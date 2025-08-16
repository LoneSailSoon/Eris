namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 1012)]
public struct Randomizer
{
    public unsafe int Next()
    {
        var func = (delegate*unmanaged[Thiscall]<nint, int>)0x65C780;
        return func(this.GetThisPointer());
    }
    
    public unsafe int Next(int min, int max)
    {
        var func = (delegate*unmanaged[Thiscall]<nint, int, int , int>)0x65C7E0;
        return func(this.GetThisPointer(), min, max);
    }

    public double NextDouble(double min, double max)
    {
        var v = Next(1, int.MaxValue) / (double)int.MaxValue;
        return min + (max - min) * v;
    }

    public double NextDouble()
    {
        return Next(1, int.MaxValue) / (double)int.MaxValue;
    }
}