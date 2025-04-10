using System.Collections;
using PatcherYrSharp.GeneralStructures;

namespace PatcherYrSharp.Helpers;

public class GlobalDvcArray<T>(IntPtr pVector) : IEnumerable<Pointer<T>>
{
    public Pointer<DynamicVectorClass<Pointer<T>>> Pointer = pVector;

    public ref DynamicVectorClass<Pointer<T>> Array => ref Pointer.Ref;

    public Pointer<T> Find(string id)
    {
        int idx = FindIndex(id);
        if (idx >= 0)
        {
            return Array.Get(idx);
        }

        return Pointer<T>.Zero;
    }

    public int FindIndex(string id)
    {
        int i = 0;
        foreach (var ptr in Array)
        {
            Pointer<AbstractTypeClass> pItem = ptr.Convert<AbstractTypeClass>();
            if (pItem.Ref.ID == id)
            {
                return i;
            }

            i++;
        }

        return -1;
    }

    public Pointer<T> Find(string id, StringComparer comparer)
    {
        int idx = FindIndex(id, comparer);
        if (idx >= 0)
        {
            return Array.Get(idx);
        }

        return Pointer<T>.Zero;
    }

    public int FindIndex(string id, StringComparer comparer)
    {
        int i = 0;
        foreach (var ptr in Array)
        {
            Pointer<AbstractTypeClass> pItem = ptr.Convert<AbstractTypeClass>();

            if (comparer.Equals(pItem.Ref.ID, id))
            {
                return i;
            }

            i++;
        }

        return -1;
    }


    public Pointer<T> this[int index] => Array[index];

    public Pointer<T> this[string id] => Find(id);

    public IEnumerator<Pointer<T>> GetEnumerator() => Array.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}