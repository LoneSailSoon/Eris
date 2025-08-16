using System.Runtime.CompilerServices;
using Eris.YRSharp.FileFormats;
using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.String.Ansi;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 3576)]
public struct TechnoTypeClass
{
    private const nint ArrayPointer = 0xA8EB00;

    public static readonly GlobalDvcArray<TechnoTypeClass> AbstractTypeArray = new(ArrayPointer);


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

    public Pointer<WeaponStruct> GetWeapon(int index, bool elite)
    {
        return elite ? this.EliteWeapon + index : this.Weapon + index;
    }


    [FieldOffset(0)] public ObjectTypeClass Base;
    [FieldOffset(0)] public AbstractTypeClass BaseAbstractType;

    [FieldOffset(1750)] public byte CameoFile_first;
    public AnsiStringPointer CameoFile => Pointer<byte>.AsPointer(ref CameoFile_first);

    [FieldOffset(1801)] public byte AltCameoFile_first;
    public AnsiStringPointer AltCameoFile => Pointer<byte>.AsPointer(ref AltCameoFile_first);

    // [FieldOffset(1808)] public Pointer<SHPStruct> AltCameo;

    [FieldOffset(2200)] public WeaponStruct Weapon_first;
    public Pointer<WeaponStruct> Weapon => Pointer<WeaponStruct>.AsPointer(ref Weapon_first);
    [FieldOffset(2708)] public WeaponStruct EliteWeapon_first;
    public Pointer<WeaponStruct> EliteWeapon => Pointer<WeaponStruct>.AsPointer(ref EliteWeapon_first);


    [FieldOffset(660)] public int WalkRate;
    [FieldOffset(664)] public int IdleRate;
    [FieldOffset(668)] public AbilitiesStruct VeteranAbilities;
    [FieldOffset(686)] public AbilitiesStruct EliteAbilities;
    [FieldOffset(704)] public double SpecialThreatValue;
    [FieldOffset(712)] public double MyEffectivenessCoefficient;
    [FieldOffset(720)] public double TargetEffectivenessCoefficient;
    [FieldOffset(728)] public double TargetSpecialThreatCoefficient;
    [FieldOffset(736)] public double TargetStrengthCoefficient;
    [FieldOffset(744)] public double TargetDistanceCoefficient;
    [FieldOffset(752)] public double ThreatAvoidanceCoefficient;
    [FieldOffset(760)] public int SlowdownDistance;
    [FieldOffset(768)] public double unknown_double_300;
    [FieldOffset(776)] public double AccelerationFactor;
    [FieldOffset(784)] public int CloakingSpeed;
    [FieldOffset(788)] public byte debrisTypes;

    public ref TypeList<Pointer<VoxelAnimTypeClass>> DebrisTypes =>
        ref TypeList<Pointer<VoxelAnimTypeClass>>.From(debrisTypes.GetThisPointer());

    [FieldOffset(816)] public byte debrisMaximums;

    public ref TypeList<int> DebrisMaximums =>
        ref TypeList<int>.From(debrisMaximums.GetThisPointer());


    [FieldOffset(844)] public Guid Locomotor;
    [FieldOffset(864)] public double VoxelScaleX;
    [FieldOffset(872)] public double VoxelScaleY;
    [FieldOffset(880)] public double Weight;
    [FieldOffset(888)] public double PhysicalSize;
    [FieldOffset(896)] public double Size;
    [FieldOffset(904)] public double SizeLimit;
    [FieldOffset(912)] public Bool HoverAttack;
    [FieldOffset(916)] public int VHPScan;
    [FieldOffset(920)] public int unknown_int_398;
    [FieldOffset(928)] public double RollAngle;
    [FieldOffset(936)] public double PitchSpeed;
    [FieldOffset(944)] public double PitchAngle;
    [FieldOffset(952)] public int BuildLimit;
    [FieldOffset(956)] public Category Category;
    [FieldOffset(960)] public uint unknown_3C0;
    [FieldOffset(968)] public double DeployTime;
    [FieldOffset(976)] public int FireAngle;
    [FieldOffset(980)] public PipScale PipScale;
    [FieldOffset(984)] public Bool PipsDrawForAll;
    [FieldOffset(988)] public int LeptonMindControlOffset;
    [FieldOffset(992)] public int PixelSelectionBracketDelta;
    [FieldOffset(996)] public int PipWrap;
    [FieldOffset(1000)] public byte dock;

