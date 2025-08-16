namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct GaugeClass
{
    public unsafe bool SetMaximum(int value)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, bool>)this.GetVirtualFunctionPointer(9);
        return func(this.GetThisPointer(), value);
    }
    public unsafe bool SetValue(int value)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, bool>)this.GetVirtualFunctionPointer(10);
        return func(this.GetThisPointer(), value);
    }
    public unsafe int GetValue()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(11);
        return func(this.GetThisPointer());
    }
    public unsafe void SetThumb(bool value)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, void>)this.GetVirtualFunctionPointer(12);
        func(this.GetThisPointer(), value);
    }
    public unsafe int GetThumbPixel()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(13);
        return func(this.GetThisPointer());
    }
    public unsafe void DrawThumb()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(14);
        func(this.GetThisPointer());
    }
    public unsafe int PixelToValue(int pixel)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, int>)this.GetVirtualFunctionPointer(15);
        return func(this.GetThisPointer(), pixel);
    }
    public unsafe int ValueToPixel(int value)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, int>)this.GetVirtualFunctionPointer(16);
        return func(this.GetThisPointer(), value);
    }

    [FieldOffset(0)] public ControlClass Base;
    
    [FieldOffset(44)] public Bool IsColorized;
    [FieldOffset(45)] public Bool HasThumb;
    [FieldOffset(46)] public Bool IsHorizontal;
    [FieldOffset(48)] public int MaxValue;
    [FieldOffset(52)] public int CurrentValue;
    [FieldOffset(56)] public int ClickDiff;

}