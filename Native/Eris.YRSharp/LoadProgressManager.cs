using Eris.YRSharp.FileFormats;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct LoadProgressManager
{
    [FieldOffset(0)] public nint vfptr;
    [FieldOffset(4)] public uint field_4;
    [FieldOffset(8)] public uint field_8;
    [FieldOffset(12)] public uint field_C;
    [FieldOffset(16)] public uint field_10;
    [FieldOffset(20)] public uint field_14;
    [FieldOffset(24)] public uint field_18;
    [FieldOffset(28)] public uint field_1C;
    [FieldOffset(32)] public uint field_20;
    [FieldOffset(36)] public uint field_24;
    [FieldOffset(40)] public uint field_28;
    [FieldOffset(44)] public uint field_2C;
    [FieldOffset(48)] public uint field_30;
    [FieldOffset(52)] public uint field_34;
    [FieldOffset(56)] public uint field_38;
    [FieldOffset(60)] public nint loadMessage;
    public Pointer<char> LoadMessage => loadMessage;
    [FieldOffset(64)] public nint loadBriefing;
    public Pointer<char> LoadBriefing => loadBriefing;
    [FieldOffset(68)] public nint titleBarSHP;
    public Pointer<ShpStruct> TitleBarSHP => titleBarSHP;
    [FieldOffset(72)] public nint loadBarSHP;
    public Pointer<ShpStruct> LoadBarSHP => loadBarSHP;
    [FieldOffset(76)] public nint backgroundSHP;
    public Pointer<ShpStruct> BackgroundSHP => backgroundSHP;
    [FieldOffset(80)] public Bool TitleBarSHP_loaded;
    [FieldOffset(81)] public Bool LoadBarSHP_loaded;
    [FieldOffset(82)] public Bool BackgroundSHP_loaded;
    [FieldOffset(84)] public uint field_54;
    [FieldOffset(88)] public uint field_58;
    [FieldOffset(92)] public uint field_5C;
    [FieldOffset(96)] public nint progressSurface;
    public Pointer<Surface> ProgressSurface => progressSurface;

}