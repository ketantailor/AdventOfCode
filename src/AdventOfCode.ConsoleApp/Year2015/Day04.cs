using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Year2015;

[AocPuzzle("The Ideal Stocking Stuffer", Solution1 = "346386", Solution2 = "9958218")]
internal class Day04 : ISolution
{
    public SolutionResult Solve(string input)
    {
        input = input.Trim();
        var part1 = FindFiveZeros(input);
        var part2 = FindSixZeros(input);
        return new SolutionResult(part1, part2);
    }

    private static int FindFiveZeros(string key)
    {
        using var hashProvider = MD5.Create();
        for (var i = 0; i < int.MaxValue; i++)
        {
            var contentAsBytes = ASCIIEncoding.ASCII.GetBytes($"{key}{i}");
            var hashAsBytes = hashProvider.ComputeHash(contentAsBytes);
            if (hashAsBytes[0] == 0x00
                && hashAsBytes[1] == 0x00
                && hashAsBytes[2] < 0x10)
            {
                return i;
            }
        }

        return int.MinValue;
    }

    private static int FindSixZeros(string key)
    {
        using var hashProvider = MD5.Create();
        for (var i = 0; i < int.MaxValue; i++)
        {
            var contentAsBytes = ASCIIEncoding.ASCII.GetBytes($"{key}{i}");
            var hashAsBytes = hashProvider.ComputeHash(contentAsBytes);
            if (hashAsBytes[0] == 0x00
                && hashAsBytes[1] == 0x00
                && hashAsBytes[2] == 0x00)
            {
                return i;
            }
        }

        return int.MinValue;
    }
}