using Eris.YRSharp;
using Eris.YRSharp.Helpers;

namespace Eris.Utilities.Network;

public interface INetworkHandle
{
    byte Index { get; }
    uint Lenth { get; }
    string Name { get; }

    void Respond(Pointer<EventClass> pEvent);

}