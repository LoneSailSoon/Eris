using Eris.Serializer;

namespace Eris.Extension.Core.Style.Modules.Behavior;

public class BehaviorMoudle(BehaviorMoudleData data) : StyleModule<BehaviorMoudleData>(data)
{
    public BehaviorMoudle() : this(null!)
    {
        
    }
    
    public static readonly Func<BehaviorMoudleData, BehaviorMoudle> Activator = static data => new(data);
    public override int SerializeType => SerializeRegister.BehaviorMoudleType;
}