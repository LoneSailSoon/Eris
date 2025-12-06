using Eris.BeonSerializer.Streaming;
using Eris.Entity;
using Eris.Utilities.Data;
using Eris.Utilities.Ini;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.Vector;

namespace Eris.Component.Scripts;

public abstract class BulletScriptable : Scriptable<BulletEntity>
{
    [Sync] 
    public virtual void OnDetonate(Pointer<CoordStruct> pCoords) { }


    public static void OnDetonate(Generic.Component component, in Pointer<CoordStruct> pCoords)
    {
        (component as BulletScriptable)?.OnDetonate(pCoords);
    }
}

public abstract class BulletScriptable<TData> : BulletScriptable, IScriptConfigWrapper where TData : IniConfig
{
    private TData? _data;
    protected TData Data { get => _data!; private set => _data = value; }

    protected override void OnSerialize(IBeonStream stream)
    {
        base.OnSerialize(stream);
        stream.ProcessObject(ref _data);
    }

    public void Attach(IniConfig? config)
    {
        Data = (TData)config!;
    }
}