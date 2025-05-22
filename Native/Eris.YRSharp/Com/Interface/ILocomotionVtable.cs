using System.Runtime.InteropServices;

namespace Eris.YRSharp.Com.Interface;

[StructLayout(LayoutKind.Sequential)]
public struct InterfaceLocomotionVtable
{
    public InterfaceUnknownVtable BaseInterfaceUnknownVtable;
    public nint LinkToObject;
    public nint IsMoving;
    public nint Destination;
    public nint HeadToCoord;
    public nint CanEnterCell;
    public nint IsToHaveShadow;
    public nint DrawMatrix;
    public nint ShadowMatrix;
    public nint DrawPoint;
    public nint ShadowPoint;
    public nint VisualCharacter;
    public nint ZAdjust;
    public nint ZGradient;
    public nint Process;
    public nint MoveTo;
    public nint StopMoving;
    public nint DoTurn;
    public nint Unlimbo;
    public nint TiltPitchAi;
    public nint PowerOn;
    public nint PowerOff;
    public nint IsPowered;
    public nint IsIonSensitive;
    public nint Push;
    public nint Shove;
    public nint ForceTrack;
    public nint InWhichLayer;
    public nint ForceImmediateDestination;
    public nint ForceNewSlope;
    public nint IsMovingNow;
    public nint ApparentSpeed;
    public nint DrawingCode;
    public nint CanFire;
    public nint GetStatus;
    public nint AcquireHunterSeekerTarget;
    public nint IsSurfacing;
    public nint MarkAllOccupationBits;
    public nint IsMovingHere;
    public nint WillJumpTracks;
    public nint IsReallyMovingNow;
    public nint StopMovementAnimation;
    public nint Limbo;
    public nint Lock;
    public nint Unlock;
    public nint GetTrackNumber;
    public nint GetTrackIndex;
    public nint GetSpeedAccum;
}