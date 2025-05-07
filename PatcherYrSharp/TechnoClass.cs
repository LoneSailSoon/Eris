using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PatcherYrSharp.GeneralDefinitions;
using PatcherYrSharp.GeneralStructures;
using PatcherYrSharp.Helpers;

namespace PatcherYrSharp;

[StructLayout(LayoutKind.Explicit, Size = 1312)]
public struct TechnoClass : IYrObject<TechnoTypeClass>
{
    public unsafe Pointer<TechnoTypeClass> Type => Base.GetTechnoType();

    public unsafe bool IsVoxel()
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, Bool>)this.GetVirtualFunctionPointer(166);
        return func(ref this);
    }

    public unsafe bool CanReachLocation(CoordStruct destCoords)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, ref CoordStruct, Bool>)this.GetVirtualFunctionPointer(179);
        return func(ref this, ref destCoords);
    }

    public unsafe int SelectWeapon(Pointer<AbstractClass> pTarget)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, int>)this.GetVirtualFunctionPointer(185);
        return func(ref this, pTarget);
    }
    public unsafe int SelectNavalTargeting(Pointer<AbstractClass> pTarget)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, int>)this.GetVirtualFunctionPointer(186);
        return func(ref this, pTarget);
    }

    public unsafe int GetROF(int idxWeapon)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, int, int>)this.GetVirtualFunctionPointer(198);
        return func(ref this, idxWeapon);
    }
    public unsafe int GetGuardRange(int dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, int, int>)this.GetVirtualFunctionPointer(199);
        return func(ref this, dwUnk);
    }
    public unsafe bool IsUnderEMP() // CanMove
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, Bool>)this.GetVirtualFunctionPointer(223);
        return func(ref this);
    }


    public unsafe int DecreaseAmmo()
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, int>)this.GetVirtualFunctionPointer(228);
        return func(ref this);
    }
    public unsafe void AddPassenger(Pointer<FootClass> pPassenger)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, void>)this.GetVirtualFunctionPointer(229);
        func(ref this, pPassenger);
    }

    public unsafe bool IsCloseEnough(Pointer<AbstractClass> pTarget, int idxWeapon)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, int, Bool>)this.GetVirtualFunctionPointer(234);
        return func(ref this, pTarget, idxWeapon);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IsCloseEnoughToAttack(Pointer<AbstractClass> pTarget)
    {
        return TechnoClassIsCloseEnoughToAttack((int)this.GetThisPointer(), (int)pTarget);
    }

    [DllImport("YRPP.Private.CoreLib.dll")]
    private static extern bool TechnoClassIsCloseEnoughToAttack(int pThis, int pTarget);


    public unsafe bool IsCloseEnoughToAttackCoords(CoordStruct coords)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, ref CoordStruct, Bool>)this.GetVirtualFunctionPointer(236);
        return func(ref this, ref coords);
    }

    public unsafe bool Destroyed(Pointer<ObjectClass> pKiller)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, Bool>)this.GetVirtualFunctionPointer(238);
        return func(ref this, pKiller);
    }
    public unsafe FireError GetFireErrorWithoutRange(Pointer<AbstractClass> pTarget, int nWeaponIndex)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, int, FireError>)this.GetVirtualFunctionPointer(239);
        return func(ref this, pTarget, nWeaponIndex);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FireError GetFireError(Pointer<AbstractClass> pTarget, int nWeaponIndex, bool ignoreRange)
    {
        return (FireError)TechnoClassFireError((int)this.GetThisPointer(), (int)pTarget, nWeaponIndex, ignoreRange);
    }

    [DllImport("YRPP.Private.CoreLib.dll")]
    private static extern int TechnoClassFireError(int pThis, int pTarget, int nWeaponIndex, bool ignoreRange);


    public unsafe Pointer<TechnoClass> SelectAutoTarget(TargetFlags TargetFlags, CoordStruct TargetCoord, bool OnlyTargetHouseEnemy)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, TargetFlags, ref CoordStruct, Bool, IntPtr>)this.GetVirtualFunctionPointer(241);
        return func(ref this, TargetFlags, ref TargetCoord, OnlyTargetHouseEnemy);
    }
    public unsafe void SetTarget(Pointer<AbstractClass> pTarget)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, void>)this.GetVirtualFunctionPointer(242);
        func(ref this, pTarget);
    }
    public unsafe Pointer<BulletClass> Fire(Pointer<AbstractClass> pTarget, int nWeaponIndex)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, int, IntPtr>)this.GetVirtualFunctionPointer(243);
        return func(ref this, pTarget, nWeaponIndex);
    }
    public unsafe void Guard()
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, void>)this.GetVirtualFunctionPointer(244);
        func(ref this);
    }
    public unsafe bool SetOwningHouse(Pointer<HouseClass> pHouse, bool announce = true)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, bool>)this.GetVirtualFunctionPointer(245);
        return func(this.GetThisPointer(), pHouse, announce);
    }
    public unsafe void UpdateRockingState(CoordStruct rockingCoord, float rockerValue, bool halfEffect)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, ref CoordStruct, float, Bool, void>)this.GetVirtualFunctionPointer(246);
        func(ref this, ref rockingCoord, rockerValue, halfEffect);
    }
    public unsafe bool Crash(Pointer<ObjectClass> pKiller)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, Bool>)this.GetVirtualFunctionPointer(247);
        return func(ref this, pKiller);
    }

    public unsafe Pointer<WeaponStruct> GetDeployWeapon()
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr>)this.GetVirtualFunctionPointer(252);
        return func(ref this);
    }
    public unsafe Pointer<WeaponStruct> GetTurretWeapon()
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr>)this.GetVirtualFunctionPointer(253);
        return func(ref this);
    }
    public unsafe Pointer<WeaponStruct> GetWeapon(int idxWeapon)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, int, IntPtr>)this.GetVirtualFunctionPointer(254);
        return func(ref this, idxWeapon);
    }
    public unsafe bool HasTurret()
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, Bool>)this.GetVirtualFunctionPointer(255);
        return func(ref this);
    }
    public unsafe bool CanOccupyFire()
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, Bool>)this.GetVirtualFunctionPointer(256);
        return func(ref this);
    }
    public unsafe int GetOccupyRangeBonus()
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, int>)this.GetVirtualFunctionPointer(257);
        return func(ref this);
    }
    public unsafe int GetOccupantCount()
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, int>)this.GetVirtualFunctionPointer(258);
        return func(ref this);
    }

    public unsafe CoordStruct GetTargetCoords()
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, out CoordStruct, Bool>)this.GetVirtualFunctionPointer(267);
        func(ref this, out CoordStruct tmp);
        return tmp;
    }

    public unsafe void SetDestination(Pointer<AbstractClass> pDest, bool bUnk = true)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, Bool, void>)this.GetVirtualFunctionPointer(288);
        func(ref this, pDest, bUnk);
    }

    public unsafe bool CanAttackOnTheMove()
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, Bool>)this.GetVirtualFunctionPointer(304);
        return func(ref this);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool InRange(CoordStruct location, Pointer<AbstractClass> pTarget, Pointer<WeaponTypeClass> pWeapon)
    {
        return TechnoClassInRange((int)this.GetThisPointer(), location.X, location.Y, location.Z, (int)pTarget, (int)pWeapon);
    }

    [DllImport("YRPP.Private.CoreLib.dll")]
    private static extern bool TechnoClassInRange(int pThis, int x, int y, int z, int pTarget, int pWeapon);

    public unsafe void SetFocus(Pointer<AbstractClass> pTarget)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, void>)0x70C610;
        func(ref this, pTarget);
    }


    public unsafe bool IsMindControlled()
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, Bool>)0x7105E0;
        return func(ref this);
    }

    public unsafe bool CanBePermMindControlled()
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, Bool>)0x53C450;
        return func(ref this);
    }


    public unsafe void SetTargetForPassengers(Pointer<AbstractClass> pTarget)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, void>)0x710550;
        func(ref this, pTarget);
    }

    public unsafe Pointer<HouseClass> GetOriginalOwner()
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr>)0x70F820;
        return func(ref this);
    }

    public unsafe int GetDistanceToTarget(Pointer<AbstractClass> pTarget)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, int>)0x5F6360;
        return func(ref this, pTarget);
    }

    public unsafe void Sensed()
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, void>)0x6F4EB0;
        func(ref this);
    }

    public unsafe bool HasAbility(Ability ability)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, Ability, Bool>)0x70D0D0;
        return func(ref this, ability);
    }

    public unsafe void EnteredOpenTopped(Pointer<TechnoClass> pPayload)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, void>)0x710470;
        func(ref this, pPayload);
    }

    public unsafe void KillPassengers(Pointer<TechnoClass> pSource)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x707CB0;
        func(this.GetThisPointer(), pSource);
    }


    public unsafe Pointer<LaserDrawClass> CreateLaser(Pointer<AbstractClass> pTarget, int weaponIndex, Pointer<WeaponTypeClass> pWeapon, CoordStruct sourceCoord)
    {
        var func = (delegate* unmanaged[Thiscall]<ref TechnoClass, IntPtr, int, IntPtr, ref CoordStruct, IntPtr>)0x6FD210;
        return func(ref this, pTarget, weaponIndex, pWeapon, ref sourceCoord);
    }


    [FieldOffset(0)] public RadioClass BaseRadio;
    [FieldOffset(0)] public MissionClass BaseMission;
    [FieldOffset(0)] public ObjectClass Base;
    [FieldOffset(0)] public AbstractClass BaseAbstract;





    [FieldOffset(240)] public FlashData Flashing;
    [FieldOffset(248)] public ProgressTimer Animation; // how the unit animates
    [FieldOffset(276)] public PassengersClass Passengers;
    [FieldOffset(284)] public IntPtr transporter; // eg Disk . PowerPlant, this points to PowerPlant
    public Pointer<TechnoClass> Transporter { get => transporter; set => transporter = value; }



    [FieldOffset(312)] public int CurrentWeaponNumber;

    [FieldOffset(336)] public VeterancyStruct Veterancy;
    [FieldOffset(344)] public double ArmorMultiplier;

    [FieldOffset(352)] public double FirepowerMultiplier;

    [FieldOffset(456)] public Bool Deactivated; //Robot Tanks without power for instance

    [FieldOffset(460)] public IntPtr drainTarget; // eg Disk . PowerPlant, this points to PowerPlant
    public Pointer<TechnoClass> DrainTarget { get => drainTarget; set => drainTarget = value; }

    [FieldOffset(464)] public IntPtr drainingMe; // eg Disk . PowerPlant, this points to Disk
    public Pointer<TechnoClass> DrainingMe { get => drainingMe; set => drainingMe = value; }

    [FieldOffset(468)] public IntPtr drainAnim;
    public Pointer<AnimClass> DrainAnim { get => drainAnim; set => drainAnim = value; }
    [FieldOffset(532)] public int Group;

    [FieldOffset(536)] public IntPtr focus;
    public Pointer<AbstractClass> Focus { get => focus; set => focus = value; }

    [FieldOffset(540)] public IntPtr owner;
    public Pointer<HouseClass> Owner { get => owner; set => owner = value; }

    [FieldOffset(544)] public CloakStates CloakStates;
    [FieldOffset(664)] public Bool Berzerk;

    // unless source is Pushy=
    // abs_Infantry source links with abs_Unit target and vice versa - can't attack others until current target flips
    // no checking whether source is Infantry, but no update for other types either
    // old Brute hack
    [FieldOffset(680)] public IntPtr directRockerLinkedUnit;
    public Pointer<FootClass> DirectRockerLinkedUnit { get => directRockerLinkedUnit; set => directRockerLinkedUnit = value; }
    [FieldOffset(684)] public IntPtr locomotorTarget; // mag->LocoTarget = victim
    public Pointer<FootClass> LocomotorTarget { get => locomotorTarget; set => locomotorTarget = value; }
    [FieldOffset(688)] public IntPtr locomotorSource; // victim->LocoSource = mag
    public Pointer<FootClass> LocomotorSource { get => locomotorSource; set => locomotorSource = value; }

    [FieldOffset(692)] public Pointer<AbstractClass> Target; //if attacking
    [FieldOffset(696)] public Pointer<AbstractClass> LastTarget;
    [FieldOffset(700)] public IntPtr captureManager;

    //public static uint pExt123 = 677;
    //public static uint pExt4 = 689;



    public Pointer<CaptureManagerClass> CaptureManager { get => captureManager; set => captureManager = value; }
    [FieldOffset(704)] public IntPtr mindControlledBy;
    public Pointer<TechnoClass> MindControlledBy { get => mindControlledBy; set => mindControlledBy = value; }
    [FieldOffset(708)] public Bool MindControlledByAUnit;

    [FieldOffset(712)] public IntPtr mindControlRingAnim;
    public Pointer<AnimClass> MindControlRingAnim { get => mindControlRingAnim; set => mindControlRingAnim = value; }
    [FieldOffset(716)] public IntPtr mindControlledByHouse;
    public Pointer<AnimClass> MindControlledByHouse { get => mindControlledByHouse; set => mindControlledByHouse = value; }

    [FieldOffset(720)] public IntPtr spawnManager;
    public Pointer<SpawnManagerClass> SpawnManager { get => spawnManager; set => spawnManager = value; }

    [FieldOffset(724)] public IntPtr spawnOwner;
    public Pointer<TechnoClass> SpawnOwner { get => spawnOwner; set => spawnOwner = value; }


    [FieldOffset(764)] public int Ammo;
    [FieldOffset(748)] public TimerStruct ROFTimer;

    // rocking effect
    [FieldOffset(808)] public float AngleRotatedSideways;
    [FieldOffset(812)] public float AngleRotatedForwards;

    // set these and leave the previous two alone!
    // if these are set, the unit will roll up to pi/4, by this step each frame, and balance back
    [FieldOffset(816)] public float RockingSidewaysPerFrame; // left to right - positive pushes left side up
    [FieldOffset(820)] public float RockingForwardsPerFrame; // back to front - positive pushes ass up

    [FieldOffset(824)] public int HijackerInfantryType; // mutant hijacker

    [FieldOffset(828)] public OwnedTiberiumStruct Tiberium;

    [FieldOffset(880)] public FacingStruct BarrelFacing;
    [FieldOffset(904)] public FacingStruct Facing;
    [FieldOffset(928)] public FacingStruct TurretFacing;
    [FieldOffset(952)] public int CurrentBurstIndex;

    [FieldOffset(972)] public Bool CountedAsOwned; // is this techno contained in OwningPlayer.Owned... counts?
    [FieldOffset(973)] public Bool IsSinking;
    [FieldOffset(974)] public Bool WasSinkingAlready; // if(IsSinking && !WasSinkingAlready) { play SinkingSound; WasSinkingAlready = 1; }

    [FieldOffset(977)] public Bool HasBeenAttacked; // ReceiveDamage when not HouseClass_IsAlly
    [FieldOffset(978)] public Bool Cloakable;
    [FieldOffset(979)] public Bool IsPrimaryFactory; // doubleclicking a warfac/barracks sets it as primary
    [FieldOffset(980)] public Bool Spawned;
    [FieldOffset(981)] public Bool IsInPlayfield;


    [FieldOffset(1050)] public Bool IsHumanControlled;
    [FieldOffset(1051)] public Bool DiscoveredByPlayer;
    [FieldOffset(1052)] public Bool DiscoveredByComputer;

    [FieldOffset(1056)] public byte SightIncrease;

    [FieldOffset(1059)] public Bool IsRadarTracked;
    [FieldOffset(1060)] public Bool IsOnCarryall;
    [FieldOffset(1061)] public Bool IsCrashing;
    [FieldOffset(1062)] public Bool WasCrashingAlready;
    [FieldOffset(1063)] public Bool IsBeingManipulated;
    [FieldOffset(1073)] public Bool IsMouseHovering;

    [FieldOffset(1088)] public DynamicVectorClass<int> CurrentTargetThreatValues;
    [FieldOffset(1112)] public DynamicVectorClass<Pointer<AbstractClass>> CurrentTargets;

    // if DistributedFire=yes, this is used to determine which possible targets should be ignored in the latest threat scan
    [FieldOffset(1136)] public DynamicVectorClass<Pointer<AbstractClass>> AttackedTargets;
    [FieldOffset(1184)] public Bool unknown_4A0;

    [FieldOffset(1280)] public IntPtr _enterTarget;

    public Pointer<TechnoClass> EnterTarget { get => _enterTarget; set => _enterTarget = value; }
    [FieldOffset(1292)] public Bool ShouldLoseTargetNow;

    [FieldOffset(1304)] public Pointer<ObjectTypeClass> Disguise;
    [FieldOffset(1308)] public Pointer<HouseClass> DisguisedAsHouse;
}