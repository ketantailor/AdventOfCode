namespace AdventOfCode.Core.Year2015;

[AocPuzzle("Doesn't He Have Intern-Elves For This?", Solution1 = "236", Solution2 = "51")]
internal class Day05 : ISolution
{
    private const string Vowels = "aeiou";
    private static readonly string[] BadStrings = { "ab", "cd", "pq", "xy" };

    public SolutionResult Solve(string input)
    {
        var lines = input
            .Split('\n')
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(s => s.Trim())
            .ToArray();

        var isNice1Count = lines.Count(IsNice1);
        var isNice2Count = lines.Count(IsNice2);

        return new SolutionResult(isNice1Count, isNice2Count);
    }

    public static bool IsNice1(string s)
    {
        if (s.Where(c => Vowels.Contains(c)).Count() < 3)
            return false;

        var hasDuplicateChars = false;
        for (var i = 0; i < s.Length - 1; i++)
        {
            if (s[i] == s[i + 1])
            {
                hasDuplicateChars = true;
                break;
            }
        }
        if (!hasDuplicateChars)
            return false;

        foreach (var badString in BadStrings)
        {
            if (s.Contains(badString))
                return false;
        }

        return true;
    }

    public static bool IsNice2(string s)
    {
        var match1 = false;
        for (var i = 0; i < s.Length - 1; i++)
        {
            var pair = s[i..(i + 2)];
            if (s[(i + 2)..].Contains(pair))
            {
                match1 = true;
                break;
            }
        }

        var match2 = false;
        for (var i = 0; i < s.Length - 2; i++)
        {
            if (s[i] == s[i + 2])
            {
                match2 = true;
                break;
            }
        }

        return match1 && match2;
    }
}