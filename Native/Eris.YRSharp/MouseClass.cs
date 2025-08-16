namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 28)]
public struct MouseCursor
{
    public const nint cursors = 0xABEFD8;

    public static FixedArray<MouseCursor> Cursors => new(cursors, 86);

    
    [FieldOffset(0)] public int Frame;
    [FieldOffset(4)] public int Count;
    [FieldOffset(8)] public int Interval;
    [FieldOffset(12)] public int MiniFrame;
    [FieldOffset(16)] public int MiniCount;
    [FieldOffset(20)] public MouseHotSpotX HotX;
    [FieldOffset(24)] public MouseHotSpotY HotY;

}

[StructLayout(LayoutKind.Explicit)]
public struct TabDataClass
{
    [FieldOffset(0)] public int TargetValue;
    [FieldOffset(4)] public int LastValue;
    [FieldOffset(8)] public Bool NeedsRedraw;
    [FieldOffset(9)] public Bool ValueIncreased;
    [FieldOffset(10)] public Bool ValueChanged;
    [FieldOffset(12)] public int ValueDelta;
}

[StructLayout(LayoutKind.Explicit)]
public struct TabClass
{
    public const nint instance = 0x87F7E8;

    public static ref TabClass Instance => ref instance.Convert<TabClass>().Ref;

    public unsafe void Activate(int control = 1)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, void>)0x6D04F0;
        func(this.GetThisPointer(), control);
    }


    [FieldOffset(0)] public SidebarClass Base;
    [FieldOffset(21784)] public nint INoticeSink;
    [FieldOffset(21788)] public TabDataClass TabData;
    [FieldOffset(21804)] public TimerStruct unknown_timer_552C;
    [FieldOffset(21816)] public TimerStruct InsufficientFundsBlinkTimer;
    [FieldOffset(21828)] public byte unknown_byte_5544;
    [FieldOffset(21829)] public Bool MissionTimerPinged;
    [FieldOffset(21830)] public byte unknown_byte_5546;

}

[StructLayout(LayoutKind.Explicit)]
public struct ScrollClass
{    
    public const nint instance = 0x87F7E8;

    public static ref ScrollClass Instance => ref instance.Convert<ScrollClass>().Ref;


    [FieldOffset(0)] public TabClass Base;
    [FieldOffset(21832)] public uint unknown_int_5548;
    [FieldOffset(21836)] public byte unknown_byte_554C;
    [FieldOffset(21840)] public uint unknown_int_5550;
    [FieldOffset(21844)] public uint unknown_int_5554;
    [FieldOffset(21848)] public byte unknown_byte_5558;
    [FieldOffset(21849)] public byte unknown_byte_5559;
    [FieldOffset(21850)] public byte unknown_byte_555A;

}

[StructLayout(LayoutKind.Explicit)]
public struct MouseClass
{    
    public const nint instance = 0x87F7E8;

    public static ref MouseClass Instance => ref instance.Convert<MouseClass>().Ref;


    [FieldOffset(0)] public ScrollClass Base;
    [FieldOffset(21852)] public Bool MouseCursorIsMini;
    [FieldOffset(21856)] public MouseCursorType MouseCursorIndex;
    [FieldOffset(21860)] public MouseCursorType MouseCursorLastIndex;
    [FieldOffset(21864)] public int MouseCursorCurrentFrame;
}