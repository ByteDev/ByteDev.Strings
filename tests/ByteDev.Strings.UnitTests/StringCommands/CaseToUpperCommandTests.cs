using ByteDev.Strings.StringCommands;
using NUnit.Framework;

namespace ByteDev.Strings.UnitTests.StringCommands
{
    [TestFixture]
    public class CaseToUpperCommandTests
    {
        [TestCase(null)]
        [TestCase("")]
        public void WhenValueIsNullOrEmpty_ThenSetToValue(string value)
        {
            var sut = new CaseToUpperCommand().SetValue(value);

            sut.Execute();

            Assert.That(sut.Result, Is.EqualTo(value));
        }

        [Test]
        public void WhenValueIsNotNullOrEmpty_ThenSet()
        {
            var sut = new CaseToUpperCommand().SetValue("John Smith");

            sut.Execute();

            Assert.That(sut.Result, Is.EqualTo("JOHN SMITH"));
        }
    }
}