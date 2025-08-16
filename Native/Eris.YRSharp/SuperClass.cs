using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.String.Uni;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 128)]
public struct SuperClass : IYRObject<SuperClass, SuperWeaponTypeClass>
{
    static Pointer<SuperWeaponTypeClass> IYRObject<SuperClass, SuperWeaponTypeClass>.Type(Pointer<SuperClass> pThis) => pThis.Ref.Type;

    public static readonly IntPtr ArrayPointer = new IntPtr(0xA83CB8);

    public static ref DynamicVectorClass<Pointer<SuperClass>> Array =>
        ref DynamicVectorClass<Pointer<SuperClass>>.GetDynamicVector(ArrayPointer);

    public static readonly IntPtr ShowTimersPointer = new IntPtr(0xA83D50);

    public static ref DynamicVectorClass<Pointer<SuperClass>> ShowTimers =>
        ref DynamicVectorClass<Pointer<SuperClass>>.GetDynamicVector(ArrayPointer);


    public unsafe void CreateChronoAnim(CoordStruct coords)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, CoordStruct, void>)0x6CB3A0;
        func(this.GetThisPointer(), coords);
    }

    public unsafe void Reset()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x6CE0B0;
        func(this.GetThisPointer());
    }

    public unsafe bool SetOnHold(bool onHold)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, bool>)0x6CB4D0;
        return func(this.GetThisPointer(), onHold);
    }

    public unsafe bool Grant(bool oneTime, bool announce, bool onHold)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, bool, bool, bool>)0x6CB560;
        return func(this.GetThisPointer(), oneTime, announce, onHold);
    }

    public unsafe bool Lose()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x6CB7B0;
        return func(this.GetThisPointer());
    }

    public unsafe void Launch(CellStruct cell, bool isPlayer)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, void>)0x6CC390;
        func(this.GetThisPointer(), cell.GetThisPointer(), isPlayer);
    }

    public unsafe void Launch(Pointer<CellStruct> cell, bool isPlayer)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, void>)0x6CC390;
        func(this.GetThisPointer(), cell, isPlayer);
    }

    public unsafe char CanFire()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, char>)0x6CC360;
        return func(this.GetThisPointer());
    }

    public unsafe void SetReadiness(bool ready)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, void>)0x6CB820;
        func(this.GetThisPointer(), ready);
    }

    public unsafe char StopPreclickAnim(bool isPlayer)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, char>)0x6CB830;
        return func(this.GetThisPointer(), isPlayer);
    }

    public unsafe char ClickFire(bool isPlayer, Pointer<CellStruct> cell)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, nint, char>)0x6CB920;
        return func(this.GetThisPointer(), isPlayer, cell);
    }

    public unsafe bool HasChargeProgressed(bool isPlayer)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, bool>)0x6CBCA0;
        return func(this.GetThisPointer(), isPlayer);
    }

    public unsafe int AnimStage()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)0x6CBEE0;
        return func(this.GetThisPointer());
    }

    public unsafe void SetCharge(int percentage)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x6CC1E0;
        func(this.GetThisPointer(), percentage);
    }

    public unsafe int GetRechargeTime()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)0x6CC260;
        return func(this.GetThisPointer());
    }

    public unsafe void SetRechargeTime(int time)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x6CC280;
        func(this.GetThisPointer(), time);
    }

    public unsafe void ResetRechargeTime()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x6CC290;
        func(this.GetThisPointer());
    }

    public unsafe UniString NameReadiness()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)0x6CC2B0;
        return func(this.GetThisPointer());
    }

    public unsafe bool ShouldDrawProgress()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x6CDE90;
        return func(this.GetThisPointer());
    }

    public unsafe bool ShouldFlashTab()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x6CE1A0;
        return func(this.GetThisPointer());
    }



    [FieldOffset(0)] public AbstractClass Base;

    [FieldOffset(36)] public int CustomChargeTime;
    [FieldOffset(40)] public nint type;
    public Pointer<SuperWeaponTypeClass> Type => type;
    [FieldOffset(44)] public nint owner;
    public Pointer<HouseClass> Owner => owner;
    [FieldOffset(48)] public TimerStruct RechargeTimer;
    [FieldOffset(64)] public Bool BlinkState;
    [FieldOffset(72)] public ulong BlinkTimer;
    [FieldOffset(80)] public int SpecialSoundDuration;
    [FieldOffset(84)] public CoordStruct SpecialSoundLocation;
    [FieldOffset(96)] public Bool CanHold;
    [FieldOffset(98)] public CellStruct ChronoMapCoords;
    [FieldOffset(104)] public nint animation;
    public Pointer<AnimClass> Animation => animation;
    [FieldOffset(108)] public Bool AnimationGotInvalid;
    [FieldOffset(109)] public Bool IsPresent;
    [FieldOffset(110)] public Bool IsOneTime;
    [FieldOffset(111)] public Bool IsReady;
    [FieldOffset(112)] public Bool IsSuspended;
    [FieldOffset(116)] public int ReadyFrame;
    [FieldOffset(120)] public int CameoChargeState;
    [FieldOffset(124)] public ChargeDrainState ChargeDrainState;

}