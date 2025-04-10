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
            private static CoordHandle? s_handle;
            public static CoordHandle Handle
            {
                get
                {
                    s_handle ??= new CoordHandle();
                    return s_handle;
                }
            }


            public unsafe CoordHandle()
            {
                m_vfptr = Marshal.AllocHGlobal(0x58 + 4);
                m_abstract = Marshal.AllocHGlobal(24);

                Pointer<IntPtr> pAbstract = m_abstract;
                pAbstract.Ref = m_vfptr;

                GetCoord = GetCoordImpl;
                *(IntPtr*)((uint)m_vfptr + 0x58) = Marshal.GetFunctionPointerForDelegate(GetCoord);
            }

            [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
            private delegate IntPtr GetCoordDelegate(IntPtr pThis, ref CoordStruct input);

            private GetCoordDelegate GetCoord;

            private IntPtr GetCoordImpl(IntPtr pThis, ref CoordStruct input)
            {
                m_copylocation = m_location;
                input = m_copylocation;
                return m_copylocation.GetThisPointer();
            }

            ~CoordHandle()
            {
                Marshal.FreeHGlobal(m_abstract);
                Marshal.FreeHGlobal(m_vfptr);
            }

            private IntPtr m_abstract;
            private IntPtr m_vfptr;
            private CoordStruct m_location;
            private CoordStruct m_copylocation;

            public IntPtr GetFakeTarget(CoordStruct location)
            {
                m_location = location;
                return m_abstract;
            }
        }


        public static Pointer<LaserDrawClass> DrawLine(this CoordStruct sourcePos, CoordStruct targetPos, ColorStruct InnerColor, ColorStruct OuterColor = default, int thickness = 2, int Duration = 15, ColorStruct houseColor = default)
        {
            ColorStruct innerColor = InnerColor;
            ColorStruct outerColor = OuterColor;
            if (default != houseColor)
            {
                innerColor = houseColor;
                outerColor = default;
            }
            return YrCreater.Create<LaserDrawClass>().Constructor(sourcePos, targetPos, innerColor, outerColor, default(ColorStruct), Duration).SetThickness(thickness);
        }

        public static void DrawLine(this Vector3 sourcePos, Vector3 targetPos, ColorStruct InnerColor, ColorStruct OuterColor = default, int thickness = 2, int Duration = 15, ColorStruct houseColor = default)
            => DrawLine(sourcePos, targetPos, InnerColor, OuterColor, thickness, Duration, houseColor);

        public static void DrawLine(this BulletVelocity sourcePos, BulletVelocity targetPos, ColorStruct InnerColor, ColorStruct OuterColor = default, int thickness = 2, int Duration = 15, ColorStruct houseColor = default)
            => DrawLine(sourcePos, targetPos, InnerColor, OuterColor, thickness, Duration, houseColor);

        public static Pointer<LaserDrawClass> SetInnerColor(this Pointer<LaserDrawClass> pLaser, byte? R = null, byte? G = null, byte? B = null)
        {
            pLaser.Ref.InnerColor.R = R ?? pLaser.Ref.InnerColor.R;
            pLaser.Ref.InnerColor.G = G ?? pLaser.Ref.InnerColor.G;
            pLaser.Ref.InnerColor.B = B ?? pLaser.Ref.InnerColor.B;

            return pLaser;
        }

        public static Pointer<LaserDrawClass> SetOuterColor(this Pointer<LaserDrawClass> pLaser, byte? R = null, byte? G = null, byte? B = null)
        {
            pLaser.Ref.OuterColor.R = R ?? pLaser.Ref.OuterColor.R;
            pLaser.Ref.OuterColor.G = G ?? pLaser.Ref.OuterColor.G;
            pLaser.Ref.OuterColor.B = B ?? pLaser.Ref.OuterColor.B;

            return pLaser;
        }

        public static Pointer<LaserDrawClass> SetOuterSpread(this Pointer<LaserDrawClass> pLaser, byte? R = null, byte? G = null, byte? B = null)
        {
            pLaser.Ref.OuterSpread.R = R ?? pLaser.Ref.OuterSpread.R;
            pLaser.Ref.OuterSpread.G = G ?? pLaser.Ref.OuterSpread.G;
            pLaser.Ref.OuterSpread.B = B ?? pLaser.Ref.OuterSpread.B;

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

        public static Pointer<LaserDrawClass> SetSource(this Pointer<LaserDrawClass> pLaser, int? X = null, int? Y = null, int? Z = null)
        {
            pLaser.Ref.Source.X = X ?? pLaser.Ref.Source.X;
            pLaser.Ref.Source.Y = Y ?? pLaser.Ref.Source.Y;
            pLaser.Ref.Source.Z = Z ?? pLaser.Ref.Source.Z;
            return pLaser;
        }

        public static Pointer<LaserDrawClass> SetTarget(this Pointer<LaserDrawClass> pLaser, int? X = null, int? Y = null, int? Z = null)
        {
            pLaser.Ref.Target.X = X ?? pLaser.Ref.Target.X;
            pLaser.Ref.Target.Y = Y ?? pLaser.Ref.Target.Y;
            pLaser.Ref.Target.Z = Z ?? pLaser.Ref.Target.Z;
            return pLaser;
        }

        public static Pointer<LaserDrawClass> OffsetSource(this Pointer<LaserDrawClass> pLaser, int? X = null, int? Y = null, int? Z = null)
        {
            pLaser.Ref.Source.X += X ?? 0;
            pLaser.Ref.Source.Y += Y ?? 0;
            pLaser.Ref.Source.Z += Z ?? 0;
            return pLaser;
        }

        public static Pointer<LaserDrawClass> OffsetTarget(this Pointer<LaserDrawClass> pLaser, int? X = null, int? Y = null, int? Z = null)
        {
            pLaser.Ref.Target.X += X ?? 0;
            pLaser.Ref.Target.Y += Y ?? 0;
            pLaser.Ref.Target.Z += Z ?? 0;
            return pLaser;
        }

        public static Pointer<LaserDrawClass> SetSource(this Pointer<LaserDrawClass> pLaser, CoordStruct Pos)
        {
            pLaser.Ref.Source = Pos;
            return pLaser;
        }

        public static Pointer<LaserDrawClass> SetTarget(this Pointer<LaserDrawClass> pLaser, CoordStruct Pos)
        {
            pLaser.Ref.Target = Pos;
            return pLaser;
        }

        public static Pointer<LaserDrawClass> OffsetSource(this Pointer<LaserDrawClass> pLaser, CoordStruct Pos)
        {
            pLaser.Ref.Source += Pos;
            return pLaser;
        }

        public static Pointer<LaserDrawClass> OffsetTarget(this Pointer<LaserDrawClass> pLaser, CoordStruct Pos)
        {
            pLaser.Ref.Target += Pos;
            return pLaser;
        }

        public static Pointer<LaserDrawClass> SetIntensity(this Pointer<LaserDrawClass> pLaser, float Start, float End)
        {
            pLaser.Ref.StartIntensity = Start;
            pLaser.Ref.EndIntensity = End;
            return pLaser;
        }

        public static Pointer<LaserDrawClass> SetStartIntensity(this Pointer<LaserDrawClass> pLaser, float Start)
        {
            pLaser.Ref.StartIntensity = Start;
            return pLaser;
        }

        public static Pointer<LaserDrawClass> SetEndIntensity(this Pointer<LaserDrawClass> pLaser, float End)
        {
            pLaser.Ref.EndIntensity = End;
            return pLaser;
        }

        public static Pointer<LaserDrawClass> SetThickness(this Pointer<LaserDrawClass> pLaser, int Thickness)
        {
            if (Thickness >= 2)
            {
                pLaser.Ref.IsHouseColor = true;
                pLaser.Ref.Thickness = Thickness;
            }
            return pLaser;
        }
        public static Pointer<LaserDrawClass> SingleLine(this CoordStruct Source, CoordStruct Target, ColorStruct Color, int thickness = 1, int duration = 1)
            => DrawLine(Source, Target, Color, default, thickness, duration);

        public static Pointer<LaserDrawClass> RedLine(this CoordStruct Source, CoordStruct Target, int thickness = 1, int duration = 1)
            => DrawLine(Source, Target, new ColorStruct(255, 0, 0), default, thickness, duration);

        public static Pointer<LaserDrawClass> RedLineZ(this CoordStruct Source, int Lenth, int thickness = 1, int duration = 1)
            => RedLine(Source, Source + new CoordStruct(0, 0, Lenth), thickness, duration);

        public static Pointer<LaserDrawClass> GreenLine(this CoordStruct Source, CoordStruct Target, int thickness = 1, int duration = 1)
            => DrawLine(Source, Target, new ColorStruct(0, 255, 0), default, thickness, duration);

        public static Pointer<LaserDrawClass> GreenLineZ(this CoordStruct Source, int Lenth, int thickness = 1, int duration = 1)
            => GreenLine(Source, Source + new CoordStruct(0, 0, Lenth), thickness, duration);
        public static Pointer<LaserDrawClass> BlueLine(this CoordStruct Source, CoordStruct Target, int thickness = 1, int duration = 1)
            => DrawLine(Source, Target, new ColorStruct(0, 0, 255), default, thickness, duration);

        public static Pointer<LaserDrawClass> BlueLineZ(this CoordStruct Source, int Lenth, int thickness = 1, int duration = 1)
            => BlueLine(Source, Source + new CoordStruct(0, 0, Lenth), thickness, duration);

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
