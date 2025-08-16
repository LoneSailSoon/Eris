using Eris.YRSharp.FileFormats;
using Eris.YRSharp.String.Ansi;
using Eris.YRSharp.Utilities;

namespace Eris.YRSharp;

public static class FileSystem
{
    private const nint ppPipbrdShp = 0xAC1478;
    private const nint ppPipsShp = 0xAC147C;
    private const nint ppPips2Shp = 0xAC1480;
    private const nint ppTalkbublShp = 0xAC1484;
    private const nint ppWrenchShp = 0x89DDC8;
    private const nint ppPoweroffShp = 0x89DDC4;
    private const nint ppGrfxtxtShp = 0xA8F794;
    private const nint ppOregathShp = 0xB1CF98;
    private const nint ppDarkenShp = 0xB07BC0;
    private const nint ppGclock2Shp = 0xB0B484;

    public static ref Pointer<ShpStruct> PipbrdShp => ref ppPipbrdShp.Convert<Pointer<ShpStruct>>().Ref;
    public static ref Pointer<ShpStruct> PipsShp => ref ppPipsShp.Convert<Pointer<ShpStruct>>().Ref;
    public static ref Pointer<ShpStruct> Pips2Shp => ref ppPips2Shp.Convert<Pointer<ShpStruct>>().Ref;
    public static ref Pointer<ShpStruct> TalkbublShp => ref ppTalkbublShp.Convert<Pointer<ShpStruct>>().Ref;
    public static ref Pointer<ShpStruct> WrenchShp => ref ppWrenchShp.Convert<Pointer<ShpStruct>>().Ref;
    public static ref Pointer<ShpStruct> PoweroffShp => ref ppPoweroffShp.Convert<Pointer<ShpStruct>>().Ref;
    public static ref Pointer<ShpStruct> GrfxtxtShp => ref ppGrfxtxtShp.Convert<Pointer<ShpStruct>>().Ref;
    public static ref Pointer<ShpStruct> OregathShp => ref ppOregathShp.Convert<Pointer<ShpStruct>>().Ref;
    public static ref Pointer<ShpStruct> DarkenShp => ref ppDarkenShp.Convert<Pointer<ShpStruct>>().Ref;
    public static ref Pointer<ShpStruct> Gclock2Shp => ref ppGclock2Shp.Convert<Pointer<ShpStruct>>().Ref;

    private const nint pTemperatPal = 0x885780;
    private const nint pGrfxtxtPal = 0xA8F790;

    public static Pointer<BytePalette> TemperatPal => pTemperatPal;
    public static Pointer<BytePalette> GrfxtxtPal => pGrfxtxtPal.Convert<nint>().Data;

    private const nint ppCameoPal = 0x87F6B0;
    private const nint ppUniTxPal = 0x87F6B4;
    private const nint ppPalettePal = 0x87F6C4;
    private const nint ppxPal = 0x87F6B8;
    private const nint ppGrftxtTiberiumPal = 0x87F6BC;
    private const nint ppAnimPal = 0x87F6C0;
    private const nint ppTheaterPal = 0x87F6C4;
    private const nint ppMousePal = 0x87F6C8;
    private const nint ppGrfxtxtConvert = 0xA8F798;
    private const nint ppSidebarPal = 0x87F6CC;

    public static ref Pointer<ConvertClass> CameoPal => ref ppCameoPal.Convert<Pointer<ConvertClass>>().Ref;
    public static ref Pointer<ConvertClass> UniTxPal => ref ppUniTxPal.Convert<Pointer<ConvertClass>>().Ref;
    public static ref Pointer<ConvertClass> PalettePal => ref ppPalettePal.Convert<Pointer<ConvertClass>>().Ref;
    public static ref Pointer<ConvertClass> XPal => ref ppxPal.Convert<Pointer<ConvertClass>>().Ref;
    public static ref Pointer<ConvertClass> GrftxtTiberiumPal => ref ppGrftxtTiberiumPal.Convert<Pointer<ConvertClass>>().Ref;
    public static ref Pointer<ConvertClass> AnimPal => ref ppAnimPal.Convert<Pointer<ConvertClass>>().Ref;
    public static ref Pointer<ConvertClass> TheaterPal => ref ppTheaterPal.Convert<Pointer<ConvertClass>>().Ref;
    public static ref Pointer<ConvertClass> MousePal => ref ppMousePal.Convert<Pointer<ConvertClass>>().Ref;
    public static ref Pointer<ConvertClass> GrfxtxtConvert => ref ppGrfxtxtConvert.Convert<Pointer<ConvertClass>>().Ref;
    public static ref Pointer<ConvertClass> SidebarPal => ref ppSidebarPal.Convert<Pointer<ConvertClass>>().Ref;


    public static unsafe IntPtr LoadFile(string fileName, bool bLoadAsSHPReferenc = false)
    {
        using var span = new AnsiStringSpan(fileName);
        var func = (delegate* unmanaged[Thiscall]<int, IntPtr, Bool, IntPtr>)NativeCode.FastCallTransferStation;
        return func(0x5B40B0, span, bLoadAsSHPReferenc);
    }
    public static unsafe IntPtr LoadWholeFileEx(string fileName, out bool outAllocated)
    {
        using var span = new AnsiStringSpan(fileName);
        var temp = false;
        var func = (delegate* unmanaged[Thiscall]<int, IntPtr, nint, IntPtr>)NativeCode.FastCallTransferStation;
        var ret = func(0x4A38D0, span,temp.GetThisPointer());
    
        outAllocated = temp;
        return ret;
    }
    public static unsafe Pointer<T> LoadWholeFileEx<T>(string fileName, out bool outAllocated)
    {
        return LoadWholeFileEx(fileName, out outAllocated);
    }
    
    public static Pointer<ShpStruct> LoadSHPFile(string fileName)
    {
        return LoadFile(fileName, true);
    }
    
    public static unsafe Pointer<T> AllocateFile<T>(string fileName)
    {
        var file = YRCreater.Create<CCFileClass>().Constructor(fileName);//YRMemory.Create<CCFileClass>(fileName);
        var ret = file.Ref.BaseFile.ReadWholeFile();
        YRDeleter.Delete(file);
        return ret;
    }
    
    public static unsafe Pointer<BytePalette> AllocatePalette(string fileName)
    {
        var pal = AllocateFile<BytePalette>(fileName);
        if(pal.IsNull == false)
        {
            var buffer = pal.Ref.Entries;// (ColorStruct*)pal;
            for (int idx = 0; idx < BytePalette.EntriesCount; idx++)
            {
    
                buffer[idx].R <<= 2;
                buffer[idx].G <<= 2;
                buffer[idx].B <<= 2;
            }
        }
    
        return pal;
    }
}

[StructLayout(LayoutKind.Explicit)]
public struct VoxelStruct
{
}