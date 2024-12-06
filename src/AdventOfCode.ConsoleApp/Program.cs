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

    if (argsObj.Day == null)
    {
        await RunSolutions(inputProvider, argsObj.Year, argsObj.Verify);
    }
    else
    {
        await RunSolution(inputProvider, argsObj.Year, argsObj.Day.Value, argsObj.Verify);
    }
}


static async Task RunSolutions(InputProvider inputProvider, int year, bool verify)
{
    try
    {
        for (var day = 0; day <= 24; day++)
        {
            await RunSolution(inputProvider, year, day, verify);
        }
    }
    catch (InvalidOperationException)
    {
        // do nothing
    }
}

static async Task RunSolution(InputProvider inputProvider, int year, int day, bool verify)
{
    var solution = BuildSolution(year, day);
    var input = day > 0 ? await inputProvider.GetInput(year, day) : "";

    Log.Info($"{year:0000}.{day:00}: {GetSolutionName(solution)} ", false);

    var stopwatch = Stopwatch.StartNew();

    var result = solution.Solve(input);

    Log.Info($"--> Part1 = {result.Part1}, Part2 = {result.Part2} (completed in {stopwatch.ElapsedMilliseconds:n0}ms)", false);
    Log.Info();

    if (verify)
    {
        var attr = solution.GetType().GetCustomAttribute<AocPuzzleAttribute>();
        if (attr?.Solution1 != null)
        {
            Console.Write("\tPart1: ");
            if (result.Part1 == attr.Solution1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Passed");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Failed: expected = {attr.Solution1}, actual = {result.Part1}");
                Console.ResetColor();
            }
        }
        if (attr?.Solution2 != null)
        {
            Console.Write("\tPart2: ");
            if (result.Part2 == attr.Solution2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Passed");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Failed: expected = {attr.Solution2}, actual = {result.Part2}");
                Console.ResetColor();
            }
        }
    }

}

static ISolution BuildSolution(int year, int day)
{
    var typeName = $"AdventOfCode.Year{year:0000}.Day{day:00}";
    var instance = typeof(Program).Assembly.CreateInstance(typeName) as ISolution
        ?? throw new InvalidOperationException($"Failed to create type: {typeName}.");
    return instance;
}

static InputProvider BuildInputProvider()
{
    var session = Environment.GetEnvironmentVariable("AOC_SESSION")
        ?? throw new ApplicationException("The environment variable AOC_SESSION must be set.");
    var inputProvider = new InputProvider(session);
    return inputProvider;
}

static string GetSolutionName(ISolution solution)
{
    return solution.GetType()
        .GetCustomAttribute<AocPuzzleAttribute>()
        ?.Name ?? "";
}