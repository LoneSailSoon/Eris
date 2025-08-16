using System.Runtime.CompilerServices;

namespace Eris.YRSharp.Helpers;

[StructLayout(LayoutKind.Sequential)]
[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
public struct Bool(byte val) : IComparable, IConvertible, IComparable<Bool>, IEquatable<Bool>
{
    byte _Value = val;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Bool(bool val) : this(Convert.ToByte(val))
    {
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool ToBoolean() => Convert.ToBoolean(_Value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Bool(bool val) => new Bool(val);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Bool(byte val) => new Bool(val);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Bool(sbyte val) => (Bool)Convert.ToByte(val);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Bool(short val) => (Bool)Convert.ToByte(val);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Bool(ushort val) => (Bool)Convert.ToByte(val);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Bool(int val) => (Bool)Convert.ToByte(val);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Bool(uint val) => (Bool)Convert.ToByte(val);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Bool(long val) => (Bool)Convert.ToByte(val);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Bool(ulong val) => (Bool)Convert.ToByte(val);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator bool(Bool val) => val.ToBoolean();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator byte(Bool val) => Convert.ToByte(val._Value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator sbyte(Bool val) => Convert.ToSByte(val._Value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator short(Bool val) => Convert.ToInt16(val._Value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator ushort(Bool val) => Convert.ToUInt16(val._Value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator int(Bool val) => Convert.ToInt32(val._Value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator uint(Bool val) => Convert.ToUInt32(val._Value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator long(Bool val) => Convert.ToInt64(val._Value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator ulong(Bool val) => Convert.ToUInt64(val._Value);

    public static bool Parse(string value) => bool.Parse(value);
    public static bool TryParse(string value, out bool result) => bool.TryParse(value, out result);
    public int CompareTo(object obj) => ToBoolean().CompareTo(obj);
    public int CompareTo(Bool value) => ToBoolean().CompareTo(value);
    public override bool Equals(object obj) => ToBoolean().Equals(obj);
    public bool Equals(Bool obj) => ToBoolean().Equals(obj);
    public override int GetHashCode() => ToBoolean().GetHashCode();
    public TypeCode GetTypeCode() => ToBoolean().GetTypeCode();
    public override string ToString() => ToBoolean().ToString();
    public string ToString(IFormatProvider provider) => ToBoolean().ToString(provider);


    public bool ToBoolean(IFormatProvider provider)
    {
        return ((IConvertible)ToBoolean()).ToBoolean(provider);
    }

    public char ToChar(IFormatProvider provider)
    {
        return ((IConvertible)ToBoolean()).ToChar(provider);
    }

    public sbyte ToSByte(IFormatProvider provider)
    {
        return ((IConvertible)ToBoolean()).ToSByte(provider);
    }

    public byte ToByte(IFormatProvider provider)
    {
        return ((IConvertible)ToBoolean()).ToByte(provider);
    }

    public short ToInt16(IFormatProvider provider)
    {
        return ((IConvertible)ToBoolean()).ToInt16(provider);
    }

    public ushort ToUInt16(IFormatProvider provider)
    {
        return ((IConvertible)ToBoolean()).ToUInt16(provider);
    }

    public int ToInt32(IFormatProvider provider)
    {
        return ((IConvertible)ToBoolean()).ToInt32(provider);
    }

    public uint ToUInt32(IFormatProvider provider)
    {
        return ((IConvertible)ToBoolean()).ToUInt32(provider);
    }

    public long ToInt64(IFormatProvider provider)
    {
        return ((IConvertible)ToBoolean()).ToInt64(provider);
    }

    public ulong ToUInt64(IFormatProvider provider)
    {
        return ((IConvertible)ToBoolean()).ToUInt64(provider);
    }

    public float ToSingle(IFormatProvider provider)
    {
        return ((IConvertible)ToBoolean()).ToSingle(provider);
    }

    public double ToDouble(IFormatProvider provider)
    {
        return ((IConvertible)ToBoolean()).ToDouble(provider);
    }

    public decimal ToDecimal(IFormatProvider provider)
    {
        return ((IConvertible)ToBoolean()).ToDecimal(provider);
    }

    public DateTime ToDateTime(IFormatProvider provider)
    {
        return ((IConvertible)ToBoolean()).ToDateTime(provider);
    }

    public object ToType(Type conversionType, IFormatProvider provider)
    {
        return ((IConvertible)ToBoolean()).ToType(conversionType, provider);
    }

    public static bool operator ==(Bool left, Bool right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Bool left, Bool right)
    {
        return !(left == right);
    }
}
