using Eris.YRSharp.String.Ansi;
using Eris.YRSharp.Utilities;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Sequential, Size = 4)]
public struct PCXPointer
{
    private int _pointer;

    private static PCXPointer Instance = new() { _pointer = 0xAC4848 };

    private unsafe bool ForceLoadFile(string pFileName, int flag1, int flag2, int buffer = 0)
        => ((delegate* unmanaged[Thiscall]<int, int, IntPtr, IntPtr, int, int, bool>)NativeCode.FastCallTransferStation)
            (0x6B9D00, this._pointer, buffer.GetThisPointer(), new AnsiString(pFileName), flag1, flag2);


    public bool LoadFile(string fileName, int flag1 = 2, int flag2 = 0)
        => Instance.GetSurface(fileName, Pointer<BytePalette>.Zero).IsNotNull
           || ForceLoadFile(fileName, flag1, flag2);

    public unsafe Pointer<BSurface> GetSurface(string pFileName, Pointer<BytePalette> pPalette)
        => ((delegate* unmanaged[Thiscall]<int, IntPtr, IntPtr, IntPtr>)0x6BA140)(this._pointer,
            new AnsiString(pFileName), pPalette);


    public unsafe bool BlitToSurface(Pointer<RectangleStruct> boundingRect, Pointer<Surface> targetSurface,
        Pointer<BSurface> PCXSurface, int transparentColor = 0xF81F)
        => ((delegate* unmanaged[Thiscall]<int, IntPtr, IntPtr, IntPtr, ushort, bool>)0x6BA580)(this._pointer,
            boundingRect, targetSurface, PCXSurface, (ushort)transparentColor);

    public static bool BlitCameo(string fileName, Point2D pos, Pointer<Surface> targetSurface, bool center = false,
        int range = 0, int transparentColor = 0xF81F)
        => Blit(fileName, pos, targetSurface, center, range, 60, 48, default, transparentColor);

    public static bool Blit(string fileName, Point2D pos, Pointer<Surface> targetSurface, bool center = false,
        int range = 0, int width = 60, int height = 48, Point2D pcxPos = default, int transparentColor = 0xF81F)
    {

        ArgumentException.ThrowIfNullOrWhiteSpace(fileName);
        PointerNullReferenceException.ThrowIfNull(targetSurface);

        if (!fileName.EndsWith(".pcx", StringComparison.OrdinalIgnoreCase))
            fileName += ".pcx";

        if (center)
        {
            pos.X -= width / 2;
            pos.Y -= height / 2;
        }


        var safeRect = targetSurface.Ref.GetRect();
        safeRect.Width -= width + range * 2;
        safeRect.Height -= 32 + height + range * 2;
        safeRect.X += range;
        safeRect.Y += range;
        if (!safeRect.InRectLenient(pos)) return false;
        Pointer<BSurface> PCXSurface;
        if ((PCXSurface = Instance.GetSurface(fileName, Pointer<BytePalette>.Zero)).IsNull)
        {
            Instance.ForceLoadFile(fileName, 2, 0);
            if ((PCXSurface = Instance.GetSurface(fileName, Pointer<BytePalette>.Zero)).IsNull) return false;
        }

        RectangleStruct rect = (pos.X, pos.Y, width, height);



        return pcxPos == default
            ? Instance.BlitToSurface(rect.GetThisPointer(), targetSurface, PCXSurface, transparentColor)
            : BlitTest((pcxPos.X, pcxPos.Y, width, height), PCXSurface, rect, targetSurface,
                (ushort)transparentColor); // ;
    }

    public static bool BlitTest(RectangleStruct sourceRect, Pointer<BSurface> sourceSurface,
        RectangleStruct targetRect, Pointer<Surface> targetSurface, ushort transparentColors)
    {
        sourceRect = Drawing.Intersect(sourceSurface.Ref.BaseSurface.GetRect(), sourceRect);
        targetRect = Drawing.Intersect(targetSurface.Ref.GetRect(), targetRect);


        Pointer<ushort> pTarget = targetSurface.Ref.Lock(targetRect.Location);
        if (pTarget.IsNull) return false;

        Pointer<ushort> pSource = sourceSurface.Ref.BaseSurface.Lock(sourceRect.Location);
        if (pSource.IsNull)
        {
            sourceSurface.Ref.BaseSurface.Unlock();
            return false;
        }

        var targetPitch = targetSurface.Ref.GetPitch() / 2;
        var sourcePitch = sourceSurface.Ref.BaseSurface.GetPitch() / 2;

        var height = Math.Min(targetRect.Height, sourceRect.Height);
        var width = Math.Min(targetRect.Width, sourceRect.Width);
        do
        {
            var w = width;
            var pt = pTarget;
            var ps = pSource;
            do
            {
                if (ps.Ref != transparentColors)
                    pt.Ref = ps.Data;
                pt += 1;
                ps += 1;
                w--;
            } while (w > 0);

            pTarget += targetPitch;
            pSource += sourcePitch;
            height--;
        } while (height > 0);

        targetSurface.Ref.Unlock();
        sourceSurface.Ref.BaseSurface.Unlock();

        return true;
    }
}