namespace PatcherYrSharp.GeneralDefinitions;

[Flags]
public enum AbstractFlags
{
    None = 0x0,
    Techno = 0x1,
    Object = 0x2,
    Foot = 0x4
};

public enum Armor
{
    None = 0,
    Flak = 1,
    Plate = 2,
    Light = 3,
    Medium = 4,
    Heavy = 5,
    Wood = 6,
    Steel = 7,
    Concrete = 8,
    Special1 = 9,
    Special2 = 10
};

public enum Ability
{
    Faster = 0,
    Stronger = 1,
    Firepower = 2,
    Scatter = 3,
    Rof = 4,
    Sight = 5,
    Cloak = 6,
    TiberiumProof = 7,
    VeinProof = 8,
    SelfHeal = 9,
    Explodes = 10,
    RadarInvisible = 11,
    Sensors = 12,
    Fearless = 13,
    C4 = 14,
    TiberiumHeal = 15,
    GuardArea = 16,
    Crusher = 17
}

public enum CloakStates
{
    UnCloaked = 0x0,
    Cloaking = 0x1,
    Cloaked = 0x2,
    UnCloaking = 0x3
}

public enum AbstractType
{
    None = 0,
    Unit = 1,
    Aircraft = 2,
    AircraftType = 3,
    Anim = 4,
    AnimType = 5,
    Building = 6,
    BuildingType = 7,
    Bullet = 8,
    BulletType = 9,
    Campaign = 10,
    Cell = 11,
    Factory = 12,
    House = 13,
    HouseType = 14,
    Infantry = 15,
    InfantryType = 16,
    Isotile = 17,
    IsotileType = 18,
    BuildingLight = 19,
    Overlay = 20,
    OverlayType = 21,
    Particle = 22,
    ParticleType = 23,
    ParticleSystem = 24,
    ParticleSystemType = 25,
    Script = 26,
    ScriptType = 27,
    Side = 28,
    Smudge = 29,
    SmudgeType = 30,
    Special = 31,
    SuperWeaponType = 32,
    TaskForce = 33,
    Team = 34,
    TeamType = 35,
    Terrain = 36,
    TerrainType = 37,
    Trigger = 38,
    TriggerType = 39,
    UnitType = 40,
    VoxelAnim = 41,
    VoxelAnimType = 42,
    Wave = 43,
    Tag = 44,
    TagType = 45,
    Tiberium = 46,
    Action = 47,
    Event = 48,
    WeaponType = 49,
    WarheadType = 50,
    Waypoint = 51,
    Abstract = 52,
    Tube = 53,
    LightSource = 54,
    EmPulse = 55,
    TacticalMap = 56,
    Super = 57,
    AiTrigger = 58,
    AiTriggerType = 59,
    Neuron = 60,
    FoggedObject = 61,
    AlphaShape = 62,
    VeinholeMonster = 63,
    NavyType = 64,
    SpawnManager = 65,
    CaptureManager = 66,
    Parasite = 67,
    Bomb = 68,
    RadSite = 69,
    Temporal = 70,
    Airstrike = 71,
    SlaveManager = 72,
    DiskLaser = 73
};

public enum BuildCat : uint
{
    DontCare = 0,
    Tech = 1,
    Resoure = 2,
    Power = 3,
    Infrastructure = 4,
    Combat = 5
}

