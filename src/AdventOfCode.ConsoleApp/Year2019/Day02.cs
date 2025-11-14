namespace AdventOfCode.Year2019;

[AocPuzzle("1202 Program Alarm", Solution1 = "10566835", Solution2 = "2347")]
internal class Day02 : ISolution
{
    public SolutionResult Solve(string input)
    {
        var part1 = SolvePart1(input);
        var part2 = SolvePart2(input);
        return new SolutionResult(part1, part2);
    }

    private static int SolvePart1(string input)
    {
        var codes = input.Split(',').Select(int.Parse).ToArray();
        codes[1] = 12;
        codes[2] = 2;
        var processedCodes = Execute(codes);
        return processedCodes.First();
    }

    private static int SolvePart2(string input)
    {
        for (var noun = 0; noun <= 99; noun++)
        {
            for (var verb = 0; verb <= 99; verb++)
            {
                var codes = input.Split(',').Select(int.Parse).ToArray();
                codes[1] = noun;
                codes[2] = verb;
                var processedCodes = Execute(codes);
                if (processedCodes[0] == 19690720)
                {
                    var answer = 100 * noun + verb;
                    return answer;
                }
            }
        }
        throw new InvalidOperationException();
    }

    private static string Execute(string codesAsString)
    {
        var codes = codesAsString.Split(',').Select(int.Parse).ToArray();
        codes = Execute(codes);
        return ToString(codes);
    }

    private static int[] Execute(int[] codes)
    {
        for (var ip = 0; ip < codes.Length; ip++)
        {
            // add
            if (codes[ip] == 1)
            {
                var val1 = codes[codes[ip + 1]];
                var val2 = codes[codes[ip + 2]];
                codes[codes[ip + 3]] = val1 + val2;
                ip += 3;
                continue;
            }

            // multiply
            else if (codes[ip] == 2)
            {
                var val1 = codes[codes[ip + 1]];
                var val2 = codes[codes[ip + 2]];
                codes[codes[ip + 3]] = val1 * val2;
                ip += 3;
                continue;
            }

            // exit
            else if (codes[ip] == 99)
            {
                break;
            }

            // error
            else
            {
                break;
            }
        }
        return codes;
    }

    private static string ToString(int[] codes)
    {
        return string.Join(',', codes.Select(i => i.ToString()));
    }
}
