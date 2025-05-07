using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
using PatcherYrSharp.Helpers;

namespace PatcherYrSharp.GeneralStructures;

[DebuggerDisplay("RGB={R}, {G}, {B}")]
[StructLayout(LayoutKind.Sequential)]
public struct ColorStruct(int r, int g, int b) : IEquatable<ColorStruct>
{
    public byte R = (byte)r;
    public byte G = (byte)g;
    public byte B = (byte)b;

    public static bool operator ==(ColorStruct a, ColorStruct b)
    {
        return Equals(a, b);
    }

    public static bool operator !=(ColorStruct a, ColorStruct b) => !(a == b);

    public bool Equals(ColorStruct other)
    {
        return R == other.R && G == other.G && B == other.B;
    }

    public override bool Equals(object obj)
    {
        if (obj?.GetType() != GetType()) return false;
        return Equals((ColorStruct)obj);
    }

    public static ColorStruct operator *(ColorStruct a, double r)
    {
        return new ColorStruct(
            (int)(a.R * r),
            (int)(a.G * r),
            (int)(a.B * r));
    }

    public static ColorStruct operator +(ColorStruct a, ColorStruct b)
    {
        return new ColorStruct(
            a.R + b.R,
            a.G + b.G,
            a.B + b.B
        );
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(R, G, B);
    }

    public override string ToString()
    {
        return $"({R}, {G}, {B})";
    }

    public static implicit operator ColorStruct((int, int, int) value) =>
        new ColorStruct(value.Item1, value.Item2, value.Item3);

    public static implicit operator ColorStruct((byte, byte, byte) value) =>
        new ColorStruct(value.Item1, value.Item2, value.Item3);
}

[DebuggerDisplay("XYZ={X}, {Y}, {Z}")]
[StructLayout(LayoutKind.Sequential)]
public struct CoordStruct(int x, int y, int z) : IVector<CoordStruct>, IEquatable<CoordStruct>
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

    public static explicit operator Vector3(CoordStruct value) => new Vector3(value.X, value.Y, value.Z);

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
    public CoordStruct OnlyZ => new(0, 0, Z);

    public static CoordStruct One => new(1, 1, 1);

    public bool Equals(CoordStruct other)
    {
        return X == other.X && Y == other.Y && Z == other.Z;
    }
}

[DebuggerDisplay("XYZ={X}, {Y}, {Z}")]
[StructLayout(LayoutKind.Sequential)]
public struct BulletVelocity(double x, double y, double z) : IVector<BulletVelocity>, IEquatable<BulletVelocity>
{
    public static BulletVelocity operator -(BulletVelocity a)
    {
        return new BulletVelocity(-a.X, -a.Y, -a.Z);
    }

    public static BulletVelocity operator +(BulletVelocity a, BulletVelocity b)
    {
        return new BulletVelocity(
            a.X + b.X,
            a.Y + b.Y,
            a.Z + b.Z);
    }

    public static BulletVelocity operator -(BulletVelocity a, BulletVelocity b)
    {
        return new BulletVelocity(
            a.X - b.X,
            a.Y - b.Y,
            a.Z - b.Z);
    }

    public static BulletVelocity operator *(BulletVelocity a, double r)
    {
        return new BulletVelocity(
            a.X * r,
            a.Y * r,
            a.Z * r);
    }

    public static double operator *(BulletVelocity a, BulletVelocity b)
    {
        return a.X * b.X
               + a.Y * b.Y
               + a.Z * b.Z;
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

    public double DistanceFrom(BulletVelocity other)
    {
        return (other - this).Magnitude();
    }

    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }

    public static bool operator ==(BulletVelocity a, BulletVelocity b)
    {
        return Math.Abs(a.X - b.X) < 0.000001f && Math.Abs(a.Y - b.Y) < 0.000001f && Math.Abs(a.Z - b.Z) < 0.000001f;
    }

    public static bool operator !=(BulletVelocity a, BulletVelocity b) => !(a == b);

