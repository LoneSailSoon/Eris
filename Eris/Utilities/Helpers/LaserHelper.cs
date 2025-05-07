using Eris.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PatcherYrSharp;
using PatcherYrSharp.GeneralStructures;
using PatcherYrSharp.Helpers;

namespace Eris.Utilities.Helpers
{
    public static class LaserHelpers
    {
        public static Pointer<LaserDrawClass> CreatLaser(this TechnoExt ext, Pointer<AbstractClass> pTarget, Pointer<WeaponTypeClass> pWeapon, CoordStruct sourceCoord)
            => CreatLaser(ext.OwnerObject, pTarget, pWeapon, sourceCoord);
        public static Pointer<LaserDrawClass> CreatLaser(this Pointer<TechnoClass> pThis, Pointer<AbstractClass> pTarget, Pointer<WeaponTypeClass> pWeapon, CoordStruct sourceCoord)
        {
            return pThis.Ref.CreateLaser(pTarget, 0, pWeapon, sourceCoord);
        }

        public static unsafe Pointer<LaserDrawClass> CreateLaser(CoordStruct target, int weaponIndex, Pointer<WeaponTypeClass> pWeapon, CoordStruct sourceCoord)
        {
            var func = (delegate* unmanaged[Thiscall]<IntPtr, IntPtr, int, IntPtr, ref CoordStruct, IntPtr>)0x6FD210;
            return func(IntPtr.Zero, CoordHandle.Handle.GetFakeTarget(target), weaponIndex, pWeapon, ref sourceCoord);
        }

        public class CoordHandle
        {
            private static CoordHandle? _sHandle;
            public static CoordHandle Handle
            {
                get
                {
                    _sHandle ??= new CoordHandle();
                    return _sHandle;
                }
            }


            public unsafe CoordHandle()
            {
                _mVfptr = Marshal.AllocHGlobal(0x58 + 4);
                _mAbstract = Marshal.AllocHGlobal(24);

                Pointer<IntPtr> pAbstract = _mAbstract;
                pAbstract.Ref = _mVfptr;

                _getCoord = GetCoordImpl;
                *(IntPtr*)((uint)_mVfptr + 0x58) = Marshal.GetFunctionPointerForDelegate(_getCoord);
            }

            [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
            private delegate IntPtr GetCoordDelegate(IntPtr pThis, ref CoordStruct input);

            private GetCoordDelegate _getCoord;

            private IntPtr GetCoordImpl(IntPtr pThis, ref CoordStruct input)
            {
                _mCopylocation = _mLocation;
                input = _mCopylocation;
                return _mCopylocation.GetThisPointer();
            }

            ~CoordHandle()
            {
                Marshal.FreeHGlobal(_mAbstract);
                Marshal.FreeHGlobal(_mVfptr);
            }

            private IntPtr _mAbstract;
            private IntPtr _mVfptr;
            private CoordStruct _mLocation;
            private CoordStruct _mCopylocation;

            public IntPtr GetFakeTarget(CoordStruct location)
            {
                _mLocation = location;
                return _mAbstract;
            }
        }


        public static Pointer<LaserDrawClass> DrawLine(this CoordStruct sourcePos, CoordStruct targetPos, ColorStruct innerColor, ColorStruct outerColor = default, int thickness = 2, int duration = 15, ColorStruct houseColor = default)
        {
            if (default != houseColor)
            {
                innerColor = houseColor;
                outerColor = default;
            }
            return YrCreater.Create<LaserDrawClass>().Constructor(sourcePos, targetPos, innerColor, outerColor, default(ColorStruct), duration).SetThickness(thickness);
        }

        public static void DrawLine(this Vector3 sourcePos, Vector3 targetPos, ColorStruct innerColor, ColorStruct outerColor = default, int thickness = 2, int duration = 15, ColorStruct houseColor = default)
            => DrawLine(sourcePos, targetPos, innerColor, outerColor, thickness, duration, houseColor);

        public static void DrawLine(this BulletVelocity sourcePos, BulletVelocity targetPos, ColorStruct innerColor, ColorStruct outerColor = default, int thickness = 2, int duration = 15, ColorStruct houseColor = default)
            => DrawLine(sourcePos, targetPos, innerColor, outerColor, thickness, duration, houseColor);

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
