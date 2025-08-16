using System.Runtime.CompilerServices;
using Eris.YRSharp.FileFormats;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct ProgressScreenClass
{
    public const nint instance = 0xAC4F58;
    public static ref ProgressScreenClass Instance => ref instance.Convert<ProgressScreenClass>().Ref;
    
    [FieldOffset(0)] public int field_0;
    [FieldOffset(4)] public nint loadManager;
    public Pointer<LoadProgressManager> LoadManager => loadManager;
    [FieldOffset(8)] public byte playerProgresses;
    public FixedArray<double> PlayerProgresses => new(ref Unsafe.As<byte, double>(ref playerProgresses), 8);
    [FieldOffset(72)] public int MainProgress;
    [FieldOffset(76)] public int field_4C;
    [FieldOffset(80)] public nint playerStartSpot;
    public Pointer<byte> PlayerStartSpot => playerStartSpot;
    [FieldOffset(84)] public nint someSHP;
    public Pointer<ShpStruct> SomeSHP => someSHP;
    [FieldOffset(88)] public byte field_58;
    [FieldOffset(89)] public byte field_59;
    [FieldOffset(90)] public byte field_5A;
    [FieldOffset(91)] public byte field_5B;
    [FieldOffset(92)] public int field_5C;
    [FieldOffset(96)] public byte field_60;
    [FieldOffset(97)] public byte TotalPlayers;
    [FieldOffset(98)] public byte field_62;
    [FieldOffset(99)] public byte field_63;
    [FieldOffset(100)] public uint hWnd;
    [FieldOffset(104)] public int field_68;
    [FieldOffset(108)] public int field_6C;
    [FieldOffset(112)] public byte field_70;
    [FieldOffset(113)] public byte field_71;
    [FieldOffset(114)] public byte field_72;
    [FieldOffset(115)] public byte field_73;
    [FieldOffset(116)] public int field_74;
    [FieldOffset(120)] public int field_78;
    [FieldOffset(124)] public int field_7C;
    [FieldOffset(128)] public int PlayerSide;

}