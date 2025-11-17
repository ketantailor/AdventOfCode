namespace AdventOfCode.Core.Tests.Year2021;

[TestFixture]
public class Day02Tests
{
    [Test]
    public void Test_Initial()
    {
        var input = """
            forward 5
            down 5
            forward 8
            up 3
            down 8
            forward 2
            """;

        var solution = new AdventOfCode.Core.Year2021.Day02_Initial();
        var result = solution.Solve(input);

        Assert.That(result.Part1, Is.EqualTo("150"));
        Assert.That(result.Part2, Is.EqualTo("900"));
    }

    [Test]
    public void Test_Optimised()
    {
        var input = """
            forward 5
            down 5
            forward 8
            up 3
            down 8
            forward 2
            """;

        var solution = new AdventOfCode.Core.Year2021.Day02_Optimised();
        var result = solution.Solve(input);

        Assert.That(result.Part1, Is.EqualTo("150"));
        Assert.That(result.Part2, Is.EqualTo("900"));
    }
}
