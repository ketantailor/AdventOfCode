namespace AdventOfCode.Year2024;

[AocPuzzle("Ceres Search")]
internal class Day04 : ISolution
{
    public SolutionResult Solve(string input)
    {
        var grid = ToCharArray(input);

        var part1 = FindWords(grid, "XMAS");
        var part2 = FindXmas(grid);
        
        return new SolutionResult(part1.ToString(), part2.ToString());
    }

    internal static void Test()
    {
        var input = """
            MMMSXXMASM
            MSAMXMSMSA
            AMXSXMAAMM
            MSAMASMSMX
            XMASAMXAMM
            XXAMMXXAMA
            SMSMSASXSS
            SAXAMASAAA
            MAMMMXMMMM
            MXMXAXMASX
            """.Trim();

        var grid = ToCharArray(input);

        Console.WriteLine(FindWords(grid, "XMAS"));
        Console.WriteLine(FindXmas(grid));
    }

    private static char[,] ToCharArray(string input)
    {
        var lines = input
            .Split('\n')
            .Select(s => s.Trim())
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .ToArray();

        var xmax = lines.Max(l => l.Length);
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

    private static int FindWords(char[,] grid, string searchText)
    {
        var instances = 0;

        var xmax = grid.GetLength(0);
        var ymax = grid.GetLength(1);

        for (var y = 0; y < ymax; y++)
        {
            for (var x = 0; x < xmax; x++)
            {
                foreach (var dy in new[] { -1, 0, 1 })
                {
                    foreach (var dx in new[] { -1, 0, 1 })
                    {
                        if (dx == 0 && dy == 0) continue;

                        var found = true;

                        for (var i = 0; i < searchText.Length; i++)
                        {
                            var xc = x + i * dx;
                            var yc = y + i * dy;

                            if (xc < 0 || xc >= xmax || yc < 0 || yc >= ymax)
                            {
                                found = false;
                                break;
                            }

                            if (grid[xc, yc] != searchText[i])
                            {
                                found = false;
                                break;
                            }
                        }

                        if (found) instances++;
                    }
                }
            }
        }
        return instances;
    }

    private static int FindXmas(char[,] grid)
    {
        var instances = 0;

        var xmax = grid.GetLength(0);
        var ymax = grid.GetLength(1);

        for (var y = 1; y < ymax - 1; y++)
        {
            for (var x = 1; x < xmax - 1; x++)
            {
                if (grid[x, y] != 'A') continue;

                var found1 = false;
                var found2 = false;

                if ((grid[x-1, y-1] == 'M' && grid[x + 1, y + 1] == 'S')
                    || (grid[x - 1, y - 1] == 'S' && grid[x + 1, y + 1] == 'M'))
                    found1 = true;

                if ((grid[x - 1, y + 1] == 'M' && grid[x + 1, y - 1] == 'S')
                    || (grid[x - 1, y + 1] == 'S' && grid[x + 1, y - 1] == 'M'))
                    found2 = true;

                if (found1 && found2) instances++;
            }
        }

        return instances;
    }
}
