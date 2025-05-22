using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Eris.YRSharp.Vector;

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

    public void Deconstruct(out int r, out int g, out int b)
    {
        r = R;
        g = G;
        b = B;
    }
}