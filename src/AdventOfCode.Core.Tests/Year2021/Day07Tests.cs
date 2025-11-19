using AdventOfCode.Core.Year2021;

namespace AdventOfCode.Core.Tests.Year2021;

[TestFixture]
public class Day07Tests
{
    [Test]
    public void Test_Initial()
    {
        var input = "16,1,2,0,4,2,7,1,2,14";

        var solution = new Day07_Initial();
        var result = solution.Solve(input);

        Assert.That(result.Part1, Is.EqualTo("37"));
        Assert.That(result.Part2, Is.EqualTo("168"));
    }

    [Test]
    public void Test_Optimised()
    {
        var input = "16,1,2,0,4,2,7,1,2,14";

        var solution = new Day07_Optimised();
        var result = solution.Solve(input);

        Assert.That(result.Part1, Is.EqualTo("37"));
        Assert.That(result.Part2, Is.EqualTo("168"));
    }
}
