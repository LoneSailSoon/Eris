using System.Runtime.CompilerServices;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct RadarClass
{
    public const nint instance = 0x87F7E8;
    public static ref RadarClass Instance => ref instance.Convert<RadarClass>().Ref;

    public unsafe void DisposeOfArt()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(50);
        func(this.GetThisPointer());
    }

    public unsafe Pointer<byte> vt_entry_CC(Pointer<byte> out_pUnk, Pointer<Point2D> pPoint)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint>)this.GetVirtualFunctionPointer(51);
        return func(this.GetThisPointer(), out_pUnk, pPoint);
    }

    public unsafe void vt_entry_D0(uint dwUnk)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, void>)this.GetVirtualFunctionPointer(52);
        func(this.GetThisPointer(), dwUnk);
    }

    public unsafe void Init_For_House()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(53);
        func(this.GetThisPointer());
    }

    [FieldOffset(0)] public DisplayClass Base;
    [FieldOffset(4584)] public uint unknown_11E8;
    [FieldOffset(4588)] public uint unknown_11EC;
    [FieldOffset(4592)] public uint unknown_11F0;
    [FieldOffset(4596)] public uint unknown_11F4;
    [FieldOffset(4600)] public uint unknown_11F8;
    [FieldOffset(4604)] public uint unknown_11FC;
    [FieldOffset(4608)] public uint unknown_1200;
    [FieldOffset(4612)] public uint unknown_1204;
    [FieldOffset(4616)] public uint unknown_1208;
    [FieldOffset(4620)] public RectangleStruct unknown_rect_120C;
    [FieldOffset(4636)] public uint unknown_121C;
    [FieldOffset(4640)] public uint unknown_1220;
    [FieldOffset(4644)] public byte unknown_cells_1124;

    public ref DynamicVectorClass<CellStruct> Unknown_cells_1124 => ref Pointer<byte>.AsPointer(ref unknown_cells_1124)
        .Convert<DynamicVectorClass<CellStruct>>().Ref;

    [FieldOffset(4668)] public uint unknown_123C;
    [FieldOffset(4672)] public uint unknown_1240;
    [FieldOffset(4676)] public uint unknown_1244;
    [FieldOffset(4680)] public uint unknown_1248;
    [FieldOffset(4684)] public uint unknown_124C;
    [FieldOffset(4688)] public uint unknown_1250;
    [FieldOffset(4692)] public uint unknown_1254;
    [FieldOffset(4696)] public uint unknown_1258;
    [FieldOffset(4700)] public byte unknown_points_125C;

    public ref DynamicVectorClass<Point2D> Unknown_points_125C => ref Pointer<byte>.AsPointer(ref unknown_points_125C)
        .Convert<DynamicVectorClass<Point2D>>().Ref;

    [FieldOffset(4724)] public uint unknown_1274;
    [FieldOffset(4728)] public byte foundationTypePixels;

    public FixedArray<DynamicVectorClass<Point2D>> FoundationTypePixels =>
        new(ref Unsafe.As<byte, DynamicVectorClass<Point2D>>(ref foundationTypePixels), 22);

    [FieldOffset(5256)] public float RadarSizeFactor;
    [FieldOffset(5260)] public int unknown_int_148C;
    [FieldOffset(5264)] public uint unknown_1490;
    [FieldOffset(5268)] public uint unknown_1494;
    [FieldOffset(5272)] public uint unknown_1498;
    [FieldOffset(5276)] public RectangleStruct unknown_rect_149C;
    [FieldOffset(5292)] public uint unknown_14AC;
    [FieldOffset(5296)] public uint unknown_14B0;
    [FieldOffset(5300)] public uint unknown_14B4;
    [FieldOffset(5304)] public uint unknown_14B8;
    [FieldOffset(5308)] public Bool unknown_bool_14BC;
    [FieldOffset(5309)] public Bool unknown_bool_14BD;
    [FieldOffset(5312)] public uint unknown_14C0;
    [FieldOffset(5316)] public uint unknown_14C4;
    [FieldOffset(5320)] public uint unknown_14C8;
    [FieldOffset(5324)] public uint unknown_14CC;
    [FieldOffset(5328)] public uint unknown_14D0;
    [FieldOffset(5332)] public int unknown_int_14D4;
    [FieldOffset(5336)] public Bool IsAvailableNow;
    [FieldOffset(5337)] public Bool unknown_bool_14D9;
    [FieldOffset(5338)] public Bool unknown_bool_14DA;
    [FieldOffset(5340)] public RectangleStruct unknown_rect_14DC;
    [FieldOffset(5356)] public uint unknown_14EC;
    [FieldOffset(5360)] public uint unknown_14F0;
    [FieldOffset(5364)] public uint unknown_14F4;
    [FieldOffset(5368)] public uint unknown_14F8;
    [FieldOffset(5372)] public uint unknown_14FC;
    [FieldOffset(5376)] public TimerStruct unknown_timer_1500;
}