using AdventOfCode.Core;

using BenchmarkDotNet.Attributes;

namespace AdventOfCode.BenchmarkApp.Year2021;

public class Day02Benchmark : SolutionBenchmark
{
    private readonly ISolution _initial = new AdventOfCode.Core.Year2021.Day02_Initial();
    private readonly ISolution _optimised = new AdventOfCode.Core.Year2021.Day02_Optimised();

    public Day02Benchmark() : base(2021, 2) { }

    [Benchmark]
    public void Solve_Initial() => _initial.Solve(Input);

    [Benchmark]
    public void Solve_Optimised() => _optimised.Solve(Input);
}
