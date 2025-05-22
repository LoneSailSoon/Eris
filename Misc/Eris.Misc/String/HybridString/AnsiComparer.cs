using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Text;

namespace Eris.Misc.String.HybridString;

public static class AnsiComparer
{
    private static bool Equal(ReadOnlySpan<char> a, ReadOnlySpan<byte> bytes)
    {
        if (a.Length != bytes.Length) return false;
        for (var i = 0; i < bytes.Length; i++)
        {
            if (a[i] != bytes[i]) return false;
        }
        return true;
    }

    private static bool EqualIgnoreCase(ReadOnlySpan<char> a, ReadOnlySpan<byte> bytes)
    {
        if (bytes.Length != a.Length) return false;

        for (var i = 0; i < bytes.Length; i++)
            if (ToLower8(bytes[i]) != ToLower16(a[i]))
                return false;
        return true;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static char ToLower8(byte a) => (char)a is >= 'A' and <= 'Z' ? (char)(a + 32) : (char)a;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static char ToLower16(char a) => a is >= 'A' and <= 'Z' ? (char)(a + 32) : a;
    }

    private static readonly ulong Seed = 8991719722437783371;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int OrdinalGetHashCode(ReadOnlySpan<char> str)
    {
        return ComputeHash32(ref Unsafe.As<char, byte>(ref MemoryMarshal.GetReference(str)), (uint)str.Length * 2, (uint)Seed, (uint)(Seed >> 32));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int OrdinalGetHashCode(ReadOnlySpan<byte> str)
    {
        return ComputeHash32Ansi(ref MemoryMarshal.GetReference(str), (uint)str.Length, (uint)Seed, (uint)(Seed >> 32));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int OrdinalGetHashCodeIgnoreCase(ReadOnlySpan<char> str)
    {
        return ComputeHash32IgnoreCase(ref Unsafe.As<char, byte>(ref MemoryMarshal.GetReference(str)), (uint)str.Length * 2,
            (uint)Seed, (uint)(Seed >> 32));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int OrdinalGetHashCodeIgnoreCase(ReadOnlySpan<byte> str)
    {
        return ComputeHash32AnsiIgnoreCase(ref MemoryMarshal.GetReference(str), (uint)str.Length, (uint)Seed, (uint)(Seed >> 32));
    }

    
    private static int ComputeHash32(ref byte data, uint count, uint p0, uint p1)
    {
        if (count < 8)
        {
            if (count >= 4)
            {
                goto Between4And7BytesRemain;
            }

            goto InputTooSmallToEnterMainLoop;
        }
        
        var loopCount = count / 8;

        do
        {
            p0 += Unsafe.ReadUnaligned<uint>(ref data);
            var nextUInt32 = Unsafe.ReadUnaligned<uint>(ref Unsafe.AddByteOffset(ref data, 4));

            Block(ref p0, ref p1);
            p0 += nextUInt32;
            Block(ref p0, ref p1);
            
            data = ref Unsafe.AddByteOffset(ref data, 8);
        } while (--loopCount > 0);

        if ((count & 0b_0100) == 0)
        {
            goto DoFinalPartialRead;
        }

        Between4And7BytesRemain:
        
        p0 += Unsafe.ReadUnaligned<uint>(ref data);
        Block(ref p0, ref p1);

        DoFinalPartialRead:
        
        var partialResult =
            Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref Unsafe.AddByteOffset(ref data, (nuint)count & 7), -4));

        count = ~count << 3;

        if (BitConverter.IsLittleEndian)
        {
            partialResult >>= 8;
            partialResult |= 0x8000_0000u;
            partialResult >>= (int)count & 0x1F;
        }
        else
        {
            partialResult <<= 8;
            partialResult |= 0x80u;
            partialResult <<= (int)count & 0x1F;
        }

        DoFinalRoundsAndReturn:

        p0 += partialResult;
        Block(ref p0, ref p1);
        Block(ref p0, ref p1);

        return (int)(p1 ^ p0);

        InputTooSmallToEnterMainLoop:
        
        partialResult = BitConverter.IsLittleEndian ? 0x80u : 0x80000000u;

        if ((count & 0b_0001) != 0)
        {
            partialResult = Unsafe.AddByteOffset(ref data, (nuint)count & 2);

            if (BitConverter.IsLittleEndian)
            {
                partialResult |= 0x8000;
            }
            else
            {
                partialResult <<= 24;
                partialResult |= 0x800000u;
            }
        }

        if ((count & 0b_0010) != 0)
        {
            if (BitConverter.IsLittleEndian)
            {
                partialResult <<= 16;
                partialResult |= Unsafe.ReadUnaligned<ushort>(ref data);
            }
            else
            {
                partialResult |= Unsafe.ReadUnaligned<ushort>(ref data);
                partialResult = RotateLeft(partialResult, 16);
            }
        }

        goto DoFinalRoundsAndReturn;
    }
    
    private static int ComputeHash32Ansi(ref byte data, uint count, uint p0, uint p1)
    {
        count <<= 1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static uint AnsiToUtf16(ushort value)
        {
            const uint mask = 0b1111111100000000;

            return ((value & mask) << 8) | (value & ~mask);
        }



        if (count < 8)
        {

            if (count >= 4)
            {
                goto Between4And7BytesRemain;
            }

            goto InputTooSmallToEnterMainLoop;
        }

        uint loopCount = count / 8;

        do
        {
            p0 += AnsiToUtf16(Unsafe.ReadUnaligned<ushort>(ref data));
            uint nextUInt32 = AnsiToUtf16(Unsafe.ReadUnaligned<ushort>(ref Unsafe.AddByteOffset(ref data, 4 >> 1)));
            

            Block(ref p0, ref p1);
            p0 += nextUInt32;
            Block(ref p0, ref p1);


            data = ref Unsafe.AddByteOffset(ref data, 8 >> 1);
        } 
        while (--loopCount > 0);

        if ((count & 0b_0100) == 0)
        {
            goto DoFinalPartialRead;
        }

        Between4And7BytesRemain:

        p0 += AnsiToUtf16(Unsafe.ReadUnaligned<ushort>(ref data));
        Block(ref p0, ref p1);

        DoFinalPartialRead:
        
        uint partialResult =
            AnsiToUtf16(Unsafe.ReadUnaligned<ushort>(ref Unsafe.Add(ref Unsafe.AddByteOffset(ref data, ((nuint)count & 7) >> 1), -2)));


        count = ~count << 3;

        if (BitConverter.IsLittleEndian)
        {
            partialResult >>= 8;
            partialResult |= 0x8000_0000u;
            partialResult >>= (int)count & 0x1F;
        }
        else
        {
            partialResult <<= 8;
            partialResult |= 0x80u;
            partialResult <<= (int)count & 0x1F;
        }

        DoFinalRoundsAndReturn:

        p0 += partialResult;
        Block(ref p0, ref p1);
        Block(ref p0, ref p1);

        return (int)(p1 ^ p0);

        InputTooSmallToEnterMainLoop:

        partialResult = BitConverter.IsLittleEndian ? 0x80u : 0x80000000u;

        if ((count & 0b_0001) != 0)
        {

            partialResult = Unsafe.AddByteOffset(ref data, ((nuint)count & 2) >> 1);

            if (BitConverter.IsLittleEndian)
            {
                partialResult |= 0x8000;
            }
            else
            {
                partialResult <<= 24;
                partialResult |= 0x800000u;
            }
        }

        if ((count & 0b_0010) != 0)
        {

            if (BitConverter.IsLittleEndian)
            {
                partialResult <<= 16;
                partialResult |= Unsafe.ReadUnaligned<byte>(ref data);
            }
            else
            {
                partialResult |= Unsafe.ReadUnaligned<byte>(ref data);
                partialResult = RotateLeft(partialResult, 16);
            }
        }

        goto DoFinalRoundsAndReturn;
    }
    
    private static int ComputeHash32IgnoreCase(ref byte data, uint count, uint p0, uint p1)
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static uint ToToLower32(uint value)
        {
            const uint mask = 0b_1111_1111_1111_1111_0000_0000_0000_0000;
            var us1 = (ushort)((value & mask) >> 16);
            us1 = us1 is >= 'A' and <= 'Z' ? (char)(us1 + 32) : us1;
            var us2 = (ushort)(value & ~mask);
            us2 = us2 is >= 'A' and <= 'Z' ? (char)(us2 + 32) : us2;
            return ((uint)us1 << 16) | us2;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ushort ToToLower16(ushort value)
        {
            return value is >= 'A' and <= 'Z' ? (char)(value + 32) : value;
        }
        
        if (count < 8)
        {
            if (count >= 4)
            {
                goto Between4And7BytesRemain;
            }

            goto InputTooSmallToEnterMainLoop;
        }
        
        var loopCount = count / 8;

        do
        {
            p0 += ToToLower32(Unsafe.ReadUnaligned<uint>(ref data));
            var nextUInt32 = ToToLower32(Unsafe.ReadUnaligned<uint>(ref Unsafe.AddByteOffset(ref data, 4)));

            Block(ref p0, ref p1);
            p0 += nextUInt32;
            Block(ref p0, ref p1);
            
            data = ref Unsafe.AddByteOffset(ref data, 8);
        } while (--loopCount > 0);

        if ((count & 0b_0100) == 0)
        {
            goto DoFinalPartialRead;
        }

        Between4And7BytesRemain:
        
        p0 += ToToLower32(Unsafe.ReadUnaligned<uint>(ref data));
        Block(ref p0, ref p1);

        DoFinalPartialRead:
        
        var partialResult =
            ToToLower32(Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref Unsafe.AddByteOffset(ref data, (nuint)count & 7), -4)));

