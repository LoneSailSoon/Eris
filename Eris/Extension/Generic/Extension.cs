using NaegleriaSerializer;
using NaegleriaSerializer.Streaming;
using PatcherYrSharp.Helpers;

namespace Eris.Extension.Generic;

public abstract class Extension<T>(Pointer<T> owner) : INaegleriaSerializable
{
    public Extension() : this(nint.Zero)
    {
    }

    private Pointer<T> _ownerObject = owner;
    public Pointer<T> OwnerObject => _ownerObject;
    public bool Expired => OwnerObject.IsNull;

    public abstract void Serialize(INaegleriaStream stream);

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
    
    void INaegleriaSerializable.OnSave(NaegleriaSerializeStream stream) => OnSave(stream);

    void INaegleriaSerializable.OnLoad(NaegleriaDeserializeStream stream) => OnLoad(stream);
    
    protected virtual void OnSave(NaegleriaSerializeStream stream)
    {
    }

    protected virtual void OnLoad(NaegleriaDeserializeStream stream)
    {
    }
}

public interface IExtensionActivator<TExt, TBase> where TExt : Extension<TBase>
{
    public static abstract TExt Create(Pointer<TBase> owner);
}