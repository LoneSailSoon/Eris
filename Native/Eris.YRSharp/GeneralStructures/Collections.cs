using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.YRSharp.Helpers;

namespace Eris.YRSharp.GeneralStructures;

[StructLayout(LayoutKind.Sequential)]
public struct DynamicVectorClass<T> : IEnumerable<T>
{
    public static ref DynamicVectorClass<T> GetDynamicVector(nint ptr) => ref Helper.GetUnmanagedRef<DynamicVectorClass<T>>(ptr);

    public ref T this[int index] => ref Get(index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ref T Get(int index) => ref Helper.GetUnmanagedRef<T>(Items, index);

    public Span<T> AsSpan()
    {
        return Helper.GetSpan<T>(Items, Count);
    }

    public unsafe bool OperatorEqual(Pointer<DynamicVectorClass<T>> pOther)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)this.GetVirtualFunctionPointer(1);
        return func(this.GetThisPointer(), pOther);
    }

    public unsafe bool SetCapacity(int capacity, Pointer<T> pMem = default)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, nint, bool>)this.GetVirtualFunctionPointer(2);
        return func(this.GetThisPointer(), capacity, pMem);
    }

    public unsafe void Clear()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(3);
        func(this.GetThisPointer());
    }

    public unsafe int FindItemIndex(Pointer<T> pItem)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int>)this.GetVirtualFunctionPointer(4);
        return func(this.GetThisPointer(), pItem);
    }

    public unsafe int GetItemIndex(Pointer<T> pItem)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int>)this.GetVirtualFunctionPointer(5);
        return func(this.GetThisPointer(), pItem);
    }

    public bool AddItem(T item)
    {
        if (Count >= Capacity)
        {
            if (!IsAllocated && Capacity != 0)
                return false;

            if (CapacityIncrement <= 0)
                return false;

            if (!SetCapacity(Capacity + CapacityIncrement))
                return false;
        }

        this[Count++] = item;
        return true;
    }

    public bool AddUnique(Pointer<T> pItem)
    {
        int idx = FindItemIndex(pItem);
        return idx < 0 && AddItem(pItem.Ref);
    }

    public struct Enumerator(Pointer<T> items, int count) : IEnumerator<T>
    {
        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_index >= count) return false;
            
            _current = items[_index];
            _index++;
            return true;
        }

        public T Current => _current;

        object IEnumerator.Current => Current;

        public void Reset()
        {
            _index = 0;
            _current = default;
        }

        private int _index;
        private T _current;
    }
    
    public Enumerator GetEnumerator() => new(Items, Count);

    IEnumerator<T> IEnumerable<T>.GetEnumerator() => new Enumerator(Items, Count);

    IEnumerator IEnumerable.GetEnumerator() => new Enumerator(Items, Count);

    private nint Vfptr;
    public nint Items;
    public int Capacity;
    public Bool IsInitialized;
    public Bool IsAllocated;
    public int Count;
    public int CapacityIncrement;
}

[StructLayout(LayoutKind.Sequential)]
public struct Vector<T> : IEnumerable<T>
{
    public struct Enumerator(Pointer<T> items, int count) : IEnumerator<T>
    {
        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_index >= count) return false;
            
            _current = items[_index];
            _index++;
            return true;
        }

        public T Current => _current;

        object IEnumerator.Current => Current;

        public void Reset()
        {
            _index = 0;
            _current = default;
        }

        private int _index;
        private T _current;
    }

    public Enumerator GetEnumerator() => new(Items, Capacity);
    
    IEnumerator<T> IEnumerable<T>.GetEnumerator() => new Enumerator(Items, Capacity);

    IEnumerator IEnumerable.GetEnumerator() => new Enumerator(Items, Capacity);
    

    public nint Vfptr;
    public nint Items;
    public int Capacity;
    public Bool IsInitialized;
    public Bool IsAllocated;
    public byte align1;
    public byte align2;

    public ref T this[int index] => ref Get(index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ref T Get(int index) => ref Helper.GetUnmanagedRef<T>(Items, index);
}