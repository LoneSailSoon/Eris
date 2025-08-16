using System.Runtime.CompilerServices;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct LineTrail
{
    [FieldOffset(0)] public ColorStruct Color;
    [FieldOffset(4)] public nint owner;
    public Pointer<ObjectClass> Owner => owner;
    [FieldOffset(8)] public int Decrement;
    [FieldOffset(12)] public int ActiveSlot;
    [FieldOffset(16)] public byte trails;
    public FixedArray<LineTrailNode> Trails => new(ref Unsafe.As<byte, LineTrailNode>(ref trails), 32);
}

[StructLayout(LayoutKind.Explicit, Size = 16)]
public struct LineTrailNode
{
    [FieldOffset(0)] public CoordStruct Position;
    [FieldOffset(12)] public int Value;
}