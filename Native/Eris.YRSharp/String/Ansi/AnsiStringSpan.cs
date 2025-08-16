using System.Runtime.CompilerServices;

namespace Eris.YRSharp.String.Ansi;

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
    
    public unsafe ReadOnlySpan<byte> AsSpan()
    {
        var length = ((delegate* unmanaged[Cdecl]<nint, uint>)0x7D15A0)(Handle);
        return new ReadOnlySpan<byte>(Handle.ToPointer(), (int)length);
    } 

    public unsafe ReadOnlySpan<byte> AsSpan(int length)
    {
        return new ReadOnlySpan<byte>(Handle.ToPointer(), length);
    } 


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator nint(AnsiStringSpan pointer) => pointer.Handle;
}