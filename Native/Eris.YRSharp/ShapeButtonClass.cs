using Eris.YRSharp.FileFormats;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct ShapeButtonClass
{
    public unsafe void SetShape(Pointer<ShpStruct> pSHP, int Width, int Height)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int, int, void>)this.GetVirtualFunctionPointer(35);
        func(this.GetThisPointer(), pSHP, Width, Height);
    }

    public unsafe void ClearShape()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x69DE70;
        func(this.GetThisPointer());
    }

    public unsafe void SetLoadedStatus()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x69DEA0;
        func(this.GetThisPointer());
    }

    public unsafe bool StartFlashing(int nDelay, int nInitDelay, bool bStart)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, int, bool, bool>)0x69DFC0;
        return func(this.GetThisPointer(), nDelay, nInitDelay, bStart);
    }

    public unsafe bool StopFlashing()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x69DFF0;
        return func(this.GetThisPointer());
    }

    public unsafe bool AI()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x69E010;
        return func(this.GetThisPointer());
    }

    public unsafe bool IsFlashing()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x69E050;
        return func(this.GetThisPointer());
    }


    [FieldOffset(0)] public ToggleClass Base;
    [FieldOffset(52)] public Bool IsToFlash;
    [FieldOffset(56)] public int FlashDelay;
    [FieldOffset(60)] public int FlashCounter;
    [FieldOffset(64)] public Bool UseFlash;
    [FieldOffset(68)] public Point2D DrawPosition;
    [FieldOffset(76)] public Bool UseSidebarSurface;
    [FieldOffset(80)] public nint drawer;
    public Pointer<ConvertClass> Drawer => drawer;
    [FieldOffset(84)] public Bool IsDrawn;
    [FieldOffset(85)] public Bool IsAlpha;
    [FieldOffset(88)] public nint shapeData;
    public Pointer<ShpStruct> ShapeData => shapeData;
    [FieldOffset(92)] public Bool IsShapeLoaded;
}

public enum ShapeButtonFlag : int
{
    UpShape = 0x0,
    DownShape = 0x1,
    DisabledShape = 0x2
};