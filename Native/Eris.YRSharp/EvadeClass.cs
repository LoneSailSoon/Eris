namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct EvadeClass
{
    public const nint instance = 0x8A38E0;
    public static ref EvadeClass Instance => ref instance.Convert<EvadeClass>().Ref;
    
    [FieldOffset(0)] public char CarryOverGlobals; //[50];
    [FieldOffset(52)] public int CarryOverMoney;
    [FieldOffset(56)] public int CarryOverTimer;
    [FieldOffset(60)] public int CarryOverDifficulty;
    [FieldOffset(64)] public short CarryOverStage;
}