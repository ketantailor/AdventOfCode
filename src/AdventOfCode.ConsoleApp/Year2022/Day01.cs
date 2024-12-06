namespace AdventOfCode.Year2022;

[AocPuzzle("Calorie Counting")]
internal class Day01 : ISolution
{
    public SolutionResult Solve(string input)
    {
        var part1 = GetMaxCalories(input);
        var part2 = GetSumOfTopThreeCalories(input);
        return new SolutionResult(part1.ToString(), part2.ToString());
    }

    public static IEnumerable<int> GetAllCalories(string input)
    {
        var lines = input.Split('\n');

        var caloriesCurrent = 0;

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                if (caloriesCurrent != 0)
                {
                    yield return caloriesCurrent;
                    caloriesCurrent = 0;
                }
            }
            else
            {
                var calories = int.Parse(line);
                caloriesCurrent += calories;
            }
        }

        if (caloriesCurrent != 0)
        {
            yield return caloriesCurrent;
        }
    }

    public static int GetMaxCalories(string input)
    {
        return GetAllCalories(input).Max();
    }

    public static int GetSumOfTopThreeCalories(string input)
    {
        return GetAllCalories(input)
            .OrderByDescending(i => i)
            .Take(3)
            .Sum();
    }
}
