using System.Numerics;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct ParticleClass
{
    [FieldOffset(0)] public ObjectClass Base;
    [FieldOffset(172)] public nint type;
    public Pointer<ParticleTypeClass> Type => type;
    [FieldOffset(176)] public byte unknown_B0;
    [FieldOffset(177)] public byte unknown_B1;
    [FieldOffset(178)] public byte unknown_B2;
    [FieldOffset(180)] public uint unknown_B4;
    [FieldOffset(184)] public uint unknown_B8;
    [FieldOffset(188)] public uint unknown_BC;
    [FieldOffset(204)] public uint unknown_CC;
    [FieldOffset(208)] public double unknown_double_D0;
    [FieldOffset(216)] public uint unknown_D8;
    [FieldOffset(220)] public uint unknown_DC;
    [FieldOffset(224)] public uint unknown_E0;
    [FieldOffset(228)] public CoordStruct Velocity;
    [FieldOffset(232)] public CoordStruct unknown_coords_E8;
    [FieldOffset(244)] public CoordStruct unknown_coords_F4;
    [FieldOffset(256)] public CoordStruct unknown_coords_100;
    [FieldOffset(268)] public Vector3 Unknown_vector3d_10C;
    [FieldOffset(280)] public Vector3 Unknown_vector3d_118;
    [FieldOffset(292)] public nint particleSystem;
    public Pointer<ParticleSystemClass> ParticleSystem => particleSystem;
    [FieldOffset(296)] public ushort RemainingEC;
    [FieldOffset(298)] public ushort RemainingDC;
    [FieldOffset(300)] public byte StateAIAdvance;
    [FieldOffset(301)] public byte unknown_12D;
    [FieldOffset(302)] public byte StartStateAI;
    [FieldOffset(303)] public byte Translucency;
    [FieldOffset(304)] public byte unknown_130;
    [FieldOffset(305)] public byte unknown_131;

}