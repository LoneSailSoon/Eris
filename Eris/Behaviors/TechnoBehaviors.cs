﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Eris.Extension;
using Eris.Extension.Eris.Scripts;
using Eris.Extension.Eris.Style;
using Eris.Utilities.Helpers;
using PatcherYrSharp;
using PatcherYrSharp.GeneralDefinitions;
using PatcherYrSharp.GeneralStructures;
using PatcherYrSharp.Helpers;

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

            if (ext is not null)
            {
                StyleManager.Instance.OnUpdate(ext.Styles);

                ext.GameObject.ForEach(o => o.OnUpdate());
            }
        }
        catch (Exception e)
        {
            LogHelper.Log(e);
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
            TechnoExt? ext = TechnoExt.ExtMap.Find(pTechno);

            if (ext is not null)
            {
                ext.GameObject.ForEach((pCoord, faceDir), TechnoScriptable.OnPut);
            }

        }
        catch (Exception e)
        {
            LogHelper.Log(e);
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
            LogHelper.Log(e);
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
            if (ext is not null && ext.ShowVisualTree)
            {

                var pos = TacticalClass.Instance.CoordsToClient(ext.OwnerRef.BaseAbstract.GetCoords()) + (10, 10);
                
                if (Surface.ViewBound.InRect(pos))
                {

                    var sb = new StringBuilder();
                    sb.Append($"[{ext.OwnerTypeRef.BaseAbstractType.ID}]").AppendLine();
                    ext.ToTreeDisplay(sb, "");
                    var text = sb.ToString();
                    Surface.GetTextDimension(text, out var w, out var h, 300);
                    if (Surface.ViewBound.InRect(pos + (w, h)))
                    {

                        Surface.Current.Ref.FillRectEx(Surface.ViewBound, new(pos, (w, h)), 0);

                        foreach (var line in text.Split(Environment.NewLine))
                        {
                            Surface.Temp.Ref.DrawText(line, pos, Drawing.TooltipColor);
                            pos.Y += 19;
                        }
                    }

                    

                    //Console.WriteLine($"{w} : {h}");
                    //Surface.Current.Ref.BitTextDraw("ABCD", new(pos, (w, h)));
                    //Surface.Current.Ref.DrawText(sb.ToString(), pos, Drawing.TooltipColor);
                }
            }
        }
        catch (Exception e)
        {
            LogHelper.Log(e);
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
            var pWH = r->Stack<Pointer<WarheadTypeClass>>(0xC);
            var pAttacker = r->Stack<Pointer<ObjectClass>>(0x10);
            var ignoreDefenses = r->Stack<bool>(0x14);
            var preventPassengerEscape = r->Stack<bool>(0x18);
            var pAttackingHouse = r->Stack<Pointer<HouseClass>>(0x1C);
            
            var ext = TechnoExt.ExtMap.Find(pTechno);

            if (ext is not null)
            {
                ext.GameObject.ForEach((pDamage, distanceFromEpicenter, pWH, pAttacker, ignoreDefenses, preventPassengerEscape, pAttackingHouse), TechnoScriptable.OnReceiveDamage);
            }

        }
        catch (Exception e)
        {
            LogHelper.Log(e);
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
            LogHelper.Log(e);
        }

        return 0;
    }

}
