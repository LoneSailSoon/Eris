using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.String.Ansi;
using Eris.YRSharp.Utilities;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 172)]
public struct ObjectClass
{
    public const nint CurrentObjectsPointer = 0xA8ECB8;

    public static ref DynamicVectorClass<Pointer<ObjectClass>> CurrentObjects =>
        ref DynamicVectorClass<Pointer<ObjectClass>>.GetDynamicVector(CurrentObjectsPointer);

    public const nint ArrayPointer = 0xA8E360;

    public static ref DynamicVectorClass<Pointer<ObjectClass>> Array =>
        ref DynamicVectorClass<Pointer<ObjectClass>>.GetDynamicVector(ArrayPointer);


    public const nint ObjectsInLayersPointer = 0x8A0360;

    public static ref DynamicVectorClass<Pointer<ObjectClass>> ObjectsInLayers =>
        ref DynamicVectorClass<Pointer<ObjectClass>>.GetDynamicVector(ObjectsInLayersPointer);


    public static unsafe Pointer<TechnoTypeClass> GetTechnoType(AbstractType abstractId, int idx)
    {
        var func = (delegate* unmanaged[Thiscall]<int, int, int, nint>)NativeCode.FastCallTransferStation;
        return func(0x48DCD0, (int)abstractId, idx);
    }

