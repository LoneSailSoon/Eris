using Eris.Extension.Eris.Generic;
using Eris.Extension.Eris.Style.State.DestroySelf;
using Eris.Serializer;
using NaegleriaSerializer;
using NaegleriaSerializer.Streaming;

namespace Eris.Extension.Eris.Style;

public class StyleStateManager : INaegleriaSerializable
{
    public void Serialize(INaegleriaStream stream)
    {
        stream.ProcessObject(ref DestroySelfState);
    }

    public int SerializeType => SerializeRegister.StyleStateModuleType;
    public ulong SerializeId { get; } = SerializeIdCreater.NewId();

    
    public DestroySelfState? DestroySelfState;

    public void OnUpdate()
    {
        DestroySelfState?.GetStateModule()?.OnUpdate();
    }

    public void Destroy()
    {
        DestroySelfState?.ForcePop();
    }
}