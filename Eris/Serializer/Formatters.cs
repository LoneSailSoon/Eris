using System.Runtime.InteropServices;
using NaegleriaSerializer;
using NaegleriaSerializer.Streaming;
using PatcherYrSharp.Helpers;

namespace Eris.Serializer;

public static class Formatters
{
    public static void ListSerialize<T>(List<T>? list, NaegleriaSerializeStream stream)
        where T : INaegleriaSerializable
    {
        if (list is null)
        {
            var count = -1;
            stream.Process(ref count);
        }
        else
        {
            var count = list.Count;
            stream.Process(ref count);

            for (var i = 0; i < count; i++)
            {
                stream.Serialize(list[i]);
            }
        }
    }
    
    public static void ListDeserialize<T>(ref List<T>? list, NaegleriaDeserializeStream stream)
        where T : INaegleriaSerializable
    {
        var count = -1;
        stream.Process(ref count);
        if (count == -1)
        {
            list = null;
        }
        else
        {
            list = new List<T>(count);
            CollectionsMarshal.SetCount(list, count);
            for (var i = 0; i < count; i++)
            {
                list[i] = (T)stream.Deserialize()!;
            }
        }
    }

    public static void PointerSerialize<T>(this ref Pointer<T> ptr, NaegleriaSerializeStream stream)
    {
        stream.Buffer.WriteInt32((int)ptr);
    }

    public static void PointerDeserialize<T>(this ref Pointer<T> ptr, NaegleriaDeserializeStream stream)
    {
    }
}