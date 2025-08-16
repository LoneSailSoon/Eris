namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct RadSiteClass
{
    public const nint array = 0xB04BD0;

    public static ref DynamicVectorClass<Pointer<RadSiteClass>> Array =>
        ref array.Convert<DynamicVectorClass<Pointer<RadSiteClass>>>().Ref;

    public unsafe void Activate()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x65B580;
        func(this.GetThisPointer());
    }

    public unsafe void Deactivate()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x65BB50;
        func(this.GetThisPointer());
    }

    public unsafe void Radiate()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x65B9C0;
        func(this.GetThisPointer());
    }

    public unsafe void DecreaseRadiation()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x65BD00;
        func(this.GetThisPointer());
    }

    public unsafe void DecreaseLight()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x65BE90;
        func(this.GetThisPointer());
    }

    public unsafe void Add(int nRadLevel)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x65B530;
        func(this.GetThisPointer(), nRadLevel);
    }

    public unsafe int GetRadLevel()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)0x65B510;
        return func(this.GetThisPointer());
    }

    public unsafe int GetRadLevelAt(Pointer<CellStruct> pCell)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int>)0x65B8F0;
        return func(this.GetThisPointer(), pCell);
    }

    public unsafe void SetRadLevel(int nRadLevel)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x65B4F0;
        func(this.GetThisPointer(), nRadLevel);
    }

    public unsafe void SetBaseCell(Pointer<CellStruct> pCell)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x65B4C0;
        func(this.GetThisPointer(), pCell);
    }

    public unsafe void GetSpread()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x65B4B0;
        func(this.GetThisPointer());
    }

    public unsafe void SetSpread(int nCells)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x65B4D0;
        func(this.GetThisPointer(), nCells);
    }

    [FieldOffset(0)] public AbstractClass Base;
    [FieldOffset(36)] public nint lightSource;
    public Pointer<LightSourceClass> LightSource => lightSource;
    [FieldOffset(40)] public TimerStruct RadLevelTimer;
    [FieldOffset(52)] public TimerStruct RadLightTimer;
    [FieldOffset(64)] public CellStruct BaseCell;
    [FieldOffset(68)] public int Spread;
    [FieldOffset(72)] public int SpreadInLeptons;
    [FieldOffset(76)] public int RadLevel;
    [FieldOffset(80)] public int LevelSteps;
    [FieldOffset(84)] public int Intensity;
    [FieldOffset(88)] public TintStruct Tint;
    [FieldOffset(100)] public int IntensitySteps;
    [FieldOffset(104)] public int IntensityDecrement;
    [FieldOffset(108)] public int RadDuration;
    [FieldOffset(112)] public int RadTimeLeft;
}