    public override bool Equals(object obj) => obj is BulletVelocity other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y, Z);

    public double X = x;
    public double Y = y;
    public double Z = z;

    public static BulletVelocity Zero => new(0, 0, 0);

    public static BulletVelocity One => new(1, 1, 1);

    public bool Equals(BulletVelocity other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
    }
}

[DebuggerDisplay("XY={X}, {Y}")]
[StructLayout(LayoutKind.Sequential)]
public struct CellStruct : IEquatable<CellStruct>
{
    public CellStruct(int x, int y)
    {
        X = (short)x;
        Y = (short)y;
    }

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
    public double Magnitude()
    {
        return Math.Sqrt(MagnitudeSquared());
    }

    //magnitude squared
    public double MagnitudeSquared()
    {
        return this * this;
    }

    public double DistanceFrom(CellStruct other)
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

    public short X;
    public short Y;

    public override string ToString()
    {
        return $"({X}, {Y})";
    }

    public bool Equals(CellStruct other)
    {
        return X == other.X && Y == other.Y;
    }
}

//Random number range
[StructLayout(LayoutKind.Sequential)]
public struct RandomStruct
{
    public int Min, Max;
};

[DebuggerDisplay("XYZ={X}, {Y}, {Z}")]
[StructLayout(LayoutKind.Sequential)]
public struct SingleVector3D : IVector<SingleVector3D>, IEquatable<SingleVector3D>
{
    public SingleVector3D(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public SingleVector3D(double x, double y, double z)
    {
        X = (float)x;
        Y = (float)y;
        Z = (float)z;
    }

    public static SingleVector3D operator -(SingleVector3D a)
    {
        return new SingleVector3D(-a.X, -a.Y, -a.Z);
    }

    public static SingleVector3D operator +(SingleVector3D a, SingleVector3D b)
    {
        return new SingleVector3D(
            a.X + b.X,
            a.Y + b.Y,
            a.Z + b.Z);
    }

    public static SingleVector3D operator -(SingleVector3D a, SingleVector3D b)
    {
        return new SingleVector3D(
            a.X - b.X,
            a.Y - b.Y,
            a.Z - b.Z);
    }

    public static SingleVector3D operator *(SingleVector3D a, double r)
    {
        return new SingleVector3D(
            (float)(a.X * r),
            (float)(a.Y * r),
            (float)(a.Z * r));
    }

    public static double operator *(SingleVector3D a, SingleVector3D b)
    {
        return a.X * b.X
               + a.Y * b.Y
               + a.Z * b.Z;
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

    public double DistanceFrom(SingleVector3D other)
    {
        return (other - this).Magnitude();
    }

    public static bool operator ==(SingleVector3D a, SingleVector3D b)
    {
        return Math.Abs(a.X - b.X) < 0.000001f && Math.Abs(a.Y - b.Y) < 0.000001f && Math.Abs(a.Z - b.Z) < 0.000001f;
    }

    public static bool operator !=(SingleVector3D a, SingleVector3D b) => !(a == b);

    public override bool Equals(object obj) => obj is SingleVector3D other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y, Z);

    public float X;
    public float Y;
    public float Z;

    public static SingleVector3D Zero => new(0, 0, 0);

    public static SingleVector3D One => new(1, 1, 1);

    public static implicit operator SingleVector3D(Vector3 value) => new SingleVector3D(value.X, value.Y, value.Z);

    public static implicit operator Vector3(SingleVector3D value) => new Vector3(value.X, value.Y, value.Z);

    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }

