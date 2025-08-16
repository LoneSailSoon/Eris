namespace Eris.YRSharp.GeneralStructures;

[StructLayout(LayoutKind.Sequential)]
public struct DirStruct(int value) : IEquatable<DirStruct>
{
    public DirStruct(double rad) : this(RadiansToValue(rad))
    {
    }

    public DirStruct(uint bits, short value)
        : this((short)TranslateFixedPoint(bits, 16, (ushort)value))
    {
    }


    public short this[uint bits]
    {
        readonly get => GetValue(bits);
        set => SetValue(value, bits);
    }
    
    public readonly short GetValue(uint bits = 16)
    {
        if (bits is <= 0 or > 16)
            throw new InvalidOperationException("Bits has to be greater than 0 and lower or equal to 16.");

        return (short)TranslateFixedPoint(16, bits, (uint)_value);
    }


    public void SetValue(short value, uint bits = 16)
    {
        if (bits is <= 0 or > 16)
            throw new InvalidOperationException("Bits has to be greater than 0 and lower or equal to 16.");

        _value = (short)TranslateFixedPoint(bits, 16, (uint)value);
    }

    public static uint TranslateFixedPoint(uint bitsFrom, uint bitsTo, uint value, uint offset = 0)
    {
        var maskIn = (1u << (int)bitsFrom) - 1;
        var maskOut = (1u << (int)bitsTo) - 1;

        if (bitsFrom > bitsTo)
        {
            // converting down
            return (((((value & maskIn) >> (int)(bitsFrom - bitsTo - 1)) + 1) >> 1) + offset) & maskOut;
        }

        if (bitsFrom < bitsTo)
        {
            // converting up
            return (((value - offset) & maskIn) << (int)(bitsTo - bitsFrom)) & maskOut;
        }

        return value & maskOut;
    }

    public short Value8
    {
        readonly get => GetValue(3); 
        set => SetValue(value, 3);
    }

    public short Value32
    {
        readonly get => GetValue(5); 
        set => SetValue(value, 5);
    }

    public short Value256
    {
        readonly get => GetValue(8);
        set => SetValue(value, 8);
    }

    public short Value
    {
        readonly get => GetValue();
        set => SetValue(value);
    }

    public readonly double ToRadians(uint bits = 16)
    {
        if (bits is <= 0 or > 16)
            throw new InvalidOperationException("Bits has to be greater than 0 and lower or equal to 16.");
        
        var max = (1 << (int)bits) - 1;

        var value = max / 4 - GetValue(bits);
        return -value * -(Math.Tau / max);
    }

    public static DirStruct FromRadians(double radians) => new(RadiansToValue(radians));

    private static short RadiansToValue(double rad, uint bits = 16)
    {
        if (bits is <= 0 or > 16)
            throw new InvalidOperationException("Bits has to be greater than 0 and lower or equal to 16.");
        
        var max = (1 << (int)bits) - 1;

        var value = (int)(rad * (max / Math.PI * 2));
            
        return (short)TranslateFixedPoint(bits, 16, (uint)(max / 4 - value));
    }
    
    public void Radians(double rad, uint bits = 16)
    {
        if (bits is <= 0 or > 16)
            throw new InvalidOperationException("Bits has to be greater than 0 and lower or equal to 16.");
        
        var max = (1 << (int)bits) - 1;

        var value = (int)(rad * (max / Math.PI * 2));
            
        SetValue((short)(max / 4 - value), bits);
    }
  

    public static bool operator ==(DirStruct a, DirStruct b) => a._value == b._value;

    public static bool operator !=(DirStruct a, DirStruct b) => !(a == b);
    public readonly override bool Equals(object obj) => obj is DirStruct other && this == other;
    public readonly override int GetHashCode() => _value;
    

    private short _value = (short)value;
    private ushort _unused = 0;

    public readonly bool Equals(DirStruct other) => _value == other._value;
}

[StructLayout(LayoutKind.Sequential)]
public struct FacingStruct(short rot)
{
    public short TurnRate
    {
        readonly get => ROT.Value;
        set => ROT.Value256 = value > 127 ? (short)127 : value;
    }

    public readonly bool IsInMotion() => TurnRate > 0 && Timer.GetTimeLeft() != 0;

    public readonly DirStruct GetTarget => Value;

    public readonly DirStruct GetCurrent()
    {
        var ret = Value;

        if (!IsInMotion()) return ret;

        var diff = GetDifference();
        var numSteps = (short)GetNumSteps();

        if (numSteps <= 0) return ret;

        var stepsLeft = Timer.GetTimeLeft();
        ret.Value = (short)(ret.Value - stepsLeft * diff / numSteps);

        return ret;
    }

    public bool Set(DirStruct value)
    {
        var ret = GetCurrent() != value;

        if (ret)
        {
            Value = value;
            Initial = value;
        }

        Timer.Start(0);

        return ret;
    }

    public bool Turn(DirStruct value)
    {
        if (Value == value)
        {
            return false;
        }

        Initial = GetCurrent();
        Value = value;

        if (TurnRate > 0)
        {
            Timer.Start(GetNumSteps());
        }

        return true;
    }

    public readonly short GetDifference()
    {
        return (short)(Value.Value - Initial.Value);
    }

    public readonly int GetNumSteps()
    {
        return Math.Abs((int)GetDifference()) / TurnRate;
    }

    public DirStruct Value; // target facing
    public DirStruct Initial; // rotation started here
    public TimerStruct Timer = new(0); // counts rotation steps
    public DirStruct ROT = new(8, rot > 127 ? (short)127 : rot); // Rate of Turn. INI Value * 256
}