using Eris.Utilities.Logger.LogFormatter;

namespace Eris.Utilities.Logger.LogHandle;

public class ConsoleLogHandle(ILogFormatter<LogMessage>? formatter = null) : ILogHandle<LogMessage>
{    
    public static readonly ConsoleLogHandle Instance = new();

    public ILogFormatter<LogMessage> LogFormatter { get; } = formatter ?? DefaultLogFormatter.Instance;
    public void Log(string message)
    {
        Console.Write(message);
    }

    public void LogLine(string message)
    {
        Console.WriteLine(message);
    }
}