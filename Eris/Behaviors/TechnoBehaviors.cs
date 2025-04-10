using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Eris.Extension;
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
                StyleManager.Instance.OnUpdate(ext.Token, ext.Styles);
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

}
