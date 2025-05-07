using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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

    private string GetString(int length = -1)
    {
        var str = length < 0 ? Encoding.GetString(_readBuffer) : Encoding.GetString(_readBuffer, 0, length);

        if (length < 0)
            str = str[..str.IndexOf('\0')];
        
        str = str.Trim();
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

    public string? this[string section, string key] => Read(section, key); 
    public string? this[nint section, nint key] => Read(section, key); 
    public Section this[string section] => new(this, section);
    
    public Section this[AnsiStringPointer section] => new(this, section, false);

}

public readonly ref struct Section
{
    private readonly nint _handle;
    private readonly IniReader _iniReader;
    private readonly bool _allocate;
    
    public Section(IniReader iniReader, string section, bool allocate = true)
    {
        _iniReader = iniReader;
        iniReader.ResetCurrentSectionName();
        _handle = Marshal.StringToHGlobalAnsi(section);
        _allocate = allocate;
    }

    public void Dispose()
    {
        if (_allocate && _handle != 0)
            Marshal.FreeHGlobal(_handle);
    }
    
    public string? this[string key]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            using var pKey = new AnsiStringSpan(key);
            return _iniReader[_handle, pKey];
        }
    }
    
    public unsafe string? this[ReadOnlySpan<byte> key]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _iniReader[_handle, (nint)Unsafe.AsPointer(ref MemoryMarshal.GetReference(key))];
    }
}