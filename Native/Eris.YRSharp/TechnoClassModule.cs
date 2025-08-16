using Eris.YRSharp.GeneralDefinitions;

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

    public Pointer<FootClass> GetFirstPassenger()
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



[StructLayout(LayoutKind.Sequential)]
public struct RecoilData
{
    public enum RecoilState : uint 
    {
        Inactive = 0,
        Compressing = 1,
        Holding = 2,
        Recovering = 3,
    }
    
    public TurretControl Turret;
    public float TravelPerFrame;
    public float TravelSoFar;
    public RecoilState State;
    public int TravelFramesLeft;

    public unsafe void Update()
    {
        var func = (delegate*unmanaged[Thiscall]<nint, void>)0x70ED10;
        func(this.GetThisPointer());
    }

    public unsafe void Fire()
    {
        var func = (delegate*unmanaged[Thiscall]<nint, void>)0x70ECE0;
        func(this.GetThisPointer());
    }
}