    public bool Equals(SingleVector3D other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct Quaternion
{
    public Quaternion(float x, float y, float z, float w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public static implicit operator System.Numerics.Quaternion(Quaternion q) =>
        new System.Numerics.Quaternion(q.X, q.Y, q.Z, q.W);

    public static implicit operator Quaternion(System.Numerics.Quaternion q) => new Quaternion(q.X, q.Y, q.Z, q.W);

    public float X;
    public float Y;
    public float Z;
    public float W;
};

[DebuggerDisplay("XY={X}, {Y}")]
[StructLayout(LayoutKind.Sequential)]
public struct Point2D : IEquatable<Point2D>
{
    public Point2D(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static Point2D operator -(Point2D a)
    {
        return new Point2D(-a.X, -a.Y);
    }

    public static Point2D operator +(Point2D a, Point2D b)
    {
        return new Point2D(
            a.X + b.X,
            a.Y + b.Y);
    }

    public static Point2D operator -(Point2D a, Point2D b)
    {
        return new Point2D(
            a.X - b.X,
            a.Y - b.Y);
    }

    public static Point2D operator *(Point2D a, double r)
    {
        return new Point2D(
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

    public static bool operator ==(Point2D a, Point2D b)
    {
        return a.X == b.X && a.Y == b.Y;
    }

    public static bool operator !=(Point2D a, Point2D b) => !(a == b);

    public override bool Equals(object obj) => obj is Point2D other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y);

    public int X;
    public int Y;

    public override string ToString()
    {
        return $"({X}, {Y})";
    }

    public Point2D SetX(int x)
    {
        this.X = x;
        return this;
    }

    public Point2D SetY(int y)
    {
        this.Y = y;
        return this;
    }

    public Point2D OffsetX(int x)
    {
        this.X += x;
        return this;
    }

    public Point2D OffsetY(int y)
    {
        this.Y += y;
        return this;
    }


    public static implicit operator Point2D((int x, int y) value) => new Point2D(value.x, value.y);
    public static implicit operator (int x, int y)(Point2D value) => (value.X, value.Y);

    public bool Equals(Point2D other)
    {
        return X == other.X && Y == other.Y;
    }
}

[DebuggerDisplay("XYZW={X}, {Y}, {Width}, {Height}")]
[StructLayout(LayoutKind.Sequential)]
public struct RectangleStruct : IEquatable<RectangleStruct>
{
    public RectangleStruct(int x, int y, int w, int h)
    {
        X = x;
        Y = y;
        Width = w;
        Height = h;
    }

    public static RectangleStruct operator -(RectangleStruct a)
    {
        return new RectangleStruct(-a.X, -a.Y, -a.Width, -a.Height);
    }

    public static RectangleStruct operator +(RectangleStruct a, RectangleStruct b)
    {
        return new RectangleStruct(
            a.X + b.X,
            a.Y + b.Y,
            a.Width + b.Width,
            a.Height + b.Height);
    }

    public static RectangleStruct operator -(RectangleStruct a, RectangleStruct b)
    {
        return new RectangleStruct(
            a.X - b.X,
            a.Y - b.Y,
            a.Width - b.Width,
            a.Height - b.Height);
    }

    public static RectangleStruct operator *(RectangleStruct a, double r)
    {
        return new RectangleStruct(
            (int)(a.X * r),
            (int)(a.Y * r),
            (int)(a.Width * r),
            (int)(a.Height * r));
    }

    public static RectangleStruct operator /(RectangleStruct a, double r)
    {
        return new RectangleStruct(
            (int)(a.X / r),
            (int)(a.Y / r),
            (int)(a.Width / r),
            (int)(a.Height / r));
    }

    public static double operator *(RectangleStruct a, RectangleStruct b)
    {
        return a.X * b.X
               + a.Y * b.Y
               + a.Width * b.Width
               + a.Height * b.Height;
    }

    public static bool operator ==(RectangleStruct a, RectangleStruct b)
    {
        return a.X == b.X && a.Y == b.Y && a.Width == b.Width && a.Height == b.Height;
    }

    public static bool operator !=(RectangleStruct a, RectangleStruct b) => !(a == b);

    public override bool Equals(object obj) => obj is RectangleStruct other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y, Width, Height);

    public int X;
    public int Y;
    public int Width;
    public int Height;

    public bool InRect(Point2D locLocation)
    {
        return locLocation.X > X && locLocation.Y > Y && locLocation.X < X + Width &&
               locLocation.Y < Y + Height;
    }

    public bool InRectLenient(Point2D locLocation)
    {
        return locLocation.X >= X && locLocation.Y >= Y && locLocation.X <= X + Width &&
               locLocation.Y <= Y + Height;
    }

    public override string ToString()
    {
        return $"({X}, {Y}, {Width}, {Height})";
    }

    public Point2D TopLeft
    {
        get => new(X, Y);
        set
        {
            Width += X - value.X;
            X = value.X;
            Height += Y - value.Y;
            Y = value.Y;
        }
    }

    public Point2D BottomLeft
    {
        get => new(X, Y + Height);
        set
        {
            Width += X - value.X;
            X = value.X;

            Height = value.Y - Y;
        }
    }

    public Point2D TopRight
    {
        get => new(X + Width, Y);
        set
        {
            Width = value.X - X;
            Height += Y - value.Y;
            Y = value.Y;
        }
    }

    public Point2D BottomRight
    {
        get => new(X + Width, Y + Height);
        set
        {
            Width = value.X - X;
            Height = value.Y - Y;
        }
    }

    public RectangleStruct(Point2D location, Point2D size)
    {
        X = location.X;
        Y = location.Y;
        Width = size.X;
        Height = size.Y;
    }

    public Point2D Location
    {
        get => new(X, Y);
        set
        {
            X = value.X;
            Y = value.Y;
        }
    }

    public Point2D Size
    {
        get => new(Width, Height);
        set
        {
            Width = value.X;
            Height = value.Y;
        }
    }

    public Point2D Center
    {
        get => new(X + Width / 2, Y + Height / 2);
        set
        {
            X = value.X + Width / 2;
            Y = value.Y + Height / 2;
        }
    }

    public RectangleStruct Inserted(int value)
    {
        return new RectangleStruct(X + value, Y + value, Width - 2 * value, Height - 2 * value);
    }

    public RectangleStruct AddLeft(int value)
    {
        return new RectangleStruct(X - value, Y, Width + value, Height);
    }

    public RectangleStruct AddRight(int value)
    {
        return new RectangleStruct(X, Y, Width + value, Height);
    }

    public RectangleStruct AddTop(int value)
    {
        return new RectangleStruct(X, Y - value, Width, Height + value);
    }

    public RectangleStruct AddBottom(int value)
    {
        return new RectangleStruct(X, Y, Width, Height + value);
    }

    public RectangleStruct AddWidth(int value)
    {
        return new RectangleStruct(X - value / 2, Y, Width + value, Height);
    }

    public RectangleStruct AddHeight(int value)
    {
        return new RectangleStruct(X, Y - value / 2, Width, Height + value);
    }

    public RectangleStruct Copy()
    {
        return new RectangleStruct(Location, Size);
    }

    public readonly RectangleStruct Sort()
    {
        (int x, int w) = Width < 0 ? (X + Width, -Width) : (X, Width);
        (int y, int h) = Height < 0 ? (Y + Height, -Height) : (Y, Height);

        return (x, y, w, h);
    }

    public Point2D LeftPoint
    {
        get => new Point2D(X, Y + Height / 2);
        set
        {
            Width = Width + X - value.X;
            X = value.X;
            Y = value.Y - Height / 2;
        }
    }

    public Point2D TopPoint
    {
        get => new Point2D(X + Width / 2, Y);
        set
        {
            Height = Height + Y - value.Y;
            Y = value.Y;
            X = value.X - Width / 2;
        }
    }

    public Point2D RightPoint
    {
        get => new Point2D(X + Width, Y + Height / 2);
        set
        {
            Width = value.X - X;
            Y = value.Y - Height / 2;
        }
    }

    public Point2D BottomPoint
    {
        get => new Point2D(X + Width / 2, Y + Height);
        set
        {
            Height = value.Y - Y;
            X = value.X - Width / 2;
        }
    }

    public static RectangleStruct FromTopLeft(Point2D location, Point2D size)
    {
        return new RectangleStruct(location, size);
    }

    public static RectangleStruct FromTopRight(Point2D location, Point2D size)
    {
        return new RectangleStruct(location.X - size.X, location.Y, size.X, size.Y);
    }

    public static RectangleStruct FromBottomLeft(Point2D location, Point2D size)
    {
        return new RectangleStruct(location.X, location.Y - size.Y, size.X, size.Y);
    }

    public static RectangleStruct FromBottomRight(Point2D location, Point2D size)
    {
        return new RectangleStruct(location.X - size.X, location.Y - size.Y, size.X, size.Y);
    }

    public static RectangleStruct FromTop(Point2D location, Point2D size)
    {
        return new RectangleStruct(location.X - size.X / 2, location.Y, size.X, size.Y);
    }

    public static RectangleStruct FromBottom(Point2D location, Point2D size)
    {
        return new RectangleStruct(location.X - size.X / 2, location.Y - size.Y, size.X, size.Y);
    }

    public static RectangleStruct FromLeft(Point2D location, Point2D size)
    {
        return new RectangleStruct(location.X, location.Y - size.Y / 2, size.X, size.Y);
    }

    public static RectangleStruct FromRight(Point2D location, Point2D size)
    {
        return new RectangleStruct(location.X - size.X, location.Y - size.Y / 2, size.X, size.Y);
    }


    public static implicit operator RectangleStruct((int x, int y, int z, int w) value) =>
        new RectangleStruct(value.x, value.y, value.z, value.w);

    public static implicit operator (int x, int y, int z, int w)(RectangleStruct value) =>
        (value.X, value.Y, value.Width, value.Height);

    public static implicit operator RectangleStruct(((int x, int y)l, (int z, int w)s) value) =>
        new RectangleStruct(value.l.x, value.l.y, value.s.z, value.s.w);

    public bool Equals(RectangleStruct other)
    {
        return X == other.X && Y == other.Y && Width == other.Width && Height == other.Height;
    }
}

[DebuggerDisplay("LTRB={Left}, {Top}, {Right}, {Bottom}")]
[StructLayout(LayoutKind.Sequential)]
public struct LtrbStruct
{
    public LtrbStruct(int x, int y, int z, int w)
    {
        Left = x;
        Top = y;
        Right = z;
        Bottom = w;
    }

    public override string ToString()
    {
        return $"({Left}, {Top}, {Right},{Bottom})";
    }

    public override int GetHashCode() => HashCode.Combine(Left, Top, Right, Bottom);

    public int Left;
    public int Top;
    public int Right;
    public int Bottom;
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

[StructLayout(LayoutKind.Sequential)]
public struct Matrix3D
{
    public float _00;
    public float _01;
    public float _02;
    public float _03;
    public float _10;
    public float _11;
    public float _12;
    public float _13;
    public float _20;
    public float _21;
    public float _22;
    public float _23;


    public unsafe void MakeIdentity()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, void>)0x5AE860;
        func(this.GetThisPointer());
    }

    public unsafe void Translate(float x, float y, float z)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, float, float, void>)0x5AE890;
        func(this.GetThisPointer(), x, y, z);
    }

    public unsafe void Translate(SingleVector3D vector3D)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x5AE8F0;
        func(this.GetThisPointer(), vector3D.GetThisPointer());
    }

