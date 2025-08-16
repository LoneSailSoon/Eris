using System.Diagnostics.CodeAnalysis;
using System.Text;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.String.Ansi;

namespace Eris.Utilities.Ini;

public class IniReader
{
    private Pointer<CCIniClass> _pIni;
    private readonly byte[] _readBuffer = new byte[2048];
    
    public Encoding Encoding { get; set; } = Encoding.UTF8;
    
    public static readonly IniReader Default = new();
    

    public void SetCurrentIni(Pointer<CCIniClass> pIni)
    {
        _pIni = pIni;
    }

    private string GetString(int length = -1)
    {
        var str = length < 0 ? Encoding.GetString(_readBuffer) : Encoding.GetString(_readBuffer, 0, length);

        if (length < 0)
            str = str[..str.IndexOf('\0')];
        
        str = str.Replace(" ", "");
        return str;
    }

    public string? Read(string? section, string key)
    {
        return ReadString(section, key, out var value) ? value : null;
    }

    private int ReadBuffer(string section, string key)
    {
        using var pSection = new AnsiStringSpan(section);
        using var pKey = new AnsiStringSpan(key);
        
        return _pIni.Ref.ReadString(pSection, pKey, 0, _readBuffer, _readBuffer.Length);
    }
    public bool ReadString(string? section, string key, [NotNullWhen(true)]out string? buffer)
    {
        if (section is not null && ReadBuffer(section, key) is var count and > 0)
        {
            buffer = GetString(count);
            
            return true;
        }

        buffer = null;
        return false;
    }

    public string? Read(nint section, nint key)
    {
        return ReadString(section, key, out var value) ? value : null;
    }

    private int ReadBuffer(nint section, nint key)
    {
        return _pIni.Ref.ReadString(section, key, 0, _readBuffer, _readBuffer.Length);
    }

    public bool ReadString(nint section, nint key, [NotNullWhen(true)]out string? buffer)
    {
        if (section is not 0 && ReadBuffer(section, key) is var count and > 0)
        {
            buffer = GetString(count);
            
            return true;
        }

        buffer = null;
        return false;
    }

    public void ResetCurrentSectionName()
    {
        if (_pIni)
        {
            _pIni.Ref.CurrentSectionName = 0;
        }
    }
     
    public Pointer<IniClass.IniSection> GetIniSection(nint section) => _pIni.Ref.GetSection(section);

    public string? this[string section, string key] => Read(section, key); 
    public string? this[nint section, nint key] => Read(section, key); 
    public Section this[string section] => new(this, section);
    
    public Section this[AnsiStringPointer section] => new(this, section, false);

}