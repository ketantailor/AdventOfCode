using AdventOfCode.Core.Year2021;

namespace AdventOfCode.Core.Tests.Year2021;

[TestFixture]
public class Day06Tests
{
    [Test]
    public void Test_Initial()
    {
        var input = "3,4,3,1,2";

        var solution = new Day06();
        var result = solution.Solve(input);

        Assert.That(result.Part1, Is.EqualTo("5934"));
        Assert.That(result.Part2, Is.EqualTo("26984457539"));
    }
}
