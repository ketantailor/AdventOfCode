using AdventOfCode.Core.Year2025;

namespace AdventOfCode.Core.Tests.Year2025;

[TestFixture]
public class Day01Tests
{
    [Test]
    public void Test_Initial()
    {
        var input = """
            L68
            L30
            R48
            L5
            R60
            L55
            L1
            L99
            R14
            L82
            """;

        var solution = new Day01_Initial();
        var result = solution.Solve(input);

        Assert.That(result.Part1, Is.EqualTo("3"));
        Assert.That(result.Part2, Is.EqualTo("6"));
    }
    
    [Test]
    public void Test_Optimised()
    {
        var input = """
            L68
            L30
            R48
            L5
            R60
            L55
            L1
            L99
            R14
            L82
            """;

        var solution = new Day01_Optimised();
        var result = solution.Solve(input);

        Assert.That(result.Part1, Is.EqualTo("3"));
        Assert.That(result.Part2, Is.EqualTo("6"));
    }
}
