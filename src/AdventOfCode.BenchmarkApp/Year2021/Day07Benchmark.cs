using AdventOfCode.Core.Year2021;

using BenchmarkDotNet.Attributes;

namespace AdventOfCode.BenchmarkApp.Year2021;

public class Day07Benchmark : SolutionBenchmark
{
    private readonly Day07_Initial _initial = new();
    private readonly Day07_Optimised _optimised = new();

    public Day07Benchmark() : base(2021, 7) { }

    [Benchmark]
    public void Solve_Initial() => _initial.Solve(Input);

    [Benchmark]
    public void Solve_Optimised() => _optimised.Solve(Input);
}
