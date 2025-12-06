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

public static class BulletBehaviors
{
    [Hook(0x4666F7, 6)]
    [UnmanagedCallersOnly(EntryPoint = "BulletClass_Update_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint BulletClass_Update_Behaviors(Registers* R)
    {
        try
        {
            Pointer<BulletClass> pBullet = (nint)R->EBP;

            var ext = BulletEntity.EntityMap.Find(pBullet);
            ext?.GameObject.ForEach(c => c.OnUpdate());

            return 0;
        }
        catch (Exception e)
        {
            Logger.LogException(e);
            return 0;
        }
    }

    [Hook(0x4690B0, 6)]
    [UnmanagedCallersOnly(EntryPoint = "BulletClass_Detonate_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint BulletClass_Detonate_Behaviors(Registers* R)
    {
        try
        {
            Pointer<BulletClass> pBullet = (nint)R->ECX;
            Pointer<CoordStruct> pCoords = R->Stack<nint>(0x4);

            var ext = BulletEntity.EntityMap.Find(pBullet);
            ext?.GameObject.ForEach(pCoords, BulletScriptable.OnDetonate);

            return 0;
        }
        catch (Exception e)
        {
            Logger.LogException(e);
            return 0;
        }
    }
}