using System.Diagnostics.CodeAnalysis;

namespace Eris.BeonSerializer.Collection;

public class SerializeObjectSet : ISerializeObjectSet
{
    private readonly List<IBeonSerializable> _list = [];
    private readonly Dictionary<IBeonSerializable, int> _set = new(Comparer.Instance);

    private class Comparer : IEqualityComparer<IBeonSerializable>
    {
        public static readonly Comparer Instance = new();
        public bool Equals(IBeonSerializable? x, IBeonSerializable? y)
        {
            return ReferenceEquals(x, y);
        }

        public int GetHashCode(IBeonSerializable obj)
        {
            return HashCode.Combine(obj.SerializeId);
        }
    }

    public bool GetOrAdd(IBeonSerializable obj, out int index)
    {
        if (_set.TryGetValue(obj, out index))
        {
            return false;
        }
        else
        {
            index = _list.Count;
            _list.Add(obj);
            _set.Add(obj, index);
            return true;
        }
    }
    
    public bool Contains(IBeonSerializable obj)
    {
        ArgumentNullException.ThrowIfNull(obj);
        return _set.ContainsKey(obj);
    }

    public bool TryGetIndex(IBeonSerializable obj, out int index)
    {
        ArgumentNullException.ThrowIfNull(obj);
        return _set.TryGetValue(obj, out index);
    }

    public bool TryGetobject(int index, [NotNullWhen(true)]out IBeonSerializable? obj)
    {
        if (index >= 0 && index < _list.Count)
        {
            obj = _list[index];
            return true;
        }
        else
        {
            obj = null;
            return false;
        }
    }

    public void Reset()
    {
        _list.Clear();
        _set.Clear();
    }
    
    public IBeonSerializable this[int index] => _list[index];
    
    public int this[IBeonSerializable obj]
    {
        get
        {
            ArgumentNullException.ThrowIfNull(obj);
            return _set[obj];
        }
    }
}
