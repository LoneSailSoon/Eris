using System.Runtime.CompilerServices;
using Eris.YRSharp.FileFormats;
using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.String.Ansi;
using Eris.YRSharp.String.Uni;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 6040)]
public struct BuildingTypeClass
{
    public unsafe bool CanCreateHere(CellStruct mapCoords, Pointer<HouseClass> pHouse)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, bool>)0x464AC0;
        return func(this.GetThisPointer(), mapCoords.GetThisPointer(), pHouse);
    }

    // public static unsafe Pointer<BuildingTypeClass> FindOrAllocate(string ID)
    // {
    //     var func = (delegate* unmanaged[Thiscall]<int, IntPtr, IntPtr>)ASM.FastCallTransferStation;
    //     return func(0x4653C0, new AnsiString(ID));
    // }

    public unsafe short GetFoundationWidth()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, short>)0x45EC90;
        return func(this.GetThisPointer());
    }

    public unsafe short GetFoundationHeight(bool bIncludeBib)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, short>)0x45ECA0;
        return func(this.GetThisPointer(), bIncludeBib);
    }

    [FieldOffset(0)] public TechnoTypeClass Base;
    [FieldOffset(0)] public ObjectTypeClass BaseObjectType;
    [FieldOffset(0)] public AbstractTypeClass BaseAbstractType;

    [FieldOffset(3576)] public int ArrayIndex;
    // [FieldOffset(3580)] public nint foundationData;
    // public readonly Pointer<CellStruct> FoundationData => foundationData;
    // [FieldOffset(3764)] public int Adjacent;
    // [FieldOffset(3768)] public AbstractType Factory;
    // [FieldOffset(3808)] public int PowerBonus;
    // [FieldOffset(3812)] public int PowerDrain;
    // [FieldOffset(3824)] public int Foundation;
    // [FieldOffset(3828)] public int Height;
    // [FieldOffset(3832)] public int OccupyHeight;
    // [FieldOffset(5408)] public int NormalZAdjust;
    // [FieldOffset(5450)] public Bool TogglePower;
    // [FieldOffset(5451)] public Bool HasSpotlight;
    // [FieldOffset(5452)] public Bool IsTemple;
    // [FieldOffset(5453)] public Bool IsPlug;
    // [FieldOffset(5454)] public Bool HoverPad;
    // [FieldOffset(5455)] public Bool BaseNormal;
    // [FieldOffset(5456)] public Bool EligibileForAllyBuilding;
    // [FieldOffset(5457)] public Bool EligibleForDelayKill;
    // [FieldOffset(5458)] public Bool NeedsEngineer;
    // [FieldOffset(5490)] public Bool Capturable;
    // [FieldOffset(5495)] public Bool CanC4;
    // [FieldOffset(5498)] public Bool ClickRepairable;
    // [FieldOffset(5825)] public Bool Hospital;
    // [FieldOffset(5835)] public Bool Helipad;
    // [FieldOffset(5889)] public Bool InvisibleInGame;
    // [FieldOffset(5891)] public Bool PlaceAnywhere;
    // [FieldOffset(6016)] public int NumberOfDocks;


    [FieldOffset(3580)] public nint foundationData;
    public readonly Pointer<CellStruct> FoundationData => foundationData;
    [FieldOffset(3584)] public nint buildup;
    public readonly Pointer<ShpStruct> Buildup => buildup;
    [FieldOffset(3588)] public Bool BuildupLoaded;
    [FieldOffset(3592)] public BuildCat BuildCat;
    [FieldOffset(3596)] public CoordStruct HalfDamageSmokeLocation1;
    [FieldOffset(3608)] public CoordStruct HalfDamageSmokeLocation2;
    [FieldOffset(3624)] public double GateCloseDelay;
    [FieldOffset(3632)] public int LightVisibility;
    [FieldOffset(3636)] public int LightIntensity;
    [FieldOffset(3640)] public int LightRedTint;
    [FieldOffset(3644)] public int LightGreenTint;
    [FieldOffset(3648)] public int LightBlueTint;
    [FieldOffset(3652)] public Point2D PrimaryFirePixelOffset;
    [FieldOffset(3660)] public Point2D SecondaryFirePixelOffset;

    [FieldOffset(3668)] public nint toOverlay;

