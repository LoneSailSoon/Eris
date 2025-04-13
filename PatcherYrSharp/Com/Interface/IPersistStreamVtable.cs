using System.Runtime.InteropServices;

namespace PatcherYrSharp.Com.Interface;

[StructLayout(LayoutKind.Sequential)]
public struct InterfacePersistStreamVtable
{
    public InterfaceUnknownVtable BaseInterfaceUnknownVtable;
    public nint GetClassIDPtr;
    public nint IsDirtyPtr;
    public nint LoadPtr;
    public nint SavePtr;
    public nint GetSizeMaxPtr;
    public nint DTORPtr;
    public nint SizePtr;
}