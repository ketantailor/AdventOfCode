
namespace AdventOfCode.Core.Year2021;

[AocPuzzle("Lanternfish", Solution1 = "352195", Solution2 = "1600306001288")]
internal class Day06 : ISolution
{
    public SolutionResult Solve(string input)
    {
        var currentAges = input.Split(',').Select(int.Parse).ToList();

        var solution1 = Solve(currentAges, 80);
        var solution2 = Solve(currentAges, 256);
        return new SolutionResult(solution1, solution2);
    }

    private long Solve(List<int> state, int maxDays)
    {
        var day = 0;

        var ageCurrent = new long[9]; // index by age
        var ageNext = new long[9]; // index by age

        foreach (var s in state)
        {
            ageCurrent[s]++;
        }

        while (day < maxDays)
        {
            ageNext[8] = ageCurrent[0]; // babies
            ageNext[7] = ageCurrent[8];
            ageNext[6] = ageCurrent[7] + ageCurrent[0]; // aged 7 + just given birth
            for (var i = 5; i >= 0; i--)
            {
                ageNext[i] = ageCurrent[i + 1];
            }

            (ageCurrent, ageNext) = (ageNext, ageCurrent);

            day++;
        }

        long sum = 0;
        foreach (var a in ageCurrent)
        {
            sum += a;
        }
        return sum;
    }
}
