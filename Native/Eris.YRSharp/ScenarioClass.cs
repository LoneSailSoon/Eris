using System.Runtime.CompilerServices;
using Eris.YRSharp.String.Ansi;
using Eris.YRSharp.String.Uni;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 14144)]
public struct ScenarioClass
{
    public const nint ppInstance = 0xA8B230;
    public static nint pInstance => ppInstance.Convert<Pointer<ScenarioClass>>().Ref;
    public static ref ScenarioClass Instance => ref ppInstance.Convert<Pointer<ScenarioClass>>().Ref.Ref;

    public const nint newINIFormat = 0xA8ED7C;
    public static ref int NewINIFormat => ref newINIFormat.Convert<int>().Ref;
    public const nint lastTheater = 0x822CF8;
    public static ref TheaterType LastTheater => ref lastTheater.Convert<TheaterType>().Ref;


    [FieldOffset(0)] public ScenarioFlags SpecialFlags;
    [FieldOffset(4)] public byte nextScenario;
    public AnsiStringPointer NextScenario => new(ref Unsafe.As<byte, byte>(ref nextScenario), 260);
    [FieldOffset(264)] public byte altNextScenario;
    public AnsiStringPointer AltNextScenario => new(ref Unsafe.As<byte, byte>(ref altNextScenario), 260);
    [FieldOffset(524)] public int HomeCell;
    [FieldOffset(528)] public int AltHomeCell;
    [FieldOffset(532)] public int UniqueID;
    [FieldOffset(536)] public Randomizer Random;
    [FieldOffset(1548)] public uint Difficulty1;
    [FieldOffset(1552)] public uint Difficulty2;
    [FieldOffset(1556)] public TimerStruct ElapsedTimer;
    [FieldOffset(1568)] public TimerStruct PauseTimer;
    [FieldOffset(1580)] public uint unknown_62C;
    [FieldOffset(1584)] public Bool IsGamePaused;
    [FieldOffset(1586)] public byte waypoints;
    public FixedArray<CellStruct> Waypoints => new(ref Unsafe.As<byte, CellStruct>(ref waypoints), 702);
    [FieldOffset(4396)] public int StartX;
    [FieldOffset(4400)] public int StartY;
    [FieldOffset(4404)] public int Width;
    [FieldOffset(4408)] public int Height;
    [FieldOffset(4412)] public int NumberStartingPoints;
    [FieldOffset(4416)] public byte startingPoints;
    public FixedArray<Point2D> StartingPoints => new(ref Unsafe.As<byte, Point2D>(ref startingPoints), 8);
    [FieldOffset(4480)] public byte houseIndices;
    public FixedArray<int> HouseIndices => new(ref Unsafe.As<byte, int>(ref houseIndices), 16);
    [FieldOffset(4544)] public byte houseHomeCells;
    public FixedArray<CellStruct> HouseHomeCells => new(ref Unsafe.As<byte, CellStruct>(ref houseHomeCells), 8);
    [FieldOffset(4576)] public Bool TeamsPresent;
    [FieldOffset(4580)] public int NumCoopHumanStartSpots;
    [FieldOffset(4584)] public TimerStruct MissionTimer;
    [FieldOffset(4596)] public nint missionTimerTextCSF;
    public UniStringPointer MissionTimerTextCSF => missionTimerTextCSF;
    [FieldOffset(4600)] public byte missionTimerText;
    public AnsiStringPointer MissionTimerText => new(ref Unsafe.As<byte, byte>(ref missionTimerText), 32);
    [FieldOffset(4632)] public TimerStruct ShroudRegrowTimer;
    [FieldOffset(4644)] public TimerStruct FogTimer;
    [FieldOffset(4656)] public TimerStruct IceTimer;
    [FieldOffset(4668)] public TimerStruct unknown_timer_123c;
    [FieldOffset(4680)] public TimerStruct AmbientTimer;
    [FieldOffset(4692)] public int TechLevel;
    [FieldOffset(4696)] public TheaterType Theater;
    [FieldOffset(4700)] public byte fileName;
    public AnsiStringPointer FileName => new(ref Unsafe.As<byte, byte>(ref fileName), 260);
    [FieldOffset(4960)] public byte name;
    public UniStringPointer Name => new(ref Unsafe.As<byte, char>(ref name), 45);
    [FieldOffset(5050)] public byte uIName;
    public AnsiStringPointer UIName => new(ref Unsafe.As<byte, byte>(ref uIName), 32);
    [FieldOffset(5082)] public byte uINameLoaded;
    public UniStringPointer UINameLoaded => new(ref Unsafe.As<byte, char>(ref uINameLoaded), 45);
    [FieldOffset(5172)] public nint intro;
    public AnsiStringPointer Intro => intro;
    [FieldOffset(5176)] public nint brief;
    public AnsiStringPointer Brief => brief;
    [FieldOffset(5180)] public nint win;
    public AnsiStringPointer Win => win;
    [FieldOffset(5184)] public nint lose;
    public AnsiStringPointer Lose => lose;
    [FieldOffset(5188)] public nint action;
    public AnsiStringPointer Action => action;
    [FieldOffset(5192)] public nint postScore;
    public AnsiStringPointer PostScore => postScore;
    [FieldOffset(5196)] public nint preMapSelect;
    public AnsiStringPointer PreMapSelect => preMapSelect;
    [FieldOffset(5200)] public byte briefing;
    public UniStringPointer Briefing => new(ref Unsafe.As<byte, char>(ref briefing), 1024);
    [FieldOffset(7248)] public byte briefingCSF;
    public AnsiStringPointer BriefingCSF => new(ref Unsafe.As<byte, byte>(ref briefingCSF), 32);
    [FieldOffset(7280)] public int ThemeIndex;
    [FieldOffset(7284)] public int HumanPlayerHouseTypeIndex;
    [FieldOffset(7288)] public double CarryOverMoney;
    [FieldOffset(7296)] public int CarryOverCap;
    [FieldOffset(7300)] public int Percent;
    [FieldOffset(7304)] public byte globalVariables;
    public FixedArray<Variable> GlobalVariables => new(ref Unsafe.As<byte, Variable>(ref globalVariables), 50);
    [FieldOffset(9354)] public byte localVariables;
    public FixedArray<Variable> LocalVariables => new(ref Unsafe.As<byte, Variable>(ref localVariables), 100);
    [FieldOffset(13454)] public CellStruct View1;
    [FieldOffset(13458)] public CellStruct View2;
    [FieldOffset(13462)] public CellStruct View3;
    [FieldOffset(13466)] public CellStruct View4;
    [FieldOffset(13472)] public uint unknown_34A0;
    [FieldOffset(13476)] public Bool FreeRadar;
    [FieldOffset(13477)] public Bool TrainCrate;
    [FieldOffset(13478)] public Bool TiberiumGrowthEnabled;
    [FieldOffset(13479)] public Bool VeinGrowthEnabled;
    [FieldOffset(13480)] public Bool IceGrowthEnabled;
    [FieldOffset(13481)] public Bool BridgeDestroyed;
    [FieldOffset(13482)] public Bool VariablesChanged;
    [FieldOffset(13483)] public Bool AmbientChanged;
    [FieldOffset(13484)] public Bool EndOfGame;
    [FieldOffset(13485)] public Bool TimerInherit;
    [FieldOffset(13486)] public Bool SkipScore;
    [FieldOffset(13487)] public Bool OneTimeOnly;
    [FieldOffset(13488)] public Bool SkipMapSelect;
    [FieldOffset(13489)] public Bool TruckCrate;
    [FieldOffset(13490)] public Bool FillSilos;
    [FieldOffset(13491)] public Bool TiberiumDeathToVisceroid;
    [FieldOffset(13492)] public Bool IgnoreGlobalAITriggers;
    [FieldOffset(13493)] public Bool unknown_bool_34B5;
    [FieldOffset(13494)] public Bool unknown_bool_34B6;
    [FieldOffset(13495)] public Bool unknown_bool_34B7;
    [FieldOffset(13496)] public int PlayerSideIndex;
    [FieldOffset(13500)] public Bool MultiplayerOnly;
    [FieldOffset(13501)] public Bool IsRandom;
    [FieldOffset(13502)] public Bool PickedUpAnyCrate;
    [FieldOffset(13504)] public TimerStruct unknown_timer_34C0;
    [FieldOffset(13516)] public int CampaignIndex;
    [FieldOffset(13520)] public int StartingDropships;
    [FieldOffset(13524)] public byte allowableUnits;

