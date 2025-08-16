namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct GadgetClass
{
    public unsafe uint Input()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint>)this.GetVirtualFunctionPointer(10);
        return func(this.GetThisPointer());
    }

    public unsafe void DrawAll(bool bForced)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, void>)this.GetVirtualFunctionPointer(11);
        func(this.GetThisPointer(), bForced);
    }

    public unsafe void DeleteList()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(12);
        func(this.GetThisPointer());
    }

    public unsafe Pointer<GadgetClass> ExtractGadget(uint nID)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, nint>)this.GetVirtualFunctionPointer(13);
        return func(this.GetThisPointer(), nID);
    }

    public unsafe void MarkListToRedraw()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(14);
        func(this.GetThisPointer());
    }

    public unsafe void Disable()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(15);
        func(this.GetThisPointer());
    }

    public unsafe void Enable()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(16);
        func(this.GetThisPointer());
    }

    public unsafe uint GetID()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint>)this.GetVirtualFunctionPointer(17);
        return func(this.GetThisPointer());
    }

    public unsafe void MarkRedraw()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(18);
        func(this.GetThisPointer());
    }

    public unsafe void PeerToPeer(uint Flags, Pointer<uint> pKey, Pointer<GadgetClass> pSendTo)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, uint, nint, nint, void>)this.GetVirtualFunctionPointer(19);
        func(this.GetThisPointer(), Flags, pKey, pSendTo);
    }

    public unsafe void SetFocus()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(20);
        func(this.GetThisPointer());
    }

    public unsafe void KillFocus()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(21);
        func(this.GetThisPointer());
    }

    public unsafe bool IsFocused()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(22);
        return func(this.GetThisPointer());
    }

    public unsafe bool IsListToRedraw()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(23);
        return func(this.GetThisPointer());
    }

    public unsafe bool IsToRedraw()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(24);
        return func(this.GetThisPointer());
    }

    public unsafe void SetPosition(int X, int Y)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, int, void>)this.GetVirtualFunctionPointer(25);
        func(this.GetThisPointer(), X, Y);
    }

    public unsafe void SetDimension(int Width, int Height)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, int, void>)this.GetVirtualFunctionPointer(26);
        func(this.GetThisPointer(), Width, Height);
    }

    public unsafe bool Draw(bool bForced)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool, bool>)this.GetVirtualFunctionPointer(27);
        return func(this.GetThisPointer(), bForced);
    }

    public unsafe void OnMouseEnter()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(28);
        func(this.GetThisPointer());
    }

    public unsafe void OnMouseLeave()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(29);
        func(this.GetThisPointer());
    }

    public unsafe void StickyProcess(GadgetFlag flags)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, GadgetFlag, void>)this.GetVirtualFunctionPointer(30);
        func(this.GetThisPointer(), flags);
    }

    public unsafe bool Action(GadgetFlag flags, Pointer<uint> pKey, KeyModifier Modifier)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, GadgetFlag, nint, KeyModifier, bool>)this
                .GetVirtualFunctionPointer(31);
        return func(this.GetThisPointer(), flags, pKey, Modifier);
    }

    public unsafe bool Clicked(Pointer<uint> pKey, GadgetFlag flags, int X, int Y, KeyModifier Modifier)
    {
        var func =
            (delegate* unmanaged[Thiscall]<nint, nint, GadgetFlag, int, int, KeyModifier, bool>)this
                .GetVirtualFunctionPointer(32);
        return func(this.GetThisPointer(), pKey, flags, X, Y, Modifier);
    }


    [FieldOffset(0)] public LinkClass Base;

    [FieldOffset(12)] public RectangleStruct Rect;
    [FieldOffset(28)] public Bool NeedsRedraw;
    [FieldOffset(29)] public Bool IsSticky;
    [FieldOffset(30)] public Bool Disabled;
    [FieldOffset(32)] public GadgetFlag Flags;
}

public enum KeyModifier : int
{
    None = 0,
    Shift = 1,
    Ctrl = 2,
    Alt = 4
}

public enum GadgetFlag : int
{
    LeftPress = 0x1,
    LeftHeld = 0x2,
    LeftRelease = 0x4,
    LeftUp = 0x8,
    RightPress = 0x10,
    RightHeld = 0x20,
    RightRelease = 0x40,
    RightUp = 0x80,
    Keyboard = 0x100
}