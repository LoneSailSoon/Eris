using PatcherYrSharp.Helpers;

namespace PatcherYrSharp;

public static class YrSharp
{
    
}

public interface IYrObject<T>
{
    Pointer<T> Type { get; }
}