namespace Eris.Utilities.Logger.LogFormatter;

public class DefaultLogFormatter : ILogFormatter<LogMessage>
{
    public static readonly DefaultLogFormatter Instance = new();
    public string Format(in LogMessage logMessage)
    {
        return $"[Eris:{logMessage.Level}] {logMessage.Time:T}s > {logMessage.Msg}";
    }
}