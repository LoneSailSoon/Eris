using System.Numerics;
using Eris.YRSharp.GeneralStructures;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp.MathEx;

partial class MathUtilities
{
    public static Vector3 ToVector3(this DirStruct dir)
    {
        var rad = -dir.ToRadians();
        var vec = new Vector3((float)Math.Cos(rad), (float)Math.Sin(rad), 0f);
        return vec;
    }

    public static CoordStruct ToCoordStruct(this Vector3 vec) => new((int)vec.X, (int)vec.Y, (int)vec.Z);

    public static CoordStruct ToCoordStruct(this BulletVelocity vec) => new((int)vec.X, (int)vec.Y, (int)vec.Z);

    public static Vector3 ToVector3(this CoordStruct coord) => new(coord.X, coord.Y, coord.Z);

    public static Vector3 ToVector3(this BulletVelocity velocity) =>
        new((float)velocity.X, (float)velocity.Y, (float)velocity.Z);

    public static BulletVelocity ToBulletVelocity(this CoordStruct location) =>
        new((float)location.X, (float)location.Y, (float)location.Z);

    public static BulletVelocity ToBulletVelocity(this Vector3 vector) => new(vector.X, vector.Y, vector.Z);

    public static RectangleStruct ToRectangleStruct(this LtrbStruct ltrb) =>
        new(ltrb.Left, ltrb.Top, ltrb.Right - ltrb.Left, ltrb.Bottom - ltrb.Top);

    public static LtrbStruct ToLtrbStruct(this RectangleStruct rect) =>
        new(rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
}