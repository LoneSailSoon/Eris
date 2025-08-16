namespace Eris.YRSharp;

public static class FPSCounter
{
    public const nint currentFrameRate = 0xABCD44;
    public static ref uint CurrentFrameRate => ref currentFrameRate.Convert<uint>().Ref;
    
    public const nint totalFramesElapsed = 0xABCD48;
    public static ref uint TotalFramesElapsed => ref totalFramesElapsed.Convert<uint>().Ref;
    
    public const nint totalTimeElapsed = 0xABCD4C;
    public static ref uint TotalTimeElapsed => ref totalTimeElapsed.Convert<uint>().Ref;
    
    public const nint reducedEffects = 0xABCD50;
    public static ref Bool ReducedEffects => ref reducedEffects.Convert<Bool>().Ref;
    
    public static double GetAverageFrameRate()
    {
        if(TotalTimeElapsed != 0) {
            return (double)TotalFramesElapsed / TotalTimeElapsed;
        }

        return 0.0;
    }
}

public static class Detail
{
    public const nint minFrameRate = 0x829FF4;
    public static ref uint MinFrameRate => ref minFrameRate.Convert<uint>().Ref;
    
    public const nint bufferZoneWidth = 0x829FF8;
    public static ref uint BufferZoneWidth => ref bufferZoneWidth.Convert<uint>().Ref;

    public static unsafe uint GetMinFrameRate()
    {
        var func = (delegate* unmanaged[Stdcall]<uint>)0x55AF60;
        return func();
    }
    
    public static bool ReduceEffects()
    {
        return FPSCounter.CurrentFrameRate < GetMinFrameRate();
    }
}