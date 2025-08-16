using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 111)]
public struct EventClass
{
    private const nint OutListPoint = 0xA802C8;
    public static ref EventList OutList => ref OutListPoint.Convert<EventList>().Ref;

    /// <summary>
    /// 添加事件
    /// </summary>
    /// <param name="event">事件</param>
    public static bool AddEvent(in EventClass @event)
    {
        if (OutList.Count >= 127)
        {
            return false;
        }

        OutList.GetEvent(false).Ref = @event;

        OutList.GetTimings(false).Ref = (int)Import.timeGetTime();
        ++OutList.Count;
        OutList.Tail = (OutList.Tail + 1) & 127;
        return true;
    } /**/


    public unsafe Pointer<EventClass> EventClass_Special(int houseIndex, int id)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, int, nint>)0x4C65A0;
        return func(this.GetThisPointer(), houseIndex, id);
    }

    public unsafe Pointer<EventClass> EventClass_Target(int houseIndex, NetworkEvents eventType, int id, int rtti)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, NetworkEvents, int, int, nint>)0x4C65E0;
        return func(this.GetThisPointer(), houseIndex, eventType, id, rtti);
    }

    public unsafe Pointer<EventClass> EventClass_Sellcell(int houseIndex, NetworkEvents eventType, ref CellStruct cell)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, NetworkEvents, nint, nint>)0x4C6650;
        return func(this.GetThisPointer(), houseIndex, eventType, cell.GetThisPointer());
    }

    public unsafe Pointer<EventClass> EventClass_Archive_Planning_Connect(int houseIndex, NetworkEvents eventType,
        TargetClass src, TargetClass dest)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, NetworkEvents, TargetClass, TargetClass, nint>)0x4C6780;
        return func(this.GetThisPointer(), houseIndex, eventType, src, dest);
    }

    public unsafe Pointer<EventClass> EventClass_Anim(int houseIndex, int animId, Pointer<HouseClass> pHouse,
        ref CellStruct cell)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, int, nint, nint, nint>)0x4C6800;
        return func(this.GetThisPointer(), houseIndex, animId, pHouse, cell.GetThisPointer());
    }

    public unsafe Pointer<EventClass> EventClass_MegaMission(int houseIndex, TargetClass src, Mission mission,
        TargetClass target, TargetClass dest, TargetClass follow)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, int, TargetClass, Mission, TargetClass, TargetClass, TargetClass, nint
                >)0x4C6860;
        return func(this.GetThisPointer(), houseIndex, src, mission, target, dest, follow);
    }

    public unsafe Pointer<EventClass> EventClass_MegaMission_F(int houseIndex, TargetClass src, Mission mission,
        TargetClass target, TargetClass dest, SpeedType speed, int /*MPHType*/ maxSpeed)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, int, TargetClass, Mission, TargetClass, TargetClass, SpeedType, int,
                nint>)0x4C68E0;
        return func(this.GetThisPointer(), houseIndex, src, mission, target, dest, speed, maxSpeed);
    }

    public unsafe Pointer<EventClass> EventClass_Production(int houseIndex, NetworkEvents eventType, int rttiId,
        int heapId, bool isNaval)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, NetworkEvents, int, int, bool, nint>)0x4C6970;
        return func(this.GetThisPointer(), houseIndex, eventType, rttiId, heapId, isNaval);
    }

    public unsafe Pointer<EventClass> EventClass_Unknown_Tuple(int houseIndex, NetworkEvents eventType, int unknown0,
        int unknown4, ref int unknownC)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, NetworkEvents, int, int, nint, nint>)0x4C6A60;
        return func(this.GetThisPointer(), houseIndex, eventType, unknown0, unknown4, unknownC.GetThisPointer());
    }

    public unsafe Pointer<EventClass> EventClass_Place(int houseIndex, NetworkEvents eventType, AbstractType rttitype,
        int heapid, int isNaval, ref CellStruct cell)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, int, NetworkEvents, AbstractType, int, int, nint, nint>)0x4C6AE0;
        return func(this.GetThisPointer(), houseIndex, eventType, rttitype, heapid, isNaval, cell.GetThisPointer());
    }

    public unsafe Pointer<EventClass> EventClass_SpecialPlace(int houseIndex, NetworkEvents eventType, int id,
        ref CellStruct cell)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, NetworkEvents, int, nint, nint>)0x4C6B60;
        return func(this.GetThisPointer(), houseIndex, eventType, id, cell.GetThisPointer());
    }

    public unsafe Pointer<EventClass> EventClass_Specific(int houseIndex, NetworkEvents eventType,
        AbstractType rttitype, int id)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, NetworkEvents, AbstractType, int, nint>)0x4C6BE0;
        return func(this.GetThisPointer(), houseIndex, eventType, rttitype, id);
    }
    
    [FieldOffset(0)] public EventType Type;
    [FieldOffset(1)] public Bool IsExecuted;
    [FieldOffset(2)] public byte HouseIndex;
    [FieldOffset(3)] public uint Frame;
    [FieldOffset(7)] public EventData Data;
}

