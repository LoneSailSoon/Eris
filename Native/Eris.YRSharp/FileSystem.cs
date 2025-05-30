﻿using Eris.YRSharp.FileFormats;
using Eris.YRSharp.GeneralStructures;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

public static class FileSystem
{
    private static IntPtr ppPIPBRD_SHP = new IntPtr(0xAC1478);
    private static IntPtr ppPIPS_SHP = new IntPtr(0xAC147C);
    private static IntPtr ppPIPS2_SHP = new IntPtr(0xAC1480);
    private static IntPtr ppTALKBUBL_SHP = new IntPtr(0xAC1484);
    private static IntPtr ppWRENCH_SHP = new IntPtr(0x89DDC8);
    private static IntPtr ppPOWEROFF_SHP = new IntPtr(0x89DDC4);
    private static IntPtr ppGRFXTXT_SHP = new IntPtr(0xA8F794);
    private static IntPtr ppOREGATH_SHP = new IntPtr(0xB1CF98);
    private static IntPtr ppDARKEN_SHP = new IntPtr(0xB07BC0);
    private static IntPtr ppGCLOCK2_SHP = new IntPtr(0xB0B484);

    public static ref Pointer<ShpStruct> PIPBRD_SHP => ref ppPIPBRD_SHP.Convert<Pointer<ShpStruct>>().Ref;
    public static ref Pointer<ShpStruct> PIPS_SHP => ref ppPIPS_SHP.Convert<Pointer<ShpStruct>>().Ref;
    public static ref Pointer<ShpStruct> PIPS2_SHP => ref ppPIPS2_SHP.Convert<Pointer<ShpStruct>>().Ref;
    public static ref Pointer<ShpStruct> TALKBUBL_SHP => ref ppTALKBUBL_SHP.Convert<Pointer<ShpStruct>>().Ref;
    public static ref Pointer<ShpStruct> WRENCH_SHP => ref ppWRENCH_SHP.Convert<Pointer<ShpStruct>>().Ref;
    public static ref Pointer<ShpStruct> POWEROFF_SHP => ref ppPOWEROFF_SHP.Convert<Pointer<ShpStruct>>().Ref;
    public static ref Pointer<ShpStruct> GRFXTXT_SHP => ref ppGRFXTXT_SHP.Convert<Pointer<ShpStruct>>().Ref;
    public static ref Pointer<ShpStruct> OREGATH_SHP => ref ppOREGATH_SHP.Convert<Pointer<ShpStruct>>().Ref;
    public static ref Pointer<ShpStruct> DARKEN_SHP => ref ppDARKEN_SHP.Convert<Pointer<ShpStruct>>().Ref;
    public static ref Pointer<ShpStruct> GCLOCK2_SHP => ref ppGCLOCK2_SHP.Convert<Pointer<ShpStruct>>().Ref;

    private static IntPtr pTEMPERAT_PAL = new IntPtr(0x885780);
    private static IntPtr pGRFXTXT_PAL = new IntPtr(0xA8F790);

    public static Pointer<BytePalette> TEMPERAT_PAL => pTEMPERAT_PAL;
    public static Pointer<BytePalette> GRFXTXT_PAL => pGRFXTXT_PAL;

    private static IntPtr ppCAMEO_PAL = new IntPtr(0x87F6B0);
    private static IntPtr ppUNITx_PAL = new IntPtr(0x87F6B4);
    private static IntPtr ppPALETTE_PAL = new IntPtr(0x87F6C4);
    private static IntPtr ppx_PAL = new IntPtr(0x87F6B8);
    private static IntPtr ppGRFTXT_TIBERIUM_PAL = new IntPtr(0x87F6BC);
    private static IntPtr ppANIM_PAL = new IntPtr(0x87F6C0);
    private static IntPtr ppTHEATER_PAL = new IntPtr(0x87F6C4);
    private static IntPtr ppMOUSE_PAL = new IntPtr(0x87F6C8);
    private static IntPtr ppGRFXTXT_Convert = new IntPtr(0xA8F798);
    private static IntPtr ppSIDEBAR_PAL = new IntPtr(0x87F6CC);

