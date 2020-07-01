using ByteDev.Strings.StringCommands;
using NUnit.Framework;

namespace ByteDev.Strings.UnitTests.StringCommands
{
    [TestFixture]
    public class CopyPasteCommandTests
    {
        private const string Value = "John Smith";

        [Test]
        public void WhenValueIsNull_ThenSetToNull()
        {
            var sut = new CopyPasteCommand(0, 2, 5);

            sut.Execute();

            Assert.That(sut.Result, Is.Null);
        }

        [Test]
        public void WhenCopyLengthIsLessThanOne_ThenSetToSame()
        {
            var sut = new CopyPasteCommand(0, 0, 5);

            sut.SetValue(Value);
            sut.Execute();

            Assert.That(sut.Result, Is.EqualTo(Value));
        }

        [TestCase(10, 1, 0)]
        [TestCase(11, 1, 0)]
        public void WhenCopyPositionEqualsOrGreaterThanValueLength_ThenSetToSame(int copyPosition, int copyLength, int pastePosition)
        {
            var sut = new CopyPasteCommand(copyPosition, copyLength, pastePosition);

            sut.SetValue(Value);
            sut.Execute();

            Assert.That(sut.Result, Is.EqualTo(Value));
        }

        [Test]
        public void WhenPastePositionGreaterThanLength_ThenPasteAtEnd()
        {
            var sut = new CopyPasteCommand(0, 4, Value.Length + 1);

            sut.SetValue(Value);
            sut.Execute();

            Assert.That(sut.Result, Is.EqualTo(Value + "John"));
        }

        [TestCase(5, 5, 0, "Smith" + Value)]
        [TestCase(5, 6, 0, "Smith" + Value)]
        [TestCase(5, 7, 0, "Smith" + Value)]
        [TestCase(1, 10, 0, "ohn Smith" + Value)]
        [TestCase(9, 2, 0, "h" + Value)]
        public void WhenCopyLengthWouldGoOutOfRange_ThenCopyTillEnd(int copyPosition, int copyLength, int pastePosition, string expected)
        {
            var sut = new CopyPasteCommand(copyPosition, copyLength, pastePosition);

            sut.SetValue(Value);
            sut.Execute();

            Assert.That(sut.Result, Is.EqualTo(expected));
        }

        [TestCase(0, 4, 0, "John" + Value)]
        [TestCase(0, 4, 1, "JJohnohn Smith")]
        [TestCase(0, 4, 10, Value + "John")]
        public void WhenCopyParamsWithinValue_ThenPaste(int copyPosition, int copyLength, int pastePosition, string expected)
        {
            var sut = new CopyPasteCommand(copyPosition, copyLength, pastePosition);

            sut.SetValue(Value);
            sut.Execute();

            Assert.That(sut.Result, Is.EqualTo(expected));
        }
    }
}