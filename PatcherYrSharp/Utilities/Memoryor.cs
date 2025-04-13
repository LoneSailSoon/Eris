using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PatcherYrSharp.Utilities;

public class Memoryor<T> : IDisposable where T : unmanaged
{
    private nint _handle;
    public nint Handle => _handle;
    public unsafe ref T Ref => ref Unsafe.AsRef<T>(_handle.ToPointer());
    public Memoryor()
    {
        _handle = Marshal.AllocHGlobal(Marshal.SizeOf<T>());
    }

    public Memoryor(MemoryorInitialize<T> initialize)
    {
        _handle = Marshal.AllocHGlobal(Marshal.SizeOf<T>());
        unsafe
        {
            initialize(ref Unsafe.AsRef<T>(_handle.ToPointer()));
        }
    }


    public void Dispose()
    {
        if(_handle != nint.Zero)
        {
            Marshal.FreeHGlobal(_handle);
            _handle = IntPtr.Zero;
        }
    }

    ~Memoryor()
    {
        if (_handle != nint.Zero)
        {
            Marshal.FreeHGlobal(_handle);
            _handle = IntPtr.Zero;
        }
    }
}

public delegate void MemoryorInitialize<T>(ref T value);
