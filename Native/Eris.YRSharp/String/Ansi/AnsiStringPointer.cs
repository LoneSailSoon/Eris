using System.Runtime.CompilerServices;

namespace Eris.YRSharp.String.Ansi;

[StructLayout(LayoutKind.Sequential)]
[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
public struct AnsiStringPointer(nint ptr) : IEquatable<AnsiStringPointer>
{
    nint buffer = ptr;

    public AnsiStringPointer(ref byte buffer, int _) : this(buffer.GetThisPointer())
    {
        
    }
    
    
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
    
    public unsafe ReadOnlySpan<byte> AsSpan(int length)
    {
        return new ReadOnlySpan<byte>(buffer.ToPointer(), length);
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