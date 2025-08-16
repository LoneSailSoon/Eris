using System.Runtime.CompilerServices;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct VoxClass
{
    public const nint array = 0xB1D4A0;
    public static ref DynamicVectorClass<Pointer<VoxClass>> Array => ref array.Convert<DynamicVectorClass<Pointer<VoxClass>>>().Ref;
    public const nint evaIndex = 0xB1D4C8;
    public static ref int EVAIndex => ref evaIndex.Convert<int>().Ref;

    [FieldOffset(0)] public byte name;
    public FixedArray<byte> Name => new(ref Unsafe.As<byte, byte>(ref name), 40);
    [FieldOffset(40)] public float Volume;
    [FieldOffset(44)] public byte yuri;
    public FixedArray<byte> Yuri => new(ref Unsafe.As<byte, byte>(ref yuri), 9);
    [FieldOffset(53)] public byte russian;
    public FixedArray<byte> Russian => new(ref Unsafe.As<byte, byte>(ref russian), 9);
    [FieldOffset(62)] public byte allied;
    public FixedArray<byte> Allied => new(ref Unsafe.As<byte, byte>(ref allied), 9);
    [FieldOffset(72)] public VoxPriority Priority;
    [FieldOffset(76)] public VoxType Type;
    [FieldOffset(80)] public int unknown_int_50;
}