    public unsafe bool Remove()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(53);
        return func(this.GetThisPointer());
    }

    public unsafe bool Put(CoordStruct coord, Direction faceDir)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, Direction, bool>)this.GetVirtualFunctionPointer(54);
        return func(this.GetThisPointer(), coord.GetThisPointer(), faceDir);
    }

    public unsafe bool IsStrange()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(32);
        return func(this.GetThisPointer());
    }

    public unsafe Pointer<TechnoTypeClass> GetTechnoType()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)this.GetVirtualFunctionPointer(33);
        return func(this.GetThisPointer());
    }

    public unsafe Pointer<ObjectTypeClass> GetObjectType()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)this.GetVirtualFunctionPointer(34);
        return func(this.GetThisPointer());
    }

    public unsafe uint GetTypeOwners()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint>)this.GetVirtualFunctionPointer(35);
        return func(this.GetThisPointer());
    }

    public unsafe AnsiStringPointer GetUIName()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)this.GetVirtualFunctionPointer(36);
        return func(this.GetThisPointer());
    }

    public unsafe bool CanBeRepaired()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(37);
        return func(this.GetThisPointer());
    }

    public unsafe bool CanBeSold()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(38);
        return func(this.GetThisPointer());
    }

    public unsafe bool IsActive()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(39);
        return func(this.GetThisPointer());
    }

    public unsafe bool IsControllable()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(40);
        return func(this.GetThisPointer());
    }

    public unsafe Pointer<CoordStruct> GetTargetCoords(Pointer<CoordStruct> pCrd)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)this.GetVirtualFunctionPointer(41);
        return func(this.GetThisPointer(), pCrd);
    }

    public unsafe Pointer<CoordStruct> GetDockCoords(Pointer<CoordStruct> pCrd, Pointer<TechnoClass> docker)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint>)this.GetVirtualFunctionPointer(42);
        return func(this.GetThisPointer(), pCrd, docker);
    }

    public unsafe Pointer<CoordStruct> GetRenderCoords(Pointer<CoordStruct> pCrd)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)this.GetVirtualFunctionPointer(43);
        return func(this.GetThisPointer(), pCrd);
    }

    public unsafe Pointer<CoordStruct> GetFLH(Pointer<CoordStruct> pDest, int idxWeapon, CoordStruct BaseCoords)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, nint, int, CoordStruct, nint>)this.GetVirtualFunctionPointer(44);
        return func(this.GetThisPointer(), pDest, idxWeapon, BaseCoords);
    }

    public unsafe Pointer<CoordStruct> GetExitCoords(Pointer<CoordStruct> pCrd, uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, uint, nint>)this.GetVirtualFunctionPointer(45);
        return func(this.GetThisPointer(), pCrd, dwUnk);
    }

    public unsafe int GetYSort()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(46);
        return func(this.GetThisPointer());
    }

    public unsafe bool IsOnBridge(Pointer<TechnoClass> pDocker = default)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)this.GetVirtualFunctionPointer(47);
        return func(this.GetThisPointer(), pDocker);
    }

    public unsafe bool IsStandingStill()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(48);
        return func(this.GetThisPointer());
    }

    public unsafe bool IsDisguised()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(49);
        return func(this.GetThisPointer());
    }

    public unsafe bool IsDisguisedAs(Pointer<HouseClass> target)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)this.GetVirtualFunctionPointer(50);
        return func(this.GetThisPointer(), target);
    }

    public unsafe Pointer<ObjectTypeClass> GetDisguise(bool DisguisedAgainstAllies)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, nint>)this.GetVirtualFunctionPointer(51);
        return func(this.GetThisPointer(), DisguisedAgainstAllies);
    }

    public unsafe Pointer<HouseClass> GetDisguiseHouse(bool DisguisedAgainstAllies)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, nint>)this.GetVirtualFunctionPointer(52);
        return func(this.GetThisPointer(), DisguisedAgainstAllies);
    }

    public unsafe bool Limbo()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(53);
        return func(this.GetThisPointer());
    }

    public unsafe bool Unlimbo(Pointer<CoordStruct> Crd, Direction dFaceDir)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, Direction, bool>)this.GetVirtualFunctionPointer(54);
        return func(this.GetThisPointer(), Crd, dFaceDir);
    }

    public unsafe void Disappear(bool permanently)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, void>)this.GetVirtualFunctionPointer(55);
        func(this.GetThisPointer(), permanently);
    }

    public unsafe void RegisterDestruction(Pointer<TechnoClass> Destroyer)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)this.GetVirtualFunctionPointer(56);
        func(this.GetThisPointer(), Destroyer);
    }

    public unsafe void RegisterKill(Pointer<HouseClass> Destroyer)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)this.GetVirtualFunctionPointer(57);
        func(this.GetThisPointer(), Destroyer);
    }

    public unsafe bool SpawnParachuted(Pointer<CoordStruct> coords)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)this.GetVirtualFunctionPointer(58);
        return func(this.GetThisPointer(), coords);
    }

    public unsafe void DropAsBomb()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(59);
        func(this.GetThisPointer());
    }

    public unsafe void MarkAllOccupationBits(Pointer<CoordStruct> coords)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)this.GetVirtualFunctionPointer(60);
        func(this.GetThisPointer(), coords);
    }

    public unsafe void UnmarkAllOccupationBits(Pointer<CoordStruct> coords)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)this.GetVirtualFunctionPointer(61);
        func(this.GetThisPointer(), coords);
    }

    public unsafe void UnInit()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(62);
        func(this.GetThisPointer());
    }

    public unsafe void Reveal()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(63);
        func(this.GetThisPointer());
    }

    public unsafe KickOutResult KickOutUnit(Pointer<TechnoClass> pTechno, CellStruct Cell)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, nint, CellStruct, KickOutResult>)this.GetVirtualFunctionPointer(64);
        return func(this.GetThisPointer(), pTechno, Cell);
    }

    public unsafe bool DrawIfVisible(Pointer<RectangleStruct> pBounds, bool EvenIfCloaked, uint dwUnk3)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, uint, bool>)this.GetVirtualFunctionPointer(65);
        return func(this.GetThisPointer(), pBounds, EvenIfCloaked, dwUnk3);
    }

    public unsafe Pointer<CellStruct> GetFoundationData(bool includeBib = true)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, nint>)this.GetVirtualFunctionPointer(66);
        return func(this.GetThisPointer(), includeBib);
    }

    public unsafe void DrawBehind(Pointer<Point2D> pLocation, Pointer<RectangleStruct> pBounds)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, void>)this.GetVirtualFunctionPointer(67);
        func(this.GetThisPointer(), pLocation, pBounds);
    }

    public unsafe void DrawExtras(Pointer<Point2D> pLocation, Pointer<RectangleStruct> pBounds)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, void>)this.GetVirtualFunctionPointer(68);
        func(this.GetThisPointer(), pLocation, pBounds);
    }

    public unsafe void DrawIt(Pointer<Point2D> pLocation, Pointer<RectangleStruct> pBounds)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, void>)this.GetVirtualFunctionPointer(69);
        func(this.GetThisPointer(), pLocation, pBounds);
    }

    public unsafe void DrawIt(Point2D pos, RectangleStruct rect)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, void>)this.GetVirtualFunctionPointer(69);
        func(this.GetThisPointer(), pos.GetThisPointer(), rect.GetThisPointer());
    }

    public unsafe void DrawAgain(Pointer<Point2D> location, Pointer<RectangleStruct> bounds)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, void>)this.GetVirtualFunctionPointer(70);
        func(this.GetThisPointer(), location, bounds);
    }

    public unsafe void Undiscover()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(71);
        func(this.GetThisPointer());
    }

    public unsafe void See(uint dwUnk, uint dwUnk2)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, uint, void>)this.GetVirtualFunctionPointer(72);
        func(this.GetThisPointer(), dwUnk, dwUnk2);
    }

    public unsafe bool Mark(MarkType value)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, MarkType, bool>)this.GetVirtualFunctionPointer(73);
        return func(this.GetThisPointer(), value);
    }

    public unsafe Pointer<RectangleStruct> GetDimensions(Pointer<RectangleStruct> pRect)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)this.GetVirtualFunctionPointer(74);
        return func(this.GetThisPointer(), pRect);
    }

    public unsafe Pointer<RectangleStruct> GetRenderDimensions(Pointer<RectangleStruct> pRect)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)this.GetVirtualFunctionPointer(75);
        return func(this.GetThisPointer(), pRect);
    }

    public unsafe void DrawRadialIndicator(uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, void>)this.GetVirtualFunctionPointer(76);
        func(this.GetThisPointer(), dwUnk);
    }

    public unsafe void MarkForRedraw()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(77);
        func(this.GetThisPointer());
    }

    public unsafe bool CanBeSelected()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(78);
        return func(this.GetThisPointer());
    }

    public unsafe bool CanBeSelectedNow()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(79);
        return func(this.GetThisPointer());
    }

    public unsafe bool CellClickedAction(Action action, Pointer<CellStruct> pCell, Pointer<CellStruct> pCell1,
        bool bUnk)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, Action, nint, nint, bool, bool>)this.GetVirtualFunctionPointer(80);
        return func(this.GetThisPointer(), action, pCell, pCell1, bUnk);
    }

    public unsafe bool ObjectClickedAction(Action action, Pointer<ObjectClass> pTarget, bool bUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, Action, nint, bool, bool>)this.GetVirtualFunctionPointer(81);
        return func(this.GetThisPointer(), action, pTarget, bUnk);
    }

    public unsafe void Flash(int Duration)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)this.GetVirtualFunctionPointer(82);
        func(this.GetThisPointer(), Duration);
    }

    public unsafe bool Select()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(83);
        return func(this.GetThisPointer());
    }

    public unsafe void Deselect()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(84);
        func(this.GetThisPointer());
    }

    public unsafe DamageState IronCurtain(int nDuration, Pointer<HouseClass> pSource, bool ForceShield)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, int, nint, bool, DamageState>)this.GetVirtualFunctionPointer(85);
        return func(this.GetThisPointer(), nDuration, pSource, ForceShield);
    }

    public unsafe void StopAirstrikeTimer()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(86);
        func(this.GetThisPointer());
    }

    public unsafe void StartAirstrikeTimer(int Duration)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)this.GetVirtualFunctionPointer(87);
        func(this.GetThisPointer(), Duration);
    }

    public unsafe bool IsIronCurtained()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(88);
        return func(this.GetThisPointer());
    }

    public unsafe bool IsCloseEnough3D(uint dwUnk, uint dwUnk2)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, uint, bool>)this.GetVirtualFunctionPointer(89);
        return func(this.GetThisPointer(), dwUnk, dwUnk2);
    }

    public unsafe int GetWeaponRange(int idxWeapon)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, int>)this.GetVirtualFunctionPointer(90);
        return func(this.GetThisPointer(), idxWeapon);
    }

    public unsafe DamageState ReceiveDamage(Pointer<int> pDamage, int DistanceFromEpicenter,
        Pointer<WarheadTypeClass> pWH, Pointer<ObjectClass> Attacker, bool IgnoreDefenses, bool PreventPassengerEscape,
        Pointer<HouseClass> pAttackingHouse)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, nint, int, nint, nint, bool, bool, nint, DamageState>)this
                .GetVirtualFunctionPointer(91);
        return func(this.GetThisPointer(), pDamage, DistanceFromEpicenter, pWH, Attacker, IgnoreDefenses,
            PreventPassengerEscape, pAttackingHouse);
    }

    public unsafe void Destroy()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(92);
        func(this.GetThisPointer());
    }

    public unsafe void Scatter(Pointer<CoordStruct> crd, bool ignoreMission, bool ignoreDestination)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, bool, void>)this.GetVirtualFunctionPointer(93);
        func(this.GetThisPointer(), crd, ignoreMission, ignoreDestination);
    }

    public unsafe bool Ignite()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(94);
        return func(this.GetThisPointer());
    }

    public unsafe void Extinguish()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(95);
        func(this.GetThisPointer());
    }

    public unsafe uint GetPointsValue()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint>)this.GetVirtualFunctionPointer(96);
        return func(this.GetThisPointer());
    }

    public unsafe Mission GetCurrentMission()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, Mission>)this.GetVirtualFunctionPointer(97);
        return func(this.GetThisPointer());
    }

    public unsafe void RestoreMission(Mission mission)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, Mission, void>)this.GetVirtualFunctionPointer(98);
        func(this.GetThisPointer(), mission);
    }

    public unsafe void UpdatePosition(PCPType how)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, PCPType, void>)this.GetVirtualFunctionPointer(99);
        func(this.GetThisPointer(), how);
    }

    public unsafe Pointer<BuildingClass> FindFactory(bool allowOccupied, bool requirePower)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, bool, nint>)this.GetVirtualFunctionPointer(100);
        return func(this.GetThisPointer(), allowOccupied, requirePower);
    }