    public ref TypeList<Pointer<TechnoTypeClass>> AllowableUnits => ref Pointer<byte>.AsPointer(ref allowableUnits)
        .Convert<TypeList<Pointer<TechnoTypeClass>>>().Ref;

    [FieldOffset(13552)] public byte allowableUnitMaximums;

    public ref TypeList<int> AllowableUnitMaximums =>
        ref Pointer<byte>.AsPointer(ref allowableUnitMaximums).Convert<TypeList<int>>().Ref;

    [FieldOffset(13580)] public byte dropshipUnitCounts;

    public ref TypeList<int> DropshipUnitCounts =>
        ref Pointer<byte>.AsPointer(ref dropshipUnitCounts).Convert<TypeList<int>>().Ref;

    [FieldOffset(13608)] public int AmbientOriginal;
    [FieldOffset(13612)] public int AmbientCurrent;
    [FieldOffset(13616)] public int AmbientTarget;
    [FieldOffset(13620)] public LightingStruct NormalLighting;
    [FieldOffset(13640)] public int IonAmbient;
    [FieldOffset(13644)] public LightingStruct IonLighting;
    [FieldOffset(13664)] public int NukeAmbient;
    [FieldOffset(13668)] public LightingStruct NukeLighting;
    [FieldOffset(13688)] public int NukeAmbientChangeRate;
    [FieldOffset(13692)] public int DominatorAmbient;
    [FieldOffset(13696)] public LightingStruct DominatorLighting;
    [FieldOffset(13716)] public int DominatorAmbientChangeRate;
    [FieldOffset(13720)] public uint unknown_3598;
    [FieldOffset(13724)] public int InitTime;
    [FieldOffset(13728)] public short Stage;
    [FieldOffset(13730)] public Bool UserInputLocked;
    [FieldOffset(13731)] public Bool unknown_35A3;
    [FieldOffset(13732)] public int ParTimeEasy;
    [FieldOffset(13736)] public int ParTimeMedium;
    [FieldOffset(13740)] public int ParTimeDifficult;
    [FieldOffset(13744)] public byte underParTitle;
    public AnsiStringPointer UnderParTitle => new(ref Unsafe.As<byte, byte>(ref underParTitle), 31);
    [FieldOffset(13775)] public byte underParMessage;
    public AnsiStringPointer UnderParMessage => new(ref Unsafe.As<byte, byte>(ref underParMessage), 31);
    [FieldOffset(13806)] public byte overParTitle;
    public AnsiStringPointer OverParTitle => new(ref Unsafe.As<byte, byte>(ref overParTitle), 31);
    [FieldOffset(13837)] public byte overParMessage;
    public AnsiStringPointer OverParMessage => new(ref Unsafe.As<byte, byte>(ref overParMessage), 31);
    [FieldOffset(13868)] public byte lSLoadMessage;
    public AnsiStringPointer LSLoadMessage => new(ref Unsafe.As<byte, byte>(ref lSLoadMessage), 31);
    [FieldOffset(13899)] public byte lSBrief;
    public AnsiStringPointer LSBrief => new(ref Unsafe.As<byte, byte>(ref lSBrief), 31);
    [FieldOffset(13932)] public int LS640BriefLocX;
    [FieldOffset(13936)] public int LS640BriefLocY;
    [FieldOffset(13940)] public int LS800BriefLocX;
    [FieldOffset(13944)] public int LS800BriefLocY;
    [FieldOffset(13948)] public byte lS640BkgdName;
    public AnsiStringPointer LS640BkgdName => new(ref Unsafe.As<byte, byte>(ref lS640BkgdName), 64);
    [FieldOffset(14012)] public byte lS800BkgdName;
    public AnsiStringPointer LS800BkgdName => new(ref Unsafe.As<byte, byte>(ref lS800BkgdName), 64);
    [FieldOffset(14076)] public byte lS800BkgdPal;
    public AnsiStringPointer LS800BkgdPal => new(ref Unsafe.As<byte, byte>(ref lS800BkgdPal), 64);
}

