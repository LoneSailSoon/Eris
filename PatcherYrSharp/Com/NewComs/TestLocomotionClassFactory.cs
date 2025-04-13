using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PatcherYrSharp.Com.Interface;
using PatcherYrSharp.Helpers;
using PatcherYrSharp.Utilities;

namespace PatcherYrSharp.Com.NewComs;

[StructLayout(LayoutKind.Sequential)]
public struct TestLocomotionClassFactory
{
    public nint IClassFactory;
    public int RefCount;

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    public static unsafe int QueryInterfacePtr(nint pThis, nint pId, nint pOut)
    {
        if (pOut == nint.Zero)
            return -2147467261;

        Pointer<Guid> pGuid = pId;

        Pointer<nint> pInterface = pOut;
        pInterface.Data = 0;
        if (pGuid.Ref == ComManager.IidIUnknown || pGuid.Ref == ComManager.IidIClassFactory)
        {
            pInterface.Data = pThis;

            //AddRef
            ((delegate*unmanaged[Stdcall]<nint, void>)Helper.GetVirtualFunctionPointer(pThis, 1))(pThis);
            return 0;
        }

        return -2147467262;
    }

    public static void Constructor(Pointer<TestLocomotionClassFactory> pThis)
    {
        pThis.Ref.IClassFactory = TestLocomotionClassFactoryVtableIClassFactory.Handle;
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    public static int AddRef(nint pThis)
    {
        Pointer<TestLocomotionClassFactory> pFactory = pThis;
        return Interlocked.Increment(ref pFactory.Ref.RefCount);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    public static int Release(nint pThis)
    {
        Pointer<TestLocomotionClassFactory> pFactory = pThis;
        var refCount = Interlocked.Decrement(ref pFactory.Ref.RefCount);
        if (refCount <= 0)
        {
            YRMemory.Deallocate(pThis);
        }

        return refCount;
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    public static unsafe int CreateInstance(nint pThis, nint pUnkOuter, nint riid, nint ppvObject)
    {
        try
        {
            if (ppvObject == nint.Zero)
                return -2147024809;
            Pointer<nint> pOutObject = ppvObject;

            if (pUnkOuter != nint.Zero)
                return -2147221232;
            Pointer<TestLocomotion> pObject = YRMemory.AllocateChecked(24);

            if(pObject == nint.Zero)
                return -2147024882;

            pObject = TestLocomotion.Constructor(pObject);
            if (pObject == nint.Zero)
                return -2147024882;




            Pointer<TestLocomotionClassFactory> pFactory = pThis;
            
            //Console.WriteLine(riid.Convert<Guid>().Data);
            //Console.WriteLine($"CreateInstance:{pObject}");

            //Pointer<nint> pOut = ppvObject;
            var ret = ((delegate* unmanaged[Stdcall]<nint, nint, nint, int>)((Pointer<Pointer<nint>>)(nint)pObject).Ref.Data)(pObject, riid, ppvObject);

            //((delegate* unmanaged[Stdcall]<nint, nint, nint, int>)&TestLocomotion.QueryInterfacePtr)(pObject, riid, ppvObject);
            //var ret = ((delegate* unmanaged[Stdcall]<nint, nint, nint, int>)pObject.Cast<Pointer<nint>>().Ref.Data)(pThis, riid, ppvObject);
            //Console.WriteLine($"CreateInstance end:{ret}");

            if (ret < 0)
            {
                ((delegate* unmanaged[Thiscall]<nint, int, void>)(((Pointer<Pointer<nint>>)(nint)pObject).Ref.Data + 0x20))(pThis, 1);
            }

            return ret;
        }
        catch (Exception e)
        {

            Console.WriteLine(e);
        }
        return -2147221232;
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    public static int LockServer(nint pThis, int fLock)
    {
        if (fLock != 0)
        {
            new Pointer<int>(pThis + 4).Ref++;
        }
        else
        {
            new Pointer<int>(pThis + 4).Ref--;
        }

        return 0;
    }



    public static readonly Memoryor<InterfaceClassFactoryVtable> TestLocomotionClassFactoryVtableIClassFactory =
        new(TestLocomotionClassFactoryVtable_IClassFactory_Initialize);

    private static unsafe void TestLocomotionClassFactoryVtable_IClassFactory_Initialize(
        ref InterfaceClassFactoryVtable vtable)
    {
        vtable.BaseInterfaceUnknownVtable.QueryInterfacePtr =
            (nint)(delegate*unmanaged[Stdcall]<nint, nint, nint, int>)&QueryInterfacePtr;

        vtable.BaseInterfaceUnknownVtable.AddRefPtr =
            (nint)(delegate*unmanaged[Stdcall]<nint, int>)&AddRef;

        vtable.BaseInterfaceUnknownVtable.ReleasePtr =
            (nint)(delegate*unmanaged[Stdcall]<nint, int>)&Release;

        vtable.CreateInstancePtr =
            (nint)(delegate*unmanaged[Stdcall]<nint, nint, nint, nint, int>)&CreateInstance;

        vtable.LockServerPtr =
            (nint)(delegate*unmanaged[Stdcall]<nint, int, int>)&LockServer;
    }
}