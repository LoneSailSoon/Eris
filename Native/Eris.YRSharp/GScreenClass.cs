namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct GScreenClass
{
    private const nint instance = 0x87F7E8;
    public static ref GScreenClass Instance => ref instance.Convert<GScreenClass>().Ref;
    
    public unsafe void One_Time()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(5);
        func(this.GetThisPointer());
    }

    public unsafe void Init()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(6);
        func(this.GetThisPointer());
    }

    public unsafe void Init_Clear()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(7);
        func(this.GetThisPointer());
    }

    public unsafe void Init_IO()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(8);
        func(this.GetThisPointer());
    }

    public unsafe void GetInputAndUpdate(Pointer<uint> outKeyCode, Pointer<int> outMouseX, Pointer<int> outMouseY)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint, void>)this.GetVirtualFunctionPointer(9);
        func(this.GetThisPointer(), outKeyCode, outMouseX, outMouseY);
    }

    public unsafe void Update(Pointer<int> keyCode, Pointer<Point2D> mouseCoords)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, void>)this.GetVirtualFunctionPointer(10);
        func(this.GetThisPointer(), keyCode, mouseCoords);
    }

    public unsafe bool SetButtons(Pointer<GadgetClass> pGadget)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)this.GetVirtualFunctionPointer(11);
        return func(this.GetThisPointer(), pGadget);
    }

    public unsafe bool AddButton(Pointer<GadgetClass> pGadget)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)this.GetVirtualFunctionPointer(12);
        return func(this.GetThisPointer(), pGadget);
    }

    public unsafe bool RemoveButton(Pointer<GadgetClass> pGadget)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)this.GetVirtualFunctionPointer(13);
        return func(this.GetThisPointer(), pGadget);
    }

    public unsafe void MarkNeedsRedraw(int dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)this.GetVirtualFunctionPointer(14);
        func(this.GetThisPointer(), dwUnk);
    }

    public unsafe void DrawOnTop()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(15);
        func(this.GetThisPointer());
    }

    public unsafe void Draw(uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, void>)this.GetVirtualFunctionPointer(16);
        func(this.GetThisPointer(), dwUnk);
    }

    public unsafe void vt_entry_44()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(17);
        func(this.GetThisPointer());
    }

    public unsafe bool SetCursor(MouseCursorType idxCursor, bool miniMap)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, MouseCursorType, bool, bool>)this.GetVirtualFunctionPointer(18);
        return func(this.GetThisPointer(), idxCursor, miniMap);
    }

    public unsafe bool UpdateCursor(MouseCursorType idxCursor, bool miniMap)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, MouseCursorType, bool, bool>)this.GetVirtualFunctionPointer(19);
        return func(this.GetThisPointer(), idxCursor, miniMap);
    }

    public unsafe bool RestoreCursor()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(20);
        return func(this.GetThisPointer());
    }

    public unsafe void UpdateCursorMinimapState(bool miniMap)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, void>)this.GetVirtualFunctionPointer(21);
        func(this.GetThisPointer(), miniMap);
    }



    [FieldOffset(0)] public nint IGameMap;
    [FieldOffset(4)] public int ScreenShakeX;
    [FieldOffset(8)] public int ScreenShakeY;
    [FieldOffset(12)] public int Bitfield;
}