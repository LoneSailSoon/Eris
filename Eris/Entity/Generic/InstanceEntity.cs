using Eris.BeonSerializer.Streaming;
using Eris.YRSharp.Helpers;

namespace Eris.Entity.Generic;

public abstract class InstanceEntity<TEntity, TBase> : Entity<TBase> where TEntity : InstanceEntity<TEntity, TBase>, IExtensionActivator<TEntity, TBase>
{
    public static readonly MapContainer<TEntity, TBase> EntityMap = new();
    

    protected InstanceEntity(Pointer<TBase> owner) : base(owner)
    {
    }
    
    public InstanceEntity()
    {
    }

    public override void Serialize(IBeonStream stream)
    {
    }

    public ref TBase OwnerRef => ref OwnerObject.Ref;
}