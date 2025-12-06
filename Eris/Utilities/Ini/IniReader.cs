using Eris.YRSharp;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.String.Ansi;
using System.Diagnostics.CodeAnalysis;

namespace Eris.Utilities.Ini;


public readonly ref struct IniReader(Pointer<CCIniClass> pIni, IniBuffer buffer)
{
    private readonly Pointer<CCIniClass> _pIni = pIni;
    public readonly IniBuffer Buffer = buffer;

    public bool ReadString(nint section, nint key, [NotNullWhen(true)] out string? buffer) => Buffer.ReadString(_pIni, section, key, out buffer);
    public void ResetCurrentSectionName()
    {
        if (_pIni != 0)
            _pIni.Ref.CurrentSectionName = 0;
    }

    public Pointer<IniClass.IniSection> GetIniSection(nint section) => _pIni.Ref.GetSection(section);

    public IniSection this[AnsiStringPointer section] => new(this, section);
    public IniSection this[string section] => new(this, section);
}