using System.Text;
using Eris.Extension.Core.Style.State.DestroySelf;
using Eris.Serializer;
using Eris.Utilities.Logger;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;
using NaegleriaSerializer;
using NaegleriaSerializer.Streaming;

namespace Eris.Extension.Core.Style;

public class StyleStateManager : INaegleriaSerializable
{
    public void Serialize(INaegleriaStream stream)
    {
        stream.ProcessObject(ref DestroySelfState);
    }

    public int SerializeType => SerializeRegister.StyleStateModuleType;
    public ulong SerializeId { get; } = SerializeIdCreater.NewId();

    
    public DestroySelfState? DestroySelfState;

    public void OnUpdate()
    {
        DestroySelfState?.GetStateModule()?.OnUpdate();
    }

    public void Destroy()
    {
        DestroySelfState?.ForcePop();
    }

    public void OnReceiveDamage(TechnoExt owner, int distanceFromEpicenter, Pointer<WarheadTypeClass> pWh, Pointer<ObjectClass> pAttacker, Pointer<HouseClass> pAttackingHouse)
    {
        var warheadExt = WarheadTypeExt.ExtMap.Find(pWh);
        if (warheadExt is not { StyleEnable: true }) return;
        
        var attackingHouseExt = pAttackingHouse.IsNotNull ? HouseExt.ExtMap.Find(pAttackingHouse) : null;
        
        if (pAttackingHouse.IsNotNull && pAttackingHouse.Ref.IsAlliedWith(owner.OwnerRef.Owner.Ref.ArrayIndex))
        {
            if (!pWh.Ref.AffectsAllies)
                return;
        }
        else
        {
            if (!warheadExt.AffectsEnemies)
                return;
        }

        if (!warheadExt.AllowZeroDamage &&
            MapClass.GetTotalDamage(10000, pWh, owner.OwnerTypeRef.Base.Armor, distanceFromEpicenter) == 0) return;
        
        if (warheadExt.SelectedBy is not { } styleType) return;
        
        foreach (var type in styleType)
        {
            StyleManager.Instance.TryCreate(owner, owner.Styles, type, attackingHouseExt, warheadExt, pAttacker);
        }
    }

    public void ToTreeDisplay(StringBuilder sb, string linePrefix)
    {
        sb.AppendTreeLeafLast(linePrefix, "DestroySelfState");
        StyleStateModule.ToTreeDisplay(DestroySelfState, sb, TreeDisplayHelper.GetNextPrefixLast(linePrefix));
    }
}