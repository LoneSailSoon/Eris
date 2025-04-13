using System.Runtime.InteropServices;

namespace PatcherYrSharp.Com.Interface;

[StructLayout(LayoutKind.Sequential)]
public struct InterfaceClassFactoryVtable(
    InterfaceUnknownVtable baseIUnknow,
    nint classIUnknow,
    nint interfaceIUnknow)

{
    public InterfaceUnknownVtable BaseInterfaceUnknownVtable = baseIUnknow;
    public nint CreateInstancePtr = classIUnknow;
    public nint LockServerPtr = interfaceIUnknow;
}