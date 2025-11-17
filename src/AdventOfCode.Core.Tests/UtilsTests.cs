namespace AdventOfCode.Core.Tests;

[TestFixture]
public class UtilsTests
{
    [Test]
    public void ReadNextInt_IndexOutOfBounds_ReturnsMinusOne()
    {
        var input = "1234";
        var index = 5;


        var rv = Utils.ReadNextInt(input, ref index);


        Assert.That(rv, Is.EqualTo(-1));
    }

    [Test]
    public void ReadNextInt_EmptyString_ReturnsMinusOne()
    {
        var input = "";
        var index = 5;


        var rv = Utils.ReadNextInt(input, ref index);


        Assert.That(rv, Is.EqualTo(-1));
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
        var input = "123\r\n456";
        var index = 5;


        var rv = Utils.ReadNextInt(input, ref index);


        Assert.That(rv, Is.EqualTo(456));
        Assert.That(index, Is.EqualTo(8));
    }

    [Test]
    public void ReadNextInt_MultiLineInput2_ReturnsZero()
    {
        var input = "123\r\n456";
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


    [Test]
    public void ReadNextString_IndexOutOfBounds_ReturnsNull()
    {
        var input = "abcd";
        var index = 5;


        var rv = Utils.ReadNextString(input, ref index);


        Assert.That(rv, Is.Null);
    }

    [Test]
    public void ReadNextString_EmptyString_ReturnsNull()
    {
        var input = "";
        var index = 5;


        var rv = Utils.ReadNextString(input, ref index);


        Assert.That(rv, Is.Null);
    }

    [Test]
    public void ReadNextString_WithLeadingWhitespace_ReturnsExpectedValue()
    {
        var input = "  abc";
        var index = 0;


        var rv = Utils.ReadNextString(input, ref index);


        Assert.That(rv, Is.EqualTo("abc"));
        Assert.That(index, Is.EqualTo(5));
    }

    [Test]
    public void ReadNextString_MultiLineInput1_ReturnsZero()
    {
        var input = "abc\r\ndef";
        var index = 5;


        var rv = Utils.ReadNextString(input, ref index);


        Assert.That(rv, Is.EqualTo("def"));
        Assert.That(index, Is.EqualTo(8));
    }

    [Test]
    public void ReadNextString_MultiLineInput2_ReturnsZero()
    {
        var input = "abc\r\ndef";
        var index = 4;


        var rv = Utils.ReadNextString(input, ref index);


        Assert.That(rv, Is.EqualTo("def"));
        Assert.That(index, Is.EqualTo(8));
    }

    [Test]
    public void ReadNextString_NoMoreDigits_ReturnsNull()
    {
        var input = "  ";
        var index = 1;


        var rv = Utils.ReadNextString(input, ref index);


        Assert.That(rv, Is.Null);
    }
}