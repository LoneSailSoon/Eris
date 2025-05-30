using System.Runtime.InteropServices;
using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 4584)]
public struct DisplayClass
{
    public static IntPtr display_ZoneCell = new IntPtr(0x88095C);
    public static CellStruct Display_ZoneCell => ((Pointer<CellStruct>)display_ZoneCell).Ref;

    public static IntPtr display_ZoneOffset = new IntPtr(0x880960);
    public static CellStruct Display_ZoneOffset
    {
        get => ((Pointer<CellStruct>)display_ZoneOffset).Ref; set => ((Pointer<CellStruct>)display_ZoneOffset).Ref = value;
    }

    public static IntPtr display_CurrentFoundation_Data = new IntPtr(0x880964);
    public static Pointer<CellStruct> Display_CurrentFoundation_Data => ((Pointer<Pointer<CellStruct>>)display_CurrentFoundation_Data).Ref;

    public static IntPtr display_PassedProximityCheck = new IntPtr(0x880968);
    public static Bool Display_PassedProximityCheck { get => ((Pointer<Bool>)display_PassedProximityCheck).Ref; set => ((Pointer<Bool>)display_PassedProximityCheck).Ref = value; }

    public static IntPtr display_PassedProximityCheck2 = new IntPtr(0x880969);
    public static Bool Display_PassedProximityCheck2 { get => ((Pointer<Bool>)display_PassedProximityCheck2).Ref; set => ((Pointer<Bool>)display_PassedProximityCheck2).Ref = value; }

    public static IntPtr display_CurrentBuilding = new IntPtr(0x88098C);
    public static Pointer<BuildingClass> Display_CurrentBuilding { get => ((Pointer<Pointer<BuildingClass>>)display_CurrentBuilding).Ref; set => ((Pointer<Pointer<BuildingClass>>)display_CurrentBuilding).Ref = value; }

    public static IntPtr display_PendingObject = new IntPtr(0x880990);
    public static Pointer<BuildingTypeClass> Display_PendingObject
    {
        get => ((Pointer<Pointer<BuildingTypeClass>>)display_PendingObject).Ref; set => ((Pointer<Pointer<BuildingTypeClass>>)display_PendingObject).Ref = value;
    }

    public static IntPtr display_PendingHouse = new IntPtr(0x880994);
    public static int Display_PendingHouse { get => ((Pointer<int>)display_PendingHouse).Ref; set => ((Pointer<int>)display_PendingHouse).Ref = value; }


    public static IntPtr pInstance = new IntPtr(0x87F7E8);
    public static ref DisplayClass Instance => ref pInstance.Convert<DisplayClass>().Ref;

    public static unsafe bool MouseClassSetCursor(int idxCursor, bool miniMap)
    {
        var func = (delegate*unmanaged[Thiscall]<nint, nint, bool, bool>)0x5BDA80;
        return func(0x87F7E8, idxCursor, miniMap);
    }

    //Decides which mouse pointer to set and then does it.
    //Mouse is over cell pMapCoords which is bShrouded and holds pObject.

    public unsafe Bool ConvertAction(Pointer<CellStruct> cell, bool bShrouded, Pointer<ObjectClass> pObject, CcAction action, int dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<ref DisplayClass, IntPtr, Bool, IntPtr, CcAction, int, Bool>)
            this.GetVirtualFunctionPointer(46);
        return func(ref this, cell, bShrouded, pObject, action, dwUnk);
    }

    public unsafe void LeftMouseButtonDown(Pointer<Point2D> point)
    {
        var func = (delegate* unmanaged[Thiscall]<ref DisplayClass, IntPtr, void>)
            this.GetVirtualFunctionPointer(47);
        func(ref this, point);
    }

    public unsafe void LeftMouseButtonUp(Pointer<CoordStruct> pCoords, Pointer<CellStruct> pCell, Pointer<ObjectClass> pObject, CcAction action, int dwUnk = 0)
    {
        var func = (delegate* unmanaged[Thiscall]<ref DisplayClass, IntPtr, IntPtr, IntPtr, CcAction, int, void>)
            this.GetVirtualFunctionPointer(48);
        func(ref this, pCoords, pCell, pObject, action, dwUnk);
    }

    public unsafe void RightMouseButtonUp(int dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)
            this.GetVirtualFunctionPointer(49);
        func(0x87F7E8, dwUnk);
    }

    public unsafe bool Passes_Proximity_Check()
    {
        return Passes_Proximity_Check(Display_PendingObject, Display_PendingHouse, Display_CurrentFoundation_Data, Display_ZoneCell + Display_ZoneOffset);
    }

    public unsafe bool Passes_Proximity_Check(Pointer<BuildingTypeClass> pPendingObject, int houseIndex, Pointer<CellStruct> foundation, CellStruct center)
    {
        var func = (delegate* unmanaged[Thiscall]<ref DisplayClass, IntPtr, int, IntPtr, IntPtr, Bool>)0x4A8EB0;
        return func(ref this, pPendingObject, houseIndex, foundation, center.GetThisPointer());
    }

    public unsafe void LMBUp(Pointer<CoordStruct> xyz, Pointer<CellStruct> pMapCoords, Pointer<ObjectClass> pObject, CcAction action, int dwUnk2 = 0)
    {
        var func = (delegate* unmanaged[Thiscall]<ref DisplayClass, IntPtr, IntPtr, IntPtr, CcAction, int, void>)0x4AB9B0;
        func(ref this, xyz, pMapCoords, pObject, action, dwUnk2);
    }

    public unsafe void RMBUp(int dwUnk2)
    {
        var func = (delegate* unmanaged[Thiscall]<ref DisplayClass, int, void>)0x4AAD30;
        func(ref this, dwUnk2);
    }

    public unsafe CcAction DecideAction(Pointer<CellStruct> pMapCoords, Pointer<ObjectClass> pObject, int dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<ref DisplayClass, IntPtr, IntPtr, int, CcAction>)0x692610;
        return func(ref this, pMapCoords, pObject, dwUnk);
    }

    [FieldOffset(4476)] public Pointer<CellStruct> CurrentFoundation_Data;
    [FieldOffset(4480)] public Bool PassedProximityCheck;
    [FieldOffset(4481)] public Bool PassedProximityShroudCheck;
    [FieldOffset(4516)] public Pointer<ObjectClass> CurrentBuilding;
    [FieldOffset(4520)] public Pointer<BuildingTypeClass> CurrentBuildingType;
    [FieldOffset(4524)] public int PendingHouse;
    [FieldOffset(4528)] public Bool RepairMode;
    [FieldOffset(4529)] public Bool SellMode;
    [FieldOffset(4530)] public Bool PowerToggleMode;
    [FieldOffset(4531)] public Bool PlanningMode;
    [FieldOffset(4532)] public Bool PlaceBeaconMode;
    [FieldOffset(4536)] public int CurrentSWTypeIndex;
        
}