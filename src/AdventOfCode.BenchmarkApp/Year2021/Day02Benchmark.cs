using AdventOfCode.Core.Year2021;

using BenchmarkDotNet.Attributes;

namespace AdventOfCode.BenchmarkApp.Year2021;

public class Day02Benchmark : SolutionBenchmark
{
    private readonly Day02_Initial _initial = new();
    private readonly Day02_Optimised _optimised = new();

    public Day02Benchmark() : base(2021, 2) { }

    [Benchmark]
    public void Solve_Initial() => _initial.Solve(Input);

    [Benchmark]
    public void Solve_Optimised() => _optimised.Solve(Input);
}
