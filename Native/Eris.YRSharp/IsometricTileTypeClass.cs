using System.Runtime.CompilerServices;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct IsometricTileTypeClass
{
    [FieldOffset(0)] public ObjectTypeClass Base;
    [FieldOffset(660)] public int ArrayIndex;
    [FieldOffset(664)] public int MarbleMadnessTile;
    [FieldOffset(668)] public int NonMarbleMadnessTile;
    [FieldOffset(672)] public uint unk_2A0;
    [FieldOffset(676)]  public byte unk_2A4;
    public ref DynamicVectorClass<Pointer<ColorStruct>> Unk_2A4 => 
        ref Pointer<byte>.AsPointer(ref unk_2A4).Convert<DynamicVectorClass<Pointer<ColorStruct>>>().Ref;
    [FieldOffset(700)] public uint unk_2BC;
    [FieldOffset(704)] public int ToSnowTheater;
    [FieldOffset(708)] public int ToTemperateTheater;
    [FieldOffset(712)] public int TileAnimIndex;
    [FieldOffset(716)] public int TileXOffset;
    [FieldOffset(720)] public int TileYOffset;
    [FieldOffset(724)] public int TileAttachesTo;
    [FieldOffset(728)] public int TileZAdjust;
    [FieldOffset(732)] public uint unk_2DC;
    [FieldOffset(736)] public Bool Morphable;
    [FieldOffset(737)] public Bool ShadowCaster;
    [FieldOffset(738)] public Bool AllowToPlace;
    [FieldOffset(739)] public Bool RequiredByRMG;
    [FieldOffset(740)] public uint unk_2E4;
    [FieldOffset(744)] public uint unk_2E8;
    [FieldOffset(748)] public uint unk_2EC;
    [FieldOffset(752)] public int unk_2F0;
    [FieldOffset(756)] public Bool unk_2F4;
    [FieldOffset(757)] public byte fileName;
    public FixedArray<byte> FileName => new(ref Unsafe.As<byte, byte>(ref fileName), 14);
    [FieldOffset(771)] public Bool AllowBurrowing;
    [FieldOffset(772)] public Bool AllowTiberium;
    [FieldOffset(776)] public uint unk_308;

}