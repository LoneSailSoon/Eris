using System.Runtime.InteropServices;

namespace Eris.Utilities.Ini.Parsers;

partial class Parsers
{
    public static bool ParseMatch(string? val, ref IntegerMatch buffer)
    {
        if (val is not { Length: > 0 }) return false;
        switch (val)
        {
            case [var first, '=', .. var num]:
            {
                var type = first switch
                {
                    '=' => MatchType.Equal,
                    '!' => MatchType.NotEqual,
                    '>' => MatchType.GreaterThanOrEqual,
                    '<' => MatchType.LessThanOrEqual,
                    _ => MatchType.None,
                };

                if (type == MatchType.None || !int.TryParse(num, out var value)) return false;
                buffer = new(value, type);
                return true;
            }
            case [var first, .. var num]:
            {
                var type = first switch
                {
                    '>' => MatchType.GreaterThan,
                    '<' => MatchType.LessThan,
                    _ => MatchType.None
                };

                if (type == MatchType.None || !int.TryParse(num, out var value)) return false;
                buffer = new(value, type);
                return true;
            }
            default:
                return false;
        }
    }
}

public enum MatchType
{
    None,
    Equal,
    NotEqual,
    GreaterThan,
    GreaterThanOrEqual,
    LessThan,
    LessThanOrEqual
}

[StructLayout(LayoutKind.Sequential)]
public struct IntegerMatch(int value, MatchType type) : IEquatable<IntegerMatch>
{
    public MatchType Type = type;
    public int Value = value;

    public override string ToString()
    {
        return $"{Type switch {
            MatchType.None => "???",
            MatchType.Equal => "==",
            MatchType.NotEqual => "!=",
            MatchType.GreaterThan => ">",
            MatchType.GreaterThanOrEqual => ">=",
            MatchType.LessThan => "<",
            MatchType.LessThanOrEqual => "<=",
            _ => "???" }} {Value}";
    }

    public bool Match(int value) => Type switch
    {
        MatchType.Equal => Value == value,
        MatchType.NotEqual => Value != value,
        MatchType.GreaterThan => value > Value,
        MatchType.GreaterThanOrEqual => value >= Value,
        MatchType.LessThan => value < Value,
        MatchType.LessThanOrEqual => value <= Value,
        _ => false
    };


    public bool Equals(IntegerMatch other)
    {
        return Type == other.Type && Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        return obj is IntegerMatch other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine((int)Type, Value);
    }

    public static bool operator ==(IntegerMatch left, IntegerMatch right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(IntegerMatch left, IntegerMatch right)
    {
        return !left.Equals(right);
    }
}