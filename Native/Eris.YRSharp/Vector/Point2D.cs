using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Eris.YRSharp.Vector;

[DebuggerDisplay("XY={X}, {Y}")]
[StructLayout(LayoutKind.Sequential)]
public struct Point2D(int x, int y) : IEquatable<Point2D>
{
    public int X = x;
    public int Y = y;

    public static Point2D operator -(Point2D a)
    {
        return new (-a.X, -a.Y);
    }

    public static Point2D operator +(Point2D a, Point2D b)
    {
        return new (
            a.X + b.X,
            a.Y + b.Y);
    }

    public static Point2D operator -(Point2D a, Point2D b)
    {
        return new (
            a.X - b.X,
            a.Y - b.Y);
    }

    public static Point2D operator *(Point2D a, double r)
    {
        return new (
            (int)(a.X * r),
            (int)(a.Y * r));
    }

    public static double operator *(Point2D a, Point2D b)
    {
        return a.X * b.X
               + a.Y * b.Y;
    }

    //magnitude
    public double Magnitude()
    {
        return Math.Sqrt(MagnitudeSquared());
    }

    //magnitude squared
    public double MagnitudeSquared()
    {
        return this * this;
    }

    public double DistanceFrom(Point2D other)
    {
        return (other - this).Magnitude();
    }
    
    public Point2D WithX(int x) => new(x, Y);
    
    public Point2D WithY(int y) => new(X, y);

    public Point2D MoveX(int x) => new(X + x, Y);
    public Point2D MoveY(int y) => new(X, Y + y);
    public Point2D Move(int x, int y) => new(X + x, Y + y);
    public Point2D Move(Point2D pos) => new(X + pos.X, Y + pos.Y);

    public void Deconstruct(out int x, out int y)
    {
        x = X;
        y = Y;
    }

    public static bool operator ==(Point2D a, Point2D b)
    {
        return a.X == b.X && a.Y == b.Y;
    }

    public static bool operator !=(Point2D a, Point2D b) => !(a == b);

    public override bool Equals(object obj) => obj is Point2D other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y);

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
    
    public static implicit operator Point2D((int x, int y) value) => new Point2D(value.x, value.y);
    public static implicit operator (int x, int y)(Point2D value) => (value.X, value.Y);

    public bool Equals(Point2D other)
    {
        return X == other.X && Y == other.Y;
    }
}