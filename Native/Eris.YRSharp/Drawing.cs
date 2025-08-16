using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

public static class Drawing
{
    public const nint tooltipColor = 0xB0FA1C;
    public static ref ColorStruct TooltipColor => ref tooltipColor.Convert<ColorStruct>().Ref;

    public const nint dirtyAreas = 0xB0CE78;

    public static ref DynamicVectorClass<DirtyAreaStruct> DirtyAreas =>
        ref DynamicVectorClass<DirtyAreaStruct>.GetDynamicVector(dirtyAreas);

    public const nint colorMode = 0x8205D0;
    
    public static ref ColorStruct ColorMode => ref colorMode.Convert<ColorStruct>().Ref;
    
    public static int Color16Bit(ColorStruct color)
    {
        return (color.B >> 3) | ((color.G >> 2) << 5) | ((color.R >> 3) << 11);
    }

    public static ColorStruct WordColor(int bits)
    {
        ColorStruct color;
        color.R = (byte)(((bits & 0b_11111_000000_00000) >> 11) << 3);
        color.G = (byte)((byte)((bits & 0b_111111_00000) >> 5) << 2); // msvc stupid warning
        color.B = (byte)((bits & 0b_11111) << 3);
        return color;
    }
    
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
    private const nint ppABuffer = 0x87E8A4;

    public static Pointer<ABufferClass> ABuffer
    {
        get => ((Pointer<Pointer<ABufferClass>>)ppABuffer).Data;
        set => ((Pointer<Pointer<ABufferClass>>)ppABuffer).Ref = value;
    }

    public unsafe Pointer<short> GetBufferAt(Point2D point)
    {
        var func = (delegate* unmanaged[Thiscall]<ref ABufferClass, int, int, IntPtr>)0x4114B0;
        return func(ref this, point.X, point.Y);
    }

    public unsafe Pointer<short> AdjustedGetBufferAt(Point2D point)
    {
        return GetBufferAt(point - new Point2D(0, Rect.Y));
    }

    public unsafe bool BlitTo(Pointer<Surface> pSurface, int X, int Y, int Offset, int Size)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int, int, int, int, bool>)0x410DC0;
        return func(this.GetThisPointer(), pSurface, X, Y, Offset, Size);
    }

    public unsafe void ReleaseSurface()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x410E50;
        func(this.GetThisPointer());
    }

    public unsafe void Blitter(Pointer<ushort> Data, int Length, ushort Value)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int, ushort, void>)0x410E70;
        func(this.GetThisPointer(), Data, Length, Value);
    }

    public unsafe void BlitAt(int X, int Y, uint Color)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, int, uint, void>)0x410ED0;
        func(this.GetThisPointer(), X, Y, Color);
    }

    public unsafe bool Fill(ushort Color)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, ushort, bool>)0x4112D0;
        return func(this.GetThisPointer(), Color);
    }

    public unsafe bool FillRect(ushort Color, RectangleStruct rect)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, ushort, RectangleStruct, bool>)0x411310;
        return func(this.GetThisPointer(), Color, rect);
    }

    public unsafe void BlitRect(RectangleStruct rect)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, RectangleStruct, void>)0x411330;
        func(this.GetThisPointer(), rect);
    }

    public unsafe Pointer<byte> GetBuffer(int X, int Y)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, int, nint>)0x4114B0;
        return func(this.GetThisPointer(), X, Y);
    }

    [FieldOffset(0)] public RectangleStruct Rect;
    [FieldOffset(16)] public int _10;
    [FieldOffset(20)] public Pointer<Surface> BSurface;
    [FieldOffset(24)] public Pointer<byte> BufferStart;
    [FieldOffset(28)] public Pointer<byte> BufferEndpoint;
    [FieldOffset(32)] public int BufferSize;
    [FieldOffset(36)] public int _24;
    [FieldOffset(40)] public int Width;
    [FieldOffset(44)] public int Height;

}

[StructLayout(LayoutKind.Explicit, Size = 48)]
public struct ZBufferClass
{
    private const nint ppZBuffer = 0x887644;
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
    
    public unsafe bool BlitTo(Pointer<Surface> pSurface, int X, int Y, int Offset, int Size)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int, int, int, int, bool>)0x7BCA50;
        return func(this.GetThisPointer(), pSurface, X, Y, Offset, Size);
    }
    public unsafe void ReleaseSurface()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x7BCAE0;
        func(this.GetThisPointer());
    }
    public unsafe void Blitter(Pointer<ushort> Data, int Length, ushort Value)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, int, ushort, void>)0x7BCAF0;
        func(this.GetThisPointer(), Data, Length, Value);
    }
    public unsafe void BlitAt(int X, int Y, uint Color)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, int, uint, void>)0x7BCB50;
        func(this.GetThisPointer(), X, Y, Color);
    }
    public unsafe bool Fill(ushort Color)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, ushort, bool>)0x7BCF50;
        return func(this.GetThisPointer(), Color);
    }
    public unsafe bool FillRect(ushort Color, RectangleStruct rect)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, ushort, RectangleStruct, bool>)0x7BCF90;
        return func(this.GetThisPointer(), Color, rect);
    }
    public unsafe void BlitRect(RectangleStruct rect)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, RectangleStruct, void>)0x7BCFB0;
        func(this.GetThisPointer(), rect);
    }
    public unsafe Pointer<byte> GetBuffer(int X, int Y)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, int, nint>)0x7BD130;
        return func(this.GetThisPointer(), X, Y);
    }



    [FieldOffset(0)] public RectangleStruct Rect;
    [FieldOffset(16)] public int CurrentOffset;
    [FieldOffset(20)] public Pointer<Surface> BSurface;
    [FieldOffset(24)] public Pointer<byte> BufferStart;
    [FieldOffset(28)] public Pointer<byte> BufferEndpoint;
    [FieldOffset(32)] public int BufferSize;
    [FieldOffset(36)] public int CurrentBaseZ;
    [FieldOffset(40)] public int Width;
    [FieldOffset(44)] public int Height;
}

[StructLayout(LayoutKind.Sequential, Size = 20)]
public struct DirtyAreaStruct
{
    public RectangleStruct Rect;
    public Bool alphabool10;
}

[StructLayout(LayoutKind.Sequential)]
public struct VoxelCacheStruct
{
    public short X;
    public short Y;
    public ushort Width;
    public ushort Height;
    public nint Buffer;
}

