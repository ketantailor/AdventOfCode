namespace AdventOfCode.Year2024;

[AocPuzzle("Historian Hysteria")]
internal class Day01 : ISolution
{
    public SolutionResult Solve(string input)
    {
        var part1 = CalculateTotalDistance(input);
        var part2 = CalculateSimilarityScore(input);
        return new SolutionResult(part1.ToString(), part2.ToString());
    }

    private static int CalculateTotalDistance(string input)
    {
        var left = new List<int>();
        var right = new List<int>();

        foreach (var line in input.Split('\n').Where(s => !string.IsNullOrWhiteSpace(s)))
        {
            var split = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            left.Add(int.Parse(split[0]));
            right.Add(int.Parse(split[1]));
        }

        left.Sort();
        right.Sort();

        var sum = 0;
        for (var i = 0; i < left.Count; i++)
        {
            sum += Math.Abs(left[i] - right[i]);
        }

        return sum;
    }

    private static int CalculateSimilarityScore(string input)
    {
        var left = new List<int>();
        var right = new List<int>();

        foreach (var line in input.Split('\n').Where(s => !string.IsNullOrWhiteSpace(s)))
        {
            var split = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            left.Add(int.Parse(split[0]));
            right.Add(int.Parse(split[1]));
        }

        var rightGroup = right
            .GroupBy(i => i)
            .ToDictionary(g => g.Key);

        var score = 0;
        for (var i = 0; i < left.Count; i++)
        {
            var leftInt = left[i];
            var rightCount = rightGroup.TryGetValue(leftInt, out IGrouping<int, int>? value) ? value.Count() : 0;
            score += leftInt * rightCount;
        }

        return score;
    }

    internal static void Test()
    {
        const string input = """
            3   4
            4   3
            2   5
            1   3
            3   9
            3   3
            """;

        Console.WriteLine(CalculateTotalDistance(input));
        Console.WriteLine(CalculateSimilarityScore(input));
    }
}
