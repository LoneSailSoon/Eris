namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct TerrainClass
{
    public const nint array = 0xA8E988;
    public static ref DynamicVectorClass<Pointer<TerrainClass>> Array => ref array.Convert<DynamicVectorClass<Pointer<TerrainClass>>>().Ref;


    [FieldOffset(0)] public ObjectClass Base; 
    [FieldOffset(172)] public ProgressTimer Animation;
    [FieldOffset(200)] public nint type;
    public Pointer<TerrainTypeClass> Type => type;
    [FieldOffset(204)] public Bool IsBurning;
    [FieldOffset(205)] public Bool IsCrumbling;
    [FieldOffset(208)] public RectangleStruct unknown_rect_D0;
}