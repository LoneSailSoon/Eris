using System.Diagnostics;

namespace Eris.YRSharp.Vector;

[DebuggerDisplay("XYZW={X}, {Y}, {Width}, {Height}")]
[StructLayout(LayoutKind.Sequential)]
public struct RectangleStruct(int x, int y, int w, int h)
    : IEquatable<RectangleStruct>
{
    public int X = x;
    public int Y = y;
    public int Width = w;
    public int Height = h;

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

    public static bool operator ==(RectangleStruct a, RectangleStruct b)
    {
        return a.X == b.X && a.Y == b.Y && a.Width == b.Width && a.Height == b.Height;
    }

    public static bool operator !=(RectangleStruct a, RectangleStruct b) => !(a == b);

    public override bool Equals(object obj) => obj is RectangleStruct other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y, Width, Height);

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

    public RectangleStruct(Point2D location, Point2D size) : this(location.X, location.Y, size.X, size.Y)
    {
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
        return new (X + value, Y + value, Width - 2 * value, Height - 2 * value);
    }

    public RectangleStruct AddLeft(int value)
    {
        return new (X - value, Y, Width + value, Height);
    }

    public RectangleStruct AddRight(int value)
    {
        return new (X, Y, Width + value, Height);
    }

    public RectangleStruct AddTop(int value)
    {
        return new (X, Y - value, Width, Height + value);
    }

    public RectangleStruct AddBottom(int value)
    {
        return new (X, Y, Width, Height + value);
    }

    public RectangleStruct AddWidth(int value)
    {
        return new (X - value / 2, Y, Width + value, Height);
    }

    public RectangleStruct AddHeight(int value)
    {
        return new (X, Y - value / 2, Width, Height + value);
    }

    public RectangleStruct Copy()
    {
        return new (X,Y,Width, Height);
    }

    public readonly RectangleStruct Sort()
    {
        var (x, w) = Width < 0 ? (X + Width, -Width) : (X, Width);
        var (y, h) = Height < 0 ? (Y + Height, -Height) : (Y, Height);

        return new(x, y, w, h);
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
    
    public RectangleStruct WithX(int x)
    {
        return new(x, Y, Width, Height);
    }
    
    public RectangleStruct WithY(int y)
    {
        return new(X, y, Width, Height);
    }
    
    public RectangleStruct WithWidth(int w)
    {
        return new(X, Y, w, Height);
    }
    
    public RectangleStruct WithHeight(int h)
    {
        return new(X, Y, Width, h);
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

    public void Deconstruct(out int x, out int y, out int w, out int h)
    {
        x = X;
        y = Y;
        w = Width;
        h = Height;
    }

    public void Deconstruct(out Point2D location, out Point2D size)
    {
        location.X = X;
        location.Y = Y;
        size.X = Width;
        size.Y = Height;
    }


    public static implicit operator RectangleStruct((int x, int y, int z, int w) value) =>
        new RectangleStruct(value.x, value.y, value.z, value.w);

    public static implicit operator (int x, int y, int z, int w)(RectangleStruct value) =>
        (value.X, value.Y, value.Width, value.Height);

    public static implicit operator RectangleStruct(((int x, int y)l, (int z, int w)s) value) =>
        new RectangleStruct(value.l.x, value.l.y, value.s.z, value.s.w);

    public static implicit operator RectangleStruct(((int x, int y)l, int z, int w) value) =>
        new RectangleStruct(value.l.x, value.l.y, value.z, value.w);
    
    public static implicit operator RectangleStruct((int x, int y, (int z, int w)s) value) =>
        new RectangleStruct(value.x, value.y, value.s.z, value.s.w);


    public bool Equals(RectangleStruct other)
    {
        return X == other.X && Y == other.Y && Width == other.Width && Height == other.Height;
    }
}