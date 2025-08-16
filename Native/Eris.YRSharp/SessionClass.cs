using System.Runtime.CompilerServices;
using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.String.Ansi;
using Eris.YRSharp.String.Uni;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 12508)]
public struct SessionClass
{
    public const nint instance = 0xA8B238;
    public static ref SessionClass Instance => ref instance.Convert<SessionClass>().Ref;

    public unsafe void ReadScenarioDescriptions()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x699980;
        func(this.GetThisPointer());
    }

    public unsafe bool CreateConnections()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, bool>)0x697B70;
        return func(this.GetThisPointer());
    }

    public unsafe void Resume()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x69BAB0;
        func(this.GetThisPointer());
    }


    [FieldOffset(0)] public GameMode GameMode;
    [FieldOffset(4)] public nint mPGameMode;
    public Pointer<MPGameModeClass> MPGameMode => mPGameMode;
    [FieldOffset(8)] public uint unknown_08;
    [FieldOffset(12)] public uint unknown_0C;
    [FieldOffset(16)] public uint unknown_10;
    [FieldOffset(20)] public uint unknown_14;
    [FieldOffset(24)] public GameModeOptionsClass Config;
    [FieldOffset(324)] public uint UniqueID;
    [FieldOffset(328)] public byte handle;
    public FixedArray<byte> Handle => new(ref Unsafe.As<byte, byte>(ref handle), 20);
    [FieldOffset(348)] public int PlayerColor;
    [FieldOffset(352)] public uint unknown_160;
    [FieldOffset(356)] public uint unknown_164;
    [FieldOffset(360)] public uint unknown_168;
    [FieldOffset(364)] public uint unknown_16C;
    [FieldOffset(368)] public uint unknown_170;
    [FieldOffset(372)] public int idxSide;
    [FieldOffset(376)] public int idxSide2;
    [FieldOffset(380)] public int Color;
    [FieldOffset(384)] public int Color2;
    [FieldOffset(388)] public int Side;
    [FieldOffset(392)] public int Side2;
    [FieldOffset(396)] public SessionOptionsClass SkirmishPreferences;
    [FieldOffset(520)] public SessionOptionsClass LANPreferences;
    [FieldOffset(644)] public SessionOptionsClass WOLPreferences;
    [FieldOffset(768)] public int MuteSWLaunches;
    [FieldOffset(772)] public uint unknown_304;
    [FieldOffset(776)] public Bool WOLLimitResolution;
    [FieldOffset(780)] public int LastNickSlot;
    
    
    [FieldOffset(784)] public int MPlayerMax;
    [FieldOffset(788)] public int MPlayerCount;
    [FieldOffset(792)] public int MaxAhead;
    [FieldOffset(796)] public int FrameSendRate;
    [FieldOffset(800)] public int DesiredFrameRate;
    [FieldOffset(804)] public int ProcessTimer;
    [FieldOffset(808)] public int ProcessTicks;
    [FieldOffset(812)] public int ProcessFrames;
    [FieldOffset(816)] public int MaxMaxAhead;
    [FieldOffset(820)] public int PrecalcMaxAhead;
    [FieldOffset(824)] public int PrecalcDesiredFrameRate;
    [FieldOffset(784)] public MPStat mpstats;
    public FixedArray<MPStat> MPStats => new(ref mpstats, 8);
    [FieldOffset(1660)] public Bool EnableMultiplayerDebug;
    [FieldOffset(1661)] public Bool DrawMPDebugStats;
    [FieldOffset(1662)] public byte field_67E;
    [FieldOffset(1663)] public byte field_67F;
    [FieldOffset(1664)] public int LoadGame;
    [FieldOffset(1668)] public int SaveGame;
    [FieldOffset(1672)] public byte field_688;
    [FieldOffset(1673)] public Bool SawCompletion;
    [FieldOffset(1674)] public Bool OutOfSync;
    [FieldOffset(1675)] public byte field_68B;
    [FieldOffset(1676)] public int GameVersion;
    
    
    
    
    
    [FieldOffset(1704)] public byte scenarioFilename;
    public AnsiStringPointer ScenarioFilename => new(ref Unsafe.As<byte, byte>(ref scenarioFilename), 514);
    [FieldOffset(2218)] public uint unknown_8AA;
    [FieldOffset(10252)] public byte unknown_vector_280C;

    public ref DynamicVectorClass<Pointer<NodeNameType>> Unknown_vector_280C => ref Pointer<byte>
        .AsPointer(ref unknown_vector_280C).Convert<DynamicVectorClass<Pointer<NodeNameType>>>().Ref;

    [FieldOffset(10276)] public byte unknown_vector_2824;

    public ref DynamicVectorClass<Pointer<NodeNameType>> Unknown_vector_2824 => ref Pointer<byte>
        .AsPointer(ref unknown_vector_2824).Convert<DynamicVectorClass<Pointer<NodeNameType>>>().Ref;

    [FieldOffset(10300)] public byte startSpots;

    public ref DynamicVectorClass<Pointer<NodeNameType>> StartSpots => ref Pointer<byte>.AsPointer(ref startSpots)
        .Convert<DynamicVectorClass<Pointer<NodeNameType>>>().Ref;


}

