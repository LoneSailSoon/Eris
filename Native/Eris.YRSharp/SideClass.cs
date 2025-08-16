namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct SideClass
{
    private const nint ArrayPointer = 0x8B4120;

    public static readonly GlobalDvcArray<SideClass> AbstractTypeArray = new(ArrayPointer);
    
    [FieldOffset(0)] public AbstractTypeClass Bae;
    [FieldOffset(152)] public byte houseTypes;
    public ref TypeList<int> HouseTypes => ref Pointer<byte>.AsPointer(ref houseTypes).Convert<TypeList<int>>().Ref;
}