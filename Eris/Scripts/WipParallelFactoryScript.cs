using Eris.BeonSerializer.Streaming;
using Eris.Component.Root;
using Eris.Component.Scripts;
using Eris.Serializer;
using Eris.Utilities.Data;
using Eris.Utilities.Ini;
using Eris.YRSharp;
using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.Helpers;

namespace Eris.Scripts;

public sealed class WipParallelFactoryData : IniConfig
{
    public override int SerializeType => ScriptsRegister.WipParallelFactoryDataType;

    public override void Read(IniSection section, IIniId id)
    {
    }

    public override void Serialize(IBeonStream stream)
    {
    }
}

[Wip("还只是个玩具，可以殴打工厂进行建造")]
public sealed class WipParallelFactoryScript : TechnoScriptable<WipParallelFactoryData>
{
    private SerializableDelegate.Node<Action> _counter = DelegateFactories.Increment.Borrow();


    public override int SerializeType => ScriptsRegister.WipParallelFactoryScriptType;

    bool b;

    protected override void OnSerialize(IBeonStream stream)
    {
        base.OnSerialize(stream);
        stream.Process(ref b);
    }

    protected override void OnSave(BeonSerializeStream stream)
    {
        stream.DelegateSerialize(_counter);
    }

    protected override void OnLoad(BeonDeserializeStream stream)
    {
        stream.DelegateDeserialize(ref _counter);
    }

    public override void OnUpdate()
    {
        if (!b)
        {
            b = true;
            Console.WriteLine("WipParallelFactoryScript");
        }
    }

    public override void OnReceiveDamage(Pointer<int> pDamage, int distanceFromEpicenter, Pointer<WarheadTypeClass> pWh, Pointer<ObjectClass> pAttacker, bool ignoreDefenses, bool preventPassengerEscape, Pointer<HouseClass> pAttackingHouse)
    {
        if (pAttacker.CastToTechno(out var pTechno) &&
            Owner.OwnerObject.CastIf<BuildingClass>(AbstractType.Building, out var factory) &&
            pTechno.Ref.Type.Ref.BaseAbstractType.Base.WhatAmI() == factory.Ref.Type.Ref.Factory)
        {
            var clone = pTechno.Ref.Type.Ref.Base.CreateObject(Owner.OwnerRef.Owner).Cast<TechnoClass>();
            if (Owner.OwnerRef.Base.KickOutUnit(clone, default) != KickOutResult.Succeeded)
                clone.Ref.Base.UnInit();
            else if (_counter.Funcs is var (_, f))
                f();
        }
    }

    public override void OnDestroy()
    {
        Console.WriteLine("WipParallelFactoryScript Remove");
    }
}