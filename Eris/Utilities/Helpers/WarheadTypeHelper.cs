using PatcherYrSharp;
using PatcherYrSharp.GeneralDefinitions;
using PatcherYrSharp.GeneralStructures;
using PatcherYrSharp.Helpers;

namespace Eris.Utilities.Helpers;

public static class WarheadTypeHelper
{
    public static Pointer<AnimClass> PlayWarheadAnim(this Pointer<WarheadTypeClass> wh, CoordStruct location, int damage = 1, LandType landType = LandType.Clear)
    {
        if (MapClass.Instance.TryGetCellAt(location, out var pCell))
            landType = pCell.Ref.LandType;
        
        var pAnimType = MapClass.SelectDamageAnimation(damage, wh, landType, location);
        
        return pAnimType ? YrCreater.Create<AnimClass>().Constructor(pAnimType, location) : 0;
    }

}