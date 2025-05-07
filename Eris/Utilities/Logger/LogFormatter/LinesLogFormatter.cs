namespace Eris.Utilities.Logger.LogFormatter;

public class LinesLogFormatter : ILogFormatter<LogMessage>
{    
    public static readonly LinesLogFormatter Instance = new();

    public string Format(in LogMessage logMessage)
    {
        return $"[Eris:{logMessage.Level}] {logMessage.Time:T} > {Format(logMessage.Msg)}";
    }
    public string Format(string logMessage)
    {
        return logMessage.Contains('\n') ? "\n    " + logMessage.Replace(Environment.NewLine, "\n    ") : logMessage;
    }
}