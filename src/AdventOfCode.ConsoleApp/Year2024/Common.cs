namespace AdventOfCode.Year2024;

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

        for (var x = 0; x < xmax; x++)
        {
            for (var y = 0; y < ymax; y++)
            {
                var l = lines[y];
                var c = l[x];
                grid[x, y] = c;
            }
        }

        return grid;
    }
}
