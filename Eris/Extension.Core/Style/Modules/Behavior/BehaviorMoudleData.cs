using Eris.Serializer;
using Eris.Utilities.Ini;
using NaegleriaSerializer.Streaming;

namespace Eris.Extension.Core.Style.Modules.Behavior;

public class BehaviorMoudleData: FilterableConfig
{
    public override void Serialize(INaegleriaStream stream)
    {
    }

    public override int SerializeType => SerializeRegister.BehaviorMoudleDataType;
    
    public override void Read(Section section)
    {
    }

    public override bool Enable => false;
}