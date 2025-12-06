using Eris.BeonSerializer;
using Eris.BeonSerializer.Streaming;
using Eris.Utilities.Data;
using System.Runtime.CompilerServices;

namespace Eris.Component.Generic;

public abstract class Component : IBeonSerializable
{
    public virtual void Serialize(IBeonStream stream)
    {
        stream.Process(ref _expired);
    }

    private Component? _next;

    private bool _expired;
    public bool Expired => _expired;
    
    public abstract int SerializeType { get; }
    public ulong SerializeId { get; } = SerializeIdCreater.NewId();

    public void Expire()
    {
        OnDestroy();
        //_next = null;
        //_expired = true;
    }


    [Sync]
    public virtual void Awake()
    {
    }
    [Sync]
    public virtual void OnDestroy()
    {
    }

    [Sync]
    public virtual void OnUpdate()
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

    public abstract class ComponentRoot : Component
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected static ref Component? Next(Component component) => ref component._next;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected static ref bool IsExpired(Component component) => ref component._expired;
    }
}