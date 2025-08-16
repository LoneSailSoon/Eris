using System.Runtime.CompilerServices;
using Eris.YRSharp.Blitters;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 392)]
public struct ConvertClass
{
    public const nint ArrayPointer = 0x89ECF8;

    public static ref DynamicVectorClass<Pointer<ConvertClass>> Arraay =>
        ref DynamicVectorClass<Pointer<ConvertClass>>.GetDynamicVector(ArrayPointer);

    public static void Constructor(Pointer<ConvertClass> pThis, Pointer<BytePalette> palette, Pointer<BytePalette> palette2, Pointer<Surface> pSurface, uint ShadeCount, bool skipBlitters)
    {
        _constructor(pThis, palette, palette2, pSurface, ShadeCount, skipBlitters);
    }
    public static unsafe void _constructor(Pointer<ConvertClass> pThis, Pointer<BytePalette> palette, Pointer<BytePalette> palette2, Pointer<Surface> pSurface, uint ShadeCount, bool skipBlitters)
    {
        var func = (delegate* unmanaged[Thiscall]<IntPtr, IntPtr, IntPtr, IntPtr, uint, Bool, IntPtr>)0x48E740;
        func(pThis, palette, palette2, pSurface, ShadeCount, skipBlitters);
    }

    public unsafe Pointer<Blitter> SelectPlainBlitter(BlitterFlags flags)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, BlitterFlags, nint>)0x490B90;
        return func(this.GetThisPointer(), flags);
    }
    public unsafe Pointer<RLEBlitter> SelectRLEBlitter(BlitterFlags flags)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, BlitterFlags, nint>)0x490E50;
        return func(this.GetThisPointer(), flags);
    }


    [FieldOffset(0)] public int Vfptr;
    
    [FieldOffset(4)] public int BytesPerPixel;
    [FieldOffset(8)] public nint blitters;
    public FixedArray<Pointer<Blitter>> Blitters => new(ref Unsafe.As<nint, Pointer<Blitter>>(ref blitters), 50);
    [FieldOffset(208)] public nint rLEBlitters;
    public FixedArray<Pointer<RLEBlitter>> RLEBlitters => new(ref Unsafe.As<nint, Pointer<RLEBlitter>>(ref rLEBlitters), 39);
    [FieldOffset(364)] public int ShadeCount;
    [FieldOffset(368)] public nint fullColorData;
    public readonly Pointer<byte> FullColorData => fullColorData;
    [FieldOffset(372)] public nint paletteData;
    public readonly Pointer<byte> PaletteData => paletteData;
    [FieldOffset(376)] public nint byteColorData;
    public readonly Pointer<byte> ByteColorData => byteColorData;
    [FieldOffset(380)] public uint CurrentZRemap;
    [FieldOffset(384)] public uint HalfTranslucencyMask;
    [FieldOffset(388)] public uint QuatTranslucencyMask;

}

[StructLayout(LayoutKind.Explicit, Size = 436)]
public struct LightConvertClass
{
    static public readonly IntPtr ArrayPointer = new IntPtr(0x87F698);
    //static public YRPP.GLOBAL_DVC_ARRAY<LightConvertClass> GLOBAL_ARRAY = new YRPP.GLOBAL_DVC_ARRAY<LightConvertClass>(ArrayPointer);

    [FieldOffset(0)] public ConvertClass Base;

    [FieldOffset(392)] public nint usedPalette1;
    public readonly Pointer<BytePalette> UsedPalette1 => usedPalette1;
    [FieldOffset(396)] public nint usedPalette2;
    public readonly Pointer<BytePalette> UsedPalette2 => usedPalette2;
    [FieldOffset(400)] public nint indexesToIgnore;
    public readonly Pointer<byte> IndexesToIgnore => indexesToIgnore;
    [FieldOffset(404)] public int RefCount;
    [FieldOffset(408)] public TintStruct Color1;
    [FieldOffset(420)] public TintStruct Color2;
    [FieldOffset(432)] public Bool Tinted;
}