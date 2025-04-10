using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
using PatcherYrSharp.Helpers;

namespace PatcherYrSharp.GeneralStructures;


    [DebuggerDisplay("RGB={R}, {G}, {B}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct ColorStruct(int r, int g, int b)
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
            return this.R == other.R && this.G == other.G && this.B == other.B;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
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
        public static implicit operator ColorStruct((int, int, int) value) => new ColorStruct((int)value.Item1, (int)value.Item2, (int)value.Item3);
        public static implicit operator ColorStruct((byte, byte, byte) value) => new ColorStruct(value.Item1, value.Item2, value.Item3);
    }

    [DebuggerDisplay("XYZ={X}, {Y}, {Z}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct CoordStruct(int x, int y, int z) : IVector<CoordStruct>
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
            return (ignoreZ ? (other - this) : (other - this).SetZ(0)).Magnitude();
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
        public CoordStruct SetX(int X)
        {
            this.X = X;
            return this;
        }
        public CoordStruct SetY(int Y)
        {
            this.Y = Y;
            return this;
        }
        public CoordStruct SetZ(int Z)
        {
            this.Z = Z;
            return this;
        }
        public CoordStruct OffsetX(int X)
        {
            this.X += X;
            return this;
        }
        public CoordStruct OffsetY(int Y)
        {
            this.Y += Y;
            return this;
        }
        public CoordStruct OffsetZ(int Z)
        {
            this.Z += Z;
            return this;
        }

        public static explicit operator double(CoordStruct value) => value.DistanceFrom(Zero);

        public static explicit operator Vector3(CoordStruct value) => new Vector3(value.X, value.Y, value.Z);

        public static implicit operator CoordStruct(Vector3 value) => new CoordStruct((int)value.X, (int)value.Y, (int)value.Z);
        public static implicit operator CoordStruct((int,int,int) value) => new CoordStruct((int)value.Item1, (int)value.Item2, (int)value.Item3);

        public static explicit operator BulletVelocity(CoordStruct value) => new BulletVelocity(value.X, value.Y, value.Z);

        public static implicit operator CoordStruct(BulletVelocity value) => new CoordStruct((int)value.X, (int)value.Y, (int)value.Z);

        public int X = x;
        public int Y = y;
        public int Z = z;

        public int F { get => X; set => X = value; }
        public int L { get => Y; set => Y = value; }
        public int H { get => Z; set => Z = value; }

        public CoordStruct XY0 => new(X, Y, 0);
        public CoordStruct OnlyZ => new(0, 0, Z);

        public static CoordStruct One => new(1, 1, 1);
    }

    [DebuggerDisplay("XYZ={X}, {Y}, {Z}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct BulletVelocity(double x, double y, double z) : IVector<BulletVelocity>
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
                 (double)(a.X * r),
                 (double)(a.Y * r),
                 (double)(a.Z * r));
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
            return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        }
        public static bool operator !=(BulletVelocity a, BulletVelocity b) => !(a == b);

        public override bool Equals(object obj) => obj is BulletVelocity other && this == other;
        public override int GetHashCode() => HashCode.Combine(X, Y, Z);

        public double X = x;
        public double Y = y;
        public double Z = z;

        public static BulletVelocity Zero => new(0, 0, 0);

        public static BulletVelocity One => new(1, 1, 1);
    }

    [DebuggerDisplay("XY={X}, {Y}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct CellStruct
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
    }

    //Random number range
    [StructLayout(LayoutKind.Sequential)]
    public struct RandomStruct
    {
        public int Min, Max;
    };


    [DebuggerDisplay("XYZ={X}, {Y}, {Z}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct SingleVector3D : IVector<SingleVector3D>
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
            return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        }
        public static bool operator !=(SingleVector3D a, SingleVector3D b) => !(a == b);

        public override bool Equals(object obj) => obj is SingleVector3D other && this == other;
        public override int GetHashCode() => base.GetHashCode();

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
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Quaternion_
    {
        public Quaternion_(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static implicit operator System.Numerics.Quaternion(Quaternion_ q) => new System.Numerics.Quaternion(q.X, q.Y, q.Z, q.W);
        public static implicit operator Quaternion_(System.Numerics.Quaternion q) => new Quaternion_(q.X, q.Y, q.Z, q.W);

        public float X;
        public float Y;
        public float Z;
        public float W;
    };

    [DebuggerDisplay("XY={X}, {Y}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct Point2D
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
        public override int GetHashCode() => base.GetHashCode();

        public int X;
        public int Y;

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public Point2D setX(int X)
        {
            this.X = X;
            return this;
        }

        public Point2D setY(int Y)
        {
            this.Y = Y;
            return this;
        }

        public Point2D OffsetX(int X)
        {
            this.X += X;
            return this;
        }

        public Point2D OffsetY(int Y)
        {
            this.Y += Y;
            return this;
        }


        public static implicit operator Point2D((int x, int y) value) => new Point2D(value.x, value.y);
        public static implicit operator (int x, int y)(Point2D value) => (value.X, value.Y);

    }

    [DebuggerDisplay("XYZW={X}, {Y}, {Width}, {Height}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct RectangleStruct
    {
        public RectangleStruct(int x, int y, int z, int w)
        {
            X = x;
            Y = y;
            Width = z;
            Height = w;
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
        public override int GetHashCode() => base.GetHashCode();

        public int X;
        public int Y;
        public int Width;
        public int Height;

        public bool InRect(Point2D locLocation)
        {
            return locLocation.X > this.X && locLocation.Y > this.Y && locLocation.X < (this.X + this.Width) && locLocation.Y < (this.Y + this.Height);
        }

        public bool InRectLenient(Point2D locLocation)
        {
            return locLocation.X >= this.X && locLocation.Y >= this.Y && locLocation.X <= (this.X + this.Width) && locLocation.Y <= (this.Y + this.Height);
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Width}, {Height})";
        }

        public Point2D TopLeft
        {
            get
            {
                return new Point2D(this.X, this.Y);
            }
            set
            {
                this.Width += this.X - value.X;
                this.X = value.X;
                this.Height += this.Y - value.Y;
                this.Y = value.Y;

            }
        }

        public Point2D BottomLeft
        {
            get
            {
                return new Point2D(this.X, this.Y + this.Height);
            }
            set
            {
                this.Width += this.X - value.X;
                this.X = value.X;

                this.Height = value.Y - this.Y;
            }
        }

        public Point2D TopRight
        {
            get
            {
                return new Point2D(this.X + this.Width, this.Y);
            }
            set
            {
                this.Width = value.X - this.X;
                this.Height += this.Y - value.Y;
                this.Y = value.Y;
            }
        }

        public Point2D BottomRight
        {
            get
            {
                return new Point2D(this.X + this.Width, this.Y + this.Height);
            }
            set
            {
                this.Width = value.X - this.X;
                this.Height = value.Y - this.Y;
            }
        }

        public RectangleStruct(Point2D location, Point2D size)
        {
            this.X = location.X;
            this.Y = location.Y;
            this.Width = size.X;
            this.Height = size.Y;
        }

        public Point2D Location
        {
            get
            {
                return new Point2D(this.X, this.Y);
            }
            set
            {
                this.X = value.X;
                this.Y = value.Y;
            }
        }

        public Point2D Size
        {
            get
            {
                return new Point2D(this.Width, this.Height);
            }
            set
            {
                this.Width = value.X;
                this.Height = value.Y;
            }
        }

        public Point2D Center
        {
            get
            {
                return new Point2D(this.X + this.Width / 2, this.Y + this.Height / 2);
            }
            set
            {
                this.X = value.X + this.Width / 2;
                this.Y = value.Y + this.Height / 2;
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


        public static implicit operator RectangleStruct((int x, int y, int z, int w) value) => new RectangleStruct(value.x, value.y, value.z, value.w);
        public static implicit operator (int x, int y, int z, int w)(RectangleStruct value) => (value.X, value.Y, value.Width, value.Height);

        public static implicit operator RectangleStruct(((int x, int y)l, (int z, int w)s) value) => new RectangleStruct(value.l.x, value.l.y, value.s.z, value.s.w);

    }



    [DebuggerDisplay("LTRB={Left}, {Top}, {Right}, {Bottom}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct LTRBStruct
    {
        public LTRBStruct(int x, int y, int z, int w)
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

        public override int GetHashCode() => base.GetHashCode();

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
        public ColorStruct this[int index] { get => Entries[index]; set => Entries[index] = value; }
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
    }