[StructLayout(LayoutKind.Explicit, Size = 14732)]
public struct EventList
{
    [FieldOffset(0)] public int Count;
    [FieldOffset(4)] public int Head;
    [FieldOffset(8)] public int Tail;

    [FieldOffset(12)] public byte List_Start;
    public nint LIST_START_PTR => Pointer<byte>.AsPointer(ref List_Start);//EventList


    [FieldOffset(14220)] public byte Timings_Strat;
    public nint TIMINGS_START_PTR => Pointer<byte>.AsPointer(ref Timings_Strat);//IntList

    /// <summary>
    /// 从事件列表中获取索引对应的EventClass指针
    /// </summary>
    /// <param name="index">索引</param>
    public Pointer<EventClass> GetEvent(uint index)
    {
        nint oldPtr = EventClass.OutList.LIST_START_PTR;

        return new((uint)oldPtr + (EventClass.OutList.Head + index) * 111);
    }

    /// <summary>
    /// 从事件列表开头或结尾EventClass的指针
    /// </summary>
    /// <param name="headOrTail">开头或结尾</param>
    public Pointer<EventClass> GetEvent(bool headOrTail)
    {

        nint oldPtr = EventClass.OutList.LIST_START_PTR;

        return headOrTail? oldPtr: new((uint)oldPtr + EventClass.OutList.Tail * 111);
    }
    /// <summary>
    /// 从时间列表中获取索引对应的时间指针
    /// </summary>
    /// <param name="index">索引</param>
    public Pointer<int> GetTimings(uint index)
    {

        nint oldPtr = EventClass.OutList.TIMINGS_START_PTR;

        return new((uint)oldPtr + (EventClass.OutList.Head + index) * 4);
    }
    /// <summary>
    /// 从时间列表开头或结尾时间指针
    /// </summary>
    /// <param name="headOrTail">开头或结尾</param>
    public Pointer<int> GetTimings(bool headOrTail)
    {

        nint oldPtr = EventClass.OutList.TIMINGS_START_PTR;

        return headOrTail ? oldPtr : new((uint)oldPtr + EventClass.OutList.Tail * 4);
    }

}

[StructLayout(LayoutKind.Explicit, Size = 104)]
public struct EventData
{
    [FieldOffset(0)] public Nothing nothing;
    [FieldOffset(0)] public Animation Animation;
    [FieldOffset(0)] public FrameInfo FrameInfo;
    [FieldOffset(0)] public Target Target;
    [FieldOffset(0)] public MegaMission MegaMission;
    [FieldOffset(0)] public MegaMissionF MegaMission_F;
    [FieldOffset(0)] public Production Production;
    [FieldOffset(0)] public UnknownLongLong Unknown_LongLong;
    [FieldOffset(0)] public UnknownTuple Unknown_Tuple;
    [FieldOffset(0)] public Place Place;
    [FieldOffset(0)] public SpecialPlace SpecialPlace;
    [FieldOffset(0)] public Specific Specific;
}

[StructLayout(LayoutKind.Explicit, Size = 104)]
public struct Nothing
{
    [FieldOffset(0)] public byte Data;
}

[StructLayout(LayoutKind.Explicit, Size = 104)]
public struct Animation
{
    [FieldOffset(0)] public int ID;
    [FieldOffset(4)] public int AnimOwner;
    [FieldOffset(8)] public CellStruct Location;
    [FieldOffset(12)] public byte ExtraData;
}

[StructLayout(LayoutKind.Explicit, Size = 104)]
public struct FrameInfo
{
    [FieldOffset(0)] public byte CRC;
    [FieldOffset(4)] public ushort CommandCount;
    [FieldOffset(6)] public byte Delay;
    [FieldOffset(8)] public byte ExtraData;
}

