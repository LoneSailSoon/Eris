using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.Extension.Core.World;
using Eris.Utilities.Ini;
using Eris.Utilities.Logger;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.Vector;

namespace Eris.Behaviors;

public static class GeneralBehaviors
{
    //[Hook(0x6875F3, 6)]
    [UnmanagedCallersOnly(EntryPoint = "Scenario_Start1_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint Scenario_Start1_Behaviors(Registers* r)
    {
        GC.Collect();
        return 0;
    }

    //[Hook(0x55AFB3, 6)]
    [UnmanagedCallersOnly(EntryPoint = "LogicClass_Update_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint LogicClass_Update_Behaviors(Registers* r)
    {
        return 0;
    }

    //[Hook(0x55B719, 5)]
    [UnmanagedCallersOnly(EntryPoint = "LogicClass_Update_Late_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint LogicClass_Update_Late_Behaviors(Registers* r)
    {
        return 0;
    }

    //[Hook(0x6851F0, 5)]
    [UnmanagedCallersOnly(EntryPoint = "Scenario_ClearClasses_Start_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint Scenario_ClearClasses_Start_Behaviors(Registers* r)
    {
        World.Clear();
        return 0;
    }

    //[Hook(0x685659, 10)]
    [UnmanagedCallersOnly(EntryPoint = "Scenario_ClearClasses_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint Scenario_ClearClasses_Behaviors(Registers* r)
    {
        
        return 0;
    }

    //DEFINE_HOOK(0x679CAF, RulesData_LoadBeforeTypeData, 5)
    [UnmanagedCallersOnly(EntryPoint = "RulesData_LoadAfterTypeData_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint RulesData_LoadAfterTypeData_Behaviors(Registers* r)
    {
        var pIni = r->Stack<Pointer<CCIniClass>>(0x4);
        var ini = IniReader.Default;
        ini.SetCurrentIni(pIni);

        World.LoadFromIni(ini);

        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x533066, Size = 6)]
    [UnmanagedCallersOnly(EntryPoint = "CommandClassCallback_Register_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint CommandClassCallback_Register_Behaviors(Registers* r)
    {
        return 0;
    }

    //DEFINE_HOOK(0x6BD68D, WinMain_PhobosRegistrations, 0x6)
    [UnmanagedCallersOnly(EntryPoint = "WinMain_Registrations_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint WinMain_Registrations_Behaviors(Registers* r)
    {
        try
        {
            
        }
        catch (Exception e)
        {
            Logger.LogException(e);
        }

        return 0;
    }
    
    //623880 5
    [UnmanagedCallersOnly(EntryPoint = "TextLabelClass_Render_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TextLabelClass_Render_Behaviors(Registers* r)
    {
        Pointer<Point2D> pos = (nint)r->EDX;
        pos.Ref += Surface.ViewBound.BottomLeft - (- Math.Max((Surface.ViewBound.Width - 800)/2, 0), 300);
        
        return 0;
    }
    
    //623AA8 7
    [UnmanagedCallersOnly(EntryPoint = "TextLabelClass_Render_Text_Back_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint TextLabelClass_Render_Text_Back_Behaviors(Registers* r)
    {
        Pointer<RectangleStruct> pRectangleStruct = r->LeaStack<nint>(0x8 + 0x30);
        Pointer<DSurface> pSurface = r->Stack<nint>(0x8 + 0x2C);
        
        if (!pRectangleStruct || !pSurface) return 0;
        
        pRectangleStruct.Ref.X -= 1;
        pRectangleStruct.Ref.Width -= 2;
        pSurface.Ref.Base.FillRectTrans(pRectangleStruct.Data, 0, 60);
        pRectangleStruct.Ref.Height = 0;
        pRectangleStruct.Ref.Width = 0;
        
        return 0;
    }
}