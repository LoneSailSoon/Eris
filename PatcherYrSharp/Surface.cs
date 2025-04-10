using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PatcherYrSharp.FileFormats;
using PatcherYrSharp.GeneralDefinitions;
using PatcherYrSharp.GeneralStructures;
using PatcherYrSharp.Helpers;

namespace PatcherYrSharp;

[StructLayout(LayoutKind.Explicit, Size = 36)]
public struct Surface
{
    private const nint ppBitText = 0x89C4B8;
    public static IntPtr BitText { get => ((Pointer<IntPtr>)ppBitText).Data; set => ((Pointer<IntPtr>)ppBitText).Ref = value; }


    private const nint ppBitFont = 0x89C4D0;
    public static IntPtr BitFont { get => ((Pointer<IntPtr>)ppBitFont).Data; set => ((Pointer<IntPtr>)ppBitFont).Ref = value; }


    private static IntPtr ppTile = new IntPtr(0x8872FC);
    private static IntPtr ppSidebar = new IntPtr(0x887300);
    private static IntPtr ppPrimary = new IntPtr(0x887308);
    private static IntPtr ppHidden = new IntPtr(0x88730C);
    private static IntPtr ppAlternate = new IntPtr(0x887310);
    private static IntPtr ppCurrent = new IntPtr(0x887314);
    private static IntPtr ppComposite = new IntPtr(0x88731C);

    public static Pointer<Surface> Tile { get => ((Pointer<Pointer<Surface>>)ppTile).Data; set => ((Pointer<Pointer<Surface>>)ppTile).Ref = value; }
    public static Pointer<Surface> Sidebar { get => ((Pointer<Pointer<Surface>>)ppSidebar).Data; set => ((Pointer<Pointer<Surface>>)ppSidebar).Ref = value; }
    public static Pointer<Surface> Primary { get => ((Pointer<Pointer<Surface>>)ppPrimary).Data; set => ((Pointer<Pointer<Surface>>)ppPrimary).Ref = value; }
    public static Pointer<Surface> Hidden { get => ((Pointer<Pointer<Surface>>)ppHidden).Data; set => ((Pointer<Pointer<Surface>>)ppHidden).Ref = value; }
    public static Pointer<Surface> Alternate { get => ((Pointer<Pointer<Surface>>)ppAlternate).Data; set => ((Pointer<Pointer<Surface>>)ppAlternate).Ref = value; }
    public static Pointer<Surface> Current { get => ((Pointer<Pointer<Surface>>)ppCurrent).Data; set => ((Pointer<Pointer<Surface>>)ppCurrent).Ref = value; }
    public static Pointer<Surface> Temp { get => ((Pointer<Pointer<Surface>>)ppCurrent).Data; set => ((Pointer<Pointer<Surface>>)ppCurrent).Ref = value; }
    public static Pointer<Surface> Composite { get => ((Pointer<Pointer<Surface>>)ppComposite).Data; set => ((Pointer<Pointer<Surface>>)ppComposite).Ref = value; }

    private static IntPtr pViewBound = new IntPtr(0x886FA0);
    public static ref RectangleStruct ViewBound => ref pViewBound.Convert<RectangleStruct>().Ref;

    private static IntPtr pSidebarBound = new IntPtr(0x886F90);
    public static ref RectangleStruct SidebarBound => ref pSidebarBound.Convert<RectangleStruct>().Ref;

    private static IntPtr pWindowBounds = new IntPtr(0x886FB0);
    public static ref RectangleStruct WindowBounds => ref pWindowBounds.Convert<RectangleStruct>().Ref;

