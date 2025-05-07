namespace Eris.Utilities.Logger;

public record struct LogMessage(DateTime Time, LogLevel Level, string Msg);