using System.Runtime.CompilerServices;

namespace Eris.YRSharp;

public static class CellSpread
{
    public static int NumCells(int nSpread)
    {
        return new Pointer<int>(0x7ED3D0)[nSpread];
    }

    public static ref CellStruct GetCell(int n)
    {
        return ref new Pointer<CellStruct>(0xABD490)[n];
    }

    public static ref CellStruct GetNeighbourOffset(int direction)
    {
        if (direction > 7)
        {
            return ref Unsafe.NullRef<CellStruct>();
        }

        return ref new Pointer<CellStruct>(0x89F688)[direction];
    }

    public static int GetDistance(int dx, int dy)
    {
        var x = Math.Abs(dx);
        var y = Math.Abs(dy);

        return x > y ? x + y / 2 : y + x / 2;
    }

    public static int GetDistance(CellStruct offset)
    {
        return GetDistance(offset.X, offset.Y);
    }
}