    public unsafe bool BlitWhole(Pointer<Surface> pSrc, bool unk1, bool unk2)
    {
        var func = (delegate* unmanaged[Thiscall]<ref Surface, IntPtr, Bool, Bool, Bool>)this.GetVirtualFunctionPointer(1);
        return func(ref this, pSrc, unk1, unk2);
    }
    public unsafe bool BlitPart(RectangleStruct clipRect, Pointer<Surface> pSrc, RectangleStruct srcRect, bool unk1, bool unk2)
    {
        var func = (delegate* unmanaged[Thiscall]<ref Surface, ref RectangleStruct, IntPtr, ref RectangleStruct, Bool, Bool, Bool>)this.GetVirtualFunctionPointer(2);
        return func(ref this, ref clipRect, pSrc, ref srcRect, unk1, unk2);
    }
    public unsafe bool Blit(RectangleStruct clipRect, RectangleStruct clipRect2, Pointer<Surface> pSrc, RectangleStruct destRect, RectangleStruct srcRect, bool unk1, bool unk2)
    {
        var func = (delegate* unmanaged[Thiscall]<ref Surface, ref RectangleStruct, ref RectangleStruct, IntPtr, ref RectangleStruct, ref RectangleStruct, Bool, Bool, Bool>)this.GetVirtualFunctionPointer(3);
        return func(ref this, ref clipRect, ref clipRect2, pSrc, ref destRect, ref srcRect, unk1, unk2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool FillRectEx(RectangleStruct clipRect, RectangleStruct fillRect, int dwColor)
    {
        return FillRectEx(this.GetThisPointer(), clipRect.GetThisPointer(), fillRect.GetThisPointer(), dwColor);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool FillRectEx(RectangleStruct clipRect, RectangleStruct fillRect, ColorStruct color)
    {
        return FillRectEx(this.GetThisPointer(), clipRect.GetThisPointer(), fillRect.GetThisPointer(), Drawing.Color16Bit(color));
    }

    private static unsafe bool FillRectEx(nint pThis, nint pClipRect, nint pRect, int color)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, int, bool>)Helper.GetVirtualFunctionPointer(pThis, 4);
        return func(pThis, pClipRect, pRect, color);

    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public unsafe bool FillRect(RectangleStruct fillRect, int dwColor)
    {
        RectangleStruct rect = this.GetRect();
        return FillRectEx((int)this.GetThisPointer(), (int)rect.GetThisPointer(), (int)fillRect.GetThisPointer(), dwColor);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public unsafe bool FillRect(RectangleStruct fillRect, ColorStruct color)
    {
        RectangleStruct rect = this.GetRect();
        return FillRectEx((int)this.GetThisPointer(), (int)rect.GetThisPointer(), (int)fillRect.GetThisPointer(), Drawing.Color16Bit(color));
    }
    public unsafe bool FillRect(int dwColor)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, bool>)this.GetVirtualFunctionPointer(6);
        return func(this.GetThisPointer(), dwColor);
    }

    //public unsafe void FillRectTrans(RectangleStruct ClipRect, int color, int nOpacity)
    //{
    //    Surface.FillRectTrans(this.GetThisPointer(), ClipRect.GetThisPointer(), color, nOpacity);
    //}

    //[DllImport("Acanthamoeba.dll")]
    //public static extern void FillRectTrans(IntPtr DSurface, IntPtr pClipRect, int color, int nOpacity);
    //public static unsafe bool FillRectTrans(Pointer<Surface> surface, Pointer<RectangleStruct> clipRect, int color, int Trans)
    //    => FillRectTrans(surface.Convert<DSurface>(), clipRect, color, Trans);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool FillRectTrans(RectangleStruct clipRect, ColorStruct color, int trans)
    {
        return FillRectTrans((int)this.GetThisPointer(), (int)clipRect.GetThisPointer(), color, trans);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool FillRectTrans(RectangleStruct clipRect, int color, int trans)
    {
        ColorStruct tmp = Drawing.WordColor(color);
        return FillRectTrans((int)this.GetThisPointer(), (int)clipRect.GetThisPointer(), tmp, trans);
    }

    public static unsafe bool FillRectTrans(Pointer<DSurface> surface, Pointer<RectangleStruct> clipRect, ColorStruct color, int trans)
    {

        var func =
            (delegate* unmanaged[Thiscall]<nint, nint, nint, int, bool>)surface.Ref.GetVirtualFunctionPointer(7);
        
        
        return func(surface, clipRect, color.GetThisPointer(), trans);
    }

    public unsafe bool SetPixel(Point2D point, int dwColor)
    {
        var func = (delegate* unmanaged[Thiscall]<ref Surface, ref Point2D, int, Bool>)this.GetVirtualFunctionPointer(9);
        return func(ref this, ref point, dwColor);
    }


    public unsafe int GetPixel(Point2D point)
    {
        var func = (delegate* unmanaged[Thiscall]<ref Surface, ref Point2D, int>)this.GetVirtualFunctionPointer(10);
        return func(ref this, ref point);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool DrawLineEx(RectangleStruct clipRect, Point2D point1, Point2D point2, int dwColor)
    {
        return DrawLineEx((int)this.GetThisPointer(), (int)clipRect.GetThisPointer(), (int)point1.GetThisPointer(), (int)point2.GetThisPointer(), dwColor);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool DrawLineEx(RectangleStruct clipRect, Point2D point1, Point2D point2, ColorStruct dwColor)
    {
        return DrawLineEx((int)this.GetThisPointer(), (int)clipRect.GetThisPointer(), (int)point1.GetThisPointer(), (int)point2.GetThisPointer(), Drawing.Color16Bit(dwColor));
    }

    private static unsafe bool DrawLineEx(nint pThis, nint pClipRect, nint pp1, nint pp2, int color)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint, int, bool>)Helper.GetVirtualFunctionPointer(pThis, 11);
        return func(pThis, pClipRect, pp1, pp2, color);

    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public unsafe bool DrawLine(Point2D point1, Point2D point2, int dwColor)
    {
        RectangleStruct rect = this.GetRect();
        return DrawLineEx((int)this.GetThisPointer(), (int)rect.GetThisPointer(), (int)point1.GetThisPointer(), (int)point2.GetThisPointer(), dwColor);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public unsafe bool DrawLine(Point2D point1, Point2D point2, ColorStruct color)
    {
        RectangleStruct rect = this.GetRect();
        return DrawLineEx((int)this.GetThisPointer(), (int)rect.GetThisPointer(), (int)point1.GetThisPointer(), (int)point2.GetThisPointer(), Drawing.Color16Bit(color));
    }

    public unsafe bool DrawRibbon(RectangleStruct clipRect, Point2D srcPoint, Point2D destPoint, ColorStruct color, float intensity, int srcZAdjust, int destZAdjust)
    {
        var func = (delegate* unmanaged[Thiscall]<ref Surface, ref RectangleStruct, ref Point2D, ref Point2D, ref ColorStruct, float, int, int, Bool>)this.GetVirtualFunctionPointer(16);
        return func(ref this, ref clipRect, ref srcPoint, ref destPoint, ref color, intensity, srcZAdjust, destZAdjust);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool DrawRectEx(RectangleStruct clipRect, RectangleStruct drawRect, int dwColor)
    {
        return DrawRectEx(this.GetThisPointer(),clipRect.GetThisPointer(), drawRect.GetThisPointer(), dwColor);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool DrawRectEx(RectangleStruct clipRect, RectangleStruct drawRect, ColorStruct dwColor)
    {
        return DrawRectEx(this.GetThisPointer(), clipRect.GetThisPointer(), drawRect.GetThisPointer(), Drawing.Color16Bit(dwColor));
    }

    private static unsafe bool DrawRectEx(nint pThis, nint pClipRect, nint pRect, int color)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, int, bool>)Helper.GetVirtualFunctionPointer(pThis, 21);
        return func(pThis, pClipRect, pRect, color);
    }
    
    
    public unsafe bool DrawRect(RectangleStruct drawRect, int dwColor)
    {
        var func = (delegate* unmanaged[Thiscall]<ref Surface, ref RectangleStruct, int, Bool>)this.GetVirtualFunctionPointer(22);
        return func(ref this, ref drawRect, dwColor);
    }

    public unsafe bool DrawRect(RectangleStruct drawRect, ColorStruct color)
    {
        var func = (delegate* unmanaged[Thiscall]<ref Surface, ref RectangleStruct, int, Bool>)this.GetVirtualFunctionPointer(22);
        return func(ref this, ref drawRect, Drawing.Color16Bit(color));
    }

    public unsafe nint Lock(int x, int y)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, int, nint>)this.GetVirtualFunctionPointer(23);
        return func(this.GetThisPointer(), x, y);
    }
    public unsafe nint Lock(Point2D location)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, int, nint>)this.GetVirtualFunctionPointer(23);
        return func(this.GetThisPointer(), location.X, location.Y);
    }

