using System.Runtime.InteropServices;
using PatcherYrSharp.GeneralDefinitions;
using PatcherYrSharp.GeneralStructures;
using PatcherYrSharp.Helpers;

namespace PatcherYrSharp;

[StructLayout(LayoutKind.Explicit, Size = 4468)]
public struct MapClass
{
    private const nint instance = 0x87F7E8;
    public static ref MapClass Instance => ref instance.Convert<MapClass>().Ref;

    public const int MaxCells = 0x40000;

    public bool TryGetCellAt(CellStruct mapCoords, out Pointer<CellClass> pCell)
    {
        pCell = Pointer<CellClass>.Zero;

        int idx = GetCellIndex(mapCoords);
        if (idx is >= 0 and < MaxCells)
        {
            pCell = Cells.Get(idx);
        }

        return pCell != Pointer<CellClass>.Zero;
    }
    public bool TryGetCellAt(CoordStruct crd, out Pointer<CellClass> pCell)
    {
        CellStruct cell = CellClass.Coord2Cell(crd);
        return this.TryGetCellAt(cell, out pCell);
    }
    public static int GetCellIndex(CellStruct mapCoords)
    {
        return (mapCoords.Y << 9) + mapCoords.X;
    }

    // no fast call. unmanaged call will lead to StackOverflowException.
    //[UnmanagedFunctionPointer(CallingConvention.FastCall)]
    //public delegate DamageAreaResult DamageAreaFunction(in CoordStruct Coords, int Damage, /*Pointer<TechnoClass>*/IntPtr SourceObject,
    //    IntPtr WH, bool AffectsTiberium, IntPtr SourceHouse);
    //public static DamageAreaFunction DamageAreaDlg = Marshal.GetDelegateForFunctionPointer<DamageAreaFunction>(new IntPtr(0x489280));

    //public static unsafe DamageAreaResult DamageArea(in CoordStruct Coords, int Damage, Pointer<TechnoClass> SourceObject,
    //    Pointer<WarheadTypeClass> WH, bool AffectsTiberium, Pointer<HouseClass> SourceHouse)
    //{
    //    //var func = (delegate* unmanaged[Fastcall]<in CoordStruct, int, IntPtr, IntPtr, bool, IntPtr, DamageAreaResult>)0x489280;
    //    var func = (delegate* managed<in CoordStruct, int, Pointer<HouseClass>, bool, Pointer<WarheadTypeClass>, Pointer<TechnoClass>, DamageAreaResult>)0x489280;
    //    return func(in Coords, Damage, SourceHouse, AffectsTiberium, WH, SourceObject);
    //}

    //[UnmanagedFunctionPointer(CallingConvention.FastCall)]
    //public delegate void FlashbangWarheadAtFunction(int Damage, IntPtr WH, CoordStruct coords, bool Force = false, SpotlightFlags CLDisableFlags = SpotlightFlags.None);
    //public static FlashbangWarheadAtFunction FlashbangWarheadAt = Marshal.GetDelegateForFunctionPointer<FlashbangWarheadAtFunction>(new IntPtr(0x48A620));

    //public static unsafe void FlashbangWarheadAt(int Damage, Pointer<WarheadTypeClass> WH, CoordStruct coords, bool Force = false, SpotlightFlags CLDisableFlags = SpotlightFlags.None)
    //{
    //    //var func = (delegate* unmanaged[Fastcall]<int, IntPtr, CoordStruct, bool, SpotlightFlags, void>)0x48A620;
    //    var func = (delegate* managed<int, Pointer<WarheadTypeClass>, SpotlightFlags, bool, CoordStruct, void>)0x48A620;
    //    func(Damage, WH, CLDisableFlags, Force, coords);
    //}

