using Eris.Extension.Core.Generic;
using Eris.Utilities.Ini;
using Eris.YRSharp;
using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.Vector;
using NaegleriaSerializer.Streaming;

namespace Eris.Extension.Core.Scripts;

public abstract class TechnoScriptable : Scriptable<TechnoExt>
{
    public virtual void OnPut(Pointer<CoordStruct> pCoord, Direction dir)
    {
    }

    public virtual void OnRemove()
    {
    }

    public virtual void OnReceiveDamage(Pointer<int> pDamage, int distanceFromEpicenter, Pointer<WarheadTypeClass> pWh,
        Pointer<ObjectClass> pAttacker, bool ignoreDefenses, bool preventPassengerEscape,
        Pointer<HouseClass> pAttackingHouse)
    {
    }

    public virtual void OnFire(int weaponIndex, Pointer<AbstractClass> target)
    {
    }

    public static void OnPut(Component component, in (Pointer<CoordStruct> pCoord, Direction dir) data)
    {
        (component as TechnoScriptable)?.OnPut(data.pCoord, data.dir);
    }
    public static void OnReceiveDamage(Component component, in (Pointer<int> pDamage, int distanceFromEpicenter, Pointer<WarheadTypeClass> pWh,
        Pointer<ObjectClass> pAttacker, bool ignoreDefenses, bool preventPassengerEscape,
        Pointer<HouseClass> pAttackingHouse) data)
    {
        (component as TechnoScriptable)?.OnReceiveDamage(data.pDamage, data.distanceFromEpicenter, data.pWh, data.pAttacker, data.ignoreDefenses, data.preventPassengerEscape,data.pAttackingHouse);
    }
    public static void OnFire(Component component, in (int weaponIndex, Pointer<AbstractClass> target) data)
    {
        (component as TechnoScriptable)?.OnFire(data.weaponIndex, data.target);
    }
}

public abstract class TechnoScriptable<TData> : TechnoScriptable, IScriptConfigWrapper where TData : IniConfig
{
    private TData? _data;
    protected TData Data { get => _data!; private set => _data = value; }

    protected override void OnSerialize(INaegleriaStream stream)
    {
        base.OnSerialize(stream);
        stream.ProcessObject(ref _data);
    }

    public void Attach(IniConfig? config)
    {
        Data = (TData)config!;
    }
}