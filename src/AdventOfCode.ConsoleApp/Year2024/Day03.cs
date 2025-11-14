using System.Text.RegularExpressions;

namespace AdventOfCode.Year2024;

[AocPuzzle("Mull It Over", Solution1 = "159833790", Solution2 = "89349241")]
internal class Day03 : ISolution
{
    public SolutionResult Solve(string input)
    {
        var part1 = ScanAndRun1(input);
        var part2 = ScanAndRun2(input);
        return new SolutionResult(part1, part2);
    }

    internal static void Test()
    {
        var input1 = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
        Console.WriteLine(ScanAndRun1(input1));

        var input2 = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
        Console.WriteLine(ScanAndRun2(input2));
    }

    private static int ScanAndRun1(string input)
    {
        var mulPattern = @"mul\(\d{1,3},\d{1,3}\)";
        var digitPattern = @"\d{1,3}";

        var matches = Regex.Matches(input, mulPattern);

        var sum = 0;
        foreach (var match in matches)
        {
            var product = Regex
                .Matches(match.ToString() ?? throw new Exception(), digitPattern)
                .Select(m => int.Parse(m.ToString()))
                .Aggregate(1, (acc, i) => acc * i);

            sum += product;
        }

        return sum;
    }
    
    private static int ScanAndRun2(string input)
    {
        var mulPattern = @"mul\(\d{1,3},\d{1,3}\)|do\(\)|don't\(\)";
        var digitPattern = @"\d{1,3}";

        var matches = Regex.Matches(input, mulPattern);

        var sum = 0;
        var include = true;
        foreach (var match in matches)
        {
            if (match.ToString() == "do()") include = true;
            else if (match.ToString() == "don't()") include = false;
            else if (include)
            {

                var product = Regex
                    .Matches(match.ToString() ?? throw new Exception(), digitPattern)
                    .Select(m => int.Parse(m.ToString()))
                    .Aggregate(1, (acc, i) => acc * i);

                sum += product;
            }
        }

        return sum;
    }
}