public enum CcAction : uint
{
    None = 0,
    Move = 1,
    NoMove = 2,
    Enter = 3,
    SelfDeploy = 4,
    Attack = 5,
    Harvest = 6,
    Select = 7,
    ToggleSelect = 8,
    Capture = 9,
    Eaten = 10,
    Repair = 11,
    Sell = 12,
    SellUnit = 13,
    NoSell = 14,
    NoRepair = 15,
    Sabotage = 16,
    Tote = 17,
    DontUse2 = 18,
    DontUse3 = 19,
    Nuke = 20,
    DontUse4 = 21,
    DontUse5 = 22,
    DontUse6 = 23,
    DontUse7 = 24,
    DontUse8 = 25,
    GuardArea = 26,
    Heal = 27,
    Damage = 28,
    GRepair = 29,
    NoDeploy = 30,
    NoEnter = 31,
    NoGRepair = 32,
    TogglePower = 33,
    NoTogglePower = 34,
    EnterTunnel = 35,
    NoEnterTunnel = 36,
    IronCurtain = 37,
    LightningStorm = 38,
    ChronoSphere = 39,
    ChronoWarp = 40,
    ParaDrop = 41,
    PlaceWaypoint = 42,
    TibSunBug = 43,
    EnterWaypointMode = 44,
    FollowWaypoint = 45,
    SelectWaypoint = 46,
    LoopWaypointPath = 47,
    DragWaypoint = 48,
    AttackWaypoint = 49,
    EnterWaypoint = 50,
    PatrolWaypoint = 51,
    AreaAttack = 52,
    IvanBomb = 53,
    NoIvanBomb = 54,
    Detonate = 55,
    DetonateAll = 56,
    DisarmBomb = 57,
    SelectNode = 58,
    AttackSupport = 59,
    PlaceBeacon = 60,
    SelectBeacon = 61,
    AttackMoveNav = 62,
    AttackMoveTar = 63,
    Demolish = 64,
    AmerParaDrop = 65,
    PsychicDominator = 66,
    SpyPlane = 67,
    GeneticConverter = 68,
    ForceShield = 69,
    NoForceShield = 70,
    Airstrike = 71,
    PsychicReveal = 72
};

public enum DamageState
{
    Unaffected = 0,
    Unchanged = 1,
    NowYellow = 2,
    NowRed = 3,
    NowDead = 4,
    PostMortem = 5
};

public enum DamageAreaResult
{
    Hit = 0,
    Missed = 1,
    Nullified = 2
};

public enum KickOutResult
{
    Failed = 0,
    Busy = 1,
    Succeeded = 2
};

public enum Direction
{
    N = 0x0,
    North = 0x0,
    Ne = 0x1,
    NorthEast = 0x1,
    E = 0x2,
    East = 0x2,
    Se = 0x3,
    SouthEast = 0x3,
    S = 0x4,
    South = 0x4,
    Sw = 0x5,
    SouthWest = 0x5,
    W = 0x6,
    West = 0x6,
    Nw = 0x7,
    NorthWest = 0x7,
};

[Flags]
public enum WwKey
{
    Shift = 0x100,
    Ctrl = 0x200,
    Alt = 0x400,
    Release = 0x800,
    VirtualKey = 0x1000,
    DoubleClick = 0x2000,
    Button = 0x8000
}

public enum SpotlightFlags
{
    None = 0x0,
    NoColor = 0x1,
    NoRed = 0x2,
    NoGreen = 0x4,
    NoBlue = 0x8
};

public enum LandType
{
    Clear = 0,
    Road = 1,
    Water = 2,
    Rock = 3,
    Wall = 4,
    Tiberium = 5,
    Beach = 6,
    Rough = 7,
    Ice = 8,
    Railroad = 9,
    Tunnel = 10,
    Weeds = 11
};

public enum Layer
{
    None = -1,
    Underground = 0,
    Surface = 1,
    Ground = 2,
    Air = 3,
    Top = 4
};

public enum PlacementType
{
    Remove = 0,
    Put = 1,
    Redraw = 2,
    AddContent = 3
};

public enum ChargeDrainState
{
    None = -1,
    Charging = 0,
    Ready = 1,
    Draining = 2
};

