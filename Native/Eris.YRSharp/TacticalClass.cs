using System.Runtime.CompilerServices;
using Eris.YRSharp.String.Uni;
using Eris.YRSharp.Utilities;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 3608)]
public struct TacticalClass
{
    public const nint ppInstance = 0x887324;

    public static ref TacticalClass Instance =>
        ref ((Pointer<Pointer<TacticalClass>>)ppInstance).Data
            .Ref; //{ get => ((Pointer<Pointer<TacticalClass>>)ppInstance).Data; set => ((Pointer<Pointer<TacticalClass>>)ppInstance).Ref = value; }

    public unsafe Point2D CoordsToClient(CoordStruct coords)
    {
        Point2D ret = default;
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, bool>)0x6D2140;
        func(this.GetThisPointer(), coords.GetThisPointer(), ret.GetThisPointer());
        return ret;
    }

    public unsafe CoordStruct ClientToCoords(Point2D client)
    {
        CoordStruct ret = default;
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint>)0x6D2280;
        func(this.GetThisPointer(), ret.GetThisPointer(), client.GetThisPointer());
        return ret;
    }

    public unsafe Point2D AdjustForZShapeMove(Point2D client)
    {
        Point2D ret = default;
        var func = (delegate* unmanaged[Thiscall]<ref TacticalClass, ref Point2D, ref Point2D, IntPtr>)0x6D1FE0;
        func(ref this, ref ret, ref client);
        return ret;
    }

    public unsafe int AdjustForZ(int height)
    {
        var func = (delegate* unmanaged[Thiscall]<int, int, nint, int>)NativeCode.FastCallTransferStation;
        return func(0x6D20E0, height, this.GetThisPointer());
    }

    // called when area needs to be marked for redrawing due to external factors
    // - alpha lights, terrain changes like cliff destruction, etc


    public unsafe void SetTacticalPosition(Pointer<CoordStruct> pCoord)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x6D6070;
        func(this.GetThisPointer(), pCoord);
    }

    public unsafe Pointer<CellStruct> CoordsToCell(Pointer<CellStruct> pDest, Pointer<CoordStruct> pSource)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint>)0x6D6590;
        return func(this.GetThisPointer(), pDest, pSource);
    }

    public unsafe bool CoordsToClient(Pointer<CoordStruct> coords, Pointer<Point2D> pOutClient)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, bool>)0x6D2140;
        return func(this.GetThisPointer(), coords, pOutClient);
    }

    public unsafe Pointer<Point2D> CoordsToScreen(Pointer<Point2D> pDest, Pointer<CoordStruct> pSource)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint>)0x6D1F10;
        return func(this.GetThisPointer(), pDest, pSource);
    }

    public unsafe Pointer<CoordStruct> ClientToCoords(Pointer<CoordStruct> pOutBuffer, Pointer<Point2D> client)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint>)0x6D2280;
        return func(this.GetThisPointer(), pOutBuffer, client);
    }

    public unsafe char GetOcclusion(Pointer<CellStruct> cell, bool fog)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, char>)0x6D8700;
        return func(this.GetThisPointer(), cell, fog);
    }

    public unsafe void FocusOn(Pointer<CoordStruct> pDest, int Velocity)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int, void>)0x6D2420;
        func(this.GetThisPointer(), pDest, Velocity);
    }

    public unsafe void RegisterDirtyArea(RectangleStruct Area, bool bUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, RectangleStruct, bool, void>)0x6D2790;
        func(this.GetThisPointer(), Area, bUnk);
    }

    public unsafe void RegisterCellAsVisible(Pointer<CellClass> pCell)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x6DA7D0;
        func(this.GetThisPointer(), pCell);
    }

    public unsafe void AddSelectable(Pointer<TechnoClass> pTechno, int x, int y)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int, int, void>)0x6D9EF0;
        func(this.GetThisPointer(), pTechno, x, y);
    }

    public unsafe void Render(Pointer<DSurface> pSurface, bool flag, int eMode)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, int, void>)0x6D3D10;
        func(this.GetThisPointer(), pSurface, flag, eMode);
    }

    public unsafe Pointer<Point2D> ApplyMatrix_Pixel(Pointer<Point2D> coords, Pointer<Point2D> offset)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint>)0x6D2070;
        return func(this.GetThisPointer(), coords, offset);
    }



    [FieldOffset(0)] public AbstractClass Base;
    [FieldOffset(36)] public byte screenText;
    public UniStringPointer ScreenText => new(ref Unsafe.As<byte, char>(ref screenText), 64);
    [FieldOffset(164)] public int EndGameGraphicsFrame;
    [FieldOffset(168)] public int LastAIFrame;
    [FieldOffset(172)] public Bool field_AC;
    [FieldOffset(173)] public Bool field_AD;
    [FieldOffset(174)] public byte gap_AE;
    [FieldOffset(176)] public Point2D TacticalPos;
    [FieldOffset(184)] public Point2D LastTacticalPos;
    [FieldOffset(192)] public double ZoomInFactor;
    [FieldOffset(200)] public Point2D Point_C8;
    [FieldOffset(208)] public Point2D Point_D0;
    [FieldOffset(216)] public float field_D8;
    [FieldOffset(220)] public float field_DC;
    [FieldOffset(224)] public int VisibleCellCount;
    [FieldOffset(228)] public byte visibleCells;

    public FixedArray<Pointer<CellClass>> VisibleCells =>
        new(ref Unsafe.As<byte, Pointer<CellClass>>(ref visibleCells), 800);

    [FieldOffset(3428)] public Point2D TacticalCoord1;
    [FieldOffset(3436)] public uint field_D6C;
    [FieldOffset(3440)] public uint field_D70;
    [FieldOffset(3444)] public Point2D TacticalCoord2;
    [FieldOffset(3452)] public Bool field_D7C;
    [FieldOffset(3453)] public Bool Redrawing;
    [FieldOffset(3456)] public RectangleStruct ContainingMapCoords;
    [FieldOffset(3472)] public LtrbStruct Band;
    [FieldOffset(3488)] public uint MouseFrameIndex;
    [FieldOffset(3492)] public TimerStruct StartTime;
    [FieldOffset(3504)] public int SelectableCount;
    [FieldOffset(3508)] public Matrix3D Unused_Matrix3D;
    [FieldOffset(3556)] public Matrix3D IsoTransformMatrix;
    [FieldOffset(3604)] public uint field_E14;

}

[StructLayout(LayoutKind.Sequential)]
public struct TacticalSelectableStruct
{
    public Pointer<TechnoClass> Techno;
    public int X;
    public int Y;
}