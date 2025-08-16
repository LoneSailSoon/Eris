using System.Runtime.CompilerServices;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct CDDriveManagerClass
{
    private const nint instance = 0xA8E8E8;
    public static ref CDDriveManagerClass Instance => ref instance.Convert<CDDriveManagerClass>().Ref;

    
    [FieldOffset(0)] public byte cDDriveNames;
    public FixedArray<int> CDDriveNames => new(ref Unsafe.As<byte, int>(ref cDDriveNames), 26);
    [FieldOffset(104)] public int NumCDDrives;
    [FieldOffset(108)] public int unknown_6C;
}