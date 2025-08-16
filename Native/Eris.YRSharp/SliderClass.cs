namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct SliderClass
{
    public unsafe int Bump(bool bMinus)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, int>)this.GetVirtualFunctionPointer(44);
        return func(this.GetThisPointer(), bMinus);
    }
    public unsafe int Step(bool bMinus)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, int>)this.GetVirtualFunctionPointer(45);
        return func(this.GetThisPointer(), bMinus);
    }

    public unsafe void RecalculateThumb()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x6B1EE0;
        func(this.GetThisPointer());
    }


    [FieldOffset(0)] public GaugeClass Base;
    [FieldOffset(60)] public nint plusGadget;
    public Pointer<GadgetClass> PlusGadget => plusGadget;
    [FieldOffset(64)] public nint minusGadget;
    public Pointer<GadgetClass> MinusGadget => minusGadget;
    [FieldOffset(68)] public Bool BelongToList;
    [FieldOffset(72)] public int Thumb;
    [FieldOffset(76)] public int ThumbSize;
    [FieldOffset(80)] public int ThumbStart;
}