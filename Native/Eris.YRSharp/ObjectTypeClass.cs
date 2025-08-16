using System.Runtime.CompilerServices;
using Eris.YRSharp.FileFormats;
using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.String.Ansi;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 660)]
public struct ObjectTypeClass
{
    public unsafe CoordStruct Dimension2()
    {
        CoordStruct tmp = default;
        var func =
            (delegate* unmanaged[Thiscall]<ref ObjectTypeClass, ref CoordStruct, void>)
            this.GetVirtualFunctionPointer(31);
        func(ref this, ref tmp);
        return tmp;
    }

    public unsafe bool SpawnAtMapCoords(CellStruct mapCoords, Pointer<HouseClass> pOwner)
    {
        var func =
            (delegate* unmanaged[Thiscall]<ref ObjectTypeClass, ref CellStruct, IntPtr, Bool>)this
                .GetVirtualFunctionPointer(32);
        return func(ref this, ref mapCoords, pOwner);
    }


    public unsafe Pointer<CoordStruct> vt_entry_6C(Pointer<CoordStruct> pDest, Pointer<CoordStruct> pSrc)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint>)this.GetVirtualFunctionPointer(27);
        return func(this.GetThisPointer(), pDest, pSrc);
    }

    public unsafe uint GetOwners()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint>)this.GetVirtualFunctionPointer(28);
        return func(this.GetThisPointer());
    }

    public unsafe int GetPipMax()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(29);
        return func(this.GetThisPointer());
    }

    public unsafe void vt_entry_78(uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, void>)this.GetVirtualFunctionPointer(30);
        func(this.GetThisPointer(), dwUnk);
    }

    public unsafe void Dimension2(Pointer<CoordStruct> pDest)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)this.GetVirtualFunctionPointer(31);
        func(this.GetThisPointer(), pDest);
    }

    public unsafe bool SpawnAtMapCoords(Pointer<CellStruct> pMapCoords, Pointer<HouseClass> pOwner)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, bool>)this.GetVirtualFunctionPointer(32);
        return func(this.GetThisPointer(), pMapCoords, pOwner);
    }

    public unsafe int GetActualCost(Pointer<HouseClass> pHouse)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int>)this.GetVirtualFunctionPointer(33);
        return func(this.GetThisPointer(), pHouse);
    }

    public unsafe int GetBuildSpeed()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(34);
        return func(this.GetThisPointer());
    }

    public unsafe Pointer<ObjectClass> CreateObject(Pointer<HouseClass> pOwner)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)this.GetVirtualFunctionPointer(35);
        return func(this.GetThisPointer(), pOwner);
    }

    public unsafe Pointer<CellStruct> GetFoundationData(bool IncludeBib)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, nint>)this.GetVirtualFunctionPointer(36);
        return func(this.GetThisPointer(), IncludeBib);
    }

    public unsafe Pointer<BuildingClass> FindFactory(bool allowOccupied, bool requirePower, bool requireCanBuild,
        Pointer<HouseClass> pHouse)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, bool, bool, bool, nint, nint>)this.GetVirtualFunctionPointer(37);
        return func(this.GetThisPointer(), allowOccupied, requirePower, requireCanBuild, pHouse);
    }

    public unsafe Pointer<ShpStruct> GetCameo()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)this.GetVirtualFunctionPointer(38);
        return func(this.GetThisPointer());
    }

    public unsafe Pointer<ShpStruct> GetImage()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)this.GetVirtualFunctionPointer(39);
        return func(this.GetThisPointer());
    }


    [FieldOffset(0)] public AbstractTypeClass Base;

    [FieldOffset(156)] public Armor Armor;
    [FieldOffset(160)] public int Strength;
    [FieldOffset(504)] public byte ImageFile_first;
    public AnsiStringPointer ImageFile => Pointer<byte>.AsPointer(ref ImageFile_first);
    [FieldOffset(531)] public byte AlphaImageFile_first;
    public AnsiStringPointer AlphaImageFile => Pointer<byte>.AsPointer(ref AlphaImageFile_first);


    [FieldOffset(152)] public ColorStruct RadialColor;
    [FieldOffset(155)] public byte unused_9B;
    [FieldOffset(164)] public nint image;
    public Pointer<ShpStruct> Image => image;
    [FieldOffset(168)] public Bool ImageAllocated;
    [FieldOffset(172)] public nint alphaImage;
    public Pointer<ShpStruct> AlphaImage => alphaImage;
    [FieldOffset(176)] public VoxelStruct MainVoxel;
    [FieldOffset(184)] public VoxelStruct TurretVoxel;
    [FieldOffset(192)] public VoxelStruct BarrelVoxel;
    [FieldOffset(200)] public byte chargerTurrets;
    public FixedArray<VoxelStruct> ChargerTurrets => new(ref Unsafe.As<byte, VoxelStruct>(ref chargerTurrets), 18);
    [FieldOffset(344)] public byte chargerBarrels;
    public FixedArray<VoxelStruct> ChargerBarrels => new(ref Unsafe.As<byte, VoxelStruct>(ref chargerBarrels), 18);
    [FieldOffset(488)] public Bool NoSpawnAlt;
    [FieldOffset(492)] public int MaxDimension;
    [FieldOffset(496)] public int CrushSound;
    [FieldOffset(500)] public int AmbientSound;
    [FieldOffset(529)] public Bool AlternateArcticArt;
    [FieldOffset(530)] public Bool ArcticArtInUse;
    [FieldOffset(556)] public Bool Theater;
    [FieldOffset(557)] public Bool Crushable;
    [FieldOffset(558)] public Bool Bombable;
    [FieldOffset(559)] public Bool RadarInvisible;
    [FieldOffset(560)] public Bool Selectable;
    [FieldOffset(561)] public Bool LegalTarget;
    [FieldOffset(562)] public Bool Insignificant;
    [FieldOffset(563)] public Bool Immune;
    [FieldOffset(564)] public Bool IsLogic;
    [FieldOffset(565)] public Bool AllowCellContent;
    [FieldOffset(566)] public Bool Voxel;
    [FieldOffset(567)] public Bool NewTheater;
    [FieldOffset(568)] public Bool HasRadialIndicator;
    [FieldOffset(569)] public Bool IgnoresFirestorm;
    [FieldOffset(570)] public Bool UseLineTrail;
    [FieldOffset(571)] public ColorStruct LineTrailColor;
    [FieldOffset(576)] public int LineTrailColorDecrement;


}