[StructLayout(LayoutKind.Explicit)]
public struct MPStat
{
    [FieldOffset(0)] public byte name;
    public AnsiStringPointer Name => Pointer<byte>.AsPointer(ref name);
    [FieldOffset(64)] public int MaxRoundTrip;
    [FieldOffset(68)] public int Resends;
    [FieldOffset(72)] public int Lost;
    [FieldOffset(76)] public int PercentLost;
    [FieldOffset(80)] public int MaxAvgRoundTrip;
    [FieldOffset(84)] public int FrameSyncStalls;
    [FieldOffset(88)] public int CommandCoundStalls;
    [FieldOffset(92)] public IPXAddressClass Address;
}

[StructLayout(LayoutKind.Explicit)]
public struct NodeNameType
{
    [FieldOffset(0)] public byte name;
    public UniStringPointer Name => new(ref Unsafe.As<byte, char>(ref name), 20);
    // [FieldOffset(40)] public sockaddr_in Address;
    [FieldOffset(56)] public byte serial;
    public AnsiStringPointer Serial => new(ref Unsafe.As<byte, byte>(ref serial), 19);
    [FieldOffset(75)] public int Country;
    [FieldOffset(79)] public int InitialCountry;
    [FieldOffset(83)] public int Color;
    [FieldOffset(87)] public int InitialColor;
    [FieldOffset(91)] public int StartPoint;
    [FieldOffset(95)] public int InitialStartPoint;
    [FieldOffset(99)] public int Team;
    [FieldOffset(103)] public int InitialTeam;
    [FieldOffset(107)] public uint SpectatorFlag;
    [FieldOffset(111)] public int HouseIndex;
    [FieldOffset(115)] public int Time;
    [FieldOffset(119)] public uint unknown_int_77;
    [FieldOffset(123)] public int Clan;
    [FieldOffset(127)] public uint unknown_int_7F;
    [FieldOffset(131)] public byte unknown_byte_83;
    [FieldOffset(132)] public byte unknown_byte_84;

}

[StructLayout(LayoutKind.Explicit)]
public struct SessionOptionsClass
{
    [FieldOffset(0)] public int MPGameMode;
    [FieldOffset(4)] public int ScenIndex;
    [FieldOffset(8)] public int GameSpeed;
    [FieldOffset(12)] public int Credits;
    [FieldOffset(16)] public int UnitCount;
    [FieldOffset(20)] public Bool ShortGame;
    [FieldOffset(21)] public Bool SuperWeaponsAllowed;
    [FieldOffset(22)] public Bool BuildOffAlly;
    [FieldOffset(23)] public Bool MCVRepacks;
    [FieldOffset(24)] public Bool CratesAppear;
    [FieldOffset(28)] public byte slotData;
    public FixedArray<CoordStruct> SlotData => new(ref Unsafe.As<byte, CoordStruct>(ref slotData), 8);
}