namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct EMPulseClass
{
    public const nint ArrayPointer = 0x8A3870;

    public static ref DynamicVectorClass<Pointer<EMPulseClass>> Array =>
        ref DynamicVectorClass<Pointer<EMPulseClass>>.GetDynamicVector(ArrayPointer);
    
    [FieldOffset(0)] public AbstractClass Base;
    
    [FieldOffset(4)] public CellStruct BaseCoords;
    [FieldOffset(8)] public int Spread;
    [FieldOffset(12)] public int CreationTime;
    [FieldOffset(16)] public int Duration;
}