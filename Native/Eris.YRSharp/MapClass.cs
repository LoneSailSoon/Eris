using System.Runtime.CompilerServices;
using Eris.YRSharp.Utilities;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 4468)]
public struct MapClass
{
    private const nint instance = 0x87F7E8;
    public static ref MapClass Instance => ref instance.Convert<MapClass>().Ref;

    private const nint invalidCell = 0xABDC50;
    public static ref CellClass InvalidCell => ref invalidCell.Convert<CellClass>().Ref;

    private const nint objectsInLayers = 0x8A0360;
    public static FixedArray<LayerClass> ObjectsInLayers => new(objectsInLayers, 5);

    private const nint movementAdjustArray = 0x82A594;
    public static FixedArray<int> MovementAdjustArray => new(movementAdjustArray, 104);

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
    
    public unsafe void AllocateCells()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(22);
        func(this.GetThisPointer());
    }
    public unsafe void DestructCells()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(23);
        func(this.GetThisPointer());
    }
    public unsafe void ConstructCells()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(24);
        func(this.GetThisPointer());
    }
    public unsafe void PointerGotInvalid(Pointer<AbstractClass> ptr, bool bUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, void>)this.GetVirtualFunctionPointer(25);
        func(this.GetThisPointer(), ptr, bUnk);
    }
    public unsafe bool DraggingInProgress()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(26);
        return func(this.GetThisPointer());
    }
    public unsafe void UpdateCrates()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(27);
        func(this.GetThisPointer());
    }
    public unsafe void CreateEmptyMap(Pointer<RectangleStruct> mapRect, bool reuse, byte nLevel, bool bUnk2)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, byte, bool, void>)this.GetVirtualFunctionPointer(28);
        func(this.GetThisPointer(), mapRect, reuse, nLevel, bUnk2);
    }
    public unsafe void SetVisibleRect(Pointer<RectangleStruct> mapRect)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)this.GetVirtualFunctionPointer(29);
        func(this.GetThisPointer(), mapRect);
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

    public static unsafe int GetTotalDamage(int damage, Pointer<WarheadTypeClass> wh, Armor armor, int distance)
    {
        var func = (delegate* unmanaged[Thiscall]<int, int, nint, Armor, int, int>)NativeCode.FastCallTransferStation;
        return func(0x489180, damage, wh, armor, distance);
    }


    public static unsafe DamageAreaResult DamageArea(CoordStruct coords, int damage, Pointer<TechnoClass> sourceObject,
        Pointer<WarheadTypeClass> wh, bool affectsTiberium, Pointer<HouseClass> sourceHouse)
    {
        var func =
            (delegate* unmanaged[Thiscall]<int, in CoordStruct, int, IntPtr, IntPtr, Bool, IntPtr, DamageAreaResult>)
            NativeCode.FastCallTransferStation;
        return func(0x489280, in coords, damage, sourceObject, wh, affectsTiberium, sourceHouse);
    }

    public static unsafe Pointer<AnimTypeClass> SelectDamageAnimation(int damage, Pointer<WarheadTypeClass> wh,
        LandType landType, CoordStruct coords)
    {
        var func =
            (delegate* unmanaged[Thiscall]<int, int, IntPtr, LandType, in CoordStruct, IntPtr>)NativeCode
                .FastCallTransferStation;
        return func(0x48A4F0, damage, wh, landType, in coords);
    }


    public static unsafe void FlashbangWarheadAt(int damage, Pointer<WarheadTypeClass> wh, CoordStruct coords,
        bool force = false, SpotlightFlags clDisableFlags = SpotlightFlags.None)
    {
        var func =
            (delegate* unmanaged[Thiscall]<int, int, IntPtr, CoordStruct, Bool, SpotlightFlags, void>)NativeCode
                .FastCallTransferStation;
        func(0x48A620, damage, wh, coords, force, clDisableFlags);
    }

    public unsafe CellStruct PickCellOnEdge(Edge edge, CellStruct currentLocation, CellStruct fallback,
        SpeedType speedType, bool validateReachability, MovementZone movZone)
    {
        CellStruct tmp = default;
        var func =
            (delegate* unmanaged[Thiscall]<nint, nint, Edge, nint, nint, SpeedType, bool, MovementZone, nint>)0x4AA440;
        func(this.GetThisPointer(), tmp.GetThisPointer(), edge, currentLocation.GetThisPointer(),
            fallback.GetThisPointer(), speedType, validateReachability, movZone);
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
        var func =
            (delegate* unmanaged[Thiscall]<nint, nint, nint, SpeedType, int, MovementZone, bool, int, int, bool, bool,
                bool, bool, nint, bool, bool, nint>)0x56DC20;
        func(this.GetThisPointer(), outBuffer.GetThisPointer(), position.GetThisPointer(), speedType, a5, movementZone,
            alt, spaceSizeX, spaceSizeY, disallowOverlay, a11, requireBurrowable, allowBridge, closeTo.GetThisPointer(),
            a15, buildable);
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
    

    public unsafe int GetMovementZoneType(Pointer<CellStruct> MapCoords, MovementZone movementZone, bool isBridge)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, MovementZone, bool, int>)0x56D230;
        return func(this.GetThisPointer(), MapCoords, movementZone, isBridge);
    }

    public unsafe int GetCellFloorHeight(Pointer<CoordStruct> crd)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int>)0x578080;
        return func(this.GetThisPointer(), crd);
    }

    public unsafe Pointer<CellStruct> PickCellOnEdge(Pointer<CellStruct> buffer, Edge Edge,
        Pointer<CellStruct> CurrentLocation, Pointer<CellStruct> Fallback, SpeedType SpeedType,
        bool ValidateReachability, MovementZone MovZone)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, nint, Edge, nint, nint, SpeedType, bool, MovementZone, nint>)0x4AA440;
        return func(this.GetThisPointer(), buffer, Edge, CurrentLocation, Fallback, SpeedType, ValidateReachability,
            MovZone);
    }

    public unsafe void Update_Pathfinding_1()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x56C510;
        func(this.GetThisPointer());
    }

    public unsafe void Update_Pathfinding_2(Pointer<DynamicVectorClass<CellStruct>> where)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x586990;
        func(this.GetThisPointer(), where);
    }

    public unsafe Pointer<CellStruct> NearByLocation(Pointer<CellStruct> outBuffer, Pointer<CellStruct> position,
        SpeedType SpeedType, int a5, MovementZone MovementZone, bool alt, int SpaceSizeX, int SpaceSizeY,
        bool disallowOverlay, bool a11, bool requireBurrowable, bool allowBridge, Pointer<CellStruct> closeTo, bool a15,
        bool buildable)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, nint, nint, SpeedType, int, MovementZone, bool, int, int, bool, bool,
                bool, bool, nint, bool, bool, nint>)0x56DC20;
        return func(this.GetThisPointer(), outBuffer, position, SpeedType, a5, MovementZone, alt, SpaceSizeX,
            SpaceSizeY, disallowOverlay, a11, requireBurrowable, allowBridge, closeTo, a15, buildable);
    }

    public unsafe void AddContentAt(Pointer<CellStruct> coords, Pointer<TechnoClass> Content)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, void>)0x5683C0;
        func(this.GetThisPointer(), coords, Content);
    }

    public unsafe void RemoveContentAt(Pointer<CellStruct> coords, Pointer<TechnoClass> Content)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, void>)0x5687F0;
        func(this.GetThisPointer(), coords, Content);
    }

    public unsafe bool IsWithinUsableArea(Pointer<CellStruct> cell, bool checkLevel)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, bool>)0x578460;
        return func(this.GetThisPointer(), cell, checkLevel);
    }

    public unsafe bool IsWithinUsableArea(Pointer<CellClass> pCell, bool checkLevel)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, bool>)0x578540;
        return func(this.GetThisPointer(), pCell, checkLevel);
    }

    public unsafe bool IsWithinUsableArea(Pointer<CoordStruct> coords)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x5785F0;
        return func(this.GetThisPointer(), coords);
    }

    public unsafe bool CoordinatesLegal(Pointer<CellStruct> cell)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x568300;
        return func(this.GetThisPointer(), cell);
    }

    public unsafe bool IsLinkedBridgeDestroyed(Pointer<CellStruct> cell)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x587410;
        return func(this.GetThisPointer(), cell);
    }

    public unsafe bool PlacePowerupCrate(CellStruct cell, Powerup type)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, CellStruct, Powerup, bool>)0x56BEC0;
        return func(this.GetThisPointer(), cell, type);
    }

    public unsafe CoordStruct FindFirstFirestorm(Pointer<CoordStruct> start, Pointer<CoordStruct> end,
        Pointer<HouseClass> pHouse)
    {
        CoordStruct temp = default;
        var func =
            (delegate* unmanaged[Thiscall]<nint, nint, nint, nint, nint, nint>)0x5880A0;
        func(this.GetThisPointer(), temp.GetThisPointer(), start, end, pHouse);
        return temp;
    }

    public unsafe void RevealArea1(Pointer<CoordStruct> Coords, int Radius, Pointer<HouseClass> OwnerHouse,
        CellStruct arg4, byte RevealByHeight, byte arg6, byte arg7, byte arg8)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, nint, int, nint, CellStruct, byte, byte, byte, byte, void>)0x5673A0;
        func(this.GetThisPointer(), Coords, Radius, OwnerHouse, arg4, RevealByHeight, arg6, arg7, arg8);
    }

    public unsafe void RevealArea2(Pointer<CoordStruct> Coords, int Radius, Pointer<HouseClass> OwnerHouse, uint arg4,
        byte RevealByHeight, byte arg6, byte arg7, byte arg8)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int, nint, uint, byte, byte, byte, byte, void>)0x5678E0;
        func(this.GetThisPointer(), Coords, Radius, OwnerHouse, arg4, RevealByHeight, arg6, arg7, arg8);
    }

    public unsafe void RevealArea3(Pointer<CoordStruct> Coords, int Height, int Radius, bool SkipReveal)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int, int, bool, void>)0x567DA0;
        func(this.GetThisPointer(), Coords, Height, Radius, SkipReveal);
    }

    public unsafe void Reveal(Pointer<HouseClass> pHouse)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x577D90;
        func(this.GetThisPointer(), pHouse);
    }

    public unsafe void Reshroud(Pointer<HouseClass> pHouse)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x577AB0;
        func(this.GetThisPointer(), pHouse);
    }

    public unsafe int GetZPos(Pointer<CoordStruct> Coords)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int>)0x578080;
        return func(this.GetThisPointer(), Coords);
    }

    public unsafe void sub_657CE0()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x657CE0;
        func(this.GetThisPointer());
    }

    public unsafe void RedrawSidebar(int mode)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x4F42F0;
        func(this.GetThisPointer(), mode);
    }

    public unsafe Pointer<ObjectClass> NextObject(Pointer<ObjectClass> pCurrentObject)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)0x4AA2B0;
        return func(this.GetThisPointer(), pCurrentObject);
    }


    public unsafe void SetPlaceBeaconMode(int mode)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x4AC960;
        func(this.GetThisPointer(), mode);
    }
    
    public unsafe void DestroyCliff(Pointer<CellClass> Cell)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x581140;
        func(this.GetThisPointer(), Cell);
    }

    public unsafe bool IsLocationFogged(Pointer<CoordStruct> coord)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x5865E0;
        return func(this.GetThisPointer(), coord);
    }

    public unsafe void RevealCheck(Pointer<CellClass> pCell, Pointer<HouseClass> pHouse, bool bUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, bool, void>)0x5865F0;
        func(this.GetThisPointer(), pCell, pHouse, bUnk);
    }

    public unsafe bool MakeTraversable(Pointer<ObjectClass> pVisitor, Pointer<CellStruct> cell)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, bool>)0x578AD0;
        return func(this.GetThisPointer(), pVisitor, cell);
    }

    public unsafe void BuildingToFirestormWall(Pointer<CellStruct> cell, Pointer<HouseClass> pHouse,
        Pointer<BuildingTypeClass> pBldType)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint, void>)0x588570;
        func(this.GetThisPointer(), cell, pHouse, pBldType);
    }

    public unsafe void BuildingToWall(Pointer<CellStruct> cell, Pointer<HouseClass> pHouse,
        Pointer<BuildingTypeClass> pBldType)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint, void>)0x588750;
        func(this.GetThisPointer(), cell, pHouse, pBldType);
    }

    public unsafe void RecalculateZones(Pointer<CellStruct> cell)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x56D5A0;
        func(this.GetThisPointer(), cell);
    }

    public unsafe void ResetZones(Pointer<CellStruct> cell)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x56D460;
        func(this.GetThisPointer(), cell);
    }

    public unsafe void RecalculateSubZones(Pointer<CellStruct> cell)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x584550;
        func(this.GetThisPointer(), cell);
    }

    [FieldOffset(0)] public GScreenClass Base;
    [FieldOffset(16)] public uint unknown_10;
    [FieldOffset(20)] public nint unknown_pointer_14;
    public Pointer<byte> Unknown_pointer_14 => unknown_pointer_14;
    [FieldOffset(24)] public byte movementZones;
    public FixedArray<Pointer<byte>> MovementZones => new(ref Unsafe.As<byte, Pointer<byte>>(ref movementZones), 13);
    [FieldOffset(76)] public uint somecount_4C;
    [FieldOffset(80)] public byte zoneConnections;

    public ref DynamicVectorClass<ZoneConnectionClass> ZoneConnections => ref Pointer<byte>
        .AsPointer(ref zoneConnections).Convert<DynamicVectorClass<ZoneConnectionClass>>().Ref;

    [FieldOffset(104)] public nint levelAndPassability;
    public Pointer<CellLevelPassabilityStruct> LevelAndPassability => levelAndPassability;
    [FieldOffset(108)] public int ValidMapCellCount;
    [FieldOffset(112)] public nint levelAndPassabilityStruct2pointer_70;

    public Pointer<LevelAndPassabilityStruct2> LevelAndPassabilityStruct2pointer_70 =>
        levelAndPassabilityStruct2pointer_70;

    [FieldOffset(116)] public uint unknown_74;
    [FieldOffset(120)] public uint unknown_78;
    [FieldOffset(124)] public uint unknown_7C;
    [FieldOffset(128)] public byte unknown_80;
    public FixedArray<uint> Unknown_80 => new(ref Unsafe.As<byte, uint>(ref unknown_80), 3);
    [FieldOffset(140)] public byte subzoneTracking1;

    public ref DynamicVectorClass<SubzoneTrackingStruct> SubzoneTracking1 => ref Pointer<byte>
        .AsPointer(ref subzoneTracking1).Convert<DynamicVectorClass<SubzoneTrackingStruct>>().Ref;

    [FieldOffset(164)] public byte subzoneTracking2;

    public ref DynamicVectorClass<SubzoneTrackingStruct> SubzoneTracking2 => ref Pointer<byte>
        .AsPointer(ref subzoneTracking2).Convert<DynamicVectorClass<SubzoneTrackingStruct>>().Ref;

    [FieldOffset(188)] public byte subzoneTracking3;

    public ref DynamicVectorClass<SubzoneTrackingStruct> SubzoneTracking3 => ref Pointer<byte>
        .AsPointer(ref subzoneTracking3).Convert<DynamicVectorClass<SubzoneTrackingStruct>>().Ref;

    [FieldOffset(212)] public byte cellStructs1;

    public ref DynamicVectorClass<CellStruct> CellStructs1 =>
        ref Pointer<byte>.AsPointer(ref cellStructs1).Convert<DynamicVectorClass<CellStruct>>().Ref;

    [FieldOffset(236)] public RectangleStruct MapRect;
    [FieldOffset(252)] public RectangleStruct VisibleRect;
    [FieldOffset(268)] public int CellIterator_NextX;
    [FieldOffset(272)] public int CellIterator_NextY;
    [FieldOffset(276)] public int CellIterator_CurrentY;
    [FieldOffset(280)] public nint cellIterator_NextCell;
    public Pointer<CellClass> CellIterator_NextCell => cellIterator_NextCell;
    [FieldOffset(284)] public int ZoneIterator_X;
    [FieldOffset(288)] public int ZoneIterator_Y;
    [FieldOffset(292)] public LtrbStruct MapCoordBounds;
    [FieldOffset(308)] public int TotalValue;
    [FieldOffset(312)] public byte cells;

    public ref Vector<Pointer<CellClass>> Cells =>
        ref Pointer<byte>.AsPointer(ref cells).Convert<Vector<Pointer<CellClass>>>().Ref;

    [FieldOffset(328)] public int MaxLevel;
    [FieldOffset(332)] public int MaxWidth;
    [FieldOffset(336)] public int MaxHeight;
    [FieldOffset(340)] public int MaxNumCells;
    [FieldOffset(344)] public Crate Crates;
    [FieldOffset(4440)] public Bool Redraws;
    [FieldOffset(4444)] public byte taggedCells;

    public ref DynamicVectorClass<CellStruct> TaggedCells =>
        ref Pointer<byte>.AsPointer(ref taggedCells).Convert<DynamicVectorClass<CellStruct>>().Ref;
}

