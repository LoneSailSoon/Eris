using System.Buffers;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.Misc.Functor;
using ZLinq;

namespace Eris.Misc.Linq;

partial class ErisEnumerable
{
    extension<TEnumerator, T>(ValueEnumerable<TEnumerator, T> source) where TEnumerator : struct, IValueEnumerator<T>, allows ref struct
    {
        public ValueEnumerable<UniqueChoose<TEnumerator, T, TKey>, TKey> UniqueChoose<TKey>(Func<T, MaybeRef<TKey>> selector)
            => new(new(source.Enumerator, selector, null));
        
        public ValueEnumerable<UniqueChoose<TEnumerator, T, TKey>, TKey> UniqueChoose<TKey>(Func<T, MaybeRef<TKey>> selector, IEqualityComparer<TKey> comparer)
            => new(new(source.Enumerator, selector, comparer));
    }
}

[StructLayout(LayoutKind.Auto)]
[EditorBrowsable(EditorBrowsableState.Never)]
public ref struct UniqueChoose<TEnumerator, T, TKey>(TEnumerator source, Func<T, MaybeRef<TKey>> selector, IEqualityComparer<TKey>? comparer) : IValueEnumerator<TKey> where TEnumerator : struct, IValueEnumerator<T>, allows ref struct
{
    private TEnumerator _source = source;
    private readonly Func<T, MaybeRef<TKey>> _selector = selector;
    private readonly IEqualityComparer<TKey>? _comparer = comparer;
    private HashSetSlim<TKey> _set;
    public void Dispose()
    {
        _source.Dispose();
        if(!_set.IsNull)
            _set.Dispose();
    }

    public readonly bool TryCopyTo(scoped Span<TKey> destination, Index offset) => false;

    public bool TryGetNext(out TKey current)
    {
        if(_set.IsNull)
            _set = new(_comparer ?? EqualityComparer<TKey>.Default);

        while(_source.TryGetNext(out var value))
            if(_selector(value).Just(out var key) && _set.Add(key))
            {
                current = key;
                return true;
            }
        
        Unsafe.SkipInit(out current);
        return false;
    }

    public readonly bool TryGetNonEnumeratedCount(out int count)
    {
        count = 0;
        return false;
    }

    public readonly bool TryGetSpan(out ReadOnlySpan<TKey> span)
    {
        Unsafe.SkipInit(out span);
        return false;
    }
}

internal ref struct HashSetSlim<T> : IDisposable
{
    const int MinimumSize = 16; // minimum arraypool size(power of 2)
    const double LoadFactor = 0.72;

    readonly IEqualityComparer<T> comparer;

    Entry[] entries;
    int[] buckets; // bucket is index of entries, 1-based(0 for empty).
    int bucketsLength; // power of 2
    int entryIndex;
    int resizeThreshold;

    public HashSetSlim(IEqualityComparer<T>? comparer)
        : this(MinimumSize, comparer)
    {
    }

    public HashSetSlim(int capacity, IEqualityComparer<T>? comparer)
    {
        capacity = Math.Max((int)System.Numerics.BitOperations.RoundUpToPowerOf2((uint)capacity), MinimumSize);

        this.comparer = comparer ?? EqualityComparer<T>.Default;
        this.buckets = ArrayPool<int>.Shared.Rent(capacity);
        this.entries = ArrayPool<Entry>.Shared.Rent(capacity);
        this.bucketsLength = capacity;
        this.resizeThreshold = (int)(bucketsLength * LoadFactor);
        buckets.AsSpan().Clear(); // 0-clear.
    }

    public readonly bool IsNull => entries is null;

    public bool Add(T item)
    {
        var hashCode = InternalGetHashCode(item);
        ref var bucket = ref buckets[GetBucketIndex(hashCode)];
        var index = bucket - 1;

        // lookup phase
        while (index != -1)
        {
            ref var entry = ref entries[index];
            if (entry.HashCode == hashCode && comparer.Equals(entry.Value, item))
            {
                return false;
            }
            index = entry.Next;
        }

        // add phase
        if (entryIndex > resizeThreshold)
        {
            Resize();
            // Need to recalculate bucket after resize
            bucket = ref buckets[GetBucketIndex(hashCode)];
        }

        ref var newEntry = ref entries[entryIndex];
        newEntry.HashCode = hashCode;
        newEntry.Value = item;
        newEntry.Next = bucket - 1;

        bucket = entryIndex + 1;
        entryIndex++;

        return true;
    }

    void Resize()
    {
        var newSize = System.Numerics.BitOperations.RoundUpToPowerOf2((uint)entries.Length * 2);
        var newEntries = ArrayPool<Entry>.Shared.Rent((int)newSize);
        var newBuckets = ArrayPool<int>.Shared.Rent((int)newSize);
        bucketsLength = (int)newSize; // guarantees PowerOf2
        resizeThreshold = (int)(bucketsLength * LoadFactor);
        newBuckets.AsSpan().Clear(); // 0-clear.

        // Copy entries
        Array.Copy(entries, newEntries, entryIndex);

        for (int i = 0; i < entryIndex; i++)
        {
            ref var entry = ref newEntries[i];
            var bucketIndex = GetBucketIndex(entry.HashCode);

            ref var bucket = ref newBuckets[bucketIndex];
            entry.Next = bucket - 1;
            bucket = i + 1;
        }

        // return old arrays
        ArrayPool<int>.Shared.Return(buckets, clearArray: false);
        ArrayPool<Entry>.Shared.Return(entries, clearArray: RuntimeHelpers.IsReferenceOrContainsReferences<Entry>());

        // assign new arrays
        entries = newEntries;
        buckets = newBuckets;
    }

    // special use case for Intercept, only call after completely constructed(don't call Add after Remove called).
    public bool Remove(T item)
    {
        var hashCode = InternalGetHashCode(item);
        ref var bucket = ref buckets[GetBucketIndex(hashCode)];
        var index = bucket - 1;
        var lastIndex = -1;

        // lookup phase
        while (index != -1)
        {
            ref var entry = ref entries[index];
            if (entry.HashCode == hashCode && comparer.Equals(entry.Value, item))
            {
                if (lastIndex == -1)
                {
                    // This is the first entry in the bucket
                    bucket = entry.Next + 1;
                }
                else
                {
                    // Link the previous entry to the next one, skipping this entry
                    entries[lastIndex].Next = entry.Next;
                }

                // Clear the removed entry's value
                if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
                {
                    entry.Value = default!;
                }

                return true;
            }

            lastIndex = index;
            index = entry.Next;
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    uint InternalGetHashCode(T key)
    {
        // allows null.
        return (uint)((key is null) ? 0 : comparer.GetHashCode(key) & 0x7FFFFFFF);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    int GetBucketIndex(uint hashCode)
    {
        return (int)(hashCode & (bucketsLength - 1));
    }

    // return to pool
    public void Dispose()
    {
        if (buckets != null)
        {
            ArrayPool<int>.Shared.Return(buckets, clearArray: false);
            buckets = null!;
        }
        if (entries != null)
        {
            ArrayPool<Entry>.Shared.Return(entries, clearArray: RuntimeHelpers.IsReferenceOrContainsReferences<Entry>());
            entries = null!;
        }
    }

    [StructLayout(LayoutKind.Auto)]
    [DebuggerDisplay("HashCode = {HashCode}, Value = {Value}, Next = {Next}")]
    struct Entry
    {
        public uint HashCode;
        public T Value;
        public int Next; // next is index of entries, -1 is end of chain
    }
}