[StructLayout(LayoutKind.Explicit, Size = 41)]
public struct Variable
{
    [FieldOffset(0)] public byte Name_first;
    public AnsiStringPointer Name => Pointer<byte>.AsPointer(ref Name_first);
    [FieldOffset(40)] public byte Value;
}

[StructLayout(LayoutKind.Explicit)]
public struct LightingStruct
{
    [FieldOffset(0)] public TintStruct Tint;
    [FieldOffset(12)] public int Ground;
    [FieldOffset(16)] public int Level;
}

[Flags]
public enum ScenarioFlags : uint
{
    bit00 = 1,
    bit01 = 2,
    bit02 = 4,
    bit03 = 8,
    CTFMode = 16,
    Inert = 32,
    TiberiumGrows = 64,
    TiberiumSpreads = 128,
    MCVDeploy = 256,
    InitialVeteran = 512,
    FixedAlliance = 1024,
    HarvesterImmune = 2048,
    FogOfWar = 4096,
    bit13 = 8192,
    TiberiumExplosive = 16384,
    DestroyableBridges = 32768,
    Meteorites = 65536,
    IonStorms = 131072,
    Visceroids = 262144,
    bit19 = 524288,
    bit20 = 1048576,
    bit21 = 2097152,
    bit22 = 4194304,
    bit23 = 8388608,
    bit24 = 16777216,
    bit25 = 33554432,
    bit26 = 67108864,
    bit27 = 134217728,
    bit28 = 268435456,
    bit29 = 536870912,
    bit30 = 1073741824,
    bit31 = 2147483648
}