    // public static unsafe int GetTotalDamage(int Damage, Pointer<WarheadTypeClass> WH, Armor armor, int distance)
    // {
    //     var func = (delegate* unmanaged[Thiscall]<int, int, IntPtr, Armor, int, int>)ASM.FastCallTransferStation;
    //     return func(0x489180, Damage, WH, armor, distance);
    // }
    //
    //
    // public static unsafe DamageAreaResult DamageArea(CoordStruct Coords, int Damage, Pointer<TechnoClass> SourceObject,
    //     Pointer<WarheadTypeClass> WH, bool AffectsTiberium, Pointer<HouseClass> SourceHouse)
    // {
    //     var func = (delegate* unmanaged[Thiscall]<int, in CoordStruct, int, IntPtr, IntPtr, Bool, IntPtr, DamageAreaResult>)ASM.FastCallTransferStation;
    //     return func(0x489280, in Coords, Damage, SourceObject, WH, AffectsTiberium, SourceHouse);
    // }
    // public static unsafe Pointer<AnimTypeClass> SelectDamageAnimation(int Damage, Pointer<WarheadTypeClass> WH, LandType LandType, CoordStruct coords)
    // {
    //     var func = (delegate* unmanaged[Thiscall]<int, int, IntPtr, LandType, in CoordStruct, IntPtr>)ASM.FastCallTransferStation;
    //     return func(0x48A4F0, Damage, WH, LandType, in coords);
    // }
    //
    //
    // public static unsafe void FlashbangWarheadAt(int Damage, Pointer<WarheadTypeClass> WH, CoordStruct coords, bool Force = false, SpotlightFlags CLDisableFlags = SpotlightFlags.None)
    // {
    //     var func = (delegate* unmanaged[Thiscall]<int, int, IntPtr, CoordStruct, Bool, SpotlightFlags, void>)ASM.FastCallTransferStation;
    //     func(0x48A620, Damage, WH, coords, Force, CLDisableFlags);
    // }

    public unsafe CellStruct PickCellOnEdge(Edge edge, CellStruct currentLocation, CellStruct fallback,
        SpeedType speedType, bool validateReachability, MovementZone movZone)
    {
        CellStruct tmp = default;
        var func = (delegate* unmanaged[Thiscall]<nint, nint, Edge, nint, nint, SpeedType, bool, MovementZone, nint>)0x4AA440;
        func(this.GetThisPointer(), tmp.GetThisPointer(), edge, currentLocation.GetThisPointer(), fallback.GetThisPointer(), speedType, validateReachability, movZone);
        return tmp;
    }

    public unsafe int GetCellFloorHeight(CoordStruct crd)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int>)0x578080;
        return func(this.GetThisPointer(), crd.GetThisPointer());
    }



    public unsafe CellStruct Pathfinding_Find(CellStruct position, SpeedType speedType, int a5,
        MovementZone movementZone, bool alt, int spaceSizeX, int spaceSizeY,
        bool disallowOverlay, bool a11, bool requireBurrowable, bool allowBridge,
        CellStruct closeTo, bool a15, bool buildable)
    {
        CellStruct outBuffer = default;
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, SpeedType, int, MovementZone, bool, int, int, bool, bool, bool, bool, nint, bool, bool, nint>)0x56DC20;
        func(this.GetThisPointer(), outBuffer.GetThisPointer(), position.GetThisPointer(), speedType, a5, movementZone, alt, spaceSizeX, spaceSizeY, disallowOverlay, a11, requireBurrowable, allowBridge, closeTo.GetThisPointer(), a15, buildable);
        return outBuffer;
    }

    public unsafe void SetTogglePowerMode(int mode)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x4AC820;
        func(this.GetThisPointer(), mode);
    }
    public unsafe void SetWaypointMode(int mode, bool bUnk = false)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, bool, void>)0x4AC700;
        func(this.GetThisPointer(), mode, bUnk);
    }
    public unsafe void SetRepairMode(int mode)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x4AC8C0;
        func(this.GetThisPointer(), mode);
    }
    public unsafe void SetSellMode(int mode)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x4AC660;
        func(this.GetThisPointer(), mode);
    }
    public unsafe void MarkNeedsRedraw(int dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x4F42F0;
        func(this.GetThisPointer(), dwUnk);
    }

    public unsafe void CenterMap()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x4AE290;
        func(this.GetThisPointer());
    }

    // public static unsafe void UnselectAll()
    // {
    //     var func = (delegate* unmanaged[Thiscall]<int, void>)ASM.FastCallTransferStation;
    //     func(0x48DC90);
    // }



    [FieldOffset(312)] public DynamicVectorClass<Pointer<CellClass>> Cells;

    [FieldOffset(4444)] public DynamicVectorClass<CellStruct> TaggedCells;
}