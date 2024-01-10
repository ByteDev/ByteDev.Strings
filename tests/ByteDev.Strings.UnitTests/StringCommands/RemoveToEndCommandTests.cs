using ByteDev.Strings.StringCommands;
using NUnit.Framework;

namespace ByteDev.Strings.UnitTests.StringCommands;

[TestFixture]
public class RemoveToEndCommandTests
{
    private const string Value = "John Smith";

    [TestCase(null)]
    [TestCase("")]
    public void WhenValueIsNullOrEmpty_ThenSetSame(string value)
    {
        var sut = new RemoveToEndCommand(0).SetValue(value);

        sut.Execute();

        Assert.That(sut.Result, Is.EqualTo(value));
    }

    [TestCase(-1, "")]
    [TestCase(0, "")]
    [TestCase(1, "J")]
    [TestCase(2, "Jo")]
    [TestCase(9, "John Smit")]
    [TestCase(10, "John Smith")]
    [TestCase(11, "John Smith")]
    public void WhenPositionSet_ThenSet(int position, string expected)
    {
        var sut = new RemoveToEndCommand(position).SetValue(Value);

        sut.Execute();

        Assert.That(sut.Result, Is.EqualTo(expected));
    }
}