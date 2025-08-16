using Eris.YRSharp.String.Ansi;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 64)]
public struct IniClass
{
    [StructLayout(LayoutKind.Sequential)]
    public struct INIComment
    {
        public nint value;
        public AnsiStringPointer Value => value;
        public nint next;
        public Pointer<INIComment>  Next => next;
    }
    
    [StructLayout(LayoutKind.Explicit, Size = 40)]
    public struct IniEntry
    {
        [FieldOffset(0)] public GenericNode Base;
        [FieldOffset(12)] public AnsiStringPointer Key;
        [FieldOffset(16)] public AnsiStringPointer Value;
        [FieldOffset(20)] public nint comments;
        public Pointer<INIComment>  Comments => comments;
        [FieldOffset(24)]public nint  commentString;
        public AnsiStringPointer CommentString => commentString;
        [FieldOffset(28)]public int PreIndentCursor;
        [FieldOffset(32)]public int PostIndentCursor;
        [FieldOffset(36)]public int CommentCursor;
    }
    
    [StructLayout(LayoutKind.Explicit, Size = 68)]
    public struct IniSection
    {
        [FieldOffset(0)] public GenericNode Base;

        [FieldOffset(12)] public nint name;
        public AnsiStringPointer Name => name;

        [FieldOffset(16)] public YRList<IniEntry> Entries;
        //TODO:
        //IndexClass
        [FieldOffset(64)] public nint comments;
        public Pointer<INIComment>  Comments => comments;
    }

    [FieldOffset(0)] public nint vftable;
    [FieldOffset(4)] public nint CurrentSectionName;
    [FieldOffset(12)] public YRList<IniSection> Sections;
    //TODO:
    //IndexType
    [FieldOffset(60)]public nint  commentString;
    public AnsiStringPointer CommentString => commentString;
}

[StructLayout(LayoutKind.Explicit, Size = 88)]
public struct CCIniClass
{
    private const nint PIniRulesFileName = 0x826260; // rulesmd.ini
    private static string ruelsFileName;

    public static string IniRulesFileName => ruelsFileName ??= (AnsiStringPointer)PIniRulesFileName;

    private const nint PIniArtFileName = 0x826254; // artmd.ini
    private static string artFileName;

    public static string IniArtFileName => artFileName ??= (AnsiStringPointer)PIniArtFileName;

    private const nint PIniAiFileName = 0x82621C; // aimd.ini
    private static string aiFileName;

    public static string IniAiFileName => aiFileName ??= (AnsiStringPointer)PIniAiFileName;


    private const nint ppIniRules = 0x887048;
    private const nint pIniAi = 0x887128;
    private const nint pIniArt = 0x887180;
    private const nint pIniUimd = 0x887208;
    private const nint pIniRa2md = 0x8870C0;

    public static Pointer<CCIniClass> IniRules
    {
        get => ((Pointer<Pointer<CCIniClass>>)ppIniRules).Data;
        set => ((Pointer<Pointer<CCIniClass>>)ppIniRules).Ref = value;
    }

    public static Pointer<CCIniClass> IniAI => pIniAi;
    public static Pointer<CCIniClass> IniArt => pIniArt;

    public static Pointer<CCIniClass> IniUIMD => pIniUimd;
    public static Pointer<CCIniClass> IniRA2MD => pIniRa2md;

    //Parses an INI file from a CCFile
    public unsafe Pointer<CCIniClass> ReadCCFile(Pointer<CCFileClass> pCCFile, byte bUnk = 0, int iUnk = 0)
    {
        var func = (delegate* unmanaged[Thiscall]<ref CCIniClass, IntPtr, byte, int, IntPtr>)0x4741F0;
        return func(ref this, pCCFile, bUnk, iUnk);
    }

    public unsafe void Reset()
    {
        var func = (delegate* unmanaged[Thiscall]<ref CCIniClass, void>)0x526B00;
        func(ref this);
    }

    public unsafe int GetKeyCount(string section)
    {
        using var pSection = new AnsiStringSpan(section);
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int>)0x526960;
        return func(this.GetThisPointer(), pSection);
    }

    public unsafe AnsiString GetKeyName(AnsiString section, int keyIndex)
    {
        var func = (delegate* unmanaged[Thiscall]<ref CCIniClass, IntPtr, int, IntPtr>)0x526CC0;
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
        var func = (delegate* unmanaged[Thiscall]<ref CCIniClass, IntPtr, IntPtr, int, int>)0x4750D0;
        return func(ref this, section, key, def);
    }

    public unsafe Pointer<IniClass.IniSection> GetSection(AnsiString section)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)0x526810;
        return func(this.GetThisPointer(), section);
    }

    public unsafe Pointer<IniClass.IniSection> GetSection(string section)
    {
        using var pSection = new AnsiStringSpan(section);
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)0x526810;
        return func(this.GetThisPointer(), pSection);
    }

    public unsafe Pointer<IniClass.IniSection> GetSection(nint pSection)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)0x526810;
        return func(this.GetThisPointer(), pSection);
    }

    public static unsafe void Constructor(Pointer<CCIniClass> pThis)
    {
        var func = (delegate* unmanaged[Thiscall]<ref CCIniClass, void>)0x535AA0;
        func(ref pThis.Ref);
        pThis.Ref.Digested = false;
        pThis.Convert<int>().Ref = 0x7E1AF4;
    }

    public static unsafe void Destructor(Pointer<CCIniClass> pThis)
    {
        var func =
            (delegate* unmanaged[Thiscall]<ref CCIniClass, Bool, void>)Helper.GetVirtualFunctionPointer(pThis, 0);
        func(ref pThis.Ref, false);
    }

    [FieldOffset(0)] public IniClass Base;
    [FieldOffset(4)] public nint CurrentSectionName;
    [FieldOffset(12)] public YRList<IniClass.IniSection> Sections;
    [FieldOffset(64)] public Bool Digested;
    [FieldOffset(65)] public byte digest;
    public FixedArray<byte> Digest => new(ref digest, 20);
}