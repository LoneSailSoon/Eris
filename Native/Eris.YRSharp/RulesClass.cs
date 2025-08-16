using System.Runtime.CompilerServices;
using Eris.YRSharp.FileFormats;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 6336)]
public struct RulesClass
{
    private const nint ppInstance = 0x8871E0;

    public static ref RulesClass Instance => ref ppInstance.Convert<Pointer<RulesClass>>().Ref.Ref;


    // call this instead of Init for the later files (gamemode, map)
    // reads the generic/list sections like [VehicleTypes] from pINI
    // doesn't actually load [MTNK] or other list contents' sections
    public unsafe void Init(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x6686C0;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_File(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x668BF0;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_SpecialWeapons(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x668FB0;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_AudioVisual(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x6691E0;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_CrateRules(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x66B900;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_CombatDamage(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x66BBB0;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_Radiation(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x66CF70;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_ElevationModel(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x66D150;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_WallModel(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x66D1F0;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_Difficulty(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x66D270;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_Colors(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x66D3A0;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_ColorAdd(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x66D480;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_General(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x66D530;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_MultiplayerDialogSettings(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x671EA0;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_Maximums(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x672230;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_InfantryTypes(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x672280;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_Countries(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x6722F0;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_VehicleTypes(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x672360;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_AircraftTypes(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x6723D0;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_Sides(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x672440;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_SuperWeaponTypes(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x6725F0;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_BuildingTypes(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x672660;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_TerrainTypes(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x6726D0;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_Teams_obsolete(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x672740;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_SmudgeTypes(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x6727D0;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_OverlayTypes(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x672840;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_Animations(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x6728B0;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_VoxelAnims(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x672920;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_Warheads(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x672990;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_Particles(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x672A00;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_ParticleSystems(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x672A70;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_AI(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x672AE0;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_Powerups(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x673E80;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_LandCharacteristics(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x674000;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_IQ(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x674240;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_JumpjetControls(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x6743D0;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_Difficulties(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x674500;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_Movies(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x674550;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void Read_AdvancedCommandBar(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x674650;
        func(this.GetThisPointer(), pINI);
    }

    public unsafe void PointerGotInvalid(Pointer<AbstractClass> pInvalid, bool removed)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, void>)0x678850;
        func(this.GetThisPointer(), pInvalid, removed);
    }


    [FieldOffset(0)] public int DetailMinFrameRateNormal;
    [FieldOffset(4)] public int DetailMinFrameRateMovie;
    [FieldOffset(8)] public int DetailBufferZoneWidth;
    [FieldOffset(12)] public int AmmoCrateDamage;
    [FieldOffset(16)] public nint largeVisceroid;
    public Pointer<UnitTypeClass> LargeVisceroid => largeVisceroid;
    [FieldOffset(20)] public nint smallVisceroid;
    public Pointer<UnitTypeClass> SmallVisceroid => smallVisceroid;
    [FieldOffset(24)] public int AttackingAircraftSightRange;
    [FieldOffset(32)] public double TunnelSpeed;
    [FieldOffset(40)] public double TiberiumHeal;
    [FieldOffset(48)] public int SelfHealInfantryFrames;
    [FieldOffset(52)] public int SelfHealInfantryAmount;
    [FieldOffset(56)] public int SelfHealUnitFrames;
    [FieldOffset(60)] public int SelfHealUnitAmount;
    [FieldOffset(64)] public Bool FreeMCV;
    [FieldOffset(65)] public Bool BerzerkAllowed;
    [FieldOffset(68)] public int PoseDir;
    [FieldOffset(72)] public int DeployDir;
    [FieldOffset(76)] public nint dropPodPuff;
    public Pointer<AnimTypeClass> DropPodPuff => dropPodPuff;
    [FieldOffset(80)] public int WaypointAnimationSpeed;
    [FieldOffset(84)] public nint barrelExplode;
    public Pointer<AnimTypeClass> BarrelExplode => barrelExplode;
    [FieldOffset(88)] public byte barrelDebris;

    public ref TypeList<Pointer<VoxelAnimTypeClass>> BarrelDebris => ref Pointer<byte>.AsPointer(ref barrelDebris)
        .Convert<TypeList<Pointer<VoxelAnimTypeClass>>>().Ref;

    [FieldOffset(116)] public nint barrelParticle;
    public Pointer<ParticleSystemTypeClass> BarrelParticle => barrelParticle;
    [FieldOffset(120)] public float RadarEventColorSpeed;
    [FieldOffset(124)] public int RadarEventMinRadius;
    [FieldOffset(128)] public float RadarEventSpeed;
    [FieldOffset(132)] public float RadarEventRotationSpeed;
    [FieldOffset(136)] public int FlashFrameTime;
    [FieldOffset(140)] public int RadarCombatFlashTime;
    [FieldOffset(144)] public int MaxWaypointPathLength;
    [FieldOffset(148)] public nint wake;
    public Pointer<AnimTypeClass> Wake => wake;
    [FieldOffset(152)] public nint nukeTakeOff;
    public Pointer<AnimTypeClass> NukeTakeOff => nukeTakeOff;
    [FieldOffset(156)] public nint infantryExplode;
    public Pointer<AnimTypeClass> InfantryExplode => infantryExplode;
    [FieldOffset(160)] public nint flamingInfantry;
    public Pointer<AnimTypeClass> FlamingInfantry => flamingInfantry;
    [FieldOffset(164)] public nint infantryHeadPop;
    public Pointer<AnimTypeClass> InfantryHeadPop => infantryHeadPop;
    [FieldOffset(168)] public nint infantryNuked;
    public Pointer<AnimTypeClass> InfantryNuked => infantryNuked;
    [FieldOffset(172)] public nint infantryVirus;
    public Pointer<AnimTypeClass> InfantryVirus => infantryVirus;
    [FieldOffset(176)] public nint infantryBrute;
    public Pointer<AnimTypeClass> InfantryBrute => infantryBrute;
    [FieldOffset(180)] public nint infantryMutate;
    public Pointer<AnimTypeClass> InfantryMutate => infantryMutate;
    [FieldOffset(184)] public nint behind;
    public Pointer<AnimTypeClass> Behind => behind;
    [FieldOffset(192)] public double AITriggerSuccessWeightDelta;
    [FieldOffset(200)] public double AITriggerFailureWeightDelta;
    [FieldOffset(208)] public double AITriggerTrackRecordCoefficient;
    [FieldOffset(216)] public int VeinholeMonsterStrength;
    [FieldOffset(220)] public int MaxVeinholeGrowth;
    [FieldOffset(224)] public int VeinholeGrowthRate;
    [FieldOffset(228)] public int VeinholeShrinkRate;
    [FieldOffset(232)] public nint veinAttack;
    public Pointer<AnimTypeClass> VeinAttack => veinAttack;
    [FieldOffset(236)] public int VeinDamage;
    [FieldOffset(240)] public int MaximumQueuedObjects;
    [FieldOffset(244)] public int AircraftFogReveal;
    [FieldOffset(248)] public nint woodCrateImg;
    public Pointer<OverlayTypeClass> WoodCrateImg => woodCrateImg;
    [FieldOffset(252)] public nint crateImg;
    public Pointer<OverlayTypeClass> CrateImg => crateImg;
    [FieldOffset(256)] public nint waterCrateImg;
    public Pointer<OverlayTypeClass> WaterCrateImg => waterCrateImg;
    [FieldOffset(260)] public byte dropPod;

    public ref TypeList<Pointer<AnimTypeClass>> DropPod =>
        ref Pointer<byte>.AsPointer(ref dropPod).Convert<TypeList<Pointer<AnimTypeClass>>>().Ref;

    [FieldOffset(288)] public byte deadBodies;

    public ref TypeList<Pointer<AnimTypeClass>> DeadBodies =>
        ref Pointer<byte>.AsPointer(ref deadBodies).Convert<TypeList<Pointer<AnimTypeClass>>>().Ref;

    [FieldOffset(316)] public byte metallicDebris;

    public ref TypeList<Pointer<AnimTypeClass>> MetallicDebris => ref Pointer<byte>.AsPointer(ref metallicDebris)
        .Convert<TypeList<Pointer<AnimTypeClass>>>().Ref;

    [FieldOffset(344)] public byte bridgeExplosions;

    public ref TypeList<Pointer<AnimTypeClass>> BridgeExplosions => ref Pointer<byte>.AsPointer(ref bridgeExplosions)
        .Convert<TypeList<Pointer<AnimTypeClass>>>().Ref;

    [FieldOffset(372)] public int DigSound;
    [FieldOffset(376)] public int CreateUnitSound;
    [FieldOffset(380)] public int CreateInfantrySound;
    [FieldOffset(384)] public int CreateAircraftSound;
    [FieldOffset(388)] public int BaseUnderAttackSound;
    [FieldOffset(392)] public int GUIMainButtonSound;
    [FieldOffset(396)] public int GUIBuildSound;
    [FieldOffset(400)] public int GUITabSound;
    [FieldOffset(404)] public int GUIOpenSound;
    [FieldOffset(408)] public int GUICloseSound;
    [FieldOffset(412)] public int GUIMoveOutSound;
    [FieldOffset(416)] public int GUIMoveInSound;
    [FieldOffset(420)] public int GUIComboOpenSound;
    [FieldOffset(424)] public int GUIComboCloseSound;
    [FieldOffset(428)] public int GUICheckboxSound;
    [FieldOffset(432)] public int ScoreAnimSound;
    [FieldOffset(436)] public int IFVTransformSound;
    [FieldOffset(440)] public int PsychicSensorDetectSound;
    [FieldOffset(444)] public int BuildingGarrisonedSound;
    [FieldOffset(448)] public int BuildingAbandonedSound;
    [FieldOffset(452)] public int BuildingRepairedSound;
    [FieldOffset(456)] public int CheerSound;
    [FieldOffset(460)] public int PlaceBeaconSound;
    [FieldOffset(464)] public int DefaultChronoSound;
    [FieldOffset(468)] public int StartPlanningModeSound;
    [FieldOffset(472)] public int AddPlanningModeCommandSound;
    [FieldOffset(476)] public int ExecutePlanSound;
    [FieldOffset(480)] public int EndPlanningModeSound;
    [FieldOffset(484)] public int CrateMoneySound;
    [FieldOffset(488)] public int CrateRevealSound;
    [FieldOffset(492)] public int CrateFireSound;
    [FieldOffset(496)] public int CrateArmourSound;
    [FieldOffset(500)] public int CrateSpeedSound;
    [FieldOffset(504)] public int CrateUnitSound;
    [FieldOffset(508)] public int CratePromoteSound;
    [FieldOffset(512)] public int ImpactWaterSound;
    [FieldOffset(516)] public int ImpactLandSound;
    [FieldOffset(520)] public int SinkingSound;
    [FieldOffset(524)] public int BombTickingSound;
    [FieldOffset(528)] public int BombAttachSound;
    [FieldOffset(532)] public int YuriMindControlSound;
    [FieldOffset(536)] public int ChronoInSound;
    [FieldOffset(540)] public int ChronoOutSound;
    [FieldOffset(544)] public int SpySatActivationSound;
    [FieldOffset(548)] public int SpySatDeactivationSound;
    [FieldOffset(552)] public int UpgradeVeteranSound;
    [FieldOffset(556)] public int UpgradeEliteSound;
    [FieldOffset(560)] public int VoiceIFVRepair;
    [FieldOffset(564)] public int SlavesFreeSound;
    [FieldOffset(568)] public int SlaveMinerDeploySound;
    [FieldOffset(572)] public int SlaveMinerUndeploySound;
    [FieldOffset(576)] public int BunkerWallsUpSound;
    [FieldOffset(580)] public int BunkerWallsDownSound;
    [FieldOffset(584)] public int RepairBridgeSound;
    [FieldOffset(588)] public int PsychicDominatorActivateSound;
    [FieldOffset(592)] public int GeneticMutatorActivateSound;
    [FieldOffset(596)] public int PsychicRevealActivateSound;
    [FieldOffset(600)] public int MasterMindOverloadDeathSound;
    [FieldOffset(604)] public int AirstrikeAbortSound;
    [FieldOffset(608)] public int AirstrikeAttackVoice;
    [FieldOffset(612)] public int MindClearedSound;
    [FieldOffset(616)] public int EnterGrinderSound;
    [FieldOffset(620)] public int LeaveGrinderSound;
    [FieldOffset(624)] public int EnterBioReactorSound;
    [FieldOffset(628)] public int LeaveBioReactorSound;
    [FieldOffset(632)] public int ActivateSound;
    [FieldOffset(636)] public int DeactivateSound;
    [FieldOffset(640)] public int SpyPlaneCamera;
    [FieldOffset(644)] public int LetsDoTheTimeWarpOutAgain;
    [FieldOffset(648)] public int LetsDoTheTimeWarpInAgain;
    [FieldOffset(652)] public int DiskLaserChargeUp;
    [FieldOffset(656)] public int SpyPlaneCameraFrames;
    [FieldOffset(660)] public nint dig;
    public Pointer<AnimTypeClass> Dig => dig;
    [FieldOffset(664)] public nint ionBlast;
    public Pointer<AnimTypeClass> IonBlast => ionBlast;
    [FieldOffset(668)] public nint ionBeam;
    public Pointer<AnimTypeClass> IonBeam => ionBeam;
    [FieldOffset(672)] public byte damageFireTypes;

    public ref TypeList<Pointer<AnimTypeClass>> DamageFireTypes => ref Pointer<byte>.AsPointer(ref damageFireTypes)
        .Convert<TypeList<Pointer<AnimTypeClass>>>().Ref;

    [FieldOffset(700)] public byte weatherConClouds;

    public ref TypeList<Pointer<AnimTypeClass>> WeatherConClouds => ref Pointer<byte>.AsPointer(ref weatherConClouds)
        .Convert<TypeList<Pointer<AnimTypeClass>>>().Ref;

    [FieldOffset(728)] public byte weatherConBolts;

    public ref TypeList<Pointer<AnimTypeClass>> WeatherConBolts => ref Pointer<byte>.AsPointer(ref weatherConBolts)
        .Convert<TypeList<Pointer<AnimTypeClass>>>().Ref;

    [FieldOffset(756)] public nint weatherConBoltExplosion;
    public Pointer<AnimTypeClass> WeatherConBoltExplosion => weatherConBoltExplosion;
    [FieldOffset(760)] public nint dominatorWarhead;
    public Pointer<WarheadTypeClass> DominatorWarhead => dominatorWarhead;
    [FieldOffset(764)] public nint dominatorFirstAnim;
    public Pointer<AnimTypeClass> DominatorFirstAnim => dominatorFirstAnim;
    [FieldOffset(768)] public nint dominatorSecondAnim;
    public Pointer<AnimTypeClass> DominatorSecondAnim => dominatorSecondAnim;
    [FieldOffset(772)] public int DominatorFireAtPercentage;
    [FieldOffset(776)] public int DominatorCaptureRange;
    [FieldOffset(780)] public int DominatorDamage;
    [FieldOffset(784)] public int MindControlAttackLineFrames;
    [FieldOffset(788)] public int DrainMoneyFrameDelay;
    [FieldOffset(792)] public int DrainMoneyAmount;
    [FieldOffset(796)] public nint drainAnimationType;
    public Pointer<AnimTypeClass> DrainAnimationType => drainAnimationType;
    [FieldOffset(800)] public nint controlledAnimationType;
    public Pointer<AnimTypeClass> ControlledAnimationType => controlledAnimationType;
    [FieldOffset(804)] public nint permaControlledAnimationType;
    public Pointer<AnimTypeClass> PermaControlledAnimationType => permaControlledAnimationType;
    [FieldOffset(808)] public nint chronoBlast;
    public Pointer<AnimTypeClass> ChronoBlast => chronoBlast;
    [FieldOffset(812)] public nint chronoBlastDest;
    public Pointer<AnimTypeClass> ChronoBlastDest => chronoBlastDest;
    [FieldOffset(816)] public nint chronoPlacement;
    public Pointer<AnimTypeClass> ChronoPlacement => chronoPlacement;
    [FieldOffset(820)] public nint chronoBeam;
    public Pointer<AnimTypeClass> ChronoBeam => chronoBeam;
    [FieldOffset(824)] public nint warpIn;
    public Pointer<AnimTypeClass> WarpIn => warpIn;
    [FieldOffset(828)] public nint warpOut;
    public Pointer<AnimTypeClass> WarpOut => warpOut;
    [FieldOffset(832)] public nint warpAway;
    public Pointer<AnimTypeClass> WarpAway => warpAway;
    [FieldOffset(836)] public nint chronoSparkle1;
    public Pointer<AnimTypeClass> ChronoSparkle1 => chronoSparkle1;
    [FieldOffset(840)] public nint ironCurtainInvokeAnim;
    public Pointer<AnimTypeClass> IronCurtainInvokeAnim => ironCurtainInvokeAnim;
    [FieldOffset(844)] public nint forceShieldInvokeAnim;
    public Pointer<AnimTypeClass> ForceShieldInvokeAnim => forceShieldInvokeAnim;
    [FieldOffset(848)] public nint weaponNullifyAnim;
    public Pointer<AnimTypeClass> WeaponNullifyAnim => weaponNullifyAnim;
    [FieldOffset(852)] public nint atmosphereEntry;
    public Pointer<AnimTypeClass> AtmosphereEntry => atmosphereEntry;
    [FieldOffset(856)] public byte prerequisitePower;

    public ref TypeList<int> PrerequisitePower =>
        ref Pointer<byte>.AsPointer(ref prerequisitePower).Convert<TypeList<int>>().Ref;

    [FieldOffset(884)] public byte prerequisiteFactory;

    public ref TypeList<int> PrerequisiteFactory =>
        ref Pointer<byte>.AsPointer(ref prerequisiteFactory).Convert<TypeList<int>>().Ref;

    [FieldOffset(912)] public byte prerequisiteBarracks;

    public ref TypeList<int> PrerequisiteBarracks =>
        ref Pointer<byte>.AsPointer(ref prerequisiteBarracks).Convert<TypeList<int>>().Ref;

    [FieldOffset(940)] public byte prerequisiteRadar;

    public ref TypeList<int> PrerequisiteRadar =>
        ref Pointer<byte>.AsPointer(ref prerequisiteRadar).Convert<TypeList<int>>().Ref;

    [FieldOffset(968)] public byte prerequisiteTech;

    public ref TypeList<int> PrerequisiteTech =>
        ref Pointer<byte>.AsPointer(ref prerequisiteTech).Convert<TypeList<int>>().Ref;

    [FieldOffset(996)] public byte prerequisiteProc;

    public ref TypeList<int> PrerequisiteProc =>
        ref Pointer<byte>.AsPointer(ref prerequisiteProc).Convert<TypeList<int>>().Ref;

    [FieldOffset(1024)] public nint prerequisiteProcAlternate;
    public Pointer<UnitTypeClass> PrerequisiteProcAlternate => prerequisiteProcAlternate;
    [FieldOffset(1028)] public int GateUp;
    [FieldOffset(1032)] public int GateDown;
    [FieldOffset(1036)] public int TurnRate;
    [FieldOffset(1040)] public int Speed;
    [FieldOffset(1048)] public double Climb;
    [FieldOffset(1056)] public int CruiseHeight;
    [FieldOffset(1064)] public double Acceleration;
    [FieldOffset(1072)] public double WobblesPerSecond;
    [FieldOffset(1080)] public int WobbleDeviation;
    [FieldOffset(1084)] public byte radarEventSuppressionDistances;

    public ref TypeList<int> RadarEventSuppressionDistances =>
        ref Pointer<byte>.AsPointer(ref radarEventSuppressionDistances).Convert<TypeList<int>>().Ref;

    [FieldOffset(1112)] public byte radarEventVisibilityDurations;

    public ref TypeList<int> RadarEventVisibilityDurations =>
        ref Pointer<byte>.AsPointer(ref radarEventVisibilityDurations).Convert<TypeList<int>>().Ref;

    [FieldOffset(1140)] public byte radarEventDurations;

    public ref TypeList<int> RadarEventDurations =>
        ref Pointer<byte>.AsPointer(ref radarEventDurations).Convert<TypeList<int>>().Ref;

    [FieldOffset(1168)] public int IonCannonDamage;
    [FieldOffset(1172)] public int RailgunDamageRadius;
    [FieldOffset(1176)] public nint prismType;
    public Pointer<BuildingTypeClass> PrismType => prismType;
    [FieldOffset(1180)] public int PrismSupportModifier;
    [FieldOffset(1184)] public int PrismSupportMax;
    [FieldOffset(1188)] public int PrismSupportDelay;
    [FieldOffset(1192)] public int PrismSupportDuration;
    [FieldOffset(1196)] public int PrismSupportHeight;
    [FieldOffset(1200)] public RocketStruct V3Rocket;
    [FieldOffset(1252)] public RocketStruct DMisl;
    [FieldOffset(1304)] public RocketStruct CMisl;
    [FieldOffset(1356)] public int ParadropRadius;
    [FieldOffset(1360)] public double ZoomInFactor;
    [FieldOffset(1368)] public double ConditionRedSparkingProbability;
    [FieldOffset(1376)] public double ConditionYellowSparkingProbability;
    [FieldOffset(1384)] public int TiberiumExplosionDamage;
    [FieldOffset(1388)] public int TiberiumStrength;
    [FieldOffset(1392)] public float MinLowPowerProductionSpeed;
    [FieldOffset(1396)] public float MaxLowPowerProductionSpeed;
    [FieldOffset(1400)] public float LowPowerPenaltyModifier;
    [FieldOffset(1404)] public float MultipleFactory;
    [FieldOffset(1408)] public int MaximumCheerRate;
    [FieldOffset(1416)] public double TreeFlammability;
    [FieldOffset(1424)] public double MissileSpeedVar;
    [FieldOffset(1432)] public double MissileROTVar;
    [FieldOffset(1440)] public int MissileSafetyAltitude;
    [FieldOffset(1444)] public nint dropPodWeapon;
    public Pointer<WeaponTypeClass> DropPodWeapon => dropPodWeapon;
    [FieldOffset(1448)] public int DropPodHeight;
    [FieldOffset(1452)] public int DropPodSpeed;
    [FieldOffset(1456)] public double DropPodAngle;
    [FieldOffset(1464)] public double ScrollMultiplier;
    [FieldOffset(1472)] public double CrewEscape;
    [FieldOffset(1480)] public int ShakeScreen;
    [FieldOffset(1484)] public int HoverHeight;
    [FieldOffset(1488)] public double HoverBob;
    [FieldOffset(1496)] public double HoverBoost;
    [FieldOffset(1504)] public double HoverAcceleration;
    [FieldOffset(1512)] public double HoverBrake;
    [FieldOffset(1520)] public double HoverDampen;
    [FieldOffset(1528)] public double PlacementDelay;
    [FieldOffset(1536)] public byte explosiveVoxelDebris;

    public ref TypeList<Pointer<VoxelAnimTypeClass>> ExplosiveVoxelDebris => ref Pointer<byte>
        .AsPointer(ref explosiveVoxelDebris).Convert<TypeList<Pointer<VoxelAnimTypeClass>>>().Ref;

    [FieldOffset(1564)] public nint tireVoxelDebris;
    public Pointer<VoxelAnimTypeClass> TireVoxelDebris => tireVoxelDebris;
    [FieldOffset(1568)] public nint scrapVoxelDebris;
    public Pointer<VoxelAnimTypeClass> ScrapVoxelDebris => scrapVoxelDebris;
    [FieldOffset(1572)] public int BridgeVoxelMax;
    [FieldOffset(1576)] public int CloakingStages;
    [FieldOffset(1580)] public int RevealTriggerRadius;
    [FieldOffset(1584)] public double ShipSinkingWeight;
    [FieldOffset(1592)] public double IceCrackingWeight;
    [FieldOffset(1600)] public double IceBreakingWeight;
    [FieldOffset(1608)] public byte iceCrackSounds;

    public ref TypeList<int> IceCrackSounds =>
        ref Pointer<byte>.AsPointer(ref iceCrackSounds).Convert<TypeList<int>>().Ref;

    [FieldOffset(1636)] public byte CliffBackImpassability;
    [FieldOffset(1640)] public double VeteranRatio;
    [FieldOffset(1648)] public double VeteranCombat;
    [FieldOffset(1656)] public double VeteranSpeed;
    [FieldOffset(1664)] public double VeteranSight;
    [FieldOffset(1672)] public double VeteranArmor;
    [FieldOffset(1680)] public double VeteranROF;
    [FieldOffset(1688)] public double VeteranCap;
    [FieldOffset(1696)] public int CloakSound;
    [FieldOffset(1700)] public int SellSound;
    [FieldOffset(1704)] public int GameClosed;
    [FieldOffset(1708)] public int IncomingMessage;
    [FieldOffset(1712)] public int SystemError;
    [FieldOffset(1716)] public int OptionsChanged;
    [FieldOffset(1720)] public int GameForming;
    [FieldOffset(1724)] public int PlayerLeft;
    [FieldOffset(1728)] public int PlayerJoined;
    [FieldOffset(1732)] public int MessageCharTyped;
    [FieldOffset(1736)] public int Construction;
    [FieldOffset(1740)] public byte creditTicks;
    public ref TypeList<int> CreditTicks => ref Pointer<byte>.AsPointer(ref creditTicks).Convert<TypeList<int>>().Ref;
    [FieldOffset(1768)] public int BuildingDieSound;
    [FieldOffset(1772)] public int BuildingSlam;
    [FieldOffset(1776)] public int RadarOn;
    [FieldOffset(1780)] public int RadarOff;
    [FieldOffset(1784)] public int MovieOn;
    [FieldOffset(1788)] public int MovieOff;
    [FieldOffset(1792)] public int ScoldSound;
    [FieldOffset(1796)] public int TeslaCharge;
    [FieldOffset(1800)] public int TeslaZap;
    [FieldOffset(1804)] public int GenericClick;
    [FieldOffset(1808)] public int GenericBeep;
    [FieldOffset(1812)] public int BuildingDamageSound;
    [FieldOffset(1816)] public int HealCrateSound;
    [FieldOffset(1820)] public int ChuteSound;
    [FieldOffset(1824)] public int StopSound;
    [FieldOffset(1828)] public int GuardSound;
    [FieldOffset(1832)] public int ScatterSound;
    [FieldOffset(1836)] public int DeploySound;
    [FieldOffset(1840)] public int StormSound;
    [FieldOffset(1844)] public byte lightningSounds;

    public ref TypeList<int> LightningSounds =>
        ref Pointer<byte>.AsPointer(ref lightningSounds).Convert<TypeList<int>>().Ref;

    [FieldOffset(1872)] public int ShellButtonSlideSound;
    [FieldOffset(1880)] public double WallBuildSpeedCoefficient;
    [FieldOffset(1888)] public double ChargeToDrainRatio;
    [FieldOffset(1896)] public double TrackedUphill;
    [FieldOffset(1904)] public double TrackedDownhill;
    [FieldOffset(1912)] public double WheeledUphill;
    [FieldOffset(1920)] public double WheeledDownhill;
    [FieldOffset(1928)] public int SpotlightMovementRadius;
    [FieldOffset(1932)] public int SpotlightLocationRadius;
    [FieldOffset(1936)] public double SpotlightSpeed;
    [FieldOffset(1944)] public double SpotlightAcceleration;
    [FieldOffset(1952)] public double SpotlightAngle;
    [FieldOffset(1960)] public int SpotlightRadius;
    [FieldOffset(1964)] public int WindDirection;
    [FieldOffset(1968)] public int CameraRange;
    [FieldOffset(1972)] public int FlightLevel;
    [FieldOffset(1976)] public int ParachuteMaxFallRate;
    [FieldOffset(1980)] public int NoParachuteMaxFallRate;
    [FieldOffset(1984)] public int BuildingDrop;
    [FieldOffset(1988)] public byte scorches;

    public ref TypeList<Pointer<SmudgeTypeClass>> Scorches =>
        ref Pointer<byte>.AsPointer(ref scorches).Convert<TypeList<Pointer<SmudgeTypeClass>>>().Ref;

    [FieldOffset(2016)] public byte scorches1;

    public ref TypeList<Pointer<SmudgeTypeClass>> Scorches1 =>
        ref Pointer<byte>.AsPointer(ref scorches1).Convert<TypeList<Pointer<SmudgeTypeClass>>>().Ref;

    [FieldOffset(2044)] public byte scorches2;

    public ref TypeList<Pointer<SmudgeTypeClass>> Scorches2 =>
        ref Pointer<byte>.AsPointer(ref scorches2).Convert<TypeList<Pointer<SmudgeTypeClass>>>().Ref;

    [FieldOffset(2072)] public byte scorches3;

    public ref TypeList<Pointer<SmudgeTypeClass>> Scorches3 =>
        ref Pointer<byte>.AsPointer(ref scorches3).Convert<TypeList<Pointer<SmudgeTypeClass>>>().Ref;

    [FieldOffset(2100)] public byte scorches4;

    public ref TypeList<Pointer<SmudgeTypeClass>> Scorches4 =>
        ref Pointer<byte>.AsPointer(ref scorches4).Convert<TypeList<Pointer<SmudgeTypeClass>>>().Ref;

    [FieldOffset(2128)] public byte repairBay;

    public ref TypeList<Pointer<BuildingTypeClass>> RepairBay => ref Pointer<byte>.AsPointer(ref repairBay)
        .Convert<TypeList<Pointer<BuildingTypeClass>>>().Ref;

    [FieldOffset(2156)] public nint gDIGateOne;
    public Pointer<BuildingTypeClass> GDIGateOne => gDIGateOne;
    [FieldOffset(2160)] public nint gDIGateTwo;
    public Pointer<BuildingTypeClass> GDIGateTwo => gDIGateTwo;
    [FieldOffset(2164)] public nint nodGateOne;
    public Pointer<BuildingTypeClass> NodGateOne => nodGateOne;
    [FieldOffset(2168)] public nint nodGateTwo;
    public Pointer<BuildingTypeClass> NodGateTwo => nodGateTwo;
    [FieldOffset(2172)] public nint wallTower;
    public Pointer<BuildingTypeClass> WallTower => wallTower;
    [FieldOffset(2176)] public byte shipyard;

    public ref TypeList<Pointer<BuildingTypeClass>> Shipyard => ref Pointer<byte>.AsPointer(ref shipyard)
        .Convert<TypeList<Pointer<BuildingTypeClass>>>().Ref;

    [FieldOffset(2204)] public nint gDIPowerPlant;
    public Pointer<BuildingTypeClass> GDIPowerPlant => gDIPowerPlant;
    [FieldOffset(2208)] public nint nodRegularPower;
    public Pointer<BuildingTypeClass> NodRegularPower => nodRegularPower;
    [FieldOffset(2212)] public nint nodAdvancedPower;
    public Pointer<BuildingTypeClass> NodAdvancedPower => nodAdvancedPower;
    [FieldOffset(2216)] public nint thirdPowerPlant;
    public Pointer<BuildingTypeClass> ThirdPowerPlant => thirdPowerPlant;
    [FieldOffset(2220)] public byte buildConst;

    public ref TypeList<Pointer<BuildingTypeClass>> BuildConst => ref Pointer<byte>.AsPointer(ref buildConst)
        .Convert<TypeList<Pointer<BuildingTypeClass>>>().Ref;

    [FieldOffset(2248)] public byte buildPower;

    public ref TypeList<Pointer<BuildingTypeClass>> BuildPower => ref Pointer<byte>.AsPointer(ref buildPower)
        .Convert<TypeList<Pointer<BuildingTypeClass>>>().Ref;

    [FieldOffset(2276)] public byte buildRefinery;

    public ref TypeList<Pointer<BuildingTypeClass>> BuildRefinery => ref Pointer<byte>.AsPointer(ref buildRefinery)
        .Convert<TypeList<Pointer<BuildingTypeClass>>>().Ref;

    [FieldOffset(2304)] public byte buildBarracks;

    public ref TypeList<Pointer<BuildingTypeClass>> BuildBarracks => ref Pointer<byte>.AsPointer(ref buildBarracks)
        .Convert<TypeList<Pointer<BuildingTypeClass>>>().Ref;

    [FieldOffset(2332)] public byte buildTech;

    public ref TypeList<Pointer<BuildingTypeClass>> BuildTech => ref Pointer<byte>.AsPointer(ref buildTech)
        .Convert<TypeList<Pointer<BuildingTypeClass>>>().Ref;

    [FieldOffset(2360)] public byte buildWeapons;

    public ref TypeList<Pointer<BuildingTypeClass>> BuildWeapons => ref Pointer<byte>.AsPointer(ref buildWeapons)
        .Convert<TypeList<Pointer<BuildingTypeClass>>>().Ref;

    [FieldOffset(2388)] public byte alliedBaseDefenses;

    public ref TypeList<Pointer<BuildingTypeClass>> AlliedBaseDefenses => ref Pointer<byte>
        .AsPointer(ref alliedBaseDefenses).Convert<TypeList<Pointer<BuildingTypeClass>>>().Ref;

    [FieldOffset(2416)] public byte sovietBaseDefenses;

    public ref TypeList<Pointer<BuildingTypeClass>> SovietBaseDefenses => ref Pointer<byte>
        .AsPointer(ref sovietBaseDefenses).Convert<TypeList<Pointer<BuildingTypeClass>>>().Ref;

    [FieldOffset(2444)] public byte thirdBaseDefenses;

    public ref TypeList<Pointer<BuildingTypeClass>> ThirdBaseDefenses => ref Pointer<byte>
        .AsPointer(ref thirdBaseDefenses).Convert<TypeList<Pointer<BuildingTypeClass>>>().Ref;

    [FieldOffset(2472)] public byte aIForcePredictionFudge;

    public ref TypeList<int> AIForcePredictionFudge =>
        ref Pointer<byte>.AsPointer(ref aIForcePredictionFudge).Convert<TypeList<int>>().Ref;

    [FieldOffset(2500)] public byte buildDefense;

    public ref TypeList<Pointer<BuildingTypeClass>> BuildDefense => ref Pointer<byte>.AsPointer(ref buildDefense)
        .Convert<TypeList<Pointer<BuildingTypeClass>>>().Ref;

    [FieldOffset(2528)] public byte buildPDefense;

    public ref TypeList<Pointer<BuildingTypeClass>> BuildPDefense => ref Pointer<byte>.AsPointer(ref buildPDefense)
        .Convert<TypeList<Pointer<BuildingTypeClass>>>().Ref;

    [FieldOffset(2556)] public byte buildAA;

    public ref TypeList<Pointer<BuildingTypeClass>> BuildAA =>
        ref Pointer<byte>.AsPointer(ref buildAA).Convert<TypeList<Pointer<BuildingTypeClass>>>().Ref;

    [FieldOffset(2584)] public byte buildHelipad;

    public ref TypeList<Pointer<BuildingTypeClass>> BuildHelipad => ref Pointer<byte>.AsPointer(ref buildHelipad)
        .Convert<TypeList<Pointer<BuildingTypeClass>>>().Ref;

    [FieldOffset(2612)] public byte buildRadar;

    public ref TypeList<Pointer<BuildingTypeClass>> BuildRadar => ref Pointer<byte>.AsPointer(ref buildRadar)
        .Convert<TypeList<Pointer<BuildingTypeClass>>>().Ref;

    [FieldOffset(2640)] public byte concreteWalls;

    public ref TypeList<Pointer<BuildingTypeClass>> ConcreteWalls => ref Pointer<byte>.AsPointer(ref concreteWalls)
        .Convert<TypeList<Pointer<BuildingTypeClass>>>().Ref;

    [FieldOffset(2668)] public byte nSGates;

    public ref TypeList<Pointer<BuildingTypeClass>> NSGates =>
        ref Pointer<byte>.AsPointer(ref nSGates).Convert<TypeList<Pointer<BuildingTypeClass>>>().Ref;

    [FieldOffset(2696)] public byte eWGates;

    public ref TypeList<Pointer<BuildingTypeClass>> EWGates =>
        ref Pointer<byte>.AsPointer(ref eWGates).Convert<TypeList<Pointer<BuildingTypeClass>>>().Ref;

    [FieldOffset(2724)] public byte buildNavalYard;

    public ref TypeList<Pointer<BuildingTypeClass>> BuildNavalYard => ref Pointer<byte>.AsPointer(ref buildNavalYard)
        .Convert<TypeList<Pointer<BuildingTypeClass>>>().Ref;

    [FieldOffset(2752)] public byte buildDummy;

    public ref TypeList<Pointer<BuildingTypeClass>> BuildDummy => ref Pointer<byte>.AsPointer(ref buildDummy)
        .Convert<TypeList<Pointer<BuildingTypeClass>>>().Ref;

    [FieldOffset(2780)] public byte neutralTechBuildings;

    public ref TypeList<Pointer<BuildingTypeClass>> NeutralTechBuildings => ref Pointer<byte>
        .AsPointer(ref neutralTechBuildings).Convert<TypeList<Pointer<BuildingTypeClass>>>().Ref;

    [FieldOffset(2808)] public double GDIWallDefense;
    [FieldOffset(2816)] public double GDIWallDefenseCoefficient;
    [FieldOffset(2824)] public double NodBaseDefenseCoefficient;
    [FieldOffset(2832)] public double GDIBaseDefenseCoefficient;
    [FieldOffset(2840)] public int ComputerBaseDefenseResponse;
    [FieldOffset(2844)] public int MaximumBaseDefenseValue;
    [FieldOffset(2848)] public byte baseUnit;

    public ref TypeList<Pointer<UnitTypeClass>> BaseUnit =>
        ref Pointer<byte>.AsPointer(ref baseUnit).Convert<TypeList<Pointer<UnitTypeClass>>>().Ref;

    [FieldOffset(2876)] public byte harvesterUnit;

    public ref TypeList<Pointer<UnitTypeClass>> HarvesterUnit => ref Pointer<byte>.AsPointer(ref harvesterUnit)
        .Convert<TypeList<Pointer<UnitTypeClass>>>().Ref;

    [FieldOffset(2904)] public byte padAircraft;

    public ref TypeList<Pointer<AircraftTypeClass>> PadAircraft => ref Pointer<byte>.AsPointer(ref padAircraft)
        .Convert<TypeList<Pointer<AircraftTypeClass>>>().Ref;

    [FieldOffset(2932)] public byte onFire;

    public ref TypeList<Pointer<AnimTypeClass>> OnFire =>
        ref Pointer<byte>.AsPointer(ref onFire).Convert<TypeList<Pointer<AnimTypeClass>>>().Ref;

    [FieldOffset(2960)] public byte treeFire;

    public ref TypeList<Pointer<AnimTypeClass>> TreeFire =>
        ref Pointer<byte>.AsPointer(ref treeFire).Convert<TypeList<Pointer<AnimTypeClass>>>().Ref;

    [FieldOffset(2988)] public nint smoke;
    public Pointer<AnimTypeClass> Smoke => smoke;
    [FieldOffset(2992)] public nint smoke_;
    public Pointer<AnimTypeClass> Smoke_ => smoke_;
    [FieldOffset(2996)] public nint moveFlash;
    public Pointer<AnimTypeClass> MoveFlash => moveFlash;
    [FieldOffset(3000)] public nint bombParachute;
    public Pointer<AnimTypeClass> BombParachute => bombParachute;
    [FieldOffset(3004)] public nint parachute;
    public Pointer<AnimTypeClass> Parachute => parachute;
    [FieldOffset(3008)] public byte splashList;

    public ref TypeList<Pointer<AnimTypeClass>> SplashList =>
        ref Pointer<byte>.AsPointer(ref splashList).Convert<TypeList<Pointer<AnimTypeClass>>>().Ref;

    [FieldOffset(3036)] public nint smallFire;
    public Pointer<AnimTypeClass> SmallFire => smallFire;
    [FieldOffset(3040)] public nint largeFire;
    public Pointer<AnimTypeClass> LargeFire => largeFire;
    [FieldOffset(3044)] public nint paratrooper;
    public Pointer<InfantryTypeClass> Paratrooper => paratrooper;
    [FieldOffset(3048)] public int EliteFlashTimer;
    [FieldOffset(3052)] public int ChronoDelay;
    [FieldOffset(3056)] public int ChronoReinfDelay;
    [FieldOffset(3060)] public int ChronoDistanceFactor;
    [FieldOffset(3064)] public Bool ChronoTrigger;
    [FieldOffset(3068)] public int ChronoMinimumDelay;
    [FieldOffset(3072)] public int ChronoRangeMinimum;
    [FieldOffset(3076)] public byte amerParaDropInf;

    public ref TypeList<Pointer<InfantryTypeClass>> AmerParaDropInf => ref Pointer<byte>.AsPointer(ref amerParaDropInf)
        .Convert<TypeList<Pointer<InfantryTypeClass>>>().Ref;

    [FieldOffset(3104)] public byte amerParaDropNum;

    public ref TypeList<int> AmerParaDropNum =>
        ref Pointer<byte>.AsPointer(ref amerParaDropNum).Convert<TypeList<int>>().Ref;

    [FieldOffset(3132)] public byte allyParaDropInf;

    public ref TypeList<Pointer<InfantryTypeClass>> AllyParaDropInf => ref Pointer<byte>.AsPointer(ref allyParaDropInf)
        .Convert<TypeList<Pointer<InfantryTypeClass>>>().Ref;

    [FieldOffset(3160)] public byte allyParaDropNum;

    public ref TypeList<int> AllyParaDropNum =>
        ref Pointer<byte>.AsPointer(ref allyParaDropNum).Convert<TypeList<int>>().Ref;

    [FieldOffset(3188)] public byte sovParaDropInf;

    public ref TypeList<Pointer<InfantryTypeClass>> SovParaDropInf => ref Pointer<byte>.AsPointer(ref sovParaDropInf)
        .Convert<TypeList<Pointer<InfantryTypeClass>>>().Ref;

    [FieldOffset(3216)] public byte sovParaDropNum;

    public ref TypeList<int> SovParaDropNum =>
        ref Pointer<byte>.AsPointer(ref sovParaDropNum).Convert<TypeList<int>>().Ref;

    [FieldOffset(3244)] public byte yuriParaDropInf;

    public ref TypeList<Pointer<InfantryTypeClass>> YuriParaDropInf => ref Pointer<byte>.AsPointer(ref yuriParaDropInf)
        .Convert<TypeList<Pointer<InfantryTypeClass>>>().Ref;

    [FieldOffset(3272)] public byte yuriParaDropNum;

    public ref TypeList<int> YuriParaDropNum =>
        ref Pointer<byte>.AsPointer(ref yuriParaDropNum).Convert<TypeList<int>>().Ref;

    [FieldOffset(3300)] public byte animToInfantry;

    public ref TypeList<Pointer<InfantryTypeClass>> AnimToInfantry => ref Pointer<byte>.AsPointer(ref animToInfantry)
        .Convert<TypeList<Pointer<InfantryTypeClass>>>().Ref;

    [FieldOffset(3328)] public byte secretInfantry;

    public ref TypeList<Pointer<InfantryTypeClass>> SecretInfantry => ref Pointer<byte>.AsPointer(ref secretInfantry)
        .Convert<TypeList<Pointer<InfantryTypeClass>>>().Ref;

    [FieldOffset(3356)] public byte secretUnits;

    public ref TypeList<Pointer<UnitTypeClass>> SecretUnits =>
        ref Pointer<byte>.AsPointer(ref secretUnits).Convert<TypeList<Pointer<UnitTypeClass>>>().Ref;

    [FieldOffset(3384)] public byte secretBuildings;

    public ref TypeList<Pointer<BuildingTypeClass>> SecretBuildings => ref Pointer<byte>.AsPointer(ref secretBuildings)
        .Convert<TypeList<Pointer<BuildingTypeClass>>>().Ref;

    [FieldOffset(3412)] public int SecretSum;
    [FieldOffset(3416)] public nint alliedDisguise;
    public Pointer<InfantryTypeClass> AlliedDisguise => alliedDisguise;
    [FieldOffset(3420)] public nint sovietDisguise;
    public Pointer<InfantryTypeClass> SovietDisguise => sovietDisguise;
    [FieldOffset(3424)] public nint thirdDisguise;
    public Pointer<InfantryTypeClass> ThirdDisguise => thirdDisguise;
    [FieldOffset(3428)] public int SpyPowerBlackout;
    [FieldOffset(3432)] public float SpyMoneyStealPercent;
    [FieldOffset(3436)] public Bool AttackCursorOnDisguise;
    [FieldOffset(3440)] public float AIMinorSuperReadyPercent;
    [FieldOffset(3444)] public int AISafeDistance;
    [FieldOffset(3448)] public int HarvesterTooFarDistance;
    [FieldOffset(3452)] public int ChronoHarvTooFarDistance;
    [FieldOffset(3456)] public byte alliedBaseDefenseCounts;

    public ref TypeList<int> AlliedBaseDefenseCounts =>
        ref Pointer<byte>.AsPointer(ref alliedBaseDefenseCounts).Convert<TypeList<int>>().Ref;

    [FieldOffset(3484)] public byte sovietBaseDefenseCounts;

    public ref TypeList<int> SovietBaseDefenseCounts =>
        ref Pointer<byte>.AsPointer(ref sovietBaseDefenseCounts).Convert<TypeList<int>>().Ref;

    [FieldOffset(3512)] public byte thirdBaseDefenseCounts;

    public ref TypeList<int> ThirdBaseDefenseCounts =>
        ref Pointer<byte>.AsPointer(ref thirdBaseDefenseCounts).Convert<TypeList<int>>().Ref;

    [FieldOffset(3540)] public byte aIPickWallDefensePercent;

    public ref TypeList<int> AIPickWallDefensePercent =>
        ref Pointer<byte>.AsPointer(ref aIPickWallDefensePercent).Convert<TypeList<int>>().Ref;

    [FieldOffset(3568)] public int AIRestrictReplaceTime;
    [FieldOffset(3572)] public int ThreatPerOccupant;
    [FieldOffset(3576)] public int ApproachTargetResetMultiplier;
    [FieldOffset(3580)] public int CampaignMoneyDeltaEasy;
    [FieldOffset(3584)] public int CampaignMoneyDeltaHard;
    [FieldOffset(3588)] public int GuardAreaTargetingDelay;
    [FieldOffset(3592)] public int NormalTargetingDelay;
    [FieldOffset(3596)] public int AINavalYardAdjacency;
    [FieldOffset(3600)] public byte disabledDisguiseDetectionPercent;

    public ref TypeList<int> DisabledDisguiseDetectionPercent =>
        ref Pointer<byte>.AsPointer(ref disabledDisguiseDetectionPercent).Convert<TypeList<int>>().Ref;

    [FieldOffset(3628)] public byte aIAutoDeployFrameDelay;

    public ref TypeList<int> AIAutoDeployFrameDelay =>
        ref Pointer<byte>.AsPointer(ref aIAutoDeployFrameDelay).Convert<TypeList<int>>().Ref;

    [FieldOffset(3656)] public int MaximumBuildingPlacementFailures;
    [FieldOffset(3660)] public byte aICaptureNormal;

    public ref TypeList<int> AICaptureNormal =>
        ref Pointer<byte>.AsPointer(ref aICaptureNormal).Convert<TypeList<int>>().Ref;

    [FieldOffset(3688)] public byte aICaptureWounded;

    public ref TypeList<int> AICaptureWounded =>
        ref Pointer<byte>.AsPointer(ref aICaptureWounded).Convert<TypeList<int>>().Ref;

    [FieldOffset(3716)] public byte aICaptureLowPower;

    public ref TypeList<int> AICaptureLowPower =>
        ref Pointer<byte>.AsPointer(ref aICaptureLowPower).Convert<TypeList<int>>().Ref;

    [FieldOffset(3744)] public byte aICaptureLowMoney;

    public ref TypeList<int> AICaptureLowMoney =>
        ref Pointer<byte>.AsPointer(ref aICaptureLowMoney).Convert<TypeList<int>>().Ref;

    [FieldOffset(3772)] public int AICaptureLowMoneyMark;
    [FieldOffset(3776)] public int AICaptureWoundedMark;
    [FieldOffset(3780)] public byte aISuperDefenseProbability;

    public ref TypeList<int> AISuperDefenseProbability =>
        ref Pointer<byte>.AsPointer(ref aISuperDefenseProbability).Convert<TypeList<int>>().Ref;

    [FieldOffset(3808)] public int AISuperDefenseFrames;
    [FieldOffset(3812)] public float AISuperDefenseDistance;
    [FieldOffset(3816)] public byte overloadCount;

    public ref TypeList<int> OverloadCount =>
        ref Pointer<byte>.AsPointer(ref overloadCount).Convert<TypeList<int>>().Ref;

    [FieldOffset(3844)] public byte overloadDamage;

    public ref TypeList<int> OverloadDamage =>
        ref Pointer<byte>.AsPointer(ref overloadDamage).Convert<TypeList<int>>().Ref;

    [FieldOffset(3872)] public byte overloadFrames;

    public ref TypeList<int> OverloadFrames =>
        ref Pointer<byte>.AsPointer(ref overloadFrames).Convert<TypeList<int>>().Ref;

    [FieldOffset(3900)] public float PurifierBonus;
    [FieldOffset(3904)] public float OccupyDamageMultiplier;
    [FieldOffset(3908)] public float OccupyROFMultiplier;
    [FieldOffset(3912)] public int OccupyWeaponRange;
    [FieldOffset(3916)] public int BunkerDamageMultiplier;
    [FieldOffset(3920)] public float BunkerROFMultiplier;
    [FieldOffset(3924)] public int BunkerWeaponRangeBonus;
    [FieldOffset(3928)] public float OpenToppedDamageMultiplier;
    [FieldOffset(3932)] public int OpenToppedRangeBonus;
    [FieldOffset(3936)] public int OpenToppedWarpDistance;
    [FieldOffset(3940)] public float FallingDamageMultiplier;
    [FieldOffset(3944)] public Bool CurrentStrengthDamage;
    [FieldOffset(3948)] public nint technician;
    public Pointer<InfantryTypeClass> Technician => technician;
    [FieldOffset(3952)] public nint engineer;
    public Pointer<InfantryTypeClass> Engineer => engineer;
    [FieldOffset(3956)] public nint pilot;
    public Pointer<InfantryTypeClass> Pilot => pilot;
    [FieldOffset(3960)] public nint alliedCrew;
    public Pointer<InfantryTypeClass> AlliedCrew => alliedCrew;
    [FieldOffset(3964)] public nint sovietCrew;
    public Pointer<InfantryTypeClass> SovietCrew => sovietCrew;
    [FieldOffset(3968)] public nint thirdCrew;
    public Pointer<InfantryTypeClass> ThirdCrew => thirdCrew;
    [FieldOffset(3972)] public nint flameDamage;
    public Pointer<WarheadTypeClass> FlameDamage => flameDamage;
    [FieldOffset(3976)] public nint flameDamage2;
    public Pointer<WarheadTypeClass> FlameDamage2 => flameDamage2;
    [FieldOffset(3980)] public nint nukeWarhead;
    public Pointer<WarheadTypeClass> NukeWarhead => nukeWarhead;
    [FieldOffset(3984)] public nint nukeProjectile;
    public Pointer<BulletTypeClass> NukeProjectile => nukeProjectile;
    [FieldOffset(3988)] public nint nukeDown;
    public Pointer<BulletTypeClass> NukeDown => nukeDown;
    [FieldOffset(3992)] public nint mutateWarhead;
    public Pointer<WarheadTypeClass> MutateWarhead => mutateWarhead;
    [FieldOffset(3996)] public nint mutateExplosionWarhead;
    public Pointer<WarheadTypeClass> MutateExplosionWarhead => mutateExplosionWarhead;
    [FieldOffset(4000)] public nint eMPulseWarhead;
    public Pointer<WarheadTypeClass> EMPulseWarhead => eMPulseWarhead;
    [FieldOffset(4004)] public nint eMPulseProjectile;
    public Pointer<WarheadTypeClass> EMPulseProjectile => eMPulseProjectile;
    [FieldOffset(4008)] public nint c4Warhead;
    public Pointer<WarheadTypeClass> C4Warhead => c4Warhead;
    [FieldOffset(4012)] public nint crushWarhead;
    public Pointer<WarheadTypeClass> CrushWarhead => crushWarhead;
    [FieldOffset(4016)] public nint v3Warhead;
    public Pointer<WarheadTypeClass> V3Warhead => v3Warhead;
    [FieldOffset(4020)] public nint dMislWarhead;
    public Pointer<WarheadTypeClass> DMislWarhead => dMislWarhead;
    [FieldOffset(4024)] public nint v3EliteWarhead;
    public Pointer<WarheadTypeClass> V3EliteWarhead => v3EliteWarhead;
    [FieldOffset(4028)] public nint dMislEliteWarhead;
    public Pointer<WarheadTypeClass> DMislEliteWarhead => dMislEliteWarhead;
    [FieldOffset(4032)] public nint cMislWarhead;
    public Pointer<WarheadTypeClass> CMislWarhead => cMislWarhead;
    [FieldOffset(4036)] public nint cMislEliteWarhead;
    public Pointer<WarheadTypeClass> CMislEliteWarhead => cMislEliteWarhead;
    [FieldOffset(4040)] public nint ivanWarhead;
    public Pointer<WarheadTypeClass> IvanWarhead => ivanWarhead;
    [FieldOffset(4044)] public int IvanDamage;
    [FieldOffset(4048)] public int IvanTimedDelay;
    [FieldOffset(4052)] public Bool CanDetonateTimeBomb;
    [FieldOffset(4053)] public Bool CanDetonateDeathBomb;
    [FieldOffset(4056)] public int IvanIconFlickerRate;
    [FieldOffset(4060)] public nint deathWeapon;
    public Pointer<WeaponTypeClass> DeathWeapon => deathWeapon;
    [FieldOffset(4064)] public nint bOMBCURS_SHP;
    public Pointer<ShpStruct> BOMBCURS_SHP => bOMBCURS_SHP;
    [FieldOffset(4068)] public nint cHRONOSK_SHP;
    public Pointer<ShpStruct> CHRONOSK_SHP => cHRONOSK_SHP;
    [FieldOffset(4072)] public int IronCurtainDuration;
    [FieldOffset(4076)] public int PsychicRevealRadius;
    [FieldOffset(4080)] public nint ionCannonWarhead;
    public Pointer<WarheadTypeClass> IonCannonWarhead => ionCannonWarhead;
    [FieldOffset(4084)] public nint veinholeTypeClass;
    public Pointer<TerrainTypeClass> VeinholeTypeClass => veinholeTypeClass;
    [FieldOffset(4088)] public byte defaultMirageDisguises;

    public ref TypeList<Pointer<TerrainTypeClass>> DefaultMirageDisguises => ref Pointer<byte>
        .AsPointer(ref defaultMirageDisguises).Convert<TypeList<Pointer<TerrainTypeClass>>>().Ref;

    [FieldOffset(4116)] public int InfantryBlinkDisguiseTime;
    [FieldOffset(4120)] public nint defaultLargeGreySmokeSystem;
    public Pointer<ParticleSystemTypeClass> DefaultLargeGreySmokeSystem => defaultLargeGreySmokeSystem;
    [FieldOffset(4124)] public nint defaultSmallGreySmokeSystem;
    public Pointer<ParticleSystemTypeClass> DefaultSmallGreySmokeSystem => defaultSmallGreySmokeSystem;
    [FieldOffset(4128)] public nint defaultSparkSystem;
    public Pointer<ParticleSystemTypeClass> DefaultSparkSystem => defaultSparkSystem;
    [FieldOffset(4132)] public nint defaultLargeRedSmokeSystem;
    public Pointer<ParticleSystemTypeClass> DefaultLargeRedSmokeSystem => defaultLargeRedSmokeSystem;
    [FieldOffset(4136)] public nint defaultSmallRedSmokeSystem;
    public Pointer<ParticleSystemTypeClass> DefaultSmallRedSmokeSystem => defaultSmallRedSmokeSystem;
    [FieldOffset(4140)] public nint defaultDebrisSmokeSystem;
    public Pointer<ParticleSystemTypeClass> DefaultDebrisSmokeSystem => defaultDebrisSmokeSystem;
    [FieldOffset(4144)] public nint defaultFireStreamSystem;
    public Pointer<ParticleSystemTypeClass> DefaultFireStreamSystem => defaultFireStreamSystem;
    [FieldOffset(4148)] public nint defaultTestParticleSystem;
    public Pointer<ParticleSystemTypeClass> DefaultTestParticleSystem => defaultTestParticleSystem;
    [FieldOffset(4152)] public nint defaultRepairParticleSystem;
    public Pointer<ParticleSystemTypeClass> DefaultRepairParticleSystem => defaultRepairParticleSystem;
    [FieldOffset(4160)] public double MyEffectivenessCoefficientDefault;
    [FieldOffset(4168)] public double TargetEffectivenessCoefficientDefault;
    [FieldOffset(4176)] public double TargetSpecialThreatCoefficientDefault;
    [FieldOffset(4184)] public double TargetStrengthCoefficientDefault;
    [FieldOffset(4192)] public double TargetDistanceCoefficientDefault;
    [FieldOffset(4200)] public double DumbMyEffectivenessCoefficient;
    [FieldOffset(4208)] public double DumbTargetEffectivenessCoefficient;
    [FieldOffset(4216)] public double DumbTargetSpecialThreatCoefficient;
    [FieldOffset(4224)] public double DumbTargetStrengthCoefficient;
    [FieldOffset(4232)] public double DumbTargetDistanceCoefficient;
    [FieldOffset(4240)] public double EnemyHouseThreatBonus;
    [FieldOffset(4248)] public double TurboBoost;
    [FieldOffset(4256)] public double AttackInterval;
    [FieldOffset(4264)] public double AttackDelay;
    [FieldOffset(4272)] public double PowerEmergency;
    [FieldOffset(4280)] public double AirstripRatio;
    [FieldOffset(4288)] public int AirstripLimit;
    [FieldOffset(4296)] public double HelipadRatio;
    [FieldOffset(4304)] public int HelipadLimit;
    [FieldOffset(4312)] public double TeslaRatio;
    [FieldOffset(4320)] public int TeslaLimit;
    [FieldOffset(4328)] public double AARatio;
    [FieldOffset(4336)] public int AALimit;
    [FieldOffset(4344)] public double DefenseRatio;
    [FieldOffset(4352)] public int DefenseLimit;
    [FieldOffset(4360)] public double WarRatio;
    [FieldOffset(4368)] public int WarLimit;
    [FieldOffset(4376)] public double BarracksRatio;
    [FieldOffset(4384)] public int BarracksLimit;
    [FieldOffset(4388)] public int RefineryLimit;
    [FieldOffset(4392)] public double RefineryRatio;
    [FieldOffset(4400)] public int BaseSizeAdd;
    [FieldOffset(4404)] public int PowerSurplus;
    [FieldOffset(4408)] public int InfantryReserve;
    [FieldOffset(4412)] public int InfantryBaseMult;
    [FieldOffset(4416)] public int SoloCrateMoney;
    [FieldOffset(4420)] public int TreeStrength;
    [FieldOffset(4424)] public nint unitCrateType;
    public Pointer<UnitTypeClass> UnitCrateType => unitCrateType;
    [FieldOffset(4432)] public double PatrolScan;
    [FieldOffset(4440)] public byte teamDelays;
    public ref TypeList<int> TeamDelays => ref Pointer<byte>.AsPointer(ref teamDelays).Convert<TypeList<int>>().Ref;
    [FieldOffset(4468)] public byte aIHateDelays;
    public ref TypeList<int> AIHateDelays => ref Pointer<byte>.AsPointer(ref aIHateDelays).Convert<TypeList<int>>().Ref;
    [FieldOffset(4496)] public int DissolveUnfilledTeamDelay;
    [FieldOffset(4500)] public byte aIIonCannonConYardValue;

    public ref TypeList<int> AIIonCannonConYardValue =>
        ref Pointer<byte>.AsPointer(ref aIIonCannonConYardValue).Convert<TypeList<int>>().Ref;

    [FieldOffset(4528)] public byte aIIonCannonWarFactoryValue;

    public ref TypeList<int> AIIonCannonWarFactoryValue =>
        ref Pointer<byte>.AsPointer(ref aIIonCannonWarFactoryValue).Convert<TypeList<int>>().Ref;

    [FieldOffset(4556)] public byte aIIonCannonPowerValue;

    public ref TypeList<int> AIIonCannonPowerValue =>
        ref Pointer<byte>.AsPointer(ref aIIonCannonPowerValue).Convert<TypeList<int>>().Ref;

    [FieldOffset(4584)] public byte aIIonCannonTechCenterValue;

    public ref TypeList<int> AIIonCannonTechCenterValue =>
        ref Pointer<byte>.AsPointer(ref aIIonCannonTechCenterValue).Convert<TypeList<int>>().Ref;

    [FieldOffset(4612)] public byte aIIonCannonEngineerValue;

    public ref TypeList<int> AIIonCannonEngineerValue =>
        ref Pointer<byte>.AsPointer(ref aIIonCannonEngineerValue).Convert<TypeList<int>>().Ref;

    [FieldOffset(4640)] public byte aIIonCannonThiefValue;

    public ref TypeList<int> AIIonCannonThiefValue =>
        ref Pointer<byte>.AsPointer(ref aIIonCannonThiefValue).Convert<TypeList<int>>().Ref;

    [FieldOffset(4668)] public byte aIIonCannonHarvesterValue;

    public ref TypeList<int> AIIonCannonHarvesterValue =>
        ref Pointer<byte>.AsPointer(ref aIIonCannonHarvesterValue).Convert<TypeList<int>>().Ref;

    [FieldOffset(4696)] public byte aIIonCannonMCVValue;

    public ref TypeList<int> AIIonCannonMCVValue =>
        ref Pointer<byte>.AsPointer(ref aIIonCannonMCVValue).Convert<TypeList<int>>().Ref;

    [FieldOffset(4724)] public byte aIIonCannonAPCValue;

    public ref TypeList<int> AIIonCannonAPCValue =>
        ref Pointer<byte>.AsPointer(ref aIIonCannonAPCValue).Convert<TypeList<int>>().Ref;

    [FieldOffset(4752)] public byte aIIonCannonBaseDefenseValue;

    public ref TypeList<int> AIIonCannonBaseDefenseValue =>
        ref Pointer<byte>.AsPointer(ref aIIonCannonBaseDefenseValue).Convert<TypeList<int>>().Ref;

    [FieldOffset(4780)] public byte aIIonCannonPlugValue;

    public ref TypeList<int> AIIonCannonPlugValue =>
        ref Pointer<byte>.AsPointer(ref aIIonCannonPlugValue).Convert<TypeList<int>>().Ref;

    [FieldOffset(4808)] public byte aIIonCannonHelipadValue;

    public ref TypeList<int> AIIonCannonHelipadValue =>
        ref Pointer<byte>.AsPointer(ref aIIonCannonHelipadValue).Convert<TypeList<int>>().Ref;

    [FieldOffset(4836)] public byte aIIonCannonTempleValue;

    public ref TypeList<int> AIIonCannonTempleValue =>
        ref Pointer<byte>.AsPointer(ref aIIonCannonTempleValue).Convert<TypeList<int>>().Ref;

    [FieldOffset(4864)] public int AIAlternateProductionCreditCutoff;
    [FieldOffset(4868)] public byte multiplayerAICM;

    public ref TypeList<int> MultiplayerAICM =>
        ref Pointer<byte>.AsPointer(ref multiplayerAICM).Convert<TypeList<int>>().Ref;

    [FieldOffset(4896)] public byte aIVirtualPurifiers;

    public ref TypeList<int> AIVirtualPurifiers =>
        ref Pointer<byte>.AsPointer(ref aIVirtualPurifiers).Convert<TypeList<int>>().Ref;

    [FieldOffset(4924)] public byte aISlaveMinerNumber;

    public ref TypeList<int> AISlaveMinerNumber =>
        ref Pointer<byte>.AsPointer(ref aISlaveMinerNumber).Convert<TypeList<int>>().Ref;

    [FieldOffset(4952)] public byte harvestersPerRefinery;

    public ref TypeList<int> HarvestersPerRefinery =>
        ref Pointer<byte>.AsPointer(ref harvestersPerRefinery).Convert<TypeList<int>>().Ref;

    [FieldOffset(4980)] public byte aIExtraRefineries;

    public ref TypeList<int> AIExtraRefineries =>
        ref Pointer<byte>.AsPointer(ref aIExtraRefineries).Convert<TypeList<int>>().Ref;

    [FieldOffset(5008)] public byte minimumAIDefensiveTeams;

    public ref TypeList<int> MinimumAIDefensiveTeams =>
        ref Pointer<byte>.AsPointer(ref minimumAIDefensiveTeams).Convert<TypeList<int>>().Ref;

    [FieldOffset(5036)] public byte maximumAIDefensiveTeams;

    public ref TypeList<int> MaximumAIDefensiveTeams =>
        ref Pointer<byte>.AsPointer(ref maximumAIDefensiveTeams).Convert<TypeList<int>>().Ref;

    [FieldOffset(5064)] public byte totalAITeamCap;

    public ref TypeList<int> TotalAITeamCap =>
        ref Pointer<byte>.AsPointer(ref totalAITeamCap).Convert<TypeList<int>>().Ref;

    [FieldOffset(5096)] public double AIUseTurbineUpgradeProbability;
    [FieldOffset(5104)] public byte fillEarliestTeamProbability;

    public ref TypeList<int> FillEarliestTeamProbability =>
        ref Pointer<byte>.AsPointer(ref fillEarliestTeamProbability).Convert<TypeList<int>>().Ref;

    [FieldOffset(5136)] public double CloakDelay;
    [FieldOffset(5144)] public double GameSpeedBias;
    [FieldOffset(5152)] public double BaseBias;
    [FieldOffset(5160)] public double ExpSpread;
    [FieldOffset(5168)] public int FireSupress;
    [FieldOffset(5172)] public int MaxIQLevels;
    [FieldOffset(5176)] public int SuperWeapons;
    [FieldOffset(5180)] public int Production;
    [FieldOffset(5184)] public int GuardArea;
    [FieldOffset(5188)] public int RepairSell;
    [FieldOffset(5192)] public int AutoCrush;
    [FieldOffset(5196)] public int Scatter;
    [FieldOffset(5200)] public int ContentScan;
    [FieldOffset(5204)] public int Aircraft;
    [FieldOffset(5208)] public int Harvester;
    [FieldOffset(5212)] public int SellBack;
    [FieldOffset(5216)] public int AIBaseSpacing;
    [FieldOffset(5220)] public Powerup SilverCrate;
    [FieldOffset(5224)] public Powerup WoodCrate;
    [FieldOffset(5228)] public Powerup WaterCrate;
    [FieldOffset(5232)] public int CrateMinimum;
    [FieldOffset(5236)] public int CrateMaximum;
    [FieldOffset(5240)] public int unknown_int_1478;
    [FieldOffset(5244)] public nint dropZoneAnim;
    public Pointer<AnimTypeClass> DropZoneAnim => dropZoneAnim;
    [FieldOffset(5248)] public int MinMoney;
    [FieldOffset(5252)] public int Money;
    [FieldOffset(5256)] public int MaxMoney;
    [FieldOffset(5260)] public int MoneyIncrement;
    [FieldOffset(5264)] public int MinUnitCount;
    [FieldOffset(5268)] public int UnitCount;
    [FieldOffset(5272)] public int MaxUnitCount;
    [FieldOffset(5276)] public int TechLevel;
    [FieldOffset(5280)] public int GameSpeed;
    [FieldOffset(5284)] public int AIDifficultyStruct;
    [FieldOffset(5288)] public int AIPlayers;
    [FieldOffset(5292)] public Bool BridgeDestruction;
    [FieldOffset(5293)] public Bool ShadowGrow;
    [FieldOffset(5294)] public Bool Shroud;
    [FieldOffset(5295)] public Bool Bases;
    [FieldOffset(5296)] public Bool TiberiumGrows;
    [FieldOffset(5297)] public Bool Crates;
    [FieldOffset(5298)] public Bool CaptureTheFlag;
    [FieldOffset(5299)] public Bool HarvesterTruce;
    [FieldOffset(5300)] public Bool MultiEngineer;
    [FieldOffset(5301)] public Bool AlliesAllowed;
    [FieldOffset(5302)] public Bool ShortGame;
    [FieldOffset(5303)] public Bool FogOfWar;
    [FieldOffset(5304)] public Bool MCVRedeploys;
    [FieldOffset(5305)] public Bool SuperWeaponsAllowed;
    [FieldOffset(5306)] public Bool BuildOffAlly;
    [FieldOffset(5307)] public Bool AllyChangeAllowed;
    [FieldOffset(5308)] public int DropZoneRadius;
    [FieldOffset(5312)] public double MessageDelay;
    [FieldOffset(5320)] public double SavourDelay;
    [FieldOffset(5328)] public int Players;
    [FieldOffset(5336)] public double BaseDefenseDelay;
    [FieldOffset(5344)] public int SuspendPriority;
    [FieldOffset(5352)] public double SuspendDelay;
    [FieldOffset(5360)] public double SurvivorRate;
    [FieldOffset(5368)] public int AlliedSurvivorDivisor;
    [FieldOffset(5372)] public int SovietSurvivorDivisor;
    [FieldOffset(5376)] public int ThirdSurvivorDivisor;
    [FieldOffset(5384)] public double ReloadRate;
    [FieldOffset(5392)] public double AutocreateTime;
    [FieldOffset(5400)] public double BuildupTime;
    [FieldOffset(5408)] public int HarvesterLoadRate;
    [FieldOffset(5416)] public double HarvesterDumpRate;
    [FieldOffset(5424)] public int AtomDamage;
    [FieldOffset(5432)] public DifficultyStruct Easy;
    [FieldOffset(5512)] public DifficultyStruct Normal;
    [FieldOffset(5592)] public DifficultyStruct Difficult;
    [FieldOffset(5688)] public double GrowthRate;
    [FieldOffset(5696)] public double ShroudRate;
    [FieldOffset(5704)] public double FogRate;
    [FieldOffset(5712)] public double IceGrowthRate;
    [FieldOffset(5720)] public double VeinGrowthRate;
    [FieldOffset(5728)] public int IceSolidifyFrameTime;
    [FieldOffset(5736)] public double AmbientChangeRate;
    [FieldOffset(5744)] public double AmbientChangeStep;
    [FieldOffset(5752)] public double CrateRegen;
    [FieldOffset(5760)] public double TimerWarning;
    [FieldOffset(5768)] public int TiberiumTransmogrify;
    [FieldOffset(5776)] public double unknown_double_1690;
    [FieldOffset(5784)] public double unknown_double_1698;
    [FieldOffset(5792)] public double unknown_double_16A0;
    [FieldOffset(5800)] public double SpeakDelay;
    [FieldOffset(5808)] public double DamageDelay;
    [FieldOffset(5816)] public int Gravity;
    [FieldOffset(5820)] public int LeptonsPerSightIncrease;
    [FieldOffset(5824)] public int Incoming;
    [FieldOffset(5828)] public int MinDamage;
    [FieldOffset(5832)] public int MaxDamage;
    [FieldOffset(5836)] public int RepairStep;
    [FieldOffset(5840)] public double RepairPercent;
    [FieldOffset(5848)] public int IRepairStep;
    [FieldOffset(5856)] public double RepairRate;
    [FieldOffset(5864)] public double URepairRate;
    [FieldOffset(5872)] public double IRepairRate;
    [FieldOffset(5880)] public double unknown_double_16F8;
    [FieldOffset(5888)] public double ConditionYellow;
    [FieldOffset(5896)] public double ConditionRed;
    [FieldOffset(5904)] public double IdleActionFrequency;
    [FieldOffset(5912)] public int CloseEnough;
    [FieldOffset(5916)] public int Stray;
    [FieldOffset(5920)] public int RelaxedStray;
    [FieldOffset(5924)] public int GuardModeStray;
    [FieldOffset(5928)] public int Crush;
    [FieldOffset(5932)] public int CrateRadius;
    [FieldOffset(5936)] public int HomingScatter;
    [FieldOffset(5940)] public int BallisticScatter;
    [FieldOffset(5944)] public double RefundPercent;
    [FieldOffset(5952)] public int BridgeStrength;
    [FieldOffset(5960)] public double BuildSpeed;
    [FieldOffset(5968)] public double C4Delay;
    [FieldOffset(5976)] public int CreditReserve;
    [FieldOffset(5984)] public double PathDelay;
    [FieldOffset(5992)] public int BlockagePathDelay;
    [FieldOffset(6000)] public double MovieTime;
    [FieldOffset(6008)] public int TiberiumShortScan;
    [FieldOffset(6012)] public int TiberiumLongScan;
    [FieldOffset(6016)] public int SlaveMinerShortScan;
    [FieldOffset(6020)] public int SlaveMinerSlaveScan;
    [FieldOffset(6024)] public int SlaveMinerLongScan;
    [FieldOffset(6028)] public int SlaveMinerScanCorrection;
    [FieldOffset(6032)] public int SlaveMinerKickFrameDelay;
    [FieldOffset(6036)] public int LightningDeferment;
    [FieldOffset(6040)] public int LightningDamage;
    [FieldOffset(6044)] public int LightningStormDuration;
    [FieldOffset(6048)] public int LightningHitDelay;
    [FieldOffset(6052)] public int LightningScatterDelay;
    [FieldOffset(6056)] public int LightningCellSpread;
    [FieldOffset(6060)] public int LightningSeparation;
    [FieldOffset(6064)] public Bool LightningPrintText;
    [FieldOffset(6068)] public nint lightningWarhead;
    public Pointer<WarheadTypeClass> LightningWarhead => lightningWarhead;
    [FieldOffset(6072)] public int ForceShieldRadius;
    [FieldOffset(6076)] public int ForceShieldDuration;
    [FieldOffset(6080)] public int ForceShieldBlackoutDuration;
    [FieldOffset(6084)] public int ForceShieldPlayFadeSoundTime;
    [FieldOffset(6088)] public Bool MutateExplosion;
    [FieldOffset(6092)] public int CollapseChance;
    [FieldOffset(6096)] public int WeedCapacity;
    [FieldOffset(6100)] public float ExtraUnitLight;
    [FieldOffset(6104)] public float ExtraInfantryLight;
    [FieldOffset(6108)] public float ExtraAircraftLight;
    [FieldOffset(6112)] public Bool Paranoid;
    [FieldOffset(6113)] public Bool CurleyShuffle;
    [FieldOffset(6114)] public Bool BlendedFog;
    [FieldOffset(6115)] public Bool CompEasyBonus;
    [FieldOffset(6116)] public Bool FineDiffControl;
    [FieldOffset(6117)] public Bool TiberiumExplosive;
    [FieldOffset(6118)] public Bool EnemyHealth;
    [FieldOffset(6119)] public Bool AllyReveal;
    [FieldOffset(6120)] public Bool SeparateAircraft;
    [FieldOffset(6121)] public Bool TreeTargeting;
    [FieldOffset(6122)] public Bool NamedCivilians;
    [FieldOffset(6123)] public Bool PlayerAutoCrush;
    [FieldOffset(6124)] public Bool PlayerReturnFire;
    [FieldOffset(6125)] public Bool PlayerScatter;
    [FieldOffset(6126)] public Bool RevealByHeight;
    [FieldOffset(6127)] public Bool AllowShroudedSubteranneanMoves;
    [FieldOffset(6128)] public Bool ShroudGrow;
    [FieldOffset(6129)] public Bool NodAIBuildsWalls;
    [FieldOffset(6130)] public Bool AIBuildsWalls;
    [FieldOffset(6131)] public Bool UseMinDefenseRule;
    [FieldOffset(6132)] public nint eMPulseSparkles;
    public Pointer<AnimTypeClass> EMPulseSparkles => eMPulseSparkles;
    [FieldOffset(6136)] public float EngineerCaptureLevel;
    [FieldOffset(6140)] public float EngineerCaptureLevel_;
    [FieldOffset(6144)] public float TalkBubbleTime;
    [FieldOffset(6148)] public int RadDurationMultiple;
    [FieldOffset(6152)] public int RadApplicationDelay;
    [FieldOffset(6156)] public int RadLevelMax;
    [FieldOffset(6160)] public int RadLevelDelay;
    [FieldOffset(6164)] public int RadLightDelay;
    [FieldOffset(6168)] public double RadLevelFactor;
    [FieldOffset(6176)] public double RadLightFactor;
    [FieldOffset(6184)] public double RadTintFactor;
    [FieldOffset(6192)] public ColorStruct RadColor;
    [FieldOffset(6196)] public nint radSiteWarhead;
    public Pointer<WarheadTypeClass> RadSiteWarhead => radSiteWarhead;
    [FieldOffset(6200)] public int ElevationIncrement;
    [FieldOffset(6208)] public double ElevationIncrementBonus;
    [FieldOffset(6216)] public double ElevationBonusCap;
    [FieldOffset(6224)] public Bool AlliedWallTransparency;
    [FieldOffset(6232)] public double WallPenetratorThreshold;
    [FieldOffset(6240)] public ColorStruct LocalRadarColor;
    [FieldOffset(6243)] public ColorStruct LineTrailColorOverride;
    [FieldOffset(6246)] public ColorStruct ChronoBeamColor;
    [FieldOffset(6249)] public ColorStruct MagnaBeamColor;
    [FieldOffset(6252)] public int OreTwinkleChance;
    [FieldOffset(6256)] public nint oreTwinkle;
    public Pointer<AnimTypeClass> OreTwinkle => oreTwinkle;
    [FieldOffset(6260)] public byte colorAdd;
    public FixedArray<ColorStruct> ColorAdd => new(ref Unsafe.As<byte, ColorStruct>(ref colorAdd), 16);
    [FieldOffset(6308)] public int LaserTargetColor;
    [FieldOffset(6312)] public int IronCurtainColor;
    [FieldOffset(6316)] public int BerserkColor;
    [FieldOffset(6320)] public int ForceShieldColor;
    [FieldOffset(6324)] public float DirectRockingCoefficient;
    [FieldOffset(6328)] public float FallBackCoefficient;
}

[StructLayout(LayoutKind.Explicit, Size = 80)]
public struct DifficultyStruct
{
    [FieldOffset(0)] public double Firepower;
    [FieldOffset(8)] public double GroundSpeed;
    [FieldOffset(16)] public double AirSpeed;
    [FieldOffset(24)] public double Armor;
    [FieldOffset(32)] public double ROF;
    [FieldOffset(40)] public double Cost;
    [FieldOffset(48)] public double BuildTime;
    [FieldOffset(56)] public double RepairDelay;
    [FieldOffset(64)] public double BuildDelay;
    [FieldOffset(72)] public Bool BuildSlowdown;
    [FieldOffset(73)] public Bool DestroyWalls;
    [FieldOffset(74)] public Bool ContentScan;
}

[StructLayout(LayoutKind.Explicit)]
public struct RocketStruct
{
    [FieldOffset(0)] public int PauseFrames;
    [FieldOffset(4)] public int TiltFrames;
    [FieldOffset(8)] public float PitchInitial;
    [FieldOffset(12)] public float PitchFinal;
    [FieldOffset(16)] public float TurnRate;
    [FieldOffset(20)] public int RaiseRate;
    [FieldOffset(24)] public float Acceleration;
    [FieldOffset(28)] public int Altitude;
    [FieldOffset(32)] public int Damage;
    [FieldOffset(36)] public int EliteDamage;
    [FieldOffset(40)] public int BodyLength;
    [FieldOffset(44)] public Bool LazyCurve;
    [FieldOffset(48)] public nint type;
    public Pointer<AircraftTypeClass> Type => type;
}