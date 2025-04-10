using System.Runtime.InteropServices;

namespace PatcherYrSharp.GeneralStructures;

[StructLayout(LayoutKind.Sequential)]
public struct DirStruct : IEquatable<DirStruct>
{
    public DirStruct(int value)
    {
        Value = (short)value;
        unused_2 = 0;
    }

    public DirStruct(double rad) : this()
    {
        radians(rad);
    }

    public DirStruct(uint bits, short value)
        : this((short)TranslateFixedPoint(bits, 16, (ushort)value))
    {
    }

    public short GetValue(uint bits = 16)
    {
        /*
        while (true)
        {
            if (Bits <= 0)
            {
                Bits += 16;
            }
            else if (Bits > 16)
            {
                Bits -= 16;
            }
            else
            {
                break;
            }
        }*/
        if (bits is <= 0 or > 16)
            throw new InvalidOperationException("Bits has to be greater than 0 and lower or equal to 16.");

        return (short)TranslateFixedPoint(16, bits, (uint)Value);
    }


    public void SetValue(short value, uint bits = 16)
    {
        if (bits is > 0 and <= 16)
        {
            Value = (short)TranslateFixedPoint(bits, 16, (uint)value, 0);
        }
        else
        {
            throw new InvalidOperationException("Bits has to be greater than 0 and lower or equal to 16.");
        }
    }

    public static uint TranslateFixedPoint(uint bitsFrom, uint bitsTo, uint value, uint offset = 0)
    {
        uint maskIn = (1u << (int)bitsFrom) - 1;
        uint maskOut = (1u << (int)bitsTo) - 1;

        if (bitsFrom > bitsTo)
        {
            // converting down
            return (((((value & maskIn) >> (int)(bitsFrom - bitsTo - 1)) + 1) >> 1) + offset) & maskOut;
        }
        else if (bitsFrom < bitsTo)
        {
            // converting up
            return (((value - offset) & maskIn) << (int)(bitsTo - bitsFrom)) & maskOut;
        }
        else
        {
            return value & maskOut;
        }
    }

    public short value8()
    {
        return GetValue(3);
    }

    public void value8(short value)
    {
        SetValue(value, 3);
    }

    public short value32()
    {
        return GetValue(5);
    }

    public void value32(short value)
    {
        SetValue(value, 5);
    }

    public short value256()
    {
        return GetValue(8);
    }

    public void value256(short value)
    {
        SetValue(value, 8);
    }

    public short value()
    {
        return GetValue(16);
    }

    public void value(short value)
    {
        SetValue(value, 16);
    }

    public double radians(uint Bits = 16)
    {
        if (Bits is > 0 and <= 16)
        {
            int max = (1 << (int)Bits) - 1;

            int value = max / 4 - this.GetValue(Bits);
            return -value * -(Math.PI * 2 / max);
        }
        else
        {
            throw new InvalidOperationException("Bits has to be greater than 0 and lower or equal to 16.");
        }
    }

    public void radians(double rad, uint bits = 16)
    {
        if (bits is > 0 and <= 16)
        {
            int Max = (1 << (int)bits) - 1;

            int value = (int)(rad * (Max / Math.PI * 2));
            this.SetValue((short)(Max / 4 - value), bits);
        }
        else
        {
            throw new InvalidOperationException("Bits has to be greater than 0 and lower or equal to 16.");
        }
    }

    public static bool operator ==(DirStruct a, DirStruct b)
    {
        return a.Value == b.Value;
    }

    public static bool operator !=(DirStruct a, DirStruct b) => !(a == b);
    public override bool Equals(object obj) => obj is DirStruct other && this == other;
    public override int GetHashCode() => Value.GetHashCode();

    public void SafeValue()
    {
        if (Value > 32767)
        {
            Value -= 32767;
        }
        else if (Value < -32767)
        {
            Value += 32767;
        }
    }

    public short Value;
    private ushort unused_2;

    public bool Equals(DirStruct other)
    {
        return Value == other.Value;
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct FacingStruct
{
    private FacingStruct(short rot) : this()
    {
        Timer = new TimerStruct(0);
        this.turn_rate(rot);
    }

    public short turn_rate()
    {
        return this.ROT.value();
    }

    public void turn_rate(short value)
    {
        if (value > 127)
        {
            value = 127;
        }

        this.ROT.SetValue(value, 8);
    }

    public bool in_motion()
    {
        return this.turn_rate() > 0 && this.Timer.GetTimeLeft() != 0;
    }

    public DirStruct target()
    {
        return this.Value;
    }

    public DirStruct current()
    {
        var ret = this.Value;

        if (this.in_motion())
        {
            var diff = this.difference();
            var num_steps = (short)(this.num_steps());

            if (num_steps > 0)
            {
                var steps_left = this.Timer.GetTimeLeft();
                ret.value((short)(ret.value() - steps_left * diff / num_steps));
            }
        }

        return ret;
    }

    public bool set(DirStruct value)
    {
        bool ret = (this.current() != value);

        if (ret)
        {
            this.Value = value;
            this.Initial = value;
        }

        this.Timer.Start(0);

        return ret;
    }

    public bool turn(DirStruct value)
    {
        if (this.Value == value)
        {
            return false;
        }

        this.Initial = this.current();
        this.Value = value;

        if (this.turn_rate() > 0)
        {
            this.Timer.Start(this.num_steps());
        }

        return true;
    }

    public short difference()
    {
        return (short)(this.Value.value() - this.Initial.value());
    }

    public int num_steps()
    {
        return Math.Abs((int)this.difference()) / (int)this.turn_rate();
    }

    public DirStruct Value; // target facing
    public DirStruct Initial; // rotation started here
    public TimerStruct Timer; // counts rotation steps
    public DirStruct ROT; // Rate of Turn. INI Value * 256
}