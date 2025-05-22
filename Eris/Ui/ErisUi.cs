using Eris.Ui.NaegleriaUi;
using Eris.Ui.TechnoGirdUi;
using Eris.YRSharp;

namespace Eris.Ui;

public static class ErisUi
{
    public static void OnRender()
    {
        NaegleriaUiForm.Render(Surface.Current);
        TechnoGird.Render(Surface.Current);
    }

    public static bool OnKeyInput(uint msg, nuint input)
    {
        if (msg == 0x102)
        {
            return NaegleriaUiForm.DumpChar(input);
        }
        else
        {
            return NaegleriaUiForm.DumpKey(input);
        }
    }

    public static bool OnLeftRelease()
    {
        //Console.WriteLine($"OnLeftRelease");

        var position = WWMouseClass.Instance.GetCoords();
        if (Surface.ViewBound.InRect(position))
        {
            if (NaegleriaUiForm.ProcessMouseButtonEvent(NaegleriaUiForm.Mouse.Left,
                    position, false, false))
            {
                return true;
            }
            else
            {
                //TechnoGird.ProcessMouseButtonEvent(true, position, false, false);
            }
        }
        return false;
    }

    public static bool OnLeftPress()
    {
        //Console.WriteLine($"OnLeftPress");

        var position = WWMouseClass.Instance.GetCoords();
        if (Surface.ViewBound.InRect(position))
        {
            if (NaegleriaUiForm.ProcessMouseButtonEvent(NaegleriaUiForm.Mouse.Left,
                    position, false, true))
            {
                return true;
            }
            else
            {
                //TechnoGird.ProcessMouseButtonEvent(true, position, false, true);
            }
        }
        return false;
    }

    public static bool OnUpdate()
    {
        var position = WWMouseClass.Instance.GetCoords();
        if (Surface.ViewBound.InRect(position))
        {
            if (NaegleriaUiForm.ProcessMouseMoveEvent(position)
                ||
                NaegleriaUiForm.IsMouseHoving(position))
            {
                return true;
            }
            else if (TechnoGird.Update(position))
            {
                return true;
            }
        }

        return false;
    }

    public static void OnRightRelease()
    {
        //Console.WriteLine($"OnRightRelease");
        //TechnoGird.ProcessMouseButtonEvent(false, default, false, false);
    }

    public static void OnRightPress()
    {
        //Console.WriteLine($"OnRightPress");
        //TechnoGird.ProcessMouseButtonEvent(false, default, false, true);
    }

    public static bool OnWindowProc(uint msg)
    {
        switch (msg)
        {
            case 0x201:
                //leftdown
                return TechnoGird.ProcessMouseButtonEvent(true, default, false, true);
            case 0x202:
                //leftup
                return TechnoGird.ProcessMouseButtonEvent(true, default, false, false);
            case 0x204:
                //rigthdown
                return TechnoGird.ProcessMouseButtonEvent(false, default, false, true);
            case 0x205:
                //rigthup
                return TechnoGird.ProcessMouseButtonEvent(false, default, false, false);
            default:
                return false;
        }

    }
}