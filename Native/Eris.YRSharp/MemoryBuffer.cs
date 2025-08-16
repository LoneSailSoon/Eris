namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct MemoryBuffer
{
    [FieldOffset(0)] public nint buffer;
    public Pointer<byte> Buffer => buffer;
    [FieldOffset(4)] public int Size;
    [FieldOffset(8)] public Bool Allocated;
}