using System.Runtime.InteropServices;
using Eris.Extension.Generic;
using Eris.Serializer;
using Eris.Utilities.Helpers;
using NaegleriaSerializer;
using NaegleriaSerializer.Streaming;

namespace Eris.Extension.Eris.Scripts;

public class GameObject : INaegleriaSerializable
{
    public static GameObject Create()
    {
        return new GameObject { _children = [] };
    }
    
    private List<Component> _children = null!;

    public bool EnumeratorLock { get; private set; }

    public void Serialize(INaegleriaStream stream)
    {
        if (stream is NaegleriaSerializeStream serializeStream)
        {
            Formatters.ListSerialize(_children, serializeStream);
        }
        else if (stream is NaegleriaDeserializeStream deserializeStream)
        {
            Formatters.ListDeserialize(ref _children!, deserializeStream);
        }
    }

    public void ForEach(Action<Component> action)
    {
        if (_children.Count == 0) return;
        
        
        EnumeratorLock = true;

        var i = 0;
        var countOfActive = 0;
        var count = _children.Count;

        for (; i < count; i++)
        {
            var component = _children[i];

            if (component.Expired) continue;

            action(component);

            if (component.Expired) continue;

            _children[i] = null!;
            _children[countOfActive] = component;
            countOfActive++;
        }

        for (; i < _children.Count; i++)
        {
            (_children[i], var component) = (null!, _children[i]);

            if (component.Expired) continue;

            _children[countOfActive] = component;
            countOfActive++;
        }

        if (countOfActive != _children.Count)
            CollectionsMarshal.SetCount(_children, countOfActive);

        EnumeratorLock = false;
        ConcatQueueComponents();
    }

    public delegate void ForEachDelegate<T>(Component component, in T data);
    public void ForEach<T>(in T args, ForEachDelegate<T> action)
    {
        if (_children.Count == 0) return;
        
        EnumeratorLock = true;

        var i = 0;
        var countOfActive = 0;
        var count = _children.Count;

        for (; i < count; i++)
        {
            var component = _children[i];

            if (component.Expired) continue;

            action(component, args);

            if (component.Expired) continue;

            _children[i] = null!;
            _children[countOfActive] = component;
            countOfActive++;
        }

        for (; i < _children.Count; i++)
        {
            (_children[i], var component) = (null!, _children[i]);

            if (component.Expired) continue;

            _children[countOfActive] = component;
            countOfActive++;
        }

        if (countOfActive != _children.Count)
            CollectionsMarshal.SetCount(_children, countOfActive);
        
        EnumeratorLock = false;
        ConcatQueueComponents();
    }

    public void ReleaseComponent(Component component)
    {
        component.Expire();
        if (!EnumeratorLock)
        {
            _children.Remove(component);
        }
    }

    public void AttachComponent(Component component)
    {
        _children.Add(component);
        component.Awake();
    }

    public void ReleaseComponentAt(int index)
    {
        if (EnumeratorLock)
        {
            _queueComponents.Add((false, null, new(index)));
        }
        else
        {
            _children.RemoveAt(index);
        }
    }

    public void InsertComponent(int index, Component component)
    {
        if (EnumeratorLock)
        {
            _queueComponents.Add((true, component, new(index)));
        }
        else
        {
            _children.Insert(index, component);
        }

    }

    public void ReleaseComponentAt(Func<int> index)
    {
        if (EnumeratorLock)
        {
            _queueComponents.Add((false, null, new(index)));
        }
        else
        {
            _children.RemoveAt(index());
        }

    }

    public void InsertComponent(Func<int> index, Component component)
    {
        if (EnumeratorLock)
        {
            _queueComponents.Add((true, component, new(index)));
        }
        else
        {
            _children.Insert(index(), component);
        }

    }

    private void ConcatQueueComponents()
    {
        if (_queueComponents.Count == 0) return;

        foreach (var (add, component, index) in _queueComponents)
        {
            if (add)
            {
                if (component is not null)
                {
                    _children.Insert(index.Value, component);
                }
            }
            else
            {
                _children.RemoveAt(index.Value);
            }
        }

        _queueComponents.Clear();
    }

    private static List<(bool add, Component? component, ValueLazy<int> index)> _queueComponents = [];

    public int SerializeType => SerializeRegister.GameObjectType;
    public ulong SerializeId { get; } = SerializeIdCreater.NewId();
}