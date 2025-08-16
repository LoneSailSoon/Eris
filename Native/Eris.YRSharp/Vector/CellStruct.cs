using System.Diagnostics;

namespace Eris.YRSharp.Vector;

[DebuggerDisplay("XY={X}, {Y}")]
[StructLayout(LayoutKind.Sequential)]
public struct CellStruct(int x, int y) : IEquatable<CellStruct>
{
    public static CellStruct operator -(CellStruct a)
    {
        return new CellStruct(-a.X, -a.Y);
    }

    public static CellStruct operator +(CellStruct a, CellStruct b)
    {
        return new CellStruct(
            a.X + b.X,
            a.Y + b.Y);
    }

    public static CellStruct operator -(CellStruct a, CellStruct b)
    {
        return new CellStruct(
            a.X - b.X,
            a.Y - b.Y);
    }

    public static CellStruct operator *(CellStruct a, double r)
    {
        return new CellStruct(
            (int)(a.X * r),
            (int)(a.Y * r));
    }

    public static double operator *(CellStruct a, CellStruct b)
    {
        return a.X * b.X
               + a.Y * b.Y;
    }

    //magnitude
    public readonly double Magnitude()
    {
        return Math.Sqrt(MagnitudeSquared());
    }

    //magnitude squared
    public readonly double MagnitudeSquared()
    {
        return this * this;
    }

    public readonly double DistanceFrom(CellStruct other)
    {
        return (other - this).Magnitude();
    }

    public static bool operator ==(CellStruct a, CellStruct b)
    {
        return a.X == b.X && a.Y == b.Y;
    }

    public static bool operator !=(CellStruct a, CellStruct b) => !(a == b);

    public override bool Equals(object obj) => obj is CellStruct other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y);

    public short X = (short)x;
    public short Y = (short)y;

    public override string ToString()
    {
        return $"({X}, {Y})";
    }

    public readonly bool Equals(CellStruct other)
    {
        return X == other.X && Y == other.Y;
    }

    public readonly void Deconstruct(out short x, out short y)
    {
        x = X;
        y = Y;
    }
}