    public unsafe bool Unlock()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(24);
        return func(this.GetThisPointer());
    }


    public unsafe int GetBytesPerPixel()
    {
        var func = (delegate* unmanaged[Thiscall]<ref Surface, int>)this.GetVirtualFunctionPointer(28);
        return func(ref this);
    }
    public unsafe int GetPitch()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(29);
        return func(this.GetThisPointer());
    }
    public unsafe RectangleStruct GetRect()
    {
        RectangleStruct ret = default;
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)this.GetVirtualFunctionPointer(30);
        func(this.GetThisPointer(), ret.GetThisPointer());
        return ret;
    }
    public unsafe int GetWidth()
    {
        var func = (delegate* unmanaged[Thiscall]<ref Surface, int>)this.GetVirtualFunctionPointer(31);
        return func(ref this);
    }
    public unsafe int GetHeight()
    {
        var func = (delegate* unmanaged[Thiscall]<ref Surface, int>)this.GetVirtualFunctionPointer(32);
        return func(ref this);
    }

    public unsafe void DrawSHP(Pointer<ShpStruct> pSHP, int nFrame, Pointer<ConvertClass> pPalette, int X, int Y)
    {
        DrawSHP(pSHP, nFrame, pPalette, new Point2D(X, Y));
    }
    public unsafe void DrawSHP(Pointer<ShpStruct> pSHP, int nFrame, Pointer<ConvertClass> pPalette, Point2D point)
    {
        RectangleStruct rect = this.GetRect();
        DrawSHP(pPalette, pSHP, nFrame, point, rect, BlitterFlags.None, 0, 0, 0, 0x3E8, 0, IntPtr.Zero, 0, 0, 0);
    }
    public unsafe void DrawSHP(Pointer<ShpStruct> pSHP, int nFrame, Pointer<ConvertClass> pPalette, Point2D point, BlitterFlags flags)
    {
        RectangleStruct rect = this.GetRect();
        DrawSHP(pPalette, pSHP, nFrame, point, rect, flags, 0, 0, 0, 0x3E8, 0, IntPtr.Zero, 0, 0, 0);
    }
    public unsafe void DrawSHP(Pointer<ShpStruct> pSHP, int nFrame, Pointer<ConvertClass> pPalette, BlitterFlags flags, int zAdjust, Point2D point)
    {
        RectangleStruct rect = this.GetRect();
        DrawSHP(pPalette, pSHP, nFrame, point, rect, flags, 0, zAdjust, 2, 1000, 0, IntPtr.Zero, 0, 0, 0);
    }
    public unsafe void DrawSHP(Pointer<ConvertClass> Palette, Pointer<ShpStruct> SHP, int frameIdx,
        Point2D pos, RectangleStruct boundingRect, BlitterFlags flags, uint arg7,
        int zAdjust, uint arg9, uint bright, int TintColor, Pointer<ShpStruct> BUILDINGZ_SHA, uint argD, int ZS_X, int ZS_Y)
    {
        DrawSHP(Palette, SHP, frameIdx, Pointer<Point2D>.AsPointer(ref pos), Pointer<RectangleStruct>.AsPointer(ref boundingRect), flags, arg7, zAdjust, arg9, bright, TintColor, BUILDINGZ_SHA, argD, ZS_X, ZS_Y);
    }

    public unsafe void DrawSHP(Pointer<ConvertClass> Palette, Pointer<ShpStruct> SHP, int frameIdx,
        Pointer<Point2D> pos, Pointer<RectangleStruct> boundingRect, BlitterFlags flags, uint arg7,
        int zAdjust, uint arg9, uint bright, int TintColor, Pointer<ShpStruct> BUILDINGZ_SHA, uint argD, int ZS_X, int ZS_Y)
    {
        var func =
            (delegate* unmanaged[Fastcall]<nint, IntPtr, IntPtr, int, IntPtr, IntPtr, BlitterFlags, uint,
                int, uint, uint, int, IntPtr, uint, int, int, void>)0x4AED70;//ASM.FastCallTransferStation;
        func(this.GetThisPointer(), Palette, SHP, frameIdx, pos, boundingRect, flags, arg7, zAdjust, arg9, bright, TintColor, BUILDINGZ_SHA, argD, ZS_X, ZS_Y);
    }

    public unsafe void DrawText(string text, Pointer<RectangleStruct> pBound, Pointer<Point2D> pLocation, int foreColor, int backColor, TextPrintType flags)
    {
        Point2D temp = default;
        Fancy_Text_Print_Wide(Pointer<Point2D>.AsPointer(ref temp), text, Pointer<Surface>.AsPointer(ref this), pBound, pLocation, foreColor, backColor, flags);
    }

    public unsafe void DrawText(string text, Pointer<RectangleStruct> pBound, Pointer<Point2D> pLocation, ColorStruct color, TextPrintType flags = TextPrintType.NoShadow)
    {
        DrawText(text, pBound, pLocation, Drawing.Color16Bit(color), 0, flags);
    }

    public unsafe void DrawText(string text, Pointer<Point2D> pLocation, ColorStruct color, TextPrintType flags = TextPrintType.NoShadow)
    {
        RectangleStruct bound = GetRect();
        DrawText(text, Pointer<RectangleStruct>.AsPointer(ref bound), pLocation, color, flags);
    }

    public unsafe void DrawText(string text, Point2D pos, ColorStruct color, TextPrintType flags = TextPrintType.NoShadow)
    {
        DrawText(text, Pointer<Point2D>.AsPointer(ref pos), color, flags);
    }

    public unsafe void DrawText(string text, int x, int y, ColorStruct color, TextPrintType flags = TextPrintType.NoShadow)
    {
        Point2D temp = new Point2D(x, y);
        DrawText(text, Pointer<Point2D>.AsPointer(ref temp), color, flags);
    }

    public unsafe void DrawText(string text, CoordStruct location, ColorStruct color, TextPrintType flags = TextPrintType.NoShadow)
    {
        Point2D pos = TacticalClass.Instance.CoordsToClient(location);
        DrawText(text, Pointer<Point2D>.AsPointer(ref pos), color, flags);
    }

    public static unsafe Pointer<Point2D> Fancy_Text_Print_Wide(Pointer<Point2D> RetVal, UniString pText, Pointer<Surface> pSurface, Pointer<RectangleStruct> pBound,
        Pointer<Point2D> pLocation, int foreColor, int backColor, TextPrintType flags)
    {
        var func = (delegate* unmanaged[Cdecl]<nint, nint, nint, nint, nint, int, int, int, int, nint>)0x4A60E0;
        return func(RetVal, pText, pSurface, pBound, pLocation, foreColor, backColor, (int)flags, 0);
    }

    public static unsafe bool GetTextDimension(string Text, out int Width, out int Height, int nMaxWidth)
    {
        Width = 0;
        Height = 0;
        return ((delegate* unmanaged[Thiscall]<nint, nint, nint, nint, int, bool>)0x433CF0)(BitFont, new UniString(Text), Width.GetThisPointer(), Height.GetThisPointer(), nMaxWidth);

    }

    public static int GetTextDimension(string Text, int nMaxWidth)
    {
        int buffer1 = 0;
        int buffer2 = 0;
        GetTextDimension(Text, out buffer1, out buffer2, nMaxWidth);
        return buffer1;
    }

    public unsafe void BitTextDraw(string text, RectangleStruct rect)
    {
        var func = (delegate* unmanaged[Cdecl]<nint, nint, nint, nint, int, int, int, int, byte, int, int, void>)0x430250;
        func(BitText, BitFont, this.GetThisPointer(), new UniString(text), rect.X, rect.Y, rect.Width, rect.Height, 0, 0, 0);

    }

    //[DllImport("Acanthamoeba.dll", CharSet = CharSet.Unicode)]
    //public unsafe static extern int GetTextDimension(string pText, int nMaxWidth);


    [FieldOffset(0)] public int Vfptr;

    [FieldOffset(4)] public int Width;                         /*| BSurface->*/
    [FieldOffset(8)] public int Height;                        /*| BSurface->*/
    [FieldOffset(12)] public int LockLevel;                    /*| BSurface->*/
    [FieldOffset(16)] public int BytesPerPixel;                /*| BSurface->*/
    [FieldOffset(20)] public Pointer<byte> Buffer;             /*| BSurface->*/
    [FieldOffset(24)] public Bool Allocated;                   /*| BSurface->*/ [FieldOffset(24)] public int BufferSize;
    [FieldOffset(25)] public Bool VRAMmed;                     /*| BSurface->*/
    [FieldOffset(26)] public byte unknown_1A;                  /*| BSurface->*/
    [FieldOffset(27)] public byte unknown_1B;                  /*| BSurface->*/
    /* [FieldOffset(28)] public Pointer<IDirectDrawSurface> Surf;*/ /*| BSurface->*/ [FieldOffset(28)] public Bool BufferAllocated;
    /* [FieldOffset(32)] public Pointer<DDSURFACEDESC2> SurfDesc;*/ /*| BSurface->*/
}

