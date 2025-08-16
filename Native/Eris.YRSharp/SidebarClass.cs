using System.Runtime.CompilerServices;
using Eris.YRSharp.GeneralDefinitions;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 52)]
public struct BuildType
{
    [FieldOffset(0)] public int ItemIndex;
    [FieldOffset(4)] public AbstractType ItemType;
    [FieldOffset(8)] public Bool IsAlt;
    [FieldOffset(12)] public nint currentFactory;
    public Pointer<FactoryClass> CurrentFactory => currentFactory;
    [FieldOffset(16)] public uint unknown_10;
    [FieldOffset(20)] public ProgressTimer Progress;
    [FieldOffset(48)] public int FlashEndFrame;
}

[StructLayout(LayoutKind.Explicit, Size = 3988)]
public struct StripClass
{
    [FieldOffset(0)] public ProgressTimer Progress;
    [FieldOffset(28)] public Bool AllowedToDraw;
    [FieldOffset(32)] public Point2D Location;
    [FieldOffset(40)] public RectangleStruct Bounds;
    [FieldOffset(56)] public int Index;
    [FieldOffset(60)] public Bool NeedsRedraw;
    [FieldOffset(61)] public byte unknown_3D;
    [FieldOffset(62)] public byte unknown_3E;
    [FieldOffset(63)] public byte unknown_3F;
    [FieldOffset(64)] public uint unknown_40;
    [FieldOffset(68)] public int TopRowIndex;
    [FieldOffset(72)] public uint unknown_48;
    [FieldOffset(76)] public uint unknown_4C;
    [FieldOffset(80)] public uint unknown_50;
    [FieldOffset(84)] public int CameoCount;
    [FieldOffset(88)] public byte cameos;
    public FixedArray<BuildType> Cameos => new(ref Unsafe.As<byte, BuildType>(ref cameos), 75);
}

[StructLayout(LayoutKind.Explicit, Size = 0x5518)]
public struct SidebarClass
{
    public const nint ppInstance = 0x87F7E8;

    public static Pointer<SidebarClass> pInstance => ppInstance;

    public static ref SidebarClass Instance => ref pInstance.Ref;

    public unsafe bool AddCameo(AbstractType absType, int idxType)
        => ((delegate* unmanaged[Thiscall]<nint, AbstractType, int, Bool>)0x6A6300)(this.GetThisPointer(), absType,
            idxType);

    //public static unsafe int GetObjectTabIdx(AbstractType abs, int idxType, int unused)
    //    => ((delegate* unmanaged[Thiscall]<int, AbstractType, int, int, int>)ASM.FastCallTransferStation)(0x6ABC60, abs, idxType, unused);

    public unsafe void RepaintSidebar(int tab = 0)
        => ((delegate* unmanaged[Thiscall]<nint, int, void>)0x6A60A0)(this.GetThisPointer(), tab);

    [FieldOffset(0)] public PowerClass Base;

    [FieldOffset(5444)] public byte tabs;
    public FixedArray<StripClass> Tabs => new(ref Unsafe.As<byte, StripClass>(ref tabs), 4);
    [FieldOffset(21396)] public uint unknown_5394;
    [FieldOffset(21400)] public uint unknown_5398;
    [FieldOffset(21404)] public int ActiveTabIndex;
    [FieldOffset(21408)] public uint unknown_53A0;
    [FieldOffset(21412)] public Bool HideObjectNameInTooltip;
    [FieldOffset(21413)] public Bool IsSidebarActive;
    [FieldOffset(21414)] public Bool SidebarNeedsRedraw;
    [FieldOffset(21415)] public Bool SidebarBackgroundNeedsRedraw;
    [FieldOffset(21416)] public Bool unknown_bool_53A8;
    [FieldOffset(21420)] public byte diplomacyHouses;

    public FixedArray<Pointer<HouseClass>> DiplomacyHouses =>
        new(ref Unsafe.As<byte, Pointer<HouseClass>>(ref diplomacyHouses), 8);

    [FieldOffset(21452)] public byte diplomacyKills;
    public FixedArray<int> DiplomacyKills => new(ref Unsafe.As<byte, int>(ref diplomacyKills), 8);
    [FieldOffset(21484)] public byte diplomacyOwned;
    public FixedArray<int> DiplomacyOwned => new(ref Unsafe.As<byte, int>(ref diplomacyOwned), 8);
    [FieldOffset(21516)] public byte diplomacyPowerDrain;
    public FixedArray<int> DiplomacyPowerDrain => new(ref Unsafe.As<byte, int>(ref diplomacyPowerDrain), 8);
    [FieldOffset(21548)] public byte diplomacyColors;

    public FixedArray<Pointer<ColorScheme>> DiplomacyColors =>
        new(ref Unsafe.As<byte, Pointer<ColorScheme>>(ref diplomacyColors), 8);

    [FieldOffset(21580)] public byte unknown_544C;
    public FixedArray<uint> Unknown_544C => new(ref Unsafe.As<byte, uint>(ref unknown_544C), 8);
    [FieldOffset(21612)] public byte unknown_546C;
    public FixedArray<uint> Unknown_546C => new(ref Unsafe.As<byte, uint>(ref unknown_546C), 8);
    [FieldOffset(21644)] public byte unknown_548C;
    public FixedArray<uint> Unknown_548C => new(ref Unsafe.As<byte, uint>(ref unknown_548C), 8);
    [FieldOffset(21676)] public byte unknown_54AC;
    public FixedArray<uint> Unknown_54AC => new(ref Unsafe.As<byte, uint>(ref unknown_54AC), 8);
    [FieldOffset(21708)] public byte unknown_54CC;
    public FixedArray<uint> Unknown_54CC => new(ref Unsafe.As<byte, uint>(ref unknown_54CC), 8);
    [FieldOffset(21740)] public byte unknown_54EC;
    public FixedArray<uint> Unknown_54EC => new(ref Unsafe.As<byte, uint>(ref unknown_54EC), 8);
    [FieldOffset(21772)] public byte unknown_550C;
    [FieldOffset(21776)] public int DiplomacyNumHouses;
    [FieldOffset(21780)] public Bool unknown_bool_5514;
    [FieldOffset(21781)] public Bool unknown_bool_5515;
}