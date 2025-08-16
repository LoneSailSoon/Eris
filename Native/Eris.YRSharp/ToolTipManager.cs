using System.Runtime.CompilerServices;
using Eris.YRSharp.String.Ansi;
using Eris.YRSharp.String.Uni;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct ToolTip
{
    [FieldOffset(0)] public uint GadgetID;
    [FieldOffset(4)] public RectangleStruct Bounds;
    [FieldOffset(20)] public nint text;
    public AnsiStringPointer Text => text;
    [FieldOffset(24)] public Bool field_18;
}

[StructLayout(LayoutKind.Explicit)]
public struct ToolTipManagerData
{
    [FieldOffset(0)] public RectangleStruct Dimension;
    [FieldOffset(16)] public byte helpText;
    public UniStringPointer HelpText => new(ref Unsafe.As<byte, char>(ref helpText), 256);

}

[StructLayout(LayoutKind.Explicit)]
public struct ToolTipManager
{
    public unsafe bool Update(Pointer<ToolTipManagerData> from)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)this.GetVirtualFunctionPointer(1);
        return func(this.GetThisPointer(), from);
    }

    public unsafe void MarkToRedraw(Pointer<ToolTipManagerData> from)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)this.GetVirtualFunctionPointer(2);
        func(this.GetThisPointer(), from);
    }

    public unsafe void Draw(bool bOnSidebar)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, void>)this.GetVirtualFunctionPointer(3);
        func(this.GetThisPointer(), bOnSidebar);
    }

    public unsafe void DrawText(Pointer<ToolTipManagerData> from)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)this.GetVirtualFunctionPointer(4);
        func(this.GetThisPointer(), from);
    }

    public unsafe UniStringPointer GetToolTipText(uint ID)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, nint>)this.GetVirtualFunctionPointer(5);
        return func(this.GetThisPointer(), ID);
    }

    public unsafe void SetState(bool bState)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, void>)0x7241A0;
        func(this.GetThisPointer(), bState);
    }

// public unsafe void ProcessMessage(Pointer<MSG> pMSG)
// {
//     var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x724200;
//     func(this.GetThisPointer(), pMSG);
// }
    public unsafe int GetTimerDelay()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)0x724510;
        return func(this.GetThisPointer());
    }

    public unsafe void SetTimerDelay(int value)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x724520;
        func(this.GetThisPointer(), value);
    }

    public unsafe void SaveTimerDelay()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x724530;
        func(this.GetThisPointer());
    }

    public unsafe void RestoreTimeDelay()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x724540;
        func(this.GetThisPointer());
    }

    public unsafe int GetLifeTime()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)0x724550;
        return func(this.GetThisPointer());
    }

    public unsafe void SetLifeTime(int value)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x724560;
        func(this.GetThisPointer(), value);
    }

    public unsafe int GetToolTipCount()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int>)0x724570;
        return func(this.GetThisPointer());
    }

    public unsafe bool Add(Pointer<ToolTip> tooltip)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool>)0x724580;
        return func(this.GetThisPointer(), tooltip);
    }

    public unsafe void Remove(uint ID)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, void>)0x724730;
        func(this.GetThisPointer(), ID);
    }

    public unsafe bool Find(uint ID, Pointer<ToolTip> tooltip)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, nint, bool>)0x7248C0;
        return func(this.GetThisPointer(), ID, tooltip);
    }

    public unsafe Pointer<ToolTip> FindFromPosition(Pointer<Point2D> point)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)0x724A30;
        return func(this.GetThisPointer(), point);
    }

    public unsafe bool Process()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x724AD0;
        return func(this.GetThisPointer());
    }

    public unsafe void Hide()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x724BE0;
        func(this.GetThisPointer());
    }

    public unsafe bool IsToolTipShowing()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x724C00;
        return func(this.GetThisPointer());
    }

    [FieldOffset(0)] public nint vtable;
    [FieldOffset(4)] public nint currentToolTip;
    public Pointer<ToolTip> CurrentToolTip => currentToolTip;
    [FieldOffset(8)] public uint hWnd;
    [FieldOffset(12)] public Bool IsActive;
    [FieldOffset(16)] public Point2D CurrentMousePosition;
    [FieldOffset(24)] public ToolTipManagerData CurrentToolTipData;
    [FieldOffset(552)] public int ToolTipDelay;
    [FieldOffset(556)] public int LastToolTipDelay;
    [FieldOffset(560)] public int ToolTipLifeTime;
    [FieldOffset(564)] public byte toolTips;

    public ref DynamicVectorClass<Pointer<ToolTip>> ToolTips => ref Pointer<byte>.AsPointer(ref toolTips)
        .Convert<DynamicVectorClass<Pointer<ToolTip>>>().Ref;

    [FieldOffset(588)] public byte toolTipIndex;
}