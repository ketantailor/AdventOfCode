using System.Text;

namespace AdventOfCode.Year2021;

[AocPuzzle("Giant Squid", Solution1 = "74320", Solution2 = "17884")]
internal class Day04 : ISolution
{
    public SolutionResult Solve(string input)
    {
        var lines = input
            .Split('\n')
            .ToArray();

        var numbers = lines[0]
            .Split(',')
            .Select(int.Parse)
            .ToArray();

        var boards = lines
            .Skip(1)
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Select(l => l
                .Trim()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray())
            .Chunk(5)
            .Select(chunk => new BingoBoard(chunk))
            .ToArray();

        var solution1 = Part1(numbers, boards);
        var solution2 = Part2(numbers, boards);
        return new SolutionResult(solution1, solution2);
    }

    private int Part1(int[] numbers, BingoBoard[] boards)
    {
        for (var n = 0; n < numbers.Length; n++)
        {
            var drawnNumbers = numbers.Take(n + 1).ToHashSet();
            foreach (var board in boards)
            {
                if (board.IsWin(drawnNumbers))
                {
                    var sumUnmarked = board.SumOfUnmarkedNumbers(drawnNumbers);
                    var lastNumber = drawnNumbers.Last();
                    var score = sumUnmarked * lastNumber;
                    return score;
                }
            }
        }

        throw new InvalidOperationException("");
    }

    private int Part2(int[] numbers, BingoBoard[] boards)
    {
        var boardsList = boards.ToList();

        for (var n = 0; n < numbers.Length; n++)
        {
            var drawnNumbers = numbers.Take(n + 1).ToHashSet();
            for (var b = 0; b < boardsList.Count; b++)
            {
                var board = boardsList[b];
                var isWin = board.IsWin(drawnNumbers);
                if (isWin && boardsList.Count > 1)
                {
                    boardsList.RemoveAt(b);
                    b--;
                }
                else if (isWin)
                {
                    var sumUnmarked = boardsList[0].SumOfUnmarkedNumbers(drawnNumbers);
                    var lastNumber = drawnNumbers.Last();
                    var score = sumUnmarked * lastNumber;
                    return score;
                }
            }
        }

        throw new InvalidOperationException("");
    }

    internal void Test()
    {
        var test = """
            7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

            22 13 17 11  0
             8  2 23  4 24
            21  9 14 16  7
             6 10  3 18  5
             1 12 20 15 19

             3 15  0  2 22
             9 18 13 17  5
            19  8  7 25 23
            20 11 10 24  4
            14 21 16 12  6

            14 21 17 24  4
            10 16 15  9 19
            18  8 23 26 20
            22 11 13  6  5
             2  0 12  3  7
            """.Trim();

        var result = Solve(test);
        Console.WriteLine($"Day04.Test() result={result}");
    }

    private class BingoBoard
    {
        private readonly int[][] _items;
        
        public BingoBoard(int[][] items)
        {
            _items = items;
        }

        public bool IsWin(HashSet<int> numbers)
        {
            // rows
            for(var x = 0; x < _items.Length; x++)
            {
                var win = true;
                for (var i = 0; i < _items.Length; i++)
                {
                    if (!numbers.Contains(_items[x][i]))
                    {
                        win = false;
                        break;
                    }
                }
                if (win)
                    return true;
            }

            // cols
            for (var y = 0; y < _items.Length; y++)
            {
                var win = true;
                for (var i = 0; i < _items.Length; i++)
                {
                    if (!numbers.Contains(_items[i][y]))
                    {
                        win = false;
                        break;
                    }
                }
                if (win)
                    return true;
            }

            return false;
        }

        public int SumOfUnmarkedNumbers(HashSet<int> numbers)
        {
            var sum = 0;
            for (var i = 0; i < _items.Length; i++)
            {
                for (var j = 0; j < _items.Length; j++)
                {
                    if (!numbers.Contains(_items[i][j]))
                    {
                        sum += _items[i][j];
                    }
                }
            }
            return sum;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            for (var i = 0; i < _items.Length; i++)
            {
                builder.AppendLine(string.Join(' ', _items[i].Select(n => n.ToString("D2"))));
            }
            return builder.ToString();
        }
    }
}
