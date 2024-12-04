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

    var session = argsObj.Session ?? throw new ApplicationException("Session must be specified.");
    var inputProvider = new InputProvider(session);

    var input = argsObj.Day > 0 ? await inputProvider.GetInput(argsObj.Year, argsObj.Day) : "";
    var solution = GetSolution(argsObj.Year, argsObj.Day);

    Log.Info($"{argsObj.Year:0000}.{argsObj.Day:00}: {GetSolutionName(solution)}");

    var stopwatch = Stopwatch.StartNew();

    var result = solution.Solve(input);

    Log.Info($"\tResult: {result}");

    Log.Info($"Completed in {stopwatch.ElapsedMilliseconds:n0}ms");
}

static ISolution GetSolution(int year, int day)
{
    var typeName = $"AdventOfCode.Year{year:0000}.Day{day:00}";
    var instance = typeof(Program).Assembly.CreateInstance(typeName) as ISolution
        ?? throw new InvalidOperationException($"Failed to create type: {typeName}.");
    return instance;
}

static string GetSolutionName(ISolution solution)
{
    return solution.GetType()
        .GetCustomAttribute<AocPuzzleAttribute>()
        ?.Name ?? "";
}