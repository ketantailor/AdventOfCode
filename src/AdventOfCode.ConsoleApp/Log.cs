namespace AdventOfCode;

internal static class Log
{
    public static void Info(string? line = null)
    {
        Console.WriteLine(line ?? "");
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

    public static void Result(int year, int day, SolutionResult result)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"{year:0000}.{day:00}");
        Console.WriteLine($"\tPart 1: {result.Part1}");
        Console.WriteLine($"\tPart 2: {result.Part2}");
    }

    private static void WriteLine(string line, ConsoleColor color)
    {
        Console.ForegroundColor = color;

        Console.WriteLine(line);

        Console.ResetColor();
    }
}
