using System.Runtime.InteropServices;
using PatcherYrSharp.GeneralStructures;
using PatcherYrSharp.Helpers;

namespace PatcherYrSharp;

[StructLayout(LayoutKind.Explicit, Size = 24)]
public struct LocomotionClass
{
    private const IntPtr _pGUIDs = 0x7E9A30;
    private static Pointer<Guid> pGUIDs => _pGUIDs.Convert<Guid>();

    public static Guid Drive => pGUIDs[0]; /* 0x7E9A30;*/

    public static Guid Hover => pGUIDs[1]; /* 0x7E9A40;*/

    public static Guid Tunnel => pGUIDs[2]; /* 0x7E9A50;*/

    public static Guid Walk => pGUIDs[3]; /* 0x7E9A60;*/

    public static Guid Droppod => pGUIDs[4]; /* 0x7E9A70;*/

    public static Guid Fly => pGUIDs[5]; /* 0x7E9A80;*/

    public static Guid Teleport => pGUIDs[6]; /* 0x7E9A90;*/

    public static Guid Mech => pGUIDs[7]; /* 0x7E9AA0;*/

    public static Guid Ship => pGUIDs[8]; /* 0x7E9AB0;*/

    public static Guid Jumpjet => pGUIDs[9]; /* 0x7E9AC0;*/

    public static Guid Rocket => pGUIDs[10]; /*0x7E9AD0;*/

    [FieldOffset(0)] public nint IPersistStream;
    [FieldOffset(4)] public nint ILocomotion;
    [FieldOffset(8)] public nint Owner;
    [FieldOffset(12)] public nint LinkedTo;
    [FieldOffset(16)] public byte Powered;
    [FieldOffset(17)] public byte Dirty;
    [FieldOffset(20)] public int RefCount;
}

[StructLayout(LayoutKind.Explicit, Size = 112)]
public struct DriveLocomotionClass
{
    [FieldOffset(24)] private nint _piggy;
    public ComPointer<IPiggyback> Piggy => _piggy;
    [FieldOffset(28)] public double Ramp1;
    [FieldOffset(32)] public double Ramp2;
    [FieldOffset(52)] public CoordStruct Destination; // 0x34 DriveLocomotionClass
    [FieldOffset(64)] public CoordStruct HeadToCoord; // 0x40 DriveLocomotionClass
    [FieldOffset(76)] public int Speed;
    [FieldOffset(80)] public double MovementSpeed;
    [FieldOffset(88)] public int TrackNumber;
    [FieldOffset(92)] public int TrackIndex;
    [FieldOffset(96)] public Bool IsOnShortTrack;
    [FieldOffset(97)] public Bool IsTurretLockedDown;
    [FieldOffset(98)] public Bool IsRotating; // 0x62 DriveLocomotionClass
    [FieldOffset(99)] public Bool IsDriving; // 0x63 DriveLocomotionClass
    [FieldOffset(101)] public Bool IsLocked; // 0x65 DriveLocomotionClass
}

[StructLayout(LayoutKind.Explicit, Size = 108)]
public struct ShipLocomotionClass
{
    [FieldOffset(24)] private nint _piggy;
    public ComPointer<IPiggyback> Piggy => _piggy;
    [FieldOffset(28)] public double Ramp1;
    [FieldOffset(32)] public double Ramp2;
    [FieldOffset(52)] public CoordStruct Destination; // 0x34 ShipLocomotionClass
    [FieldOffset(64)] public CoordStruct HeadToCoord; // 0x40 ShipLocomotionClass
    [FieldOffset(76)] public int Speed;
    [FieldOffset(80)] public double MovementSpeed;
    [FieldOffset(88)] public int TrackNumber;
    [FieldOffset(92)] public int TrackIndex;
    [FieldOffset(96)] public Bool IsOnShortTrack;
    [FieldOffset(97)] public Bool IsTurretLockedDown;
    [FieldOffset(98)] public Bool IsRotating; // 0x62 ShipLocomotionClass
    [FieldOffset(99)] public Bool IsDriving; // 0x63 ShipLocomotionClass
    [FieldOffset(101)] public Bool IsLocked; // 0x65 ShipLocomotionClass
}

