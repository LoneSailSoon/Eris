using Eris.BeonSerializer.Streaming;
using System.Diagnostics.CodeAnalysis;

namespace Eris.Utilities.Data;

public static class SerializableDelegate
{
    private static readonly Dictionary<int, object> _map = [];

    private static int _id = 0;
    public static Node<TFunc>.Factory New<TFunc>(Func<(Action<IBeonStream>, TFunc)> func)
    {
        var f = new Node<TFunc>.Factory(func, _id);
        _map.Add(_id, func);
        _id++;
        return f;
    }

    public readonly struct Node<TFunc>
    {
        private Node(Action<IBeonStream> s, TFunc f, int i)
        {
            Funcs = (s, f);
            Id = i;
        }

        public Node(int id)
        {
            if (TryGet(id, out var f))
            {
                Id = id;
                Funcs = f();
            }
            Id = -1;
        }

        private static bool TryGet(int id, [NotNullWhen(true)] out Func<(Action<IBeonStream>, TFunc)>? value)
        {
            if (_map.TryGetValue(id, out var f) && f is Func<(Action<IBeonStream>, TFunc)> func)
            {
                value = func;
                return true;
            }
            value = null;
            return false;
        }

        public readonly (Action<IBeonStream>, TFunc)? Funcs;

        public readonly int Id;

        public sealed class Factory(Func<(Action<IBeonStream>, TFunc)> func, int id)
        {
            private readonly Func<(Action<IBeonStream>, TFunc)> _func = func;
            private readonly int _id = id;

            public Node<TFunc> Borrow()
            {
                var (s, f) = _func();
                return new(s, f, _id);
            }
        }
    }
}

