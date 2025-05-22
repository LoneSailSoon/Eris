using Eris.Serializer;
using Eris.Utilities.Helpers;
using Eris.YRSharp;
using NaegleriaSerializer.Streaming;

namespace Eris.Extension.Core.Style.Modules.DamageSelf;

public sealed class DamageSelfModule(DamageSelfModuleData data) : StyleModule<DamageSelfModuleData>(data)
{
    public DamageSelfModule() : this(null!)
    {
    }

    public override int SerializeType => SerializeRegister.DamageSelfModuleType;

    public static readonly Func<DamageSelfModuleData, DamageSelfModule> Activator = static data => new(data);

    public override void Serialize(INaegleriaStream stream)
    { 
        base.Serialize(stream);
        stream.Process(ref _rof);
    }


    private int _rof;

    public override void OnUpdate()
    {
        if (!Active) return;
        if (_rof <= 0)
        {
            //Style.Owner;
            //Console.WriteLine($"DamageSelfModule {Data.Test} {Data.Rof} {Game.CurrentFrame}");
            var owner = Owner;
            var house = Style?.House ?? HouseExt.ExtMap.Find(owner.OwnerRef.Owner);
            
            var health = owner.OwnerRef.Base.Health;

            var wh = Data.WarheadType.Type.AsNullable ?? RulesClass.Instance.C4Warhead;

            var realDamage = owner.OwnerObject.GetRealDamage(Data.Damage, wh);
            
            if (Data.Animation)
            {
                var anim = wh.PlayWarheadAnim(owner.OwnerRef.BaseAbstract.GetCoords(), realDamage);
                if (anim)
                    anim.Ref.Owner = house?.OwnerObject ?? 0;
            }
            
            if (Data.Peaceful)
            {
                if (realDamage >= health)
                {
                    owner.OwnerRef.Base.Remove();
                    owner.OwnerRef.Base.Health = 0;
                    owner.OwnerRef.Base.UnInit();
                }
                else
                {
                    owner.OwnerRef.Base.Health -= realDamage;
                }
            }
            else
            {
                var pDamageMaker = house?.OwnerObject.Convert<ObjectClass>() ?? 0;
                if (pDamageMaker == (nint)owner.OwnerObject)
                    pDamageMaker = 0;


                owner.OwnerRef.Base.ReceiveDamage(
                    Data.Damage,
                    0,
                    wh,
                    pDamageMaker,
                    false,
                    owner.Type.OwnerRef.Crewed,
                    house?.OwnerObject ?? 0);
            }


            // Console.WriteLine(
            //     $"DamageSelfModule: {owner.Expired} {health} -> {(owner.Expired ? 0 : owner.OwnerRef.Base.Health)}");

            _rof = Data.Rof;
        }
        else
        {
            _rof--;
        }
    }

    public override void Disable()
    {
        base.Disable();
        Console.WriteLine($"DamageSelfModule Disable");
    }
}