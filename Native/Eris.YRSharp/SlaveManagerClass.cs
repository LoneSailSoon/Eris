namespace Eris.YRSharp;


[StructLayout(LayoutKind.Explicit)]
public struct SlaveManagerClass
{
    public unsafe void SetOwner(Pointer<TechnoClass> NewOwner)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x6AF580;
        func(this.GetThisPointer(), NewOwner);
    }

    public unsafe void CreateSlave(Pointer<SlaveControl> Node)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x6AF650;
        func(this.GetThisPointer(), Node);
    }

    public unsafe void LostSlave(Pointer<InfantryClass> Slave)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x6B0A20;
        func(this.GetThisPointer(), Slave);
    }

    public unsafe void Deploy2()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x6B0D60;
        func(this.GetThisPointer());
    }

    public unsafe void Killed(Pointer<TechnoClass> Killer, Pointer<HouseClass> ForcedOwnerHouse = default)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, void>)0x6B0AE0;
        func(this.GetThisPointer(), Killer, ForcedOwnerHouse);
    }

    public unsafe bool ShouldWakeUpNow()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x6B1020;
        return func(this.GetThisPointer());
    }

    [FieldOffset(0)] public AbstractClass Base;
    [FieldOffset(36)] public nint owner;
    public Pointer<TechnoClass> Owner => owner;
    [FieldOffset(40)] public nint slaveType;
    public Pointer<InfantryTypeClass> SlaveType => slaveType;
    [FieldOffset(44)] public int SlaveCount;
    [FieldOffset(48)] public int RegenRate;
    [FieldOffset(52)] public int ReloadRate;
    [FieldOffset(56)] public byte slaveNodes;

    public ref DynamicVectorClass<Pointer<SlaveControl>> SlaveNodes => ref Pointer<byte>.AsPointer(ref slaveNodes)
        .Convert<DynamicVectorClass<Pointer<SlaveControl>>>().Ref;

    [FieldOffset(80)] public TimerStruct RespawnTimer;
    [FieldOffset(92)] public SlaveManagerStatus State;
    [FieldOffset(96)] public int LastScanFrame;
}

public enum SlaveManagerStatus : uint
{
    Ready = 0,
    Scanning = 1,
    Travelling = 2,
    Deploying = 3,
    Working = 4,
    ScanningAgain = 5,
    PackingUp = 6
}

public enum SlaveControlStatus : uint
{
    Unknown = 0,
    ScanningForTiberium = 1,
    MovingToTiberium = 2,
    Harvesting = 3,
    BringingItBack = 4,
    Respawning = 5,
    Dead = 6
}

[StructLayout(LayoutKind.Explicit)]
public struct SlaveControl
{
    [FieldOffset(0)]public Pointer<InfantryClass> Slave;
    [FieldOffset(4)]public SlaveControlStatus State;
    [FieldOffset(8)]public TimerStruct RespawnTimer;
}