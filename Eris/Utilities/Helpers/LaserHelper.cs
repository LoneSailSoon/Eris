using System.Numerics;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.MathEx;
using Eris.YRSharp.Vector;

namespace Eris.Utilities.Helpers
{
    public static class LaserHelpers
    {
        private static Pointer<LaserDrawClass> DrawLine(this CoordStruct sourcePos, CoordStruct targetPos, ColorStruct innerColor, ColorStruct outerColor = default, int thickness = 2, int duration = 15, ColorStruct houseColor = default)
        {
            if (default != houseColor)
            {
                innerColor = houseColor;
                outerColor = default;
            }
            return YRCreater
                .Create<LaserDrawClass>()
                .Constructor(sourcePos, targetPos, innerColor, outerColor, default, duration)
                .SetThickness(thickness);
        }

        public static void DrawLine(this Vector3 sourcePos, Vector3 targetPos, ColorStruct innerColor, ColorStruct outerColor = default, int thickness = 2, int duration = 15, ColorStruct houseColor = default)
            => DrawLine(sourcePos.ToCoordStruct(), targetPos.ToCoordStruct(), innerColor, outerColor, thickness, duration, houseColor);

        public static void DrawLine(this BulletVelocity sourcePos, BulletVelocity targetPos, ColorStruct innerColor, ColorStruct outerColor = default, int thickness = 2, int duration = 15, ColorStruct houseColor = default)
            => DrawLine(sourcePos.ToCoordStruct(), targetPos.ToCoordStruct(), innerColor, outerColor, thickness, duration, houseColor);

        public static Pointer<LaserDrawClass> SetInnerColor(this Pointer<LaserDrawClass> pLaser, byte? r = null, byte? g = null, byte? b = null)
        {
            pLaser.Ref.InnerColor.R = r ?? pLaser.Ref.InnerColor.R;
            pLaser.Ref.InnerColor.G = g ?? pLaser.Ref.InnerColor.G;
            pLaser.Ref.InnerColor.B = b ?? pLaser.Ref.InnerColor.B;

            return pLaser;
        }

        public static Pointer<LaserDrawClass> SetOuterColor(this Pointer<LaserDrawClass> pLaser, byte? r = null, byte? g = null, byte? b = null)
        {
            pLaser.Ref.OuterColor.R = r ?? pLaser.Ref.OuterColor.R;
            pLaser.Ref.OuterColor.G = g ?? pLaser.Ref.OuterColor.G;
            pLaser.Ref.OuterColor.B = b ?? pLaser.Ref.OuterColor.B;

            return pLaser;
        }

        public static Pointer<LaserDrawClass> SetOuterSpread(this Pointer<LaserDrawClass> pLaser, byte? r = null, byte? g = null, byte? b = null)
        {
            pLaser.Ref.OuterSpread.R = r ?? pLaser.Ref.OuterSpread.R;
            pLaser.Ref.OuterSpread.G = g ?? pLaser.Ref.OuterSpread.G;
            pLaser.Ref.OuterSpread.B = b ?? pLaser.Ref.OuterSpread.B;

            return pLaser;
        }

        public static Pointer<LaserDrawClass> SetInnerColor(this Pointer<LaserDrawClass> pLaser, ColorStruct color)
        {
            pLaser.Ref.InnerColor = color;

            return pLaser;
        }

        public static Pointer<LaserDrawClass> SetOuterColor(this Pointer<LaserDrawClass> pLaser, ColorStruct color)
        {
            pLaser.Ref.OuterColor = color;

            return pLaser;
        }

        public static Pointer<LaserDrawClass> SetOuterSpread(this Pointer<LaserDrawClass> pLaser, ColorStruct color)
        {
            pLaser.Ref.OuterSpread = color;

            return pLaser;
        }

        public static Pointer<LaserDrawClass> SetSource(this Pointer<LaserDrawClass> pLaser, int? x = null, int? y = null, int? z = null)
        {
            pLaser.Ref.Source.X = x ?? pLaser.Ref.Source.X;
            pLaser.Ref.Source.Y = y ?? pLaser.Ref.Source.Y;
            pLaser.Ref.Source.Z = z ?? pLaser.Ref.Source.Z;
            return pLaser;
        }

