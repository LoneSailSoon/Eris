using System.Runtime.CompilerServices;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct TeamClass
{
    public const nint array = 0x8B40E8;
    public static ref DynamicVectorClass<Pointer<TeamClass>> Array => ref array.Convert<DynamicVectorClass<Pointer<TeamClass>>>().Ref;


    public unsafe void LiberateMember(Pointer<FootClass> pFoot, int idx = -1, byte count = 0)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int, byte, void>)0x6EA870;
        func(this.GetThisPointer(), pFoot, idx, count);
    }

    public unsafe bool AddMember(Pointer<FootClass> pFoot, bool bForce)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, bool>)0x6EA500;
        return func(this.GetThisPointer(), pFoot, bForce);
    }

    public unsafe void AssignMissionTarget(Pointer<AbstractClass> pTarget)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x6E9050;
        func(this.GetThisPointer(), pTarget);
    }


    [FieldOffset(0)] public AbstractClass Base;
    [FieldOffset(36)] public nint type;
    public Pointer<TeamTypeClass> Type => type;
    [FieldOffset(40)] public nint currentScript;
    public Pointer<ScriptClass> CurrentScript => currentScript;
    [FieldOffset(44)] public nint owner;
    public Pointer<HouseClass> Owner => owner;
    [FieldOffset(48)] public nint target;
    public Pointer<HouseClass> Target => target;
    [FieldOffset(52)] public nint spawnCell;
    public Pointer<CellClass> SpawnCell => spawnCell;
    [FieldOffset(56)] public nint closestMember;
    public Pointer<FootClass> ClosestMember => closestMember;
    [FieldOffset(60)] public nint queuedFocus;
    public Pointer<AbstractClass> QueuedFocus => queuedFocus;
    [FieldOffset(64)] public nint focus;
    public Pointer<AbstractClass> Focus => focus;
    [FieldOffset(68)] public int unknown_44;
    [FieldOffset(72)] public int TotalObjects;
    [FieldOffset(76)] public int TotalThreatValue;
    [FieldOffset(80)] public int CreationFrame;
    [FieldOffset(84)] public nint firstUnit;
    public Pointer<FootClass> FirstUnit => firstUnit;
    [FieldOffset(88)] public TimerStruct GuardAreaTimer;
    [FieldOffset(100)] public TimerStruct SuspendTimer;
    [FieldOffset(112)] public nint tag;
    public Pointer<TagClass> Tag => tag;
    [FieldOffset(116)] public Bool IsTransient;
    [FieldOffset(117)] public Bool NeedsReGrouping;
    [FieldOffset(118)] public Bool GuardSlowerIsNotUnderStrength;
    [FieldOffset(119)] public Bool IsForcedActive;
    [FieldOffset(120)] public Bool IsHasBeen;
    [FieldOffset(121)] public Bool IsFullStrength;
    [FieldOffset(122)] public Bool IsUnderStrength;
    [FieldOffset(123)] public Bool IsReforming;
    [FieldOffset(124)] public Bool IsLagging;
    [FieldOffset(125)] public Bool NeedsToDisappear;
    [FieldOffset(126)] public Bool JustDisappeared;
    [FieldOffset(127)] public Bool IsMoving;
    [FieldOffset(128)] public Bool StepCompleted;
    [FieldOffset(129)] public Bool TargetNotAssigned;
    [FieldOffset(130)] public Bool IsLeavingMap;
    [FieldOffset(131)] public Bool IsSuspended;
    [FieldOffset(132)] public Bool AchievedGreatSuccess;
    [FieldOffset(136)] public byte countObjects;
    public FixedArray<int> CountObjects => new(ref Unsafe.As<byte, int>(ref countObjects), 6);
}