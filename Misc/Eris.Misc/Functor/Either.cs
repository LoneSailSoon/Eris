using System.Runtime.CompilerServices;

namespace Eris.Misc.Functor;

public readonly ref struct Either<TL, TR> where TR : allows ref struct where TL : allows ref struct
{
    readonly bool _either;
    readonly TL _left;
    readonly TR _right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Either(bool either, TL left, TR right)
    {
        _either = either;
        _left = left;
        _right = right;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Left(out TL left)
    {
        left = _left;
        return !_either;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Right(out TR right)
    {
        right = _right;
        return _either;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Either<TL, TR>(TL value) => new(false, value, default!);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Either<TL, TR>(TR value) => new(false, default!, value);
}