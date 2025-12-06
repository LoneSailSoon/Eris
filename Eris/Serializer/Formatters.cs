using Eris.BeonSerializer;
using Eris.BeonSerializer.Streaming;
using Eris.Utilities.Data;
using Eris.YRSharp;
using System.Runtime.InteropServices;

namespace Eris.Serializer;

public static class Formatters
{
    extension(BeonSerializeStream stream)
    {
        public void ListSerialize<T>(List<T>? list)
            where T : IBeonSerializable
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

        public BeonSerializeStream DelegateSerialize<T>(SerializableDelegate.Node<T> node)
        {
            var id = node.Id;
            stream.Process(ref id);

            if (node.Funcs is var (s, _))
                s(stream);
            return stream;
        }
    }

    extension(BeonDeserializeStream stream)
    {
        public void ListDeserialize<T>(ref List<T>? list)
        where T : IBeonSerializable
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
        public BeonDeserializeStream DelegateDeserialize<T>(ref SerializableDelegate.Node<T> node)
        {
            var id = -1;
            stream.Process(ref id);
            if (id != node.Id)
                node = new SerializableDelegate.Node<T>(id);

            if (node.Funcs is var (s, _))
                s(stream);

            return stream;
        }
    }

    extension(IBeonStream stream)
    {
        public IBeonStream Process<T>(ref YRTypePointer<T> type) where T : struct, IYRType<T>
        {
            string? id = type.Id;
            stream.ProcessStringInline(ref id);
            type.Id = id;
            return stream;
        }
    }
}