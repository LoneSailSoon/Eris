namespace Eris.Utilities.Logger.LogFormatter;

public interface ILogFormatter<TMessage>
{
    string Format(in TMessage logMessage);
}