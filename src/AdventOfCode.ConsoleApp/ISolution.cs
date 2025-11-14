namespace AdventOfCode;

public interface ISolution
{
    SolutionResult Solve(string input);
}

public class SolutionResult
{
    public string Part1 { get; }
    public string Part2 { get; }

    public SolutionResult(string part1, string part2)
    {
        Part1 = part1;
        Part2 = part2;
    }

    public SolutionResult(int part1, int part2)
    {
        Part1 = part1.ToString();
        Part2 = part2.ToString();
    }

    public SolutionResult(long part1, long part2)
    {
        Part1 = part1.ToString();
        Part2 = part2.ToString();
    }

    public SolutionResult(double part1, double part2)
    {
        Part1 = part1.ToString();
        Part2 = part2.ToString();
    }
}
