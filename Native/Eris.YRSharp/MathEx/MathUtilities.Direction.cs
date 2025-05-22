using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.GeneralStructures;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp.MathEx;

partial class MathUtilities
{
    public const double BinaryAngleMagic = -(360.0 / (65535 - 1)) * (Math.PI / 180);


    public static int Dir2FacingIndex(this DirStruct dir, int facing)
    {
        var bits = (uint)System.Math.Round(System.Math.Sqrt(facing), MidpointRounding.AwayFromZero);
        double face = dir.GetValue(bits);
        var x = face / (1 << (int)bits) * facing;
        var index = (int)System.Math.Round(x, MidpointRounding.AwayFromZero);
        return index;
    }

    public static Direction ToDirType(this DirStruct dir) =>
        dir.Dir2FacingIndex(8) switch
        {
            0 => Direction.North,
            1 => Direction.NorthEast,
            2 => Direction.East,
            3 => Direction.SouthEast,
            4 => Direction.South,
            5 => Direction.SouthWest,
            6 => Direction.West,
            7 => Direction.NorthWest,
            _ => Direction.N
        };

    public static double Deg2Rad(double deg) => Math.PI * 2 / 360 * deg;

    public static double Rad2Deg(double rad) => 360 / (Math.PI * 2) * rad;
    
    public static DirStruct Xy2Dir(double x, double y)
    {
        var radians = Math.Atan2(y, -x);
        radians += Deg2Rad(90);
        return Radians2Dir(radians);
    }

    public static DirStruct Point2Dir(this CoordStruct offset)
    {
        var radians = Math.Atan2(offset.Y, -offset.X);
        radians -= Deg2Rad(90);
        return Radians2Dir(radians);
    }

    public static DirStruct Radians2Dir(double radians)
    {
        var d = (short)(radians / BinaryAngleMagic);
        return new(d);
    }
}