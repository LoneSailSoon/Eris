using System.Text;

namespace Eris.Utilities.Helpers;

public class LogHelper
{
    public static void Log(string message, string title, int lengthMin = 0, ConsoleColor? color = null)
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

    public static void Log(Exception e)
    {
        Log(e.ToString(), "Exception", 20, ConsoleColor.Red);
    }
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