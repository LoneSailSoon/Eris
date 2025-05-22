using Eris.YRSharp.Helpers;
using NaegleriaSerializer.Streaming;

namespace Eris.Extension.Generic;

public abstract class InstanceExtension<TExt, TBase> : Extension<TBase> where TExt : InstanceExtension<TExt, TBase>, IExtensionActivator<TExt, TBase>
{
    public static readonly MapContainer<TExt, TBase> ExtMap = new();
    

    protected InstanceExtension(Pointer<TBase> owner) : base(owner)
    {
    }
    
    public InstanceExtension()
    {
    }

    public override void Serialize(INaegleriaStream stream)
    {
    }

    public ref TBase OwnerRef => ref OwnerObject.Ref;
}