using ByteDev.Strings.StringCommands;
using NUnit.Framework;

namespace ByteDev.Strings.UnitTests.StringCommands
{
    [TestFixture]
    public class RemoveCommandTests
    {
        private const string Value = "John Smith John Smith";

        [TestCase(null)]
        [TestCase("")]
        public void WhenValueIsNullOrEmpty_ThenSetSame(string value)
        {
            var sut = new RemoveCommand("Smith").SetValue(value);
            
            sut.Execute();

            Assert.That(sut.Result, Is.EqualTo(value));
        }

        [TestCase(null)]
        [TestCase("")]
        public void WhenRemoveValueIsNullOrEmpty_ThenSetSame(string removeValue)
        {
            var sut = new RemoveCommand(removeValue).SetValue(Value);

            sut.Execute();
            
            Assert.That(sut.Result, Is.EqualTo(Value));
        }

        [Test]
        public void WhenRemoveValueNotPresent_ThenSetSame()
        {
            var sut = new RemoveCommand("Peter").SetValue(Value);

            sut.Execute();

            Assert.That(sut.Result, Is.EqualTo(Value));
        }

        [Test]
        public void WhenRemoveValuePresent_ThenSet()
        {
            var sut = new RemoveCommand("John").SetValue(Value);

            sut.Execute();
            
            Assert.That(sut.Result, Is.EqualTo(" Smith  Smith"));
        }
    }
}