using System.Runtime.InteropServices;
using Eris.Utilities.Logger;
using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.String.Uni;

namespace Eris.Extension.Core.Commands
{
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void DTORFunc(nint pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate nint GetNameFunc(nint pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate nint GetUINameFunc(nint pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate bool CheckInputFunc(nint pThis, WwKey input);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void ExecuteFunc(nint pThis, WwKey input);

    public static class CommandBase
    {
        public static readonly GetUINameFunc GetUICategory = static pThis => new UniString(UICategory());
        public static readonly DTORFunc DTOR = DTORProxy;
        public static readonly CheckInputFunc PreventCombinationOverride = PreventCombinationOverrideProxy;
        public static readonly CheckInputFunc ExtraTriggerCondition = ExtraTriggerConditionProxy;
        public static readonly CheckInputFunc CheckLoop55E020 = CheckLoop55E020Proxy;


        public static string UICategory() => "Eris";
        public static void DTORProxy(nint pThis) { }

        public static bool PreventCombinationOverrideProxy(nint pThis, WwKey input) => false;


        public static bool ExtraTriggerConditionProxy(nint pThis, WwKey input) => !Convert.ToBoolean(input & WwKey.Release);

        public static bool CheckLoop55E020Proxy(nint pThis, WwKey input) => false;


    }


    [StructLayout(LayoutKind.Sequential, Size = 36)]
    public struct Command
    {

        public nint VTableDTOR;
        public nint VTableGetName;
        public nint VTableGetUIName;
        public nint VTableGetUICategory;
        public nint VTableGetUIDescription;
        public nint VTablePreventCombinationOverride;
        public nint VTableExtraTriggerCondition;
        public nint VTableCheckLoop55E020;
        public nint VTableExecute;

        public static void Register()
        {
            try
            {
                ShowVisualTreeCommand.Register();
                UnselectLastCommand.Register();
                LoadIntoTransportsCommand.Register();
                //LogHelper.Log(
                //    """
                //    ShowVisualTreeCommand
                //    """, "RegisterCommands");
            }
            catch (Exception e)
            {

                Logger.LogException(e);
            }
        
        }
    }
}


