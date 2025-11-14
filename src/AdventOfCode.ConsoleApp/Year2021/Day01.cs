namespace AdventOfCode.Year2021;

[AocPuzzle("Sonar Sweep", Solution1 = "1532", Solution2 = "1571")]
internal class Day01 : ISolution
{
    public SolutionResult Solve(string input)
    {
        var lines = input
            .Split('\n')
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(s => s.Trim())
            .ToArray();

        var part1 = SolvePart1(lines);
        var part2 = SolvePart2(lines);
        return new SolutionResult(part1.ToString(), part2.ToString());
    }

    private static int SolvePart1(string[] lines)
    {
        var depths = lines.Select(int.Parse).ToArray();

        var increased = 0;

        for (var i = 1; i < depths.Length; i++)
        {
            if (depths[i] > depths[i - 1])
                increased++;
        }

        return increased;
    }

    private static int SolvePart2(string[] lines)
    {
        var depths = lines.Select(int.Parse).ToArray();

        var increased = 0;

        for (var i = 1; i < depths.Length - 2; i++)
        {
            var prevSum = depths[i - 1];
            var currSum = depths[i + 2];
            if (currSum > prevSum)
                increased++;
        }

        return increased;
    }
}
