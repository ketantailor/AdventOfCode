namespace AdventOfCode.Core.Year2021;

[AocPuzzle("Hydrothermal Venture", Solution1 = "6841", Solution2 = "19258")]
internal class Day05 : ISolution
{
    public SolutionResult Solve(string input)
    {
        var lines = input
            .Split('\n')
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Select(Line.Parse)
            .ToArray();

        var solution1 = Solve(lines.Where(l => l.X1 == l.X2 || l.Y1 == l.Y2).ToArray());
        var solution2 = Solve(lines);

        return new SolutionResult(solution1, solution2);
    }

    private static int Solve(Line[] lines)
    {
        var maxSize = lines.Max(l => l.MaxCoord) + 1;
        var grid = new int[maxSize, maxSize];

        foreach (var line in lines)
        {
            var xc = line.X1;
            var yc = line.Y1;

            while (true)
            {
                grid[xc, yc]++;

                if (xc == line.X2 && yc == line.Y2)
                {
                    break;
                }

                xc += line.Xd;
                yc += line.Yd;
            }
        }

        var xmax = grid.GetLength(0);
        var ymax = grid.GetLength(1);
        var count = 0;
        for (var y = 0; y < ymax; y++)
        {
            for (var x = 0; x < xmax; x++)
            {
                if (grid[x, y] > 1) count++;
            }
        }

        return count;
    }

    internal void Test()
    {
        var test = """
            0,9 -> 5,9
            8,0 -> 0,8
            9,4 -> 3,4
            2,2 -> 2,1
            7,0 -> 7,4
            6,4 -> 2,0
            0,9 -> 2,9
            3,4 -> 1,4
            0,0 -> 8,8
            5,5 -> 8,2
            """.Trim();

        var result = Solve(test);
        Console.WriteLine($"Day04.Test() result={result}");
    }

    class Line
    {
        public int X1 { get; private set; }
        public int Y1 { get; private set; }
        public int X2 { get; private set; }
        public int Y2 { get; private set; }
        public int Xd => Math.Sign(X2 - X1);
        public int Yd => Math.Sign(Y2 - Y1);
        public int MaxCoord { get; private set; }

        public static Line Parse(string line)
        {
            var parts = line.Split(" -> ");
            var start = parts[0].Split(',');
            var end = parts[1].Split(',');

            var x1 = int.Parse(start[0]);
            var y1 = int.Parse(start[1]);
            var x2 = int.Parse(end[0]);
            var y2 = int.Parse(end[1]);

            return new Line
            {
                X1 = x1,
                Y1 = y1,
                X2 = x2,
                Y2 = y2,
                MaxCoord = new[] { x1, y1, x2, y2 }.Max(),
            };
        }

        public override string ToString()
        {
            return $"Line: ({X1}, {Y1}) -> ({X2}, {Y2}) [{Xd},{Yd}]";
        }
    }
}
