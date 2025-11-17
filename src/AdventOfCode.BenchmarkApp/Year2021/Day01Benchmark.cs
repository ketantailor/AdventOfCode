using AdventOfCode.Core.Year2021;

using BenchmarkDotNet.Attributes;

namespace AdventOfCode.BenchmarkApp.Year2021;

public class Day01Benchmark : SolutionBenchmark
{
    private readonly Day01_Initial _initial = new();
    private readonly Day01_Optimised _optimised = new();

    public Day01Benchmark() : base(2021, 1) { }

    [Benchmark]
    public void Solve_Initial() => _initial.Solve(Input);

    [Benchmark]
    public void Solve_Optimised() => _optimised.Solve(Input);
}
