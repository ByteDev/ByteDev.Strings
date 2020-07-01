using ByteDev.Strings.StringCommands;
using NUnit.Framework;

namespace ByteDev.Strings.UnitTests.StringCommands
{
    [TestFixture]
    public class CutPasteCommandTests
    {
        private const string Value = "John Smith";

        [Test]
        public void WhenValueIsNull_ThenSetToNull()
        {
            var sut = new CutPasteCommand(0, 2, 5);

            sut.Execute();

            Assert.That(sut.Result, Is.Null);
        }
        
        [Test]
        public void WhenCopyLengthIsLessThanOne_ThenSetToSame()
        {
            var sut = new CutPasteCommand(0, 0, 5);

            sut.SetValue(Value);
            sut.Execute();

            Assert.That(sut.Result, Is.EqualTo(Value));
        }

        [TestCase(10, 1, 0)]
        [TestCase(11, 1, 0)]
        public void WhenCopyPositionEqualsOrGreaterThanValueLength_ThenSetToSame(int copyPosition, int copyLength, int pastePosition)
        {
            var sut = new CutPasteCommand(copyPosition, copyLength, pastePosition);

            sut.SetValue(Value);
            sut.Execute();

            Assert.That(sut.Result, Is.EqualTo(Value));
        }

        [Test]
        public void WhenPastePositionGreaterThanLength_ThenPasteAtEnd()
        {
            var sut = new CutPasteCommand(0, 4, Value.Length + 1);

            sut.SetValue(Value);
            sut.Execute();

            Assert.That(sut.Result, Is.EqualTo(" SmithJohn"));
        }

        // John Smith
        // 0123456789

        [TestCase(5, 5, "SmithJohn ")]
        [TestCase(5, 6, "SmithJohn ")]
        [TestCase(5, 7, "SmithJohn ")]
        [TestCase(1, 10, "ohn SmithJ")]
        [TestCase(9, 2, "hJohn Smit")]
        public void WhenCutLength_ThenCopyTillEnd(int cutPosition, int cutLength, string expected)
        {
            var sut = new CutPasteCommand(cutPosition, cutLength, 0);

            sut.SetValue(Value);
            sut.Execute();

            Assert.That(sut.Result, Is.EqualTo(expected));
        }

        [TestCase(0, 4, 0, "John Smith")]
        [TestCase(0, 4, 1, " JohnSmith")]
        [TestCase(0, 4, 10, " SmithJohn")]
        [TestCase(0, 10, 10, "")]
        [TestCase(0, 11, 10, "")]
        public void WhenCutParamsWithinValue_ThenPaste(int cutPosition, int cutLength, int pastePosition, string expected)
        {
            var sut = new CutPasteCommand(cutPosition, cutLength, pastePosition);

            sut.SetValue(Value);
            sut.Execute();

            Assert.That(sut.Result, Is.EqualTo(expected));
        }
    }
}