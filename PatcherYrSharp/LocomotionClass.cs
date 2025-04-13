using System.Runtime.InteropServices;
using PatcherYrSharp.Helpers;

namespace PatcherYrSharp;

[StructLayout(LayoutKind.Explicit, Size = 24)]
public struct LocomotionClass
{
    private const IntPtr _pGUIDs = 0x7E9A30;
    private static Pointer<Guid> pGUIDs => _pGUIDs.Convert<Guid>();
    public static Guid Drive { get => pGUIDs[0]; set => pGUIDs[0] = value; }/* 0x7E9A30;*/
    public static Guid Hover { get => pGUIDs[1]; set => pGUIDs[1] = value; }/* 0x7E9A40;*/
    public static Guid Tunnel { get => pGUIDs[2]; set => pGUIDs[2] = value; }/* 0x7E9A50;*/
    public static Guid Walk { get => pGUIDs[3]; set => pGUIDs[3] = value; }/* 0x7E9A60;*/
    public static Guid Droppod { get => pGUIDs[4]; set => pGUIDs[4] = value; }/* 0x7E9A70;*/
    public static Guid Fly { get => pGUIDs[5]; set => pGUIDs[5] = value; }/* 0x7E9A80;*/
    public static Guid Teleport { get => pGUIDs[6]; set => pGUIDs[6] = value; }/* 0x7E9A90;*/
    public static Guid Mech { get => pGUIDs[7]; set => pGUIDs[7] = value; }/* 0x7E9AA0;*/
    public static Guid Ship { get => pGUIDs[8]; set => pGUIDs[8] = value; }/* 0x7E9AB0;*/
    public static Guid Jumpjet { get => pGUIDs[9]; set => pGUIDs[9] = value; }/* 0x7E9AC0;*/
    public static Guid Rocket { get => pGUIDs[10]; set => pGUIDs[10] = value; } /*0x7E9AD0;*/

    [FieldOffset(0)]      public nint IPersistStream;
    [FieldOffset(4)]      public nint ILocomotion;
    [FieldOffset(8)]      public nint Owner;
    [FieldOffset(12)]     public nint LinkedTo;
    [FieldOffset(16)]     public byte Powered;
    [FieldOffset(17)]     public byte Dirty;
    [FieldOffset(20)] public int RefCount;







}