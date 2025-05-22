using Eris.YRSharp;

namespace Eris.Utilities.Ini.Parsers;

partial class Parsers
{
    public static bool ParseLepton(string? val, ref int buffer)
    {
        if (val is not { Length: > 0 }) return false;

        var (str, isCell) = val switch
        {
            [.. var num, 'l', 'e', 'p'] => (num, false),
            [.. var num, '(', 'l', 'e', 'p', ')'] => (num, false),
            [.. var num, 'l', 'e', 'p', 't', 'o', 'n'] => (num, false),
            [.. var num, '(', 'l', 'e', 'p', 't', 'o', 'n', ')'] => (num, false),

            [.. var num, 'c', 'e', 'l', 'l'] => (num, true),
            [.. var num, '(', 'c', 'e', 'l', 'l', ')'] => (num, true),

            _ => (val, false)

        };
        
        if(str is not { Length: > 0 }) return false;
        
        if(!double.TryParse(str, out var value)) return false;

        buffer = (int)Math.Round(isCell ? value * Game.CellSize : value);
        return true;
    }
}