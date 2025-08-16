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

    public static bool EqualIgnoreCaseSimd(ReadOnlySpan<byte> a, ReadOnlySpan<byte> bytes)
    {
        const uint casemask = 0b_0010_0000_0010_0000_0010_0000_0010_0000;

        if (a.Length != bytes.Length) return false;
        var length = a.Length;
        
        if (!Vector128.IsHardwareAccelerated || length < Vector128<byte>.Count)
        {
            return EqualsIgnoreCaseScalar(ref MemoryMarshal.GetReference(a), ref MemoryMarshal.GetReference(bytes), length);
        }
        if (Vector512.IsHardwareAccelerated && length >= Vector512<byte>.Count)
        {
            return EqualsIgnoreCaseVector512(ref MemoryMarshal.GetReference(a), ref MemoryMarshal.GetReference(bytes), length);
        }
        if (Vector256.IsHardwareAccelerated && length >= Vector256<byte>.Count)
        {
            return EqualsIgnoreCaseVector256(ref MemoryMarshal.GetReference(a), ref MemoryMarshal.GetReference(bytes), length);
        }
        return EqualsIgnoreCaseVector128(ref MemoryMarshal.GetReference(a), ref MemoryMarshal.GetReference(bytes), length);
        
        
        static bool EqualsIgnoreCaseScalar(ref byte charA, ref byte charB, int length)
        {
            const uint hightMask = 0b_1100_0000_1100_0000_1100_0000_1100_0000;
            const uint lowMask = 0b_0001_1111_0001_1111_0001_1111_0001_1111;

            // const uint hight = 0b_0100_0000_0100_0000_0100_0000_0100_0000;
            const uint low = 0b_0000_0101_0000_0101_0000_0101_0000_0101;

            // const uint def = 0b_0010_0001_0010_0001_0010_0001_0010_0001;
            const uint one = 0b_0000_0001_0000_0001_0000_0001_0000_0001;

            var valueAu32 = 0u;
            var valueBu32 = 0u;

            var byteOffset = 0;

            while ((uint)length >= 4)
            {
                valueAu32 = Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref charA, byteOffset));
                valueBu32 = Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref charB, byteOffset));


                var difference = valueAu32 ^ valueBu32;

                // Console.WriteLine($"{difference:b}");
                // Console.WriteLine($"{IsWord(valueAu32, difference)}");
                // Console.WriteLine($"{IsWord(valueBu32, difference)}");


                if (difference != 0 && ((difference | casemask) != casemask || !IsWord(valueAu32, difference) ||
                                        !IsWord(valueBu32, difference)))
                {
                    return false;
                }

                byteOffset += 4;
                length -= 4;
            }

            if (length != 0)
            {
                byte ba = 0;
                byte bb = 0;

                while ((uint)length > 0)
                {
                    ba = Unsafe.Add(ref charA, byteOffset);
                    bb = Unsafe.Add(ref charB, byteOffset);

                    var difference = ba ^ bb;

                    if (difference != 0 &&
                        ((difference | 0b_0010_0000) != 0b_0010_0000 ||
                         !((char)ba is >= 'a' and <= 'z' or >= 'A' and <= 'Z' &&
                           (char)ba is >= 'a' and <= 'z' or >= 'A' and <= 'Z')))
                    {
                        return false;
                    }

                    byteOffset++;
                    length--;
                }
            }

            return true;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            bool IsWord(uint word, uint mask)
            {
                //排除非0b_01**_****
                //word & hightMask:            >> 1
                //0b_11**_**** -> 0b_1100_0000 -> 0b_0110_0000
                //0b_10**_**** -> 0b_1000_0000 -> 0b_0100_0000
                //0b_01**_**** -> 0b_0100_0000 -> 0b_0010_0000
                //0b_00**_**** -> 0b_0000_0000 -> 0b_0000_0000

                var hightValue = (word & hightMask) >> 1;

                //@1
                //hightValue & casemask
                //0b_0110_0000 -> 0b_0010_0000
                //0b_0100_0000 -> 0b_0000_0000
                //0b_0010_0000 -> 0b_0010_0000
                //0b_0000_0000 -> 0b_0000_0000

                //@2
                //(hightValue >> 1) & casemask
                //0b_0110_0000 -> 0b_0010_0000
                //0b_0100_0000 -> 0b_0000_0000
                //0b_0010_0000 -> 0b_0000_0000
                //0b_0000_0000 -> 0b_0000_0000

                //@1^@2
                //0b_0110_0000 -> 0b_0000_0000 x
                //0b_0100_0000 -> 0b_0000_0000 x
                //0b_0010_0000 -> 0b_0010_0000 v
                //0b_0000_0000 -> 0b_0000_0000 x

                if ((((hightValue & casemask) ^ (hightValue & (hightValue >> 1) & casemask)) & mask) != mask)
                    return false;

                //排除非字母
                //word & lowMask                                             | casemask                     - one                            & mask
                //0b_01*0_0000                -> 0b_0000_0000                -> 0b_0010_0000                -> 0b_0001_1111                -> 0b_0000_0000 x
                //0b_01*0_0001 ~ 0b_01*1_1010 -> 0b_0000_0001 ~ 0b_0001_1010 -> 0b_0010_0001 ~ 0b_0011_1010 -> 0b_0010_0000 ~ 0b_0011_1001 -> 0b_0010_0000 v
                //0b_01*1_1011 ~ 0b_01*1_1111 -> 0b_0001_1011 ~ 0b_0001_1111 -> 0b_0011_1011 ~ 0b_0011_1111 -> 0b_0011_1010 ~ 0b_0011_1110 -> 0b_0010_0000 v


                var lowvalue = word & lowMask;

                if ((((lowvalue | casemask) - one) & mask) != mask) return false;

                //+ low                                                      & mask
                //0b_0010_0001 ~ 0b_0011_1010 -> 0b_0010_0110 ~ 0b_0011_1111 -> 0b_0010_0000 ~ 0b_0010_0000 v
                //0b_0011_1011 ~ 0b_0011_1111 -> 0b_0100_0000 ~ 0b_0100_0100 -> 0b_0000_0000 ~ 0b_0000_0000 x

                lowvalue += low;

                return (lowvalue & mask) == 0;
            }
        }

        static bool EqualsIgnoreCaseVector512(ref byte charA, ref byte charB, int length)
        {
            var lengthU = (nuint)length;
            var lengthToExamine = lengthU - (nuint)Vector512<byte>.Count;
            nuint i = 0;

            Vector512<byte> vec1;
            Vector512<byte> vec2;

            var loweringMask = Vector512.Create<byte>(0x20);
            var vecA = Vector512.Create<byte>((byte)'a');
            var vecZMinusA = Vector512.Create<byte>('z' - 'a');

            do
            {
                vec1 = Vector512.LoadUnsafe(ref charA, i);
                vec2 = Vector512.LoadUnsafe(ref charB, i);

                var notEquals = ~Vector512.Equals(vec1, vec2);
                if (!notEquals.Equals(Vector512<byte>.Zero))
                {
                    // not exact match
                    vec1 |= loweringMask;
                    vec2 |= loweringMask;
                    if (Vector512.GreaterThanAny((vec1 - vecA) & notEquals, vecZMinusA) || !vec1.Equals(vec2))
                    {
                        return false; // first input isn't in [A-Za-z], and not exact match of lowered
                    }
                }

                i += (nuint)Vector512<byte>.Count;
            } while (i <= lengthToExamine);

            if (i != lengthU)
            {
                i = lengthU - (nuint)Vector512<byte>.Count;
                vec1 = Vector512.LoadUnsafe(ref charA, i);
                vec2 = Vector512.LoadUnsafe(ref charB, i);

                var notEquals = ~Vector512.Equals(vec1, vec2);
                if (notEquals.Equals(Vector512<byte>.Zero)) return true;
                // not exact match
                vec1 |= loweringMask;
                vec2 |= loweringMask;

                return !Vector512.GreaterThanAny((vec1 - vecA) & notEquals, vecZMinusA) && vec1.Equals(vec2);
                // first input isn't in [A-Za-z], and not exact match of lowered
            }

            return true;
        }

        static bool EqualsIgnoreCaseVector256(ref byte charA, ref byte charB, int length)
        {
            var lengthU = (nuint)length;
            var lengthToExamine = lengthU - (nuint)Vector256<byte>.Count;
            nuint i = 0;

            Vector256<byte> vec1;
            Vector256<byte> vec2;

            var loweringMask = Vector256.Create<byte>(0x20);
            var vecA = Vector256.Create<byte>((byte)'a');
            var vecZMinusA = Vector256.Create<byte>('z' - 'a');

            do
            {
                vec1 = Vector256.LoadUnsafe(ref charA, i);
                vec2 = Vector256.LoadUnsafe(ref charB, i);

                var notEquals = ~Vector256.Equals(vec1, vec2);
                if (!notEquals.Equals(Vector256<byte>.Zero))
                {
                    // not exact match
                    vec1 |= loweringMask;
                    vec2 |= loweringMask;
                    if (Vector256.GreaterThanAny((vec1 - vecA) & notEquals, vecZMinusA) || !vec1.Equals(vec2))
                    {
                        return false; // first input isn't in [A-Za-z], and not exact match of lowered
                    }
                }

                i += (nuint)Vector256<byte>.Count;
            } while (i <= lengthToExamine);

            if (i != lengthU)
            {
                i = lengthU - (nuint)Vector256<byte>.Count;
                vec1 = Vector256.LoadUnsafe(ref charA, i);
                vec2 = Vector256.LoadUnsafe(ref charB, i);

                var notEquals = ~Vector256.Equals(vec1, vec2);
                if (notEquals.Equals(Vector256<byte>.Zero)) return true;
                // not exact match
                vec1 |= loweringMask;
                vec2 |= loweringMask;

                return !Vector256.GreaterThanAny((vec1 - vecA) & notEquals, vecZMinusA) && vec1.Equals(vec2);
                // first input isn't in [A-Za-z], and not exact match of lowered
            }

            return true;
        }

        static bool EqualsIgnoreCaseVector128(ref byte charA, ref byte charB, int length)
        {
            var lengthU = (nuint)length;
            var lengthToExamine = lengthU - (nuint)Vector128<byte>.Count;
            nuint i = 0;

            Vector128<byte> vec1;
            Vector128<byte> vec2;

            var loweringMask = Vector128.Create<byte>(0x20);
            var vecA = Vector128.Create<byte>((byte)'a');
            var vecZMinusA = Vector128.Create<byte>('z' - 'a');

            do
            {
                vec1 = Vector128.LoadUnsafe(ref charA, i);
                vec2 = Vector128.LoadUnsafe(ref charB, i);

                var notEquals = ~Vector128.Equals(vec1, vec2);
                if (!notEquals.Equals(Vector128<byte>.Zero))
                {
                    // not exact match
                    vec1 |= loweringMask;
                    vec2 |= loweringMask;
                    if (Vector128.GreaterThanAny((vec1 - vecA) & notEquals, vecZMinusA) || !vec1.Equals(vec2))
                    {
                        return false; // first input isn't in [A-Za-z], and not exact match of lowered
                    }
                }

                i += (nuint)Vector128<byte>.Count;
            } while (i <= lengthToExamine);

            if (i != lengthU)
            {
                i = lengthU - (nuint)Vector128<byte>.Count;
                vec1 = Vector128.LoadUnsafe(ref charA, i);
                vec2 = Vector128.LoadUnsafe(ref charB, i);

                var notEquals = ~Vector128.Equals(vec1, vec2);
                if (notEquals.Equals(Vector128<byte>.Zero)) return true;
                // not exact match
                vec1 |= loweringMask;
                vec2 |= loweringMask;

                return !Vector128.GreaterThanAny((vec1 - vecA) & notEquals, vecZMinusA) && vec1.Equals(vec2);
                // first input isn't in [A-Za-z], and not exact match of lowered
            }

            return true;
        }
    }

    private static readonly ulong Seed = 8991719722437783371;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int OrdinalGetHashCode(ReadOnlySpan<char> str)
    {
        return ComputeHash32(ref Unsafe.As<char, byte>(ref MemoryMarshal.GetReference(str)), (uint)str.Length * 2,
            (uint)Seed, (uint)(Seed >> 32));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int OrdinalGetHashCode(ReadOnlySpan<byte> str)
    {
        return ComputeHash32Ansi(ref MemoryMarshal.GetReference(str), (uint)str.Length, (uint)Seed, (uint)(Seed >> 32));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int OrdinalGetHashCodeIgnoreCase(ReadOnlySpan<char> str)
    {
        return ComputeHash32IgnoreCase(ref Unsafe.As<char, byte>(ref MemoryMarshal.GetReference(str)),
            (uint)str.Length * 2,
            (uint)Seed, (uint)(Seed >> 32));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int OrdinalGetHashCodeIgnoreCase(ReadOnlySpan<byte> str)
    {
        return ComputeHash32AnsiIgnoreCase(ref MemoryMarshal.GetReference(str), (uint)str.Length, (uint)Seed,
            (uint)(Seed >> 32));
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
        } while (--loopCount > 0);

        if ((count & 0b_0100) == 0)
        {
            goto DoFinalPartialRead;
        }

        Between4And7BytesRemain:

        p0 += AnsiToUtf16(Unsafe.ReadUnaligned<ushort>(ref data));
        Block(ref p0, ref p1);

        DoFinalPartialRead:

        uint partialResult =
            AnsiToUtf16(
                Unsafe.ReadUnaligned<ushort>(ref Unsafe.Add(ref Unsafe.AddByteOffset(ref data, ((nuint)count & 7) >> 1),
                    -2)));


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
            ToToLower32(
                Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref Unsafe.AddByteOffset(ref data, (nuint)count & 7), -4)));

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
        } while (--loopCount > 0);

        if ((count & 0b_0100) == 0)
        {
            goto DoFinalPartialRead;
        }

        Between4And7BytesRemain:

        p0 += AnsiToUtf16(Unsafe.ReadUnaligned<ushort>(ref data));
        Block(ref p0, ref p1);

        DoFinalPartialRead:

        uint partialResult =
            AnsiToUtf16(
                Unsafe.ReadUnaligned<ushort>(ref Unsafe.Add(ref Unsafe.AddByteOffset(ref data, ((nuint)count & 7) >> 1),
                    -2)));


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

    public sealed class AnsiOrdinalComparerParer : IEqualityComparer<string>,
        IAlternateEqualityComparer<ReadOnlySpan<byte>, string>
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


    public sealed class AnsiOrdinalIgnoreCaseComparerParer : IEqualityComparer<string>,
        IAlternateEqualityComparer<ReadOnlySpan<byte>, string>
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

        public bool Equals(ReadOnlySpan<byte> left, ReadOnlySpan<byte> right)
        {
            return EqualIgnoreCaseSimd(left, right);
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