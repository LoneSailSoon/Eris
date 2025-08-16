using Eris.YRSharp.FileFormats;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 152)]
public struct WWMouseClass
{
    // private static IntPtr instance = new IntPtr(0x887640);
    public static ref WWMouseClass Instance => ref new Pointer<Pointer<WWMouseClass>>(0x887640).Ref.Ref;


    public unsafe void Draw(Pointer<CellStruct> coords, Pointer<ShpStruct> pImage, int idxFrame)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, int, void>)this.GetVirtualFunctionPointer(1);
        func(this.GetThisPointer(), coords, pImage, idxFrame);
    }

    public unsafe bool IsRefCountNegative()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(2);
        return func(this.GetThisPointer());
    }

    public unsafe void HideCursor()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(3);
        func(this.GetThisPointer());
    }

    public unsafe void ShowCursor()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(4);
        func(this.GetThisPointer());
    }

    public unsafe void ReleaseMouse()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(5);
        func(this.GetThisPointer());
    }

    public unsafe void CaptureMouse()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(6);
        func(this.GetThisPointer());
    }

    public unsafe byte GetField10()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, byte>)this.GetVirtualFunctionPointer(7);
        return func(this.GetThisPointer());
    }

    public unsafe void func_20(RectangleStruct Useless)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, RectangleStruct, void>)this.GetVirtualFunctionPointer(8);
        func(this.GetThisPointer(), Useless);
    }

    public unsafe void CallFunc10()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(9);
        func(this.GetThisPointer());
    }

    public unsafe uint GetRefCount()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint>)this.GetVirtualFunctionPointer(10);
        return func(this.GetThisPointer());
    }

    public unsafe int GetX()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(11);
        return func(this.GetThisPointer());
    }

    public unsafe int GetY()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(12);
        return func(this.GetThisPointer());
    }

    public unsafe Pointer<Point2D> GetCoords(Pointer<Point2D> buffer)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)this.GetVirtualFunctionPointer(13);
        return func(this.GetThisPointer(), buffer);
    }

    public unsafe void SetCoords(Point2D buffer)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, Point2D, void>)this.GetVirtualFunctionPointer(14);
        func(this.GetThisPointer(), buffer);
    }

    public unsafe void func_3C(Pointer<DSurface> pSurface, bool bUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, void>)this.GetVirtualFunctionPointer(15);
        func(this.GetThisPointer(), pSurface, bUnk);
    }

    public unsafe void func_40(Pointer<DSurface> pSurface, bool bUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, void>)this.GetVirtualFunctionPointer(16);
        func(this.GetThisPointer(), pSurface, bUnk);
    }

    public unsafe void func_44(Pointer<int> arg1, Pointer<int> arg2)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, void>)this.GetVirtualFunctionPointer(17);
        func(this.GetThisPointer(), arg1, arg2);
    }


    public unsafe Point2D GetCoords()
    {
        Point2D pBuffer = default;
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)this.GetVirtualFunctionPointer(13);
        func(this.GetThisPointer(), Pointer<Point2D>.AsPointer(ref pBuffer));
        return pBuffer;
    }


    [FieldOffset(4)] public nint image;
    public Pointer<ShpStruct> Image => image;
    [FieldOffset(8)] public int ImageFrameIndex;
    [FieldOffset(12)] public uint RefCount;
    [FieldOffset(16)] public byte field_10;
    [FieldOffset(17)] public byte field_11;
    [FieldOffset(18)] public byte field_12;
    [FieldOffset(19)] public byte field_13;
    [FieldOffset(20)] public uint field_14;
    [FieldOffset(24)] public uint field_18;
    [FieldOffset(28)] public Point2D XY1;
    [FieldOffset(36)] public nint surface;
    public Pointer<DSurface> Surface => surface;
    [FieldOffset(40)] public nint hWnd;
    [FieldOffset(44)] public RectangleStruct Rect0;
    [FieldOffset(60)] public Point2D XY2;
    [FieldOffset(68)] public uint field_44;
    [FieldOffset(72)] public RectangleStruct Rect1;
    [FieldOffset(88)] public uint field_58;
    [FieldOffset(92)] public RectangleStruct Rect2;
    [FieldOffset(108)] public uint field_6C;
    [FieldOffset(112)] public RectangleStruct Rect3;
    [FieldOffset(128)] public RectangleStruct Rect4;
    [FieldOffset(144)] public uint field_90;
    [FieldOffset(148)] public uint field_94;
}