    public unsafe void TranslateX(float x)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, void>)0x5AE980;
        func(this.GetThisPointer(), x);
    }

    public unsafe void TranslateY(float y)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, void>)0x5AE9B0;
        func(this.GetThisPointer(), y);
    }

    public unsafe void TranslateZ(float z)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, void>)0x5AE9E0;
        func(this.GetThisPointer(), z);
    }

    public unsafe void Scale(float factor)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, void>)0x5AEA10;
        func(this.GetThisPointer(), factor);
    }

    public unsafe void Scale(float x, float y, float z)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, float, float, void>)0x5AEA70;
        func(this.GetThisPointer(), z, y, z);
    }

    public unsafe void ScaleX(float x)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, void>)0x5AEAD0;
        func(this.GetThisPointer(), x);
    }

    public unsafe void ScaleY(float y)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, void>)0x5AEAF0;
        func(this.GetThisPointer(), y);
    }

    public unsafe void ScaleZ(float z)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, void>)0x5AEB20;
        func(this.GetThisPointer(), z);
    }

    public unsafe void ShearYz(float y, float z)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, float, void>)0x5AEB50;
        func(this.GetThisPointer(), y, z);
    }

    public unsafe void ShearXy(float x, float y)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, float, void>)0x5AEBA0;
        func(this.GetThisPointer(), x, y);
    }

    public unsafe void ShearXz(float x, float z)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, float, void>)0x5AEBF0;
        func(this.GetThisPointer(), x, z);
    }

    public unsafe void PreRotateX(float theta)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, void>)0x5AEC40;
        func(this.GetThisPointer(), theta);
    }

    public unsafe void PreRotateY(float theta)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, void>)0x5AED50;
        func(this.GetThisPointer(), theta);
    }

    public unsafe void PreRotateZ(float theta)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, void>)0x5AEE50;
        func(this.GetThisPointer(), theta);
    }

    public unsafe void RotateX(float theta)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, void>)0x5AEF60;
        func(this.GetThisPointer(), theta);
    }

    public unsafe void RotateX(float sin, float cos)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, float, void>)0x5AF000;
        func(this.GetThisPointer(), sin, cos);
    }

    public unsafe void RotateY(float theta)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, void>)0x5AF080;
        func(this.GetThisPointer(), theta);
    }

    public unsafe void RotateY(float sin, float cos)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, float, void>)0x5AF120;
        func(this.GetThisPointer(), sin, cos);
    }

    public unsafe void RotateZ(float theta)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, void>)0x5AF1A0;
        func(this.GetThisPointer(), theta);
    }

    public unsafe void RotateZ(float sin, float cos)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float, float, void>)0x5AF240;
        func(this.GetThisPointer(), sin, cos);
    }

    public unsafe float GetXVal()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float>)0x5AF2C0;
        return func(this.GetThisPointer());
    }

    public unsafe float GetYVal()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float>)0x5AF310;
        return func(this.GetThisPointer());
    }

    public unsafe float GetZVal()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float>)0x5AF360;
        return func(this.GetThisPointer());
    }

    public unsafe float GetXRotation()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float>)0x5AF3B0;
        return func(this.GetThisPointer());
    }

    public unsafe float GetYRotation()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float>)0x5AF410;
        return func(this.GetThisPointer());
    }

    public unsafe float GetZRotation()
    {
        var func = (delegate* unmanaged[Thiscall]<nint, float>)0x5AF470;
        return func(this.GetThisPointer());
    }

    public unsafe Pointer<SingleVector3D> RotateVector(Pointer<SingleVector3D> ret, Pointer<SingleVector3D> rotate)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint>)0x5AF4D0;
        return func(this.GetThisPointer(), ret, rotate);
    }

    public unsafe SingleVector3D RotateVector(ref SingleVector3D rotate)
    {
        SingleVector3D buffer = default;
        RotateVector(Pointer<SingleVector3D>.AsPointer(ref buffer), Pointer<SingleVector3D>.AsPointer(ref rotate));
        return buffer;
    }

    public unsafe void LookAt1(SingleVector3D p, SingleVector3D t, float roll)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, float, void>)0x5AF550;
        func(this.GetThisPointer(), p.GetThisPointer(), t.GetThisPointer(), roll);
    }

    public unsafe void LookAt2(SingleVector3D p, SingleVector3D t, float roll)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, float, void>)0x5AF710;
        func(this.GetThisPointer(), p.GetThisPointer(), t.GetThisPointer(), roll);
    }
}