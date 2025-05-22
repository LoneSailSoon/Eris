using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator nint(AnsiStringSpan pointer) => pointer.Handle;
}