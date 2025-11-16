namespace AdventOfCode.Core.Year2021;

[AocPuzzle("Sonar Sweep", Solution1 = "1532", Solution2 = "1571")]
public class Day01 : Day01_Optimised { }

public class Day01_Initial : ISolution
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
        return new SolutionResult(part1, part2);
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
            // compare the entering element of the new 3-measurement window
            // with the leaving element of the previous window
            var prevDepth = depths[i - 1];
            var nextDepth = depths[i + 2];
            if (nextDepth > prevDepth)
                increased++;
        }

        return increased;
    }
}

public class Day01_Optimised : ISolution
{
    public SolutionResult Solve(string input)
    {
        var part1 = 0;
        var part2 = 0;

        var a = 0;
        var b = 0;
        var c = 0;
        var d = 0;

        var iteration = 0;
        var index = 0;

        while (index < input.Length)
        {
            a = b;
            b = c;
            c = d;
            d = Utils.ReadNextInt(input, ref index);
            if (d < 0)  // no more ints to read
                break;

            if (iteration > 0)
            {
                if (d > c)
                    part1++;
            }

            if (iteration > 2)
            {
                if (d > a)  // same as (a+b+c) > (b+c+d)
                    part2++;
            }

            iteration++;
        }

        return new SolutionResult(part1, part2);
    }
}