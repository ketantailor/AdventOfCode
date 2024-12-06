namespace AdventOfCode;

internal static class Log
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

    public static void Debug(string line)
    {
        WriteLine(line, ConsoleColor.DarkGray);
    }

    public static void Warn(string line)
    {
        WriteLine(line, ConsoleColor.Yellow);
    }

    public static void Error(string line)
    {
        WriteLine(line, ConsoleColor.Red);
    }

    private static void WriteLine(string line, ConsoleColor color)
    {
        Console.ForegroundColor = color;

        Console.WriteLine(line);

        Console.ResetColor();
    }
}
