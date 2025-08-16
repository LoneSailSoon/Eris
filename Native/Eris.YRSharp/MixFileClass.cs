using Eris.YRSharp.String.Ansi;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct MixHeaderData
{
    [FieldOffset(0)] public uint ID;
    [FieldOffset(4)] public uint Offset;
    [FieldOffset(8)] public uint Size;
}


[StructLayout(LayoutKind.Explicit)]
public struct MixFileClass
{

    public const nint pMixes = 0xABEFD8;

    public static ref YRList<Pointer<MixFileClass>> Mixes => ref pMixes.Convert<YRList<Pointer<MixFileClass>>>().Ref;

    public const nint pArray = 0x884D90;

    public static ref DynamicVectorClass<Pointer<MixFileClass>> Array => ref pArray.Convert<DynamicVectorClass<Pointer<MixFileClass>>>().Ref;

    public const nint pArrayAlt = 0x884DC0;

    public static ref DynamicVectorClass<Pointer<MixFileClass>> ArrayAlt => ref pArrayAlt.Convert<DynamicVectorClass<Pointer<MixFileClass>>>().Ref;

    public const nint pMaps = 0x884DA8;

    public static ref DynamicVectorClass<Pointer<MixFileClass>> Maps => ref pMaps.Convert<DynamicVectorClass<Pointer<MixFileClass>>>().Ref;

    public const nint pMovies = 0x884DE0;

    public static ref DynamicVectorClass<Pointer<MixFileClass>> Movies => ref pMovies.Convert<DynamicVectorClass<Pointer<MixFileClass>>>().Ref;

    public const nint pMultimd = 0x884DD8;

    public static ref MixFileClass Multimd => ref pMultimd.Convert<MixFileClass>().Ref;

    public const nint pMulti = 0x884DDC;

    public static ref MixFileClass Multi => ref pMulti.Convert<MixFileClass>().Ref;

    public const nint pGenerics = 0x884DF8;

    public static ref GenericMixFiles Generics => ref pGenerics.Convert<GenericMixFiles>().Ref;
    
    
    [FieldOffset(0)] public GenericNode Base;
    
    [FieldOffset(12)] public nint fileName;
    public AnsiStringPointer FileName => fileName;
    [FieldOffset(16)] public Bool Blowfish;
    [FieldOffset(17)] public Bool Encryption;
    [FieldOffset(20)] public int CountFiles;
    [FieldOffset(24)] public int FileSize;
    [FieldOffset(28)] public int FileStartOffset;
    [FieldOffset(32)] public nint headers;
    public Pointer<MixHeaderData> Headers => headers;
    [FieldOffset(36)] public int field_24;

}

[StructLayout(LayoutKind.Explicit)]
public struct GenericMixFiles
{
    [FieldOffset(0)] public nint ra2Md;
    public Pointer<MixFileClass> Ra2Md => ra2Md;
    [FieldOffset(4)] public nint ra2;
    public Pointer<MixFileClass> Ra2 => ra2;
    [FieldOffset(8)] public nint language;
    public Pointer<MixFileClass> Language => language;
    [FieldOffset(12)] public nint langmd;
    public Pointer<MixFileClass> Langmd => langmd;
    [FieldOffset(16)] public nint theaterTemperat;
    public Pointer<MixFileClass> TheaterTemperat => theaterTemperat;
    [FieldOffset(20)] public nint theaterTemperatmd;
    public Pointer<MixFileClass> TheaterTemperatmd => theaterTemperatmd;
    [FieldOffset(24)] public nint theaterTem;
    public Pointer<MixFileClass> TheaterTem => theaterTem;
    [FieldOffset(28)] public nint generic;
    public Pointer<MixFileClass> Generic => generic;
    [FieldOffset(32)] public nint genermd;
    public Pointer<MixFileClass> Genermd => genermd;
    [FieldOffset(36)] public nint theaterIsotemp;
    public Pointer<MixFileClass> TheaterIsotemp => theaterIsotemp;
    [FieldOffset(40)] public nint theaterIsotem;
    public Pointer<MixFileClass> TheaterIsotem => theaterIsotem;
    [FieldOffset(44)] public nint isogen;
    public Pointer<MixFileClass> Isogen => isogen;
    [FieldOffset(48)] public nint isogenmd;
    public Pointer<MixFileClass> Isogenmd => isogenmd;
    [FieldOffset(52)] public nint movieS02D;
    public Pointer<MixFileClass> MovieS02D => movieS02D;
    [FieldOffset(56)] public nint unknown1;
    public Pointer<MixFileClass> Unknown1 => unknown1;
    [FieldOffset(60)] public nint main;
    public Pointer<MixFileClass> Main => main;
    [FieldOffset(64)] public nint conqmd;
    public Pointer<MixFileClass> Conqmd => conqmd;
    [FieldOffset(68)] public nint conquer;
    public Pointer<MixFileClass> Conquer => conquer;
    [FieldOffset(72)] public nint cameomd;
    public Pointer<MixFileClass> Cameomd => cameomd;
    [FieldOffset(76)] public nint cameo;
    public Pointer<MixFileClass> Cameo => cameo;
    [FieldOffset(80)] public nint cachemd;
    public Pointer<MixFileClass> Cachemd => cachemd;
    [FieldOffset(84)] public nint cache;
    public Pointer<MixFileClass> Cache => cache;
    [FieldOffset(88)] public nint localmd;
    public Pointer<MixFileClass> Localmd => localmd;
    [FieldOffset(92)] public nint local;
    public Pointer<MixFileClass> Local => local;
    [FieldOffset(96)] public nint ntrlmd;
    public Pointer<MixFileClass> Ntrlmd => ntrlmd;
    [FieldOffset(100)] public nint neutral;
    public Pointer<MixFileClass> Neutral => neutral;
    [FieldOffset(104)] public nint mapsmD02D;
    public Pointer<MixFileClass> MapsmD02D => mapsmD02D;
    [FieldOffset(108)] public nint mapS02D;
    public Pointer<MixFileClass> MapS02D => mapS02D;
    [FieldOffset(112)] public nint unknown2;
    public Pointer<MixFileClass> Unknown2 => unknown2;
    [FieldOffset(116)] public nint unknown3;
    public Pointer<MixFileClass> Unknown3 => unknown3;
    [FieldOffset(120)] public nint sideC02Dmd;
    public Pointer<MixFileClass> SideC02Dmd => sideC02Dmd;
    [FieldOffset(124)] public nint sideC02D;
    public Pointer<MixFileClass> SideC02D => sideC02D;
}