[Flags]
public enum TextPrintType
{
    Lastpoint = 0, //*
    Lastshadow = 0, //*
    Point6 = 0x1, //*
    Point8 = 0x2,
    Point3 = 0x3, //*
    Led = 0x4, //*
    Vcr = 0x5, //*
    Point6Grad = 0x6,
    Map = 0x7, //*
    Metal12 = 0x8,
    Efnt = 0x9, //*
    Type = 0xA, //*
    Score = 0xB, //*
    Fonts = 0xF, //*
    NoShadow = 0x10,
    DropShadow = 0x20,
    FullShadow = 0x40,
    LightShadow = 0x80,
    Center = 0x100,
    Right = 0x200,
    Background = 0x400,
    MediumColor = 0x1000,
    BrightColor = 0x2000,
    UseGradPal = 0x4000,
    UnknownColor = 0x8000,
    GradAll = 0xF000,
}

public enum SuperWeaponType
{
    Invalid = -1,
    Nuke = 0,
    IronCurtain = 1,
    LightningStorm = 2,
    ChronoSphere = 3,
    ChronoWarp = 4,
    ParaDrop = 5,
    AmerParaDrop = 6,
    PsychicDominator = 7,
    SpyPlane = 8,
    GeneticMutator = 9,
    ForceShield = 10,
    PsychicReveal = 11
};

[Flags]
public enum BlitterFlags
{
    None = 0x0,
    Darken = 0x1,
    TransLucent25 = 0x2,
    TransLucent50 = 0x4,
    TransLucent75 = 0x6,
    Warp = 0x8,
    ZRemap = 0x10,
    Plain = 0x20,
    Bf040 = 0x40,
    Bf080 = 0x80,
    MultiPass = 0x100,
    Centered = 0x200,
    Bf400 = 0x400,
    Alpha = 0x800,
    Bf1000 = 0x1000,
    Flat = 0x2000,
    ZRead = 0x3000,
    ZReadWrite = 0x4000,
    Bf8000 = 0x8000,
    Zero = 0x10000,
    Nonzero = 0x20000
};

public enum VisualType
{
    Normal = 0,
    Indistinct = 1,
    Darken = 2,
    Shadowy = 3,
    Ripple = 4,
    Hidden = 5
};

public enum Move
{
    Ok = 0,
    Cloak = 1,
    MovingBlock = 2,
    ClosedGate = 3,
    FriendlyDestroyable = 4,
    Destroyable = 5,
    Temp = 6,
    No = 7
};

public enum ZGradient
{
    None = -1,
    Ground = 0,
    Deg45 = 1,
    Deg90 = 2,
    Deg135 = 3
};

// this is how game's enums are to be defined from now on
public enum FireError
{
    None = -1, // no valid value
    Ok = 0, // no problem, can fire
    Ammo = 1, // no ammo
    Facing = 2, // bad facing
    Rearm = 3, // still reloading
    Rotating = 4, // busy rotating
    Illegal = 5, // can't fire
    Cant = 6, // I'm sorry Dave, I can't do that
    Moving = 7, // moving, can't fire
    Range = 8, // out of range
    Cloaked = 9, // need to decloak
    Busy = 10, // busy, please hold
    MustDeploy = 11 // deploy first!
};

public enum Rank
{
    Invalid = -1,
    Elite = 0,
    Veteran = 1,
    Rookie = 2
};

public enum SpeedType
{
    None = -1,
    Foot = 0,
    Track = 1,
    Wheel = 2,
    Hover = 3,
    Winged = 4,
    Float = 5,
    Amphibious = 6,
    FloatBeach = 7
};

public enum MovementZone
{
    None = -1,
    Normal = 0,
    Crusher = 1,
    Destroyer = 2,
    AmphibiousDestroyer = 3,
    AmphibiousCrusher = 4,
    Amphibious = 5,
    Subterrannean = 6,
    Infantry = 7,
    InfantryDestroyer = 8,
    Fly = 9,
    Water = 10,
    WaterBeach = 11,
    CrusherAll = 12
};

