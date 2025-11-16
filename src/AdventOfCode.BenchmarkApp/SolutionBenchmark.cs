using AdventOfCode.Core;

using BenchmarkDotNet.Attributes;

public abstract class SolutionBenchmark : IDisposable
{
    private readonly int _year;
    private readonly int _day;
    private readonly InputProvider _inputProvider;

    protected SolutionBenchmark(int year, int day)
    {
        _year = year;
        _day = day;
        _inputProvider = InputProvider.CreateFromEnvironmentVariable();
    }

    protected string Input { get; private set; } = string.Empty;

    [GlobalSetup]
    public async Task Setup()
    {
        Input = await _inputProvider.GetInput(_year, _day);
    }

    public void Dispose()
    {
        _inputProvider.Dispose();
    }
}