        public static Pointer<LaserDrawClass> SetTarget(this Pointer<LaserDrawClass> pLaser, int? x = null, int? y = null, int? z = null)
        {
            pLaser.Ref.Target.X = x ?? pLaser.Ref.Target.X;
            pLaser.Ref.Target.Y = y ?? pLaser.Ref.Target.Y;
            pLaser.Ref.Target.Z = z ?? pLaser.Ref.Target.Z;
            return pLaser;
        }

        public static Pointer<LaserDrawClass> OffsetSource(this Pointer<LaserDrawClass> pLaser, int? x = null, int? y = null, int? z = null)
        {
            pLaser.Ref.Source.X += x ?? 0;
            pLaser.Ref.Source.Y += y ?? 0;
            pLaser.Ref.Source.Z += z ?? 0;
            return pLaser;
        }

        public static Pointer<LaserDrawClass> OffsetTarget(this Pointer<LaserDrawClass> pLaser, int? x = null, int? y = null, int? z = null)
        {
            pLaser.Ref.Target.X += x ?? 0;
            pLaser.Ref.Target.Y += y ?? 0;
            pLaser.Ref.Target.Z += z ?? 0;
            return pLaser;
        }

        public static Pointer<LaserDrawClass> SetSource(this Pointer<LaserDrawClass> pLaser, CoordStruct pos)
        {
            pLaser.Ref.Source = pos;
            return pLaser;
        }

        public static Pointer<LaserDrawClass> SetTarget(this Pointer<LaserDrawClass> pLaser, CoordStruct pos)
        {
            pLaser.Ref.Target = pos;
            return pLaser;
        }

        public static Pointer<LaserDrawClass> OffsetSource(this Pointer<LaserDrawClass> pLaser, CoordStruct pos)
        {
            pLaser.Ref.Source += pos;
            return pLaser;
        }

        public static Pointer<LaserDrawClass> OffsetTarget(this Pointer<LaserDrawClass> pLaser, CoordStruct pos)
        {
            pLaser.Ref.Target += pos;
            return pLaser;
        }

        public static Pointer<LaserDrawClass> SetIntensity(this Pointer<LaserDrawClass> pLaser, float start, float end)
        {
            pLaser.Ref.StartIntensity = start;
            pLaser.Ref.EndIntensity = end;
            return pLaser;
        }

        public static Pointer<LaserDrawClass> SetStartIntensity(this Pointer<LaserDrawClass> pLaser, float start)
        {
            pLaser.Ref.StartIntensity = start;
            return pLaser;
        }

        public static Pointer<LaserDrawClass> SetEndIntensity(this Pointer<LaserDrawClass> pLaser, float end)
        {
            pLaser.Ref.EndIntensity = end;
            return pLaser;
        }

        public static Pointer<LaserDrawClass> SetThickness(this Pointer<LaserDrawClass> pLaser, int thickness)
        {
            if (thickness >= 2)
            {
                pLaser.Ref.IsHouseColor = true;
                pLaser.Ref.Thickness = thickness;
            }
            return pLaser;
        }
        public static Pointer<LaserDrawClass> SingleLine( CoordStruct source, CoordStruct target, ColorStruct color, int thickness = 1, int duration = 1)
            => DrawLine(source, target, color, default, thickness, duration);

        public static Pointer<LaserDrawClass> RedLine( CoordStruct source, CoordStruct target, int thickness = 1, int duration = 1)
            => DrawLine(source, target, new ColorStruct(255, 0, 0), default, thickness, duration);

        public static Pointer<LaserDrawClass> RedLineZ( CoordStruct source, int lenth, int thickness = 1, int duration = 1)
            => RedLine(source, source + new CoordStruct(0, 0, lenth), thickness, duration);

        public static Pointer<LaserDrawClass> GreenLine( CoordStruct source, CoordStruct target, int thickness = 1, int duration = 1)
            => DrawLine(source, target, new ColorStruct(0, 255, 0), default, thickness, duration);

