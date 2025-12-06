namespace Eris.BeonSerializer.Streaming;

public interface IBeonStream
{
    IBeonStream Process<T>(ref T value) where T : unmanaged;
    IBeonStream ProcessObject<T>(ref T? value) where T : IBeonSerializable;
    IBeonStream ProcessInline<T>(ref T value) where T : struct, IBeonSerializable;
    IBeonStream ProcessStringInline(ref string? value);
    IBeonStream ProcessArrayUnmanaged<T>(ref T[]? value) where T : unmanaged;
    IBeonStream ProcessArrayInline<T>(ref T[]? value) where T : struct, IBeonSerializable;
    IBeonStream ProcessObjectArrayInline<T>(ref T?[]? value) where T : IBeonSerializable;
    void Reset();
}
