using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.BeonSerializer.Collection;

namespace Eris.BeonSerializer.Streaming;

public class BeonSerializeStream : IBeonStream
{
    private readonly SerializeObjectSet _serializeObjectSet;
    private readonly BeonStreamEnumerable _naegleriaStreamEnumerable;
    public BeonSerializerWriter Buffer { get; private set; }

    public BeonSerializeStream()
    {
        _serializeObjectSet = new();
        _naegleriaStreamEnumerable = new(_serializeObjectSet);
        Buffer = null!;
    }

    public void Write()
    {
        Buffer = new BeonSerializerWriter(10);
    }


    public IBeonStream Process<T>(ref T value) where T : unmanaged
    {
        if (!RuntimeHelpers.IsReferenceOrContainsReferences<T>())
        {
            Buffer.Write(value);
        }

        return this;
    }

    public IBeonStream ProcessObject<T>(ref T? value) where T : IBeonSerializable
    {
        if (value is null)
        {
            Buffer.WriteInt32(0);
        }
        else
        {
            _serializeObjectSet.GetOrAdd(value, out var index);
            Buffer.WriteInt32(value.SerializeType);
            Buffer.WriteInt32(index);
        }
        return this;
    }

    public IBeonStream ProcessInline<T>(ref T value) where T : struct, IBeonSerializable
    {
        value.Serialize(this);
        value.OnSave(this);
        return this;
    }

    public IBeonStream ProcessStringInline(ref string? value)
    {
        if (value is null)
        {
            Buffer.WriteByte(0);
        }
        else
        {
            Buffer.WriteByte(1);
            Buffer.WriteString(value);
        }
        return this;
    }

    public IBeonStream ProcessArrayUnmanaged<T>(ref T[]? value) where T : unmanaged
    {
        if (value is null)
        {
            Buffer.WriteByte(0);
        }
        else
        {
            Buffer.WriteByte(1);
            Buffer.WriteInt32(value.Length);
            Buffer.WriteBytes(MemoryMarshal.CreateSpan(ref Unsafe.As<T, byte>(ref MemoryMarshal.GetArrayDataReference(value)), value.Length * Unsafe.SizeOf<T>()));
        }
        return this;
    }

    public IBeonStream ProcessArrayInline<T>(ref T[]? value) where T : struct, IBeonSerializable
    {
        if (value is null)
        {
            Buffer.WriteByte(0);
        }
        else
        {
            Buffer.WriteByte(1);
            Buffer.WriteInt32(value.Length);
            foreach (var t in value)
            {
                t.Serialize(this);
                t.OnSave(this);
            }
        }
        return this;
    }

    public IBeonStream ProcessObjectArrayInline<T>(ref T?[]? value) where T : IBeonSerializable
    {
        if (value is null)
        {
            Buffer.WriteByte(0);
        }
        else
        {
            Buffer.WriteByte(1);
            Buffer.WriteInt32(value.Length);
            foreach (var t in value)
            {
                if (t is null)
                {
                    Buffer.WriteInt32(0);
                }
                else
                {
                    _serializeObjectSet.GetOrAdd(t, out var index);
                    Buffer.WriteInt32(t.SerializeType);
                    Buffer.WriteInt32(index);
                }
            }
        }
        return this;
    }

    public void Serialize(IBeonSerializable value)
    {
        _serializeObjectSet.GetOrAdd(value, out var index);

        Buffer.WriteInt32(value.SerializeType);
        Buffer.WriteInt32(index);

        while (_naegleriaStreamEnumerable.MoveNextOrDonothing())
        {
            _naegleriaStreamEnumerable.Current?.Serialize(this);
            _naegleriaStreamEnumerable.Current?.OnSave(this);
        }
    }

    public void Reset()
    {
        _serializeObjectSet.Reset();
        _naegleriaStreamEnumerable.Reset();
        Buffer?.Reset();
        Buffer = null!;
    }
}
