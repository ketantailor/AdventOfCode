namespace AdventOfCode.Year2024;

[AocPuzzle("Print Queue", Solution1 = "4662", Solution2 = "5900")]
internal class Day05 : ISolution
{
    public SolutionResult Solve(string input)
    {
        var lines = input
            .Split('\n')
            .Select(s => s.Trim())
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .ToArray();

        var part1 = SumCorrectQueues(lines);
        var part2 = SumCorrectedQueues(lines);
        return new SolutionResult(part1.ToString(), part2.ToString());
    }

    internal static void Test()
    {
        var input = """
            47|53
            97|13
            97|61
            97|47
            75|29
            61|13
            75|53
            29|13
            97|29
            53|29
            61|53
            97|53
            61|29
            47|13
            75|47
            97|75
            47|61
            75|61
            47|29
            75|13
            53|13

            75,47,61,53,29
            97,61,53,29,13
            75,29,13
            75,97,47,61,53
            61,13,29
            97,13,75,29,47
            """;

        var lines = input
            .Split('\n')
            .Select(s => s.Trim())
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .ToArray();

        Console.WriteLine(SumCorrectQueues(lines));
        Console.WriteLine(SumCorrectedQueues(lines));
    }

    private static int SumCorrectQueues(string[] lines)
    {
        var rules = GetRules(lines);
        var queues = GetQueues(lines);

        var sum = queues
            .Where(q => CheckQueue(rules, q))
            .Sum(q => q[q.Length / 2]);

        return sum;
    }

    private static int SumCorrectedQueues(string[] lines)
    {
        var rules = GetRules(lines);
        var queues = GetQueues(lines);
        var comparer = new QueueItemComparer(rules);

        var sum = queues
            .Where(q => !CheckQueue(rules, q))
            .Select(q => CorrectQueue(comparer, q))
            .Sum(q => q[q.Length / 2]);

        return sum;
    }

    private static Rule[] GetRules(string[] lines)
    {
        return lines
            .Where(l => l.Contains('|'))
            .Select(l =>
            {
                var split = l.Split('|');
                return new Rule(int.Parse(split[0]), int.Parse(split[1]));
            })
            .ToArray();
    }

    private static int[][] GetQueues(string[] lines)
    {
        return lines
            .Where(l => l.Contains(','))
            .Select(l => l.Split(",").Select(int.Parse).ToArray())
            .ToArray();
    }

    private static bool CheckQueue(Rule[] rules, int[] queue)
    {
        for (var qi = 0; qi < queue.Length; qi++)
        {
            foreach(var rule in rules)
            {
                if (queue[qi] == rule.First)
                {
                    if (queue.Take(qi).Any(qi => qi == rule.Second))
                        return false;
                }

                if (queue[qi] == rule.Second)
                {
                    if (queue.Skip(qi).Any(qi => qi == rule.First))
                        return false;
                }
            }
        }

        return true;
    }

    private static int[] CorrectQueue(IComparer<int> comparer, int[] queue)
    {
        return queue
            .OrderBy(q => q, comparer)
            .ToArray();
    }

    private record Rule(int First, int Second);

    private class QueueItemComparer : IComparer<int>
    {
        private readonly Rule[] _rules;

        public QueueItemComparer(Rule[] rules)
        {
            _rules = rules;
        }

        public int Compare(int x, int y)
        {
            if (_rules.Any(r => r.First == x && r.Second == y)) return -1;
            if (_rules.Any(r => r.First == y && r.Second == x)) return 1;
            return 0;
        }
    }
}
