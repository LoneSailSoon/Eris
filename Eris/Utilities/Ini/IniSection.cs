using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.String.Ansi;

namespace Eris.Utilities.Ini;

public readonly ref struct IniSection
{
    private readonly nint _handle;
    public readonly IniReader IniReader;
    private readonly bool _allocate;
    public IniSection(IniReader iniReader, nint section, bool allocate = false)
    {
        _handle = section;
        IniReader = iniReader;
        _allocate = allocate;
        iniReader.ResetCurrentSectionName();
    }

    public IniSection(IniReader iniReader, string section) : this(iniReader, Marshal.StringToHGlobalAnsi(section), true)
    {
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
            return IniReader.ReadString(_handle, pKey, out var value) ? value : null;
        }
    }

    public unsafe string? this[ReadOnlySpan<byte> key]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => IniReader.ReadString(_handle, (nint)Unsafe.AsPointer(ref MemoryMarshal.GetReference(key)), out var value) ? value : null;
    }

    public Enumerator GetEnumerator() => new(this);

    public ref struct Enumerator
    {
        private readonly Pointer<IniClass.IniEntry> _last;
        private readonly Pointer<GenericNode> _firstNode;


        private Pointer<GenericNode> _current;
        private bool _next = true;
        public Enumerator(IniSection section)
        {
            var list = section.IniReader.GetIniSection(section._handle);
            if (!list)
            {
                _next = false;
                return;
            }
            _last = list.Ref.Entries.Last;
            _firstNode = list.Ref.Entries.Base.FirstNode.Next;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            var result = _next;
            if (!result) return false;
            _current = _current.IsNotNull ? _current.Ref.Next : _firstNode;

            _next = (nint)_current != (nint)_last;
            return result;
        }

        public readonly Entry Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                var current = _current.Cast<IniClass.IniEntry>();
                return new(current.Ref.Key, current.Ref.Value);
            }
        }
    }

    public record struct Entry(AnsiStringPointer Key, AnsiStringPointer Value);
}

public interface ISection
{
    public string? GetValue(string key);
}

public interface IIniId
{
    public bool GetSection(IniReader reader, out IniSection section);
    public bool GetArtSection(IniReader reader, out IniSection section);
}
