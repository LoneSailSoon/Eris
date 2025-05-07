using System.Runtime.InteropServices;
using System.Text;
using Eris.Utilities.Logger.LogFormatter;
using Eris.Utilities.Logger.LogHandle;
using Eris.Utilities.Logger.LogHandlersManager;
using PatcherYrSharp.Helpers;

namespace Eris.Utilities.Logger;

public static class Logger
{
    public static void Log(string message)
    {
        Log(message, "Info", 20);
        foreach (var handlr in LogHandlesManager.Handles)
            handlr.LogLine(handlr.LogFormatter.Format(new(DateTime.Now, LogLevel.Info, message)));
    }
    
    public static void LogException(Exception e)
    {
        var message = e.ToString();
        Log(message, "Exception", 20, ConsoleColor.Red);
        foreach (var handle in LogHandlesManager.Handles)
            handle.LogLine(handle.LogFormatter.Format(new(DateTime.Now, LogLevel.Error, message)));
    }

    public static void Log(string message, LogLevel level)
    {
        Log(message, level.ToString(),20,
            level switch
            {
                LogLevel.Warning => ConsoleColor.Yellow,
                LogLevel.Error => ConsoleColor.Red,
                _=> ConsoleColor.Gray
            });
        
        foreach (var handlr in LogHandlesManager.Handles)
            handlr.LogLine(handlr.LogFormatter.Format(new(DateTime.Now, level, message)));
    }
    
    private static void Log(string message, string title, int lengthMin = 0, ConsoleColor? color = null)
    {
        var oldColor = Console.ForegroundColor;
        if (color != null)
        {
            Console.ForegroundColor = color.Value;
        }


        var lines = message.Split(Environment.NewLine);


        var length = lines.Max(x => x.Length);
        var titleLength = title.Length;
        length = Math.Max(length, titleLength + 2);
        length = Math.Max(length, lengthMin);


        Console.WriteLine($"\u250c\u2500\u2500 {title}{new string('\u2500', length - titleLength - 2)}\u2500\u2510 ");
        foreach (var line in lines)
        {
            Console.Write("\u2502 ");
            Console.ForegroundColor = oldColor;
            Console.Write($"{line}{new(' ', length - line.Length + 1)}");
            if (color != null)
            {
                Console.ForegroundColor = color.Value;
            }

            Console.WriteLine("\u2502 ");
        }

        Console.WriteLine($"\u2514\u2500{new string('\u2500', length)}\u2500\u2518 ");

        Console.ForegroundColor = oldColor;
    }


    private static readonly DefaultLogHandlesManager LogHandlesManager = new(new FileLogHandler(LinesLogFormatter.Instance));
}

public static class TreeDisplayHelper
{
    public static StringBuilder AppendTreeLeaf(this StringBuilder sb, string linePrefix, string text)
    {
        sb
            .Append(linePrefix)
            .Append('\u251c')
            .Append($"\u2500\u2500 {text}")
            .Append(Environment.NewLine);
        return sb;
    }
    public static StringBuilder AppendTreeLine(this StringBuilder sb, string linePrefix, string text)
    {
        sb
            .Append(linePrefix)
            .Append('\u2502')
            .Append($"   {text}")
            .Append(Environment.NewLine);
        return sb;
    }
    public static StringBuilder AppendTreeLeafLast(this StringBuilder sb, string linePrefix, string text)
    {
        sb
            .Append(linePrefix)
            .Append('\u2514')
            .Append($"\u2500\u2500 {text}")
            .Append(Environment.NewLine);
        return sb;
    }
    public static StringBuilder AppendTreeLineLast(this StringBuilder sb, string linePrefix, string text)
    {
        sb
            .Append(linePrefix)
            .Append($"    {text}")
            .Append(Environment.NewLine);
        return sb;
    }


    public static string GetNextPrefix(string linePrefix) => linePrefix + "\u2502   ";
    public static string GetNextPrefixLast(string linePrefix) => linePrefix + "    ";
}