using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.YRSharp.Helpers;

namespace Eris.YRSharp.String.Uni;

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