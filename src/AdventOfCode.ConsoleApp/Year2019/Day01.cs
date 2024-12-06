namespace AdventOfCode.Year2019;

[AocPuzzle("The Tyranny of the Rocket Equation", Solution1 = "3297896", Solution2 = "4943969")]
internal class Day01 : ISolution
{
    public SolutionResult Solve(string input)
    {
        var lines = input
            .Split('\n')
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .ToArray();

        var part1 = lines
            .Select(s => double.Parse(s))
            .Select(GetFuelReqs)
            .Sum();

        var part2 = lines
            .Select(s => double.Parse(s))
            .Select(GetFuelReqs2)
            .Sum();

        return new SolutionResult(part1.ToString(), part2.ToString());
    }

    private static double GetFuelReqs(double mass)
    {
        return Math.Max(Math.Floor(mass / 3d) - 2, 0d);
    }

    private static double GetFuelReqs2(double mass)
    {
        var fuelTotal = GetFuelReqs(mass);
        var fuelCurrent = GetFuelReqs(fuelTotal);
        while (true)
        {
            var fuelTemp = GetFuelReqs(fuelCurrent);
            fuelTotal += fuelCurrent;
            if (fuelTemp == 0) break;
            fuelCurrent = fuelTemp;
        }
        return fuelTotal;
    }
}