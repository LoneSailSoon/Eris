using System.Runtime.CompilerServices;

namespace Eris.YRSharp.String.Ansi;

public sealed class AnsiString : IDisposable
{
    public readonly nint HGlobal;
    private readonly bool _allocated;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public AnsiString(string str)
    {
        HGlobal = Marshal.StringToHGlobalAnsi(str);
        _allocated = true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public AnsiString(nint buffer, bool allocate = false)
    {
        HGlobal = allocate ? Marshal.StringToHGlobalAnsi(Marshal.PtrToStringAnsi(buffer)) : buffer;
        _allocated = allocate;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator nint(AnsiString ansiStr) => ansiStr.HGlobal;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator uint(AnsiString ansiStr) => (uint)ansiStr.HGlobal;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator string(AnsiString ansiStr) => Marshal.PtrToStringAnsi((IntPtr)ansiStr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator AnsiString(string str) => new(str);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator AnsiString(nint ptr) => new(ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator AnsiString(Pointer<byte> ptr) => new(ptr);

    public override string ToString() => this;

    private bool _disposedValue;

    private void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
            }

            if (HGlobal != IntPtr.Zero && _allocated)
            {
                Marshal.FreeHGlobal(HGlobal);
            }

            _disposedValue = true;
        }
    }

    ~AnsiString()
    {
        Dispose(disposing: false);
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}