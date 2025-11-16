namespace AdventOfCode.Core.Year2024;

internal static class Common
{
    internal static char[,] ToCharArray(string input)
    {
        var lines = input
            .Split('\n')
            .Select(s => s.Trim())
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .ToArray();

        var xmax = lines.Min(l => l.Length);
        var ymax = lines.Length;

        var grid = new char[xmax, ymax];

        for (var y = 0; y < ymax; y++)
        {
            for (var x = 0; x < xmax; x++)
            {
                var l = lines[y];
                var c = l[x];
                grid[x, y] = c;
            }
        }

        return grid;
    }

    internal static char[,] DeepClone(char[,] grid)
    {
        var clone = (char[,])grid.Clone();

        var xmax = clone.GetLength(0);
        var ymax = clone.GetLength(1);
        for (var y = 0; y < ymax; y++)
        {
            for (var x = 0; x < xmax; x++)
            {
                clone[x, y] = grid[x, y];
            }
        }

        return clone;
    }

    internal static void Print(char[,] grid)
    {
        var xmax = grid.GetLength(0);
        var ymax = grid.GetLength(1);
        for (var y = 0; y < ymax; y++)
        {
            for (var x = 0; x < xmax; x++)
            {
                Console.Write(grid[x, y]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
