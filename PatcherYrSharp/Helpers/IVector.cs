namespace PatcherYrSharp.Helpers;

public interface IVector<T>
    where T : struct, IVector<T>
{
    public static abstract T operator -(T a, T b);
    public static abstract T operator +(T a, T b);
    public static abstract T operator *(T a, double r);

    public static abstract T Zero { get; }
    public static abstract T One { get; }
}