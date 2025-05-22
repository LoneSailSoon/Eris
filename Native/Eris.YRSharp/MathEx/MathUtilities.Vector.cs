using System.Numerics;
using Eris.YRSharp.Helpers;

namespace Eris.YRSharp.MathEx;

partial class MathUtilities
{
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
        var num = (float)Math.Sqrt(a.Length() * b.Length());
        if (IsZero(num))
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
    
    
    public static Vector3 GetForwardVector(this Pointer<TechnoClass> pTechno, bool getTurret = false)
    {
        var facing = getTurret ? pTechno.Ref.TurretFacing : pTechno.Ref.Facing;

        return facing.GetCurrent().ToVector3();
    }


    public static Vector3 RotateVector(Vector3 vectorA, Vector3 vectorB, float angle = 45.0f, float? minAngle = null)
    {
        var rad = angle * Math.PI / 180;

        var aModule = vectorA.Length();
        var bModule = vectorB.Length();

        var aNormal = vectorA * (1 / aModule);
        var bNormal = vectorB * (1 / bModule);

        var cosTh = aNormal.X * bNormal.X + aNormal.Y * bNormal.Y +
                    aNormal.Z * bNormal.Z; //Vector3.Dot(aNormal, bNormal);


        if (null != minAngle && Math.Acos(cosTh) <= minAngle * Math.PI / 180)
        {
            return bNormal * aModule;
        }

        var vectorBOnA = aNormal * cosTh;

        var vectorC = bNormal - vectorBOnA;
        var cNormal = vectorC * (1 / vectorC.Length());


        var x = (float)Math.Sin(rad);
        var y = (float)Math.Cos(rad);

        return vectorA * y + cNormal * x * aModule;
    }

}