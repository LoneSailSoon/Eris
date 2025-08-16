using Eris.YRSharp.GeneralDefinitions;
using System.Runtime.CompilerServices;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct AITriggerTypeClasss
{
    public const nint ArrayPointer = 0xA8B200;

    public static readonly GlobalDvcArray<TechnoTypeClass> AbstractTypeArray = new(ArrayPointer);

    public unsafe void RegisterSuccess()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x41FD60;
        func(this.GetThisPointer());
    }
    public unsafe void RegisterFailure()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x41FE20;
        func(this.GetThisPointer());
    }
    public unsafe bool ConditionMet(Pointer<HouseClass> CallingHouse, Pointer<HouseClass> TargetHouse, bool EnoughBaseDefense)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, bool, bool>)0x41E720;
        return func(this.GetThisPointer(), CallingHouse, TargetHouse, EnoughBaseDefense);
    }
    public unsafe bool OwnerHouseOwns(Pointer<HouseClass> CallingHouse, Pointer<HouseClass> TargetHouse)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, bool>)0x41EE90;
        return func(this.GetThisPointer(), CallingHouse, TargetHouse);
    }
    public unsafe bool CivilianHouseOwns(Pointer<HouseClass> CallingHouse, Pointer<HouseClass> TargetHouse)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, bool>)0x41EC90;
        return func(this.GetThisPointer(), CallingHouse, TargetHouse);
    }
    public unsafe bool EnemyHouseOwns(Pointer<HouseClass> CallingHouse, Pointer<HouseClass> TargetHouse)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, bool>)0x41EAF0;
        return func(this.GetThisPointer(), CallingHouse, TargetHouse);
    }
    public unsafe bool IronCurtainCharged(Pointer<HouseClass> CallingHouse, Pointer<HouseClass> TargetHouse)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, bool>)0x41F0D0;
        return func(this.GetThisPointer(), CallingHouse, TargetHouse);
    }
    public unsafe bool ChronoSphereCharged(Pointer<HouseClass> CallingHouse, Pointer<HouseClass> TargetHouse)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, bool>)0x41F180;
        return func(this.GetThisPointer(), CallingHouse, TargetHouse);
    }
    public unsafe bool HouseCredits(Pointer<HouseClass> CallingHouse, Pointer<HouseClass> TargetHouse)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, bool>)0x41F230;
        return func(this.GetThisPointer(), CallingHouse, TargetHouse);
    }

    [FieldOffset(0)] public AbstractClass BaseAbstract;
    [FieldOffset(0)] public AbstractTypeClass Base;

    [FieldOffset(152)] public AITriggerCondition ConditionType;
    [FieldOffset(156)] public int IsGlobal;
    [FieldOffset(160)] public AITriggerHouseType OwnerHouseType;
    [FieldOffset(164)] public Bool IsEnabled;
    [FieldOffset(168)] public int HouseIndex;
    [FieldOffset(172)] public int SideIndex;
    [FieldOffset(176)] public int TechLevel;
    [FieldOffset(180)] public int unknown_B4;
    [FieldOffset(184)] public double Weight_Current;
    [FieldOffset(192)] public double Weight_Minimum;
    [FieldOffset(200)] public double Weight_Maximum;
    [FieldOffset(208)] public Bool IsForSkirmish;
    [FieldOffset(209)] public Bool IsForBaseDefense;
    [FieldOffset(210)] public Bool Enabled_Easy;
    [FieldOffset(211)] public Bool Enabled_Normal;
    [FieldOffset(212)] public Bool Enabled_Hard;
    [FieldOffset(216)] public nint conditionObject;
    public readonly Pointer<TechnoTypeClass> ConditionObject => conditionObject;
    [FieldOffset(220)] public nint team1;
    public readonly Pointer<TeamTypeClass> Team1 => team1;
    [FieldOffset(224)] public nint team2;
    public readonly Pointer<TeamTypeClass> Team2 => team2;
    [FieldOffset(228)] public byte conditions;
    public FixedArray<AITriggerConditionComparator> Conditions => new(ref Unsafe.As<byte, AITriggerConditionComparator>(ref conditions), 4);
    [FieldOffset(260)] public int TimesExecuted;
    [FieldOffset(264)] public int TimesCompleted;
    [FieldOffset(268)] public int unknown_10C;
}

[StructLayout(LayoutKind.Sequential, Size = 8)]
public struct AITriggerConditionComparator
{
    public int ComparatorType;
    public int ComparatorOperand;
}
