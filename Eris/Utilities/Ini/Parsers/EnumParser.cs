using Eris.Utilities.Helpers;

namespace Eris.Utilities.Ini.Parsers;

partial class Parsers
{
    public static bool Parse<T>(string? val, IReadOnlyDictionary<string, ulong> parser, ref T buffer)
        where T : struct, Enum
    {
        if (string.IsNullOrWhiteSpace(val)) return false;

        if (parser.TryGetValue(val, out var value))
            buffer = EnumHelper.FromUint64<T>(value);
        return false;
    }

    public static bool ParseFlags<T>(string? val, IReadOnlyDictionary<string, ulong> parser, ref T buffer)
        where T : struct, Enum
    {
        if (string.IsNullOrWhiteSpace(val) || val.Split(',', StringSplitOptions.RemoveEmptyEntries) is not
                { Length: > 0 } ids) return false;

        ulong temp = 0;

        foreach (var id in ids)
        {
            if (parser.TryGetValue(id, out var value))
                temp |= value;
        }

        buffer = EnumHelper.FromUint64<T>(temp);
        return false;
    }

}