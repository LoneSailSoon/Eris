using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.String.Ansi;

namespace Eris.Utilities.Ini;

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
    
    public Enumerator GetEnumerator() => new Enumerator(this);

    public ref struct Enumerator
    {
        private readonly Pointer<IniClass.IniEntry> _last;
        private readonly Pointer<GenericNode> _firstNode;
        
        private Pointer<GenericNode> _current;
        private bool _next = true;
        public Enumerator(Section section)
        {
            var list = section._iniReader.GetIniSection(section._handle);
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