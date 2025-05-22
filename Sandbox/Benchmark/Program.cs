using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Eris.Misc.String.HybridString;

namespace Benchmark;

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<Test>();
    }
}

[MemoryDiagnoser(false)]
public class Test
{
    private const string Text1 =
        """
        j4TOjXVbS4XDs12PGwuEL2X8GbWSDrn2wRl3vWYcWBHtpA77g6JAJkeVhrqCdGpV7pjA28nhF6QHrAk94Qn2L9XnEKV9C3IBFGik
        7mOTorr6CZFbVPbnwfyzB1Pgsf8vYApG53yawEKU6l2SgHyNMt0jOU2NhDpThw3m92GhCmnnIErlJnHZrbsVGzFTn9AftTwCO0iv
        omxdLFVAAK0VAZ5iWTmXY7HtOrceQmQnkkYdz50gWqm7DDj7wzINOxpZkmX8gsNo8maraXx7BsqcBUjKlZX0mhwPaQNXmVPQ2buW
        4H7owvy5gUfveCZ9Eci4cdF5nOWhjFyZ0brklVjnwQVmVLync8Crc65gu3moQxNW4Fl9QgAvU52OrqrkrkcAf1qnky04R9dU352w
        nM0ASNABiLVLzM0M2ixVMeIDy9WvNOS7WDSyeYwvPjAhNSdv64c9Pd9955WW9GjmTgh2Rh3SjwXbcWjkmWQ6xIHm3N3PI8bkF4dz
        """;

    private const string Text2 =
        """
        j4TOjXVbS4XDs12PGwuEL2X8GbWSDrn2wRl3vWYcWBHtpA77g6JAJkeVhrqCdGpV7pjA28nhF6QHrAk94Qn2L9XnEKV9C3IBFGik
        7mOTorr6CZFbVPbnwfyzB1Pgsf8vYApG53yawEKU6l2SgHyNMt0jOU2NhDpThw3m92GhCmnnIErlJnHZrbsVGzFTn9AftTwCO0iv
        omxdLFVAAK0VAZ5iWTmXY7HtOrceQmQnkkYdz50gWqm7DDj7wzINOxpZkmX8gsNo8maraXx7BsqcBUjKlZX0mhwPaQNXmVPQ2buW
        4H7owvy5gUfveCZ9Eci4cdF5nOWhjFyZ0brklVjnwQVmVLync8Crc65gu3moQxNW4Fl9QgAvU52OrqrkrkcAf1qnky04R9dU352w
        nM0ASNABiLVLzM0M2ixVMeIDy9WvNOS7WDSyeYwvPjAhNSdv64c9Pd9955WW9GjmTgh2Rh3SjwXbcWjkmWQ6xIHm3N3PI8bkF4d0
        """;

    private static ReadOnlySpan<byte> Text3 =>
        """
        j4TOjXVbS4XDs12PGwuEL2X8GbWSDrn2wRl3vWYcWBHtpA77g6JAJkeVhrqCdGpV7pjA28nhF6QHrAk94Qn2L9XnEKV9C3IBFGik
        7mOTorr6CZFbVPbnwfyzB1Pgsf8vYApG53yawEKU6l2SgHyNMt0jOU2NhDpThw3m92GhCmnnIErlJnHZrbsVGzFTn9AftTwCO0iv
        omxdLFVAAK0VAZ5iWTmXY7HtOrceQmQnkkYdz50gWqm7DDj7wzINOxpZkmX8gsNo8maraXx7BsqcBUjKlZX0mhwPaQNXmVPQ2buW
        4H7owvy5gUfveCZ9Eci4cdF5nOWhjFyZ0brklVjnwQVmVLync8Crc65gu3moQxNW4Fl9QgAvU52OrqrkrkcAf1qnky04R9dU352w
        nM0ASNABiLVLzM0M2ixVMeIDy9WvNOS7WDSyeYwvPjAhNSdv64c9Pd9955WW9GjmTgh2Rh3SjwXbcWjkmWQ6xIHm3N3PI8bkF4d0
        """u8;
    
    private static ReadOnlySpan<byte> Text4 =>
        """
        j4TOjXVbS4XDs12PGwuEL2X8GbWSDrn2wRl3vWYcWBHtpA77g6JAJkeVhrqCdGpV7pjA28nhF6QHrAk94Qn2L9XnEKV9C3IBFGik
        7mOTorr6CZFbVPbnwfyzB1Pgsf8vYApG53yawEKU6l2SgHyNMt0jOU2NhDpThw3m92GhCmnnIErlJnHZrbsVGzFTn9AftTwCO0iv
        omxdLFVAAK0VAZ5iWTmXY7HtOrceQmQnkkYdz50gWqm7DDj7wzINOxpZkmX8gsNo8maraXx7BsqcBUjKlZX0mhwPaQNXmVPQ2buW
        4H7owvy5gUfveCZ9Eci4cdF5nOWhjFyZ0brklVjnwQVmVLync8Crc65gu3moQxNW4Fl9QgAvU52OrqrkrkcAf1qnky04R9dU352w
        nM0ASNABiLVLzM0M2ixVMeIDy9WvNOS7WDSyeYwvPjAhNSdv64c9Pd9955WW9GjmTgh2Rh3SjwXbcWjkmWQ6xIHm3N3PI8bkF4d0
        """u8;

    [Benchmark]
    public bool DefaultStringEqualsTest()
    {
        return string.Equals(Text1, Text2);
    }
    
    [Benchmark]
    public bool ErisStringEqualsU8Test()
    {
        return AnsiComparer.Ordinal.Equals(Text3, Text4);
    }

    [Benchmark]
    public bool ErisStringEqualsTest()
    {
        return AnsiComparer.Ordinal.Equals(Text3, Text1);
    }

    [Benchmark]
    public int DefaultStringGetHashCodeTest()
    {
        return string.GetHashCode(Text2);
    }

    [Benchmark]
    public int ErisStringGetHashCodeU8Test()
    {
        return AnsiComparer.Ordinal.GetHashCode(Text3);
    }

    [Benchmark]
    public int ErisStringGetHashCodeTest()
    {
        return AnsiComparer.Ordinal.GetHashCode(Text2);
    }

    
}

