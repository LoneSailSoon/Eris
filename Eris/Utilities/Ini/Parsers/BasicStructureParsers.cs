using PatcherYrSharp.GeneralStructures;

namespace Eris.Utilities.Ini.Parsers;

partial class Parsers
{
    public static bool Parse(string? val, ref CoordStruct buffer)
    {
        if (string.IsNullOrWhiteSpace(val)) return false;
        var tmp = val.Split(',', 3);
        if (tmp.Length == 3 && int.TryParse(tmp[0], out var x) && int.TryParse(tmp[1], out var y) &&
            int.TryParse(tmp[2], out var z))
        {
            (buffer.X, buffer.Y, buffer.Z) = (x, y, z);
            return true;
        }

        return false;
    }

    public static bool Parse(string? val, ref ColorStruct buffer)
    {
        if (string.IsNullOrWhiteSpace(val)) return false;
        var tmp = val.Split(',', 3);
        if (tmp.Length == 3 && byte.TryParse(tmp[0], out var r) && byte.TryParse(tmp[1], out var g) &&
            byte.TryParse(tmp[2], out var b))
        {
            (buffer.R, buffer.G, buffer.B) = (r, g, b);
            return true;
        }

        return false;
    }

    public static bool Parse(string? val, ref CellStruct buffer)
    {
        if (string.IsNullOrWhiteSpace(val)) return false;
        var tmp = val.Split(',', 2);
        if (tmp.Length == 2 && short.TryParse(tmp[0], out var x) && short.TryParse(tmp[1], out var y))
        {
            (buffer.X, buffer.Y) = (x, y);
            return true;
        }

        return false;
    }

    public static bool Parse(string? val, ref RectangleStruct buffer)
    {
        if (string.IsNullOrWhiteSpace(val)) return false;
        var tmp = val.Split(',', 4);
        if (tmp.Length == 4 && int.TryParse(tmp[0], out var x) && int.TryParse(tmp[1], out var y) &&
            int.TryParse(tmp[2], out var w) && int.TryParse(tmp[3], out var h))
        {
            (buffer.X, buffer.Y, buffer.Width, buffer.Height) = (x, y, w, h);
            return true;
        }

        return false;
    }

}