//public readonly Pointer<OverlayTypeClass> ToOverlay => toOverlay;
    [FieldOffset(3672)] public int ToTile;
    [FieldOffset(3676)] public byte buildupFile;
    public AnsiStringPointer BuildupFile => Pointer<byte>.AsPointer(ref buildupFile);
    [FieldOffset(3692)] public int BuildupSound;
    [FieldOffset(3696)] public int PackupSound;
    [FieldOffset(3700)] public int CreateUnitSound;
    [FieldOffset(3704)] public int UnitEnterSound;
    [FieldOffset(3708)] public int UnitExitSound;
    [FieldOffset(3712)] public int WorkingSound;
    [FieldOffset(3716)] public int NotWorkingSound;
    [FieldOffset(3720)] public byte powersUpBuilding;
    public AnsiStringPointer PowersUpBuilding => Pointer<byte>.AsPointer(ref powersUpBuilding);
    [FieldOffset(3744)] public nint freeUnit;
    public readonly Pointer<UnitTypeClass> FreeUnit => freeUnit;
    [FieldOffset(3748)] public nint secretInfantry;
    public readonly Pointer<InfantryTypeClass> SecretInfantry => secretInfantry;
    [FieldOffset(3752)] public nint secretUnit;
    public readonly Pointer<UnitTypeClass> SecretUnit => secretUnit;
    [FieldOffset(3756)] public nint secretBuilding;
    public readonly Pointer<BuildingTypeClass> SecretBuilding => secretBuilding;
    [FieldOffset(3760)] public int field_EB0;
    [FieldOffset(3764)] public int Adjacent;
    [FieldOffset(3768)] public AbstractType Factory;
    [FieldOffset(3772)] public CoordStruct TargetCoordOffset;
    [FieldOffset(3784)] public CoordStruct ExitCoord;
    [FieldOffset(3796)] public nint foundationOutside;
    public readonly Pointer<CellStruct> FoundationOutside => foundationOutside;
    [FieldOffset(3800)] public int field_ED8;
    [FieldOffset(3804)] public int DeployFacing;
    [FieldOffset(3808)] public int PowerBonus;
    [FieldOffset(3812)] public int PowerDrain;
    [FieldOffset(3816)] public int ExtraPowerBonus;

    [FieldOffset(3820)] public int ExtraPowerDrain;

//[FieldOffset(3824)] public Foundation Foundation;
    [FieldOffset(3828)] public int Height;
    [FieldOffset(3832)] public int OccupyHeight;
    [FieldOffset(3836)] public int MidPoint;
    [FieldOffset(3840)] public int DoorStages;

    [FieldOffset(3844)] public byte buildingAnimFrame;

//public FixedArray<BuildingAnimFrameStruct> BuildingAnimFrame => new(ref Unsafe.As<byte, BuildingAnimFrameStruct>(ref buildingAnimFrame), 6);
    [FieldOffset(3916)] public byte buildingAnim;