public enum SequenceAnimType
{
    StandReady = 0,
    StandGuard = 1,
    Prone = 2,
    Walk = 3,
    FireWeapon = 4,
    LieDown = 5,
    Crawl = 6,
    GetUp = 7,
    FireProne = 8,
    Idle1 = 9,
    Idle2 = 10,
    GunDeath = 11,
    ExplosionDeath = 12,
    Explosion2Death = 13,
    GrenadeDeath = 14,
    FireDeath = 15,
    Tread = 16,
    Swim = 17,
    WetIdle1 = 18,
    WetIdle2 = 19,
    WetDie1 = 20,
    WetDie2 = 21,
    WetAttack = 22,
    Hover = 23,
    Fly = 24,
    Tumble = 25,
    FireFly = 26,
    Deploy = 27,
    Deployed = 28,
    DeployedFire = 29,
    DeployedIdle = 30,
    Undeploy = 31,
    Cheer = 32,
    Paradrop = 33,
    AirDeathStart = 34,
    AirDeathFalling = 35,
    AirDeathFinish = 36,
    Panic = 37,
    Shovel = 38,
    Carry = 39,
    SecondaryFire = 40,
    SecondaryProne = 41,
    Nothing = -1
}

public enum Mission
{
    None = -1,
    Sleep = 0,
    Attack = 1,
    Move = 2,
    QMove = 3,
    Retreat = 4,
    Guard = 5,
    Sticky = 6,
    Enter = 7,
    Capture = 8,
    Eaten = 9,
    Harvest = 10,
    AreaGuard = 11,
    Return = 12,
    Stop = 13,
    Ambush = 14,
    Hunt = 15,
    Unload = 16,
    Sabotage = 17,
    Construction = 18,
    Selling = 19,
    Repair = 20,
    Rescue = 21,
    Missile = 22,
    Harmless = 23,
    Open = 24,
    Patrol = 25,
    ParadropApproach = 26,
    ParadropOverfly = 27,
    Wait = 28,
    AttackMove = 29,
    SpyplaneApproach = 30,
    SpyplaneOverfly = 31
};

[Flags]
public enum TargetFlags
{
    None = 0x0,
    Unknown1 = 0x1,
    Unknown2 = 0x2,
    Air = 0x4,
    Infantry = 0x8,
    Vehicles = 0x10,
    Buildings = 0x20,
    Economy = 0x40,
    Ships = 0x80, // from RA1
    Neutral = 0x100, // from RA1
    Capture = 0x200,
    Fakes = 0x400, // from RA1
    Power = 0x800,
    Factories = 0x1000,
    BaseDefense = 0x2000,
    Friendlies = 0x4000,
    Occupiable = 0x8000,
    TechCapture = 0x10000
};

public enum RadioCommand
{
    AnswerInvalid = 0, // static (no message)
    AnswerPositive = 1, // Roger.
    RequestLink = 2, // Come in.
    NotifyUnlink = 3, // Over and out.
    RequestPickUp = 4, // "Please pick me up."
    RequestAttach = 5, // "Attach to transport."
    RequestDelivery = 6, // "I've got a delivery for you."
    NotifyBeginLoad = 7, // I'm performing load/unload maneuver. Be careful.
    NotifyUnloaded = 8, // I'm clear.
    RequestUnload = 9, // You are clear to unload. Driving away now.
    AnswerNegative = 10, // Am unable to comply.
    RequestBeginProduction = 11, // I'm starting construction now... act busy.
    RequestEndProduction = 12, // I've finished construction. You are free.
    RequestRedraw = 13, // We bumped, redraw yourself please.
    RequestLoading = 14, // I'm trying to load up now.
    AnswerLoading = 14, // Loading up now.
    QueryCanEnter = 15, // May I become a passenger?
    QueryCanUnload = 16, // Are you ready to receive shipment?
    QueryWantEnter = 17, // Are you trying to become a passenger?
    RequestMoveTo = 18, // Move to location X.
    QueryMoving = 19, // Do you need to move?
    AnswerAwaiting = 20, // All right already. Now what?
    RequestCompleteEnter = 21, // I'm a passenger now.
    RequestDockRefinery = 22, // Backup into refinery now.
    AnswerLeave = 23, // Run away!
    NotifyLeave = 23, // Running away.
    RequestTether = 24, // Tether established.
    RequestUntether = 25, // Tether broken.
    RequestAlternativeTether = 26, // Alternative tether established.
    RequestAlternativeUntether = 27, // Alternative tether broken.
    RequestRepair = 28, // Repair one step.
    QueryReadiness = 29, // Are you prepared to fight?
    RequestAttack = 30, // Attack this target please.
    RequestReload = 31, // Reload one step.
    AnswerBlocked = 32, // Circumstances prevent success.
    QueryDone = 33, // All done with the request?
    AnswerDone = 33, // All done with the request.
    QueryNeedRepair = 34, // Do you need service depot work?
    QueryOnBuilding = 35, // Are you located on top of me?
    QueryCanTote = 36, // Want ride
};

