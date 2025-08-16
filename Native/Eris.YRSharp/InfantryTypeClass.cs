using System.Runtime.CompilerServices;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 3792)]
public struct InfantryTypeClass
{
    [FieldOffset(0)] public TechnoTypeClass Base;
    [FieldOffset(0)] public ObjectTypeClass BaseObjectType;
    [FieldOffset(0)] public AbstractTypeClass BaseAbstractType;
    [FieldOffset(0)] public int ArrayIndex;
    [FieldOffset(4)] public PipIndex Pip;
    [FieldOffset(8)] public PipIndex OccupyPip;
    [FieldOffset(12)] public WeaponStruct OccupyWeapon;
    [FieldOffset(40)] public WeaponStruct EliteOccupyWeapon;
    [FieldOffset(68)] public nint sequence;
    public Pointer<SequenceStruct> Sequence => sequence;
    [FieldOffset(72)] public int FireUp;
    [FieldOffset(76)] public int FireProne;
    [FieldOffset(80)] public int SecondaryFire;
    [FieldOffset(84)] public int SecondaryProne;
    [FieldOffset(88)] public TypeList<Pointer<AnimTypeClass>> DeadBodies;
    [FieldOffset(116)] public TypeList<Pointer<AnimTypeClass>> DeathAnims;
    [FieldOffset(144)] public TypeList<int> VoiceComment;
    [FieldOffset(172)] public int EnterWaterSound;
    [FieldOffset(176)] public int LeaveWaterSound;
    [FieldOffset(180)] public Bool Cyborg;
    [FieldOffset(181)] public Bool NotHuman;
    [FieldOffset(182)] public Bool Ivan;
    [FieldOffset(184)] public int DirectionDistance;
    [FieldOffset(188)] public Bool Occupier;
    [FieldOffset(189)] public Bool Assaulter;
    [FieldOffset(192)] public int HarvestRate;
    [FieldOffset(196)] public Bool Fearless;
    [FieldOffset(197)] public Bool Crawls;
    [FieldOffset(198)] public Bool Infiltrate;
    [FieldOffset(199)] public Bool Fraidycat;
    [FieldOffset(200)] public Bool TiberiumProof;
    [FieldOffset(201)] public Bool Civilian;
    [FieldOffset(202)] public Bool C4;
    [FieldOffset(203)] public Bool Engineer;
    [FieldOffset(204)] public Bool Agent;
    [FieldOffset(205)] public Bool Thief;
    [FieldOffset(206)] public Bool VehicleThief;
    [FieldOffset(207)] public Bool Doggie;
    [FieldOffset(208)] public Bool Deployer;
    [FieldOffset(209)] public Bool DeployedCrushable;
    [FieldOffset(210)] public Bool UseOwnName;
    [FieldOffset(211)] public Bool JumpJetTurn;

}

[StructLayout(LayoutKind.Explicit)]
public struct SequenceStruct
{
    [FieldOffset(0)] public byte sequences;
    public FixedArray<SubSequenceStruct> Sequences => new(ref Unsafe.As<byte, SubSequenceStruct>(ref sequences), 42);
}

[StructLayout(LayoutKind.Explicit, Size = 0x24)]
public struct SubSequenceStruct
{
    [FieldOffset(0)] public int StartFrame;
    [FieldOffset(4)] public int CountFrames;
    [FieldOffset(8)] public int FacingMultiplier;
    [FieldOffset(12)] public SequenceFacing Facing;
    [FieldOffset(16)] public int SoundCount;
    [FieldOffset(20)] public int Sound1StartFrame;
    [FieldOffset(24)] public int Sound1Index;
    [FieldOffset(28)] public int Sound2StartFrame;
    [FieldOffset(32)] public int Sound2Index;

}

