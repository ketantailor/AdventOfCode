using System.Runtime.CompilerServices;

namespace AdventOfCode.Core.Year2021;

[AocPuzzle("The Treachery of Whales", Solution1 = "342534", Solution2 = "94004208")]
public class Day07 : Day07_Optimised { }

public class Day07_Initial : ISolution
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

public class Day07_Optimised : ISolution
{
    public SolutionResult Solve(string input)
    {
        var positions = new List<int>(input.Length/3);
        var idx = 0;
        var min = int.MaxValue;
        var max = int.MinValue;
        while (idx < input.Length) { 
            var p = Utils.ReadNextInt(input, ref idx);
            positions.Add(p);
            idx++;  // skip comma
            if (p < min) min = p;
            if (p > max) max = p;
        }

        var part1 = Enumerable.Range(min, max)
            .Select(r => Score1(positions, r))
            .Min();

        var part2 = Enumerable.Range(min, max)
            .Select(r => Score2(positions, r))
            .Min();

        return new SolutionResult(part1, part2);
    }

    private static int Score1(IList<int> ints, int desiredPosition)
    {
        var sum = 0;
        for (var i = 0; i < ints.Count; i++)
        {
            var fuel = Math.Abs(ints[i] - desiredPosition);
            sum += fuel;
        }

        return sum;
    }

    private static int Score2(IList<int> ints, int desiredPosition)
    {
        var sum = 0;
        for (var i = 0; i < ints.Count; i++)
        {
            var distance = Math.Abs(ints[i] - desiredPosition);
            var fuel = Triangle(distance);
            sum += fuel;
        }

        return sum;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int Triangle(int i)
    {
        return i * (i + 1) / 2;
    }
}
