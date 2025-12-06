using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Eris.BeonSerializer;

public class BeonSerializerReader(byte[] buffer)
{
    private byte[] _buffer = buffer;
    private int _capacity = buffer.Length;
    private int _position = 0;

    public int Capacity => _capacity;
    public int Position => _position;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private T Read<T>(int size)
    {
        var current = _position;
        _position += size;
        if (_position > _capacity)
        {
            throw new ArgumentOutOfRangeException();
        }

        return Unsafe.ReadUnaligned<T>(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(_buffer), current));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Read<T>()
    {
        return Read<T>(Unsafe.SizeOf<T>());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int ReadInt32()
    {
        return Read<int>(4);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte ReadByte()
    {
        return Read<byte>(1);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ReadBytes(in ReadOnlySpan<byte> bytes)
    {
        var current = _position;
        _position += bytes.Length;
        if (_position > _capacity)
        {
            throw new ArgumentOutOfRangeException();
        }
        Unsafe.CopyBlockUnaligned(ref MemoryMarshal.GetReference(bytes),
            ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(_buffer), current), (uint)bytes.Length);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<T> ReadBytes<T>(int length)
    {
        var current = _position;
        var byteLength = Unsafe.SizeOf<T>() * length;
        _position += byteLength;
        if (_position > _capacity)
        {
            throw new ArgumentOutOfRangeException();
        }

        return MemoryMarshal.CreateReadOnlySpan(
            ref Unsafe.As<byte, T>(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(_buffer), current)), length);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ReadString()
    {
        int length = ReadInt32();

        var current = _position;
        _position += length * 2;
        if (_position > _capacity)
        {
            throw new ArgumentOutOfRangeException();
        }

        return new string(MemoryMarshal.CreateReadOnlySpan(
            ref Unsafe.As<byte, char>(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(_buffer), current)),
            length));
    }

    public void Rest()
    {
        _buffer = null!;
        _capacity = 0;
        _position = 0;
    }
}