    public ref TypeList<Pointer<BuildingTypeClass>> Dock =>
        ref TypeList<Pointer<BuildingTypeClass>>.From(dock.GetThisPointer());

    [FieldOffset(1028)] public nint deploysInto;
    public readonly Pointer<BuildingTypeClass> DeploysInto => deploysInto;
    [FieldOffset(1032)] public nint undeploysInto;
    public readonly Pointer<UnitTypeClass> UndeploysInto => undeploysInto;
    [FieldOffset(1036)] public nint powersUnit;
    public readonly Pointer<UnitTypeClass> PowersUnit => powersUnit;
    [FieldOffset(1040)] public Bool PoweredUnit;
    [FieldOffset(1044)] public byte voiceSelect;

    public ref TypeList<int> VoiceSelect =>
        ref TypeList<int>.From(voiceSelect.GetThisPointer());

    [FieldOffset(1072)] public byte voiceSelectEnslaved;

    public ref TypeList<int> VoiceSelectEnslaved =>
        ref TypeList<int>.From(voiceSelectEnslaved.GetThisPointer());

    [FieldOffset(1100)] public byte voiceSelectDeactivated;

    public ref TypeList<int> VoiceSelectDeactivated =>
        ref TypeList<int>.From(voiceSelectDeactivated.GetThisPointer());

    [FieldOffset(1128)] public byte voiceMove;

    public ref TypeList<int> VoiceMove =>
        ref TypeList<int>.From(voiceMove.GetThisPointer());

    [FieldOffset(1156)] public byte voiceAttack;

    public ref TypeList<int> VoiceAttack =>
        ref TypeList<int>.From(voiceAttack.GetThisPointer());

    [FieldOffset(1184)] public byte voiceSpecialAttack;

    public ref TypeList<int> VoiceSpecialAttack =>
        ref TypeList<int>.From(voiceSpecialAttack.GetThisPointer());

    [FieldOffset(1212)] public byte voiceDie;

    public ref TypeList<int> VoiceDie =>
        ref TypeList<int>.From(voiceDie.GetThisPointer());

    [FieldOffset(1240)] public byte voiceFeedback;

    public ref TypeList<int> VoiceFeedback =>
        ref TypeList<int>.From(voiceFeedback.GetThisPointer());

    [FieldOffset(1268)] public byte moveSound;

    public ref TypeList<int> MoveSound =>
        ref TypeList<int>.From(moveSound.GetThisPointer());

    [FieldOffset(1296)] public byte dieSound;

    public ref TypeList<int> DieSound =>
        ref TypeList<int>.From(dieSound.GetThisPointer());

    [FieldOffset(1324)] public int AuxSound1;
    [FieldOffset(1328)] public int AuxSound2;
    [FieldOffset(1332)] public int CreateSound;
    [FieldOffset(1336)] public int DamageSound;
    [FieldOffset(1340)] public int ImpactWaterSound;
    [FieldOffset(1344)] public int ImpactLandSound;
    [FieldOffset(1348)] public int CrashingSound;
    [FieldOffset(1352)] public int SinkingSound;
    [FieldOffset(1356)] public int VoiceFalling;
    [FieldOffset(1360)] public int VoiceCrashing;
    [FieldOffset(1364)] public int VoiceSinking;
    [FieldOffset(1368)] public int VoiceEnter;
    [FieldOffset(1372)] public int VoiceCapture;
    [FieldOffset(1376)] public int TurretRotateSound;
    [FieldOffset(1380)] public int EnterTransportSound;
    [FieldOffset(1384)] public int LeaveTransportSound;
    [FieldOffset(1388)] public int DeploySound;
    [FieldOffset(1392)] public int UndeploySound;
    [FieldOffset(1396)] public int ChronoInSound;
    [FieldOffset(1400)] public int ChronoOutSound;
    [FieldOffset(1404)] public int VoiceHarvest;
    [FieldOffset(1408)] public int VoicePrimaryWeaponAttack;
    [FieldOffset(1412)] public int VoicePrimaryEliteWeaponAttack;
    [FieldOffset(1416)] public int VoiceSecondaryWeaponAttack;
    [FieldOffset(1420)] public int VoiceSecondaryEliteWeaponAttack;
    [FieldOffset(1424)] public int VoiceDeploy;
    [FieldOffset(1428)] public int VoiceUndeploy;
    [FieldOffset(1432)] public int EnterGrinderSound;
    [FieldOffset(1436)] public int LeaveGrinderSound;
    [FieldOffset(1440)] public int EnterBioReactorSound;
    [FieldOffset(1444)] public int LeaveBioReactorSound;
    [FieldOffset(1448)] public int ActivateSound;
    [FieldOffset(1452)] public int DeactivateSound;
    [FieldOffset(1456)] public int MindClearedSound;
    [FieldOffset(1460)] public MovementZone MovementZone;
    [FieldOffset(1464)] public int GuardRange;
    [FieldOffset(1468)] public int MinDebris;
    [FieldOffset(1472)] public int MaxDebris;
    [FieldOffset(1476)] public byte debrisAnims;

