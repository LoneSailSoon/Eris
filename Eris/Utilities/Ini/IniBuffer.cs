using Eris.YRSharp;
using Eris.YRSharp.Helpers;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace Eris.Utilities.Ini;

public class IniBuffer
{
    public static readonly IniBuffer Default = new();

    private readonly byte[] _readBuffer = new byte[2048];

    public Encoding Encoding = Encoding.UTF8;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private string GetString(int length = -1)
    {
        var str = length < 0 ? Encoding.GetString(_readBuffer) : Encoding.GetString(_readBuffer, 0, length);

        if (length < 0)
            str = str[..str.IndexOf('\0')];

        str = str.Replace(" ", "");
        return str;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int ReadBuffer(Pointer<CCIniClass> pIni, nint section, nint key)
    {
        return pIni.Ref.ReadString(section, key, 0, _readBuffer, _readBuffer.Length);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool ReadString(Pointer<CCIniClass> pIni, nint section, nint key, [NotNullWhen(true)] out string? buffer)
    {
        if (section is not 0 && ReadBuffer(pIni, section, key) is var count and > 0)
        {
            buffer = GetString(count);

            return true;
        }

        buffer = null;
        return false;
    }
}


