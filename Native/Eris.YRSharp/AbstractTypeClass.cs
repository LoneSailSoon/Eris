using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.String.Ansi;
using Eris.YRSharp.String.Uni;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 152, Pack = 1)]
public struct AbstractTypeClass
{
    private const nint ArrayPointer = 0xA8E968;

    public static readonly GlobalDvcArray<AbstractTypeClass> AbstractTypeArray = new(ArrayPointer);

    public unsafe void LoadTheaterSpecificArt(TheaterType thType)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, TheaterType, void>)this.GetVirtualFunctionPointer(24);
        func(this.GetThisPointer(), thType);
    }

    public unsafe void LoadFromINI(Pointer<CCIniClass> pIni)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)this.GetVirtualFunctionPointer(25);
        func(this.GetThisPointer(), pIni);
    }

    public unsafe void SaveToINI(Pointer<CCIniClass> pIni)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)this.GetVirtualFunctionPointer(26);
        func(this.GetThisPointer(), pIni);
    }

    [FieldOffset(0)] public AbstractClass Base;

    [FieldOffset(36)] public byte ID_first;
    public AnsiStringPointer ID => Pointer<byte>.AsPointer(ref ID_first);

    [FieldOffset(61)] public byte UINameLabel_first;
    [FieldOffset(96)] public UniStringPointer UIName;

    [FieldOffset(100)] public byte Name_first;
}