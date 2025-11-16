namespace AdventOfCode.Core.Year2022;

[AocPuzzle("Tuning Trouble", Solution1 = "1210", Solution2 = "3476")]
public class Day06 : ISolution
{
    public SolutionResult Solve(string input)
    {
        var part1 = FindStartOfMarker(input, 4);
        var part2 = FindStartOfMarker(input, 14);
        return new SolutionResult(part1, part2);
    }

    private static int FindStartOfMarker(string input, int markerLength)
    {
        for (var i = markerLength; i < input.Length; i++)
        {
            if (IsUnique(input.Substring(i-markerLength, markerLength)))
            {
                return i;
            }
        }

        return 0;
    }

    private static bool IsUnique(string input)
    {
        var set = new HashSet<char>();
        foreach (var c in input)
        {
            if (set.Contains(c)) 
                return false;
            set.Add(c);
        }
        return true;
    }

    internal static void Test1()
    {
        var examples = new[] {
            "mjqjpqmgbljsphdztnvjfqwrcgsmlb",
            "bvwbjplbgvbhsrlpgdmjqwftvncz",
            "nppdvjthqldpwncqszvftbrmjlhg",
            "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg",
            "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw",
        };

        foreach (var example in examples)
        {
            Console.WriteLine($"{example} - {FindStartOfMarker(example, 4)}, {FindStartOfMarker(example, 14)}");
        }
    }
}