namespace Eris.Utilities.Helpers;

public readonly struct ValueLazy<T> where T : struct
{
    private readonly T _value;
    private readonly Func<T>? _func;

    public ValueLazy(T value)
    {
        this._value = value;
    }
    public ValueLazy(Func<T> func)
    {
        this._func = func;
    }
    
    public T Value => _func?.Invoke() ?? _value;
}