using System.Runtime.CompilerServices;

namespace Eris.YRSharp.Helpers;

public readonly struct ComPointer<T>(nint pointer)
{
    private readonly nint _pointer = pointer;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator nint(ComPointer<T> value) => value._pointer;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ComPointer<T>(nint value) => new(value);

    public Pointer<nint> VTable
    {
        [method: MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _pointer.Convert<Pointer<nint>>().Data;
    }

    public unsafe void AddRef()
    {
        ((delegate*unmanaged[Stdcall]<nint, uint>)VTable[1])(_pointer);
    }

    public unsafe void Release()
    {
        ((delegate*unmanaged[Stdcall]<nint, uint>)VTable[2])(_pointer);
    }

    public unsafe void QueryInterface(Pointer<Guid> riid, Pointer<nint> ppvObject)
    {
        ((delegate*unmanaged[Stdcall]<nint, nint, nint, uint>)VTable[0])(_pointer, riid, ppvObject);
    }
}