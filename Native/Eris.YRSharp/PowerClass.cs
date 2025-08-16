namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct PowerClass
{
    public const nint instance = 0x87F7E8;
    public static ref PowerClass Instance => ref instance.Convert<PowerClass>().Ref;

    [FieldOffset(0)] public RadarClass Base;
    [FieldOffset(5388)] public Bool unknown_bool_150C;
    [FieldOffset(5392)] public TimerStruct unknown_timer_1510;
    [FieldOffset(5404)] public uint unknown_151C;
    [FieldOffset(5408)] public TimerStruct unknown_timer_1520;
    [FieldOffset(5420)] public uint unknown_152C;
    [FieldOffset(5424)] public uint unknown_1530;
    [FieldOffset(5428)] public uint unknown_1534;
    [FieldOffset(5432)] public Bool unknown_bool_1538;
    [FieldOffset(5436)] public int PowerOutput;
    [FieldOffset(5440)] public int PowerDrain;

}