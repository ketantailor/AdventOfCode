namespace AdventOfCode.Core.Tests;

[TestFixture]
public class UtilsTests
{
    [Test]
    public void ReadNextInt_IndexOutOfBounds_ReturnsZero()
    {
        var input = "1234";
        var index = 5;


        var rv = Utils.ReadNextInt(input, ref index);


        Assert.That(rv, Is.EqualTo(0));
    }

    [Test]
    public void ReadNextInt_WithLeadingWhitespace_ReturnsExpectedValue()
    {
        var input = "  123";
        var index = 0;


        var rv = Utils.ReadNextInt(input, ref index);


        Assert.That(rv, Is.EqualTo(123));
        Assert.That(index, Is.EqualTo(5));
    }

    [Test]
    public void ReadNextInt_MultiLineInput1_ReturnsZero()
    {
        var input = """
            123
            456
            789
            """;
        var index = 5;


        var rv = Utils.ReadNextInt(input, ref index);


        Assert.That(rv, Is.EqualTo(456));
        Assert.That(index, Is.EqualTo(8));
    }

    [Test]
    public void ReadNextInt_MultiLineInput2_ReturnsZero()
    {
        var input = """
            123
            456
            789
            """;
        var index = 4;


        var rv = Utils.ReadNextInt(input, ref index);


        Assert.That(rv, Is.EqualTo(456));
        Assert.That(index, Is.EqualTo(8));
    }

    [Test]
    public void ReadNextInt_NoMoreDigits_ReturnsMinusOne()
    {
        var input = "  ";
        var index = 1;


        var rv = Utils.ReadNextInt(input, ref index);


        Assert.That(rv, Is.EqualTo(-1));
    }
}