public enum NetworkEvents
{
    Empty = 0x0,
    PowerOn = 0x1,
    PowerOff = 0x2,
    Ally = 0x3,
    MegaMission = 0x4,
    MegaMissionF = 0x5,
    Idle = 0x6,
    Scatter = 0x7,
    Destruct = 0x8,
    Deploy = 0x9,
    Detonate = 0xA,
    Place = 0xB,
    Options = 0xC,
    GameSpeed = 0xD,
    Produce = 0xE,
    Suspend = 0xF,
    Abandon = 0x10,
    Primary = 0x11,
    SpecialPlace = 0x12,
    Exit = 0x13,
    Animation = 0x14,
    Repair = 0x15,
    Sell = 0x16,
    SellCell = 0x17,
    Special = 0x18,
    FrameSync = 0x19,
    Message = 0x1A,
    ResponseTime = 0x1B,
    FrameInfo = 0x1C,
    SaveGame = 0x1D,
    Archive = 0x1E,
    AddPlayer = 0x1F,
    Timing = 0x20,
    ProcessTime = 0x21,
    PageUser = 0x22,
    RemovePlayer = 0x23,
    LatencyFudge = 0x24,
    MegaFrameInfo = 0x25,
    PacketTiming = 0x26,
    AboutToExit = 0x27,
    FallbackHost = 0x28,
    AddressChange = 0x29,
    PlanConnect = 0x2A,
    PlanCommit = 0x2B,
    PlanNodeDelete = 0x2C,
    AllCheer = 0x2D,
    AbandonAll = 0x2E
};

public enum Edge
{
    None = -1,
    North = 0,
    East = 1,
    South = 2,
    West = 3,
    Air = 4
};

public enum GameMode
{
    Campaign = 0x0,
    Modem = 0x1, // modem game
    NullModem = 0x2, // NULL-modem
    Lan = 0x3,
    Internet = 0x4,
    Skirmish = 0x5,
};

public enum MarkType
{
    Up = 0,
    Down = 1,
    Change = 2,
    ChangeRedraw = 3,
    OverlapDown = 4,
    OverlapUp = 5
}

