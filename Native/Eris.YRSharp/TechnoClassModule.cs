using System.Runtime.InteropServices;
using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.GeneralStructures;
using Eris.YRSharp.Helpers;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Sequential)]
public struct VeterancyStruct
{
    VeterancyStruct(double value) : this()
    {
        this.Add(value);
    }

    public void Add(int ownerCost, int victimCost)
    {
        this.Add(victimCost / (ownerCost * RulesClass.Instance.VeteranRatio));
    }

    public void Add(double value)
    {
        var val = this.Veterancy + value;

        if (val > RulesClass.Instance.VeteranCap)
        {
            val = RulesClass.Instance.VeteranCap;
        }

        this.Veterancy = (float)val;
    }

    public Rank GetRemainingLevel()
    {
        if (this.Veterancy >= 2.0f)
        {
            return Rank.Elite;
        }

        if (this.Veterancy >= 1.0f)
        {
            return Rank.Veteran;
        }

        return Rank.Rookie;
    }

    bool IsNegative()
    {
        return this.Veterancy < 0.0f;
    }

    bool IsRookie()
    {
        return this.Veterancy >= 0.0f && this.Veterancy < 1.0f;
    }

    bool IsVeteran()
    {
        return this.Veterancy >= 1.0f && this.Veterancy < 2.0f;
    }

    bool IsElite()
    {
        return this.Veterancy >= 2.0f;
    }

    void Reset()
    {
        this.Veterancy = 0.0f;
    }

    void SetRookie(bool notReally = true)
    {
        this.Veterancy = notReally ? -0.25f : 0.0f;
    }

    void SetVeteran(bool yesReally = true)
    {
        this.Veterancy = yesReally ? 1.0f : 0.0f;
    }

    void SetElite(bool yesReally = true)
    {
        this.Veterancy = yesReally ? 2.0f : 0.0f;
    }

    public float Veterancy;
}

[StructLayout(LayoutKind.Sequential)]
public struct PassengersClass
{
    public int NumPassengers;
    public IntPtr firstPassenger;

    public Pointer<FootClass> FirstPassenger
    {
        get => firstPassenger;
        set => firstPassenger = value;
    }

    public IEnumerable<Pointer<FootClass>> Passengers()
    {
        for (Pointer<FootClass> current = FirstPassenger;
             current.IsNotNull;
             current = current.Ref.BaseObject.NextObject.CastToFoot(out Pointer<FootClass> pFoot) ? pFoot : IntPtr.Zero)
        {
            yield return current;
        }
    }

    public unsafe void AddPassenger(Pointer<FootClass> pPassenger)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x4733A0;
        func(this.GetThisPointer(), pPassenger);
    }

    public unsafe Pointer<FootClass> GetFirstPassenger()
    {
        return FirstPassenger;
    }

    public unsafe Pointer<FootClass> RemoveFirstPassenger()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)0x473430;
        return func(this.GetThisPointer());
    }

    public unsafe int GetTotalSize()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)0x473460;
        return func(this.GetThisPointer());
    }

    public unsafe int IndexOf(Pointer<FootClass> candidate)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int>)0x473500;
        return func(this.GetThisPointer(), candidate);
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct FlashData
{
    public int DurationRemaining;
    public Bool FlashingNow;

    public unsafe bool Update()
    {
        var func = (delegate* unmanaged[Thiscall]<ref FlashData, Bool>)0x4CC770;
        return func(ref this);
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct OwnedTiberiumStruct
{
    public unsafe float GetAmount(int index)
    {
        var func = (delegate* unmanaged[Thiscall]<ref OwnedTiberiumStruct, int, float>)0x6C9680;
        return func(ref this, index);
    }

    public unsafe float GetTotalAmount()
    {
        var func = (delegate* unmanaged[Thiscall]<ref OwnedTiberiumStruct, float>)0x6C9650;
        return func(ref this);
    }

    public unsafe float AddAmount(float amount, int index)
    {
        var func = (delegate* unmanaged[Thiscall]<ref OwnedTiberiumStruct, float, int, float>)0x6C9690;
        return func(ref this, amount, index);
    }

    public unsafe float RemoveAmount(float amount, int index)
    {
        var func = (delegate* unmanaged[Thiscall]<ref OwnedTiberiumStruct, float, int, float>)0x6C96B0;
        return func(ref this, amount, index);
    }

    public unsafe int GetTotalValue()
    {
        var func = (delegate* unmanaged[Thiscall]<ref OwnedTiberiumStruct, int>)0x6C9600;
        return func(ref this);
    }

    public float Tiberium1;
    public float Tiberium2;
    public float Tiberium3;
    public float Tiberium4;
}

[StructLayout(LayoutKind.Explicit, Size = 116)]
public struct SpawnManagerClass
{
    public unsafe void Recalc()
    {
        var func = (delegate* unmanaged[Thiscall]<ref SpawnManagerClass, IntPtr, void>)0x6B7100;
        func(ref this, target);
    }

    public unsafe void SetTarget(Pointer<AbstractClass> target)
    {
        var func = (delegate* unmanaged[Thiscall]<ref SpawnManagerClass, IntPtr, void>)0x6B7B90;
        func(ref this, target);
    }

    public unsafe int DrawState()
    {
        var func = (delegate* unmanaged[Thiscall]<ref SpawnManagerClass, int>)0x6B7D50;
        return func(ref this);
    }


    [FieldOffset(36)] public IntPtr owner;

    public Pointer<TechnoClass> Owner
    {
        get => owner;
        set => owner = value;
    }

    [FieldOffset(40)] public IntPtr spawnType;

    public Pointer<AircraftTypeClass> SpawnType
    {
        get => spawnType;
        set => spawnType = value;
    }

    [FieldOffset(44)] public int SpawnCount;
    [FieldOffset(48)] public int RegenRate;
    [FieldOffset(52)] public int ReloadRate;
    [FieldOffset(56)] public byte spawnedNodes;

    public ref DynamicVectorClass<Pointer<SpawnNode>> SpawnedNodes => ref Pointer<byte>.AsPointer(ref spawnedNodes)
        .Convert<DynamicVectorClass<Pointer<SpawnNode>>>().Ref;

    [FieldOffset(80)] public TimerStruct UpdateTimer;
    [FieldOffset(92)] public TimerStruct SpawnTimer;
    [FieldOffset(104)] public IntPtr destination;

    public Pointer<AbstractClass> Destination
    {
        get => destination;
        set => destination = value;
    }

    [FieldOffset(108)] public IntPtr target;

    public Pointer<AbstractClass> Target
    {
        get => target;
        set => target = value;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 24)]
public struct SpawnNode
{
    [FieldOffset(0)] public Pointer<TechnoClass> Unit;
    [FieldOffset(4)] public int Status;
    [FieldOffset(8)] public TimerStruct SpawnTimer;
    [FieldOffset(20)] public Bool IsSpawnMissile;
}