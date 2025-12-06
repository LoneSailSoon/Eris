using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.YRSharp.Helpers;

namespace Eris.Behaviors;

public static class UiBehaviors
{
    //[Hook(0x4F4583, 6)]
    [UnmanagedCallersOnly(EntryPoint = "Ui_DrawOnTop_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint Ui_DrawOnTop_Behaviors(Registers* r)
    {
        return 0;
    }

    //[Hook(0x54F7F1, 8)]
    [UnmanagedCallersOnly(EntryPoint = "Ui_KeyInput_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint Ui_KeyInput_Behaviors(Registers* r)
    {
        return 0;
    }

    //[Hook(0x693268, 5)]
    [UnmanagedCallersOnly(EntryPoint = "Ui_MouseLeftRelease_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint Ui_MouseLeftRelease_Behaviors(Registers* r)
    {
        return 0;
    }

    //[Hook(0x6931A5, 6)]
    [UnmanagedCallersOnly(EntryPoint = "Ui_MouseLeftPress_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint Ui_MouseLeftPress_Behaviors(Registers* r)
    {
        return 0;
    }

    // [Hook(0x692F30, 5)]
    [UnmanagedCallersOnly(EntryPoint = "Ui_MouseUpdate_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint Ui_MouseUpdate_Behaviors(Registers* r)
    {
        return 0;
    }

    // [Hook(0x693325, 8)]
    [UnmanagedCallersOnly(EntryPoint = "Ui_MouseRightPress_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint Ui_MouseRightPress_Behaviors(Registers* r)
    {
        return 0;
    }



    // [Hook(0x6933C0, 5)]
    [UnmanagedCallersOnly(EntryPoint = "Ui_MouseRightRelease_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint Ui_MouseRightRelease_Behaviors(Registers* r)
    {
        return 0;
    }

    //[Hook(0x693119, 6)]
    [UnmanagedCallersOnly(EntryPoint = "Ui_WindowProc_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint Ui_WindowProc_Behaviors(Registers* r)
    {
        return 0;
    }
}