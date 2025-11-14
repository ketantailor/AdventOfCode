namespace AdventOfCode.Year2015;

[AocPuzzle("Not Quite Lisp", Solution1 = "232", Solution2 = "1783")]
internal class Day01 : ISolution
{
    public SolutionResult Solve(string input)
    {
        var part1 = GetFloor(input);
        var part2 = StepsToBasement(input);
        return new SolutionResult(part1, part2);
    }

    private static int GetFloor(string directions)
    {
        var floor = 0;
        for (var i = 0; i < directions.Length; i++)
        {
            if (directions[i] == '(') floor++;
            else if (directions[i] == ')') floor--;
        }
        return floor;
    }

    private static int StepsToBasement(string directions)
    {
        var floor = 0;
        for (var i = 0; i < directions.Length; i++)
        {
            if (directions[i] == '(') floor++;
            else if (directions[i] == ')') floor--;
            if (floor == -1) return i + 1;
        }
        throw new Exception();
    }
}