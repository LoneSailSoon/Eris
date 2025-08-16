namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct AlphaLightingRemapClass
{
    public const nint ArrayPointer = 0x88A080;

    public static ref DynamicVectorClass<Pointer<AlphaLightingRemapClass>> Array =>
        ref DynamicVectorClass<Pointer<AlphaLightingRemapClass>>.GetDynamicVector(ArrayPointer);
    
    [FieldOffset(0)] public ushort table;
    public FixedArray<ushort> Table => new(ref table, 65536);
    [FieldOffset(131072)] public int IntensityCount;
    [FieldOffset(131076)] public int RefCount;
}