    public ref TypeList<Pointer<AnimClass>> DebrisAnims =>
        ref TypeList<Pointer<AnimClass>>.From(debrisAnims.GetThisPointer());

    [FieldOffset(1504)] public int Passengers;
    [FieldOffset(1508)] public Bool OpenTopped;
    [FieldOffset(1512)] public int Sight;
    [FieldOffset(1516)] public Bool ResourceGatherer;
    [FieldOffset(1517)] public Bool ResourceDestination;
    [FieldOffset(1518)] public Bool RevealToAll;
    [FieldOffset(1519)] public Bool Drainable;
    [FieldOffset(1520)] public int SensorsSight;
    [FieldOffset(1524)] public int DetectDisguiseRange;
    [FieldOffset(1528)] public int BombSight;
    [FieldOffset(1532)] public int LeadershipRating;
    [FieldOffset(1536)] public NavalTargetingType NavalTargeting;
    [FieldOffset(1540)] public LandTargetingType LandTargeting;
    [FieldOffset(1544)] public float BuildTimeMultiplier;
    [FieldOffset(1548)] public int MindControlRingOffset;
    [FieldOffset(1552)] public int Cost;
    [FieldOffset(1556)] public int Soylent;
    [FieldOffset(1560)] public int FlightLevel;
    [FieldOffset(1564)] public int AirstrikeTeam;
    [FieldOffset(1568)] public int EliteAirstrikeTeam;
    [FieldOffset(1572)] public nint airstrikeTeamType;
    public readonly Pointer<AircraftTypeClass> AirstrikeTeamType => airstrikeTeamType;
    [FieldOffset(1576)] public nint eliteAirstrikeTeamType;
    public readonly Pointer<AircraftTypeClass> EliteAirstrikeTeamType => eliteAirstrikeTeamType;
    [FieldOffset(1580)] public int AirstrikeRechargeTime;
    [FieldOffset(1584)] public int EliteAirstrikeRechargeTime;
    [FieldOffset(1588)] public int TechLevel;
    [FieldOffset(1592)] public byte prerequisite;

    public ref TypeList<int> Prerequisite =>
        ref TypeList<int>.From(prerequisite.GetThisPointer());

    [FieldOffset(1620)] public byte prerequisiteOverride;

    public ref TypeList<int> PrerequisiteOverride =>
        ref TypeList<int>.From(prerequisiteOverride.GetThisPointer());

