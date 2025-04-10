using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.Extension.Eris.Commands;
using Eris.Extension.Eris.Style;
using Eris.Ui.NaegleriaUi;
using Eris.Utilities.Ini;
using Microsoft.Win32;
using PatcherYrSharp;
using PatcherYrSharp.Helpers;

namespace Eris.Behaviors;

public static class GeneralBehaviors
{
    //[Hook(0x6875F3, 6)]
    [UnmanagedCallersOnly(EntryPoint = "Scenario_Start1_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 Scenario_Start1_Behaviors(Registers* r)
    {
        return 0;
    }

    //[Hook(0x55AFB3, 6)]
    [UnmanagedCallersOnly(EntryPoint = "LogicClass_Update_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 LogicClass_Update_Behaviors(Registers* r)
    {
        NaegleriaUiMissionManager.Running();
        return 0;
    }

    //[Hook(0x55B719, 5)]
    [UnmanagedCallersOnly(EntryPoint = "LogicClass_Update_Late_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 LogicClass_Update_Late_Behaviors(Registers* r)
    {
        return 0;
    }
    
    //[Hook(0x685659, 10)]
    [UnmanagedCallersOnly(EntryPoint = "Scenario_ClearClasses_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 Scenario_ClearClasses_Behaviors(Registers* r)
    {
        StyleType.ExtMap.Clear();

        return 0;
    }

    //DEFINE_HOOK(0x679CAF, RulesData_LoadBeforeTypeData, 5)
    [UnmanagedCallersOnly(EntryPoint = "RulesData_LoadAfterTypeData", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 RulesData_LoadAfterTypeData(Registers* r)
    {
        var pIni = r->Stack<Pointer<CCINIClass>>(0x4);

        var ini = IniReader.Default;
        ini.SetCurrentIni(pIni);

        StyleType.ExtMap.LoadFromIni(ini);
        
        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x533066, Size = 6)]
    [UnmanagedCallersOnly(EntryPoint = "CommandClassCallback_Register", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 CommandClassCallback_Register(Registers* R)
    {
        Command.Register();
        return 0;
    }
}