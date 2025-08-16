namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct ParticleSystemClass
{
    [FieldOffset(0)] public ObjectClass Base;
    [FieldOffset(172)] public nint type;
    public Pointer<ParticleSystemTypeClass> Type => type;
    [FieldOffset(176)] public CoordStruct SpawnDistanceToOwner;
    [FieldOffset(188)] public byte particles;

    public ref DynamicVectorClass<Pointer<ParticleClass>> Particles => ref Pointer<byte>.AsPointer(ref particles)
        .Convert<DynamicVectorClass<Pointer<ParticleClass>>>().Ref;

    [FieldOffset(212)] public CoordStruct TargetCoords;
    [FieldOffset(224)] public nint owner;
    public Pointer<ObjectClass> Owner => owner;
    [FieldOffset(228)] public nint target;
    public Pointer<AbstractClass> Target => target;
    [FieldOffset(232)] public int SpawnFrames;
    [FieldOffset(236)] public int Lifetime;
    [FieldOffset(240)] public int SparkSpawnFrames;
    [FieldOffset(244)] public int SpotlightRadius;
    [FieldOffset(248)] public Bool TimeToDie;
    [FieldOffset(249)] public Bool unknown_bool_F9;
    [FieldOffset(252)] public nint ownerHouse;
    public Pointer<HouseClass> OwnerHouse => ownerHouse;
}