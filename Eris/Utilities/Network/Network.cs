using Eris.YRSharp;
using Eris.YRSharp.Helpers;

namespace Eris.Utilities.Network;

public static class Network
{
    static Network()
    {
        NetworkHandles = [];
        return;


        static void Register(INetworkHandle handle)
        {
            NetworkHandles.Add(handle.Index, handle);
        }
    }

    public static readonly Dictionary<byte, INetworkHandle> NetworkHandles;


    public static bool GetEventLength(byte events, out uint length)
    {
        if (NetworkHandles.TryGetValue(events, out var handler))
        {
            length = handler.Lenth;
            return true;
        }

        length = 0;
        return false;
    }

    public static unsafe uint Network_RespondToEvent_Behaviors(Registers* r)
    {
        try
        {
            Pointer<EventClass> pEvent = (nint)r->ECX;
            var eventType = (byte)pEvent.Ref.Type;
            if (NetworkHandles.TryGetValue(eventType, out var handler))
            {
                handler.Respond(pEvent);
            }
        }
        catch (Exception e)
        {
            Logger.Logger.LogException(e);
        }

        return 0;
    }


    public static unsafe uint Network_GetEventSize1_Behaviors(Registers* r)
    {
        var nSize = (byte)r->EDI;

        if (!GetEventLength(nSize, out var length)) return 0;
        r->ECX = length;
        r->EBP = length;
        r->Stack(0x20, length);

        return 0x64BE97;

    }


    public static unsafe uint Network_GetEventSize2_Behaviors(Registers* r)
    {
        var nSize = (byte)r->ESI;

        if (!GetEventLength(nSize, out var length)) return 0;
        r->ECX = length;
        r->EBP = length;
        return 0x64C321;

    }


    public static unsafe uint Network_GetEventSize3_Behaviors(Registers* r)
    {
        var nSize = (byte)r->EDI;

        if (!GetEventLength(nSize, out var length)) return 0;
        r->EDX = length;
        r->EBP = length;
        return 0x64B71D;

    }
}