using PatcherYrSharp;
using PatcherYrSharp.Helpers;

namespace Eris.Utilities.Network;

public interface INetworkHandle
{
    byte Index { get; }
    uint Lenth { get; }
    string Name { get; }

    void Respond(Pointer<EventClass> pEvent);

}