using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Eris.Extension;
using Eris.Extension.Core.Scripts;
using Eris.Utilities.Logger;
using Eris.YRSharp;
using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.Vector;

namespace Eris.Behaviors;

public static class TechnoBehaviors
{
    //[Hook(0x6F9E50, 5)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoClass_Update_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoClass_Update_Behaviors(Registers* r)
    {
        try
        {
            Pointer<TechnoClass> pTechno = (nint)r->ESI;

            var ext = TechnoExt.ExtMap.Find(pTechno);

            ext?.GameObject.ForEach(o => o.OnUpdate());
        }
        catch (Exception e)
        {
            Logger.LogException(e);
        }

        return 0;
    }

    //[Hook(0x6F6CA0, 7)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoClass_Put_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoClass_Put_Behaviors(Registers* r)
    {
        try
        {
            Pointer<TechnoClass> pTechno = (nint)r->ECX;
            var pCoord = r->Stack<Pointer<CoordStruct>>(0x4);
            var faceDir = r->Stack<Direction>(0x8);
            var ext = TechnoExt.ExtMap.Find(pTechno);

            ext?.GameObject.ForEach((pCoord, faceDir), TechnoScriptable.OnPut);

        }
        catch (Exception e)
        {
            Logger.LogException(e);
        }
        return 0;
    }

    //[Hook(0x6F6AC4, 5)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoClass_Remove_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoClass_Remove_Behaviors(Registers* r)
    {
        
        try
        {
            Pointer<TechnoClass> pTechno = (nint)r->ECX;
            
            var ext = TechnoExt.ExtMap.Find(pTechno);

            if (ext is not null)
            {
                ext.GameObject.ForEach(o=>(o as TechnoScriptable)?.OnRemove());
            }

        }
        catch (Exception e)
        {
            Logger.LogException(e);
        }

        return 0;
    }

    
    //[Hook(0x6D471A, 6)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoClass_RenderLater", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoClass_RenderLater(Registers* r)
    {
        try
        {
            Pointer<TechnoClass> pTechno = (nint)r->ESI;
            var ext = TechnoExt.ExtMap.Find(pTechno);
        }
        catch (Exception e)
        {
            Logger.LogException(e);
        }
        return 0;
    }

    //[Hook(0x701900, 6)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoClass_ReceiveDamage_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoClass_ReceiveDamage_Behaviors(Registers* r)
    {
        try
        {
            Pointer<TechnoClass> pTechno = (nint)r->ECX;
            var pDamage = r->Stack<Pointer<int>>(0x4);
            var distanceFromEpicenter = r->Stack<int>(0x8);
            var pWh = r->Stack<Pointer<WarheadTypeClass>>(0xC);
            var pAttacker = r->Stack<Pointer<ObjectClass>>(0x10);
            var ignoreDefenses = r->Stack<bool>(0x14);
            var preventPassengerEscape = r->Stack<bool>(0x18);
            var pAttackingHouse = r->Stack<Pointer<HouseClass>>(0x1C);
            
            var ext = TechnoExt.ExtMap.Find(pTechno);

            ext?.GameObject.ForEach((pDamage, distanceFromEpicenter, pWH: pWh, pAttacker, ignoreDefenses, preventPassengerEscape, pAttackingHouse), TechnoScriptable.OnReceiveDamage);

        }
        catch (Exception e)
        {
            Logger.LogException(e);
        }

        return 0;
    }

    //[Hook(0x6FDD50, 6)]
    [UnmanagedCallersOnly(EntryPoint = "TechnoClass_Fire_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoClass_Fire_Behaviors(Registers* r)
    {
        
        try
        {
            Pointer<TechnoClass> pTechno = (nint)r->ECX;
            var pTarget = r->Stack<Pointer<AbstractClass>>(0x4);
            var nWeaponIndex = r->Stack<int>(0x8);
            
            var ext = TechnoExt.ExtMap.Find(pTechno);

            if (ext is not null)
            {
                ext.GameObject.ForEach((nWeaponIndex, pTarget), TechnoScriptable.OnFire);
            }

        }
        catch (Exception e)
        {
            Logger.LogException(e);
        }

        return 0;
    }

    //7077C0 7
    [UnmanagedCallersOnly(EntryPoint = "TechnoClass_PointerExpired_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TechnoClass_PointerExpired_Behaviors(Registers* r)
    {
        
        try
        {
            Pointer<TechnoClass> pTechno = (nint)r->ECX;
            var pTarget = r->Stack<Pointer<AbstractClass>>(0x4);
            
            var ext = TechnoExt.ExtMap.Find(pTechno);

            if (ext is not null)
            {
            }

        }
        catch (Exception e)
        {
            Logger.LogException(e);
        }

        return 0;
    }

}
