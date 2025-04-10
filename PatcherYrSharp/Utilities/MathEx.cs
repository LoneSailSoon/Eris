using System.Numerics;
using System.Runtime.InteropServices;
using PatcherYrSharp.GeneralDefinitions;
using PatcherYrSharp.GeneralStructures;
using PatcherYrSharp.Helpers;

namespace PatcherYrSharp.Utilities;

    public static class MathEx
    {
        private static Random _random = new Random(60);
        private static object _randomLocker = new object();
        public static void SetRandomSeed(int seed)
        {
            _random = new Random(seed);
        }
        public static Random Random => _random;
        public static object RandomLocker => _randomLocker;

        // ===============================================
        // Utilities for numeric
        #region Numeric
        public const double Epsilon = float.Epsilon;

        public static int Dir2FacingIndex(this DirStruct dir, int facing)
        {
            uint bits = (uint)Math.Round(Math.Sqrt(facing), MidpointRounding.AwayFromZero);
            double face = dir.GetValue(bits);
            double x = (face / (1 << (int)bits)) * facing;
            int index = (int)Math.Round(x, MidpointRounding.AwayFromZero);
            return index;
        }

        public static Direction ToDirType(this DirStruct dir)
        {
            int i = dir.Dir2FacingIndex(8);
            switch (i)
            {
                case 0:
                    return Direction.North;
                case 1:
                    return Direction.NorthEast;
                case 2:
                    return Direction.East;
                case 3:
                    return Direction.SouthEast;
                case 4:
                    return Direction.South;
                case 5:
                    return Direction.SouthWest;
                case 6:
                    return Direction.West;
                case 7:
                    return Direction.NorthWest;
            }
            return Direction.N;
        }


        public static bool Approximately(double a, double b)
        {
            return Math.Abs(a - b) < Epsilon;
        }
        public static bool Approximately(float a, float b)
        {
            return Approximately((double)a, b);
        }
        public static bool IsNearlyZero(double val)
        {
            return Approximately(val, 0);
        }

        public static double Deg2Rad(double deg)
        {
            return ((Math.PI * 2) / 360) * deg;
        }
        public static double Rad2Deg(double rad)
        {
            return (360 / (Math.PI * 2)) * rad;
        }

        public static double Clamp(double x, double min, double max)
        {
            return x < min ? min : x < max ? x : max;
        }
        public static float Clamp(float x, float min, float max)
        {
            return x < min ? min : x < max ? x : max;
        }
        public static int Clamp(int x, int min, int max)
        {
            return x < min ? min : x < max ? x : max;
        }
        public static long Clamp(long x, long min, long max)
        {
            return x < min ? min : x < max ? x : max;
        }

        public static double Wrap(double x, double min, double max)
        {
            if (min == max)
            {
                return min;
            }

            var size = max - min;
            var endVal = x;

            while (endVal < min)
            {
                endVal += size;
            }
            while (endVal > max)
            {
                endVal -= size;
            }

            return endVal;
        }
        public static float Wrap(float x, float min, float max)
        {
            return (float)Wrap((double)x, min, max);
        }
        public static long Wrap(long x, long min, long max)
        {
            if (min == max)
            {
                return min;
            }

            var size = max - min;
            var endVal = x;

            while (endVal < min)
            {
                endVal += size;
            }
            while (endVal > max)
            {
                endVal -= size;
            }

            return endVal;
        }
        public static int Wrap(int x, int min, int max)
        {
            return (int)Wrap((long)x, min, max);
        }

        public static double Lerp(double a, double b, double alpha)
        {
            return a + alpha * (b - a);
        }
        public static float Lerp(float a, float b, double alpha)
        {
            return (float)Lerp((double)a, b, alpha);
        }
        public static long Lerp(long a, long b, double alpha)
        {
            return (long)(a + alpha * (b - a));
        }
        public static int Lerp(int a, int b, double alpha)
        {
            return (int)Lerp((long)a, b, alpha);
        }

        public static double Repeat(double t, double length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("length should not <= 0");
            }

            var val = t % length;
            return val < 0 ? val + length : val;
        }
        public static double PingPong(double t, double length)
        {
            var val = Repeat(t, length * 2);
            return val > length ? 2 * length - val : val;
        }

        public static double Remap(double value, double start, double end)
        {
            return start + value * (end - start);
        }

        public static T Remap<T>(double value, T start, T end)
            where T : struct, IVector<T>
        {
            return start + (end - start) * value;
        }

        public static double ColseTo(double a, double b, double length)
        {
            var offset = b - a;
            return Math.Abs(offset) < length ? b : a + (offset < 0 ? -length : length);
        }

        public static Vector3 ColseTo(Vector3 a, Vector3 b, float length)
        {
            var offset = b - a;
            var magnitude = offset.Length();
            return Math.Abs(magnitude) < length ? b : a + (offset * length / magnitude);
        }

        #endregion



        #region Miscellaneous
        public static Vector3 GetForwardVector(this Pointer<TechnoClass> pTechno, bool getTurret = false)
        {
            FacingStruct facing = getTurret ? pTechno.Ref.TurretFacing : pTechno.Ref.Facing;

            return facing.current().ToVector3();
        }


        #endregion


        // ===============================================
        // Utilities for Vectors
        #region Vectors
        public static Vector3 GetNormalizedVector3(Vector3 vector)
        {
            return vector == Vector3.Zero ? Vector3.Zero : vector * (1 / vector.Length());
        }
        public static Vector3 Normalize(this Vector3 vector)
        {
            return GetNormalizedVector3(vector);
        }

        public static float RadAngle(Vector3 a, Vector3 b)
        {
            float num = (float)Math.Sqrt(a.Length() * b.Length());
            if (num < Epsilon)
                return 0f;
            return (float)Math.Acos(Dot(a, b) / num);
        }
        public static float DegAngle(Vector3 a, Vector3 b)
        {
            return (float)Rad2Deg(RadAngle(a, b));
        }
        public static float Dot(Vector3 a, Vector3 b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }
        public static Vector3 Cross(Vector3 a, Vector3 b)
        {
            return new Vector3(
                a.Y * b.Z - a.Z - b.Y,
                a.Z * b.X - a.X - b.Z,
                a.X * b.Y - a.Y * b.X);
        }
        public static Vector3 Lerp(Vector3 a, Vector3 b, float t)
        {
            return a + (b - a) * t;
        }

        public static Vector3 Slerp(Vector3 a, Vector3 b, float t)
        {
            Quaternion r = MathEx.FromToRotation(a, b);
            Quaternion q = Quaternion.Slerp(Quaternion.Identity, r, t);
            return Vector3.Normalize(Vector3.Transform(a, q));
        }

        public static float CalculateRandomRange(float min = 0.0f, float max = 1.0f)
        {
            if (min == max)
            {
                return min;
            }

            float length = max - min;
            return min + (float)_random.NextDouble() * length;

        }

        public static Vector3 CalculateRandomUnitVector()
        {
            const float r = 1;
            const float tau = (float)(Math.PI * 2);

            float azimuth = (float)(_random.NextDouble() * tau);
            float elevation = (float)(_random.NextDouble() * tau);

            return new Vector3(
                (float)(r * Math.Cos(elevation) * Math.Cos(azimuth)),
                (float)(r * Math.Cos(elevation) * Math.Sin(azimuth)),
                (float)(r * Math.Sin(elevation))
                );

        }
        public static Vector3 CalculateRandomPointInSphere(float innerRadius, float outerRadius)
        {
            return CalculateRandomUnitVector() * CalculateRandomRange(innerRadius, outerRadius);
        }

        public static Vector3 CalculateRandomPointInBox(Vector3 size)
        {
            return new Vector3(
                CalculateRandomRange(0, size.X) - size.X / 2f,
                CalculateRandomRange(0, size.Y) - size.Y / 2f,
                CalculateRandomRange(0, size.Z) - size.Z / 2f
                );
        }

        public static Vector3 CalculateRandomPointInBox(float sizeX, float sizeY, float sizeZ)
        {
            return new Vector3(
                CalculateRandomRange(0, sizeX) - sizeX / 2f,
                CalculateRandomRange(0, sizeY) - sizeY / 2f,
                CalculateRandomRange(0, sizeZ) - sizeZ / 2f
                );
        }


        /// <summary>
        /// 将向量a朝向量b旋转一定角度
        /// </summary>
        /// <param name="vectorA">待旋转的向量</param>
        /// <param name="vectorB">目标向量</param>
        /// <param name="angle">旋转角度</param>
        /// <param name="minAngle">小于等于这个角度直接转向目标向量方向</param>
        /// <returns>旋转后的向量</returns>
        public static Vector3 RotateVector(Vector3 vectorA, Vector3 vectorB, float angle = 45.0f, float? minAngle = null)
        {
            double rad = angle * Math.PI / 180;

            float aModule = vectorA.Length();
            float bModule = vectorB.Length();

            Vector3 aNormal = vectorA * (1 / aModule);
            Vector3 bNormal = vectorB * (1 / bModule);

            //获取向量a、b夹角的余弦值
            float cosTh = aNormal.X * bNormal.X + aNormal.Y * bNormal.Y + aNormal.Z * bNormal.Z;//Vector3.Dot(aNormal, bNormal);

            //小于这个角度就直接转向

            if (null != minAngle && Math.Acos(cosTh) <= minAngle * Math.PI / 180)
            {
                return bNormal * aModule;
            }

            //获取向量b在向量a上的投影
            Vector3 vectorB_ = aNormal * cosTh;

            //获取垂直于向量a的向量c
            Vector3 vectorC = bNormal - vectorB_;
            //获取与向量c通向的单位向量，作为新平面基底之一
            Vector3 cNormal = vectorC * (1 / vectorC.Length());

            //获取旋转后的二维坐标

            float X = (float)Math.Sin(rad);
            float Y = (float)Math.Cos(rad);

            //一个3*2矩阵乘一个2*1向量
            return vectorA * Y + cNormal * X * aModule;
        }


        #endregion

        #region Quaternion

        // https://stackoverflow.com/questions/1171849/finding-quaternion-representing-the-rotation-from-one-vector-to-another
        public static Quaternion FromToRotation(Vector3 fromDirection, Vector3 toDirection)
        {
            var from = Vector3.Normalize(fromDirection);
            var to = Vector3.Normalize(toDirection);

            var dot = Vector3.Dot(from, to);
            // same direction
            if (dot > 0.999999)
            {
                return Quaternion.Identity;
            }

            Vector3 normal;
            // opposite directions
            if (dot < -0.999999)
            {
                normal = Vector3.Cross(Vector3.UnitX, from);
                if (normal.Length() < 0.000001)
                    normal = Vector3.Cross(Vector3.UnitY, from);
                normal = Vector3.Normalize(normal);
                return Quaternion.CreateFromAxisAngle(normal, (float)Math.PI);
            }

            normal = Vector3.Cross(from, to);
            var q = new Quaternion(normal, 1 + dot);
            q = Quaternion.Normalize(q);
            return q;
        }
        #endregion


        // ===============================================
        // Utilities for Convertions
        #region Convertions
        public static Vector3 ToVector3(this DirStruct dir)
        {
            double rad = -dir.radians();
            Vector3 vec = new Vector3((float)Math.Cos(rad), (float)Math.Sin(rad), 0f);
            return vec;
        }

        public static Vector3 ToVector3(this CoordStruct coord)
        {
            return new Vector3(coord.X, coord.Y, coord.Z);
        }
        public static CoordStruct ToCoordStruct(this Vector3 vec)
        {
            return new CoordStruct((int)vec.X, (int)vec.Y, (int)vec.Z);
        }

        public static CoordStruct ToCoordStruct(this SingleVector3D vec)
        {
            return new CoordStruct((int)vec.X, (int)vec.Y, (int)vec.Z);
        }

        public static ColorStruct ToColorStruct(this Vector3 vector)
        {
            return new ColorStruct((int)vector.X, (int)vector.Y, (int)vector.Z);
        }

        public static Vector3 ToVector3(this BulletVelocity velocity)
        {
            return new Vector3((float)velocity.X, (float)velocity.Y, (float)velocity.Z);
        }

        public static CoordStruct ToCoordStruct(this BulletVelocity vec)
        {
            return new CoordStruct((int)vec.X, (int)vec.Y, (int)vec.Z);
        }

        public static BulletVelocity ToBulletVelocity(this CoordStruct Location)
        {
            return new BulletVelocity((float)Location.X, (float)Location.Y, (float)Location.Z);
        }
        public static BulletVelocity ToBulletVelocity(this Vector3 vector)
        {
            return new BulletVelocity((float)vector.X, (float)vector.Y, (float)vector.Z);
        }

        public static RectangleStruct ToRectangleStruct(this LTRBStruct ltrb)
        {
            return new RectangleStruct(ltrb.Left, ltrb.Top, ltrb.Right - ltrb.Left, ltrb.Bottom - ltrb.Top);
        }

        public static LTRBStruct ToLTRBStruct(this RectangleStruct rect)
        {
            return new LTRBStruct(rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
        }

        #endregion

        public const double BinaryAngleMagic = -(360.0 / (65535 - 1)) * (Math.PI / 180);
        public static DirStruct XY2Dir(double X, double Y)
        {
            double radians = Math.Atan2(Y, -X);
            radians += MathEx.Deg2Rad(90);
            return Radians2Dir(radians);
        }
        public static DirStruct Point2Dir(this CoordStruct offset)
        {
            double radians = Math.Atan2(offset.Y, -offset.X);
            radians -= MathEx.Deg2Rad(90);
            return Radians2Dir(radians);
        }
        public static DirStruct Radians2Dir(double radians)
        {
            short d = (short)(radians / BinaryAngleMagic);
            return new DirStruct(d);
        }

        public static int GetRandomValue(this Point2D point, int defVal)
        {
            if (default == point) return defVal;
            int min = point.X;
            int max = point.Y;
            if (min > max)
            {
                min = max;
                max = point.X;
            }
            return Math.Max(defVal + MathEx.Random.Next(min, max), 0);
        }

        public static int Min(int value1, int value2)
        {
            return value1 <= value2 ? value1 : value2;
        }
        public static int Max(int value1, int value2)
        {
            return value1 >= value2 ? value1 : value2;
        }

        public static List<T> CreateList<T>(int count)
        {
            var list = new List<T>(count);
            CollectionsMarshal.SetCount(list, count);
            return list;
        }
    }
