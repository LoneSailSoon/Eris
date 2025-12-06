using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Eris.BeonSerializer;

public sealed class BeonSerializerWriter(int capacity)
{
    private byte[] _buffer = new byte[capacity];
    private int _capacity = capacity;
    private int _position = 0;
    
    public int  Capacity => _capacity;
    public int Count => _position;
    
    private void EnsureCapacity()
    {
        var newCapacity = _capacity * 2;
        var newBuffer = new byte[newCapacity];
        Array.Copy(_buffer, 0, newBuffer, 0, _capacity);
        _buffer = newBuffer;
        _capacity = newCapacity;
    }
    
    private void EnsureCapacity(int capacity)
    {
        var newCapacity = _capacity + capacity;
        var newBuffer = new byte[newCapacity];
        Array.Copy(_buffer, 0, newBuffer, 0, _capacity);
        _buffer = newBuffer;
        _capacity = newCapacity;
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Write<T>(in T value, int size)
    {
        var end = _position + size;
        if (end >= _capacity)
        {
            EnsureCapacity();
        }

        if (end >= _capacity)
        {
            EnsureCapacity(size);
        }

        Unsafe.WriteUnaligned(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(_buffer), _position), value);
        
        _position = end;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write<T>(in T value)
    {
        Write(value, Unsafe.SizeOf<T>());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteInt32(int value)
    {
        Write(value, 4);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteByte(byte value)
    {
        Write(value, 1);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteBytes(in ReadOnlySpan<byte> value)
    {
        var size = (uint)value.Length;
        var end = _position + size;
        
        if (_position + size >= _capacity)
        {
            EnsureCapacity();
        }
        
        if (end >= _capacity)
        {
            EnsureCapacity((int)size);
        }

        Unsafe.CopyBlockUnaligned(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(_buffer), _position), ref MemoryMarshal.GetReference(value), size);

        _position += (int)size;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteString(string str)
    {
        var size = (uint)str.Length * 2 + 4;
        var end = _position + size;

        if (_position + size >= _capacity)
        {
            EnsureCapacity();
        }

        if (end >= _capacity)
        {
            EnsureCapacity((int)size);
        }
        
        WriteInt32(str.Length);
        Unsafe.CopyBlockUnaligned(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(_buffer), _position),
            ref Unsafe.As<char, byte>(ref Unsafe.AsRef(in str.GetPinnableReference())), (uint)str.Length * 2);

        _position += (int)str.Length * 2;
    }

    public ReadOnlySpan<byte> AsSpan() => new(_buffer, 0, _position);

    public void Reset()
    {
        _position = 0;
        _buffer = null!;
    }
}
