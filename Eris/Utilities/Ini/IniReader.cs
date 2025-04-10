using System.Diagnostics.CodeAnalysis;
using System.Text;
using PatcherYrSharp;
using PatcherYrSharp.Helpers;

namespace Eris.Utilities.Ini;

public class IniReader
{
    private Pointer<CCINIClass> _pIni;
    private readonly byte[] _readBuffer = new byte[2048];
    
    public Encoding Encoding { get; set; } = Encoding.UTF8;
    
    public static readonly IniReader Default = new();
    

    public void SetCurrentIni(Pointer<CCINIClass> pIni)
    {
        _pIni = pIni;
    }

    public string? Read(string? section, string key)
    {
        return ReadString(section, key, out var value) ? value : null;
    }

    private string GetString()
    {
        string str = Encoding.GetString(_readBuffer);
        str = str[..str.IndexOf('\0')];
        str = str.Trim();

        return str;
    }
    private int ReadBuffer(string section, string key)
    {
        return _pIni.Ref.ReadString(section, key, "", _readBuffer, _readBuffer.Length);
    }
    public bool ReadString(string? section, string key, [NotNullWhen(true)]out string? buffer)
    {
        if (section is not null && ReadBuffer(section, key) > 0)
        {
            buffer = GetString();
            
            return true;
        }

        buffer = null;
        return false;
    }

}