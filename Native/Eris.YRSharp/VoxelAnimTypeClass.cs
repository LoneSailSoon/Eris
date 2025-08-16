namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct VoxelAnimTypeClass
{
    private const nint ArrayPointer = 0xA8EB28;

    public static readonly GlobalDvcArray<VoxelAnimTypeClass> AbstractTypeArray = new(ArrayPointer);

    [FieldOffset(0)] public ObjectTypeClass Base;
    [FieldOffset(660)] public Bool Normalized;
    [FieldOffset(661)] public Bool Translucent;
    [FieldOffset(662)] public Bool SourceShared;
    [FieldOffset(664)] public int VoxelIndex;
    [FieldOffset(668)] public int Duration;
    [FieldOffset(672)] public double Elasticity;
    [FieldOffset(680)] public double MinAngularVelocity;
    [FieldOffset(688)] public double MaxAngularVelocity;
    [FieldOffset(696)] public double MinZVel;
    [FieldOffset(704)] public double MaxZVel;
    [FieldOffset(712)] public double MaxXYVel;
    [FieldOffset(720)] public Bool IsMeteor;
    [FieldOffset(724)] public nint spawns;
    public Pointer<VoxelAnimTypeClass> Spawns => spawns;
    [FieldOffset(728)] public int SpawnCount;
    [FieldOffset(732)] public int StartSound;
    [FieldOffset(736)] public int StopSound;
    [FieldOffset(740)] public nint bounceAnim;
    public Pointer<AnimTypeClass> BounceAnim => bounceAnim;
    [FieldOffset(744)] public nint expireAnim;
    public Pointer<AnimTypeClass> ExpireAnim => expireAnim;
    [FieldOffset(748)] public nint trailerAnim;
    public Pointer<AnimTypeClass> TrailerAnim => trailerAnim;
    [FieldOffset(752)] public int Damage;
    [FieldOffset(756)] public int DamageRadius;
    [FieldOffset(760)] public nint warhead;
    public Pointer<WarheadTypeClass> Warhead => warhead;
    [FieldOffset(764)] public nint attachedSystem;
    public Pointer<ParticleSystemTypeClass> AttachedSystem => attachedSystem;
    [FieldOffset(768)] public Bool IsTiberium;
}