    public static ref Pointer<ConvertClass> CAMEO_PAL => ref ppCAMEO_PAL.Convert<Pointer<ConvertClass>>().Ref;
    public static ref Pointer<ConvertClass> UNITx_PAL => ref ppUNITx_PAL.Convert<Pointer<ConvertClass>>().Ref;
    public static ref Pointer<ConvertClass> PALETTE_PAL => ref ppPALETTE_PAL.Convert<Pointer<ConvertClass>>().Ref;
    public static ref Pointer<ConvertClass> x_PAL => ref ppx_PAL.Convert<Pointer<ConvertClass>>().Ref;
    public static ref Pointer<ConvertClass> GRFTXT_TIBERIUM_PAL => ref ppGRFTXT_TIBERIUM_PAL.Convert<Pointer<ConvertClass>>().Ref;
    public static ref Pointer<ConvertClass> ANIM_PAL => ref ppANIM_PAL.Convert<Pointer<ConvertClass>>().Ref;
    public static ref Pointer<ConvertClass> THEATER_PAL => ref ppTHEATER_PAL.Convert<Pointer<ConvertClass>>().Ref;
    public static ref Pointer<ConvertClass> MOUSE_PAL => ref ppMOUSE_PAL.Convert<Pointer<ConvertClass>>().Ref;
    public static ref Pointer<ConvertClass> GRFXTXT_Convert => ref ppGRFXTXT_Convert.Convert<Pointer<ConvertClass>>().Ref;
    public static ref Pointer<ConvertClass> SIDEBAR_PAL => ref ppSIDEBAR_PAL.Convert<Pointer<ConvertClass>>().Ref;


    // public static unsafe IntPtr LoadFile(string fileName, bool bLoadAsSHPReferenc = false)
    // {
    //     var func = (delegate* unmanaged[Thiscall]<int, IntPtr, Bool, IntPtr>)ASM.FastCallTransferStation;
    //     return func(0x5B40B0, new AnsiString(fileName), bLoadAsSHPReferenc);
    // }
    // public static unsafe IntPtr LoadWholeFileEx(string fileName, out bool outAllocated)
    // {
    //     var func = (delegate* unmanaged[Thiscall]<int, IntPtr, out Bool, IntPtr>)ASM.FastCallTransferStation;
    //     var ret = func(0x4A38D0, new AnsiString(fileName), out var tmp);
    //
    //     outAllocated = tmp;
    //     return ret;
    // }
    // public static unsafe Pointer<T> LoadWholeFileEx<T>(string fileName, out bool outAllocated)
    // {
    //     return LoadWholeFileEx(fileName, out outAllocated);
    // }
    //
    // public static Pointer<SHPStruct> LoadSHPFile(string fileName)
    // {
    //     return LoadFile(fileName, true);
    // }
    //
    // public static unsafe Pointer<T> AllocateFile<T>(string fileName)
    // {
    //     var file = YRMemory.Create<CCFileClass>(fileName);
    //     var ret = file.Ref.ReadWholeFile();
    //     YRMemory.Delete(file);
    //     return ret;
    // }
    //
    // public static unsafe Pointer<BytePalette> AllocatePalette(string fileName)
    // {
    //     var pal = AllocateFile<BytePalette>(fileName);
    //     if(pal.IsNull == false)
    //     {
    //         var buffer = pal.Ref.Entries;// (ColorStruct*)pal;
    //         for (int idx = 0; idx < BytePalette.EntriesCount; idx++)
    //         {
    //
    //             buffer[idx].R <<= 2;
    //             buffer[idx].G <<= 2;
    //             buffer[idx].B <<= 2;
    //         }
    //     }
    //
    //     return pal;
    // }
}