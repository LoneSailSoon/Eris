namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct ToggleClass
{
    public unsafe void TurnOn()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x723EA0;
        func(this.GetThisPointer());
    }
    public unsafe void TurnOff()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x723EB0;
        func(this.GetThisPointer());
    }
    
    [FieldOffset(0)] public ControlClass Base;
    [FieldOffset(44)] public Bool IsPressed;
    [FieldOffset(45)] public Bool IsOn;
    [FieldOffset(48)] public uint ToggleType;
}