public enum TriggerEvent : uint
{
    None = 0x0,
    EnteredBy = 0x1,
    SpiedBy = 0x2,
    ThievedBy = 0x3,
    DiscoveredByPlayer = 0x4,
    HouseDiscovered = 0x5,
    AttackedByAnybody = 0x6,
    DestroyedByAnybody = 0x7,
    AnyEvent = 0x8,
    DestroyedUnitsAll = 0x9,
    DestroyedBuildingsAll = 0xA,
    DestroyedAll = 0xB,
    CreditsExceed = 0xC,
    ElapsedTime = 0xD,
    MissionTimerExpired = 0xE,
    DestroyedBuildingsNum = 0xF,
    DestroyedUnitsNum = 0x10,
    NoFactoriesLeft = 0x11,
    CiviliansEvacuated = 0x12,
    BuildBuildingType = 0x13,
    BuildUnitType = 0x14,
    BuildInfantryType = 0x15,
    BuildAircraftType = 0x16,
    TeamLeavesMap = 0x17,
    ZoneEntryBy = 0x18,
    CrossesHorizontalLine = 0x19,
    CrossesVerticalLine = 0x1A,
    GlobalSet = 0x1B,
    GlobalCleared = 0x1C,
    DestroyedFakesAll = 0x1D,
    LowPower = 0x1E,
    AllBridgesDestroyed = 0x1F,
    BuildingExists = 0x20,
    SelectedByPlayer = 0x21,
    ComesNearWaypoint = 0x22,
    EnemyInSpotlight = 0x23,
    LocalSet = 0x24,
    LocalCleared = 0x25,
    FirstDamagedCombatonly = 0x26,
    HalfHealthCombatonly = 0x27,
    QuarterHealthCombatonly = 0x28,
    FirstDamagedAnysource = 0x29,
    HalfHealthAnysource = 0x2A,
    QuarterHealthAnysource = 0x2B,
    AttackedByHouse = 0x2C,
    AmbientLightBelow = 0x2D,
    AmbientLightAbove = 0x2E,
    ElapsedScenarioTime = 0x2F,
    DestroyedByAnything = 0x30,
    PickupCrate = 0x31,
    PickupCrateAny = 0x32,
    RandomDelay = 0x33,
    CreditsBelow = 0x34,
    SpyAsHouse = 0x35,
    SpyAsInfantry = 0x36,
    DestroyedUnitsNaval = 0x37,
    DestroyedUnitsLand = 0x38,
    BuildingDoesNotExist = 0x39,
    PowerFull = 0x3A,
    EnteredOrOverflownBy = 0x3B,
    TechTypeExists = 0x3C,
    TechTypeDoesntExist = 0x3D
}

