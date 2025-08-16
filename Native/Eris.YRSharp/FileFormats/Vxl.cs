using System.Numerics;

namespace Eris.YRSharp.FileFormats;

[StructLayout(LayoutKind.Explicit)]
public struct VoxLib
{
    public unsafe int ReadFile(Pointer<CCFileClass> ccFile, bool UseContainedPalette)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, int>)0x755DB0;
        return func(this.GetThisPointer(), ccFile, UseContainedPalette);
    }

    public unsafe Pointer<VoxelSectionHeader> leaSectionHeader(int headerIndex)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, nint>)0x7564A0;
        return func(this.GetThisPointer(), headerIndex);
    }

    public unsafe Pointer<VoxelSectionTailer> leaSectionTailer(int headerIndex, int a3)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, int, int, nint>)0x7564B0;
        return func(this.GetThisPointer(), headerIndex, a3);
    }

    [FieldOffset(0)] public Bool Initialized;
    [FieldOffset(4)] public uint CountHeaders;
    [FieldOffset(8)] public uint CountTailers;
    [FieldOffset(12)] public uint TotalSize;
    [FieldOffset(16)] public nint headerData;
    public Pointer<VoxelSectionHeader> HeaderData => headerData;
    [FieldOffset(20)] public nint tailerData;
    public Pointer<VoxelSectionTailer> TailerData => tailerData;
    [FieldOffset(24)] public nint bodyData;
    public Pointer<byte> BodyData => bodyData;
}

[StructLayout(LayoutKind.Sequential)]
public struct VoxelSectionHeader 
{
    public int limb_number;
    public int unk1;
    public char unk2;
}

[StructLayout(LayoutKind.Explicit)]
public struct VoxelSectionTailer
{
    [FieldOffset(0)] public int span_start_off;
    [FieldOffset(4)] public int span_end_off;
    [FieldOffset(8)] public int span_data_off;
    [FieldOffset(12)] public float HVAMultiplier;
    [FieldOffset(16)] public Matrix3D TransformationMatrix;
    [FieldOffset(64)] public Vector3 MinBounds;
    [FieldOffset(76)] public Vector3 MaxBounds;
    [FieldOffset(160)] public byte size_X;
    [FieldOffset(161)] public byte size_Y;
    [FieldOffset(162)] public byte size_Z;
    [FieldOffset(163)] public byte NormalsMode;
}