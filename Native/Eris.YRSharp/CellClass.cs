﻿using System.Formats.Asn1;
using System.Runtime.InteropServices;
using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

[Flags]
public enum CellFlags
{
    None = 0,
    IsWaypoint = 0x4,
    Explored = 0x8,

    Bridge = 0x100
}

[StructLayout(LayoutKind.Explicit, Size = 328)]
public struct CellClass
{
    // get content objects
    public unsafe Pointer<TechnoClass> FindTechnoNearestTo(Point2D offsetPixel, bool alt, Pointer<TechnoClass> pExcludeThis)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, nint, nint>)0x47C3D0;
        return func(this.GetThisPointer(), offsetPixel.GetThisPointer(), alt, pExcludeThis);
    }

    public unsafe Pointer<ObjectClass> FindObjectOfType(AbstractType abs, bool alt)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, AbstractType, bool, nint>)0x47C4D0;
        return func(this.GetThisPointer(), abs, alt);
    }

    public unsafe Pointer<BuildingClass> GetBuilding()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)0x47C520;
        return func(this.GetThisPointer());
    }

    public unsafe Pointer<UnitClass> GetUnit(bool alt)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, nint>)0x47EBA0;
        return func(this.GetThisPointer(), alt);
    }

    public unsafe Pointer<InfantryClass> GetInfantry(bool alt)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, nint>)0x47EC40;
        return func(this.GetThisPointer(), alt);
    }

    public unsafe Pointer<AircraftClass> GetAircraft(bool alt)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, nint>)0x47EBF0;
        return func(this.GetThisPointer(), alt);
    }

    // public unsafe Pointer<TerrainClass> GetTerrain(bool alt)
    // {
    //     var func = (delegate* unmanaged[Thiscall]<ref CellClass, Bool, IntPtr>)0x47C550;
    //     return func(ref this, alt);
    // }

    /* craziest thing... first iterates Content looking to Aircraft,
     * failing that, calls FindTechnoNearestTo,
     * if that fails too, reiterates Content looking for Terrain
     */
    public unsafe Pointer<ObjectClass> GetSomeObject(CoordStruct coords, bool alt)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, nint>)0x47C5A0;
        return func(this.GetThisPointer(), coords.GetThisPointer(), alt);
    }


    public unsafe void SetupLAT()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x47CA80;
        func(this.GetThisPointer());
    }
    public unsafe void Setup(int unk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x47D2B0;
        func(this.GetThisPointer(), unk);
    }

    public unsafe bool CanThisExistHere(SpeedType speedType, Pointer<BuildingTypeClass> pObject, Pointer<HouseClass> pOwner)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, bool>)0x47C620;
        return func(this.GetThisPointer(), pObject, pOwner);
    }

    public unsafe bool CanPutTiberium()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, bool>)0x4838E0;
        return func(this.GetThisPointer(), 0);
    }

    public unsafe Pointer<CellClass> GetNeighbourCell(Direction direction)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, Direction, nint>)0x481810;
        return func(this.GetThisPointer(), direction);
    }

    public unsafe void CollectCrate(Pointer<FootClass> pCollector)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x481A00;
        func(this.GetThisPointer(), pCollector);
    }

    // returns the tiberium's index in OverlayTypes
    public unsafe int GetContainedTiberiumIndex()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)0x485010;
        return func(this.GetThisPointer());
    }
    public unsafe int GetContainedTiberiumValue()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)0x485020;
        return func(this.GetThisPointer());
    }

    // add or create tiberium of the specified type
    public unsafe bool IncreaseTiberium(int idxTiberium, int amount)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, int, bool>)0x487190;
        return func(this.GetThisPointer(), idxTiberium, amount);
    }
    public unsafe bool ReduceTiberium(int amount)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, bool>)0x480A80;
        return func(this.GetThisPointer(), amount);
    }

    public unsafe int GetFloorHeight(Point2D subCoords)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int>)0x47B3A0;
        return func(this.GetThisPointer(), subCoords.GetThisPointer());
    }

    public unsafe CoordStruct GetCenterCoords()
    {
        CoordStruct centerCoords = default;
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)0x480A30;
        func(this.GetThisPointer(), centerCoords.GetThisPointer());
        return centerCoords;
    }


    public bool ContainsBridge()
    {
        return this.Flags.HasFlag(CellFlags.Bridge);
    }

    public Pointer<ObjectClass> GetContent()
    {
        return this.ContainsBridge() ? this.AltObject : this.FirstObject;
    }

    public int GetLevel()
    {
        return this.Level + (this.ContainsBridge() ? Game.BridgeLevels : 0);
    }

    public static CoordStruct Cell2Coord(CellStruct cell, int z = 0)
    {
        return new CoordStruct(cell.X * Game.CellSize + 128, cell.Y * Game.CellSize + 128, z);
    }
    public static CellStruct Coord2Cell(CoordStruct crd)
    {
        return new CellStruct(crd.X / Game.CellSize, crd.Y / Game.CellSize);
    }

    public CoordStruct FixHeight(CoordStruct crd)
    {
        if (this.ContainsBridge())
        {
            crd.Z += Game.BridgeHeight;
        }
        return crd;
    }

    public CoordStruct GetCoordsWithBridge()
    {
        return this.FixHeight(this.Base.GetCoords());
    }

    public unsafe void MarkForRedraw()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x486E70;
        func(this.GetThisPointer());
    }
    public unsafe CoordStruct FindInfantrySubposition(CoordStruct coords, bool ignoreContents, bool alt, bool useCellCoords)
    {
        CoordStruct subPosition = default;
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, bool, bool, bool, void>)0x481180;
        func(this.GetThisPointer(), subPosition.GetThisPointer(), coords.GetThisPointer(), ignoreContents, alt, useCellCoords);
        return subPosition;
    }
    public unsafe bool TryAssignJumpjet(Pointer<FootClass> pObject)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x487D70;
        return func(this.GetThisPointer(), pObject);
    }
    public unsafe void AddContent(Pointer<ObjectClass> pContent, bool onBridge)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, void>)0x47E8A0;
        func(this.GetThisPointer(), pContent, onBridge);
    }
    public unsafe void RemoveContent(Pointer<ObjectClass> pContent, bool onBridge)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, void>)0x47EA90;
        func(this.GetThisPointer(), pContent, onBridge);
    }


    public unsafe bool IsClearToMove(SpeedType speedType, bool ignoreInfantry, bool ignoreVehicles, int zone, MovementZone movementZone, int level, bool isBridge)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, SpeedType, bool, bool, int, MovementZone, int, bool, bool>)0x4834A0;
        return func(this.GetThisPointer(), speedType, ignoreInfantry, ignoreVehicles, zone, movementZone, level, isBridge);
    }

    [FieldOffset(0)]
    public AbstractClass Base;

    [FieldOffset(36)] public CellStruct MapCoords;   //Where on the map does this Cell lie?

    [FieldOffset(44)] private IntPtr bridgeOwnerCell;
    public Pointer<CellClass> BridgeOwnerCell { get => bridgeOwnerCell; set => bridgeOwnerCell = value; }

    [FieldOffset(56)] public int IsoTileTypeIndex;   //What tile is this Cell?
    [FieldOffset(60)] public Pointer<TagClass> AttachedTag;          // The cell tag
    [FieldOffset(64)] public Pointer<BuildingTypeClass> Rubble;              // The building type that provides the rubble image
    [FieldOffset(68)] public int OverlayTypeIndex;   //What Overlay lies on this Cell?
    [FieldOffset(72)] public int SmudgeTypeIndex;    //What Smudge lies on this Cell?

    [FieldOffset(80)] public int WallOwnerIndex; // Which House owns the wall placed in this Cell? // Determined by finding the nearest BuildingType and taking its owner
    [FieldOffset(84)] public int InfantryOwnerIndex;
    [FieldOffset(88)] public int AltInfantryOwnerIndex;

    [FieldOffset(120)] public uint CloakedByHouses;


    [FieldOffset(224)] public Pointer<FootClass> Jumpjet; // a jumpjet occupying this cell atm
    [FieldOffset(228)] public Pointer<ObjectClass> FirstObject;   //The first Object on this Cell. NextObject functions as a linked list.
    [FieldOffset(232)] public Pointer<ObjectClass> AltObject;
    [FieldOffset(236)] public LandType LandType;  //What type of floor is this Cell?
    [FieldOffset(240)] public double RadLevel;  //The level of radiation on this Cell.

    [FieldOffset(256)] public int OccupyHeightsCoveringMe;

    [FieldOffset(282)] public byte Height;
    [FieldOffset(283)] public byte Level;
    [FieldOffset(284)] public byte SlopeIndex;  // this + 2 == cell's slope shape as reflected by PLACE.SHP

    [FieldOffset(286)] public byte Powerup; //The crate type on this cell. Also indicates some other weird properties


    [FieldOffset(288)] public byte Shroudedness; // trust me, you don't wanna know... if you do, see 0x7F4194 and cry
    [FieldOffset(289)] public byte Foggedness; // same value as above: -2: Occluded completely, -1: Visible, 0...48: frame in fog.shp or shroud.shp
    [FieldOffset(290)] public byte BlockedNeighbours; // number of somehow occupied cells next to this

    [FieldOffset(292)] public uint OccupationFlags; // 0x1F: infantry subpositions: center, TL, TR, BL, BR
    [FieldOffset(296)] public uint AltOccupationFlags; // 0x20: Units, 0x40: Objects, Aircraft, Overlay, 0x80: Building

    [FieldOffset(300)] public int CopyFlags;    // related to Flags below

    [FieldOffset(304)] public int ShroudCounter;
    [FieldOffset(308)] public uint GapsCoveringThisCell; // actual count of gapgens in this cell, no idea why they need a second layer
    [FieldOffset(312)] public Bool VisibilityChanged;

    [FieldOffset(320)] public CellFlags Flags;

}