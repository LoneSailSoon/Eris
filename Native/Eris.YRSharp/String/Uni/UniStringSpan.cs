using System.Runtime.CompilerServices;

namespace Eris.YRSharp.String.Uni;

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