[StructLayout(LayoutKind.Explicit, Size = 36)]
public struct DSurface
{
    public static unsafe void Constructor(Pointer<DSurface> pThis, int Width, int Height, bool BackBuffer, bool Force3D)
    {
        var func = (delegate* unmanaged[Thiscall]<ref DSurface, int, int, Bool, Bool, IntPtr>)0x4BA5A0;
        func(ref pThis.Ref, Width, Height, BackBuffer, Force3D);
    }

    public static unsafe void Destructor(Pointer<DSurface> pThis)
    {
        var func = (delegate* unmanaged[Thiscall]<ref DSurface, void>)Helper.GetVirtualFunctionPointer(pThis, 0);
        func(ref pThis.Ref);
    }

    [FieldOffset(0)] public Surface Base;
}

[StructLayout(LayoutKind.Explicit, Size = 36)]
public struct XSurface
{
    public static unsafe void Constructor(Pointer<XSurface> pThis, int Width, int Height)
    {
        var func = (delegate* unmanaged[Thiscall]<ref XSurface, int, int, IntPtr>)0x4AEC60;
        func(ref pThis.Ref, Width, Height);
    }

    public static unsafe void Destructor(Pointer<XSurface> pThis)
    {
        var func = (delegate* unmanaged[Thiscall]<ref XSurface, void>)Helper.GetVirtualFunctionPointer(pThis, 0);
        func(ref pThis.Ref);
    }

