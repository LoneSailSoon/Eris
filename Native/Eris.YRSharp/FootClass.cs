using System.Runtime.CompilerServices;
using Eris.YRSharp.FileFormats;
using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 1728)]
public struct FootClass
{
    // public unsafe bool MoveTo(CoordStruct where)
    // {
    //     var func = (delegate* unmanaged[Thiscall]<ref FootClass, IntPtr, bool>)this.GetVirtualFunctionPointer(319);
    //     return func(ref this, Pointer<CoordStruct>.AsPointer(ref where));
    // }
    //
    // public unsafe bool StopDrive()
    // {
    //     var func = (delegate* unmanaged[Thiscall]<ref FootClass, bool>)this.GetVirtualFunctionPointer(320);
    //     return func(ref this);
    // }
    //
    // public unsafe bool ChronoWarpTo(CoordStruct where)
    // {
    //     var func = (delegate* unmanaged[Thiscall]<ref FootClass, CoordStruct, bool>)this.GetVirtualFunctionPointer(322);
    //     return func(ref this, where);
    // }
    //
    // public unsafe void Panic()
    // {
    //     var func = (delegate* unmanaged[Thiscall]<ref FootClass, void>)this.GetVirtualFunctionPointer(326);
    //     func(ref this);
    // }
    //
    // public unsafe void UnPanic()
    // {
    //     var func = (delegate* unmanaged[Thiscall]<ref FootClass, void>)this.GetVirtualFunctionPointer(327);
    //     func(ref this);
    // }
    //
    // public unsafe int GetCurrentSpeed()
    // {
    //     var func = (delegate* unmanaged[Thiscall]<ref FootClass, int>)this.GetVirtualFunctionPointer(334);
    //     return func(ref this);
    // }
    //
    // public unsafe bool StopMoving()
    // {
    //     var func = (delegate* unmanaged[Thiscall]<ref FootClass, bool>)this.GetVirtualFunctionPointer(338);
    //     return func(ref this);
    // }

    public unsafe void ReceiveGunner(Pointer<FootClass> Gunner)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)this.GetVirtualFunctionPointer(309);
        func(this.GetThisPointer(), Gunner);
    }

    public unsafe void RemoveGunner(Pointer<FootClass> Gunner)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)this.GetVirtualFunctionPointer(310);
        func(this.GetThisPointer(), Gunner);
    }

    public unsafe bool IsLeavingMap()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(311);
        return func(this.GetThisPointer());
    }

    public unsafe bool vt_entry_4E0()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(312);
        return func(this.GetThisPointer());
    }

    public unsafe bool CanDeployNow()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(313);
        return func(this.GetThisPointer());
    }

    public unsafe void AddSensorsAt(CellStruct cell)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, CellStruct, void>)this.GetVirtualFunctionPointer(314);
        func(this.GetThisPointer(), cell);
    }

    public unsafe void RemoveSensorsAt(CellStruct cell)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, CellStruct, void>)this.GetVirtualFunctionPointer(315);
        func(this.GetThisPointer(), cell);
    }

    public unsafe Pointer<CoordStruct> vt_entry_4F0(Pointer<CoordStruct> pCrd)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)this.GetVirtualFunctionPointer(316);
        return func(this.GetThisPointer(), pCrd);
    }

    public unsafe void vt_entry_4F4()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(317);
        func(this.GetThisPointer());
    }

    public unsafe bool vt_entry_4F8()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(318);
        return func(this.GetThisPointer());
    }

    public unsafe bool MoveTo(Pointer<CoordStruct> pCrd)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)this.GetVirtualFunctionPointer(319);
        return func(this.GetThisPointer(), pCrd);
    }

    public unsafe bool StopMoving()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(320);
        return func(this.GetThisPointer());
    }

    public unsafe bool vt_entry_504()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(321);
        return func(this.GetThisPointer());
    }

    public unsafe bool ChronoWarpTo(CoordStruct pDest)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, CoordStruct, bool>)this.GetVirtualFunctionPointer(322);
        return func(this.GetThisPointer(), pDest);
    }

    public unsafe void Draw_A_SHP(Pointer<ShpStruct> SHP, int idxFacing, Pointer<Point2D> Coords,
        Pointer<RectangleStruct> Rectangle, uint dwUnk5, uint dwUnk6, uint dwUnk7, ZGradient ZGradient, uint dwUnk9,
        int extraLight, uint dwUnk11, uint dwUnk12, uint dwUnk13, uint dwUnk14, uint dwUnk15, uint dwUnk16)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, nint, int, nint, nint, uint, uint, uint, ZGradient, uint, int, uint,
                uint, uint, uint, uint, uint, void>)this.GetVirtualFunctionPointer(323);
        func(this.GetThisPointer(), SHP, idxFacing, Coords, Rectangle, dwUnk5, dwUnk6, dwUnk7, ZGradient, dwUnk9,
            extraLight, dwUnk11, dwUnk12, dwUnk13, dwUnk14, dwUnk15, dwUnk16);
    }