public enum TriggerAction : uint
{
    None = 0x0,
    Win = 0x1,
    Lose = 0x2,
    ProductionBegins = 0x3,
    CreateTeam = 0x4,
    DestroyTeam = 0x5,
    AllToHunt = 0x6,
    Reinforcement = 0x7,
    DropZoneFlare = 0x8,
    FireSale = 0x9,
    PlayMovie = 0xA,
    TextTrigger = 0xB,
    DestroyTrigger = 0xC,
    AutocreateBegins = 0xD,
    ChangeHouse = 0xE,
    AllowWin = 0xF,
    RevealAllMap = 0x10,
    RevealAroundWaypoint = 0x11,
    RevealWaypointZone = 0x12,
    PlaySoundEffect = 0x13,
    PlayMusicTheme = 0x14,
    PlaySpeech = 0x15,
    ForceTrigger = 0x16,
    TimerStart = 0x17,
    TimerStop = 0x18,
    TimerExtend = 0x19,
    TimerShorten = 0x1A,
    TimerSet = 0x1B,
    GlobalSet = 0x1C,
    GlobalClear = 0x1D,
    AutoBaseBuilding = 0x1E,
    GrowShroud = 0x1F,
    DestroyAttachedObject = 0x20,
    AddOneTimeSuperWeapon = 0x21,
    AddRepeatingSuperWeapon = 0x22,
    PreferredTarget = 0x23,
    AllChangeHouse = 0x24,
    MakeAlly = 0x25,
    MakeEnemy = 0x26,
    ChangeZoomLevel = 0x27,
    ResizePlayerView = 0x28,
    PlayAnimAt = 0x29,
    DoExplosionAt = 0x2A,
    CreateVoxelAnim = 0x2B,
    IonStormStart = 0x2C,
    IonStormStop = 0x2D,
    LockInput = 0x2E,
    UnlockInput = 0x2F,
    MoveCameraToWaypoint = 0x30,
    ZoomIn = 0x31,
    ZoomOut = 0x32,
    ReshroudMap = 0x33,
    ChangeLightBehavior = 0x34,
    EnableTrigger = 0x35,
    DisableTrigger = 0x36,
    CreateRadarEvent = 0x37,
    LocalSet = 0x38,
    LocalClear = 0x39,
    MeteorShower = 0x3A,
    ReduceTiberium = 0x3B,
    SellBuilding = 0x3C,
    TurnOffBuilding = 0x3D,
    TurnOnBuilding = 0x3E,
    Apply100Damage = 0x3F,
    SmallLightFlash = 0x40,
    MediumLightFlash = 0x41,
    LargeLightFlash = 0x42,
    AnnounceWin = 0x43,
    AnnounceLose = 0x44,
    ForceEnd = 0x45,
    DestroyTag = 0x46,
    SetAmbientStep = 0x47,
    SetAmbientRate = 0x48,
    SetAmbientLight = 0x49,
    AiTriggersBegin = 0x4A,
    AiTriggersStop = 0x4B,
    RatioOfAiTriggerTeams = 0x4C,
    RatioOfTeamAircraft = 0x4D,
    RatioOfTeamInfantry = 0x4E,
    RatioOfTeamUnits = 0x4F,
    ReinforcementAt = 0x50,
    WakeupSelf = 0x51,
    WakeupAllSleepers = 0x52,
    WakeupAllHarmless = 0x53,
    WakeupGroup = 0x54,
    VeinGrowth = 0x55,
    TiberiumGrowth = 0x56,
    IceGrowth = 0x57,
    ParticleAnim = 0x58,
    RemoveParticleAnim = 0x59,
    LightningStrike = 0x5A,
    GoBerzerk = 0x5B,
    ActivateFirestorm = 0x5C,
    DeactivateFirestorm = 0x5D,
    IonCannonStrike = 0x5E,
    NukeStrike = 0x5F,
    ChemMissileStrike = 0x60,
    ToggleTrainCargo = 0x61,
    PlaySoundEffectRandom = 0x62,
    PlaySoundEffectAtWaypoint = 0x63,
    PlayIngameMovie = 0x64,
    ReshroudMapAtWaypoint = 0x65,
    LightningStormStrike = 0x66,
    TimerText = 0x67,
    FlashTeam = 0x68,
    TalkBubble = 0x69,
    SetObjectTechLevel = 0x6A,
    ReinforcementByChrono = 0x6B,
    CreateCrate = 0x6C,
    IronCurtain = 0x6D,
    PauseGame = 0x6E,
    EvictOccupiers = 0x6F,
    CenterCameraAtWaypoint = 0x70,
    MakeHouseCheer = 0x71,
    SetTabTo = 0x72,
    FlashCameo = 0x73,
    StopSounds = 0x74,
    PlayIngameMovieAndPause = 0x75,
    ClearAllSmudges = 0x76,
    DestroyAll = 0x77,
    DestroyAllBuildings = 0x78,
    DestroyAllLandUnits = 0x79,
    DestroyAllNavalUnits = 0x7A,
    MindControlBase = 0x7B,
    RestoreMindControlledBase = 0x7C,
    CreateBuilding = 0x7D,
    RestoreStartingUnits = 0x7E,
    StartChronoScreenEffect = 0x7F,
    TeleportAll = 0x80,
    SetSuperWeaponCharge = 0x81,
    RestoreStartingBuildings = 0x82,
    FlashBuildingsOfType = 0x83,
    SuperWeaponSetRechargeTime = 0x84,
    SuperWeaponResetRechargeTime = 0x85,
    SuperWeaponReset = 0x86,
    SetPreferredTargetCell = 0x87,
    ClearPreferredTargetCell = 0x88,
    SetBaseCenterCell = 0x89,
    ClearBaseCenterCell = 0x8A,
    BlackoutRadar = 0x8B,
    SetDefensiveTargetCell = 0x8C,
    ClearDefensiveTargetCell = 0x8D,
    RetintRed = 0x8E,
    RetintGreen = 0x8F,
    RetintBlue = 0x90,
    JumpCameraHome = 0x91
}

public enum VoxType : int
{
    Standard = 0,
    Queue = 1,
    Interrupt = 2,
    QueuedInterrupt = 3
}

public enum VoxPriority : int
{
    Low = 0,
    Normal = 1,
    Important = 2,
    Critical = 3
}