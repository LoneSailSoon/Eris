using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.YRSharp.Helpers;

namespace Eris.YRSharp.String.Uni;

public sealed class UniString : IDisposable
{
    public readonly nint HGlobal;
    private readonly bool _allocated;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public UniString(string str)
    {
        HGlobal = Marshal.StringToHGlobalUni(str);
        _allocated = true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public UniString(IntPtr buffer, bool allocate = false)
    {
        HGlobal = allocate ? Marshal.StringToHGlobalUni(Marshal.PtrToStringUni(buffer)) : buffer;
        _allocated = allocate;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator nint(UniString uniStr) => uniStr.HGlobal;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator string(UniString uniStr) => Marshal.PtrToStringUni((nint)uniStr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator UniString(string str) => new(str);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator UniString(nint ptr) => new(ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator UniString(Pointer<char> ptr) => new(ptr);

    public override string ToString() => this;

    private bool _disposedValue;
 
    private void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
            }

            if (HGlobal != nint.Zero && _allocated)
            {
                Marshal.FreeHGlobal(HGlobal);
            }

            _disposedValue = true;
        }
    }

    ~UniString()
    {
        Dispose(disposing: false);
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}