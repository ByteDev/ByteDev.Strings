using ByteDev.Strings.StringCommands;
using NUnit.Framework;

namespace ByteDev.Strings.UnitTests.StringCommands;

[TestFixture]
public class RemovePositionCommandTests
{
    private const string Value = "John Smith";

    [TestCase(null)]
    [TestCase("")]
    public void WhenValueIsNullOrEmpty_ThenSetSame(string value)
    {
        var sut = new RemovePositionCommand(0, 1).SetValue(value);

        sut.Execute();
        
        Assert.That(sut.Result, Is.EqualTo(value));
    }

    [TestCase(-1, "ohn Smith")]
    [TestCase(0, "ohn Smith")]
    [TestCase(9, "John Smit")]
    [TestCase(10, "John Smith")]
    [TestCase(11, "John Smith")]
    public void WhenPositionSet_ThenSet(int position, string expected)
    {
        var sut = new RemovePositionCommand(position, 1).SetValue(Value);

        sut.Execute();

        Assert.That(sut.Result, Is.EqualTo(expected));
    }

    [TestCase(0, 1, "ohn Smith")]
    [TestCase(0, 10, "")]
    [TestCase(9, 1, "John Smit")]
    [TestCase(9, 2, "John Smit")]
    [TestCase(10, 1, "John Smith")]
    public void WhenLengthSet_ThenSet(int position, int length, string expected)
    {
        var sut = new RemovePositionCommand(position, length).SetValue(Value);

        sut.Execute();
        
        Assert.That(sut.Result, Is.EqualTo(expected));
    }
}