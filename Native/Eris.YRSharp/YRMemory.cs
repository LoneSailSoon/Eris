using System.Runtime.InteropServices;
using Eris.YRSharp.Helpers;

namespace Eris.YRSharp;

// provides access to the game's operator new and operator delete.
public static class YRMemory
{
	// both functions are naked, which means neither prolog nor epilog are
	// generated for them. thus, a simple jump suffices to redirect to the
	// original methods, and no more book keeping or cleanup has to be
	// performed the calling convention has to match for this trick to work.

	// naked does not support inlining. the inline modifier here means that
	// multiple definitions are allowed.

	// the game's operator new
	public static unsafe IntPtr Allocate(uint size)
	{
		var func = (delegate* unmanaged[Cdecl]<uint, nint>)0x7C8E17;
		return func(size);
	}

	// the game's operator delete
	public static unsafe void Deallocate(IntPtr mem)
	{
		var func = (delegate* unmanaged[Cdecl]<nint, void>)0x7C8B3D;
		func(mem);
	}

	public static IntPtr AllocateChecked(uint size)
	{
		var ptr = Allocate(size);
		if (ptr == IntPtr.Zero)
		{
			throw new OutOfMemoryException("YRMemory Alloc fail.");
		}
		return ptr;
	}

	public static Pointer<T> Allocate<T>()
	{
		return AllocateChecked((uint)Marshal.SizeOf<T>());
	}
}