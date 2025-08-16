namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct SmudgeTypeClass
{
    private const nint ArrayPointer = 0xA8EC18;

    public static readonly GlobalDvcArray<SmudgeTypeClass> AbstractTypeArray = new(ArrayPointer);
    
    [FieldOffset(0)] public ObjectTypeClass Base;
    [FieldOffset(660)] public int ArrayIndex;
    [FieldOffset(664)] public int Width;
    [FieldOffset(668)] public int Height;
    [FieldOffset(672)] public Bool Crater;
    [FieldOffset(673)] public Bool Burn;
}