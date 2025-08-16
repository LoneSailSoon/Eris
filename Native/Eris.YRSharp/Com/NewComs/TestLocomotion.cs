using System.Runtime.CompilerServices;
using Eris.Misc.Memoryor;
using Eris.YRSharp.Com.Interface;
using Eris.YRSharp.Com.YrComs;
using Eris.YRSharp.GeneralDefinitions;

namespace Eris.YRSharp.Com.NewComs;

[StructLayout(LayoutKind.Explicit, Size = 24)]
public struct TestLocomotion
{
    public static readonly Guid UuId = new("AEB2742B-6F2C-8E99-1097-313E72C98391");


    [FieldOffset(0)] public LocomotionClass Base;
    // This is the desired destination coordinate of the object.
    //     public CoordStruct DestinationCoord;
    //
    // // This is the coordinate that the unit is heading to as an immediate
    // // destination. This coordinate is never further than once cell (or track)
    // // from the unit's location. When this coordinate is reached, then the
    // // next location in the path list becomes the next HeadTo coordinate.
    //     public CoordStruct HeadToCoord;
    //
    // //  This is the logical coordinate for the object. It is the center of
    // //  the circle when calculating the rotation.
    //     public CoordStruct CenterCoord;
    //
    // //  The current rotation angle.
    //     public double Angle;
    //
    // //  If this object is moving, then this flag will be true.
    //     public bool IsMoving;


    public static unsafe Pointer<TestLocomotion> Constructor(Pointer<TestLocomotion> pThis)
    {
        var func = (delegate* unmanaged[Thiscall]<nint, nint>)0x55A6C0;
        var ret = func(pThis);

        pThis.Ref.Base.ILocomotion = TestLocomotionVtableILocomotion.Handle;
        pThis.Ref.Base.IPersistStream = TestLocomotionVtableIPersistStream.Handle;
        //Console.WriteLine($"Constructor {pThis}");
        return ret;
    }


    //[UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    //public static unsafe int QueryInterfacePtr(nint pThis, nint pId, nint pOut)
    //{
    //    Console.WriteLine($"QueryInterfacePtr: {pThis} {pId.Convert<Guid>().Data} {pId.Convert<Guid>().Data == ComManager.IidIUnknown} {pOut}");
    //    Console.WriteLine($"{pThis.Convert<TestLocomotion>().Ref.Base.IPersistStream} {pThis.Convert<TestLocomotion>().Ref.Base.ILocomotion}");
    //    var pLoco = pThis.Convert<TestLocomotion>();
    //    pLoco.Ref.Base.ILocomotion = TestLocomotionVtableILocomotion.Handle;
    //    pLoco.Ref.Base.IPersistStream = TestLocomotionVtableIPersistStream.Handle;


    //    var func = (delegate* unmanaged[Thiscall]<nint,nint,nint, int>)0x55A9B0;
    //    var ret = func(pThis, pId, pOut);

    //    Console.WriteLine($"QueryInterfacePtr: {ret}");

    //    return ret;
    //}


    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    public static int InWhichLayer(nint pThis)
    {
        return (int)Layer.Ground;
    }


    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    public static int GetClassId(nint pThis, nint pId)
    {
        if (pId == nint.Zero)
            return -2147467261;

        pId.Convert<Guid>().Ref = UuId;

        return 0;
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvThiscall)])]
    public static int Size(nint pThis)
    {
        return 24;
    }



    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    public static unsafe int Load(nint pThis, nint pStm)
    {
        //Console.WriteLine("Load start");
        var func = (delegate* unmanaged[Stdcall]<nint, nint, int>)LocomotionComObject.LocomotionVtableIPersistStream.Ref.LoadPtr;
        var ret = func(pThis, pStm);

        //Console.WriteLine($"Load:{ret}");

        if (ret < 0)
            return ret;

        var pLoco = pThis.Convert<TestLocomotion>();
        pLoco.Ref.Base.ILocomotion = TestLocomotionVtableILocomotion.Handle;
        pLoco.Ref.Base.IPersistStream = TestLocomotionVtableIPersistStream.Handle;

        //Console.WriteLine($"Load end");
        return ret;
    }













    public static readonly Memoryor<InterfaceLocomotionVtable> TestLocomotionVtableILocomotion = new(TestLocomotionVtable_ILocomotion_Initialize);

    public static readonly Memoryor<InterfacePersistStreamVtable> TestLocomotionVtableIPersistStream = new(TestLocomotionVtable_IPersistStream_Initialize);

    private static unsafe void TestLocomotionVtable_ILocomotion_Initialize(ref InterfaceLocomotionVtable vtable)
    {
        LocomotionComObject.LocomotionVtable_ILocomotion_Initialize(ref vtable);
        //vtable.BaseInterfaceUnknownVtable.QueryInterfacePtr = (nint)(delegate* unmanaged[Stdcall]<nint, nint, nint, int>)&QueryInterfacePtr;
        vtable.InWhichLayer = (nint)(delegate* unmanaged[Stdcall]<nint, int>)&InWhichLayer;
    }

    private static unsafe void TestLocomotionVtable_IPersistStream_Initialize(ref InterfacePersistStreamVtable vtable)
    {
        LocomotionComObject.LocomotionVtable_IPersistStream_Initialize(ref vtable);
        //vtable.BaseInterfaceUnknownVtable.QueryInterfacePtr = (nint)(delegate* unmanaged[Stdcall]<nint, nint, nint, int>)&QueryInterfacePtr;
        vtable.GetClassIDPtr = (nint)(delegate* unmanaged[Stdcall]<nint, nint, int>)&GetClassId;
        vtable.SizePtr = (nint)(delegate* unmanaged[Thiscall]<nint, int>)&Size;
        vtable.LoadPtr = (nint)(delegate* unmanaged[Stdcall]<nint, nint, int>)&Load;
    }

}