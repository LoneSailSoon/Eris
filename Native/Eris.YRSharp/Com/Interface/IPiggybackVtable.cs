namespace Eris.YRSharp.Com.Interface;

[StructLayout(LayoutKind.Sequential)]
public struct InterfacePiggybackVtable
{
     public InterfaceUnknownVtable BaseInterfaceUnknownVtable;
     public nint BeginPiggyback;
     public nint EndPiggyback;
     public nint IsOkToEnd;
     public nint PiggybackClsid;
     public nint IsPiggybacking;
}