        count = ~count << 3;

        if (BitConverter.IsLittleEndian)
        {
            partialResult >>= 8;
            partialResult |= 0x8000_0000u;
            partialResult >>= (int)count & 0x1F;
        }
        else
        {
            partialResult <<= 8;
            partialResult |= 0x80u;
            partialResult <<= (int)count & 0x1F;
        }

        DoFinalRoundsAndReturn:

        p0 += partialResult;
        Block(ref p0, ref p1);
        Block(ref p0, ref p1);

        return (int)(p1 ^ p0);

        InputTooSmallToEnterMainLoop:
        
        partialResult = BitConverter.IsLittleEndian ? 0x80u : 0x80000000u;

        if ((count & 0b_0001) != 0)
        {
            partialResult = Unsafe.AddByteOffset(ref data, (nuint)count & 2);

            if (BitConverter.IsLittleEndian)
            {
                partialResult |= 0x8000;
            }
            else
            {
                partialResult <<= 24;
                partialResult |= 0x800000u;
            }
        }

        if ((count & 0b_0010) != 0)
        {
            if (BitConverter.IsLittleEndian)
            {
                partialResult <<= 16;
                partialResult |= ToToLower16(Unsafe.ReadUnaligned<ushort>(ref data));
            }
            else
            {
                partialResult |= ToToLower16(Unsafe.ReadUnaligned<ushort>(ref data));
                partialResult = RotateLeft(partialResult, 16);
            }
        }

