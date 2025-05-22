using System.Runtime.InteropServices;
using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.String.Ansi;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 3576)]
public struct TechnoTypeClass
{
    private const nint ArrayPointer = 0xA8EB00;

    public static GlobalDvcArray<TechnoTypeClass> AbstractTypeArray { get; } = new(ArrayPointer);


    public unsafe bool CanAttackMove()
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoTypeClass, Bool>)this.GetVirtualFunctionPointer(41);
        return func(ref this);
    }

    public unsafe bool CanCreateHere(CellStruct mapCoords, Pointer<HouseClass> pOwner)
    {
        var func =
            (delegate* unmanaged[Thiscall]<ref TechnoTypeClass, ref CellStruct, IntPtr, Bool>)this
                .GetVirtualFunctionPointer(42);
        return func(ref this, ref mapCoords, pOwner);
    }

    public unsafe int GetCost()
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoTypeClass, int>)this.GetVirtualFunctionPointer(43);
        return func(ref this);
    }

    public unsafe int GetRepairStepCost()
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoTypeClass, int>)this.GetVirtualFunctionPointer(44);
        return func(ref this);
    }

    public unsafe int GetRepairStep()
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoTypeClass, int>)this.GetVirtualFunctionPointer(45);
        return func(ref this);
    }

    public unsafe int GetRefund(Pointer<HouseClass> pHouse, bool bUnk)
    {
        var func =
            (delegate* unmanaged[Thiscall]<ref TechnoTypeClass, IntPtr, Bool, int>)this.GetVirtualFunctionPointer(46);
        return func(ref this, pHouse, bUnk);
    }

    public unsafe int GetFlightLevel()
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoTypeClass, int>)this.GetVirtualFunctionPointer(47);
        return func(ref this);
    }

    Pointer<WeaponStruct> GetWeapon(int index, bool elite)
    {
        return elite ? this.EliteWeapon + index : this.Weapon + index;
    }


    [FieldOffset(0)] public ObjectTypeClass Base;
    [FieldOffset(0)] public AbstractTypeClass BaseAbstractType;

    [FieldOffset(844)] public Guid Locomotor;
    [FieldOffset(896)] public double Size;
    [FieldOffset(904)] public double SizeLimit;

    [FieldOffset(1460)] public MovementZone MovementZone;
    [FieldOffset(1504)] public int Passengers;
    [FieldOffset(1508)] public Bool OpenTopped;

    [FieldOffset(1552)] public int Cost;
    [FieldOffset(1588)] public int TechLevel;

    [FieldOffset(1656)] public int Speed;

    [FieldOffset(1660)] public SpeedType SpeedType;

    [FieldOffset(1750)] public byte CameoFile_first;
    public AnsiStringPointer CameoFile => Pointer<byte>.AsPointer(ref CameoFile_first);

    // [FieldOffset(1776)] public Pointer<SHPStruct> Cameo;
    [FieldOffset(1780)] public Bool CameoAllocated;
    [FieldOffset(1801)] public byte AltCameoFile_first;
    public AnsiStringPointer AltCameoFile => Pointer<byte>.AsPointer(ref AltCameoFile_first);

    // [FieldOffset(1808)] public Pointer<SHPStruct> AltCameo;
    [FieldOffset(1812)] public Bool AltCameoAllocated;

    [FieldOffset(2200)] public WeaponStruct Weapon_first;
    public Pointer<WeaponStruct> Weapon => Pointer<WeaponStruct>.AsPointer(ref Weapon_first);
    [FieldOffset(2704)] public Bool ClearAllWeapons;
    [FieldOffset(2708)] public WeaponStruct EliteWeapon_first;
    public Pointer<WeaponStruct> EliteWeapon => Pointer<WeaponStruct>.AsPointer(ref EliteWeapon_first);

    [FieldOffset(3434)] public Bool BalloonHover;
    [FieldOffset(3476)] public Bool JumpJet;
    [FieldOffset(992)] public int PixelSelectionBracketDelta;

    [FieldOffset(1028)] public IntPtr deploysInto;
    public Pointer<BuildingTypeClass> DeploysInto => deploysInto;
    [FieldOffset(1032)] public IntPtr undeploysInto;
    public Pointer<UnitTypeClass> UndeploysInto => undeploysInto;
    [FieldOffset(1668)] public int Ammo;

    [FieldOffset(3277)] public Bool Crewed;
    [FieldOffset(3278)] public Bool Naval;
    [FieldOffset(3280)] public Bool Cloakable;
    [FieldOffset(3348)] public Bool SelfHealing;
    [FieldOffset(3349)] public Bool Explodes;
    [FieldOffset(3361)] public Bool TurretSpins;
    [FieldOffset(3367)] public Bool HunterSeeker;
    [FieldOffset(3368)] public Bool Crusher;
    [FieldOffset(3369)] public Bool OmniCrusher;
    [FieldOffset(3370)] public Bool OmniCrushResistant;
    [FieldOffset(3371)] public Bool TiltsWhenCrushes;
    [FieldOffset(3372)] public Bool IsSubterranean;
    [FieldOffset(3373)] public Bool AutoCrush;
    [FieldOffset(3374)] public Bool Bunkerable;
    [FieldOffset(3375)] public Bool CanDisguise;
    [FieldOffset(3376)] public Bool PermaDisguise;
    [FieldOffset(3377)] public Bool DetectDisguise;
    [FieldOffset(3378)] public Bool DisguiseWhenStill;
    [FieldOffset(3379)] public Bool CanApproachTarget;
    [FieldOffset(3380)] public Bool CanRecalcApproachTarget;
    [FieldOffset(3385)] public Bool DefaultToGuardArea;
    [FieldOffset(3412)] public Bool Spawned;
    [FieldOffset(3412)] public int SpawnsNumber;
    [FieldOffset(3412)] public int SpawnRegenRate;
    [FieldOffset(3412)] public int SpawnReloadRate;
    [FieldOffset(3432)] public Bool MissileSpawn;
    [FieldOffset(3433)] public Bool Underwater;
    [FieldOffset(3436)] public int SuppressionThreshold;
    [FieldOffset(3440)] public int JumpjetTurnRate;
    [FieldOffset(3444)] public int JumpjetSpeed;
    [FieldOffset(3448)] public float JumpjetClimb;
    [FieldOffset(3452)] public float JumpjetCrash;
    [FieldOffset(3456)] public int JumpjetHeight;
    [FieldOffset(3460)] public float JumpjetAccel;
    [FieldOffset(3464)] public float JumpjetWobbles;
    [FieldOffset(3468)] public Bool JumpjetNoWobbles;
    [FieldOffset(3472)] public int JumpjetDeviation;
    [FieldOffset(3477)] public Bool Crashable;
    [FieldOffset(3478)] public Bool ConsideredAircraft;
    [FieldOffset(3479)] public Bool Organic;
    [FieldOffset(3480)] public Bool NoShadow;
    [FieldOffset(3481)] public Bool CanPassiveAquire;
    [FieldOffset(3482)] public Bool CanRetaliate;
    [FieldOffset(3516)] public Bool IsSelectableCombatant;
    [FieldOffset(3517)] public Bool Accelerates;
    [FieldOffset(3518)] public Bool DisableVoxelCache;
    [FieldOffset(3519)] public Bool DisableShadowCache;
}

[StructLayout(LayoutKind.Sequential)]
public struct WeaponStruct
{
    public IntPtr weaponType;

    public Pointer<WeaponTypeClass> WeaponType
    {
        get => weaponType;
        set => weaponType = value;
    }

    public CoordStruct FLH;
    public int BarrelLength;
    public int BarrelThickness;
    public bool TurretLocked;
}