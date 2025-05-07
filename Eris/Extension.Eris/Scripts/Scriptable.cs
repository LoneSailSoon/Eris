using Eris.Extension.Eris.Generic;
using Eris.Extension.Generic;
using Eris.Utilities.Ini;
using NaegleriaSerializer;
using NaegleriaSerializer.Streaming;

namespace Eris.Extension.Eris.Scripts;

public abstract class Scriptable<TExt> : Component, IScriptable<TExt>
    where TExt : IGameObjectOwner<TExt>, INaegleriaSerializable
{
    private TExt? _owner;

    public TExt Owner => _owner!;
    
    void IScriptable<TExt>.AttachTo(TExt owner)
    {
        _owner = owner;
    }

    public sealed override void Serialize(INaegleriaStream stream)
    {
        base.Serialize(stream);
        stream.ProcessObject(ref _owner);
        OnSerialize(stream);
    }

    protected virtual void OnSerialize(INaegleriaStream stream)
    {

    }
}

public interface IScriptConfigWrapper
{
    public void Attach(IniConfig? config);
}
