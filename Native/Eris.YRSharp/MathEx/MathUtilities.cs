namespace Eris.YRSharp.MathEx;

public static partial class MathUtilities
{
    public static double Lerp(double a, double b, double alpha) => a + alpha * (b - a);

    public static float Lerp(float a, float b, double alpha) => (float)(a + alpha * (b - a));

    public static long Lerp(long a, long b, double alpha) => (long)(a + alpha * (b - a));

    public static int Lerp(int a, int b, double alpha) => (int)(a + alpha * (b - a));
}