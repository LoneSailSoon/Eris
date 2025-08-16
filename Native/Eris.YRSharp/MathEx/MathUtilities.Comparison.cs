namespace Eris.YRSharp.MathEx;

partial class MathUtilities
{
    public const double DoubleEpsilon = 2.2204460492503131e-016;

    public const float FloatEpsilon = 1.192092896e-07F;

    public static bool AreClose(double left, double right)
    {
        // ReSharper disable once CompareOfFloatsByEqualityOperator
        if (left == right) return true;
        var eps = (Math.Abs(left) + Math.Abs(right) + 10.0) * DoubleEpsilon;
        var delta = left - right;
        return -eps < delta && eps > delta;
    }

    public static bool AreClose(double value1, double value2, double eps)
    {
        // ReSharper disable once CompareOfFloatsByEqualityOperator
        if (value1 == value2) return true;
        var delta = value1 - value2;
        return -eps < delta && eps > delta;
    }

    public static bool AreClose(float left, float right)
    {
        // ReSharper disable once CompareOfFloatsByEqualityOperator
        if (left == right) return true;
        var eps = (Math.Abs(left) + Math.Abs(right) + 10.0) * FloatEpsilon;
        var delta = left - right;
        return -eps < delta && eps > delta;
    }

    public static bool AreClose(float value1, float value2, float eps)
    {
        // ReSharper disable once CompareOfFloatsByEqualityOperator
        if (value1 == value2) return true;
        var delta = value1 - value2;
        return -eps < delta && eps > delta;
    }

    public static bool LessThan(double left, double right) => left < right && !AreClose(left, right);
    public static bool GreaterThan(double left, double right) => left > right && !AreClose(left, right);

    public static bool LessOrClose(double left, double right) => left < right || AreClose(left, right);
    public static bool GreaterOrClose(double left, double right) => left > right || AreClose(left, right);

    public static bool LessThan(float left, float right) => left < right && !AreClose(left, right);
    public static bool GreaterThan(float left, float right) => left > right && !AreClose(left, right);

    public static bool LessOrClose(float left, float right) => left < right || AreClose(left, right);
    public static bool GreaterOrClose(float left, float right) => left > right || AreClose(left, right);

    public static bool IsOne(double value) => Math.Abs(value - 1.0) < 10.0 * DoubleEpsilon;

    public static bool IsOne(float value) => Math.Abs(value - 1.0f) < 10.0f * FloatEpsilon;

    public static bool IsZero(double value) => Math.Abs(value) < 10.0 * DoubleEpsilon;

    public static bool IsZero(float value) => Math.Abs(value) < 10.0f * FloatEpsilon;

    public static double Clamp(double x, double min, double max) => x < min ? min : x < max ? x : max;

    public static float Clamp(float x, float min, float max) => x < min ? min : x < max ? x : max;

    public static int Clamp(int x, int min, int max) => x < min ? min : x < max ? x : max;

    public static long Clamp(long x, long min, long max) => x < min ? min : x < max ? x : max;

    public static (double min, double max) GetMinMax(double a, double b) => a < b ? (a, b) : (b, a);

    public static (double min, double max) GetMinMaxFromDelta(double initialValue, double delta) =>
        delta < 0 ? (initialValue + delta, initialValue) : (initialValue, initialValue + delta);
    
    public static (int min, int max) GetMinMax(int a, int b) => a < b ? (a, b) : (b, a);

    public static (int min, int max) GetMinMaxFromDelta(int initialValue, int delta) =>
        delta < 0 ? (initialValue + delta, initialValue) : (initialValue, initialValue + delta);
    
}