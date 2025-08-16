using System.Collections;
using Eris.Misc.String.HybridString;
using Eris.YRSharp.String.Ansi;

namespace Eris.YRSharp.Helpers;

public class GlobalDvcArray<T>(nint pVector) : IEnumerable<Pointer<T>>
{
    public Pointer<DynamicVectorClass<Pointer<T>>> Pointer = pVector;

    public ref DynamicVectorClass<Pointer<T>> Array => ref Pointer.Ref;

    public Pointer<T> Find(string id)
    {
        var idx = FindIndex(id);
        
        return idx >= 0 ? Array.Get(idx) : 0;
    }

    public int FindIndex(string id)
    {
        if (string.IsNullOrWhiteSpace(id)) return -1;
        if (id.Length > 23) return -1;
        using var ansi = new AnsiStringSpan(id);
        var span = ansi.AsSpan();
        
        var i = 0;
        
        foreach (var ptr in Array)
        {
            var pItem = ptr.Convert<AbstractTypeClass>();
            // if (AnsiComparer.Ordinal.Equals(pItem.Ref.ID, id))
            if(span.SequenceEqual(pItem.Ref.ID.AsSpan()))
            {
                return i;
            }

            i++;
        }
        return -1;
    }

    public Pointer<T> FindIgnoreCase(string id)
    {
        var idx = FindIndexIgnoreCase(id);
        if (idx >= 0)
        {
            return Array.Get(idx);
        }

        return 0;
    }
    
    public int FindIndexIgnoreCase(string id)
    {
        if (string.IsNullOrWhiteSpace(id)) return -1;
        if (id.Length > 23) return -1;
        
        using var ansi = new AnsiStringSpan(id);
        var span = ansi.AsSpan();
        
        var i = 0;
        
        foreach (var ptr in Array)
        {
            var pItem = ptr.Convert<AbstractTypeClass>();
            // if (AnsiComparer.Ordinal.Equals(pItem.Ref.ID, id))
            
            
            if(AnsiComparer.EqualIgnoreCaseSimd(span, pItem.Ref.ID.AsSpan()))
            {
                return i;
            }

            i++;
        }
        return -1;
    }
    
    public Pointer<T> Find(string id, StringComparer comparer)
    {
        var idx = FindIndex(id, comparer);
        if (idx >= 0)
        {
            return Array.Get(idx);
        }

        return 0;
    }

    public int FindIndex(string id, StringComparer comparer)
    {
        var i = 0;
        foreach (var ptr in Array)
        {
            var pItem = ptr.Convert<AbstractTypeClass>();

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

    public DynamicVectorClass<Pointer<T>>.Enumerator GetEnumerator() => Array.GetEnumerator();
    
    IEnumerator<Pointer<T>> IEnumerable<Pointer<T>>.GetEnumerator() => Array.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => Array.GetEnumerator();
    
    public readonly struct AlternateLookup<TAlternateKey>(GlobalDvcArray<T> abstractTypeArray, IAlternateEqualityComparer<TAlternateKey, AnsiStringPointer> comparer) where TAlternateKey : allows ref struct
    {
        public int FindIndex(TAlternateKey id)
        {
            var i = 0;
        
            foreach (var ptr in abstractTypeArray.Array)
            {
                var pItem = ptr.Convert<AbstractTypeClass>();
                if (comparer.Equals(id, pItem.Ref.ID))
                {
                    return i;
                }

                i++;
            }

            return -1;
        }

        public Pointer<T> Find(TAlternateKey id)
        {
            var idx = FindIndex(id);
            if (idx < 0) return 0;
            
            return abstractTypeArray.Array.Get(idx);
        }
        
        public Pointer<T> this[int index] => abstractTypeArray[index];

        public Pointer<T> this[TAlternateKey id] => Find(id);
    }
}