using NUnit.Framework;

namespace ByteDev.Strings.UnitTests
{
    [TestFixture]
    public class StringNewLineExtensionsTests
    {
        [TestFixture]
        public class GetEndNewLine : StringExtensionsTests
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenNullOrEmpty_ThenReturnEmpty(string sut)
            {
                var result = sut.GetEndNewLine();

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenHasNoEndLineChars_ThenReturnEmpty()
            {
                var result = "Line 1".GetEndNewLine();

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenHasNoEndLineChars_AndMultiLine_ThenReturnEmpty()
            {
                var result = "Line 1\r\nLine2"
                    .GetEndNewLine();

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenHasWindowsEndLineChars_ThenReturnWindowsEndLineChars()
            {
                var result = "Line 1\nLine2\r\n"
                    .GetEndNewLine();

                Assert.That(result, Is.EqualTo("\r\n"));
            }

            [Test]
            public void WhenHasUnixEndLineChars_ThenReturnUnixEndLineChars()
            {
                var result = "Line 1\r\nLine2\n"
                    .GetEndNewLine();

                Assert.That(result, Is.EqualTo("\n"));
            }
        }

        [TestFixture]
        public class RemoveEndNewLine : StringExtensionsTests
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenNullOrEmpty_ThenReturnSame(string sut)
            {
                var result = sut.RemoveEndNewLine();

                Assert.That(result, Is.EqualTo(sut));
            }

            [Test]
            public void WhenHasNoEndLineChars_ThenReturnSame()
            {
                const string sut = "Line number 1";

                var result = sut.RemoveEndNewLine();

                Assert.That(result, Is.EqualTo(sut));
            }

            [Test]
            public void WhenHasWindowsEndLineChars_ThenRemove()
            {
                const string sut = "Line number 1\r\n" +
                                   "Line number 2\r\n";

                const string expected = "Line number 1\r\n" +
                                        "Line number 2";

                var result = sut.RemoveEndNewLine();

                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void WhenHasUnixEndLineChars_ThenRemove()
            {
                const string sut = "Line number 1\n" +
                                   "Line number 2\n";

                const string expected = "Line number 1\n" +
                                        "Line number 2";

                var result = sut.RemoveEndNewLine();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class DetectNewLineType : StringNewLineExtensionsTests
        {
            [TestCase(null)]
            [TestCase("")]
            [TestCase("This is some text.")]
            public void WhenNoReturn_ThenReturnNone(string sut)
            {
                var result = sut.DetectNewLineType();

                Assert.That(result, Is.EqualTo(NewLineType.None));
            }

            [TestCase("\r\n")]
            [TestCase("Text\r\n")]
            [TestCase("\r\nText\r\n")]
            [TestCase("\r\nThis is\r\nsome text\r\n")]
            public void WhenContainsOnlyWindowsNewLine_ThenReturnWindows(string sut)
            {
                var result = sut.DetectNewLineType();
                
                Assert.That(result, Is.EqualTo(NewLineType.Windows));
            }

            [TestCase("\n")]
            [TestCase("Text\n")]
            [TestCase("\nText\n")]
            [TestCase("\nThis is\nsome text\n")]
            public void WhenContainsOnlyUnixNewLine_ThenReturnUnix(string sut)
            {
                var result = sut.DetectNewLineType();

                Assert.That(result, Is.EqualTo(NewLineType.Unix));
            }

            [TestCase("\n\r\n")]
            [TestCase("\nText\r\n")]
            [TestCase("\r\nText\n")]
            [TestCase("\r\nThis is\nsome text\r\n")]
            public void WhenContainsWindowsAndUnix_ThenReturnMix(string sut)
            {
                var result = sut.DetectNewLineType();

                Assert.That(result, Is.EqualTo(NewLineType.Mix));
            }
        }

        [TestFixture]
        public class NormalizeNewLinesToUnix : StringNewLineExtensionsTests
        {
            [TestCase(null)]
            [TestCase("")]
            [TestCase("Some text.")]
            [TestCase("Some text\n.")]
            public void WhenNotContainWindowsNewLine_ThenSame(string sut)
            {
                var result = sut.NormalizeNewLinesToUnix();

                Assert.That(result, Is.EqualTo(sut));
            }

            [TestCase("\r\n", "\n")]
            [TestCase("\n\r", "\n")]
            [TestCase("\n", "\n")]
            [TestCase("\r", "\n")]
            [TestCase("\r\nThis is\nsome text\n\r", "\nThis is\nsome text\n")]
            public void WhenContainsWindowsAndUnix_ThenNormalizeToUnix(string sut, string expected)
            {
                var result = sut.NormalizeNewLinesToUnix();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class NormalizeNewLinesToWindows : StringNewLineExtensionsTests
        {
            [TestCase(null)]
            [TestCase("")]
            [TestCase("Some text.")]
            [TestCase("Some text\r\n.")]
            public void WhenNotContainUnixNewLine_ThenSame(string sut)
            {
                var result = sut.NormalizeNewLinesToWindows();

                Assert.That(result, Is.EqualTo(sut));
            }
            
            [TestCase("\r\n", "\r\n")]
            [TestCase("\n\r", "\r\n")]
            [TestCase("\n", "\r\n")]
            [TestCase("\r", "\r\n")]
            [TestCase("\n\r\n\r", "\r\n\r\n")]
            [TestCase("\r\nThis is\nsome text\r\n", "\r\nThis is\r\nsome text\r\n")]
            public void WhenContainsWindowsAndUnix_ThenNormalizeToWindows(string sut, string expected)
            {
                var result = sut.NormalizeNewLinesToWindows();

                Assert.That(result, Is.EqualTo(expected));
            }
        }
    }
}