    [FieldOffset(0)] public Surface Base;
}

[StructLayout(LayoutKind.Explicit, Size = 36)]
public struct BSurface
{
    public static unsafe void Constructor(Pointer<BSurface> pThis, int width, int height)
    {
        var func = (delegate* unmanaged[Thiscall]<ref BSurface, int, int, IntPtr>)0x4AEC60;
        func(ref pThis.Ref, width, height);
        pThis.Ref.BaseSurface.Vfptr = 0x7E2070;

        pThis.Ref.BaseSurface.LockLevel = 0;
    }

    public static unsafe void Destructor(Pointer<BSurface> pThis)
    {
        var func = (delegate* unmanaged[Thiscall]<ref BSurface, void>)Helper.GetVirtualFunctionPointer(pThis, 0);
        func(ref pThis.Ref);
    }

    public void Allocate(int bytesPerPixel)
    {
        int bufferSize = 2 * BaseSurface.Width * BaseSurface.Height;
        BaseSurface.Buffer = Marshal.AllocHGlobal(bufferSize);
        BaseSurface.BufferSize = bufferSize;
        BaseSurface.BytesPerPixel = bytesPerPixel;
        BaseSurface.BufferAllocated = true;
    }

    public void Deallocate()
    {
        Marshal.FreeHGlobal(BaseSurface.Buffer);
        BaseSurface.Buffer = Pointer<byte>.Zero;
        BaseSurface.BufferSize = 0;
        BaseSurface.BytesPerPixel = 0;
        BaseSurface.BufferAllocated = false;
    }

    [FieldOffset(0)] public XSurface Base;
    [FieldOffset(0)] public Surface BaseSurface;
}