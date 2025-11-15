using System.Diagnostics;
using System.Reflection;

using AdventOfCode;

Log.Info("Advent of Code by Ketan Tailor");
Log.Info();

try
{
    await MainImpl();
}
catch(Exception ex)
{
    Log.Error(ex.ToString());
}

static async Task MainImpl()
{
    var argsObj = new Args(Environment.GetCommandLineArgs()[1..]);

    if (argsObj.ShowHelp)
    {
        argsObj.WriteHelp();
        return;
    }

    var inputProvider = BuildInputProvider();

    if (argsObj.RunAll)
    {
        for (var year = 2015; year <= DateTime.Now.Year; year++)
        {
            await RunSolutions(inputProvider, year, argsObj.Verify);
        }
    }
    else if (argsObj.Day == null)
    {
        await RunSolutions(inputProvider, argsObj.Year, argsObj.Verify);
    }
    else
    {
        var solution = BuildSolution(argsObj.Year, argsObj.Day.Value);
        if (solution != null)
            await RunSolution(inputProvider, solution, argsObj.Year, argsObj.Day.Value, argsObj.Verify);
    }
}


static async Task RunSolutions(InputProvider inputProvider, int year, bool verify)
{
    for (var day = 1; day <= 24; day++)
    {
        var solution = BuildSolution(year, day);
        if (solution == null) break;
        await RunSolution(inputProvider, solution, year, day, verify);
    }
}

static async Task RunSolution(InputProvider inputProvider, ISolution solution, int year, int day, bool verify)
{
    var input = day > 0 ? await inputProvider.GetInput(year, day) : "";
    var attr = solution.GetType().GetCustomAttribute<AocPuzzleAttribute>()
        ?? throw new InvalidOperationException($"Solution for {year:0000}.{day:00} doesn't have AocPuzzleAttribute set.");

    Log.Write($"{year:0000}.{day:00}:", false);
    Log.Write($" {attr.Name}", ConsoleColor.DarkCyan);

    var stopwatch = Stopwatch.StartNew();

    var result = solution.Solve(input);

    var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

    LogPartResult("Part 1", result.Part1, attr.Solution1, verify);
    LogPartResult("Part 2", result.Part2, attr.Solution2, verify);

    Log.Write($"Completed in {elapsedMilliseconds:n0}ms", ConsoleColor.DarkGray);
    Log.Write();
}

static void LogPartResult(string prefix, string result, string? expected, bool verify)
{
    Log.Write($"  {prefix}: {result}", false);
    if (verify)
    {
        if (result == expected)
        {
            Log.Write(" Passed", ConsoleColor.Green, false);
        }
        else
        {
            Log.Write($" Failed: expected = {expected}", ConsoleColor.Red, false);
            Environment.ExitCode = 1;
        }
    }
    Log.Write("");
}

static ISolution? BuildSolution(int year, int day)
{
    var typeName = $"AdventOfCode.Year{year:0000}.Day{day:00}";
    var instance = typeof(Program).Assembly.CreateInstance(typeName) as ISolution;
    return instance;
}

static InputProvider BuildInputProvider()
{
    var session = Environment.GetEnvironmentVariable("AOC_SESSION")
        ?? throw new ApplicationException("The environment variable AOC_SESSION must be set.");
    var inputProvider = new InputProvider(session);
    return inputProvider;
}