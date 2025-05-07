using Eris.Utilities.Logger.LogFormatter;

namespace Eris.Utilities.Logger.LogHandle;

public interface ILogHandle<TMessage>
{
    public void Log(in TMessage message) => Log(LogFormatter.Format(message));
    
    ILogFormatter<TMessage> LogFormatter { get; }
    
    void Log(string message);

    void LogLine(string message);
}