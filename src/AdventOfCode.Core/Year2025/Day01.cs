namespace AdventOfCode.Core.Year2025;

[AocPuzzle("Secret Entrance", Solution1 = "1078", Solution2 = "6412")]
internal class Day01 : ISolution
{
    public SolutionResult Solve(string input)
    {
        var rotations = input
            .Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .Select(ParseLine)
            .ToList();

        int part1 = Part1(rotations);
        int part2 = Part2(rotations);

        return new SolutionResult(part1, part2);
    }

    private static int Part1(List<int> rotations)
    {
        var position = 50;
        var pointsAtZeroCount = 0;
        foreach (var rotation in rotations)
        {
            position += rotation;
            while (position >= 100 || position < 0)
            {
                if (position >= 100) position -= 100;
                else if (position < 0) position += 100;
            }

            if (position == 0)
            {
                pointsAtZeroCount++;
            }
        }

        return pointsAtZeroCount;
    }
    
    private static int Part2(List<int> rotations)
    {
        var position = 50;
        var pointsAtZeroCount = 0;
        foreach (var rotation in rotations)
        {
            var prev = position;
            position += rotation;


            if (position == 0)
            {
                pointsAtZeroCount++;
                continue;
            }

            if ((prev < 0 && position > 0) || (prev > 0 && position < 0))
            {
                pointsAtZeroCount++;
            }

            while (position >= 100 || position <= -100)
            {
                if (position >= 100)
                {
                    position -= 100;
                    pointsAtZeroCount++;
                }
                else if (position <= -100)
                {
                    position += 100;
                    pointsAtZeroCount++;
                }
            }
        }

        return pointsAtZeroCount;
    }

    private int ParseLine(string line)
    {
        var multiplier = line[0] == 'R' ? 1 : -1;
        var value = int.Parse(line[1..]);
        return multiplier * value;
    }
}
