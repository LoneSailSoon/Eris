﻿using System.Runtime.InteropServices;
using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.GeneralStructures;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.String.Ansi;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 32)]
public struct MissionControlClass
{
    public static Pointer<MissionControlClass> Array() => new Pointer<MissionControlClass>(0xA8E3A8);

    public static Pointer<AnsiStringPointer> Names()
    {
        return new Pointer<AnsiStringPointer>(0x816CAC);
    }

    //public static unsafe Mission Find(AnsiString name)
    //{
    //    var func = (delegate* unmanaged[Fastcall]<IntPtr, Mission>)0x5B3910;
    //    return func(name);
    //}

    public static unsafe void Constructor(Pointer<MissionControlClass> pThis)
    {
        var func = (delegate* unmanaged[Thiscall]<ref MissionControlClass, void>)0x5B3700;
        func(ref pThis.Ref);
    }

    public unsafe string GetName()
    {
        var func = (delegate* unmanaged[Thiscall]<ref MissionControlClass, AnsiStringPointer>)0x5B3740;
        return func(ref this);
    }

    public unsafe void LoadFromINI(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<ref MissionControlClass, IntPtr, void>)0x5B3760;
        func(ref this, pINI);
    }

    [FieldOffset(0)] public int ArrayIndex;
    [FieldOffset(4)] public bool NoThreat;
    [FieldOffset(5)] public bool Zombie;
    [FieldOffset(6)] public bool Recruitable;
    [FieldOffset(7)] public bool Paralyzed;
    [FieldOffset(8)] public bool Retaliate;
    [FieldOffset(9)] public bool Scatter;
    [FieldOffset(16)] public double Rate; //default 0.016
    [FieldOffset(24)] public double AARate; //default 0.016
}

[StructLayout(LayoutKind.Explicit, Size = 212)]
public struct MissionClass
{
    public unsafe bool QueueMission(Mission mission, bool start_mission)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, Mission, bool, bool>)this.GetVirtualFunctionPointer(122);
        return func(this.GetThisPointer(), mission, start_mission);
    }

    public unsafe bool NextMission()
    {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, Bool>)this.GetVirtualFunctionPointer(123);
        return func(ref this);
    }
    public unsafe bool ForceMission(Mission mission)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, Mission, bool>)this.GetVirtualFunctionPointer(124);
        return func(this.GetThisPointer(), mission);
    }
    public unsafe void StartMission(Mission mission, Pointer<AbstractClass> pTarget, Pointer<AbstractClass> pDestination = default)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, Mission, nint, nint, void>)this.GetVirtualFunctionPointer(125);
        func(this.GetThisPointer(), mission, pTarget, pDestination);
    }

    public unsafe bool Mission_Revert()
    {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, Bool>)this.GetVirtualFunctionPointer(126);
        return func(ref this);
    }
    public unsafe bool HasForcedMission()
    {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, Bool>)this.GetVirtualFunctionPointer(127);
        return func(ref this);
    }
    public unsafe bool CanDoNextMission() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, Bool>)this.GetVirtualFunctionPointer(128);
        return func(ref this);
    }
    public unsafe int Mission_Sleep() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(129);
        return func(ref this);
    }
    public unsafe int Mission_Harmless() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(130);
        return func(ref this);
    }
    public unsafe int Mission_Ambush() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(131);
        return func(ref this);
    }
    public unsafe int Mission_Attack() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(132);
        return func(ref this);
    }
    public unsafe int Mission_Capture() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(133);
        return func(ref this);
    }
    public unsafe int Mission_Eaten() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(134);
        return func(ref this);
    }
    public unsafe int Mission_Guard() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(135);
        return func(ref this);
    }
    public unsafe int Mission_AreaGuard() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(136);
        return func(ref this);
    }
    public unsafe int Mission_Harvest() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(137);
        return func(ref this);
    }
    public unsafe int Mission_Hunt() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(138);
        return func(ref this);
    }
    public unsafe int Mission_Move() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(139);
        return func(ref this);
    }
    public unsafe int Mission_Retreat() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(140);
        return func(ref this);
    }
    public unsafe int Mission_Return() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(141);
        return func(ref this);
    }
    public unsafe int Mission_Stop() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(142);
        return func(ref this);
    }
    public unsafe int Mission_Unload() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(143);
        return func(ref this);
    }
    public unsafe int Mission_Enter() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(144);
        return func(ref this);
    }
    public unsafe int Mission_Construction() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(145);
        return func(ref this);
    }
    public unsafe int Mission_Selling() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(146);
        return func(ref this);
    }
    public unsafe int Mission_Repair() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(147);
        return func(ref this);
    }
    public unsafe int Mission_Missile() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(148);
        return func(ref this);
    }
    public unsafe int Mission_Open() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(149);
        return func(ref this);
    }
    public unsafe int Mission_Rescue() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(150);
        return func(ref this);
    }
    public unsafe int Mission_Patrol() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(151);
        return func(ref this);
    }
    public unsafe int Mission_ParaDropApproach() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(152);
        return func(ref this);
    }
    public unsafe int Mission_ParaDropOverfly() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(153);
        return func(ref this);
    }
    public unsafe int Mission_Wait() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(154);
        return func(ref this);
    }
    public unsafe int Mission_SpyPlaneApproach() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(155);
        return func(ref this);
    }
    public unsafe int Mission_SpyPlaneOverfly() {
        var func = (delegate* unmanaged[Thiscall]<ref MissionClass, int>)this.GetVirtualFunctionPointer(156);
        return func(ref this);
    }

    [FieldOffset(0)] public ObjectClass Base;
    [FieldOffset(0)] public AbstractClass BaseAbstract;

    [FieldOffset(172)] public Mission CurrentMission;
    [FieldOffset(176)] public Mission unknown_mission_B0;
    [FieldOffset(180)] public Mission QueuedMission;

    [FieldOffset(188)] public int MissionStatus;
    [FieldOffset(192)] public int CurrentMissionStartTime;    //in frames

    [FieldOffset(200)] public TimerStruct UpdateTimer;
}