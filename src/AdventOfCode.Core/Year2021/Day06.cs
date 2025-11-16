
namespace AdventOfCode.Core.Year2021;

[AocPuzzle("Lanternfish", Solution1 = "352195", Solution2 = null)]

internal class Day06X : ISolution
{
    public SolutionResult Solve(string input)
    {
        var state = input.Split(',').Select(int.Parse).ToList();

        var solution1 = Solve1(state.ToList(), 80);
        var solution2 = Solve1(state.ToList(), 256);
        return new SolutionResult(solution1, solution2);
    }

    private int Solve1(List<int> state, int maxDays)
    {
        var day = 0;

        while (true)
        {
            day++;
            var newFish = new List<int>();
            for (int i = 0; i < state.Count; i++)
            {
                state[i]--;
                if (state[i] < 0)
                {
                    state[i] = 6;
                    newFish.Add(8);
                }
            }
            state.AddRange(newFish);

            //Console.WriteLine($"After {day} days: {string.Join(',', state)}");
            //Console.WriteLine($"After {day} days: {state.Count}");

            if (day == maxDays)
            {
                break;
            }
        }

        return state.Count;
    }

    public void Test()
    {
        //var input = "3,4,3,1,2";
        var input = "1";
        Console.WriteLine(Solve(input));
    }
}
