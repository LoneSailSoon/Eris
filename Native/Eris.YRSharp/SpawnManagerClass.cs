namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 116)]
public struct SpawnManagerClass
{
    public unsafe void KillNodes()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x6B7100;
        func(this.GetThisPointer());
    }

    public unsafe void SetTarget(Pointer<AbstractClass> pTarget)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x6B7B90;
        func(this.GetThisPointer(), pTarget);
    }

    public unsafe bool UpdateTarget()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x6B7C40;
        return func(this.GetThisPointer());
    }

    public unsafe void ResetTarget()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x6B7BB0;
        func(this.GetThisPointer());
    }

    public unsafe int CountAliveSpawns()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)0x6B7D30;
        return func(this.GetThisPointer());
    }

    public unsafe int CountDockedSpawns()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)0x6B7D50;
        return func(this.GetThisPointer());
    }

    public unsafe int CountLaunchingSpawns()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)0x6B7D80;
        return func(this.GetThisPointer());
    }

    public unsafe void UnlinkPointer()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x6B7C60;
        func(this.GetThisPointer());
    }




    [FieldOffset(36)] public nint owner;
    public Pointer<TechnoClass> Owner => owner;
    [FieldOffset(40)] public nint spawnType;
    public Pointer<AircraftTypeClass> SpawnType => spawnType;
    [FieldOffset(44)] public int SpawnCount;
    [FieldOffset(48)] public int RegenRate;
    [FieldOffset(52)] public int ReloadRate;
    [FieldOffset(56)] public byte spawnedNodes;

    public ref DynamicVectorClass<Pointer<SpawnControl>> SpawnedNodes => ref Pointer<byte>.AsPointer(ref spawnedNodes)
        .Convert<DynamicVectorClass<Pointer<SpawnControl>>>().Ref;

    [FieldOffset(80)] public TimerStruct UpdateTimer;
    [FieldOffset(92)] public TimerStruct SpawnTimer;
    [FieldOffset(104)] public nint target;
    public Pointer<AbstractClass> Target => target;
    [FieldOffset(108)] public nint newTarget;
    public Pointer<AbstractClass> NewTarget => newTarget;
    [FieldOffset(112)] public SpawnManagerStatus Status;

}

[StructLayout(LayoutKind.Explicit, Size = 24)]
public struct SpawnControl
{
    [FieldOffset(0)] public Pointer<TechnoClass> Unit;
    [FieldOffset(4)] public int Status;
    [FieldOffset(8)] public TimerStruct SpawnTimer;
    [FieldOffset(20)] public Bool IsSpawnMissile;
}

public enum SpawnManagerStatus : uint
{
    Idle = 0, // no target or out of range
    Launching = 1, // one launch in progress
    CoolDown = 2 // waiting for launch to complete
}

public enum SpawnNodeStatus : uint
{
    Idle = 0, // docked, waiting for target
    TakeOff = 1, // missile tilting and launch
    Preparing = 2, // gathering, waiting
    Attacking = 3, // attacking until no ammo
    Returning = 4, // return to carrier

    //Unused_5, // not used
    Reloading = 6, // docked, reloading ammo and health
    Dead = 7 // respawning
}