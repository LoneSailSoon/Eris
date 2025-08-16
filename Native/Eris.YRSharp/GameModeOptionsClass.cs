using System.Runtime.CompilerServices;
using Eris.YRSharp.String.Uni;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct GameModeOptionsClass
{
    public const nint instance = 0xA8B250;

    public static ref GameModeOptionsClass Instance =>
        ref instance.Convert<GameModeOptionsClass>().Ref;

    [FieldOffset(0)] public int MPModeIndex;
    [FieldOffset(4)] public int ScenarioIndex;
    [FieldOffset(8)] public Bool Bases;
    [FieldOffset(12)] public int Money;
    [FieldOffset(16)] public Bool BridgeDestruction;
    [FieldOffset(17)] public Bool Crates;
    [FieldOffset(18)] public Bool ShortGame;
    [FieldOffset(19)] public Bool SWAllowed;
    [FieldOffset(20)] public Bool BuildOffAlly;
    [FieldOffset(24)] public int GameSpeed;
    [FieldOffset(28)] public Bool MultiEngineer;
    [FieldOffset(32)] public int UnitCount;
    [FieldOffset(36)] public int AIPlayers;
    [FieldOffset(40)] public int AIDifficulty;
    [FieldOffset(44)] public byte aISlotsAIDifficulties;
    public FixedArray<int> AISlotsAIDifficulties => new(ref Unsafe.As<byte, int>(ref aISlotsAIDifficulties), 8);
    [FieldOffset(76)] public byte aISlotsStartingSpots;
    public FixedArray<int> AISlotsStartingSpots => new(ref Unsafe.As<byte, int>(ref aISlotsStartingSpots), 8);
    [FieldOffset(108)] public byte aISlotsColours;
    public FixedArray<int> AISlotsColours => new(ref Unsafe.As<byte, int>(ref aISlotsColours), 8);
    [FieldOffset(140)] public byte aISlotsStarts;
    public FixedArray<int> AISlotsStarts => new(ref Unsafe.As<byte, int>(ref aISlotsStarts), 8);
    [FieldOffset(172)] public byte aISlotsTeams;
    public FixedArray<int> AISlotsTeams => new(ref Unsafe.As<byte, int>(ref aISlotsTeams), 8);
    [FieldOffset(204)] public Bool AlliesAllowed;
    [FieldOffset(205)] public Bool HarvesterTruce;
    [FieldOffset(206)] public Bool CTF;
    [FieldOffset(207)] public Bool FogOfWar;
    [FieldOffset(208)] public Bool MCVRedeploy;
    [FieldOffset(210)] public char mapDescription;
    public UniStringPointer MapDescription => Pointer<char>.AsPointer(ref mapDescription);

}