using ByteDev.Strings.StringCommands;
using NUnit.Framework;

namespace ByteDev.Strings.UnitTests.StringCommands
{
    [TestFixture]
    public class CaseToLowerCommandTests
    {
        [TestCase(null)]
        [TestCase("")]
        public void WhenValueIsNullOrEmpty_ThenSetToValue(string value)
        {
            var sut = new CaseToLowerCommand();

            sut.SetValue(value);
            sut.Execute();

            Assert.That(sut.Result, Is.EqualTo(value));
        }

        [Test]
        public void WhenValueIsNotNullOrEmpty_ThenSet()
        {
            var sut = new CaseToLowerCommand();

            sut.SetValue("John Smith");
            sut.Execute();

            Assert.That(sut.Result, Is.EqualTo("john smith"));
        }
    }
}