namespace AdventOfCode.Year2024;

[AocPuzzle("Guard Gallivant")]
internal class Day06 : ISolution
{
    public SolutionResult Solve(string input)
    {
        var grid = Common.ToCharArray(input);
        var part1 = CountGuardPatrol(grid);

        return new SolutionResult(part1.ToString(), "");
    }

    internal static void Test()
    {
        var input =
            """
            ....#.....
            .........#
            ..........
            ..#.......
            .......#..
            ..........
            .#..^.....
            ........#.
            #.........
            ......#...
            """;

        var grid = Common.ToCharArray(input);
        Console.WriteLine(CountGuardPatrol(grid));
    }

    internal static int CountGuardPatrol(char[,] grid)
    {
        var isInGrid = true;
        while (isInGrid)
        {
            isInGrid = MoveOne(grid);
        }
        return CountDistinctSteps(grid);
    }

    internal static bool MoveOne(char[,] grid)
    {
        var xmax = grid.GetLength(0);
        var ymax = grid.GetLength(1);
        var xpos = 0;
        var ypos = 0;
        var dx = 0;
        var dy = 0;

        for (var x = 0; x < xmax; x++)
        {
            for (var y = 0; y < ymax; y++)
            {
                var c = grid[x, y];
                if (c == '^' || c == '<' || c == '>' || c == 'v' || c == 'V')
                {
                    xpos = x;
                    ypos = y;

                    (dx, dy) = GetDxDy(c);

                    break;
                }
            }
        }

        var xnew = xpos + dx;
        var ynew = ypos + dy;

        if (xnew < 0 || xnew >= xmax || ynew < 0 || ynew >= ymax)
        {
            // left the grid
            grid[xpos, ypos] = 'x';
            return false;
        }

        if (grid[xnew, ynew] == '#')
        {
            // blocked, so turn right and then move one step
            grid[xpos, ypos] = TurnRight(grid[xpos, ypos]);
            return MoveOne(grid);
        }

        // move forward one step
        grid[xnew, ynew] = grid[xpos, ypos];
        grid[xpos, ypos] = 'x';

        return true;
    }

    private static (int dx, int dy) GetDxDy(char c)
    {
        switch (c)
        {
            case '^':
                return (0, -1);
            case '<':
                return (-1, 0);
            case '>':
                return (1, 0);
            case 'v':
            case 'V':
                return (0, 1);
        }

        throw new ArgumentException(nameof(c));
    }

    private static char TurnRight(char c)
    {
        switch (c)
        {
            case '^':
                return '>';
            case '<':
                return '^';
            case '>':
                return 'v';
            case 'v':
            case 'V':
                return '<';
        }

        throw new ArgumentException(nameof(c));
    }

    internal static int CountDistinctSteps(char[,] grid)
    {
        var xmax = grid.GetLength(0);
        var ymax = grid.GetLength(1);

        var distinctSteps = 0;

        for (var x = 0; x < xmax; x++)
        {
            for (var y = 0; y < ymax; y++)
            {
                if (grid[x, y] == 'x') distinctSteps++;
            }
        }

        return distinctSteps;
    }
}