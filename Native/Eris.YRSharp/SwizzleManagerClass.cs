using System.Runtime.InteropServices;
using Eris.YRSharp.GeneralStructures;
using Eris.YRSharp.Helpers;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Sequential)]
public struct SwizzlePointerClass
{
    uint unknown_0; //no idea, only found it being zero
    nint pAnything; //the pointer, to literally any object type
}



[StructLayout(LayoutKind.Explicit, Size = 52)]
public struct SwizzleManagerClass
{
    private const nint instance = 0xB0C110;
    public static ref SwizzleManagerClass Instance => ref instance.Convert<SwizzleManagerClass>().Ref;
    
    public unsafe uint Swizzle(Pointer<nint> pointer)
    {
        var func = (delegate* unmanaged[Stdcall]<nint, nint, uint>)this.GetVirtualFunctionPointer(4);
        return func(this.GetThisPointer(), pointer);
    }
    
    [FieldOffset(4)]
    public DynamicVectorClass<SwizzlePointerClass> Swizzles_Old;
    [FieldOffset(28)]
    public DynamicVectorClass<SwizzlePointerClass> Swizzles_New;

}