//MethodData { Type = RadioCommand, Name = ReceiveCommand, IsPoionter = False } this.GetVirtualFunctionPointer(101);
    public unsafe bool DiscoveredBy(Pointer<HouseClass> pHouse)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)this.GetVirtualFunctionPointer(102);
        return func(this.GetThisPointer(), pHouse);
    }

    public unsafe void SetRepairState(int state)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)this.GetVirtualFunctionPointer(103);
        func(this.GetThisPointer(), state);
    }

    public unsafe void Sell(uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, void>)this.GetVirtualFunctionPointer(104);
        func(this.GetThisPointer(), dwUnk);
    }

//MethodData { Type = void, Name = AssignPlanningPath, IsPoionter = False } this.GetVirtualFunctionPointer(105);
    public unsafe void MoveToDirection(FacingType facing)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, byte, void>)this.GetVirtualFunctionPointer(106);
        func(this.GetThisPointer(), (byte)facing);
    }

    public unsafe Move IsCellOccupied(Pointer<CellClass> pDestCell, FacingType facing, int level,
        Pointer<CellClass> pSourceCell, bool alt)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, nint, byte, int, nint, bool, Move>)this.GetVirtualFunctionPointer(107);
        return func(this.GetThisPointer(), pDestCell, (byte)facing, level, pSourceCell, alt);
    }

    public unsafe uint vt_entry_1B0(uint dwUnk, uint dwUnk2, uint dwUnk3, uint dwUnk4, uint dwUnk5)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, uint, uint, uint, uint, uint, uint>)this
                .GetVirtualFunctionPointer(108);
        return func(this.GetThisPointer(), dwUnk, dwUnk2, dwUnk3, dwUnk4, dwUnk5);
    }

    public unsafe void SetLocation(Pointer<CoordStruct> crd)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)this.GetVirtualFunctionPointer(109);
        func(this.GetThisPointer(), crd);
    }

    public unsafe Pointer<CellStruct> GetMapCoords(Pointer<CellStruct> pUCell)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)this.GetVirtualFunctionPointer(110);
        return func(this.GetThisPointer(), pUCell);
    }

    public unsafe Pointer<CellClass> GetCell()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)this.GetVirtualFunctionPointer(111);
        return func(this.GetThisPointer());
    }

    public unsafe Pointer<CellStruct> GetMapCoordsAgain(Pointer<CellStruct> pUCell)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)this.GetVirtualFunctionPointer(112);
        return func(this.GetThisPointer(), pUCell);
    }

    public unsafe Pointer<CellClass> GetCellAgain()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)this.GetVirtualFunctionPointer(113);
        return func(this.GetThisPointer());
    }

    public unsafe int GetHeight()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(114);
        return func(this.GetThisPointer());
    }

    public unsafe void SetHeight(uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, void>)this.GetVirtualFunctionPointer(115);
        func(this.GetThisPointer(), dwUnk);
    }

    public unsafe int GetZ()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(116);
        return func(this.GetThisPointer());
    }

    public unsafe bool IsBeingWarpedOut()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(117);
        return func(this.GetThisPointer());
    }

    public unsafe bool IsWarpingIn()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(118);
        return func(this.GetThisPointer());
    }

    public unsafe bool IsWarpingSomethingOut()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(119);
        return func(this.GetThisPointer());
    }

    public unsafe bool IsNotWarping()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(120);
        return func(this.GetThisPointer());
    }

    public unsafe Pointer<LightConvertClass> GetRemapColour()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)this.GetVirtualFunctionPointer(121);
        return func(this.GetThisPointer());
    }

    public DamageState TakeDamage(int damage, bool crewed)
    {
        return TakeDamage(damage, RulesClass.Instance.C4Warhead, crewed);
    }

    public DamageState TakeDamage(int damage, Pointer<WarheadTypeClass> pWH, bool crewed)
    {
        return TakeDamage(damage, pWH, IntPtr.Zero, IntPtr.Zero, crewed);
    }

    public DamageState TakeDamage(int damage, Pointer<WarheadTypeClass> pWH, Pointer<ObjectClass> pAttacker,
        Pointer<HouseClass> pAttackingHouse, bool crewed)
    {
        return ReceiveDamage(damage, 0, pWH, pAttacker, true, !crewed, pAttackingHouse);
    }

    public unsafe DamageState ReceiveDamage(int damage, int distanceFromEpicenter, Pointer<WarheadTypeClass> pWH,
        Pointer<ObjectClass> pAttacker, bool ignoreDefenses, bool preventPassengerEscape,
        Pointer<HouseClass> pAttackingHouse)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int, nint, nint, bool, bool, nint, DamageState>)
            this.GetVirtualFunctionPointer(91);
        return func(this.GetThisPointer(), Pointer<int>.AsPointer(ref damage), distanceFromEpicenter, pWH, pAttacker,
            ignoreDefenses, preventPassengerEscape, pAttackingHouse);
    }

    public unsafe void SetLocation(CoordStruct coord)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)this.GetVirtualFunctionPointer(109);
        func(this.GetThisPointer(), coord.GetThisPointer());
    }


    // public unsafe int GetHeight()
    // {
    //     var func = (delegate* unmanaged[Thiscall]<ref ObjectClass, int>)this.GetVirtualFunctionPointer(114);
    //     return func(ref this);
    // }

    public double GetHealthPercentage()
    {
        return (double)Health / GetObjectType().Ref.Strength;
    }


    public unsafe int DistanceFrom(Pointer<AbstractClass> that)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int>)0x5F6440;
        return func(this.GetThisPointer(), that);
    }

    public unsafe void SetHealthPercentage(double percentage)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, double, void>)0x5F5C80;
        func(this.GetThisPointer(), percentage);
    }

    public unsafe bool IsRedHP()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x5F5CD0;
        return func(this.GetThisPointer());
    }

    public unsafe bool IsYellowHP()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x5F5D20;
        return func(this.GetThisPointer());
    }

    public unsafe bool IsGreenHP()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x5F5D90;
        return func(this.GetThisPointer());
    }

    public unsafe HealthState GetHealthStatus()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, HealthState>)0x5F5DD0;
        return func(this.GetThisPointer());
    }

    public unsafe bool AttachTrigger(Pointer<TagClass> pTag)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x5F5B50;
        return func(this.GetThisPointer(), pTag);
    }

    public unsafe void BecomeUntargetable()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x70D4A0;
        func(this.GetThisPointer());
    }

    public unsafe void ReplaceTag(Pointer<TagClass> pTag)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x5F5B4C;
        func(this.GetThisPointer(), pTag);
    }

    public unsafe int GetCellLevel()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)0x5F5F00;
        return func(this.GetThisPointer());
    }


    [FieldOffset(0)] public AbstractClass Base;

    [FieldOffset(44)] public int
        FallRate; //how fast is it falling down? only works if FallingDown is set below, and actually positive numbers will move the thing UPWARDS

    [FieldOffset(48)]
    private nint nextObject; //Next Object in the same cell or transport. This is a linked list of Objects.

    public Pointer<ObjectClass> NextObject
    {
        get => nextObject;
        set => nextObject = value;
    }

    [FieldOffset(100)] public int CustomSound;
    [FieldOffset(104)] public Bool BombVisible; // In range of player's bomb seeing units, so should draw it

    [FieldOffset(108)] public int Health; //The current Health.
    [FieldOffset(112)] public int EstimatedHealth; // used for auto-targeting threat estimation
    [FieldOffset(116)] public Bool IsOnMap; // has this object been placed on the map?

    [FieldOffset(128)] public Bool NeedsRedraw;
    [FieldOffset(129)] public Bool InLimbo; // act as if it doesn't exist - e.g., post mortem state before being deleted
    [FieldOffset(130)] public Bool InOpenToppedTransport;
    [FieldOffset(131)] public Bool IsSelected; //Has the player selected this Object?
    [FieldOffset(132)] public Bool HasParachute; //Is this Object parachuting?

    [FieldOffset(136)] private nint parachute; //Current parachute Anim.

    public Pointer<AnimClass> Parachute
    {
        get => parachute;
        set => parachute = value;
    }

    [FieldOffset(140)] public Bool OnBridge;
    [FieldOffset(141)] public Bool IsFallingDown;

    [FieldOffset(142)] public Bool
        WasFallingDown; // last falling state when FootClass::Update executed. used to find out whether it changed.

    [FieldOffset(143)]
    public Bool IsABomb; // if set, will explode after FallingDown brings it to contact with the ground

    [FieldOffset(144)] public Bool IsAlive; //Self-explanatory.

    [FieldOffset(148)] public Layer LastLayer;
    [FieldOffset(152)] public Bool IsInLogic; // has this object been added to the logic collection?
    [FieldOffset(153)] public Bool IsVisible; // was this object in viewport when drawn?

    [FieldOffset(156)] public CoordStruct Location; //Absolute current 3D location (in leptons)
    [FieldOffset(168)] public nint lineTrailer;
    public readonly Pointer<LineTrail> LineTrailer => lineTrailer;
}