using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.Ui;
using Microsoft.Win32;
using PatcherYrSharp;
using PatcherYrSharp.Com;
using PatcherYrSharp.Helpers;

namespace Eris.Behaviors;

public static class UiBehaviors
{
    //[Hook(0x4F4583, 6)]
    [UnmanagedCallersOnly(EntryPoint = "Ui_DrawOnTop_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 Ui_DrawOnTop_Behaviors(Registers* r)
    {
        ErisUi.OnRender();
        return 0;
    }



    //[Hook(0x54F7F1, 8)]
    [UnmanagedCallersOnly(EntryPoint = "Ui_KeyInput_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 Ui_KeyInput_Behaviors(Registers* r)
    {
        var msg = r->Stack<uint>(0x20 + 8);
        switch (msg)
        {
            case 201:
                break;
            case 0x100:
            case 0x101:
            case 0x104:
            case 0x105:

                return ErisUi.OnKeyInput(msg, r->Stack<nuint>(0x20 + 12)) ? 0x54FB3Du : 0u;
            case 0x102:
                return ErisUi.OnKeyInput(msg, r->Stack<nuint>(0x20 + 12)) ? 0x54FB3Du : 0u;
        }

        return 0;
    }

    //[Hook(0x693268, 5)]
    [UnmanagedCallersOnly(EntryPoint = "Ui_MouseLeftRelease_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 Ui_MouseLeftRelease_Behaviors(Registers* r)
    {
        if (ErisUi.OnLeftRelease())
        {
            r->Stack(0x28 + 0x8, 0u);
            r->EAX = 0u;
            return 0x693276;
        }
        return 0;
    }

    //[Hook(0x6931A5, 6)]
    [UnmanagedCallersOnly(EntryPoint = "Ui_MouseLeftPress_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 Ui_MouseLeftPress_Behaviors(Registers* r)
    {
        if (ErisUi.OnLeftPress())
        {
            r->EAX = 0u;
            return 0x6931B4;
        }
        return 0;
    }

    // [Hook(0x692F30, 5)]
    [UnmanagedCallersOnly(EntryPoint = "Ui_MouseUpdate_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 Ui_MouseUpdate_Behaviors(Registers* r)
    {
        if (ErisUi.OnUpdate())
        {
            DisplayClass.MouseClassSetCursor(0, false);
            return 0x692FB2;
        }
        return 0;
    }




    // [Hook(0x693325, 8)]
    [UnmanagedCallersOnly(EntryPoint = "Ui_MouseRightPress_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 Ui_MouseRightPress_Behaviors(Registers* r)
    {
        ErisUi.OnRightPress();
        return 0;
    }



    // [Hook(0x6933C0, 5)]
    [UnmanagedCallersOnly(EntryPoint = "Ui_MouseRightRelease_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 Ui_MouseRightRelease_Behaviors(Registers* r)
    {
        ErisUi.OnRightRelease();
        return 0;
    }


    //[Hook(0x693119, 6)]
    [UnmanagedCallersOnly(EntryPoint = "Ui_WindowProc_Behaviors", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 Ui_WindowProc_Behaviors(Registers* r)
    {
        Pointer<uint> p = r->Stack<IntPtr>(0x24 + 8);
        if (ErisUi.OnWindowProc(p.Data))
        {
            return 0x6931F1;
        }
        
        switch (p.Ref)
        {
            case 0x200:
                //Console.WriteLine("MouseClass_Messages Move");
                break;
            //case 0x20A:
            //    break;
            //case 0x201:
            //    //leftdown
            //    break;
            //case 0x202:
            //    //leftup
            //    break;
            //case 0x204:
            //    //rigthdown
            //    break;
            //case 0x205:
            //    //rigthup
            //    break;
            //return 0x6931F1;
            default:
                break;
        }
        return 0;
    }

}