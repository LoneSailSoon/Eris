using NaegleriaSerializer;
using NaegleriaSerializer.Streaming;

namespace Eris.Extension.Eris.Generic;

public abstract class Component : INaegleriaSerializable
{
    public virtual void Serialize(INaegleriaStream stream)
    {
        stream.Process(ref _expired);
    }

    private bool _expired;
    public bool Expired => _expired;
    
    
    public abstract int SerializeType { get; }
    public ulong SerializeId { get; } = SerializeIdCreater.NewId();

    public void Expire()
    {
        OnDestroy();
        _expired = true;
    }

    public virtual void Awake()
    {
    }
    public virtual void OnDestroy()
    {
        
    }
}