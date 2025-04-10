using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PatcherYrSharp.Helpers;

namespace PatcherYrSharp.GeneralStructures;

[StructLayout(LayoutKind.Sequential)]
public struct DynamicVectorClass<T> : IEnumerable<T>
{
    public static ref DynamicVectorClass<T> GetDynamicVector(IntPtr ptr)
    {
        return ref Helper.GetUnmanagedRef<DynamicVectorClass<T>>(ptr);
    }

    public ref T this[int index]
    {
        get
        {
            //if (index < 0 || index >= Count)
            //{
            //    throw new IndexOutOfRangeException();
            //}
            return ref Get(index);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ref T Get(int index) => ref Helper.GetUnmanagedRef<T>(Items, index);

    public Span<T> GetSpan()
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

    class Enumerator : IEnumerator<T>, IEnumerator
    {
        internal Enumerator(Pointer<T> items, int count)
        {
            this.items = items;
            this.count = count;
            Reset();
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (index < count)
            {
                current = items[index];
                index++;
                return true;
            }

            return false;
        }

        public T Current => current;

        object IEnumerator.Current => Current;

        public void Reset()
        {
            index = 0;
            current = default(T);
        }

        private Pointer<T> items;
        private int count;
        private int index;
        private T current;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new Enumerator(Items, Count);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

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
    class Enumerator : IEnumerator<T>, IEnumerator
    {
        internal Enumerator(Pointer<T> Items, int Count)
        {
            items = Items;
            count = Count;
            Reset();
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (index < count)
            {
                current = items[index];
                index++;
                return true;
            }

            return false;
        }

        public T Current => current;

        object IEnumerator.Current => Current;

        public void Reset()
        {
            index = 0;
            current = default(T);
        }

        private Pointer<T> items;
        private int count;
        private int index;
        private T current;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new Enumerator(Items, Capacity);
    }

    IEnumerator IEnumerable.GetEnumerator() => new Enumerator(Items, Capacity);
    

    public nint Vfptr;
    public nint Items;
    public int Capacity;
    public Bool IsInitialized;
    public Bool IsAllocated;
    public byte align1;
    public byte align2;

    public ref T this[int index]
    {
        get => ref Get(index);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ref T Get(int index) => ref Helper.GetUnmanagedRef<T>(Items, index);
}