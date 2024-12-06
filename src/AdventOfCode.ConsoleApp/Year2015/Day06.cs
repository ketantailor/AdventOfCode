namespace AdventOfCode.Year2015;

[AocPuzzle("Probably a Fire Hazard", Solution1 = "543903", Solution2 = "14687245")]
internal class Day06 : ISolution
{
    public SolutionResult Solve(string input)
    {
        var lines = input
            .Split('\n')
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(s => s.Trim())
            .ToArray();

        var part1 = LightsOn1(lines);
        var part2 = LightsOn2(lines);
        return new SolutionResult(part1.ToString(), part2.ToString());
    }

    private static int LightsOn1(IEnumerable<string> instructions)
    {
        const int Limit = 1000;

        bool[,] lights = new bool[Limit, Limit];

        foreach (var instruction in instructions)
        {
            var ins = Parse(instruction);

            for (var x = ins.Ax; x <= ins.Bx; x++)
            {
                for (var y = ins.Ay; y <= ins.By; y++)
                {
                    switch (ins.Action)
                    {
                        case "toggle":
                            lights[x, y] = !lights[x, y];
                            break;
                        case "on":
                            lights[x, y] = true;
                            break;
                        case "off":
                            lights[x, y] = false;
                            break;
                    }
                }
            }
        }

        var lightsOn = 0;
        for (var x = 0; x < Limit; x++)
        {
            for (var y = 0; y < Limit; y++)
            {
                if (lights[x, y]) lightsOn++;
            }
        }
        return lightsOn;
    }

    private static long LightsOn2(IEnumerable<string> instructions)
    {
        const int Limit = 1000;

        int[,] lights = new int[Limit, Limit];

        foreach (var instruction in instructions)
        {
            var ins = Parse(instruction);

            for (var x = ins.Ax; x <= ins.Bx; x++)
            {
                for (var y = ins.Ay; y <= ins.By; y++)
                {
                    switch (ins.Action)
                    {
                        case "toggle":
                            lights[x, y] += 2;
                            break;
                        case "on":
                            lights[x, y]++;
                            break;
                        case "off":
                            lights[x, y]--;
                            if (lights[x, y] < 0)
                                lights[x, y] = 0;
                            break;
                    }
                }
            }
        }

        var lightsOn = 0L;
        for (var x = 0; x < Limit; x++)
        {
            for (var y = 0; y < Limit; y++)
            {
                lightsOn += lights[x, y];
            }
        }
        return lightsOn;
    }

    private static (string Action, int Ax, int Ay, int Bx, int By) Parse(string instruction)
    {
        instruction = instruction.Replace("turn ", "");
        var parts = instruction.Split(' ');
        var partsA = parts[1].Split(',');
        var partsB = parts[3].Split(',');

        var action = parts[0];
        var ax = int.Parse(partsA[0]);
        var ay = int.Parse(partsA[1]);
        var bx = int.Parse(partsB[0]);
        var by = int.Parse(partsB[1]);

        return (action, ax, ay, bx, by);
    }

}