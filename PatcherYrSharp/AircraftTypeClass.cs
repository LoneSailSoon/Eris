using System.Runtime.InteropServices;

namespace PatcherYrSharp;

[StructLayout(LayoutKind.Explicit, Size = 3600)]
public struct AircraftTypeClass
{
    // public static unsafe Pointer<AbstractTypeClass> FindOrAllocate(string ID)
    // {
    //     var func = (delegate* unmanaged[Thiscall]<int, IntPtr, IntPtr>)ASM.FastCallTransferStation;
    //     return func(0x41CEF0, new AnsiString(ID));
    // }


    [FieldOffset(0)] public TechnoTypeClass Base;
    [FieldOffset(0)] public ObjectTypeClass BaseObjectType;
    [FieldOffset(0)] public AbstractTypeClass BaseAbstractType;
    [FieldOffset(3576)] public int ArrayIndex;

}