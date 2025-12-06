using Eris.BeonSerializer.Streaming;
using Eris.Entity;
using Eris.Utilities.Data;
using Eris.Utilities.Ini;
using Eris.YRSharp.Vector;

namespace Eris.Component.Scripts;

public abstract class SuperWeaponScriptable : Scriptable<SuperWeaponEntity>
{
    [Sync]
    public virtual void OnLaunch(CellStruct cell, bool isPlayer) { }

    public static void OnLaunch(Generic.Component component, in (CellStruct cell, bool isPlayer) arg)
    {
        (component as SuperWeaponScriptable)?.OnLaunch(arg.cell, arg.isPlayer);
    }
}

public abstract class SuperWeaponScriptable<TData> : SuperWeaponScriptable, IScriptConfigWrapper where TData : IniConfig
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
