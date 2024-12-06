namespace AdventOfCode.Year2022;

[AocPuzzle("Rucksack Reorganization")]
public class Day03 : ISolution
{
    public SolutionResult Solve(string input)
    {
        var lines = input
            .Split('\n')
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .ToArray();
        
        var part1 = CalculatePart1(lines);
        var part2 = CalculatePart2(lines);

        return new SolutionResult(part1.ToString(), part2.ToString());
    }

    private static int CalculatePart1(string[] lines)
    {
        return lines
            .Select(GetCommonType)
            .Select(GetPriority)
            .Sum();
    }

    private static int CalculatePart2(string[] lines)
    {
        var answer = 0;
        for (var i = 0; i < lines.Length; i += 3)
        {
            var badgeType = GetBadgeType(lines[i], lines[i + 1], lines[i + 2]);
            var badgePriority = GetPriority(badgeType);
            answer += badgePriority;
        }
        return answer;
    }

    public static int GetPriority(char c)
    {
        var i = Convert.ToInt32(c);
        switch (i)
        {
            case >= 97 and <= 122:
                return i - 96;
            case >= 65 and <= 91:
                return i - 38;
            default:
                return -1;
        }
    }

    public static char GetCommonType(string rucksack)
    {
        for (var a = 0; a < rucksack.Length / 2; a++)
        {
            for (var b = rucksack.Length / 2; b < rucksack.Length; b++)
            {
                if (rucksack[a] == rucksack[b])
                    return rucksack[a];
            }
        }
        throw new InvalidOperationException($"Rucksack: {rucksack}");
    }

    public static char GetBadgeType(string rucksackA, string rucksackB, string rucksackC)
    {
        for (var a = 0; a < rucksackA.Length; a++)
        {
            for (var b = 0; b < rucksackB.Length; b++)
            {
                if (rucksackA[a] != rucksackB[b])
                    continue;

                for (var c = 0; c < rucksackC.Length; c++)
                {
                    if (rucksackA[a] == rucksackC[c])
                        return rucksackA[a];
                }
            }
        }

        throw new InvalidOperationException($"Rucksacks: {rucksackA}, {rucksackB}, {rucksackC}");
    }
}