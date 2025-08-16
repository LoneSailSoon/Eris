namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct TemporalClass
{
    public const nint array = 0xB0EC60;
    public static ref DynamicVectorClass<Pointer<TemporalClass>> Array => ref array.Convert<DynamicVectorClass<Pointer<TemporalClass>>>().Ref;


    public unsafe void Fire(Pointer<TechnoClass> pTarget)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x71AF20;
        func(this.GetThisPointer(), pTarget);
    }

    public unsafe bool CanWarpTarget(Pointer<TechnoClass> pTarget)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x71AE50;
        return func(this.GetThisPointer(), pTarget);
    }

    public unsafe int GetWarpPerStep(int nHelperCount = 0)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, int>)0x71AB10;
        return func(this.GetThisPointer(), nHelperCount);
    }

    public unsafe void LetGo()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x71ABC0;
        func(this.GetThisPointer());
    }

    public unsafe void JustLetGo()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x71AD40;
        func(this.GetThisPointer());
    }

    public unsafe void Detach()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x71ADE0;
        func(this.GetThisPointer());
    }

    [FieldOffset(0)] public AbstractClass Base;
    [FieldOffset(36)] public nint owner;
    public Pointer<TechnoClass> Owner => owner;
    [FieldOffset(40)] public nint target;
    public Pointer<TechnoClass> Target => target;
    [FieldOffset(44)] public TimerStruct LifeTimer;
    [FieldOffset(56)] public nint unknown_pointer_38;
    public Pointer<byte> Unknown_pointer_38 => unknown_pointer_38;
    [FieldOffset(60)] public nint sourceSW;
    public Pointer<SuperClass> SourceSW => sourceSW;
    [FieldOffset(64)] public nint nextTemporal;
    public Pointer<TemporalClass> NextTemporal => nextTemporal;
    [FieldOffset(68)] public nint prevTemporal;
    public Pointer<TemporalClass> PrevTemporal => prevTemporal;
    [FieldOffset(72)] public int WarpRemaining;
    [FieldOffset(76)] public int WarpPerStep;

}