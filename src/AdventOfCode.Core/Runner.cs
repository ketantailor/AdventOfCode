using System.Diagnostics;
using System.Reflection;

namespace AdventOfCode.Core;

public class Runner
{
    private readonly InputProvider _inputProvider;

    public Runner(InputProvider inputProvider)
    {
        _inputProvider = inputProvider;
    }

    public async Task RunAll(bool verify)
    {
        for (var year = 2015; year <= DateTime.Now.Year; year++)
        {
            await Run(year, null, verify);
        }
    }

    public async Task Run(int year, int? day, bool verify)
    {
        if (day.HasValue)
        {
            var solution = BuildSolution(year, day.Value);
            if (solution == null)
            {
                Log.Warn($"Solution {year:0000}.{day:00} not found.");
            }
            else
            {
                await RunSolution(solution, year, day.Value, verify);
            }
        }
        else
        {
            for (var d = 1; d <= 24; d++)
            {
                var solution = BuildSolution(year, d);
                if (solution == null) break;
                await RunSolution(solution, year, d, verify);
            }
        }
    }

    private async Task RunSolution(ISolution solution, int year, int day, bool verify)
    {
        var input = day > 0 ? await _inputProvider.GetInput(year, day) : "";
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

    private static void LogPartResult(string prefix, string result, string? expected, bool verify)
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

    private static ISolution? BuildSolution(int year, int day)
    {
        var typeName = $"AdventOfCode.Core.Year{year:0000}.Day{day:00}";
        var instance = typeof(Runner).Assembly.CreateInstance(typeName) as ISolution;
        return instance;
    }
}