[StructLayout(LayoutKind.Explicit, Size = 60)]
public struct WalkLocomotionClass
{
    [FieldOffset(24)] private nint _piggy;
    public ComPointer<IPiggyback> Piggy => _piggy;
    [FieldOffset(28)] public CoordStruct Destination;
    [FieldOffset(40)] public CoordStruct HeadToCoord;
    [FieldOffset(52)] public Bool IsMoving;
    [FieldOffset(54)] public Bool IsReallyMoving;
    [FieldOffset(56)] public Bool Piggyback;
}

[StructLayout(LayoutKind.Explicit, Size = 52)]
public struct MechLocomotionClass
{
    [FieldOffset(24)] public CoordStruct Destination; // 0x18 MechLocomotionClass
    [FieldOffset(36)] public CoordStruct HeadToCoord; // 0x24 MechLocomotionClass
    [FieldOffset(48)] public Bool IsMoving; // 0x30 MechLocomotionClass
    [FieldOffset(49)] public byte Unknown31; // 0x31 MechLocomotionClass
    [FieldOffset(50)] public byte Unknown32; // 0x32 MechLocomotionClass
    [FieldOffset(51)] public byte Unknown33; // 0x33 MechLocomotionClass
}

[StructLayout(LayoutKind.Explicit, Size = 152)]
public struct JumpjetLocomotionClass
{
    [FieldOffset(24)] private nint _piggy;
    public ComPointer<IPiggyback> Piggy => _piggy;
    [FieldOffset(28)] public double TurnRate;
    [FieldOffset(32)] public int Speed;
    [FieldOffset(36)] public float Climb;
    [FieldOffset(40)] public float Crash;
    [FieldOffset(44)] public int Height;
    [FieldOffset(48)] public float Accel;
    [FieldOffset(52)] public float Wobbles;
    [FieldOffset(56)] public int Deviation;
    [FieldOffset(60)] public Bool NoWobbles;
    [FieldOffset(64)] public CoordStruct HeadToCoord;
    [FieldOffset(76)] public Bool IsMoving;
    [FieldOffset(80)] public State State;

    [FieldOffset(84)] public FacingStruct LocomotionFacing;
    [FieldOffset(112)] public double CurrentSpeed;
    [FieldOffset(120)] public double MaxSpeed;
    [FieldOffset(128)] public int CurrentHeight;


    [FieldOffset(144)] public Bool occupy90__DestinationReached; // 抵达目的地
}

public enum State
{
    Grounded = 0,
    Ascending = 1,
    Hovering = 2,
    Cruising = 3,
    Descending = 4,
    Crashing = 5,
    Unknown = 6,
}

[StructLayout(LayoutKind.Explicit, Size = 96)]
public struct FlyLocomotionClass
{
    [FieldOffset(0)] public LocomotionClass Base;

    [FieldOffset(24)] public Bool AirportBound;
    [FieldOffset(28)] public CoordStruct MovingDestination;
    [FieldOffset(40)] public CoordStruct XYZ2;
    [FieldOffset(52)] public Bool HasMoveOrder;
    [FieldOffset(56)] public int FlightLevel;
    [FieldOffset(64)] public double TargetSpeed;
    [FieldOffset(72)] public double CurrentSpeed;
    [FieldOffset(80)] public byte IsTakingOff;
    [FieldOffset(81)] public Bool IsLanding;
    [FieldOffset(82)] public Bool WasLanding;
    [FieldOffset(83)] public Bool unknown_bool_53;
    [FieldOffset(84)] public int unknown_54;
    [FieldOffset(88)] public int unknown_58;
    [FieldOffset(92)] public Bool IsElevating;
    [FieldOffset(93)] public Bool unknown_bool_5D;
    [FieldOffset(94)] public Bool unknown_bool_5E;
    [FieldOffset(95)] public Bool unknown_bool_5F;
}