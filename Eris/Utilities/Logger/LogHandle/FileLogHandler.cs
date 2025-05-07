using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.Utilities.Logger.LogFormatter;
using PatcherYrSharp.Helpers;

namespace Eris.Utilities.Logger.LogHandle;

public class FileLogHandler(ILogFormatter<LogMessage>? formatter = null) : ILogHandle<LogMessage>
{
    public static readonly FileLogHandler Instance = new();
    public ILogFormatter<LogMessage> LogFormatter { get; } = formatter ?? DefaultLogFormatter.Instance;
    public void Log(string message)
    {
        using var anis = new AnsiStringSpan($"{message}");
        
        Registers r = default;
        TempStack stack = default;
        stack.Format = anis;
        r.ESP = (uint)stack.GetThisPointer();
        Debug_Log(r.GetThisPointer());
    }

    public void LogLine(string message)
    {
        //using var format = new AnsiStringSpan("%s\n");

        nint format;
        unsafe
        {
            format = (nint)Unsafe.AsPointer(ref MemoryMarshal.GetReference("%s\n"u8));
        }
        
        using var data = new AnsiStringSpan($"{message}");
        
        Registers r = default;
        TempStack stack = default;
        stack.Format = format;
        stack.Arg = data;
        
        r.ESP = (uint)stack.GetThisPointer();
        Debug_Log(r.GetThisPointer());
    }
    
    [StructLayout(LayoutKind.Sequential)]
    private struct TempStack
    {
        private int align;
        public nint Format;
        public nint Arg;
    }
    
    [DllImport("Ares.dll")]
    private static extern uint Debug_Log(nint r);
}