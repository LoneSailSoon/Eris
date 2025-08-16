using Eris.YRSharp.String.Ansi;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 4)]
public struct FileClass
{
    public unsafe AnsiStringPointer GetFileName()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)this.GetVirtualFunctionPointer(1);
        return func(this.GetThisPointer());
    }

    public unsafe AnsiStringPointer SetFileName(Pointer<char> pFileName)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)this.GetVirtualFunctionPointer(2);
        return func(this.GetThisPointer(), pFileName);
    }

    public unsafe bool CreateFile()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(3);
        return func(this.GetThisPointer());
    }

    public unsafe bool DeleteFile()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(4);
        return func(this.GetThisPointer());
    }

    public unsafe bool Exists(bool writeShared = true)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, bool>)this.GetVirtualFunctionPointer(5);
        return func(this.GetThisPointer(), writeShared);
    }

    public unsafe bool HasHandle()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(6);
        return func(this.GetThisPointer());
    }

    public unsafe bool Open(FileAccessMode access)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, FileAccessMode, bool>)this.GetVirtualFunctionPointer(7);
        return func(this.GetThisPointer(), access);
    }

    public unsafe bool OpenEx(Pointer<char> pFileName, FileAccessMode access)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, FileAccessMode, bool>)this.GetVirtualFunctionPointer(8);
        return func(this.GetThisPointer(), pFileName, access);
    }

    public unsafe int ReadBytes(nint pBuffer, int nNumBytes)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int, int>)this.GetVirtualFunctionPointer(9);
        return func(this.GetThisPointer(), pBuffer, nNumBytes);
    }

    public unsafe int Seek(int offset, FileSeekMode seek)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, FileSeekMode, int>)this.GetVirtualFunctionPointer(10);
        return func(this.GetThisPointer(), offset, seek);
    }

    public unsafe int GetFileSize()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(11);
        return func(this.GetThisPointer());
    }

    public unsafe int WriteBytes(nint pBuffer, int nNumBytes)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int, int>)this.GetVirtualFunctionPointer(12);
        return func(this.GetThisPointer(), pBuffer, nNumBytes);
    }

    public unsafe void Close()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(13);
        func(this.GetThisPointer());
    }

    public unsafe uint GetFileTime()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint>)this.GetVirtualFunctionPointer(14);
        return func(this.GetThisPointer());
    }

    public unsafe bool SetFileTime(uint FileTime)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, bool>)this.GetVirtualFunctionPointer(15);
        return func(this.GetThisPointer(), FileTime);
    }

    public unsafe void CDCheck(uint errorCode, bool bUnk, Pointer<char> pFilename)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, bool, nint, void>)this.GetVirtualFunctionPointer(16);
        func(this.GetThisPointer(), errorCode, bUnk, pFilename);
    }

    public unsafe nint ReadWholeFile()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)0x4A3890;
        return func(this.GetThisPointer());
    }


    [FieldOffset(0)] public nint vftable;
    [FieldOffset(4)] public Bool SkipCDCheck;
    [FieldOffset(5)] public byte padding_5;
    [FieldOffset(6)] public byte padding_6;
    [FieldOffset(7)] public byte padding_7;
}

[StructLayout(LayoutKind.Explicit, Size = 36)]
public struct RawFileClass
{
    public unsafe void Bias(int offset = 0, int length = -1)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, int, void>)0x65D2B0;
        func(this.GetThisPointer(), offset, length);
    }

    [FieldOffset(0)] public FileClass Base;
    
    [FieldOffset(4)] public FileAccessMode FileAccess;
    [FieldOffset(8)] public int FilePointer;
    [FieldOffset(12)] public int FileSize;
    [FieldOffset(16)] public nint Handle;
    [FieldOffset(20)] public nint fileName;
    public readonly AnsiStringPointer FileName => fileName;
    [FieldOffset(24)] public short unknown_short_1C;
    [FieldOffset(26)] public short unknown_short_1E;
    [FieldOffset(28)] public Bool FileNameAllocated;

}

[StructLayout(LayoutKind.Explicit, Size = 84)]
public struct BufferIOFileClass
{
    [FieldOffset(0)] public RawFileClass Base;
    [FieldOffset(0)] public FileClass BaseFile;
    
    [FieldOffset(36)] public Bool unknown_bool_24;
    [FieldOffset(37)] public Bool unknown_bool_25;
    [FieldOffset(38)] public Bool unknown_bool_26;
    [FieldOffset(39)] public Bool unknown_bool_27;
    [FieldOffset(40)] public Bool unknown_bool_28;
    [FieldOffset(41)] public Bool unknown_bool_29;
    [FieldOffset(44)] public uint unknown_2C;
    [FieldOffset(48)] public uint unknown_30;
    [FieldOffset(52)] public uint unknown_34;
    [FieldOffset(56)] public uint unknown_38;
    [FieldOffset(60)] public uint unknown_3C;
    [FieldOffset(64)] public uint unknown_40;
    [FieldOffset(68)] public int unknown_int_44;
    [FieldOffset(72)] public int unknown_int_48;
    [FieldOffset(76)] public uint unknown_4C;
    [FieldOffset(80)] public uint unknown_50;
}

[StructLayout(LayoutKind.Explicit, Size = 88)]
public struct CDFileClass
{
    [FieldOffset(0)] public BufferIOFileClass Base;
    [FieldOffset(0)] public FileClass BaseFile;
    [FieldOffset(84)] public Bool IsDisabled;
}

[StructLayout(LayoutKind.Explicit, Size = 108)]
public struct CCFileClass
{
    public static unsafe void Constructor(Pointer<CCFileClass> pThis, string fileName)
    {
        using var span = new AnsiStringSpan(fileName); 
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x4739F0;
        func(pThis, span);
    }
    
    public static unsafe void Destructor(Pointer<CCFileClass> pThis)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, void>)pThis.GetVirtualFunctionPointer(0);
        func(pThis, false);
    }


    [FieldOffset(0)] public CDFileClass Base;
    [FieldOffset(0)] public FileClass BaseFile;
    
    [FieldOffset(88)] public MemoryBuffer Buffer;
    [FieldOffset(100)] public uint Position;
    [FieldOffset(104)] public uint Availability;

}

[Flags]
public enum  FileAccessMode: uint {
    None = 0,
    Read = 1,
    Write = 2,
    ReadWrite = Read | Write
}

public enum FileSeekMode: uint {
    Set = 0, // SEEK_SET
    Current = 1, // SEEK_CUR
    End = 2 // SEEK_END
}