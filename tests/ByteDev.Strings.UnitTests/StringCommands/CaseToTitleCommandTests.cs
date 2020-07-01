using ByteDev.Strings.StringCommands;
using NUnit.Framework;

namespace ByteDev.Strings.UnitTests.StringCommands
{
    [TestFixture]
    public class CaseToTitleCommandTests
    {
        [TestCase(null)]
        [TestCase("")]
        public void WhenValueIsNullOrEmpty_ThenSetToValue(string value)
        {
            var sut = new CaseToTitleCommand().SetValue(value);

            sut.Execute();

            Assert.That(sut.Result, Is.EqualTo(value));
        }

        [Test]
        public void WhenValueIsNotNullOrEmpty_ThenSet()
        {
            var sut = new CaseToTitleCommand().SetValue("john smith");

            sut.Execute();

            Assert.That(sut.Result, Is.EqualTo("John Smith"));
        }
    }
}