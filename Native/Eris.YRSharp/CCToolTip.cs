namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct CCToolTip
{
    // static constexpr reference<bool, 0x884B8C> HideName {};
    // static constexpr reference<CCToolTip*, 0x887368> Instance {};
    // static constexpr reference<RGBClass, 0xB0FA1C> ToolTipTextColor{};
    public const nint hideName = 0x884B8C;
    public static ref Bool HideName => ref hideName.Convert<Bool>().Ref;
    public const nint instance = 0x887368;
    public static ref CCToolTip Instance => ref instance.Convert<CCToolTip>().Ref;
    public const nint toolTipTextColor = 0xB0FA1C;
    public static ref ColorStruct ToolTipTextColor => ref toolTipTextColor.Convert<ColorStruct>().Ref;
    
    [FieldOffset(0)] public ToolTipManager Base;
    [FieldOffset(608)] public Bool FullRedraw;
    [FieldOffset(612)] public int Delay;
}