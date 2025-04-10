using System.Runtime.InteropServices;
using PatcherYrSharp.GeneralDefinitions;
using PatcherYrSharp.GeneralStructures;
using PatcherYrSharp.Helpers;

namespace PatcherYrSharp;

[StructLayout(LayoutKind.Explicit, Size = 660)]
public struct ObjectTypeClass
{
    public unsafe CoordStruct Dimension2()
    {
        CoordStruct tmp = default;
        var func = (delegate* unmanaged[Thiscall]<ref ObjectTypeClass, ref CoordStruct, void>)this.GetVirtualFunctionPointer(31);
        func(ref this, ref tmp);
        return tmp;
    }
    public unsafe bool SpawnAtMapCoords(CellStruct mapCoords, Pointer<HouseClass> pOwner)
    {
        var func = (delegate* unmanaged[Thiscall]<ref ObjectTypeClass, ref CellStruct, IntPtr, Bool>)this.GetVirtualFunctionPointer(32);
        return func(ref this, ref mapCoords, pOwner);
    }
    public unsafe Pointer<ObjectClass> CreateObject(Pointer<HouseClass> pOwner)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)this.GetVirtualFunctionPointer(35);
        return func(this.GetThisPointer(), pOwner);
    }

    [FieldOffset(0)] public AbstractTypeClass Base;

    [FieldOffset(156)] public Armor Armor;
    [FieldOffset(160)] public int Strength;
    [FieldOffset(504)] public byte ImageFile_first;
    public AnsiStringPointer ImageFile => Pointer<byte>.AsPointer(ref ImageFile_first);
    [FieldOffset(531)] public byte AlphaImageFile_first;
    public AnsiStringPointer AlphaImageFile => Pointer<byte>.AsPointer(ref AlphaImageFile_first);

}
