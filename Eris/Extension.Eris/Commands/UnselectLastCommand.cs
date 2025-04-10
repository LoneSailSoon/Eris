using System.Runtime.InteropServices;
using Eris.Utilities.Helpers;
using PatcherYrSharp;
using PatcherYrSharp.GeneralDefinitions;
using PatcherYrSharp.Helpers;

namespace Eris.Extension.Eris.Commands;

public static class UnselectLastCommand
{
    public static readonly GetNameFunc GetName = static pThis => new AnsiString(Name());
    public static readonly GetUINameFunc GetUiName = static pThis =>  new UniString(UiName());
    public static readonly GetUINameFunc GetUiDescription = static pThis => new UniString(UiDescription());
    public static readonly ExecuteFunc Execute = ExecuteProxy;



    public static string Name() => "UnselectLastCommand";

    public static string UiName() => "取消选择一个单位";


    public static string UiDescription() => "取消选择一个单位";


    public static void ExecuteProxy(IntPtr pThis, WwKey input)
    {
        LogHelper.Log("UnselectLastCommand", "Command");
        if (ObjectClass.CurrentObjects.Count != 0 && ObjectClass.CurrentObjects[ObjectClass.CurrentObjects.Count - 1] is {IsNotNull:true} last)
        {
            last.Ref.Deselect();
        }
    }

    public static void Register()
    {
        Pointer<Pointer<Command>> pVfptr = YRMemory.Allocate(4);

        Pointer<Command> vtable = YRMemory.Allocate(4 * 9);

        vtable.Ref.VTableDTOR = Marshal.GetFunctionPointerForDelegate(CommandBase.DTOR);
        vtable.Ref.VTableGetName = Marshal.GetFunctionPointerForDelegate(GetName);
        vtable.Ref.VTableGetUIName = Marshal.GetFunctionPointerForDelegate(GetUiName);
        vtable.Ref.VTableGetUICategory = Marshal.GetFunctionPointerForDelegate(CommandBase.GetUICategory);
        vtable.Ref.VTableGetUIDescription = Marshal.GetFunctionPointerForDelegate(GetUiDescription);
        vtable.Ref.VTablePreventCombinationOverride = Marshal.GetFunctionPointerForDelegate(CommandBase.PreventCombinationOverride);
        vtable.Ref.VTableExtraTriggerCondition = Marshal.GetFunctionPointerForDelegate(CommandBase.ExtraTriggerCondition);
        vtable.Ref.VTableCheckLoop55E020 = Marshal.GetFunctionPointerForDelegate(CommandBase.CheckLoop55E020);
        vtable.Ref.VTableExecute = Marshal.GetFunctionPointerForDelegate(Execute);

        pVfptr.Data = vtable;
        CommandClass.ABSTRACTTYPE_ARRAY.Array.AddItem(pVfptr.Convert<CommandClass>());
    }
}