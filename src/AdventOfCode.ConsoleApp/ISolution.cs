namespace AdventOfCode;

public interface ISolution
{
    SolutionResult Solve(string input);
}

public record SolutionResult(string Part1, string Part2);
