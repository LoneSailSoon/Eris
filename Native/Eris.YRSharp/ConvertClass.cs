﻿using System.Runtime.InteropServices;
using Eris.YRSharp.GeneralStructures;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 392)]
public struct ConvertClass
{
    static public readonly IntPtr ArrayPointer = new IntPtr(0x89ECF8);
    //static public YRPP.GLOBAL_DVC_ARRAY<ConvertClass> GLOBAL_ARRAY = new YRPP.GLOBAL_DVC_ARRAY<ConvertClass>(ArrayPointer);

    public static void Constructor(Pointer<ConvertClass> pThis, Pointer<BytePalette> palette, Pointer<BytePalette> palette2, Pointer<Surface> pSurface, uint ShadeCount, bool skipBlitters)
    {
        _constructor(pThis, palette, palette2, pSurface, ShadeCount, skipBlitters);
    }
    public static unsafe void _constructor(Pointer<ConvertClass> pThis, Pointer<BytePalette> palette, Pointer<BytePalette> palette2, Pointer<Surface> pSurface, uint ShadeCount, bool skipBlitters)
    {
        var func = (delegate* unmanaged[Thiscall]<IntPtr, IntPtr, IntPtr, IntPtr, uint, Bool, IntPtr>)0x48E740;
        func(pThis, palette, palette2, pSurface, ShadeCount, skipBlitters);
    }


    [FieldOffset(0)] public int Vfptr;

    [FieldOffset(4)] public int LeanAndMean;
    // [FieldOffset(8)] public Pointer<BlitterCore> Blitters_first;
    // public Pointer<Pointer<BlitterCore>> Blitters => Pointer<Pointer<BlitterCore>>.AsPointer(ref Blitters_first);
    [FieldOffset(364)] public int Count;
    [FieldOffset(368)] public Pointer<byte> BufferA;
    [FieldOffset(372)] public Pointer<byte> Midpoint;
    [FieldOffset(376)] public Pointer<byte> BufferB;
    [FieldOffset(380)] public int f_17C;
    [FieldOffset(384)] public int f_180;
    [FieldOffset(388)] public int f_184;
}

[StructLayout(LayoutKind.Explicit, Size = 436)]
public struct LightConvertClass
{
    static public readonly IntPtr ArrayPointer = new IntPtr(0x87F698);
    //static public YRPP.GLOBAL_DVC_ARRAY<LightConvertClass> GLOBAL_ARRAY = new YRPP.GLOBAL_DVC_ARRAY<LightConvertClass>(ArrayPointer);

    [FieldOffset(0)] public ConvertClass Base;

    [FieldOffset(392)] public Pointer<BytePalette> UsedPalette1;
    [FieldOffset(396)] public Pointer<BytePalette> UsedPalette2;
    [FieldOffset(400)] public IntPtr _190;
    [FieldOffset(404)] public int UsageCount;
    [FieldOffset(408)] public TintStruct Color1;
    [FieldOffset(420)] public TintStruct Color2;
    [FieldOffset(432)] public byte _1B0;
}