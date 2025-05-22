using System.Runtime.InteropServices;
using Eris.YRSharp.GeneralStructures;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Sequential)]
public struct BulletData
{
    public TimerStruct UnknownTimer;
    public TimerStruct ArmTimer;
    public CoordStruct Location;
    public int Distance;
};

[StructLayout(LayoutKind.Explicit, Size = 352)]
public struct BulletClass : IYRObject<BulletTypeClass>/*, IExtMapIndex*/
{
    public const nint ArrayPointer = 0xA8ED40;
    public static ref DynamicVectorClass<Pointer<BulletClass>> Array => ref DynamicVectorClass<Pointer<BulletClass>>.GetDynamicVector(ArrayPointer);

    Pointer<BulletTypeClass> IYRObject<BulletTypeClass>.Type => Type;

    // 123 virtual functions
    public void SetTarget(Pointer<AbstractClass> pTarget)
    {
        this.Target = pTarget;
    }

    public unsafe bool MoveTo(CoordStruct where, BulletVelocity velocity)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, bool>)this.GetVirtualFunctionPointer(124);
        return func(this.GetThisPointer(), where.GetThisPointer(), velocity.GetThisPointer());
    }

    public unsafe void Fire(bool destroy = false)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, void>)0x468D80;
        func(this.GetThisPointer(), destroy);
    }

    public unsafe void Detonate(CoordStruct coords)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x4690B0;
        func(this.GetThisPointer(), coords.GetThisPointer());
    }

    public unsafe void LoseTarget()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x468430;
        func(this.GetThisPointer());
    }

    [FieldOffset(0)] public ObjectClass Base;
    [FieldOffset(0)] public AbstractClass BaseAbstract;


    [FieldOffset(172)] public Pointer<BulletTypeClass> Type;
    [FieldOffset(176)] public Pointer<TechnoClass> Owner;

    [FieldOffset(180)] public byte align_b4;
    [FieldOffset(180)] public sbyte align_Sb4;

    [FieldOffset(184)] public BulletData Data;
    [FieldOffset(224)] public Bool Bright;

    [FieldOffset(232)] public BulletVelocity Velocity;

    [FieldOffset(261)] public Bool CourseLocked;
    [FieldOffset(264)] public int CourseLockedDuration;
    [FieldOffset(268)] public Pointer<AbstractClass> Target;
    [FieldOffset(272)] public int Speed;
    [FieldOffset(276)] public int InheritedColor;

    [FieldOffset(296)] public Pointer<WarheadTypeClass> WH;
    [FieldOffset(300)] public byte AnimFrame;
    [FieldOffset(301)] public byte AnimRateCounter;
    [FieldOffset(304)] public Pointer<WeaponTypeClass> WeaponType;
    [FieldOffset(308)] public CoordStruct SourceCoords;
    [FieldOffset(320)] public CoordStruct TargetCoords;
    [FieldOffset(332)] public CellStruct LastMapCoords;
    [FieldOffset(336)] public int DamageMultiplier;
    [FieldOffset(340)] public Pointer<AnimClass> NextAnim;
    [FieldOffset(344)] public Bool SpawnNextAnim;


    [FieldOffset(348)] public int Range;



}