        public static Pointer<LaserDrawClass> GreenLineZ( CoordStruct source, int lenth, int thickness = 1, int duration = 1)
            => GreenLine(source, source + new CoordStruct(0, 0, lenth), thickness, duration);
        public static Pointer<LaserDrawClass> BlueLine( CoordStruct source, CoordStruct target, int thickness = 1, int duration = 1)
            => DrawLine(source, target, new ColorStruct(0, 0, 255), default, thickness, duration);

        public static Pointer<LaserDrawClass> BlueLineZ( CoordStruct source, int lenth, int thickness = 1, int duration = 1)
            => BlueLine(source, source + new CoordStruct(0, 0, lenth), thickness, duration);

        public static void MapCell(CoordStruct sourcePos, ColorStruct lineColor, ColorStruct outerColor = default, int thickness = 1, int duration = 1)
        {
            if (MapClass.Instance.TryGetCellAt(sourcePos, out Pointer<CellClass> pCell))
            {
                CoordStruct cellPos = pCell.Ref.GetCoordsWithBridge();
                Cell(cellPos, 128, lineColor, outerColor, thickness, duration);
            }
        }

        public static void Cell(CoordStruct sourcePos, int length, ColorStruct lineColor, ColorStruct outerColor = default, int thickness = 1, int duration = 1)
        {
            CoordStruct p1 = sourcePos + new CoordStruct(length, length, 0);
            CoordStruct p2 = sourcePos + new CoordStruct(-length, length, 0);
            CoordStruct p3 = sourcePos + new CoordStruct(-length, -length, 0);
            CoordStruct p4 = sourcePos + new CoordStruct(length, -length, 0);
            DrawLine(p1, p2, lineColor, outerColor, thickness, duration);
            DrawLine(p2, p3, lineColor, outerColor, thickness, duration);
            DrawLine(p3, p4, lineColor, outerColor, thickness, duration);
            DrawLine(p4, p1, lineColor, outerColor, thickness, duration);
        }

        public static void Crosshair(CoordStruct sourcePos, int length, ColorStruct lineColor, ColorStruct outerColor = default, int thickness = 1, int duration = 1)
        {
            DrawLine(sourcePos, sourcePos + new CoordStruct(length, 0, 0), lineColor, outerColor, thickness, duration);
            DrawLine(sourcePos, sourcePos + new CoordStruct(-length, 0, 0), lineColor, outerColor, thickness, duration);
            DrawLine(sourcePos, sourcePos + new CoordStruct(0, -length, 0), lineColor, outerColor, thickness, duration);
            DrawLine(sourcePos, sourcePos + new CoordStruct(0, length, 0), lineColor, outerColor, thickness, duration);
        }

        public static void RedCell(CoordStruct sourcePos, int thickness = 1, int duration = 1)
            => MapCell(sourcePos, new ColorStruct(255, 0, 0), default, thickness, duration);

        public static void GreenCell(CoordStruct sourcePos, int thickness = 1, int duration = 1)
            => MapCell(sourcePos, new ColorStruct(0, 255, 0), default, thickness, duration);

        public static void BlueCell(CoordStruct sourcePos, int thickness = 1, int duration = 1)
            => MapCell(sourcePos, new ColorStruct(0, 0, 255), default, thickness, duration);

        public static void RedCrosshair(CoordStruct sourcePos, int length, int thickness = 1, int duration = 1)
            => Crosshair(sourcePos, length, new ColorStruct(255, 0, 0), default, thickness, duration);

        public static void GreenCrosshair(CoordStruct sourcePos, int length, int thickness = 1, int duration = 1)
            => Crosshair(sourcePos, length, new ColorStruct(0, 255, 0), default, thickness, duration);

        public static void BlueCrosshair(CoordStruct sourcePos, int length, int thickness = 1, int duration = 1)
            => Crosshair(sourcePos, length, new ColorStruct(0, 0, 255), default, thickness, duration);
    }
}
