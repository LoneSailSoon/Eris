using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Eris.Misc.Memoryor;

public class Memoryor<T> : IDisposable where T : unmanaged
{
    public nint Handle { get; private set; }

    public unsafe ref T Ref => ref Unsafe.AsRef<T>(Handle.ToPointer());
    
    public Memoryor()
    {
        Handle = Marshal.AllocHGlobal(Marshal.SizeOf<T>());
    }

    public Memoryor(MemoryorInitialize<T> initialize)
    {
        Handle = Marshal.AllocHGlobal(Marshal.SizeOf<T>());
        unsafe
        {
            initialize(ref Unsafe.AsRef<T>(Handle.ToPointer()));
        }
    }


    public void Dispose()
    {
        if(Handle != nint.Zero)
        {
            Marshal.FreeHGlobal(Handle);
            Handle = IntPtr.Zero;
        }
    }

    ~Memoryor()
    {
        if (Handle != nint.Zero)
        {
            Marshal.FreeHGlobal(Handle);
            Handle = IntPtr.Zero;
        }
    }
}

public delegate void MemoryorInitialize<T>(ref T value);
