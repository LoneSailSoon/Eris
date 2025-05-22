using System.Drawing;
using System.Drawing.Imaging;
using CommonRenderUi;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.Vector;
using NaegleriaUi;
using NaegleriaUi.Interface;

#pragma warning disable CA1416 // 验证平台兼容性


namespace Eris.Ui.NaegleriaUi;

public static class NaegleriaUiForm
{
    static NaegleriaUiForm()
    {
        Form = new();
        Form.View.Items.Add(new("阋神星运行中…", Color.FromArgb(200, 200, 200)));
        Form.MissionEvent += OnMissionEvent;
        //Form.MissionEvent += NaegleriaUiEvent.OnMissionEvent;
    }

    public static readonly CommonRenderForm Form;

    public static void Render(Pointer<Surface> surface)
    {
        Form.Render.Render(Form, Form.Graphics);

        surface.Ref.FillRectEx(Surface.ViewBound,
            new(Form.Rectangle.X, Form.Rectangle.Y, Form.Rectangle.Width, Form.Rectangle.Height), (0, 0, 0));

        var drawRect = Drawing.Intersect(Surface.ViewBound,
            new(Form.Rectangle.X, Form.Rectangle.Y, Form.Rectangle.Width, Form.Rectangle.Height));
        var formDrawRect = new Rectangle(drawRect.X - Form.Location.X, drawRect.Y - Form.Location.Y,
            drawRect.Width, drawRect.Height);

        var data = Form.Graphics.Image.LockBits(formDrawRect, ImageLockMode.ReadOnly, PixelFormat.Format16bppRgb565);

        var pTarget = surface.Ref.Lock(drawRect.X, drawRect.Y);
        var pSource = data.Scan0;
        for (var i = 0; i < drawRect.Height; i++)
        {
            unsafe
            {
                Buffer.MemoryCopy(pSource.ToPointer(), pTarget.ToPointer(), drawRect.Width * 2, drawRect.Width * 2);
            }

            pSource += data.Stride;
            pTarget += surface.Ref.GetPitch();
        }

        surface.Ref.Unlock();

        Form.Graphics.Image.UnlockBits(data);

        //Console.WriteLine(WWMouseClass.Instance.GetCoords());
        //Console.WriteLine(Form.MouseDragHandle.GlobalCurrent);
        if (Form.PreviewSize != default)
        {
            var previewRect = new RectangleStruct(Form.Location.X, Form.Location.Y, Form.PreviewSize.Width,
                Form.PreviewSize.Height);
            surface.Ref.FillRectTrans(previewRect,
                (100, 100, 100),
                50);
            surface.Ref.DrawRectEx(Surface.ViewBound,
                previewRect,
                (100, 100, 100));
        }

        //if (Form.MouseDragHandle.Active)
        //{
        //    surface.Ref.DrawLine(Point2Point2D(Form.MouseDragHandle.GlobalStart),
        //        Point2Point2D(Form.MouseDragHandle.GlobalCurrent), (225, 0, 225));
        //}
    }

    public static bool ProcessMouseButtonEvent(Mouse botton, Point2D mousePos, bool isDouble, bool down)
    {
        Point pos = new(mousePos.X, mousePos.Y);
        return Form.InputManager.ProcessMouseButtonEvent(Form, (NaegleriaMouse)botton, pos, isDouble, down);
    }

    public static bool ProcessMouseMoveEvent(Point2D mousePos)
    {
        Point pos = new(mousePos.X, mousePos.Y);
        return Form.InputManager.ProcessMouseMoveEvent(Form, pos);
    }

    public static bool IsMouseHoving(Point2D point)
    {
        return Form.MouseHoving || Form.MouseDragHandle.Active;
    }

    public static bool DumpKey(nuint input)
    {
        //Console.WriteLine((User32.Vk)input);

        return !Form.Trim || (User32.Vk)input == User32.Vk.Oem3;
    }

    public static bool DumpChar(nuint input)
    {
        //Console.WriteLine($"{Convert.ToString((int)input, 2)} {(char)input}");
        Form.InputManager.ProcessCharEvent(Form, (char)input);
        return true;
    }

    public static Point Point2D2Point(Point2D point) => new(point.X, point.Y);

    public static Point2D Point2Point2D(Point point) => new(point.X, point.Y);

    public enum Mouse
    {
        None,
        Left,
        Right,
        Middle,
        XBotton1,
        XBotton2
    }
    
    
    public static void OnMissionEvent(object? sender, CommonRenderForm.MissionEventArgs e)
    {
        e.Result = NaegleriaUiMissionManager.AddMission(e.Mission);
    }
}