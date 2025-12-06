using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.Utilities.Network;
using Eris.YRSharp.Helpers;

namespace Eris.Behaviors;

public static class NetworkBehaviors
{
    //[Hook(0x4C6CB0, 0x6)]
    [UnmanagedCallersOnly(EntryPoint = "Network_RespondToEvent_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint Network_RespondToEvent_Behaviors(Registers* r)
    {
        return Network.Network_RespondToEvent_Behaviors(r);
    }


    //[Hook(0x64BE7D, 0x6)]
    [UnmanagedCallersOnly(EntryPoint = "Network_GetEventSize1_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint Network_GetEventSize1_Behaviors(Registers* r)
    {
        return Network.Network_GetEventSize1_Behaviors(r);
    }


    //[Hook(0x64C30E, 0x6)]
    [UnmanagedCallersOnly(EntryPoint = "Network_GetEventSize2_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint Network_GetEventSize2_Behaviors(Registers* r)
    {
        return Network.Network_GetEventSize2_Behaviors(r);
    }


    //[Hook(0x64B6FE, 0x6)]
    [UnmanagedCallersOnly(EntryPoint = "Network_GetEventSize3_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint Network_GetEventSize3_Behaviors(Registers* r)
    {
        return Network.Network_GetEventSize3_Behaviors(r);
    }

}