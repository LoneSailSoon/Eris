using Eris.BeonSerializer.Streaming;
using Eris.Utilities.Data;
using Eris.YRSharp;

namespace Eris.Utilities.Ini.Parsers;

partial class Parsers
{
    public static bool Parse<T>(string? val, ref YRTypePointer<T> buffer) where T : struct, IYRType<T>
    {
        if (!string.IsNullOrWhiteSpace(val))
        {
            buffer = new YRTypePointer<T> { Id = val };
            return true;
        }

        return false;
    }
}



