using System.Runtime.InteropServices;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.String.Ansi;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp.FileFormats;

[StructLayout(LayoutKind.Sequential)]
public struct ShpStruct
{
    public static unsafe void Destructor(Pointer<ShpStruct> pThis)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)Helper.GetVirtualFunctionPointer(pThis, 0);
        func(pThis);
    }
    public unsafe void Load()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x69E090;
        func(this.GetThisPointer());
    }
    public unsafe void Unload()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x69E100;
        func(this.GetThisPointer());
    }
    public unsafe Pointer<ShpFile> GetData()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)0x69E580;
        return func(this.GetThisPointer());
    }
    public unsafe RectangleStruct GetFrameBounds(int idxFrame)
    {
        RectangleStruct tmp = default;
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int, nint>)0x69E7E0;
        func(this.GetThisPointer(), tmp.GetThisPointer(), idxFrame);
        return tmp;
    }
    public unsafe ColorStruct GetColor(int idxFrame)
    {
        ColorStruct tmp = default;
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int, nint>)0x69E860;
        func(this.GetThisPointer(), tmp.GetThisPointer(), idxFrame);
        return tmp;
    }
    public unsafe Pointer<byte> GetPixels(int idxFrame)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, nint>)0x69E740;
        return func(this.GetThisPointer(), idxFrame);
    }
    public unsafe bool HasCompression(int idxFrame)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, bool>)0x69E900;
        return func(this.GetThisPointer(), idxFrame);
    }
    public bool IsReference()
    {
        return Type == 0xFFFF;
    }
    public Pointer<ShpReference> AsReference()
    {
        return IsReference() ? Pointer<ShpStruct>.AsPointer(ref this).Convert<ShpReference>() : Pointer<ShpReference>.Zero;
    }
    public Pointer<ShpFile> AsFile()
    {
        return !IsReference() ? Pointer<ShpStruct>.AsPointer(ref this).Convert<ShpFile>() : Pointer<ShpFile>.Zero;
    }


    public ushort Type;
    public short Width;
    public short Height;
    public short Frames;
}

[StructLayout(LayoutKind.Explicit, Size = 36)]
public struct ShpReference
{
    public static unsafe void Constructor(Pointer<ShpReference> pThis, string fileName)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x69E430;
        func(pThis, new AnsiString(fileName));
    }
    public static unsafe void Destructor(Pointer<ShpReference> pThis)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)Helper.GetVirtualFunctionPointer(pThis, 0);
        func(pThis);
    }

    [FieldOffset(0)] public ShpStruct Base;
    [FieldOffset(8)] public AnsiStringPointer Filename;
    [FieldOffset(12)] public Pointer<ShpStruct> Data;
    [FieldOffset(16)] public Bool Loaded;
    [FieldOffset(20)] public int INdex;
    [FieldOffset(24)] public nint next;
    public Pointer<ShpReference> Next => next;
    [FieldOffset(28)] public nint prev;
    public Pointer<ShpReference> Prev => prev;
    [FieldOffset(32)] public uint _20;
}

[StructLayout(LayoutKind.Explicit, Size = 24)]
public struct ShpFrame
{
    [FieldOffset(0)] public short Left;
    [FieldOffset(2)] public short Top;
    [FieldOffset(4)] public short Width;
    [FieldOffset(6)] public short Height;
    [FieldOffset(8)] public uint Flags;
    [FieldOffset(12)] public ColorStruct Color;
    [FieldOffset(16)] public uint _10;
    [FieldOffset(20)] public int Offset;
}

[StructLayout(LayoutKind.Sequential)]
public struct ShpFile
{
    public ShpStruct Base;
    public ShpFrame FirstFrame;
    public Pointer<ShpFrame> Frames => Pointer<ShpFrame>.AsPointer(ref FirstFrame);
}