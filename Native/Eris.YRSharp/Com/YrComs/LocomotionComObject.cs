using Eris.Misc.Memoryor;
using Eris.YRSharp.Com.Interface;

namespace Eris.YRSharp.Com.YrComs;

public static class LocomotionComObject
{
    public static readonly Memoryor<InterfaceLocomotionVtable> LocomotionVtableILocomotion =
        new(LocomotionVtable_ILocomotion_Initialize);

    public static readonly Memoryor<InterfacePersistStreamVtable> LocomotionVtableIPersistStream =
        new(LocomotionVtable_IPersistStream_Initialize);


    public static void LocomotionVtable_ILocomotion_Initialize(ref InterfaceLocomotionVtable vtable)
    {
        vtable.BaseInterfaceUnknownVtable.QueryInterfacePtr = 0x4D0510;
        vtable.BaseInterfaceUnknownVtable.AddRefPtr = 0x4D0520;
        vtable.BaseInterfaceUnknownVtable.ReleasePtr = 0x4D0530;
        vtable.LinkToObject = 0x55A710;
        vtable.IsMoving = 0x55ACD0;
        vtable.Destination = 0x55AC70;
        vtable.HeadToCoord = 0x55ACA0;
        vtable.CanEnterCell = 0x55ABF0;
        vtable.IsToHaveShadow = 0x55ABE0;
        vtable.DrawMatrix = 0x55A730;
        vtable.ShadowMatrix = 0x55A7D0;
        vtable.DrawPoint = 0x55ABD0;
        vtable.ShadowPoint = 0x55A8C0;
        vtable.VisualCharacter = 0x55ABC0;
        vtable.ZAdjust = 0x55ABA0;
        vtable.ZGradient = 0x55ABB0;
        vtable.Process = 0x55AC60;
        vtable.MoveTo = 0x55AC50;
        vtable.StopMoving = 0x55AC40;
        vtable.DoTurn = 0x55AC30;
        vtable.Unlimbo = 0x55AC20;
        vtable.TiltPitchAi = 0x55AB90;
        vtable.PowerOn = 0x55A8F0;
        vtable.PowerOff = 0x55A910;
        vtable.IsPowered = 0x55A930;
        vtable.IsIonSensitive = 0x55A940;
        vtable.Push = 0x55AB70;
        vtable.Shove = 0x55AB80;
        vtable.ForceTrack = 0x55AC10;
        vtable.InWhichLayer = 0x4C9150;
        vtable.ForceImmediateDestination = 0x55AC00;
        vtable.ForceNewSlope = 0x55ACE0;
        vtable.IsMovingNow = 0x4B6610;
        vtable.ApparentSpeed = 0x55AD10;
        vtable.DrawingCode = 0x55ACF0;
        vtable.CanFire = 0x55AD00;
        vtable.GetStatus = 0x4B4C60;
        vtable.AcquireHunterSeekerTarget = 0x4B4C70;
        vtable.IsSurfacing = 0x4B4C80;
        vtable.MarkAllOccupationBits = 0x4B6620;
        vtable.IsMovingHere = 0x4B6630;
        vtable.WillJumpTracks = 0x4B6640;
        vtable.IsReallyMovingNow = 0x4B4C50;
        vtable.StopMovementAnimation = 0x4B4C90;
        vtable.Limbo = 0x4B4CA0;
        vtable.Lock = 0x4B6650;
        vtable.Unlock = 0x4B6660;
        vtable.GetTrackNumber = 0x4B6670;
        vtable.GetTrackIndex = 0x4B6680;
        vtable.GetSpeedAccum = 0x4B6690;
    }

    public static void LocomotionVtable_IPersistStream_Initialize(ref InterfacePersistStreamVtable vtable)
    {
        vtable.BaseInterfaceUnknownVtable.QueryInterfacePtr = 0x55A9B0;
        vtable.BaseInterfaceUnknownVtable.AddRefPtr = 0x55A950;
        vtable.BaseInterfaceUnknownVtable.ReleasePtr = 0x55A970;

        vtable.GetClassIDPtr = 0x4C9150;
        vtable.IsDirtyPtr = 0x4B4C30;
        vtable.LoadPtr = 0x55AAC0;
        vtable.SavePtr = 0x55AA60;
        vtable.GetSizeMaxPtr = 0x55AB40;
        vtable.DTORPtr = 0x5172F0;
        vtable.SizePtr = 0x4C9150;
    }
}