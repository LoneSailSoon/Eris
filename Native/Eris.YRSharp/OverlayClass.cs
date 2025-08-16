namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct OverlayClass
{
    public const nint array = 0xA8EC50;
    public static ref DynamicVectorClass<Pointer<OverlayClass>> Array => ref array.Convert<DynamicVectorClass<Pointer<OverlayClass>>>().Ref;

    [FieldOffset(0)] public ObjectClass Base;
    [FieldOffset(172)] public nint type;
    public Pointer<OverlayTypeClass> Type => type;
}