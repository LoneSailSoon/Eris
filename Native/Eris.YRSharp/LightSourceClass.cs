namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct LightSourceClass
{
    public unsafe void Activate(uint dwZero = 0)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, void>)0x554A60;
        func(this.GetThisPointer(), dwZero);
    }
    public unsafe void Deactivate(uint dwZero = 0)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, void>)0x554A80;
        func(this.GetThisPointer(), dwZero);
    }
    public unsafe void ChangeLevels(int nIntensity, TintStruct Tint, byte mode)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, TintStruct, byte, void>)0x554AA0;
        func(this.GetThisPointer(), nIntensity, Tint, mode);
    }

    [FieldOffset(0)] public AbstractClass Base;
    
    [FieldOffset(36)] public int LightIntensity;
    [FieldOffset(40)] public TintStruct LightTint;
    [FieldOffset(52)] public int DetailLevel;
    [FieldOffset(56)] public CoordStruct Location;
    [FieldOffset(68)] public int LightVisibility;
    [FieldOffset(72)] public Bool Activated;
}