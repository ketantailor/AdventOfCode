namespace AdventOfCode.Year2024;

[AocPuzzle("Red-Nosed Reports", Solution1 = "242", Solution2 = "311")]
internal class Day02 : ISolution
{
    public SolutionResult Solve(string input)
    {
        var lines = input
            .Split('\n')
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(s => s.Trim())
            .ToArray();

        var part1 = lines.Where(CheckIsSafe).Count();
        var part2 = lines.Where(CheckIsSafeDampened).Count();
        return new SolutionResult(part1, part2);
    }

    internal static void Test1()
    {
        var input = """
            7 6 4 2 1
            1 2 7 8 9
            9 7 6 2 1
            1 3 2 4 5
            8 6 4 4 1
            1 3 6 7 9
            """;

        var result = new Day02().Solve(input);
        Console.WriteLine(result);
    }

    private static bool CheckIsSafe(string line)
    {
        var values = line
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        return CheckIsSafe(values);
    }

    private static bool CheckIsSafeDampened(string line)
    {
        var values = line
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        if (CheckIsSafe(values)) return true;

        for (var i = 0; i < values.Length; i++)
        {
            var values2 = values.ToList();
            values2.RemoveAt(i);
            if (CheckIsSafe(values2.ToArray()))
                return true;
        }

        return false;
    }

    private static bool CheckIsSafe(int[] values)
    {
        bool? increasing = null;

        for (var i = 1; i < values.Length; i++)
        {
            var increase = values[i] > values[i - 1];
            if (increasing == null)
            {
                increasing = increase;
            }
            else if (increasing != increase)
            {
                return false;
            }

            var diff = Math.Abs(values[i] - values[i - 1]);
            if (diff < 1 || diff > 3)
            {
                return false;
            }
        }

        return true;
    }
}
