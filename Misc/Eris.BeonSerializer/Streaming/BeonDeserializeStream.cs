using System.Runtime.CompilerServices;
using Eris.BeonSerializer.Collection;
using Activators = System.Collections.Generic.Dictionary<int, Eris.BeonSerializer.DeserializeObjectActivatorDelegate>;

namespace Eris.BeonSerializer.Streaming;

public class BeonDeserializeStream : IBeonStream
{

    private readonly SerializeObjectSet _serializeObjectSet;
    private readonly BeonStreamEnumerable _naegleriaStreamEnumerable;
    public BeonSerializerReader Buffer { get; private set; }
    private readonly Activators _activators;
    
    public BeonDeserializeStream(Activators? activators = null)
    {
        _serializeObjectSet = new();
        _naegleriaStreamEnumerable = new(_serializeObjectSet);
        Buffer = null!;
        _activators = activators ?? DeserializeObjectActivator.Activators;
    }

    public void Read(byte[] buffer)
    {
        Buffer = new(buffer);
    }
    
    
    public IBeonStream Process<T>(ref T value) where T : unmanaged
    {
        if(!RuntimeHelpers.IsReferenceOrContainsReferences<T>())
        {
            value = Buffer.Read<T>();
        }

        return this;
    }

    public IBeonStream ProcessObject<T>(ref T? value) where T : IBeonSerializable
    {
        var type = Buffer.ReadInt32();
        if (type == 0)
        {
            value = default;
            return this;
        }
        
        if (!DeserializeObjectActivator.TryGetActivator(type, out var activator, _activators)) throw new KeyNotFoundException($"key:{type}");
        
        var index = Buffer.ReadInt32();
        if (_serializeObjectSet.TryGetobject(index, out var deserializeObj))
        {
            value = (T)deserializeObj;
            return this;
        }

        var obj = activator();
        _serializeObjectSet.GetOrAdd(obj, out var current);
        if (current != index)
        {
            throw new IndexOutOfRangeException($"should {current} but {index}");
        }
        value = (T)obj;
        
        return this;
    }

    public IBeonStream ProcessInline<T>(ref T value) where T : struct, IBeonSerializable
    {
        value.Serialize(this);
        value.OnLoad(this);
        return this;
    }

    public IBeonStream ProcessStringInline(ref string? value)
    {
        if (Buffer.ReadByte() == 0)
        {
            value = null;
        }
        else
        {
            value = Buffer.ReadString();
        }
        return this;
    }

    public IBeonStream ProcessArrayUnmanaged<T>(ref T[]? value) where T : unmanaged
    {
        if (Buffer.ReadByte() == 0)
        {
            value = null;
        }
        else
        {
            var length = Buffer.ReadInt32();
            value = [..Buffer.ReadBytes<T>(length)];
        }
        return this;
    }

    public IBeonStream ProcessArrayInline<T>(ref T[]? value) where T : struct, IBeonSerializable
    {
        if (Buffer.ReadByte() == 0)
        {
            value = null;
        }
        else
        {
            var length = Buffer.ReadInt32();
            value = new T[length];

            foreach (var t in value)
            {
                t.Serialize(this);
                t.OnLoad(this);
            }
        }
        return this;
    }

    public IBeonStream ProcessObjectArrayInline<T>(ref T?[]? value) where T : IBeonSerializable
    {
        if (Buffer.ReadByte() == 0)
        {
            value = null;
        }
        else
        {
            var length = Buffer.ReadInt32();
            value = new T?[length];

            for (var i = 0; i < value.Length; i++)
            {
                
                var type = Buffer.ReadInt32();
                if (type == 0)
                {
                    value[i] = default;
                }
        
                if (!DeserializeObjectActivator.TryGetActivator(type, out var activator, _activators)) throw new KeyNotFoundException($"key:{type}");
        
                var index = Buffer.ReadInt32();
                if (_serializeObjectSet.TryGetobject(index, out var deserializeObj))
                {
                    
                    value[i] = (T)deserializeObj;
                    return this;
                }

                var obj = activator();
                _serializeObjectSet.GetOrAdd(obj, out var current);
                if (current != index)
                {
                    throw new IndexOutOfRangeException();
                }
                value[i] = (T)obj;
            }
        }
        return this;
    }

    public IBeonSerializable? Deserialize()
    {
        var type = Buffer.ReadInt32();
        if (type == 0)
        {
            return null;
        }
        
        
        if (!DeserializeObjectActivator.TryGetActivator(type, out var activator, _activators)) throw new KeyNotFoundException();
        
        var index = Buffer.ReadInt32();
        if (_serializeObjectSet.TryGetobject(index, out var value))
        {
            return value;
        }

        var obj = activator();
        _serializeObjectSet.GetOrAdd(obj, out var current);
        if (current != index)
        {
            throw new IndexOutOfRangeException($"should {current} but {index}");
        }
                
        while (_naegleriaStreamEnumerable.MoveNextOrDonothing())
        {
            _naegleriaStreamEnumerable.Current?.Serialize(this);
            _naegleriaStreamEnumerable.Current?.OnLoad(this);
        }
                
        return obj;

    }

    public void Reset()
    {
        _serializeObjectSet.Reset();
        _naegleriaStreamEnumerable.Reset();
        Buffer?.Rest();
        Buffer = null!;
    }

}