    [FieldOffset(1648)] public int ThreatPosed;
    [FieldOffset(1652)] public int Points;
    [FieldOffset(1656)] public int Speed;
    [FieldOffset(1660)] public SpeedType SpeedType;
    [FieldOffset(1664)] public int InitialAmmo;
    [FieldOffset(1668)] public int Ammo;
    [FieldOffset(1672)] public int IFVMode;
    [FieldOffset(1676)] public int AirRangeBonus;
    [FieldOffset(1680)] public Bool BerserkFriendly;
    [FieldOffset(1681)] public Bool SprayAttack;
    [FieldOffset(1682)] public Bool Pushy;
    [FieldOffset(1683)] public Bool Natural;
    [FieldOffset(1684)] public Bool Unnatural;
    [FieldOffset(1685)] public Bool CloseRange;
    [FieldOffset(1688)] public int Reload;
    [FieldOffset(1692)] public int EmptyReload;
    [FieldOffset(1696)] public int ReloadIncrement;
    [FieldOffset(1700)] public int RadialFireSegments;
    [FieldOffset(1704)] public int DeployFireWeapon;
    [FieldOffset(1708)] public Bool DeployFire;
    [FieldOffset(1709)] public Bool DeployToLand;
    [FieldOffset(1710)] public Bool MobileFire;
    [FieldOffset(1711)] public Bool OpportunityFire;
    [FieldOffset(1712)] public Bool DistributedFire;
    [FieldOffset(1713)] public Bool DamageReducesReadiness;
    [FieldOffset(1716)] public int ReadinessReductionMultiplier;
    [FieldOffset(1720)] public nint unloadingClass;
    public readonly Pointer<UnitTypeClass> UnloadingClass => unloadingClass;
    [FieldOffset(1724)] public nint deployingAnim;
    public readonly Pointer<AnimTypeClass> DeployingAnim => deployingAnim;
    [FieldOffset(1728)] public Bool AttackFriendlies;
    [FieldOffset(1729)] public Bool AttackCursorOnFriendlies;
    [FieldOffset(1732)] public int UndeployDelay;
    [FieldOffset(1736)] public Bool PreventAttackMove;
    [FieldOffset(1740)] public uint OwnerFlags;
    [FieldOffset(1744)] public int AIBasePlanningSide;
    [FieldOffset(1748)] public Bool StupidHunt;
    [FieldOffset(1749)] public Bool AllowedToStartInMultiplayer;
    [FieldOffset(1776)] public nint cameo;
    public readonly Pointer<ShpStruct> Cameo => cameo;
    [FieldOffset(1780)] public Bool CameoAllocated;
    [FieldOffset(1808)] public nint altCameo;
    public readonly Pointer<ShpStruct> AltCameo => altCameo;
    [FieldOffset(1812)] public Bool AltCameoAllocated;
    [FieldOffset(1816)] public int RotCount;
    [FieldOffset(1820)] public int ROT;
    [FieldOffset(1824)] public int TurretOffset;
    [FieldOffset(1828)] public Bool CanBeHidden;
    [FieldOffset(1832)] public int Points2;
    [FieldOffset(1836)] public byte explosion;

    public ref TypeList<Pointer<AnimTypeClass>> Explosion =>
        ref TypeList<Pointer<AnimTypeClass>>.From(explosion.GetThisPointer());

    [FieldOffset(1864)] public byte destroyAnim;

    public ref TypeList<Pointer<AnimTypeClass>> DestroyAnim =>
        ref TypeList<Pointer<AnimTypeClass>>.From(destroyAnim.GetThisPointer());

    [FieldOffset(1892)] public nint naturalParticleSystem;
    public readonly Pointer<ParticleSystemTypeClass> NaturalParticleSystem => naturalParticleSystem;
    [FieldOffset(1896)] public CoordStruct NaturalParticleSystemLocation;
    [FieldOffset(1908)] public nint refinerySmokeParticleSystem;
    public readonly Pointer<ParticleSystemTypeClass> RefinerySmokeParticleSystem => refinerySmokeParticleSystem;
    [FieldOffset(1912)] public byte damageParticleSystems;

    public ref TypeList<Pointer<ParticleSystemTypeClass>> DamageParticleSystems => ref Pointer<byte>
        .AsPointer(ref damageParticleSystems).Convert<TypeList<Pointer<ParticleSystemTypeClass>>>().Ref;

    [FieldOffset(1940)] public byte destroyParticleSystems;

    public ref TypeList<Pointer<ParticleSystemTypeClass>> DestroyParticleSystems => ref Pointer<byte>
        .AsPointer(ref destroyParticleSystems).Convert<TypeList<Pointer<ParticleSystemTypeClass>>>().Ref;

