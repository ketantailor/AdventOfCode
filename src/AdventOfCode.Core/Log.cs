namespace AdventOfCode.Core;

public static class Log
{
    public static void Info(string? line = null, bool newLine = true)
    {
        if (newLine)
        {
            Console.WriteLine(line ?? "");
        }
        else
        {
            Console.Write(line ?? "");
        }
    }

    public static void Debug(string line, bool newLine = true)
    {
        Write(line, ConsoleColor.DarkGray, newLine);
    }

    public static void Warn(string line)
    {
        Write(line, ConsoleColor.Yellow);
    }

    public static void Error(string line)
    {
        Write(line, ConsoleColor.Red);
    }

    public static void Write()
    {
        Write("");
    }

    public static void Write(string line, bool newLine = true)
    {
        if (newLine)
            Console.WriteLine(line);
        else
            Console.Write(line);
    }

    public static void Write(string line, ConsoleColor color, bool newLine = true)
    {
        Console.ForegroundColor = color;

        if (newLine)
            Console.WriteLine(line);
        else
            Console.Write(line);

        Console.ResetColor();
    }
}