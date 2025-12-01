using AdventOfCode.Core.Year2025;

using BenchmarkDotNet.Attributes;

namespace AdventOfCode.BenchmarkApp.Year2025;

public class Day01Benchmark : SolutionBenchmark
{
    private readonly Day01_Initial _initial = new();
    private readonly Day01_Optimised _optimised = new();

    public Day01Benchmark() : base(2025, 1) { }

    [Benchmark]
    public void Solve_Initial() => _initial.Solve(Input);

    [Benchmark]
    public void Solve_Optimised() => _optimised.Solve(Input);
}