[StructLayout(LayoutKind.Explicit, Size = 24)]
public struct LayerClass
{
    [FieldOffset(0)] public nint vfptr;
    [FieldOffset(4)] public byte @base;
    public ref DynamicVectorClass<Pointer<ObjectClass>> Base =>
        ref Pointer<byte>.AsPointer(ref @base).Convert<DynamicVectorClass<Pointer<ObjectClass>>>().Ref;
}

[StructLayout(LayoutKind.Explicit, Size = 16)]
public struct Crate
{
    [FieldOffset(0)] public TimerStruct CrateTimer;
    [FieldOffset(12)] public CellStruct Location;
}

[StructLayout(LayoutKind.Explicit, Size = 36)]
public struct SubzoneTrackingStruct
{
    [FieldOffset(0)] public byte subzoneConnections;

    public ref DynamicVectorClass<SubzoneConnectionStruct> SubzoneConnections => ref Pointer<byte>
        .AsPointer(ref subzoneConnections).Convert<DynamicVectorClass<SubzoneConnectionStruct>>().Ref;

    [FieldOffset(24)] public ushort unknown_word_18;
    [FieldOffset(28)] public uint unknown_dword_1C;
    [FieldOffset(32)] public uint unknown_dword_20;
}

[StructLayout(LayoutKind.Explicit, Size = 10, Pack = 2)]
public struct LevelAndPassabilityStruct2
{
    [FieldOffset(0)] public byte word_0;
    public FixedArray<short> Word_0 => new(ref Unsafe.As<byte, short>(ref word_0), 4);
    [FieldOffset(8)] public byte CellLevel;
    [FieldOffset(9)] public byte field_9;
}

[StructLayout(LayoutKind.Explicit, Size = 4, Pack = 2)]
public struct CellLevelPassabilityStruct
{
    [FieldOffset(0)] public byte CellPassability;
    [FieldOffset(1)] public byte CellLevel;
    [FieldOffset(2)] public ushort ZoneArrayIndex;
}

[StructLayout(LayoutKind.Explicit, Size = 16)]
public struct ZoneConnectionClass
{
    [FieldOffset(0)] public CellStruct FromMapCoords;
    [FieldOffset(4)] public CellStruct ToMapCoords;
    [FieldOffset(8)] public Bool unknown_bool_08;
    [FieldOffset(12)] public nint cell;
    public Pointer<CellClass> Cell => cell;
}

[StructLayout(LayoutKind.Explicit, Size = 8)]
public struct SubzoneConnectionStruct
{
    [FieldOffset(0)] public uint unknown_dword_0;
    [FieldOffset(4)] public byte unknown_byte_4;
}