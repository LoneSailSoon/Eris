using Eris.YRSharp;
using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.Vector;

namespace Eris.Utilities.Helpers;

public static class WarheadTypeHelper
{
    public static Pointer<AnimClass> PlayWarheadAnim(this Pointer<WarheadTypeClass> wh, CoordStruct location, int damage = 1, LandType landType = LandType.Clear)
    {
        if (MapClass.Instance.TryGetCellAt(location, out var pCell))
            landType = pCell.Ref.LandType;
        
        var pAnimType = MapClass.SelectDamageAnimation(damage, wh, landType, location);
        
        return pAnimType ? YRCreater.Create<AnimClass>().Constructor(pAnimType, location) : 0;
    }

}