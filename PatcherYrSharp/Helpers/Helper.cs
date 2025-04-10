using System.Runtime.CompilerServices;

namespace PatcherYrSharp.Helpers;

public static class Helper
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref T GetUnmanagedRef<T>(nint ptr, int offset = 0)
    {
        return ref ptr.Convert<T>()[offset];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe Span<T> GetSpan<T>(nint ptr, int length)
    {
        return new Span<T>(ptr.ToPointer(), length);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TTo ForceConvert<TFrom, TTo>(TFrom obj)
    {
        return Unsafe.As<TFrom, TTo>(ref obj);
        //    var ptr = new Pointer<TTo>(Pointer<TFrom>.AsPointer(ref obj));
        //    return ptr.Ref;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static nint GetVirtualFunctionTable(nint pThis, int tableIndex)
    {
        Pointer<Pointer<nint>> pVfptr = pThis;
        Pointer<nint> vfptr = pVfptr[tableIndex];
        return vfptr;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static nint GetVirtualFunctionTable<T>(Pointer<T> pThis, int tableIndex)
    {
        return GetVirtualFunctionTable((nint)pThis, tableIndex);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static nint GetVirtualFunctionTable<T>(ref this T pThis, int tableIndex) where T : struct
    {
        return GetVirtualFunctionTable(Pointer<T>.AsPointer(ref pThis), tableIndex);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static nint GetVirtualFunctionPointer(nint pThis, int index, int tableIndex = 0)
    {
        Pointer<nint> vfptr = GetVirtualFunctionTable(pThis, tableIndex);
        nint address = vfptr[index];
        return address;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static nint GetVirtualFunctionPointer<T>(Pointer<T> pThis, int index, int tableIndex = 0)
    {
        return GetVirtualFunctionPointer((nint)pThis, index, tableIndex);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static nint GetVirtualFunctionPointer<T>(ref this T pThis, int index, int tableIndex = 0) where T : struct
    {
        return GetVirtualFunctionPointer(Pointer<T>.AsPointer(ref pThis), index, tableIndex);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SetVirtualFunctionPointer(nint pThis, int index, nint functionAddress, int tableIndex = 0)
    {
        Pointer<nint> vfptr = GetVirtualFunctionTable(pThis, tableIndex);
        vfptr[index] = functionAddress;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SetVirtualFunctionPointer<T>(Pointer<T> pThis, int index, nint functionAddress,
        int tableIndex = 0)
    {
        SetVirtualFunctionPointer((nint)pThis, index, functionAddress, tableIndex);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SetVirtualFunctionPointer<T>(ref this T pThis, int index, nint functionAddress,
        int tableIndex = 0) where T : struct
    {
        SetVirtualFunctionPointer(Pointer<T>.AsPointer(ref pThis), index, functionAddress, tableIndex);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Pointer<T> Convert<T>(this nint ptr)
    {
        return new Pointer<T>(ptr);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void Copy(nint from, nint to, int byteCount)
    {
        Unsafe.CopyBlock(to.ToPointer(), from.ToPointer(), (uint)byteCount);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Pointer<T> GetThisPointer<T>(ref this T pThis) where T : struct
    {
        return Pointer<T>.AsPointer(ref pThis);
    }
}