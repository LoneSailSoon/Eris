using Eris.BeonSerializer.Streaming;
using Eris.Serializer;
using Eris.Utilities.Logger;
using System.Runtime.CompilerServices;

namespace Eris.Component.Generic;

public sealed class GameObject : Component.ComponentRoot
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static GameObject Create() => new();
    public override int SerializeType => SerializeRegister.GameObjectType;

    public delegate void ForEachDelegate<T>(Component component, in T data);

    public struct ComponentSeq
    {
        private (Component Head, Component Tail)? _current;

        private (Component Head, Component Tail)? _queue;

        private int _count;
        private bool _dirt;
        private int _lock;

        private void Queue(Component component)
        {
            if (_queue is var (h, t))
                (Next(t), _queue) = (component, (h, component));
            else
                _queue = (component, component);
        }

        private void Unqueue()
        {
            if (_queue is var (qh, qt))
            {
                if (_current is var (h, t))
                    (Next(t), _current) = (qh, (h, qt));
                else
                    _current = _queue;
                _queue = null;
            }
        }

        private void Trim()
        {
            if (_current is null)
                return;

            Component? head = null;
            Component? tail = null;

            Component? current = _current?.Head;
            while (current != null)
            {
                if (IsExpired(current))
                {
                    current.Expire();
                    (current, Next(current)) = (Next(current), null);
                }

                else
                {
                    head = tail = current;
                    current = Next(current);
                    goto Any;
                }

            }

            _count = 0;  
            _current = null;
            return;

        Any:
            _count = 1;
            while (current != null)
            {
                if (IsExpired(current))
                {
                    current.Expire();
                    (current, Next(current)) = (Next(current), null);
                }
                else
                {
                    (Next(tail), tail) = (current, current);
                    _count++;
                    current = Next(current);
                }
            }
            _current = (head, tail);
            return;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ForEach(Action<Component> action)
        {
            if (_current is null) return;
            try
            {
                _lock++;
                Component? current = _current?.Head;
                while (current != null)
                {
                    if (!IsExpired(current))
                        action(current);

                    current = Next(current);
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
            finally
            {
                _lock--;
                if (_lock == 0 && _dirt)
                {
                    Unqueue();
                    Trim();
                    _dirt = false;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ForEach<T>(in T args, ForEachDelegate<T> action)
        {
            if (_current is null) return;
            try
            {
                _lock++;
                Component? current = _current?.Head;
                while (current != null)
                {
                    if (!IsExpired(current))
                        action(current, args);
                    current = Next(current);
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
            finally
            {
                _lock--;
                if (_lock == 0 && _dirt)
                {
                    Unqueue();
                    Trim();
                }
            }
        }

        public void AddComponent(Component component)
        {
            Next(component) = null;
            if (_lock == 0)
            {
                if (_current is var (h, t))
                    (Next(t), _current) = (component, (h, component));
                else
                    _current = (component, component);
                _count++;
            }
            else
            {
                Queue(component);
                Dirt();
            }
            component.Awake();
        }

        public void Dirt() => _dirt = true;

        public readonly void OnSave(BeonSerializeStream stream)
        {
            if (_lock != 0)
            {
                Console.WriteLine("wtf");
                stream.Buffer.WriteInt32(0);
            }
            else if (_count is 0 || _current is null)
            {
                stream.Buffer.WriteInt32(0);
            }
            else
            {
                stream.Buffer.WriteInt32(_count);
                stream.Buffer.WriteByte(_dirt ? (byte)1 : (byte)0);

                var current = _current?.Head;
                var i = 0;
                while (current != null)
                {
                    stream.ProcessObject(ref current);
                    i++;
                    current = Next(current!);
                }
                if (i != _count)
                    Console.WriteLine("wtf");
            }
        }

        public void OnLoad(BeonDeserializeStream stream)
        {
            var count = _count = stream.Buffer.ReadInt32();
            if (count <= 0)
                return;
            _dirt = stream.Buffer.ReadByte() != 0;

            Component? current = null;
            stream.ProcessObject(ref current);

            var head = current!;
            var tail = current!;

            for (int i = 1; i < count; i++)
            {
                stream.ProcessObject(ref current);
                (Next(tail), tail) = (current, current!);
            }
            _current = (head, tail);
        }

        public void Destroy()
        {
            if (_current is var (h, _))
            {
                while (h != null)
                {
                    if (!IsExpired(h))
                    {
                        h.Expire();
                        IsExpired(h) = true;
                    }
                    (h, Next(h)) = (Next(h), null);
                }
                _current = null;
            }
            if (_queue is var (qh, _))
            {
                while (qh != null)
                {
                    if (!IsExpired(qh))
                    {
                        qh.Expire();
                        IsExpired(qh) = true;
                    }
                    (qh, Next(qh)) = (Next(qh), null);
                }
                _queue = null;
            }
            _count = 0;
            _dirt = false;
        }

        public void RemoveComponent(Component component)
        {
            if (!IsExpired(component))
            {
                IsExpired(component) = true;
                Dirt();
            }
        }

    }

    private ComponentSeq seq;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ForEach(Action<Component> action)
    {
        if (!Expired)
            seq.ForEach(action);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ForEach<T>(in T args, ForEachDelegate<T> action)
    {
        if (!Expired)
            seq.ForEach(args, action);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void AttachComponent(Component component)
    {
        if (!Expired)
            seq.AddComponent(component);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void RemoveComponent(Component component) 
    {
        if (!Expired)
            seq.RemoveComponent(component);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Dirt()
    {
        if (!Expired)
            seq.Dirt();
    }

    public void Destroy()
    {
        ref var expired = ref IsExpired(this);
        if (!expired)
        {
            expired = true;
            seq.Destroy();
        }
    }

    protected override void OnSave(BeonSerializeStream stream)
    {
        if(!Expired)
            seq.OnSave(stream);
    }

    protected override void OnLoad(BeonDeserializeStream stream)
    {
        if (!Expired)
            seq.OnLoad(stream);
    }
}