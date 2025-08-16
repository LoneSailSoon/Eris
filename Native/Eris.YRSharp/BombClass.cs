

using System.Numerics;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct BombClass
{
    public unsafe void Detonate()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x438720;
        func(this.GetThisPointer());
    }
    public unsafe void Disarm()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x4389B0;
        func(this.GetThisPointer());
    }
    public unsafe bool IsDeathBomb()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)0x4389F0;
        return func(this.GetThisPointer()) == 0;
    }
    public unsafe int GetCurrentFlickerFrame()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)0x438A00;
        return func(this.GetThisPointer());
    }
    public unsafe bool TimeToExplode()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x438A70;
        return func(this.GetThisPointer());
    }

    
    [FieldOffset(0)] public AbstractClass Base;
    [FieldOffset(36)] public nint owner;
    public readonly Pointer<TechnoClass> Owner => owner;
    [FieldOffset(40)] public nint ownerHouse;
    public readonly Pointer<HouseClass> OwnerHouse => ownerHouse;
    [FieldOffset(44)] public nint target;
    public readonly Pointer<ObjectClass> Target => target;
    [FieldOffset(48)] public int deathBomb;
    public bool DeathBomb
    {
        get => deathBomb != 0;
        set => deathBomb = value ? 1 : 0;
    }
    [FieldOffset(52)] public int PlantingFrame;
    [FieldOffset(56)] public int DetonationFrame;
    [FieldOffset(60)] public AudioController Audio;
    [FieldOffset(80)] public int TickSound;
    [FieldOffset(84)] public int shouldPlayTickingSound;
    public bool ShouldPlayTickingSound
    {
        get => shouldPlayTickingSound != 0;
        set => shouldPlayTickingSound = value ? 1 : 0;
    }

    [FieldOffset(88)] public Bool Harmless;
}