using Eris.BeonSerializer;
using Eris.BeonSerializer.Streaming;
using Eris.YRSharp.Helpers;

namespace Eris.Entity.Generic;

public abstract class Entity<T>(Pointer<T> owner) : IBeonSerializable
{
    public Entity() : this(nint.Zero)
    {
    }

    private Pointer<T> _ownerObject = owner;
    public Pointer<T> OwnerObject => _ownerObject;
    public bool Expired => OwnerObject.IsNull;

    public abstract void Serialize(IBeonStream stream);

    public abstract int SerializeType { get; }
    public ulong SerializeId { get; } = SerializeIdCreater.NewId();

    public void Load(Pointer<T> owner)
    {
        _ownerObject = owner;
    }

    public void Expire()
    {
        OnExpire();

        _ownerObject = nint.Zero;
    }

    protected virtual void OnExpire()
    {
    }
    
    void IBeonSerializable.OnSave(BeonSerializeStream stream) => OnSave(stream);

    void IBeonSerializable.OnLoad(BeonDeserializeStream stream) => OnLoad(stream);
    
    protected virtual void OnSave(BeonSerializeStream stream)
    {
    }

    protected virtual void OnLoad(BeonDeserializeStream stream)
    {
    }
}

public interface IExtensionActivator<TExt, TBase> where TExt : Entity<TBase>
{
    public static abstract TExt Create(Pointer<TBase> owner);
}