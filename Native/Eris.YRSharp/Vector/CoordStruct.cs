using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Eris.YRSharp.Vector;

[DebuggerDisplay("XYZ={X}, {Y}, {Z}")]
[StructLayout(LayoutKind.Sequential)]
public struct CoordStruct(int x, int y, int z) : IEquatable<CoordStruct>
{
    public static CoordStruct Zero => new(0, 0, 0);

    public static CoordStruct operator -(CoordStruct a)
    {
        return new CoordStruct(-a.X, -a.Y, -a.Z);
    }

    public static CoordStruct operator +(CoordStruct a, CoordStruct b)
    {
        return new CoordStruct(
            a.X + b.X,
            a.Y + b.Y,
            a.Z + b.Z);
    }

    public static CoordStruct operator -(CoordStruct a, CoordStruct b)
    {
        return new CoordStruct(
            a.X - b.X,
            a.Y - b.Y,
            a.Z - b.Z);
    }

    public static CoordStruct operator *(CoordStruct a, double r)
    {
        return new CoordStruct(
            (int)(a.X * r),
            (int)(a.Y * r),
            (int)(a.Z * r));
    }

    public static CoordStruct operator /(CoordStruct a, double r)
    {
        return new CoordStruct(
            (int)(a.X / r),
            (int)(a.Y / r),
            (int)(a.Z / r));
    }

    public static double operator *(CoordStruct a, CoordStruct b)
    {
        return a.X * b.X
               + a.Y * b.Y
               + a.Z * b.Z;
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

    public readonly double DistanceFrom(CoordStruct other)
    {
        return (other - this).Magnitude();
    }

    public readonly double DistanceFrom(CoordStruct other, bool ignoreZ)
    {
        return (ignoreZ ? other - this : (other - this).XY0).Magnitude();
    }

    public static bool operator ==(CoordStruct a, CoordStruct b)
    {
        return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
    }

    public static bool operator !=(CoordStruct a, CoordStruct b) => !(a == b);

    public override bool Equals(object obj) => obj is CoordStruct other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y, Z);

    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }

    public static explicit operator double(CoordStruct value) => value.DistanceFrom(Zero);

    public static explicit operator Vector3(CoordStruct value) => new (value.X, value.Y, value.Z);

    public static implicit operator CoordStruct(Vector3 value) =>
        new CoordStruct((int)value.X, (int)value.Y, (int)value.Z);

    public static implicit operator CoordStruct((int, int, int) value) =>
        new CoordStruct(value.Item1, value.Item2, value.Item3);

    public static explicit operator BulletVelocity(CoordStruct value) => new BulletVelocity(value.X, value.Y, value.Z);

    public static implicit operator CoordStruct(BulletVelocity value) =>
        new CoordStruct((int)value.X, (int)value.Y, (int)value.Z);

    public int X = x;
    public int Y = y;
    public int Z = z;

    public int F
    {
        get => X;
        set => X = value;
    }

    public int L
    {
        get => Y;
        set => Y = value;
    }

    public int H
    {
        get => Z;
        set => Z = value;
    }

    public CoordStruct XY0 => new(X, Y, 0);
    
    public CoordStruct WithX(int x) => new(x, Y, Z);
    public CoordStruct WithY(int y) => new(X, y, Z);
    public CoordStruct WithZ(int z) => new(X, Y, z);
    
    public CoordStruct MoveX(int x) => WithX(X + x);
    public CoordStruct MoveY(int y) => WithY(Y + y);
    public CoordStruct MoveZ(int z) => WithZ(Z + z);
    public CoordStruct Move(CoordStruct other) => this + other;

    public static CoordStruct One => new(1, 1, 1);

    public bool Equals(CoordStruct other)
    {
        return X == other.X && Y == other.Y && Z == other.Z;
    }

    public void Deconstruct(out int x, out int y, out int z)
    {
        x = X;
        y = Y;
        z = Z;
    }
}