//public FixedArray<BuildingAnimStruct> BuildingAnim => new(ref Unsafe.As<byte, BuildingAnimStruct>(ref buildingAnim), 21);
    [FieldOffset(5344)] public int Upgrades;
    [FieldOffset(5348)] public nint deployingAnim;
    public readonly Pointer<ShpStruct> DeployingAnim => deployingAnim;
    [FieldOffset(5352)] public Bool DeployingAnimLoaded;
    [FieldOffset(5356)] public nint underDoorAnim;
    public readonly Pointer<ShpStruct> UnderDoorAnim => underDoorAnim;
    [FieldOffset(5360)] public Bool UnderDoorAnimLoaded;
    [FieldOffset(5364)] public nint rubble;
    public readonly Pointer<ShpStruct> Rubble => rubble;
    [FieldOffset(5368)] public Bool RubbleLoaded;
    [FieldOffset(5372)] public nint roofDeployingAnim;
    public readonly Pointer<ShpStruct> RoofDeployingAnim => roofDeployingAnim;
    [FieldOffset(5376)] public Bool RoofDeployingAnimLoaded;
    [FieldOffset(5380)] public nint underRoofDoorAnim;
    public readonly Pointer<ShpStruct> UnderRoofDoorAnim => underRoofDoorAnim;
    [FieldOffset(5384)] public Bool UnderRoofDoorAnimLoaded;
    [FieldOffset(5388)] public nint doorAnim;
    public readonly Pointer<ShpStruct> DoorAnim => doorAnim;
    [FieldOffset(5392)] public nint specialZOverlay;
    public readonly Pointer<ShpStruct> SpecialZOverlay => specialZOverlay;
    [FieldOffset(5396)] public int SpecialZOverlayZAdjust;
    [FieldOffset(5400)] public nint bibShape;
    public readonly Pointer<ShpStruct> BibShape => bibShape;
    [FieldOffset(5404)] public Bool BibShapeLoaded;
    [FieldOffset(5408)] public int NormalZAdjust;
    [FieldOffset(5412)] public int AntiAirValue;
    [FieldOffset(5416)] public int AntiArmorValue;
    [FieldOffset(5420)] public int AntiInfantryValue;
    [FieldOffset(5424)] public Point2D ZShapePointMove;
    [FieldOffset(5432)] public int unknown_1538;
    [FieldOffset(5436)] public int unknown_153C;
    [FieldOffset(5440)] public int unknown_1540;
    [FieldOffset(5444)] public int unknown_1544;
    [FieldOffset(5448)] public ushort ExtraLight;
    [FieldOffset(5450)] public Bool TogglePower;
    [FieldOffset(5451)] public Bool HasSpotlight;
    [FieldOffset(5452)] public Bool IsTemple;
    [FieldOffset(5453)] public Bool IsPlug;
    [FieldOffset(5454)] public Bool HoverPad;
    [FieldOffset(5455)] public Bool BaseNormal;
    [FieldOffset(5456)] public Bool EligibileForAllyBuilding;
    [FieldOffset(5457)] public Bool EligibleForDelayKill;
    [FieldOffset(5458)] public Bool NeedsEngineer;
    [FieldOffset(5460)] public int CaptureEvaEvent;
    [FieldOffset(5464)] public int ProduceCashStartup;
    [FieldOffset(5468)] public int ProduceCashAmount;
    [FieldOffset(5472)] public int ProduceCashDelay;
    [FieldOffset(5476)] public int InfantryGainSelfHeal;
    [FieldOffset(5480)] public int UnitsGainSelfHeal;
    [FieldOffset(5484)] public int RefinerySmokeFrames;
    [FieldOffset(5488)] public Bool Bib;
    [FieldOffset(5489)] public Bool Wall;
    [FieldOffset(5490)] public Bool Capturable;
    [FieldOffset(5491)] public Bool Powered;
    [FieldOffset(5492)] public Bool PoweredSpecial;
    [FieldOffset(5493)] public Bool Overpowerable;
    [FieldOffset(5494)] public Bool Spyable;
    [FieldOffset(5495)] public Bool CanC4;
    [FieldOffset(5496)] public Bool WantsExtraSpace;
    [FieldOffset(5497)] public Bool Unsellable;
    [FieldOffset(5498)] public Bool ClickRepairable;
    [FieldOffset(5499)] public Bool CanBeOccupied;
    [FieldOffset(5500)] public Bool CanOccupyFire;
    [FieldOffset(5504)] public int MaxNumberOccupants;
    [FieldOffset(5508)] public Bool ShowOccupantPips;
    [FieldOffset(5512)] public byte muzzleFlash;
    public FixedArray<Point2D> MuzzleFlash => new(ref Unsafe.As<byte, Point2D>(ref muzzleFlash), 10);
    [FieldOffset(5592)] public byte damageFireOffset;
    public FixedArray<Point2D> DamageFireOffset => new(ref Unsafe.As<byte, Point2D>(ref damageFireOffset), 8);
    [FieldOffset(5656)] public Point2D QueueingCell;
    [FieldOffset(5664)] public int NumberImpassableRows;
    [FieldOffset(5668)] public byte removeOccupy;
    public FixedArray<Point2D> RemoveOccupy => new(ref Unsafe.As<byte, Point2D>(ref removeOccupy), 8);
    [FieldOffset(5732)] public byte addOccupy;
    public FixedArray<Point2D> AddOccupy => new(ref Unsafe.As<byte, Point2D>(ref addOccupy), 8);
    [FieldOffset(5796)] public Bool Radar;
    [FieldOffset(5797)] public Bool SpySat;
    [FieldOffset(5798)] public Bool ChargeAnim;
    [FieldOffset(5799)] public Bool IsAnimDelayedFire;
    [FieldOffset(5800)] public Bool SiloDamage;
    [FieldOffset(5801)] public Bool UnitRepair;
    [FieldOffset(5802)] public Bool UnitReload;
    [FieldOffset(5803)] public Bool Bunker;
    [FieldOffset(5804)] public Bool Cloning;
    [FieldOffset(5805)] public Bool Grinding;
    [FieldOffset(5806)] public Bool UnitAbsorb;
    [FieldOffset(5807)] public Bool InfantryAbsorb;
    [FieldOffset(5808)] public Bool SecretLab;
    [FieldOffset(5809)] public Bool DoubleThick;
    [FieldOffset(5810)] public Bool Flat;
    [FieldOffset(5811)] public Bool DockUnload;
    [FieldOffset(5812)] public Bool Recoilless;
    [FieldOffset(5813)] public Bool HasStupidGuardMode;
    [FieldOffset(5814)] public Bool BridgeRepairHut;
    [FieldOffset(5815)] public Bool Gate;
    [FieldOffset(5816)] public Bool SAM;
    [FieldOffset(5817)] public Bool ConstructionYard;
    [FieldOffset(5818)] public Bool NukeSilo;
    [FieldOffset(5819)] public Bool Refinery;
    [FieldOffset(5820)] public Bool Weeder;
    [FieldOffset(5821)] public Bool WeaponsFactory;
    [FieldOffset(5822)] public Bool LaserFencePost;
    [FieldOffset(5823)] public Bool LaserFence;
    [FieldOffset(5824)] public Bool FirestormWall;
    [FieldOffset(5825)] public Bool Hospital;
    [FieldOffset(5826)] public Bool Armory;
    [FieldOffset(5827)] public Bool EMPulseCannon;
    [FieldOffset(5828)] public Bool TickTank;
    [FieldOffset(5829)] public Bool TurretAnimIsVoxel;
    [FieldOffset(5830)] public Bool BarrelAnimIsVoxel;
    [FieldOffset(5831)] public Bool CloakGenerator;
    [FieldOffset(5832)] public Bool SensorArray;
    [FieldOffset(5833)] public Bool ICBMLauncher;
    [FieldOffset(5834)] public Bool Artillary;
    [FieldOffset(5835)] public Bool Helipad;
    [FieldOffset(5836)] public Bool OrePurifier;
    [FieldOffset(5837)] public Bool FactoryPlant;
    [FieldOffset(5840)] public float InfantryCostBonus;
    [FieldOffset(5844)] public float UnitsCostBonus;
    [FieldOffset(5848)] public float AircraftCostBonus;
    [FieldOffset(5852)] public float BuildingsCostBonus;
    [FieldOffset(5856)] public float DefensesCostBonus;
    [FieldOffset(5860)] public Bool GDIBarracks;
    [FieldOffset(5861)] public Bool NODBarracks;
    [FieldOffset(5862)] public Bool YuriBarracks;
    [FieldOffset(5864)] public float ChargedAnimTime;
    [FieldOffset(5868)] public int DelayedFireDelay;
    [FieldOffset(5872)] public int SuperWeapon;
    [FieldOffset(5876)] public int SuperWeapon2;
    [FieldOffset(5880)] public int GateStages;
    [FieldOffset(5884)] public int PowersUpToLevel;
    [FieldOffset(5888)] public Bool DamagedDoor;
    [FieldOffset(5889)] public Bool InvisibleInGame;
    [FieldOffset(5890)] public Bool TerrainPalette;
    [FieldOffset(5891)] public Bool PlaceAnywhere;
    [FieldOffset(5892)] public Bool ExtraDamageStage;
    [FieldOffset(5893)] public Bool AIBuildThis;
    [FieldOffset(5894)] public Bool IsBaseDefense;
    [FieldOffset(5895)] public byte CloakRadiusInCells;
    [FieldOffset(5896)] public Bool ConcentricRadialIndicator;
    [FieldOffset(5900)] public int PsychicDetectionRadius;
    [FieldOffset(5904)] public int BarrelStartPitch;
    [FieldOffset(5908)] public byte voxelBarrelFile;
    public AnsiStringPointer VoxelBarrelFile => Pointer<byte>.AsPointer(ref voxelBarrelFile);
    [FieldOffset(5936)] public CoordStruct VoxelBarrelOffsetToPitchPivotPoint;
    [FieldOffset(5948)] public CoordStruct VoxelBarrelOffsetToRotatePivotPoint;
    [FieldOffset(5960)] public CoordStruct VoxelBarrelOffsetToBuildingPivotPoint;
    [FieldOffset(5972)] public CoordStruct VoxelBarrelOffsetToBarrelEnd;
    [FieldOffset(5984)] public Bool DemandLoad;
    [FieldOffset(5985)] public Bool DemandLoadBuildup;
    [FieldOffset(5986)] public Bool FreeBuildup;
    [FieldOffset(5987)] public Bool IsThreatRatingNode;
    [FieldOffset(5988)] public Bool PrimaryFireDualOffset;
    [FieldOffset(5989)] public Bool ProtectWithWall;
    [FieldOffset(5990)] public Bool CanHideThings;
    [FieldOffset(5991)] public Bool CrateBeneath;
    [FieldOffset(5992)] public Bool LeaveRubble;
    [FieldOffset(5993)] public Bool CrateBeneathIsMoney;
    [FieldOffset(5994)] public byte theaterSpecificID;
    public AnsiStringPointer TheaterSpecificID => Pointer<byte>.AsPointer(ref theaterSpecificID);
    [FieldOffset(6016)] public int NumberOfDocks;
    [FieldOffset(6020)] public Vector<CoordStruct> DockingOffsets;
}