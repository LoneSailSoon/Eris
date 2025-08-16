using System.Runtime.CompilerServices;
using Eris.YRSharp.String.Ansi;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct VocClassHeader
{
    [FieldOffset(0)] public nint next;
    public Pointer<VocClassHeader> Next => next;
    [FieldOffset(4)] public nint prev;
    public Pointer<VocClassHeader> Prev => prev;
    [FieldOffset(8)] public uint Magic;
}

[StructLayout(LayoutKind.Explicit)]
public struct VolumeStruct
{
    [FieldOffset(0)] public int Volume;
    [FieldOffset(4)] public uint unknown_4;
    [FieldOffset(8)] public int unknown_int_8;
    [FieldOffset(12)] public int unknown_int_C;
    [FieldOffset(16)] public int unknown_int_10;
    [FieldOffset(20)] public int unknown_int_14;
    [FieldOffset(24)] public uint unknown_18;
    [FieldOffset(28)] public int unknown_int_1C;

}

[StructLayout(LayoutKind.Explicit)]
public struct VocClass
{
    public const nint array = 0xB1D378;
    public static ref DynamicVectorClass<Pointer<VocClass>> Array => ref array.Convert<DynamicVectorClass<Pointer<VocClass>>>().Ref;
    public const nint voicesEnabled = 0x8464AC;
    public static ref Bool VoicesEnabled => ref voicesEnabled.Convert<Bool>().Ref;


    [FieldOffset(0)] public VocClassHeader Header;
    [FieldOffset(12)] public int SamplesOK;
    [FieldOffset(16)] public SoundControl Control;
    [FieldOffset(20)] public SoundType Type;
    [FieldOffset(24)] public VolumeStruct Volume;
    [FieldOffset(56)] public uint unknown_38;
    [FieldOffset(60)] public uint unknown_3C;
    [FieldOffset(64)] public SoundPriority Priority;
    [FieldOffset(68)] public uint unknown_44;
    [FieldOffset(72)] public int Limit;
    [FieldOffset(76)] public int Loop;
    [FieldOffset(80)] public int Range;
    [FieldOffset(84)] public float MinVolume;
    [FieldOffset(88)] public int MinDelay;
    [FieldOffset(92)] public int MaxDelay;
    [FieldOffset(96)] public int MinFDelta;
    [FieldOffset(100)] public int MaxFDelta;
    [FieldOffset(104)] public int VShift;
    [FieldOffset(108)] public byte name;
    public AnsiStringPointer Name => new(ref Unsafe.As<byte, byte>(ref name), 32);
    [FieldOffset(140)] public uint unknown_8C;
    [FieldOffset(144)] public uint unknown_90;
    [FieldOffset(148)] public uint unknown_94;
    [FieldOffset(152)] public uint unknown_98;
    [FieldOffset(156)] public uint unknown_9C;
    [FieldOffset(160)] public uint unknown_A0;
    [FieldOffset(164)] public uint unknown_A4;
    [FieldOffset(168)] public uint unknown_A8;
    [FieldOffset(172)] public uint unknown_AC;
    [FieldOffset(176)] public uint unknown_B0;
    [FieldOffset(180)] public byte sampleIndex;
    public FixedArray<int> SampleIndex => new(ref Unsafe.As<byte, int>(ref sampleIndex), 32);
    [FieldOffset(308)] public int NumSamples;
    [FieldOffset(312)] public int Attack;
    [FieldOffset(316)] public int Decay;
    [FieldOffset(320)] public uint unknown_140;
    [FieldOffset(324)] public uint unknown_144;
}