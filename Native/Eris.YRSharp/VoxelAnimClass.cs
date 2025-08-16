namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct VoxelAnimClass
{
    public const nint array = 0x887388;
    public static ref DynamicVectorClass<Pointer<VoxelAnimClass>> Array => ref array.Convert<DynamicVectorClass<Pointer<VoxelAnimClass>>>().Ref;


    [FieldOffset(0)] public ObjectClass Base;
    [FieldOffset(176)] public BounceClass Bounce;
    [FieldOffset(256)] public int unknown_int_100;
    [FieldOffset(260)] public nint type;
    public Pointer<VoxelAnimTypeClass> Type => type;
    [FieldOffset(264)] public nint attachedSystem;
    public Pointer<ParticleSystemClass> AttachedSystem => attachedSystem;
    [FieldOffset(268)] public nint ownerHouse;
    public Pointer<HouseClass> OwnerHouse => ownerHouse;
    [FieldOffset(272)] public Bool TimeToDie;
    [FieldOffset(276)] public AudioController Audio3;
    [FieldOffset(296)] public AudioController Audio4;
    [FieldOffset(316)] public Bool Invisible;
    [FieldOffset(320)] public int Duration;

}