using System.Runtime.InteropServices;

namespace Eris.Misc.String.Utf8;

[StructLayout(LayoutKind.Sequential)]
public readonly record struct Utf8String
{
    public readonly int Length;
    public readonly int ByteLength;
    private readonly byte[] _data;

    private Utf8String(byte[] data, int length)
    {
        Length = length;
        ByteLength = data.Length - 1;
        _data = data;
    }

    public static readonly Utf8String Empty = new([0], 0);

    public bool Equals(Utf8String? value)
    {
        return value is not null &&
               (ReferenceEquals(_data, value.Value._data) ||
                _data.AsSpan().SequenceEqual(value.Value._data.AsSpan()));
    }

    public int CompareTo(Utf8String? value)
    {
        if (value is null) return 1;
        return Utf8StringComparer.Default.Utf8CompareTo(_data, value.Value._data);
    }

    public override string ToString()
    {
        return new(Utf8StringConvert.Utf8ToUtf16(_data.AsSpan(0, ByteLength)));
    }

    public override int GetHashCode()
    {
        return Utf8StringComparer.Default.Utf8GetHashCode(_data.AsSpan(0, ByteLength));
    }

    public bool IsNull => _data is null;
    public bool IsNotNull => _data is not null;

    public ReadOnlySpan<byte> AsSpan() => _data.AsSpan(0, ByteLength);

    public static bool operator ==(Utf8String? left, Utf8String? right) =>
        left is null ? right is null : right is not null && left.Value.Equals(right);

    public static bool operator !=(Utf8String? left, Utf8String? right) => !(left == right);

    public static bool operator ==(Utf8String? left, string? right) =>
        left is null
            ? right is null
            : right is not null && Utf8StringComparer.Default.HybridEquals(left.Value.AsSpan(), right);

    public static bool operator !=(Utf8String? left, string right) => !(left == right);

    public static bool operator ==(string? right, Utf8String? left) =>
        left is null
            ? right is null
            : right is not null && Utf8StringComparer.Default.HybridEquals(left.Value.AsSpan(), right);

    public static bool operator !=(string right, Utf8String? left) => !(left == right);

    public static implicit operator ReadOnlySpan<byte>(Utf8String value) => value.AsSpan();

    public Utf8String(ReadOnlySpan<byte> data) : this(data.ToArray(), Utf8StringConvert.Utf8ToUtf16Length(data, out _))
    {
    }

    public Utf8String(ReadOnlySpan<char> data) : this(Utf8StringConvert.Utf16ToUtf8(data), data.Length)
    {
    }
}