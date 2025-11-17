namespace AdventOfCode.Core.Tests.Year2021;

[TestFixture]
public class Day01Tests
{
    [Test]
    public void Test1()
    {
        var input = """
            199
            200
            208
            210
            200
            207
            240
            269
            260
            263
            """;

        var solution = new AdventOfCode.Core.Year2021.Day01();
        var result = solution.Solve(input);

        Assert.That(result.Part1, Is.EqualTo("7"));
        Assert.That(result.Part2, Is.EqualTo("5"));
    }
}