//MethodData { Type = void, Name = Draw_A_VXL, IsPoionter = False } this.GetVirtualFunctionPointer(324);
    public unsafe void GoBerzerk()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(325);
        func(this.GetThisPointer());
    }

    public unsafe void Panic()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(326);
        func(this.GetThisPointer());
    }

    public unsafe void UnPanic()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(327);
        func(this.GetThisPointer());
    }

    public unsafe void PlayIdleAnim(int nIdleAnimNumber)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)this.GetVirtualFunctionPointer(328);
        func(this.GetThisPointer(), nIdleAnimNumber);
    }

    public unsafe uint vt_entry_524()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint>)this.GetVirtualFunctionPointer(329);
        return func(this.GetThisPointer());
    }

//MethodData { Type = DWORD, Name = vt_entry_528, IsPoionter = False } this.GetVirtualFunctionPointer(330);
    public unsafe Pointer<BuildingClass> vt_entry_52C(Pointer<BuildingTypeClass> bType, uint dwUnk2, uint dwUnk3,
        Pointer<int> dwUnk4)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, nint, uint, uint, nint, nint>)this.GetVirtualFunctionPointer(331);
        return func(this.GetThisPointer(), bType, dwUnk2, dwUnk3, dwUnk4);
    }

    public unsafe uint vt_entry_530(uint dwUnk, uint dwUnk2, uint dwUnk3)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, uint, uint, uint>)this.GetVirtualFunctionPointer(332);
        return func(this.GetThisPointer(), dwUnk, dwUnk2, dwUnk3);
    }

    public unsafe void vt_entry_534(uint dwUnk, uint dwUnk2)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, uint, void>)this.GetVirtualFunctionPointer(333);
        func(this.GetThisPointer(), dwUnk, dwUnk2);
    }

    public unsafe int GetCurrentSpeed()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(334);
        return func(this.GetThisPointer());
    }

    public unsafe uint vt_entry_53C(uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, uint>)this.GetVirtualFunctionPointer(335);
        return func(this.GetThisPointer(), dwUnk);
    }

    public unsafe void vt_entry_540(uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, void>)this.GetVirtualFunctionPointer(336);
        func(this.GetThisPointer(), dwUnk);
    }

    public unsafe void SetSpeedPercentage(double percentage)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, double, void>)this.GetVirtualFunctionPointer(337);
        func(this.GetThisPointer(), percentage);
    }

    public unsafe void vt_entry_548()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(338);
        func(this.GetThisPointer());
    }

    public unsafe void vt_entry_54C()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(339);
        func(this.GetThisPointer());
    }

    public unsafe bool vt_entry_550(uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, bool>)this.GetVirtualFunctionPointer(340);
        return func(this.GetThisPointer(), dwUnk);
    }

    public unsafe bool CanBeRecruited(Pointer<HouseClass> ByWhom)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x4DA230;
        return func(this.GetThisPointer(), ByWhom);
    }

    public unsafe void CreateWakes(CoordStruct coords)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, CoordStruct, void>)0x629E90;
        func(this.GetThisPointer(), coords);
    }

    public unsafe bool Jumpjet_LocationClear()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x4135A0;
        return func(this.GetThisPointer());
    }

    public unsafe void Jumpjet_OccupyCell(CellStruct Cell)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, CellStruct, void>)0x4E00B0;
        func(this.GetThisPointer(), Cell);
    }

    public unsafe void FootClass_ImbueLocomotor(Pointer<FootClass> target, Guid clsid)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, Guid, void>)0x710000;
        func(this.GetThisPointer(), target, clsid);
    }

    public unsafe void UpdatePassengerCoords()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x7104F0;
        func(this.GetThisPointer());
    }

    public unsafe void AbortMotion()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x4DF0D0;
        func(this.GetThisPointer());
    }

    public unsafe bool UpdatePathfinding(CellStruct unkCell, CellStruct unkCell2, int unk3)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, CellStruct, CellStruct, int, bool>)0x4D3920;
        return func(this.GetThisPointer(), unkCell, unkCell2, unk3);
    }

    public unsafe Pointer<FootClass> RemoveFirstPassenger()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)0x4DE710;
        return func(this.GetThisPointer());
    }

    public unsafe Pointer<FootClass> RemovePassenger(Pointer<FootClass> pPassenger)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)0x4DE670;
        return func(this.GetThisPointer(), pPassenger);
    }

    public unsafe void EnterAsPassenger(Pointer<FootClass> pPassenger)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x4DE630;
        func(this.GetThisPointer(), pPassenger);
    }

    public unsafe void ClearNavQueue()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x4DA1C0;
        func(this.GetThisPointer());
    }

    public unsafe bool MoveToTiberium(int radius, bool scanClose = true)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, bool, bool>)0x4DCFE0;
        return func(this.GetThisPointer(), radius, scanClose);
    }

    public unsafe bool MoveToWeed(int radius)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, bool>)0x4DDB90;
        return func(this.GetThisPointer(), radius);
    }


    [FieldOffset(0)] public TechnoClass Base;
    [FieldOffset(0)] public RadioClass BaseRadio;
    [FieldOffset(0)] public MissionClass BaseMission;
    [FieldOffset(0)] public ObjectClass BaseObject;

    [FieldOffset(0)] public AbstractClass BaseAbstract;


    [FieldOffset(1312)] public int PlanningPathIdx;
    [FieldOffset(1316)] public CellStruct WaypointNearbyAccessibleCellDelta;
    [FieldOffset(1320)] public CellStruct WaypointCell;
    [FieldOffset(1324)] public uint unknown_52C;
    [FieldOffset(1328)] public uint unknown_530;
    [FieldOffset(1336)] public int WalkedFramesSoFar;
    [FieldOffset(1340)] public Bool IsMoveSoundPlaying;
    [FieldOffset(1344)] public int MoveSoundDelay;
    [FieldOffset(1348)] public AudioController MoveSoundAudioController;
    [FieldOffset(1368)] public CellStruct CurrentMapCoords;
    [FieldOffset(1372)] public CellStruct LastMapCoords;
    [FieldOffset(1376)] public CellStruct LastJumpjetMapCoords;
    [FieldOffset(1380)] public CellStruct CurrentJumpjetMapCoords;
    [FieldOffset(1384)] public CoordStruct unknown_coords_568;
    [FieldOffset(1396)] public uint unused_574;
    [FieldOffset(1400)] public double SpeedPercentage;
    [FieldOffset(1408)] public double SpeedMultiplier;
    [FieldOffset(1416)] public byte unknown_abstract_array_588;

    public ref DynamicVectorClass<Pointer<AbstractClass>> Unknown_abstract_array_588 => ref Pointer<byte>
        .AsPointer(ref unknown_abstract_array_588).Convert<DynamicVectorClass<Pointer<AbstractClass>>>().Ref;

    [FieldOffset(1440)] public nint unknown_5A0;
    public readonly Pointer<AbstractClass> Unknown_5A0 => unknown_5A0;
    [FieldOffset(1444)] public nint destination;
    public readonly Pointer<AbstractClass> Destination => destination;
    [FieldOffset(1448)] public nint lastDestination;
    public readonly Pointer<AbstractClass> LastDestination => lastDestination;

    [FieldOffset(1452)] public byte unknown_abstract_array_5AC;

    public ref DynamicVectorClass<Pointer<AbstractClass>> Unknown_abstract_array_5AC => ref Pointer<byte>
        .AsPointer(ref unknown_abstract_array_5AC).Convert<DynamicVectorClass<Pointer<AbstractClass>>>().Ref;

    [FieldOffset(1476)] public int unknown_int_5C4;
    [FieldOffset(1480)] public uint unknown_5C8;
    [FieldOffset(1484)] public uint unknown_5CC;
    [FieldOffset(1488)] public byte unknown_5D0;
    [FieldOffset(1489)] public Bool unknown_bool_5D1;
    [FieldOffset(1492)] public nint team;
    public readonly Pointer<TeamClass> Team => team;
    [FieldOffset(1496)] public nint nextTeamMember;
    public readonly Pointer<FootClass> NextTeamMember => nextTeamMember;
    [FieldOffset(1500)] public uint unknown_5DC;
    [FieldOffset(1504)] public byte pathDirections;
    public FixedArray<int> PathDirections => new(ref Unsafe.As<byte, int>(ref pathDirections), 24);
    [FieldOffset(1600)] public TimerStruct PathDelayTimer;
    [FieldOffset(1612)] public int unknown_int_64C;
    [FieldOffset(1616)] public TimerStruct unknown_timer_650;
    [FieldOffset(1628)] public TimerStruct SightTimer;
    [FieldOffset(1640)] public TimerStruct BlockagePathTimer;
    [FieldOffset(1652)] private nint locomotor;
    public ComPointer<ILocomotion> Locomotor => locomotor;
    [FieldOffset(1656)] public CoordStruct unknown_point3d_678;
    [FieldOffset(1668)] public sbyte TubeIndex;
    [FieldOffset(1669)] public Bool unknown_bool_685;
    [FieldOffset(1670)] public sbyte WaypointIndex;
    [FieldOffset(1671)] public Bool unknown_bool_687;
    [FieldOffset(1672)] public Bool unknown_bool_688;
    [FieldOffset(1673)] public Bool IsTeamLeader;
    [FieldOffset(1674)] public Bool ShouldScanForTarget;
    [FieldOffset(1675)] public Bool unknown_bool_68B;
    [FieldOffset(1676)] public Bool IsDeploying;
    [FieldOffset(1677)] public Bool IsFiring;
    [FieldOffset(1678)] public Bool unknown_bool_68E;
    [FieldOffset(1679)] public Bool ShouldEnterAbsorber;
    [FieldOffset(1680)] public Bool ShouldEnterOccupiable;
    [FieldOffset(1681)] public Bool ShouldGarrisonStructure;
    [FieldOffset(1684)] public nint parasiteEatingMe;
    public readonly Pointer<FootClass> ParasiteEatingMe => parasiteEatingMe;

    [FieldOffset(1688)] public uint unknown_698;
    [FieldOffset(1692)] public nint parasiteImUsing;
    public readonly Pointer<ParasiteClass> ParasiteImUsing => parasiteImUsing;
    [FieldOffset(1696)] public TimerStruct ParalysisTimer;
    [FieldOffset(1708)] public Bool unknown_bool_6AC;
    [FieldOffset(1709)] public Bool IsAttackedByLocomotor;
    [FieldOffset(1710)] public Bool IsLetGoByLocomotor;
    [FieldOffset(1711)] public Bool unknown_bool_6AF;
    [FieldOffset(1712)] public Bool unknown_bool_6B0;
    [FieldOffset(1713)] public Bool unknown_bool_6B1;
    [FieldOffset(1714)] public Bool unknown_bool_6B2;
    [FieldOffset(1715)] public Bool unknown_bool_6B3;
    [FieldOffset(1716)] public Bool unknown_bool_6B4;
    [FieldOffset(1717)] public Bool unknown_bool_6B5;
    [FieldOffset(1718)] public Bool FrozenStill;
    [FieldOffset(1719)] public Bool unknown_bool_6B7;
    [FieldOffset(1720)] public Bool unknown_bool_6B8;
}