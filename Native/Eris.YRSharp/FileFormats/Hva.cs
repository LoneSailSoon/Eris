namespace Eris.YRSharp.FileFormats;

[StructLayout(LayoutKind.Explicit)]
public struct MotLib
{
    [FieldOffset(0)] public Bool LoadedFailed;
    [FieldOffset(4)] public int LayerCount;
    [FieldOffset(8)] public int FrameCount;
    [FieldOffset(12)] public nint matrixes;
    public Pointer<Matrix3D> Matrixes => matrixes;
}