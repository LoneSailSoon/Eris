using System.Runtime.InteropServices;

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
            this.Start(duration);
        }

        public void Start(int duration)
        {
            this.Duration = duration;
            this.Restart();
        }

        public void Restart()
        {
            Base.Start(this.Duration);
        }

        public TimerStruct Base;
        public int Duration;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct ProgressTimer(int duration)
    {
        public void Start(int duration)
        {
            this.Timer.Start(duration);
        }

        public void Start(int duration, int step)
        {
            this.Step = step;
            this.Start(duration);
        }

        // returns whether the value changed.
        public bool Update()
        {
            if (this.Timer.Base.GetTimeLeft() != 0 || this.Timer.Duration == 0)
            {
                // timer is still running or hasn't been set yet.
                this.HasChanged = false;
            }
            else
            {
                // timer expired. move one step forward.
                this.Value += this.Step;
                this.HasChanged = true;
                this.Timer.Restart();
            }

            return this.HasChanged;
        }

        public int Value = 0; // the current value
        public bool HasChanged = false; // if the timer expired this frame and the value changed
        public RepeatableTimerStruct Timer = new(duration);
        public int Step = 1; // added to value every time the timer expires
    }
