using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PatcherYrSharp.Helpers;

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
    public static implicit operator AnsiString(IntPtr ptr) => new(ptr);

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

[StructLayout(LayoutKind.Sequential)]
[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
public struct AnsiStringPointer(nint ptr) : IEquatable<AnsiStringPointer>
{
    nint buffer = ptr;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator AnsiString(AnsiStringPointer pointer) => new(pointer.buffer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator nint(AnsiStringPointer pointer) => pointer.buffer;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator string(AnsiStringPointer pointer) => (AnsiString)pointer;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator AnsiStringPointer(nint ptr) => new(ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator AnsiStringPointer(Pointer<byte> ptr) => new(ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator AnsiStringPointer(AnsiString str) => (nint)str;


    public override string ToString() => this;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static AnsiStringPointer From(nint ptr) => new(ptr);

    public unsafe ReadOnlySpan<byte> AsSpan()
    {
        var length = ((delegate* unmanaged[Cdecl]<nint, uint>)0x7D15A0)(buffer);
        return new ReadOnlySpan<byte>(buffer.ToPointer(), (int)length);
    } 

    public bool Equals(AnsiStringPointer other)
    {
        return buffer == other.buffer;
    }

    public override bool Equals(object obj)
    {
        return obj is AnsiStringPointer other && Equals(other);
    }

    public override int GetHashCode()
    {
        return buffer.GetHashCode();
    }

    public static bool operator ==(AnsiStringPointer left, AnsiStringPointer right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(AnsiStringPointer left, AnsiStringPointer right)
    {
        return !left.Equals(right);
    }
}

[StructLayout(LayoutKind.Sequential)]
[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
public readonly ref struct AnsiStringSpan(string str)
{
    public readonly nint Handle = Marshal.StringToHGlobalAnsi(str);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Dispose()
    {
        if (Handle != 0)
        {
            Marshal.FreeHGlobal(Handle);
        }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator nint(AnsiStringSpan pointer) => pointer.Handle;

}

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

[StructLayout(LayoutKind.Sequential)]
[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
public struct UniStringPointer(nint ptr)
{
    nint buffer = ptr;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator UniString(UniStringPointer pointer) => new UniString(pointer.buffer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator nint(UniStringPointer pointer) => pointer.buffer;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator string(UniStringPointer pointer) => (UniString)pointer;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator UniStringPointer(nint ptr) => new(ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator UniStringPointer(Pointer<char> ptr) => new(ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator UniStringPointer(UniString str) => (nint)str;


    public override string ToString() => this;
    
        
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UniStringPointer From(nint ptr) => new(ptr);

    
    public unsafe ReadOnlySpan<char> AsSpan()
    {
        var length = ((delegate* unmanaged[Cdecl]<nint, uint>)0x7CA405)(buffer);
        return new ReadOnlySpan<char>(buffer.ToPointer(), (int)length);
    } 

}

[StructLayout(LayoutKind.Sequential)]
[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
public readonly ref struct UniStringSpan(string str)
{
    public readonly nint Handle = Marshal.StringToHGlobalUni(str);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Dispose()
    {
        if (Handle != 0)
        {
            Marshal.FreeHGlobal(Handle);
        }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator nint(UniStringSpan pointer) => pointer.Handle;

}


