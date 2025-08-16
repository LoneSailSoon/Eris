namespace Eris.YRSharp.MathEx;

partial class MathUtilities
{
    public static readonly IRandom DefaultRandom = new ScenarioRandom();
    public static readonly IRandom DesyncRandom = new CSDesyncRandom();
    
    
    private class ScenarioRandom : IRandom
    {
        public int Next() => ScenarioClass.Instance.Random.Next();
    
        public int Next(int min, int max) => ScenarioClass.Instance.Random.Next(min, max);
    
        public double NextDouble() => ScenarioClass.Instance.Random.NextDouble();
    
        public double NextDouble(double min, double max) => ScenarioClass.Instance.Random.NextDouble(min, max);

    }

    private class CSDesyncRandom : IRandom
    {
        private static readonly Random _random = new();
    
        public int Next() => _random.Next();
    
        public int Next(int min, int max) => _random.Next(min, max);
    
        public double NextDouble() => _random.NextDouble();
    
        public double NextDouble(double min, double max) =>  _random.NextDouble() * (max - min) + min;
    }
    
    
    public interface IRandom
    {
        int Next();
        int Next(int min, int max);
        double NextDouble();
        double NextDouble(double min, double max);
    }
}