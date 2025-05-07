using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Eris.Utilities.Ini.Parsers;

public static partial class Parsers
{
    public static bool Parse(string? val, ref bool buffer)
    {
        if (val is not { Length: > 0 }) return false;
        
        switch (val[0])
        {
            case '1' or 'T' or 'Y' or 't' or 'y':
                buffer = true;
                return true;
            case '0' or 'F' or 'N' or 'f' or 'n':
                buffer = false;
                return true;
            default:
                return false;
        }
    }

    public static bool Parse(this ISection section, string key, ref bool buffer) =>
        section.GetValue(key) is { } value && Parse(value, ref buffer);

    public static bool Parse(string? val, ref byte buffer)
    {
        if (!byte.TryParse(val, out var parsed)) return false;

        buffer = parsed;
        return true;

    }

    public static bool Parse<T>(string? val, ref T buffer) where T : struct, INumber<T>
    {
        if (!T.TryParse(val, null, out var parsed)) return false;

        buffer = parsed;
        return true;

    }

    public static bool Parse<T>(this ISection section, string key, ref T buffer) where T : struct, INumber<T> =>
        section.GetValue(key) is { } value && Parse(value, ref buffer);

    public static bool Parse(string? val, [NotNullWhen(true)] ref string? buffer)
    {
        if(val is null )return false;
        buffer = val;
        return true;
    }

    public static bool Parse(this ISection section, string key, ref string? buffer) =>
        section.GetValue(key) is { } value && Parse(value, ref buffer);

}