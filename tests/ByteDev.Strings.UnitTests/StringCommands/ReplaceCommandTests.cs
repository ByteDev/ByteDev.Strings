using ByteDev.Strings.StringCommands;
using NUnit.Framework;

namespace ByteDev.Strings.UnitTests.StringCommands
{
    [TestFixture]
    public class ReplaceCommandTests
    {
        private const string Value = "John Smith John Smith";

        [TestCase(null)]
        [TestCase("")]
        public void WhenValueIsNullOrEmpty_ThenSetSame(string value)
        {
            var sut = new ReplaceCommand("John", "Peter");

            sut.SetValue(value);
            sut.Execute();

            Assert.That(sut.Result, Is.EqualTo(value));
        }

        [TestCase(null)]
        [TestCase("")]
        public void WhenOldValueIsNullOrEmpty_ThenSetSame(string oldValue)
        {
            var sut = new ReplaceCommand(oldValue, "Peter");

            sut.SetValue(Value);
            sut.Execute();

            Assert.That(sut.Result, Is.EqualTo(Value));
        }

        [TestCase(null)]
        [TestCase("")]
        public void WhenNewValueIsNullOrEmpty_ThenReplaceWithEmpty(string newValue)
        {
            var sut = new ReplaceCommand("John", newValue);

            sut.SetValue(Value);
            sut.Execute();

            Assert.That(sut.Result, Is.EqualTo(" Smith  Smith"));
        }

        [Test]
        public void WhenOldValueValueNotPresent_ThenSetSame()
        {
            var sut = new ReplaceCommand("Jill", "Peter");

            sut.SetValue(Value);
            sut.Execute();

            Assert.That(sut.Result, Is.EqualTo(Value));
        }

        [Test]
        public void WhenOldValuePresent_ThenReplaceWithNewValue()
        {
            var sut = new ReplaceCommand("John", "Peter");

            sut.SetValue(Value);
            sut.Execute();

            Assert.That(sut.Result, Is.EqualTo("Peter Smith Peter Smith"));
        }
    }
}