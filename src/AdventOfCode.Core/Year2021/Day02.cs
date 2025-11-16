namespace AdventOfCode.Core.Year2021;

[AocPuzzle("Dive!", Solution1 = "1924923", Solution2 = "1982495697")]
internal class Day02 : ISolution
{
    public SolutionResult Solve(string input)
    {
        var lines = input
            .Split('\n')
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(s => s.Trim())
            .ToArray();

        var hpos = 0;
        var depth1 = 0;
        var depth2 = 0;
        var aim = 0;

        for (var i = 0; i < lines.Length; i++)
        {
            var split = lines[i].Split(" ");
            var instruction = split[0];
            var value = int.Parse(split[1]);
            switch (instruction)
            {
                case "forward":
                    hpos += value;
                    depth2 += aim * value;
                    break;
                case "down":
                    depth1 += value;
                    aim += value;
                    break;
                case "up":
                    depth1 -= value;
                    aim -= value;
                    break;
            }
        }

        var sum1 = hpos * depth1;
        var sum2 = hpos * depth2;

        return new SolutionResult(sum1, sum2);
    }
}