    [FieldOffset(1968)] public CoordStruct DamageSmokeOffset;
    [FieldOffset(1980)] public Bool DamSmkOffScrnRel;
    [FieldOffset(1984)] public CoordStruct DestroySmokeOffset;
    [FieldOffset(1996)] public CoordStruct RefinerySmokeOffsetOne;
    [FieldOffset(2008)] public CoordStruct RefinerySmokeOffsetTwo;
    [FieldOffset(2020)] public CoordStruct RefinerySmokeOffsetThree;
    [FieldOffset(2032)] public CoordStruct RefinerySmokeOffsetFour;
    [FieldOffset(2044)] public int ShadowIndex;
    [FieldOffset(2048)] public int Storage;
    [FieldOffset(2052)] public Bool TurretNotExportedOnGround;
    [FieldOffset(2053)] public Bool Gunner;
    [FieldOffset(2054)] public Bool HasTurretTooltips;
    [FieldOffset(2056)] public int TurretCount;
    [FieldOffset(2060)] public int WeaponCount;
    [FieldOffset(2064)] public Bool IsChargeTurret;
    [FieldOffset(2068)] public int TurretWeapon;
    [FieldOffset(2704)] public Bool ClearAllWeapons;
    [FieldOffset(3212)] public Bool TypeImmune;
    [FieldOffset(3213)] public Bool MoveToShroud;
    [FieldOffset(3214)] public Bool Trainable;
    [FieldOffset(3215)] public Bool DamageSparks;
    [FieldOffset(3216)] public Bool TargetLaser;
    [FieldOffset(3217)] public Bool ImmuneToVeins;
    [FieldOffset(3218)] public Bool TiberiumHeal;
    [FieldOffset(3219)] public Bool CloakStop;
    [FieldOffset(3220)] public Bool IsTrain;
    [FieldOffset(3221)] public Bool IsDropship;
    [FieldOffset(3222)] public Bool ToProtect;
    [FieldOffset(3223)] public Bool Disableable;
    [FieldOffset(3224)] public Bool Unbuildable;
    [FieldOffset(3225)] public Bool DoubleOwned;
    [FieldOffset(3226)] public Bool Invisible;
    [FieldOffset(3227)] public Bool RadarVisible;
    [FieldOffset(3228)] public Bool HasPrimary;
    [FieldOffset(3229)] public Bool Sensors;
    [FieldOffset(3230)] public Bool Nominal;
    [FieldOffset(3231)] public Bool DontScore;
    [FieldOffset(3232)] public Bool DamageSelf;
    [FieldOffset(3233)] public Bool Turret;
    [FieldOffset(3234)] public Bool TurretRecoil;
    [FieldOffset(3236)] public TurretControl TurretAnimData;
    [FieldOffset(3252)] public Bool unknown_bool_CB4;
    [FieldOffset(3256)] public TurretControl BarrelAnimData;
    [FieldOffset(3272)] public Bool unknown_bool_CC8;
    [FieldOffset(3276)] public Bool Repairable;
    [FieldOffset(3277)] public Bool Crewed;
    [FieldOffset(3278)] public Bool Naval;
    [FieldOffset(3279)] public Bool Remapable;
    [FieldOffset(3280)] public Bool Cloakable;
    [FieldOffset(3281)] public Bool GapGenerator;
    [FieldOffset(3282)] public byte GapRadiusInCells;
    [FieldOffset(3283)] public byte SuperGapRadiusInCells;
    [FieldOffset(3284)] public Bool Teleporter;
    [FieldOffset(3285)] public Bool IsGattling;
    [FieldOffset(3288)] public int WeaponStages;
    [FieldOffset(3292)] public byte weaponStage;
    public FixedArray<int> WeaponStage => new(ref Unsafe.As<byte, int>(ref weaponStage), 6);
    [FieldOffset(3316)] public byte eliteStage;
    public FixedArray<int> EliteStage => new(ref Unsafe.As<byte, int>(ref eliteStage), 6);
    [FieldOffset(3340)] public int RateUp;
    [FieldOffset(3344)] public int RateDown;
    [FieldOffset(3348)] public Bool SelfHealing;
    [FieldOffset(3349)] public Bool Explodes;
    [FieldOffset(3352)] public nint deathWeapon;
    public readonly Pointer<WeaponTypeClass> DeathWeapon => deathWeapon;
    [FieldOffset(3356)] public float DeathWeaponDamageModifier;
    [FieldOffset(3360)] public Bool NoAutoFire;
    [FieldOffset(3361)] public Bool TurretSpins;
    [FieldOffset(3362)] public Bool TiltCrashJumpjet;
    [FieldOffset(3363)] public Bool Normalized;
    [FieldOffset(3364)] public Bool ManualReload;
    [FieldOffset(3365)] public Bool VisibleLoad;
    [FieldOffset(3366)] public Bool LightningRod;
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
    [FieldOffset(3381)] public Bool ImmuneToPsionics;
    [FieldOffset(3382)] public Bool ImmuneToPsionicWeapons;
    [FieldOffset(3383)] public Bool ImmuneToRadiation;
    [FieldOffset(3384)] public Bool Parasiteable;
    [FieldOffset(3385)] public Bool DefaultToGuardArea;
    [FieldOffset(3386)] public Bool Warpable;
    [FieldOffset(3387)] public Bool ImmuneToPoison;
    [FieldOffset(3388)] public Bool ReselectIfLimboed;
    [FieldOffset(3389)] public Bool RejoinTeamIfLimboed;
    [FieldOffset(3390)] public Bool Slaved;
    [FieldOffset(3392)] public nint enslaves;
    public readonly Pointer<InfantryTypeClass> Enslaves => enslaves;
    [FieldOffset(3396)] public int SlavesNumber;
    [FieldOffset(3400)] public int SlaveRegenRate;
    [FieldOffset(3404)] public int SlaveReloadRate;
    [FieldOffset(3408)] public int OpenTransportWeapon;
    [FieldOffset(3412)] public Bool Spawned;
    [FieldOffset(3416)] public nint spawns;
    public readonly Pointer<AircraftTypeClass> Spawns => spawns;
    [FieldOffset(3420)] public int SpawnsNumber;
    [FieldOffset(3424)] public int SpawnRegenRate;
    [FieldOffset(3428)] public int SpawnReloadRate;
    [FieldOffset(3432)] public Bool MissileSpawn;
    [FieldOffset(3433)] public Bool Underwater;
    [FieldOffset(3434)] public Bool BalloonHover;
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
    [FieldOffset(3476)] public Bool JumpJet;
    [FieldOffset(3477)] public Bool Crashable;
    [FieldOffset(3478)] public Bool ConsideredAircraft;
    [FieldOffset(3479)] public Bool Organic;
    [FieldOffset(3480)] public Bool NoShadow;
    [FieldOffset(3481)] public Bool CanPassiveAquire;
    [FieldOffset(3482)] public Bool CanRetaliate;
    [FieldOffset(3483)] public Bool RequiresStolenThirdTech;
    [FieldOffset(3484)] public Bool RequiresStolenSovietTech;
    [FieldOffset(3485)] public Bool RequiresStolenAlliedTech;
    [FieldOffset(3488)] public uint RequiredHouses;
    [FieldOffset(3492)] public uint ForbiddenHouses;
    [FieldOffset(3496)] public uint SecretHouses;
    [FieldOffset(3500)] public Bool UseBuffer;
    [FieldOffset(3504)] public CoordStruct SecondSpawnOffset;
    [FieldOffset(3516)] public Bool IsSelectableCombatant;
    [FieldOffset(3517)] public Bool Accelerates;
    [FieldOffset(3518)] public Bool DisableVoxelCache;
    [FieldOffset(3519)] public Bool DisableShadowCache;
    [FieldOffset(3520)] public int ZFudgeCliff;
    [FieldOffset(3524)] public int ZFudgeColumn;
    [FieldOffset(3528)] public int ZFudgeTunnel;
    [FieldOffset(3532)] public int ZFudgeBridge;
    [FieldOffset(3536)] public byte paletteFile;
    public AnsiStringPointer PaletteFile => Pointer<byte>.AsPointer(ref paletteFile);
    [FieldOffset(3568)] public byte palette;

