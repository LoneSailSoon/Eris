using Eris.YRSharp;
using Eris.YRSharp.Helpers;

namespace Eris.Utilities.Helpers;

public static class TechnoTypeHelper
{
    public static int GetRealDamage(this Pointer<TechnoClass> pTechno, int damage, Pointer<WarheadTypeClass> pWh, bool ignoreArmor = true, int distance = 0)
    {
        return pTechno.Convert<ObjectClass>().GetRealDamage(damage, pWh, ignoreArmor, distance);
    }

    public static int GetRealDamage(this Pointer<ObjectClass> pObject, int damage, Pointer<WarheadTypeClass> pWh, bool ignoreArmor = true, int distance = 0)
    {
        var realDamage = damage;
        if (!ignoreArmor)
        {
            // 计算实际伤害
            if (realDamage > 0)
            {
                realDamage = MapClass.GetTotalDamage(damage, pWh, pObject.Ref.GetObjectType().Ref.Armor, distance);
            }
            else
            {
                realDamage = -MapClass.GetTotalDamage(-damage, pWh, pObject.Ref.GetObjectType().Ref.Armor, distance);
            }
        }
        return realDamage;
    }

}