using Eris.YRSharp.MathEx;

namespace Eris.YRSharp.Helpers;

public record struct FixedArray<T>(Pointer<T> Ptr, int Length)
{
    public FixedArray(ref T ptr, int Length) : this(Pointer<T>.AsPointer(ref ptr), Length)
    {
        
    }

    public ref T this[int index]
    {
        get
        {
            if(index >= 0 && index < Length)
                return ref Ptr[index];
            throw new IndexOutOfRangeException();
        }
    }

    public T this[Index index]
    {
        get
        {
            var i = index.GetOffset(Length);
            return i >= 0 && i < Length ? Ptr[i] : throw new IndexOutOfRangeException();
        }

        set
        {
            var i = index.GetOffset(Length);
            Ptr[i] = i >= 0 && i < Length ? value : throw new IndexOutOfRangeException();
        }
    }

    public FixedArray<T> this[Range range]
    {
        get
        {
            var start = range.Start.GetOffset(Length);
            var end = range.End.GetOffset(Length);

            if (start < 0 || end < 0 || start >= Length || end >= Length) throw new IndexOutOfRangeException();
            
            (start, end) = MathUtilities.GetMinMax(start, end);
            return new(ref Ptr[start], end - start);
        }
    }
    
    public Enumerator GetEnumerator() => new(Ptr, Length);
    
    public struct Enumerator(Pointer<T> ptr, int length)
    {
        private T _current;
        private int _index;
        
        private readonly Pointer<T> _ptr = ptr;
        private readonly int _length = length;

        public bool MoveNext()
        {
            if (_index >= _length) return false;
            _current = _ptr[_index];
            _index++;
            return true;
        }

        public T Current => _current;
    }
}