namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct CRCEngine
{
    [FieldOffset(0)] public int CRC;
    [FieldOffset(4)] public int Index;
    [FieldOffset(8)] public int Composite;
}