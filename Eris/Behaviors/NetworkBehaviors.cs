using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.Utilities.Network;
using PatcherYrSharp.Helpers;

namespace Eris.Behaviors;

public static class NetworkBehaviors
{
    //[Hook(0x4C6CB0, 0x6)]
    [UnmanagedCallersOnly(EntryPoint = "Network_RespondToEvent_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint Network_RespondToEvent_Behaviors(Registers* r)
    {
        return Network.Network_RespondToEvent_Behaviors(r);//EventClassExt.EventClass_RespondToEvent(R);
    }


    //[Hook(0x64BE7D, 0x6)]
    [UnmanagedCallersOnly(EntryPoint = "Network_GetEventSize1_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint Network_GetEventSize1_Behaviors(Registers* r)
    {
        return Network.Network_GetEventSize1_Behaviors(r);//EventClassExt.sub_64BDD0_GetEventSize1(R);
    }


    //[Hook(0x64C30E, 0x6)]
    [UnmanagedCallersOnly(EntryPoint = "Network_GetEventSize2_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint Network_GetEventSize2_Behaviors(Registers* r)
    {
        return Network.Network_GetEventSize2_Behaviors(r);//EventClassExt.sub_64BDD0_GetEventSize2(R);
    }


    //[Hook(0x64B6FE, 0x6)]
    [UnmanagedCallersOnly(EntryPoint = "Network_GetEventSize3_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint Network_GetEventSize3_Behaviors(Registers* r)
    {
        return Network.Network_GetEventSize3_Behaviors(r);//EventClassExt.sub_64B660_GetEventSize(R);
    }

}