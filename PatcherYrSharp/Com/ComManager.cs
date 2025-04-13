using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using PatcherYrSharp.Com.Interface;
using PatcherYrSharp.Utilities;

namespace PatcherYrSharp.Com;

public static class ComManager
{
    // public static readonly StrategyBasedComWrappers Wrappers = new();
    //
    public static void RegisterFactoryForClass(Guid rclsid, nint factory)
    {
        var hr = CoRegisterClassObject(rclsid, factory, 1, 1, out var lpdwRegister);
        if (hr != 0)
            Console.WriteLine("Failed to instantiate COM classes. Error: " + hr);
        else
            Console.WriteLine("Successfully instantiated COM classes.");
    
        Game.COMClasses.AddItem(lpdwRegister);
    }
    
    [DllImport("ole32.dll")]
    public static extern int CoRegisterClassObject(
        [MarshalAs(UnmanagedType.LPStruct)] Guid rclsid,
        nint pUnk,
        uint dwClsContext,
        uint flags,
        out uint lpdwRegister);

    public static readonly Guid IidIUnknown = new Guid("00000000-0000-0000-C000-000000000046");

    public static readonly Guid IidIClassFactory = new Guid("00000001-0000-0000-C000-000000000046");

    public static readonly Guid IidIPersistStream = new Guid("00000109-0000-0000-C000-000000000046");

    public static readonly Guid IidIPersist = new Guid("0000010c-0000-0000-C000-000000000046");
    
    public static readonly Guid IidILocomotion = new Guid("070F3290-9841-11D1-B709-00A024DDAFD1");

    public static readonly Guid IidIPiggyback = new Guid("92FEA800-A184-11D1-B70A-00A024DDAFD1");

}