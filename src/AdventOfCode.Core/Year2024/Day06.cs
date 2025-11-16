namespace AdventOfCode.Core.Year2024;

[AocPuzzle("Guard Gallivant", Solution1 = "4696")]
internal class Day06X : ISolution
{
    public SolutionResult Solve(string input)
    {
        var grid = Common.ToCharArray(input);
        var part1 = CountGuardPatrol((char[,])grid.Clone());
        var part2 = CountPossibleLoops((char[,])grid.Clone());
        //var part2 = "";

        return new SolutionResult(part1, part2);
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
        Console.WriteLine(CountGuardPatrol((char[,])grid.Clone()));
        Console.WriteLine(CountPossibleLoops((char[,])grid.Clone()));
    }

    internal static int CountPossibleLoops(char[,] grid)
    {
        const int Limit = 1000;

        var xmax = grid.GetLength(0);
        var ymax = grid.GetLength(1);

        var possibleLoops = 0;
        var threads = 0;

        for (var y = 0; y < ymax; y++)
        {
            for (var x = 0; x < xmax; x++)
            {
                threads++;
                var x1 = x;
                var y1 = y;
                ThreadPool.QueueUserWorkItem(c =>
                {
                    if (IsPossibleLoop(grid, x1, y1, Limit))
                    {
                        Interlocked.Increment(ref possibleLoops);
                        Interlocked.Decrement(ref threads);
                    }
                });
            }
        }

        while (threads > 0) Thread.Sleep(100);

        return possibleLoops;
    }

    private static bool IsPossibleLoop(char[,] grid, int x, int y, int limit)
    {
        var clonedGrid = (char[,])grid.Clone();

        try
        {

            if (clonedGrid[x, y] != '.')
                return false;

            clonedGrid[x, y] = '#';
            var steps = CountGuardPatrol(clonedGrid, limit);
            return steps == -1;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{clonedGrid.GetLength(0)}, {clonedGrid.GetLength(0)}, {x}, {y}" + ex);
            throw;
        }
    }

    internal static int CountGuardPatrol(char[,] grid, int limit = int.MaxValue)
    {
        var isInGrid = true;
        var step = 0;
        while (isInGrid && step < limit)
        {
            isInGrid = MoveOne(grid);
            step++;
        }
        return step == limit ? -1 : CountDistinctSteps(grid);
    }

    internal static bool MoveOne(char[,] grid)
    {
        var xmax = grid.GetLength(0);
        var ymax = grid.GetLength(1);
        var xpos = 0;
        var ypos = 0;
        var dx = 0;
        var dy = 0;

        for (var y = 0; y < ymax; y++)

        {
            for (var x = 0; x < xmax; x++)
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

        for (var y = 0; y < ymax; y++)

        {
            for (var x = 0; x < xmax; x++)
            {
                if (grid[x, y] == 'x') distinctSteps++;
            }
        }

        return distinctSteps;
    }
}