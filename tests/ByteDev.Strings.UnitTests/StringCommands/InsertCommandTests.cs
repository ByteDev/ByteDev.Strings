using ByteDev.Strings.StringCommands;
using NUnit.Framework;

namespace ByteDev.Strings.UnitTests.StringCommands
{
    [TestFixture]
    public class InsertCommandTests
    {
        private const string Value = "John Smith";

        [TestCase(null)]
        [TestCase("")]
        public void WhenValueIsNullOrEmpty_ThenSetToInsertValue(string value)
        {
            var sut = new InsertCommand(10, "Peter");

            sut.SetValue(value);
            sut.Execute();

            Assert.That(sut.Result, Is.EqualTo("Peter"));
        }
        
        [TestCase(-1, "Peter" + Value)]
        [TestCase(0, "Peter" + Value)]
        [TestCase(1, "JPeterohn Smith")]
        [TestCase(9, "John SmitPeterh")]
        [TestCase(10, Value + "Peter")]
        [TestCase(11, Value + "Peter")]
        public void WhenPositionSet_ThenSet(int position, string expected)
        {
            var sut = new InsertCommand(position, "Peter");

            sut.SetValue(Value);
            sut.Execute();

            Assert.That(sut.Result, Is.EqualTo(expected));
        }

        [TestCase(null)]
        [TestCase("")]
        public void WhenInsertValueIsNullOrEmpty_ThenSetToValue(string insertValue)
        {
            var sut = new InsertCommand(0, insertValue);

            sut.SetValue(Value);
            sut.Execute();

            Assert.That(sut.Result, Is.EqualTo(Value));
        }
    }
}