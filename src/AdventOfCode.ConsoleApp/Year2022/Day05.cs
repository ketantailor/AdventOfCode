namespace AdventOfCode.Year2022;

[AocPuzzle("Supply Stacks", Solution1 = "BSDMQFLSP", Solution2 = "PGSQBFLDP")]
public class Day05 : ISolution
{
    public SolutionResult Solve(string input)
    {
        var lines = input.Split('\n').ToArray();
        var part1 = ParseStacksAndExecuteMoves(lines, false);
        var part2 = ParseStacksAndExecuteMoves(lines, true);
        return new SolutionResult(part1, part2);
    }

    private static string ParseStacksAndExecuteMoves(string[] lines, bool moveMultipleCrates)
    {
        var stackNameIndex = 0;
        var stackCount = 0;

        // determine number of stacks
        for (var i = 0; i < lines.Length; i++)
        {
            if (lines[i].Trim().StartsWith("1"))
            {
                stackNameIndex = i;
                stackCount = lines[i].Count(char.IsDigit);
                break;
            }
        }

        // create stacks
        var stacks = Enumerable
            .Range(0, stackCount)
            .Select(i => new List<string>(stackNameIndex))
            .ToArray();

        // populate stacks
        for (var i = 0; i < stackNameIndex; i++)
        {
            for (var s = 0; s < stackCount; s++)
            {
                var crateIdx = (s + 1) * 4 - 3;
                var crate = lines[i].Length > crateIdx ? lines[i][crateIdx] : ' ';
                if (crate != ' ')
                    stacks[s].Insert(0, crate.ToString());
            }
        }

        // execute moves
        for (var i = stackNameIndex + 2; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue;

            var split = lines[i].Split(' ');
            var stacksToMove = int.Parse(split[1]);
            var src = int.Parse(split[3]);
            var dst = int.Parse(split[5]);

            var srcStack = stacks[src - 1];
            var dstStack = stacks[dst - 1];

            if (!moveMultipleCrates)
            {
                for (var j = 0; j < stacksToMove; j++)
                {
                    var crate = srcStack[srcStack.Count - 1];
                    dstStack.Add(crate);
                    srcStack.RemoveAt(srcStack.Count - 1);
                }
            }
            else
            {
                var crates = srcStack.GetRange(srcStack.Count - stacksToMove, stacksToMove);
                dstStack.AddRange(crates);
                srcStack.RemoveRange(srcStack.Count - stacksToMove, stacksToMove);
            }
        }

        // print stacks
        //for (var s = 0; s < stackCount; s++)
        //{
        //    Console.WriteLine($"Stack {s}:");
        //    for (var i = stacks[s].Count - 1; i >= 0; i--)
        //    {
        //        Console.WriteLine($"\t{stacks[s][i]}");
        //    }
        //}

        // extract answer
        var answer = "";
        for (var s = 0; s < stackCount; s++)
        {
            answer += stacks[s].Last();
        }

        return answer;
    }

    internal static void Test1()
    {
        const string input = """
                [D]    
            [N] [C]    
            [Z] [M] [P]
             1   2   3 

            move 1 from 2 to 1
            move 3 from 1 to 3
            move 2 from 2 to 1
            move 1 from 1 to 2
            """;

        var lines = input.Split('\n').ToArray();

        Console.WriteLine(ParseStacksAndExecuteMoves(lines, false));
        Console.WriteLine(ParseStacksAndExecuteMoves(lines, true));
    }
}