[StructLayout(LayoutKind.Explicit, Size = 104)]
public struct Target
{
    [FieldOffset(0)] public TargetClass Whom;
    [FieldOffset(5)] public byte ExtraData;
}

[StructLayout(LayoutKind.Explicit, Size = 104)]
public struct MegaMission
{
    [FieldOffset(0)] public TargetClass Whom;
    [FieldOffset(5)] public byte Mission;
    [FieldOffset(6)] public byte _gap_;
    [FieldOffset(7)] public TargetClass Target;
    [FieldOffset(12)] public TargetClass Destination;
    [FieldOffset(17)] public TargetClass Follow;
    [FieldOffset(22)] public Bool IsPlanningEvent;
    [FieldOffset(23)] public byte ExtraData;
}

[StructLayout(LayoutKind.Explicit, Size = 104)]
public struct MegaMissionF
{
    [FieldOffset(0)] public TargetClass Whom;
    [FieldOffset(5)] public byte Mission;
    [FieldOffset(6)] public TargetClass Target;
    [FieldOffset(11)] public TargetClass Destination;
    [FieldOffset(16)] public int Speed;
    [FieldOffset(20)] public int MaxSpeed;
    [FieldOffset(24)] public byte ExtraData;
}

[StructLayout(LayoutKind.Explicit, Size = 104)]
public struct Production
{
    [FieldOffset(0)] public int RTTI_ID;
    [FieldOffset(4)] public int Heap_ID;
    [FieldOffset(8)] public int IsNaval;
    [FieldOffset(12)] public byte ExtraData;
}

[StructLayout(LayoutKind.Explicit, Size = 104)]
public struct UnknownLongLong
{
    [FieldOffset(0)] public int Unknown_0;
    [FieldOffset(8)] public ulong Data;
    [FieldOffset(16)] public int Unknown_C;
    [FieldOffset(24)] public byte ExtraData;
}

[StructLayout(LayoutKind.Explicit, Size = 104)]
public struct UnknownTuple
{
    [FieldOffset(0)] public int Unknown_0;
    [FieldOffset(4)] public int Unknown_4;
    [FieldOffset(8)] public int Data;
    [FieldOffset(12)] public int Unknown_C;
    [FieldOffset(16)] public byte ExtraData;
}

[StructLayout(LayoutKind.Explicit, Size = 104)]
public struct Place
{
    [FieldOffset(0)] public AbstractType RTTIType;
    [FieldOffset(4)] public int HeapID;
    [FieldOffset(8)] public int IsNaval;
    [FieldOffset(12)] public CellStruct Location;
    [FieldOffset(16)] public byte ExtraData;
}

[StructLayout(LayoutKind.Explicit, Size = 104)]
public struct SpecialPlace
{
    [FieldOffset(0)] public int ID;
    [FieldOffset(4)] public CellStruct Location;
    [FieldOffset(8)] public byte ExtraData;
}

[StructLayout(LayoutKind.Explicit, Size = 104)]
public struct Specific
{
    [FieldOffset(0)] public AbstractType RTTIType;
    [FieldOffset(4)] public int ID;
    [FieldOffset(8)] public byte ExtraData;
}

public enum EventType : byte
{
    Empty = 0,
    Poweron = 1,
    Poweroff = 2,
    Ally = 3,
    Megamission = 4,
    MegamissionF = 5,
    Idle = 6,
    Scatter = 7,
    Destruct = 8,
    Deploy = 9,
    Detonate = 10,
    Place = 11,
    Options = 12,
    Gamespeed = 13,
    Produce = 14,
    Suspend = 15,
    Abandon = 16,
    Primary = 17,
    SpecialPlace = 18,
    Exit = 19,
    Animation = 20,
    Repair = 21,
    Sell = 22,
    Sellcell = 23,
    Special = 24,
    Framesync = 25,
    Message = 26,
    Responstime = 27,
    Frameinfo = 28,
    Savegame = 29,
    Archive = 30,
    Addplayer = 31,
    Timing = 32,
    ProcessTime = 33,
    Pageuser = 34,
    Removeplayer = 35,
    Latencyfudge = 36,
    Megaframeinfo = 37,
    Packettiming = 38,
    Abouttoexit = 39,
    Fallbackhost = 40,
    Addresschange = 41,
    Planconnect = 42,
    Plancommit = 43,
    Plannodedelete = 44,
    Allcheer = 45,
    AbandonAll = 46,
    LastEvent = 47
}