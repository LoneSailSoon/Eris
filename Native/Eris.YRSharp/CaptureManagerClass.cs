﻿using System.Runtime.InteropServices;
using Eris.YRSharp.GeneralStructures;
using Eris.YRSharp.Helpers;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Sequential)]
public struct ControlNode
{
    public Pointer<TechnoClass> Unit;
    public Pointer<HouseClass> OriginalOwner;
    public TimerStruct LinkDrawTimer;
};

[StructLayout(LayoutKind.Explicit, Size = 80)]
public struct CaptureManagerClass
{
    public static unsafe Pointer<CaptureManagerClass> Cotr(Pointer<CaptureManagerClass> pThis,
        Pointer<TechnoClass> pOwner, int nMaxControlNodes, bool bInfiniteControl)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int, bool, nint>)0x4717D0;
        return func(pThis, pOwner, nMaxControlNodes, bInfiniteControl);
    }

    public static void Constructor(Pointer<CaptureManagerClass> pThis, Pointer<TechnoClass> pOwner, int nMaxControlNodes, bool bInfiniteControl)
    {
        Cotr(pThis, pOwner, nMaxControlNodes, bInfiniteControl);
    }
    public unsafe bool CaptureUnit(Pointer<TechnoClass> pUnit)
    {
        var func = (delegate* unmanaged[Thiscall]<ref CaptureManagerClass, IntPtr, Bool>)0x471D40;
        return func(ref this, pUnit);
    }
    public unsafe bool FreeUnit(Pointer<TechnoClass> pUnit)
    {
        var func = (delegate* unmanaged[Thiscall]<ref CaptureManagerClass, IntPtr, Bool>)0x471FF0;
        return func(ref this, pUnit);
    }
    public unsafe void FreeUnit()
    {
        var func = (delegate* unmanaged[Thiscall]<ref CaptureManagerClass, void>)0x472140;
        func(ref this);
    }
    public unsafe bool NeutralizeVictim(Pointer<TechnoClass> pVictim)
    {
        var func = (delegate* unmanaged[Thiscall]<ref CaptureManagerClass, IntPtr, Bool>)0x472330;
        return func(ref this, pVictim);
    }
    public unsafe bool CanCapture(Pointer<TechnoClass> target)
    {
        var func = (delegate* unmanaged[Thiscall]<ref CaptureManagerClass, IntPtr, Bool>)0x471C90;
        return func(ref this, target);
    }
    public unsafe bool CannotControlAnyMore()
    {
        var func = (delegate* unmanaged[Thiscall]<ref CaptureManagerClass, Bool>)0x4722A0;
        return func(ref this);
    }
    public unsafe bool IsControllingSomething()
    {
        var func = (delegate* unmanaged[Thiscall]<ref CaptureManagerClass, Bool>)0x4722C0;
        return func(ref this);
    }
    public unsafe bool IsOverloading(out bool wasDamageApplied)
    {
        var func = (delegate* unmanaged[Thiscall]<ref CaptureManagerClass, out bool, Bool>)0x4726C0;
        return func(ref this, out wasDamageApplied);
    }
    public unsafe void HandleOverload()
    {
        var func = (delegate* unmanaged[Thiscall]<ref CaptureManagerClass, void>)0x471A50;
        func(ref this);
    }
    public unsafe bool NeedsToDrawLinks()
    {
        var func = (delegate* unmanaged[Thiscall]<ref CaptureManagerClass, Bool>)0x472640;
        return func(ref this);
    }
    public unsafe bool DrawLinks()
    {
        var func = (delegate* unmanaged[Thiscall]<ref CaptureManagerClass, Bool>)0x472160;
        return func(ref this);
    }
    public unsafe void DecideUnitFate(Pointer<TechnoClass> unit)
    {
        var func = (delegate* unmanaged[Thiscall]<ref CaptureManagerClass, IntPtr, void>)0x4723B0;
        func(ref this, unit);
    }
    public unsafe Pointer<HouseClass> GetOriginalOwner(Pointer<TechnoClass> unit)
    {
        var func = (delegate* unmanaged[Thiscall]<ref CaptureManagerClass, IntPtr, IntPtr>)0x4722F0;
        return func(ref this, unit);
    }

    public readonly int NumControlNodes => ControlNodes.Count;


    [FieldOffset(0)] public AbstractClass Base;
    [FieldOffset(36)] public DynamicVectorClass<Pointer<ControlNode>> ControlNodes;
    [FieldOffset(60)] public int MaxControlNodes;
    [FieldOffset(64)] public Bool InfiniteMindControl;
    [FieldOffset(65)] public Bool OverloadDeathSoundPlayed; // Has the mind control death sound played already?

    [FieldOffset(68)] public int OverloadPipState; // Used to create the red overloading pip by returning true in IsOverloading's wasDamageApplied for 10 frames.
    [FieldOffset(72)] public Pointer<TechnoClass> Owner;
    [FieldOffset(76)] public int OverloadDamageDelay; // Decremented every frame. If it reaches zero, OverloadDamage is applied.
}