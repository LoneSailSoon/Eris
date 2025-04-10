using System.Runtime.InteropServices;
using PatcherYrSharp.Helpers;

namespace PatcherYrSharp;

[StructLayout(LayoutKind.Explicit, Size = 152, Pack = 1)]
public struct AbstractTypeClass
{
    private const nint ArrayPointer = 0xA8E968;

    public static GlobalDvcArray<AbstractTypeClass> AbstractTypeArray = new GlobalDvcArray<AbstractTypeClass>(ArrayPointer);

    // public unsafe bool LoadFromINI(Pointer<CCINIClass> pINI)
    // {
    //     return LoadFromINI((int)this.GetThisPointer(), (int)pINI);
    // }
    //
    // [DllImport("YRPP.Private.CoreLib.dll")]
    // private extern static bool LoadFromINI(int pThis, int pIni);


    [FieldOffset(0)]
    public AbstractClass Base;

    [FieldOffset(36)] public byte ID_first;
    public AnsiStringPointer ID => Pointer<byte>.AsPointer(ref ID_first);

    [FieldOffset(61)] public byte UINameLabel_first;
    [FieldOffset(96)] public UniStringPointer UIName;

    [FieldOffset(100)] public byte Name_first;
}