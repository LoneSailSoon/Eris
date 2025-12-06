using Eris.BeonSerializer.Streaming;
using Eris.Component.Generic;
using Eris.Component.Scripts;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;

namespace Eris.Entity.Generic;

public abstract class CommonInstanceEntity<TEntity, TBase, TTypeEntity, TTypeBase> : InstanceEntity<TEntity, TBase>, IGameObjectOwner<TEntity>
    where TEntity : InstanceEntity<TEntity, TBase>, IExtensionActivator<TEntity, TBase>, IGameObjectOwner<TEntity>
    where TTypeEntity : CommonTypeEntity<TTypeEntity, TTypeBase>, IExtensionActivator<TTypeEntity, TTypeBase>
    where TBase : IYRObject<TBase, TTypeBase>
{
    private TTypeEntity? TypeField;
    private GameObject? ObjectField;

    public TTypeEntity Type => TypeField!;
    
    public GameObject GameObject
    {
        get
        {
            if (ObjectField is null)
            {
                ObjectField = GameObject.Create();
                Awake();
            }
            
            return ObjectField;
        }
    }


    public ref TTypeBase OwnerTypeRef => ref Type.OwnerRef;

    protected virtual void Awake()
    {
        TypeField ??= CommonTypeEntity<TTypeEntity, TTypeBase>.EntityMap.Find(TBase.Type(OwnerObject))!;
        if (TypeField.Scripts is { } scripts)
        {
            foreach (var script in scripts)
            { 
                ScriptManager.AttachTo((this as TEntity)!, script);
            }
        }
        
    }

    protected override void OnExpire()
    {
        base.OnExpire();
        GameObject.Destroy();
    }

    public override void Serialize(IBeonStream stream)
    {
        base.Serialize(stream);
        stream.ProcessObject(ref TypeField!)
            .ProcessObject(ref ObjectField);
    }

    protected CommonInstanceEntity(Pointer<TBase> owner) : base(owner)
    {
        TypeField = null;
    }

    protected CommonInstanceEntity()
    {
        TypeField = null;
    }
}

public interface IGameObjectOwner<TEntity> where TEntity : IGameObjectOwner<TEntity> 
{
    public GameObject GameObject { get; }
}