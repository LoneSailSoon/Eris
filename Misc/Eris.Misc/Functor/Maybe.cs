using System.Runtime.CompilerServices;

namespace Eris.Misc.Functor;

public readonly ref struct MaybeRef<T> where T : allows ref struct
{
    readonly bool _hasvalue;

    readonly T _value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private MaybeRef(bool hasvalue, T value) : this()
    {
        _hasvalue = hasvalue;
        _value = value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Just(out T value)
    {
        value = _value;
        return _hasvalue;
    }

    public bool Nothing => !_hasvalue;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MaybeRef<T> OfNullable(T? value) =>
        value is { } v ? new(true, v) : default;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MaybeRef<T>(T value) => new(true, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator MaybeRef<T>(Fail fail) => default;
}
