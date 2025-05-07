using System.Runtime.InteropServices;
using PatcherYrSharp.Helpers;

namespace PatcherYrSharp;

[StructLayout(LayoutKind.Explicit, Size = 88)]
public struct INIClass
{
    [StructLayout(LayoutKind.Explicit, Size = 68)]
    public struct INISection
    {
        [FieldOffset(0)] public GenericNode Base;

        [FieldOffset(12)] public AnsiStringPointer Name;

        [FieldOffset(16)] public YRList<INIEntry> Entries;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x1C)]
    public struct INIEntry
    {
        [FieldOffset(0)] public GenericNode Base;
        [FieldOffset(12)] public AnsiStringPointer Key;
        [FieldOffset(16)] public AnsiStringPointer Value;

    }

}

[StructLayout(LayoutKind.Explicit, Size = 88)]
public struct CCINIClass
{
    private static IntPtr ini_Rules_FileName = new IntPtr(0x826260); // rulesmd.ini
    private static string ruels_FileName = null;
    public static string INI_Ruels_FileName
    {
        get
        {
            if (null == ruels_FileName)
            {
                ruels_FileName = (AnsiStringPointer)ini_Rules_FileName;
            }
            return ruels_FileName;
        }
    }

    private static IntPtr ini_Art_FileName = new IntPtr(0x826254); // artmd.ini
    private static string art_fileName = null;
    public static string INI_Art_FileName
    {
        get
        {
            if (null == art_fileName)
            {
                art_fileName = (AnsiStringPointer)ini_Art_FileName;
            }
            return art_fileName;
        }
    }

    private static IntPtr ini_AI_FileName = new IntPtr(0x82621C); // aimd.ini
    private static string ai_FileName = null;
    public static string INI_AI_FileName
    {
        get
        {
            if (null == ai_FileName)
            {
                ai_FileName = (AnsiStringPointer)ini_AI_FileName;
            }
            return ai_FileName;
        }
    }


    private static IntPtr ppINI_Rules = new IntPtr(0x887048);
    private static IntPtr pINI_AI = new IntPtr(0x887128);
    private static IntPtr pINI_Art = new IntPtr(0x887180);

    private static IntPtr pINI_UIMD = new IntPtr(0x887208);
    private static IntPtr pINI_RA2MD = new IntPtr(0x8870C0);

    public static Pointer<CCINIClass> INI_Rules { get => ((Pointer<Pointer<CCINIClass>>)ppINI_Rules).Data; set => ((Pointer<Pointer<CCINIClass>>)ppINI_Rules).Ref = value; }
    public static Pointer<CCINIClass> INI_AI { get => pINI_AI; set => pINI_AI = value; }
    public static Pointer<CCINIClass> INI_Art { get => pINI_Art; set => pINI_Art = value; }

    public static Pointer<CCINIClass> INI_UIMD { get => pINI_UIMD; set => pINI_UIMD = value; }
    public static Pointer<CCINIClass> INI_RA2MD { get => pINI_RA2MD; set => pINI_RA2MD = value; }

    //Parses an INI file from a CCFile
    public unsafe Pointer<CCINIClass> ReadCCFile(Pointer<CCFileClass> pCCFile, byte bUnk = 0, int iUnk = 0)
    {
        var func = (delegate* unmanaged[Thiscall]<ref CCINIClass, IntPtr, byte, int, IntPtr>)0x4741F0;
        return func(ref this, pCCFile, bUnk, iUnk);
    }

    public unsafe void Reset()
    {
        var func = (delegate* unmanaged[Thiscall]<ref CCINIClass, void>)0x526B00;
        func(ref this);
    }
    public unsafe int GetKeyCount(AnsiString section)
    {
        var func = (delegate* unmanaged[Thiscall]<ref CCINIClass, IntPtr, int>)0x526960;
        return func(ref this, section);
    }
    public unsafe AnsiString GetKeyName(AnsiString section, int keyIndex)
    {
        var func = (delegate* unmanaged[Thiscall]<ref CCINIClass, IntPtr, int, IntPtr>)0x526CC0;
        return func(ref this, section, keyIndex);
    }

    public unsafe int ReadString(AnsiString section, AnsiString key, AnsiString def, byte[] buffer, int bufferSize)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint, byte[], int, int>)0x528A10;
        return func(this.GetThisPointer(), section, key, def, buffer, bufferSize);
    }

    public unsafe int ReadString(string section, string key, string def, byte[] buffer, int bufferSize)
    {
        using var pSection = new AnsiStringSpan(section);
        using var pKey = new AnsiStringSpan(key);
        using var pDef = new AnsiStringSpan(def);
        
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint, byte[], int, int>)0x528A10;
        return func(this.GetThisPointer(), pSection, pKey, pDef, buffer, bufferSize);
    }

    public unsafe int ReadString(nint section, nint key, nint def, byte[] buffer, int bufferSize)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint, byte[], int, int>)0x528A10;
        return func(this.GetThisPointer(), section, key, def, buffer, bufferSize);
    }

    public unsafe int ReadHouseTypesList(AnsiString section, AnsiString key, int def = 0)
    {
        var func = (delegate* unmanaged[Thiscall]<ref CCINIClass, IntPtr, IntPtr, int, int>)0x4750D0;
        return func(ref this, section, key, def);
    }

    public static unsafe void Constructor(Pointer<CCINIClass> pThis)
    {
        var func = (delegate* unmanaged[Thiscall]<ref CCINIClass, void>)0x535AA0;
        func(ref pThis.Ref);
        pThis.Ref.Digested = false;
        pThis.Convert<int>().Ref = 0x7E1AF4;
    }

    public static unsafe void Destructor(Pointer<CCINIClass> pThis)
    {
        var func = (delegate* unmanaged[Thiscall]<ref CCINIClass, Bool, void>)Helpers.Helper.GetVirtualFunctionPointer(pThis, 0);
        func(ref pThis.Ref, false);
    }

    [FieldOffset(0)] public INIClass Base;
    [FieldOffset(4)] public nint CurrentSectionName;
    [FieldOffset(12)] public YRList<INIClass.INISection> Sections;
    [FieldOffset(64)] public Bool Digested;
}

public static class IniClassHelper
{
    public static bool TryGetSection(this Pointer<CCINIClass> pIni, string section, out Pointer<INIClass.INISection> pSection) => (pSection = pIni.Ref.Sections.FirstOrDefault(o => o.IsNotNull && o.Ref.Name == section)).IsNotNull;
    public static bool TryGetEntries(this Pointer<INIClass.INISection> pSection, string entrie, out Pointer<INIClass.INIEntry> pEntries) => (pEntries = pSection.Ref.Entries.FirstOrDefault(o => o.IsNotNull && o.Ref.Key == entrie)).IsNotNull;
    public static bool GetString(this Pointer<CCINIClass> pIni, string section, string key, out string val)
    {
        val = null;
        if (null == section || null == key) return false;

        return pIni.TryGetSection(section, out Pointer<INIClass.INISection> pSection) && pSection.TryGetEntries(key, out Pointer<INIClass.INIEntry> pEntries) && !string.IsNullOrWhiteSpace((val = pEntries.Ref.Value));
    }
        
    public static Dictionary<string, string> ReadRegister(this Pointer<CCINIClass> pIni, string section)
    {
        if (pIni.TryGetSection(section, out var pSection))
        {
            Dictionary<string, string> dic = new();
            foreach(var entrie in pSection.Ref.Entries)
            {
                if (entrie)
                {
                    dic.Add(entrie.Ref.Key, entrie.Ref.Value);
                }
            }
            return dic;
        }
        return null;
    }
}