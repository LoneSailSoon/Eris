using Eris.Component.Scripts;
using Eris.Entity;
using Eris.Utilities.Data;
using Eris.Utilities.Logger;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.Vector;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Eris.Behaviors.EntityBehaviors;

public static class SuperWeaponBehaviors
{
    [Hook(0x6CC390, 6)]
    [UnmanagedCallersOnly(EntryPoint = "SuperClass_Launch_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint SuperClass_Launch_Behaviors(Registers* R)
    {
        try
        {
            Pointer<SuperClass> pSuper = (nint)R->ECX;
            var pCell = R->Stack<Pointer<CellStruct>>(0x4);
            var isPlayer = R->Stack<bool>(0x8);

            var ext = SuperWeaponEntity.EntityMap.Find(pSuper);
            ext?.GameObject.ForEach((pCell.Ref, isPlayer), SuperWeaponScriptable.OnLaunch);

            return 0;
        }
        catch (Exception e)
        {
            Logger.LogException(e);
            return 0;
        }
    }
}
