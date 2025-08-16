using System.Diagnostics;

namespace Eris.YRSharp.Vector;

[DebuggerDisplay("XYZ={X}, {Y}, {Z}")]
[StructLayout(LayoutKind.Sequential)]
public struct BulletVelocity(double x, double y, double z) : IEquatable<BulletVelocity>
{
    public static BulletVelocity operator -(BulletVelocity a)
    {
        return new BulletVelocity(-a.X, -a.Y, -a.Z);
    }

    public static BulletVelocity Add(BulletVelocity left, BulletVelocity right) =>
        new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

    public static BulletVelocity operator +(BulletVelocity a, BulletVelocity b)
    {
        return new BulletVelocity(
            a.X + b.X,
            a.Y + b.Y,
            a.Z + b.Z);
    }
    
    public static BulletVelocity Substract(BulletVelocity left, BulletVelocity right) =>
        new (left.X - right.X, left.Y - right.Y, left.Z - right.Z);
    
    public static BulletVelocity operator -(BulletVelocity a, BulletVelocity b)
    {
        return new (
            a.X - b.X,
            a.Y - b.Y,
            a.Z - b.Z);
    }
    
    public static BulletVelocity Multiply(BulletVelocity left, BulletVelocity right) =>
        new(left.X * right.X, left.Y * right.Y, left.Z * right.Z);

    public static BulletVelocity Multiply(BulletVelocity left, double right) =>
        new(left.X * right, left.Y * right, left.Z * right);


    public static BulletVelocity operator *(BulletVelocity a, double r)
    {
        return new (
            a.X * r,
            a.Y * r,
            a.Z * r);
    }

    public static BulletVelocity operator *(BulletVelocity a, BulletVelocity b)
    {
        return new (
            a.X * b.X,
            a.Y * b.Y,
            a.Z * b.Z);
    }
    
    public static BulletVelocity Divide(BulletVelocity left, BulletVelocity right) =>
        new(left.X / right.X, left.Y / right.Y, left.Z / right.Z);

    public static BulletVelocity Divide(BulletVelocity left, double r) =>
        new(left.X / r, left.Y / r, left.Z / r);


    public static BulletVelocity operator /(BulletVelocity a, double r)
    {
        return new (
            a.X / r,
            a.Y / r,
            a.Z / r);
    }

    public static BulletVelocity operator /(BulletVelocity a, BulletVelocity b)
    {
        return new (
            a.X / b.X,
            a.Y / b.Y,
            a.Z / b.Z);
    }

    //magnitude
    public readonly double Magnitude()
    {
        return Math.Sqrt(MagnitudeSquared());
    }

    //magnitude squared
    public readonly double MagnitudeSquared()
    {
        return Dot(this, this);
    }

    public readonly double DistanceFrom(BulletVelocity other)
    {
        return (other - this).Magnitude();
    }

    public static double Dot(BulletVelocity vector1, BulletVelocity vector2) =>
        vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;

    
    
    public BulletVelocity Abs() => new(Math.Abs(X), Math.Abs(Y), Math.Abs(Z));

    public readonly override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }

    public static bool operator ==(BulletVelocity a, BulletVelocity b)
    {
        return Math.Abs(a.X - b.X) < 0.000001f && Math.Abs(a.Y - b.Y) < 0.000001f && Math.Abs(a.Z - b.Z) < 0.000001f;
    }

    public static bool operator !=(BulletVelocity a, BulletVelocity b) => !(a == b);

    public readonly override bool Equals(object obj) => obj is BulletVelocity other && this == other;
    public readonly override int GetHashCode() => HashCode.Combine(X, Y, Z);

    public double X = x;
    public double Y = y;
    public double Z = z;

    public static BulletVelocity Zero => new(0, 0, 0);

    public static BulletVelocity One => new(1, 1, 1);

    public readonly bool Equals(BulletVelocity other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
    }

    public readonly void Deconstruct(out double x, out double y, out double z)
    {
        x = X;
        y = Y;
        z = Z;
    }
}