using Eris.YRSharp.String.Uni;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct EditClass
{
    public unsafe void SetText(UniStringPointer lpStr, int nMaxLength)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int, void>)this.GetVirtualFunctionPointer(34);
        func(this.GetThisPointer(), lpStr, nMaxLength);
    }
    public unsafe UniStringPointer GetText()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)this.GetVirtualFunctionPointer(35);
        return func(this.GetThisPointer());
    }
    public unsafe void DrawBackground()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(36);
        func(this.GetThisPointer());
    }
    public unsafe void DrawText(UniStringPointer lpStr)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)this.GetVirtualFunctionPointer(37);
        func(this.GetThisPointer(), lpStr);
    }
    public unsafe bool HandleKeyInput(int nASCII)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, bool>)this.GetVirtualFunctionPointer(38);
        return func(this.GetThisPointer(), nASCII);
    }

    
    [FieldOffset(0)] public ControlClass Base;
    
    [FieldOffset(44)] public TextPrintType TextFlags;
    [FieldOffset(48)] public EditFlag EditFlags;
    [FieldOffset(52)] public nint text;
    public readonly UniStringPointer Text => text;
    [FieldOffset(56)] public int MaxLength;
    [FieldOffset(60)] public int Length;
    [FieldOffset(64)] public int Color;
    [FieldOffset(68)] public Bool IsReadOnly;

}

public enum EditFlag : int
{
    Alpha = 0x1,
    Digit = 0x2,
    Other = 0x4,
    ToUpper = 0x8
}
