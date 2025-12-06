using Eris.BeonSerializer.Collection;

namespace Eris.BeonSerializer.Streaming;

public class BeonStreamEnumerable(ISerializeObjectSet set) : IBeonStreamEnumerable
{
    public bool MoveNextOrDonothing()
    {
        if (!set.TryGetobject(_currentIndex, out _current)) return false;

        _currentIndex += 1;
        return true;
    }

    private int _currentIndex;

    private IBeonSerializable? _current;
    public IBeonSerializable? Current => _current;

    public void Reset()
    {
        _currentIndex = 0;
        _current = null;
    }
}