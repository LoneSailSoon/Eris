using Eris.YRSharp.String.Uni;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 4584)]
public struct DisplayClass
{
    
    public const nint pInstance = 0x87F7E8;
    public static ref DisplayClass Instance => ref pInstance.Convert<DisplayClass>().Ref;
    
    public static unsafe bool MouseClassSetCursor(int idxCursor, bool miniMap)
    {
        var func = (delegate*unmanaged[Thiscall]<nint, nint, bool, bool>)0x5BDA80;
        return func(0x87F7E8, idxCursor, miniMap);
    }

    public unsafe void RightMouseButtonUp(int dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)
            this.GetVirtualFunctionPointer(49);
        func(0x87F7E8, dwUnk);
    }

    public unsafe bool Passes_Proximity_Check(Pointer<BuildingTypeClass> pPendingObject, int houseIndex,
        Pointer<CellStruct> foundation, CellStruct center)
    {
        var func = (delegate* unmanaged[Thiscall]<ref DisplayClass, IntPtr, int, IntPtr, IntPtr, Bool>)0x4A8EB0;
        return func(ref this, pPendingObject, houseIndex, foundation, center.GetThisPointer());
    }

    public unsafe void LMBUp(Pointer<CoordStruct> xyz, Pointer<CellStruct> pMapCoords, Pointer<ObjectClass> pObject,
        CCAction action, int dwUnk2 = 0)
    {
        var func =
            (delegate* unmanaged[Thiscall]<ref DisplayClass, IntPtr, IntPtr, IntPtr, CCAction, int, void>)0x4AB9B0;
        func(ref this, xyz, pMapCoords, pObject, action, dwUnk2);
    }

    public unsafe void RMBUp(int dwUnk2)
    {
        var func = (delegate* unmanaged[Thiscall]<ref DisplayClass, int, void>)0x4AAD30;
        func(ref this, dwUnk2);
    }


    public unsafe void LoadFromINI(Pointer<CCIniClass> pINI)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)this.GetVirtualFunctionPointer(32);
        func(this.GetThisPointer(), pINI);
    }

    public unsafe UniStringPointer GetToolTip(uint nDlgID)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, nint>)this.GetVirtualFunctionPointer(33);
        return func(this.GetThisPointer(), nDlgID);
    }

    public unsafe void CloseWindow()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(34);
        func(this.GetThisPointer());
    }

    public unsafe void vt_entry_8C()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(35);
        func(this.GetThisPointer());
    }

    public unsafe bool MapCell(Pointer<CellStruct> pMapCoord, Pointer<HouseClass> pHouse)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, bool>)this.GetVirtualFunctionPointer(36);
        return func(this.GetThisPointer(), pMapCoord, pHouse);
    }

    public unsafe bool RevealFogShroud(Pointer<CellStruct> pMapCoord, Pointer<HouseClass> pHouse,
        bool bIncreaseShroudCounter)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, bool, bool>)this.GetVirtualFunctionPointer(37);
        return func(this.GetThisPointer(), pMapCoord, pHouse, bIncreaseShroudCounter);
    }

    public unsafe bool MapCellFoggedness(Pointer<CellStruct> pMapCoord, Pointer<HouseClass> pHouse)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, bool>)this.GetVirtualFunctionPointer(38);
        return func(this.GetThisPointer(), pMapCoord, pHouse);
    }

    public unsafe bool MapCellVisibility(Pointer<CellStruct> pMapCoord, Pointer<HouseClass> pHouse)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, bool>)this.GetVirtualFunctionPointer(39);
        return func(this.GetThisPointer(), pMapCoord, pHouse);
    }

    public unsafe MouseCursorType GetLastMouseCursor()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, MouseCursorType>)this.GetVirtualFunctionPointer(40);
        return func(this.GetThisPointer());
    }

    public unsafe bool ScrollMap(uint dwUnk1, uint dwUnk2, uint dwUnk3)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, uint, uint, bool>)this.GetVirtualFunctionPointer(41);
        return func(this.GetThisPointer(), dwUnk1, dwUnk2, dwUnk3);
    }

    public unsafe void Set_View_Dimensions(Pointer<RectangleStruct> rect)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)this.GetVirtualFunctionPointer(42);
        func(this.GetThisPointer(), rect);
    }

    public unsafe void vt_entry_AC(uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, void>)this.GetVirtualFunctionPointer(43);
        func(this.GetThisPointer(), dwUnk);
    }

    public unsafe void vt_entry_B0(uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, void>)this.GetVirtualFunctionPointer(44);
        func(this.GetThisPointer(), dwUnk);
    }

    public unsafe void vt_entry_B4(Pointer<Point2D> pPoint)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)this.GetVirtualFunctionPointer(45);
        func(this.GetThisPointer(), pPoint);
    }

    public unsafe bool ConvertAction(Pointer<CellStruct> cell, bool bShrouded, Pointer<ObjectClass> pObject,
        Action action, bool dwUnk)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, nint, bool, nint, Action, bool, bool>)
            this.GetVirtualFunctionPointer(46);
        return func(this.GetThisPointer(), cell, bShrouded, pObject, action, dwUnk);
    }

    public unsafe void LeftMouseButtonDown(Pointer<Point2D> point)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)this.GetVirtualFunctionPointer(47);
        func(this.GetThisPointer(), point);
    }

    public unsafe void LeftMouseButtonUp(Pointer<CoordStruct> coords, Pointer<CellStruct> cell,
        Pointer<ObjectClass> pObject, Action action, uint dwUnk2)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, nint, nint, nint, Action, uint, void>)
            this.GetVirtualFunctionPointer(48);
        func(this.GetThisPointer(), coords, cell, pObject, action, dwUnk2);
    }

    public unsafe void RightMouseButtonUp(uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, void>)this.GetVirtualFunctionPointer(49);
        func(this.GetThisPointer(), dwUnk);
    }

    public unsafe CCAction DecideAction(Pointer<CellStruct> cell, Pointer<ObjectClass> pObject, uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, uint, CCAction>)0x692610;
        return func(this.GetThisPointer(), cell, pObject, dwUnk);
    }

    public unsafe Pointer<CellStruct> FoundationBoundsSize(Pointer<CellStruct> outBuffer,
        Pointer<CellStruct> pFoundationData)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint>)0x4A94F0;
        return func(this.GetThisPointer(), outBuffer, pFoundationData);
    }

    public unsafe void MarkFoundation(Pointer<CellStruct> BaseCell, bool Mark)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, void>)0x4A95A0;
        func(this.GetThisPointer(), BaseCell, Mark);
    }

    public unsafe void Submit(Pointer<ObjectClass> pObject)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x4A9720;
        func(this.GetThisPointer(), pObject);
    }

    public unsafe void Remove(Pointer<ObjectClass> pObject)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x4A9770;
        func(this.GetThisPointer(), pObject);
    }

    [FieldOffset(0)] public MapClass Base;
    [FieldOffset(4468)] public CellStruct CurrentFoundation_CenterCell;
    [FieldOffset(4472)] public CellStruct CurrentFoundation_TopLeftOffset;
    [FieldOffset(4476)] public nint currentFoundation_Data;
    public readonly Pointer<CellStruct> CurrentFoundation_Data => currentFoundation_Data;
    [FieldOffset(4480)] public Bool unknown_1180;
    [FieldOffset(4481)] public Bool unknown_1181;
    [FieldOffset(4482)] public CellStruct CurrentFoundationCopy_CenterCell;
    [FieldOffset(4486)] public CellStruct CurrentFoundationCopy_TopLeftOffset;
    [FieldOffset(4492)] public nint currentFoundationCopy_Data;
    public readonly Pointer<CellStruct> CurrentFoundationCopy_Data => currentFoundationCopy_Data;
    [FieldOffset(4496)] public uint unknown_1190;
    [FieldOffset(4500)] public uint unknown_1194;
    [FieldOffset(4504)] public uint unknown_1198;
    [FieldOffset(4508)] public Bool FollowObject;
    [FieldOffset(4512)] public nint objectToFollow;
    public readonly Pointer<ObjectClass> ObjectToFollow => objectToFollow;
    [FieldOffset(4516)] public nint currentBuilding;
    public readonly Pointer<ObjectClass> CurrentBuilding => currentBuilding;
    [FieldOffset(4520)] public nint currentBuildingType;
    public readonly Pointer<ObjectTypeClass> CurrentBuildingType => currentBuildingType;
    [FieldOffset(4524)] public uint unknown_11AC;
    [FieldOffset(4528)] public Bool RepairMode;
    [FieldOffset(4529)] public Bool SellMode;
    [FieldOffset(4530)] public Bool PowerToggleMode;
    [FieldOffset(4531)] public Bool PlanningMode;
    [FieldOffset(4532)] public Bool PlaceBeaconMode;
    [FieldOffset(4536)] public int CurrentSWTypeIndex;
    [FieldOffset(4540)] public uint unknown_11BC;
    [FieldOffset(4544)] public uint unknown_11C0;
    [FieldOffset(4548)] public uint unknown_11C4;
    [FieldOffset(4552)] public uint unknown_11C8;
    [FieldOffset(4556)] public Bool unknown_bool_11CC;
    [FieldOffset(4557)] public Bool unknown_bool_11CD;
    [FieldOffset(4558)] public Bool unknown_bool_11CE;
    [FieldOffset(4559)] public Bool DraggingRectangle;
    [FieldOffset(4560)] public Bool unknown_bool_11D0;
    [FieldOffset(4561)] public Bool unknown_bool_11D1;
    [FieldOffset(4564)] public uint unknown_11D4;
    [FieldOffset(4568)] public uint unknown_11D8;
    [FieldOffset(4572)] public uint unknown_11DC;
    [FieldOffset(4576)] public uint unknown_11E0;

}