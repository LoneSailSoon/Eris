using Eris.BeonSerializer;
using Eris.BeonSerializer.Streaming;
using Eris.Entity.Generic;
using Eris.Utilities.Ini;

namespace Eris.Component.Scripts;

public abstract class Scriptable<TExt> : Generic.Component, IScriptable<TExt>
    where TExt : IGameObjectOwner<TExt>, IBeonSerializable
{
    private TExt? _owner;

    public TExt Owner => _owner!;
    
    void IScriptable<TExt>.AttachTo(TExt owner)
    {
        _owner = owner;
    }

    public sealed override void Serialize(IBeonStream stream)
    {
        base.Serialize(stream);
        stream.ProcessObject(ref _owner);
        OnSerialize(stream);
    }

    protected virtual void OnSerialize(IBeonStream stream)
    {

    }

    public void Remove()
    {
        Owner.GameObject.RemoveComponent(this);
    }
}

public interface IScriptConfigWrapper
{
    public void Attach(IniConfig? config);
}
