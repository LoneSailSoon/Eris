using Eris.YRSharp.Helpers;

namespace Eris.YRSharp;

public static class YRSharp
{
    
}

public interface IYRObject<T>
{
    Pointer<T> Type { get; }
}