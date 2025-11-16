namespace AdventOfCode.Core.Year2015;

[AocPuzzle("I Was Told There Would Be No Math", Solution1 = "1586300", Solution2 = "3737498")]
internal class Day02 : ISolution
{
    public SolutionResult Solve(string input)
    {
        var lines = input
            .Split('\n')
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(s => s.Trim())
            .ToArray();

        var totalArea = lines
            .Select(ExtractDimensions)
            .Select(t => GetWrappingPaperArea(t.l, t.w, t.h))
            .Sum();

        var totalRibbonLength = lines
            .Select(ExtractDimensions)
            .Select(t => GetRibbonLength(t.l, t.w, t.h))
            .Sum();

        return new SolutionResult(totalArea, totalRibbonLength);
    }

    private static (int l, int w, int h) ExtractDimensions(string lwh)
    {
        var dimensions = lwh.Split('x').Select(int.Parse).ToArray();
        return (dimensions[0], dimensions[1], dimensions[2]);
    }

    private static int GetWrappingPaperArea(int l, int w, int h)
    {
        var maxDimension = new[] { l, w, h }.OrderByDescending(x => x).First();
        var surfaceArea = 2 * (l * w + w * h + h * l);
        var slack = l * w * h / maxDimension;
        return surfaceArea + slack;
    }

    private static int GetRibbonLength(int l, int w, int h)
    {
        var maxDimension = new[] { l, w, h }.OrderByDescending(x => x).First();
        var ribbonLength = 2 * (l + w + h - maxDimension);
        var bowLength = l * w * h;
        return ribbonLength + bowLength;
    }
}
