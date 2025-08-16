using System.Diagnostics;

namespace Eris.YRSharp.Vector;

//Random number range
[StructLayout(LayoutKind.Sequential)]
public struct RandomStruct
{
    public int Min, Max;
}


[DebuggerDisplay("LTRB={Left}, {Top}, {Right}, {Bottom}")]
[StructLayout(LayoutKind.Sequential)]
public struct LtrbStruct(int x, int y, int z, int w)
{
    public override string ToString()
    {
        return $"({Left}, {Top}, {Right},{Bottom})";
    }

    public override int GetHashCode() => HashCode.Combine(Left, Top, Right, Bottom);

    public int Left = x;
    public int Top = y;
    public int Right = z;
    public int Bottom = w;
}

[StructLayout(LayoutKind.Explicit, Size = 828)]
public struct BytePalette
{
    public const int EntriesCount = 256;
    [FieldOffset(0)] public ColorStruct Entries_first;
    public Pointer<ColorStruct> Entries => Pointer<ColorStruct>.AsPointer(ref Entries_first);

    public ColorStruct this[int index]
    {
        get => Entries[index];
        set => Entries[index] = value;
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct TintStruct
{
    public int Red;
    public int Green;
    public int Blue;
}