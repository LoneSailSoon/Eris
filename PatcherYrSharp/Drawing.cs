using System.Runtime.InteropServices;
using PatcherYrSharp.GeneralStructures;
using PatcherYrSharp.Helpers;

namespace PatcherYrSharp;

public static class Drawing
{
    private const nint tooltipColor = 0xB0FA1C;
    public static ref ColorStruct TooltipColor => ref tooltipColor.Convert<ColorStruct>().Ref;

    public static int Color16Bit(ColorStruct color)
    {
        return (color.B >> 3) | ((color.G >> 2) << 5) | ((color.R >> 3) << 11);
    }

    public static ColorStruct WordColor(int bits)
    {
        ColorStruct color;
        color.R = (byte)(((bits & 0b1111100000000000) >> 11) << 3);
        color.G = (byte)((byte)((bits & 0b11111100000) >> 5) << 2); // msvc stupid warning
        color.B = (byte)((bits & 0b11111) << 3);
        return color;
    }

    //TextBox dimensions for tooltip-style boxes
    // public static unsafe Pointer<RectangleStruct> GetTextDimensions(Pointer<RectangleStruct> pOutBuffer, UniString text, Point2D location, int flags, int marginX = 0, int marginY = 0)
    // {
    //     var func = (delegate* unmanaged[Thiscall]<int, IntPtr, IntPtr, Point2D, int, int, int, IntPtr>)ASM.FastCallTransferStation;
    //     return func(0x4A59E0, pOutBuffer, text, location, flags, marginX, marginY);
    // }

    // public static unsafe RectangleStruct GetTextDimensions(string text, Point2D location, int flags, int marginX = 0, int marginY = 0)
    // {
    //     RectangleStruct outBuffer = default;
    //     GetTextDimensions(Pointer<RectangleStruct>.AsPointer(ref outBuffer), text, location, flags, marginX, marginY);
    //     return outBuffer;
    // }

    // public static unsafe int RGB2DWORD(int red, int green, int blue)
    // {
    //     var func = (delegate* unmanaged[Thiscall]<int, int, int, int, int>)ASM.FastCallTransferStation;
    //     return func(0x4355D0, red, green, blue);
    // }
    //
    // public static unsafe int RGB2DWORD(ColorStruct color)
    // {
    //     return RGB2DWORD(color.R, color.G, color.B);
    // }

    // public static unsafe Pointer<RectangleStruct> Intersect(Pointer<RectangleStruct> pOutBuffer,
    //     Pointer<RectangleStruct> rect1,
    //     Pointer<RectangleStruct> rect2,
    //     Pointer<int> delta_left,
    //     Pointer<int> delta_top)
    // {
    //     var func = (delegate* unmanaged[Thiscall]<int, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>)ASM.FastCallTransferStation;
    //     return func(0x421B60, pOutBuffer, rect1, rect2, delta_left, delta_top);
    // }

    // public static Pointer<RectangleStruct> Intersect(Pointer<RectangleStruct> pOutBuffer,
    //     Pointer<RectangleStruct> rect1,
    //     Pointer<RectangleStruct> rect2)
    //     => Intersect(pOutBuffer, rect1, rect2, IntPtr.Zero, IntPtr.Zero);

    // public static RectangleStruct CCIntersect(RectangleStruct rect1, RectangleStruct rect2)
    // {
    //     RectangleStruct pOutBuffer = new();
    //     return Intersect(pOutBuffer.GetThisPointer(), rect1.GetThisPointer(), rect2.GetThisPointer()).Ref;
    // }
    public static RectangleStruct Intersect(RectangleStruct rect1, RectangleStruct rect2)
    {
        rect1 = rect1.Sort();
        rect2 = rect2.Sort();

        Point2D p1 = (Math.Clamp(rect2.X, rect1.X, rect1.X + rect1.Width), Math.Clamp(rect2.Y, rect1.Y, rect1.Y + rect1.Height));
        Point2D p2 = (Math.Clamp(rect2.X + rect2.Width, rect1.X, rect1.X + rect1.Width) - p1.X, Math.Clamp(rect2.Y + rect2.Height, rect1.Y, rect1.Y + rect1.Height) - p1.Y);

        return (p1, p2);
    }
}



[StructLayout(LayoutKind.Explicit, Size = 48)]
public struct ABufferClass
{
    private static IntPtr ppABuffer = new IntPtr(0x87E8A4);
    public static Pointer<ABufferClass> ABuffer { get => ((Pointer<Pointer<ABufferClass>>)ppABuffer).Data; set => ((Pointer<Pointer<ABufferClass>>)ppABuffer).Ref = value; }

    public unsafe Pointer<short> GetBufferAt(Point2D point)
    {
        var func = (delegate* unmanaged[Thiscall]<ref ABufferClass, int,int,IntPtr>)0x4114B0;
        return func(ref this, point.X, point.Y);
    }
    public unsafe Pointer<short> AdjustedGetBufferAt(Point2D point)
    {
        return GetBufferAt(point - new Point2D(0, Rect.Y));
    }

    [FieldOffset(0)] public RectangleStruct Rect;
    [FieldOffset(16)] public int _10;
    //[FieldOffset(20)] public Pointer<Surface> BSurface;
    [FieldOffset(24)] public Pointer<byte> BufferStart;
    [FieldOffset(28)] public Pointer<byte> BufferEndpoint;
    [FieldOffset(32)] public int BufferSize;
    [FieldOffset(36)] public int _24;
    [FieldOffset(40)] public int Width;
    [FieldOffset(44)] public int Height;

}

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public struct ZBufferClass
{
    private static IntPtr ppZBuffer = new IntPtr(0x887644);
    public static Pointer<ZBufferClass> ZBuffer { get => ((Pointer<Pointer<ZBufferClass>>)ppZBuffer).Data; set => ((Pointer<Pointer<ZBufferClass>>)ppZBuffer).Ref = value; }

    public unsafe Pointer<short> GetBufferAt(Point2D point)
    {
        var func = (delegate* unmanaged[Thiscall]<ref ZBufferClass, int, int, IntPtr>)0x7BD130;
        return func(ref this, point.X, point.Y);
    }
    public unsafe Pointer<short> AdjustedGetBufferAt(Point2D point)
    {
        return GetBufferAt(point - new Point2D(0, Rect.Y));
    }

    [FieldOffset(0)] public RectangleStruct Rect;
    [FieldOffset(16)] public int CurrentOffset;
    //[FieldOffset(20)] public Pointer<Surface> BSurface;
    [FieldOffset(24)] public Pointer<byte> BufferStart;
    [FieldOffset(28)] public Pointer<byte> BufferEndpoint;
    [FieldOffset(32)] public int BufferSize;
    [FieldOffset(36)] public int CurrentBaseZ;
    [FieldOffset(40)] public int Width;
    [FieldOffset(44)] public int Height;
}