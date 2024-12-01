namespace AdventOfCode.Year2022;

[AocSolution("Camp Cleanup")]
public class Day04 : ISolution
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
        var answer = lines
            .Select(ParseToRange)
            .Where(rs => IsFullyContained(rs[0], rs[1]))
            .Count();

        return answer;
    }

    private static int CalculatePart2(string[] lines)
    {
        var answer = lines
            .Select(ParseToRange)
            .Where(rs =>
            {
                var r1 = DoesOverlap(rs[0], rs[1]);
                var r2 = DoesOverlap(rs[1], rs[0]);
                if (r1 != r2) Console.WriteLine(rs[0] + " " + rs[1]);
                return DoesOverlap(rs[0], rs[1]);
            })
            .Count();

        return answer;
    }

    public static Range[] ParseToRange(string s)
    {
        return s.Split(',')
            .Select(r =>
            {
                var rParts = r.Split('-');
                var start = int.Parse(rParts[0]);
                var end = int.Parse(rParts[1]);
                return new Range(start, end);
            })
            .ToArray();
    }

    public static bool IsFullyContained(Range a, Range b)
    {
        return (a.Start <= b.Start && a.End >= b.End)
            || (a.Start >= b.Start && a.End <= b.End);
    }

    public static bool DoesOverlap(Range a, Range b)
    {
        return (b.Start >= a.Start && b.Start <= a.End)
            || (b.End >= a.Start && b.End <= a.End)
            || IsFullyContained(a, b);
    }

    public record Range(int Start, int End);

}