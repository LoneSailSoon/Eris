using Eris.YRSharp.Utilities;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct RadBeam
{
    public static unsafe Pointer<RadBeam> DisposeOfArt(RadBeamType mode)
    {
        var func = (delegate* unmanaged[Thiscall]<RadBeamType, nint>)0x659110;
        return func(mode);
    }

    
    [FieldOffset(0)] public uint unknown_0;
    [FieldOffset(4)] public nint owner;
    public Pointer<TechnoClass> Owner => owner;
    [FieldOffset(8)] public byte unknown_8;
    [FieldOffset(12)] public uint unknown_C;
    [FieldOffset(16)] public RadBeamType Type;
    [FieldOffset(20)] public uint unknown_14;
    [FieldOffset(24)] public double unknown_18;
    [FieldOffset(32)] public ColorStruct Color;
    [FieldOffset(36)] public CoordStruct SourceLocation;
    [FieldOffset(48)] public CoordStruct TargetLocation;
    [FieldOffset(60)] public uint Period;
    [FieldOffset(64)] public double Amplitude;
    [FieldOffset(72)] public double unknown_48;
    [FieldOffset(80)] public uint unknown_50;
    [FieldOffset(84)] public uint unknown_54;
    [FieldOffset(88)] public byte unknown_58;
    [FieldOffset(92)] public uint unknown_5C;
    [FieldOffset(96)] public uint unknown_60;
    [FieldOffset(100)] public uint unknown_64;
    [FieldOffset(104)] public double unknown_68;
    [FieldOffset(112)] public CoordStruct AnotherLocation;
    [FieldOffset(124)] public uint unknown_7C;
    [FieldOffset(128)] public double unknown_80;
    [FieldOffset(136)] public uint unknown_88;
    [FieldOffset(140)] public uint unknown_8C;
    [FieldOffset(144)] public CoordStruct AndAnotherLocation;
    [FieldOffset(156)] public uint unknown_9C;
    [FieldOffset(160)] public uint unknown_A0;
    [FieldOffset(164)] public uint unknown_A4;
    [FieldOffset(168)] public uint unknown_A8;
    [FieldOffset(172)] public uint unknown_AC;
    [FieldOffset(176)] public uint unknown_B0;
    [FieldOffset(180)] public uint unknown_B4;
    [FieldOffset(184)] public double unknown_B8;
    [FieldOffset(192)] public byte unknown_C0;

}