        goto DoFinalRoundsAndReturn;
    }
    
    private static int ComputeHash32AnsiIgnoreCase(ref byte data, uint count, uint p0, uint p1)
    {
        count <<= 1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static uint AnsiToUtf16(ushort value)
        {
            const uint mask = 0b1111111100000000;
            var us1 = (ushort)((value & mask) >> 8);
            us1 = us1 is >= 'A' and <= 'Z' ? (char)(us1 + 32) : us1;
            var us2 = (ushort)(value & ~mask);
            us2 = us2 is >= 'A' and <= 'Z' ? (char)(us2 + 32) : us2;
            
            return ((uint)us1 << 16) | us2;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ushort AnsiToUtf16Bit16(byte value)
        {
            ushort us = value;
            return us is >= 'A' and <= 'Z' ? (char)(us + 32) : us;
        }


        if (count < 8)
        {

            if (count >= 4)
            {
                goto Between4And7BytesRemain;
            }

            goto InputTooSmallToEnterMainLoop;
        }

        uint loopCount = count / 8;

        do
        {
            p0 += AnsiToUtf16(Unsafe.ReadUnaligned<ushort>(ref data));
            uint nextUInt32 = AnsiToUtf16(Unsafe.ReadUnaligned<ushort>(ref Unsafe.AddByteOffset(ref data, 4 >> 1)));
            

            Block(ref p0, ref p1);
            p0 += nextUInt32;
            Block(ref p0, ref p1);


            data = ref Unsafe.AddByteOffset(ref data, 8 >> 1);
        } 
        while (--loopCount > 0);

        if ((count & 0b_0100) == 0)
        {
            goto DoFinalPartialRead;
        }

        Between4And7BytesRemain:

        p0 += AnsiToUtf16(Unsafe.ReadUnaligned<ushort>(ref data));
        Block(ref p0, ref p1);

        DoFinalPartialRead:
        
        uint partialResult =
            AnsiToUtf16(Unsafe.ReadUnaligned<ushort>(ref Unsafe.Add(ref Unsafe.AddByteOffset(ref data, ((nuint)count & 7) >> 1), -2)));


        count = ~count << 3;

        if (BitConverter.IsLittleEndian)
        {
            partialResult >>= 8;
            partialResult |= 0x8000_0000u;
            partialResult >>= (int)count & 0x1F;
        }
        else
        {
            partialResult <<= 8;
            partialResult |= 0x80u;
            partialResult <<= (int)count & 0x1F;
        }

        DoFinalRoundsAndReturn:

        p0 += partialResult;
        Block(ref p0, ref p1);
        Block(ref p0, ref p1);

        return (int)(p1 ^ p0);

        InputTooSmallToEnterMainLoop:

        partialResult = BitConverter.IsLittleEndian ? 0x80u : 0x80000000u;

        if ((count & 0b_0001) != 0)
        {

            partialResult = Unsafe.AddByteOffset(ref data, ((nuint)count & 2) >> 1);

            if (BitConverter.IsLittleEndian)
            {
                partialResult |= 0x8000;
            }
            else
            {
                partialResult <<= 24;
                partialResult |= 0x800000u;
            }
        }

        if ((count & 0b_0010) != 0)
        {

            if (BitConverter.IsLittleEndian)
            {
                partialResult <<= 16;
                partialResult |= AnsiToUtf16Bit16(Unsafe.ReadUnaligned<byte>(ref data));
            }
            else
            {
                partialResult |= AnsiToUtf16Bit16(Unsafe.ReadUnaligned<byte>(ref data));
                partialResult = RotateLeft(partialResult, 16);
            }
        }

        goto DoFinalRoundsAndReturn;
    }
    

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void Block(ref uint rp0, ref uint rp1)
    {
        var p0 = rp0;
        var p1 = rp1;

        p1 ^= p0;
        p0 = RotateLeft(p0, 20);

        p0 += p1;
        p1 = RotateLeft(p1, 9);

        p1 ^= p0;
        p0 = RotateLeft(p0, 27);

        p0 += p1;
        p1 = RotateLeft(p1, 19);

        rp0 = p0;
        rp1 = p1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint RotateLeft(uint value, int shift)
    {
        return (value << shift) | (value >> (32 - shift));
    }
    
    public static readonly AnsiOrdinalComparerParer Ordinal = new();
    public static readonly AnsiOrdinalIgnoreCaseComparerParer OrdinalIgnoreCase = new();
    
    public sealed class AnsiOrdinalComparerParer : IEqualityComparer<string>, IAlternateEqualityComparer<ReadOnlySpan<byte>, string>
    {
        internal AnsiOrdinalComparerParer()
        {
            
        }
        
        public bool Equals(string? x, string? y)
        {
            return string.Equals(x, y);
        }

        public int GetHashCode(string obj)
        {
            return OrdinalGetHashCode(obj);
        }

        public bool Equals(ReadOnlySpan<byte> alternate, string other)
        {
            return Equal(other, alternate);
        }

        public bool Equals(ReadOnlySpan<byte> left, ReadOnlySpan<byte> right)
        {
            return left.SequenceEqual(right);
        }

        public int GetHashCode(ReadOnlySpan<byte> alternate)
        {
            return OrdinalGetHashCode(alternate);
        }

        public string Create(ReadOnlySpan<byte> alternate)
        {
            return Encoding.ASCII.GetString(alternate);
        }
    }
    
        
    public sealed class AnsiOrdinalIgnoreCaseComparerParer : IEqualityComparer<string>, IAlternateEqualityComparer<ReadOnlySpan<byte>, string>
    {
        internal AnsiOrdinalIgnoreCaseComparerParer()
        {
            
        }
        
        public bool Equals(string? x, string? y)
        {
            return string.Equals(x, y, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(string obj)
        {
            return OrdinalGetHashCodeIgnoreCase(obj);
        }

        public bool Equals(ReadOnlySpan<byte> alternate, string other)
        {
            return EqualIgnoreCase(other, alternate);
        }

        public int GetHashCode(ReadOnlySpan<byte> alternate)
        {
            return OrdinalGetHashCodeIgnoreCase(alternate);
        }

        public string Create(ReadOnlySpan<byte> alternate)
        {
            return Encoding.ASCII.GetString(alternate);
        }
    }
}