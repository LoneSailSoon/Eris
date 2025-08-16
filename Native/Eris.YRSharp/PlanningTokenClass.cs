using System.Runtime.CompilerServices;

namespace Eris.YRSharp;



[StructLayout(LayoutKind.Explicit, Size = 16)]
public struct PlanningMemberClass
{
    [FieldOffset(0)] public nint owner;
    public Pointer<TechnoClass> Owner => owner;
    [FieldOffset(4)] public uint Packet;
    [FieldOffset(8)] public int field_8;
    [FieldOffset(12)] public byte field_C;
}

[StructLayout(LayoutKind.Explicit, Size = 16)]
public struct PlanningNodeClass
{
    public const nint unknown1 = 0xAC4B30;
    public static ref DynamicVectorClass<Pointer<PlanningNodeClass>> Unknown1 => ref unknown1.Convert<DynamicVectorClass<Pointer<PlanningNodeClass>>>().Ref;
    public const nint unknown2 = 0xAC4C18;
    public static ref DynamicVectorClass<Pointer<PlanningNodeClass>> Unknown2 => ref unknown2.Convert<DynamicVectorClass<Pointer<PlanningNodeClass>>>().Ref;
    public const nint unknown3 = 0xAC4C98;
    public static ref DynamicVectorClass<Pointer<PlanningNodeClass>> Unknown3 => ref unknown3.Convert<DynamicVectorClass<Pointer<PlanningNodeClass>>>().Ref;
    public const nint planningModeActive = 0xAC4CF4;
    public static ref Bool PlanningModeActive => ref planningModeActive.Convert<Bool>().Ref;

    
    [FieldOffset(0)] public byte planningMembers;
    public ref DynamicVectorClass<Pointer<PlanningMemberClass>> PlanningMembers => ref Pointer<byte>.AsPointer(ref planningMembers).Convert<DynamicVectorClass<Pointer<PlanningMemberClass>>>().Ref;
    [FieldOffset(24)] public int field_18;
    [FieldOffset(28)] public Bool field_1C;
    [FieldOffset(32)] public byte planningBranches;
    public ref DynamicVectorClass<Pointer<PlanningBranchClass>> PlanningBranches => ref Pointer<byte>.AsPointer(ref planningBranches).Convert<DynamicVectorClass<Pointer<PlanningBranchClass>>>().Ref;
}

[StructLayout(LayoutKind.Sequential, Size = 0x78)]
public struct PlanningBranchClass;

[StructLayout(LayoutKind.Explicit)]
public struct PlanningTokenClass
{
    [FieldOffset(0)] public nint ownerUnit;
    public Pointer<TechnoClass> OwnerUnit => ownerUnit;
    [FieldOffset(4)] public byte planningNodes;
    public ref DynamicVectorClass<Pointer<PlanningNodeClass>> PlanningNodes => ref Pointer<byte>.AsPointer(ref planningNodes).Convert<DynamicVectorClass<Pointer<PlanningNodeClass>>>().Ref;
    [FieldOffset(28)] public Bool field_1C;
    [FieldOffset(29)] public Bool field_1D;
    [FieldOffset(32)] public byte unknown_20_88;
    public FixedArray<uint> Unknown_20_88 => new(ref Unsafe.As<byte, uint>(ref unknown_20_88), 27);
    [FieldOffset(140)] public int field_8C;
    [FieldOffset(144)] public int ClosedLoopNodeCount;
    [FieldOffset(148)] public int StepsToClosedLoop;
    [FieldOffset(152)] public Bool field_98;
    [FieldOffset(153)] public Bool field_99;
}