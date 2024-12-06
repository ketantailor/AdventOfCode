namespace AdventOfCode.Year2022;

[AocPuzzle("Rock Paper Scissors")]
internal class Day02 : ISolution
{
    public SolutionResult Solve(string input)
    {
        
        var part1 = CalculatePart1(input);
        var part2 = CalculatePart2(input);
        return new SolutionResult(part1.ToString(), part2.ToString());
    }

    private static int CalculatePart1(string input)
    {
        var combinations = GenerateCombinations();
        var answer = input.Split('\n')
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Select(l => CalculateScore1(combinations, l[0], l[2]))
            .Sum();
        return answer;
    }

    private static int CalculatePart2(string input)
    {
        var combinations = GenerateCombinations();
        var answer = input.Split('\n')
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Select(l => CalculateScore2(combinations, l[0], l[2]))
            .Sum();
        return answer;
    }

    private static IEnumerable<GameCombination> GenerateCombinations()
    {
        foreach (var p1 in Enum.GetValues<GamePlay>())
        {
            foreach (var p2 in Enum.GetValues<GamePlay>())
            {
                var result = GameResult.Lose;
                if (p1 == GamePlay.Rock && p2 == GamePlay.Paper) result = GameResult.Win;
                else if (p1 == GamePlay.Paper && p2 == GamePlay.Scissors) result = GameResult.Win;
                else if (p1 == GamePlay.Scissors && p2 == GamePlay.Rock) result = GameResult.Win;
                else if (p1 == p2) result = GameResult.Draw;
                yield return new GameCombination(p1, p2, result);
            }
        }
    }

    private static int CalculateScore1(IEnumerable<GameCombination> combinations, char p1, char p2)
    {
        var play1 = p1 switch
        {
            'A' => GamePlay.Rock,
            'B' => GamePlay.Paper,
            'C' => GamePlay.Scissors,
            _ => throw new NotImplementedException(),
        };

        var play2 = p2 switch
        {
            'X' => GamePlay.Rock,
            'Y' => GamePlay.Paper,
            'Z' => GamePlay.Scissors,
            _ => throw new NotImplementedException(),
        };

        var combination = combinations.Single(c => c.P1 == play1 && c.P2 == play2);

        var playScore = combination.P2 switch
        {
            GamePlay.Rock => 1,
            GamePlay.Paper => 2,
            GamePlay.Scissors => 3,
            _ => throw new NotImplementedException(),
        };

        var resultScore = combination.Result switch
        {
            GameResult.Lose => 0,
            GameResult.Draw => 3,
            GameResult.Win => 6,
            _ => throw new NotImplementedException(),
        };

        return playScore + resultScore;
    }

    private static int CalculateScore2(IEnumerable<GameCombination> combinations, char p1, char p2)
    {
        var play1 = p1 switch
        {
            'A' => GamePlay.Rock,
            'B' => GamePlay.Paper,
            'C' => GamePlay.Scissors,
            _ => throw new NotImplementedException(),
        };

        var result = p2 switch
        {
            'X' => GameResult.Lose,
            'Y' => GameResult.Draw,
            'Z' => GameResult.Win,
            _ => throw new NotImplementedException(),
        };

        var combination = combinations.Single(c => c.P1 == play1 && c.Result == result);

        var playScore = combination.P2 switch
        {
            GamePlay.Rock => 1,
            GamePlay.Paper => 2,
            GamePlay.Scissors => 3,
            _ => throw new NotImplementedException(),
        };

        var resultScore = combination.Result switch
        {
            GameResult.Lose => 0,
            GameResult.Draw => 3,
            GameResult.Win => 6,
            _ => throw new NotImplementedException(),
        };

        return playScore + resultScore;
    }

    private enum GamePlay
    {
        Rock, Paper, Scissors
    }

    private enum GameResult
    {
        Lose, Draw, Win
    }

    private class GameCombination
    {
        public GameCombination(GamePlay p1, GamePlay p2, GameResult result)
        {
            P1 = p1;
            P2 = p2;
            Result = result;
        }

        public GamePlay P1 { get; }
        public GamePlay P2 { get; }
        public GameResult Result { get; }
    }

}
