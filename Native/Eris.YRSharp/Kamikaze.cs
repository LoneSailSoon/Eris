namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 36)]
public struct Kamikaze
{
    public unsafe void Add(Pointer<AircraftClass> pAircraft)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x54E3B0;
        func(this.GetThisPointer(), pAircraft);
    }

    public unsafe void Remove(Pointer<AircraftClass> pAircraft)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x54E590;
        func(this.GetThisPointer(), pAircraft);
    }

    public unsafe void Update()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x54E4D0;
        func(this.GetThisPointer());
    }

    public unsafe void Clear()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x54E6F0;
        func(this.GetThisPointer());
    }

    [FieldOffset(0)] public TimerStruct UpdateTimer;
    [FieldOffset(12)] public byte nodes;

    public ref DynamicVectorClass<Pointer<KamikazeControl>> Nodes => ref Pointer<byte>.AsPointer(ref nodes)
        .Convert<DynamicVectorClass<Pointer<KamikazeControl>>>().Ref;
}

[StructLayout(LayoutKind.Explicit, Size = 8)]
public struct KamikazeControl
{
    [FieldOffset(0)] public nint item;
    public Pointer<AircraftClass> Item => item;
    [FieldOffset(4)] public nint cell;
    public Pointer<CellClass> Cell => cell;
}
