namespace Eris.YRSharp.GeneralStructures;

[StructLayout(LayoutKind.Sequential)]
public struct TimerStruct
{
    public TimerStruct(int duration)
    {
        Start(duration);
    }

    public void Start(int duration)
    {
        StartTime = Game.CurrentFrame;
        TimeLeft = duration;
    }

    public void Stop()
    {
        StartTime = -1;
        TimeLeft = 0;
    }

    public void Pause()
    {
        if (IsTicking())
        {
            TimeLeft = GetTimeLeft();
            StartTime = -1;
        }
    }

    public void Resume()
    {
        if (!IsTicking())
        {
            StartTime = Game.CurrentFrame;
        }
    }

    public readonly int GetTimeLeft()
    {
        if (!IsTicking())
        {
            return TimeLeft;
        }

        var passed = Game.CurrentFrame - StartTime;
        var left = TimeLeft - passed;

        return left <= 0 ? 0 : left;
    }

    public readonly int GetTime()
    {
        if (!IsTicking())
        {
            return 0;
        }

        return Game.CurrentFrame - StartTime;
    }

    // returns whether a ticking timer has finished counting down.
    public readonly bool Completed()
    {
        return IsTicking() && !HasTimeLeft();
    }

    // returns whether a delay is active or a timer is still counting down.
    // this is the 'opposite' of Completed() (meaning: incomplete / still busy)
    // and logically the same as !Expired() (meaning: blocked / delay in progress)
    public readonly bool InProgress()
    {
        return IsTicking() && HasTimeLeft();
    }

    // returns whether a delay is inactive. same as !InProgress().

    public readonly bool IsExpired => !IsTicking() || !HasTimeLeft();

    public readonly bool Expired()
    {
        return !IsTicking() || !HasTimeLeft();
    }

    public bool Ticking => StartTime != -1;

    internal readonly bool IsTicking()
    {
        return StartTime != -1;
    }

    internal readonly bool HasTimeLeft()
    {
        return GetTimeLeft() > 0;
    }

    public int StartTime;
    public int gap;
    public int TimeLeft;
}

[StructLayout(LayoutKind.Sequential)]
public struct RepeatableTimerStruct
{
    public RepeatableTimerStruct(int duration)
    {
        Start(duration);
    }

    public void Start(int duration)
    {
        Duration = duration;
        Restart();
    }

    public void Restart()
    {
        Base.Start(Duration);
    }

    public TimerStruct Base;
    public int Duration;
}

[StructLayout(LayoutKind.Sequential)]
public struct ProgressTimer(int duration)
{
    public void Start(int duration)
    {
        Timer.Start(duration);
    }

    public void Start(int duration, int step)
    {
        Step = step;
        Start(duration);
    }

    // returns whether the value changed.
    public bool Update()
    {
        if (Timer.Base.GetTimeLeft() != 0 || Timer.Duration == 0)
        {
            // timer is still running or hasn't been set yet.
            HasChanged = false;
        }
        else
        {
            // timer expired. move one step forward.
            Value += Step;
            HasChanged = true;
            Timer.Restart();
        }

        return HasChanged;
    }

    public int Value = 0; // the current value
    public bool HasChanged = false; // if the timer expired this frame and the value changed
    public RepeatableTimerStruct Timer = new(duration);
    public int Step = 1; // added to value every time the timer expires
}

[StructLayout(LayoutKind.Explicit, Size = 32)]
public struct TransitionTimer
{
    public bool AreStates11() // 0x4A5110
        => State1 && State2;

    public bool AreStates10() // 0x4A5130
        => State1 && !State2;

    public bool AreStates01() // 0x4A51B0
        => !State1 && State2;

    public bool AreStates00() // 0x4A51D0
        => !State1 && !State2;

    public unsafe bool IsTimerFinished()
    {
        var func = (delegate*unmanaged[Thiscall]<nint, bool>)0x4A5150;
        return func(this.GetThisPointer());
    }

    public unsafe void StartTimer11(double time)
    {
        var func = (delegate*unmanaged[Thiscall]<nint,double, void>)0x4A51F0;
        func(this.GetThisPointer(), time);
    }

    public unsafe void StartTimer10(double time)
    {
        var func = (delegate*unmanaged[Thiscall]<nint,double, void>)0x4A5240;
        func(this.GetThisPointer(), time);
    }

    public unsafe void Update()
    {
        var func = (delegate*unmanaged[Thiscall]<nint, void>)0x4A5290;
        func(this.GetThisPointer());
    }

    public unsafe void PercentageDone()
    {
        var func = (delegate*unmanaged[Thiscall]<nint, double>)0x4A52F0;
        func(this.GetThisPointer());
    }

    public unsafe void SetToDone()
    {
        var func = (delegate*unmanaged[Thiscall]<nint, void>)0x4A5360;
        func(this.GetThisPointer());
    }


    [FieldOffset(0)] public double Rate1;
    [FieldOffset(8)] public TimerStruct ActionTimer;
    [FieldOffset(20)] public uint Rate2;
    [FieldOffset(24)] public Bool State1;
    [FieldOffset(25)] public Bool State2;
}

