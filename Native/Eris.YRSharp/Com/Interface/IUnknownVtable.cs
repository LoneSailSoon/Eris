namespace Eris.YRSharp.Com.Interface;

[StructLayout(LayoutKind.Sequential)]
public struct InterfaceUnknownVtable(
    nint queryInterfacePtr,
    nint addRefPtr,
    nint releasePtr)
{
    public nint QueryInterfacePtr = queryInterfacePtr;
    public nint AddRefPtr = addRefPtr;
    public nint ReleasePtr = releasePtr;
}