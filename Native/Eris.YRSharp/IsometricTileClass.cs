namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct IsometricTileClass
{
    [FieldOffset(0)] public ObjectClass Base;
    [FieldOffset(172)] public nint type;
    public Pointer<IsometricTileTypeClass> Type => type;
}