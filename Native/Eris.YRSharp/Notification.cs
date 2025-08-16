namespace Eris.YRSharp;

using PointerExpiredNotification = Notification;
[StructLayout(LayoutKind.Explicit)]
public struct Notification
{
    public const nint notifyInvalidObject = 0xB0F720;
    public static ref PointerExpiredNotification NotifyInvalidObject => ref notifyInvalidObject.Convert<PointerExpiredNotification>().Ref;
    public const nint notifyInvalidType = 0xB0F670;
    public static ref PointerExpiredNotification NotifyInvalidType => ref notifyInvalidType.Convert<PointerExpiredNotification>().Ref;
    public const nint notifyInvalidAnim = 0xB0F5B8;
    public static ref PointerExpiredNotification NotifyInvalidAnim => ref notifyInvalidAnim.Convert<PointerExpiredNotification>().Ref;
    public const nint notifyInvalidHouse = 0xB0F6C8;
    public static ref PointerExpiredNotification NotifyInvalidHouse => ref notifyInvalidHouse.Convert<PointerExpiredNotification>().Ref;
    public const nint notifyInvalidTag = 0xB0F618;
    public static ref PointerExpiredNotification NotifyInvalidTag => ref notifyInvalidTag.Convert<PointerExpiredNotification>().Ref;
    public const nint notifyInvalidTrigger = 0xB0F708;
    public static ref PointerExpiredNotification NotifyInvalidTrigger => ref notifyInvalidTrigger.Convert<PointerExpiredNotification>().Ref;
    public const nint notifyInvalidFactory = 0xB0F640;
    public static ref PointerExpiredNotification NotifyInvalidFactory => ref notifyInvalidFactory.Convert<PointerExpiredNotification>().Ref;
    public const nint notifyInvalidWaypoint = 0xB0F5F0;
    public static ref PointerExpiredNotification NotifyInvalidWaypoint => ref notifyInvalidWaypoint.Convert<PointerExpiredNotification>().Ref;
    public const nint notifyInvalidTeam = 0xB0F5D8;
    public static ref PointerExpiredNotification NotifyInvalidTeam => ref notifyInvalidTeam.Convert<PointerExpiredNotification>().Ref;
    public const nint notifyInvalidNeuron = 0xB0F6F0;
    public static ref PointerExpiredNotification NotifyInvalidNeuron => ref notifyInvalidNeuron.Convert<PointerExpiredNotification>().Ref;
    public const nint notifyInvalidActionOrEvent = 0xB0F658;
    public static ref PointerExpiredNotification NotifyInvalidActionOrEvent => ref notifyInvalidActionOrEvent.Convert<PointerExpiredNotification>().Ref;

    [FieldOffset(0)] public byte array;
    public ref DynamicVectorClass<Pointer<AbstractClass>> Array => ref Pointer<byte>.AsPointer(ref array).Convert<DynamicVectorClass<Pointer<AbstractClass>>>().Ref;
}