    public ref DynamicVectorClass<Pointer<ColorScheme>> Palette => ref Pointer<byte>.AsPointer(ref palette)
        .Convert<DynamicVectorClass<Pointer<ColorScheme>>>().Ref;
}

[StructLayout(LayoutKind.Explicit)]
public struct AbilitiesStruct
{
    [FieldOffset(0)]public Bool Faster;   //0x00
    [FieldOffset(1)]public Bool Stronger; //0x01
    [FieldOffset(2)]public Bool Firepower; //0x02
    [FieldOffset(3)]public Bool Scatter;  //0x03
    [FieldOffset(4)]public Bool Rof; //0x04
    [FieldOffset(5)]public Bool Sight; //0x05
    [FieldOffset(6)]public Bool Cloak; //0x06
    [FieldOffset(7)]public Bool TiberiumProof; //0x07
    [FieldOffset(8)]public Bool VeinProof; //0x08
    [FieldOffset(9)]public Bool SelfHeal; //0x09
    [FieldOffset(10)]public Bool Explodes; //0x0A
    [FieldOffset(11)]public Bool RadarInvisible; //0x0B
    [FieldOffset(12)]public Bool Sensors; //0x0C
    [FieldOffset(13)]public Bool Fearless; //0x0D
    [FieldOffset(14)]public Bool C4; //0x0E
    [FieldOffset(15)]public Bool TiberiumHeal; //0x0F
    [FieldOffset(16)]public Bool GuardArea; //0x10
    [FieldOffset(17)]public Bool Crusher; //0x11

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

[StructLayout(LayoutKind.Sequential)]
public struct TurretControl
{
    public int Travel;
    public int CompressFrames;
    public int RecoverFrames;
    public int HoldFrames;
}