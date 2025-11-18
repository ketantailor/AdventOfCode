
namespace AdventOfCode.Core.Year2021;

[AocPuzzle("The Treachery of Whales", Solution1 = "342534", Solution2 = "94004208")]
internal class Day07 : ISolution
{
    public SolutionResult Solve(string input)
    {
        var positions = input.Split(',').Select(int.Parse).ToArray();

        var part1 = Enumerable.Range(positions.Min(), positions.Max())
            .Select(r => Score1(positions, r))
            .Min();

        var part2 = Enumerable.Range(positions.Min(), positions.Max())
            .Select(r => Score2(positions, r))
            .Min();

        return new SolutionResult(part1, part2);
    }

    private static int Score1(int[] ints, int ave)
    {
        var score = ints
            .Select(i => Math.Abs(i - ave))
            .Sum();
        return score;
    }

    private static int Score2(int[] ints, int ave)
    {
        var score = ints
            .Select(i => Triangle(Math.Abs(i - ave)))
            .Sum();
        return score;
    }

    private static int Triangle(int i)
    {
        return i * (i + 1) / 2;
    }
}
