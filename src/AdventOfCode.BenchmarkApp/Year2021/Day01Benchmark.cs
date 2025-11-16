using AdventOfCode.Core;

using BenchmarkDotNet.Attributes;

namespace AdventOfCode.BenchmarkApp.Year2021;

public class Day01Benchmark : SolutionBenchmark
{
    private readonly ISolution _initial = new AdventOfCode.Core.Year2021.Day01_Initial();
    private readonly ISolution _optimised = new AdventOfCode.Core.Year2021.Day01_Optimised();

    public Day01Benchmark() : base(2021, 1) { }

    [Benchmark]
    public void Solve_Initial() => _initial.Solve(Input);

    [Benchmark]
    public void Solve_Optimised() => _optimised.Solve(Input);
}
