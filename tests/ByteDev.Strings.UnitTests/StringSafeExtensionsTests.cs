using NUnit.Framework;

namespace ByteDev.Strings.UnitTests
{
    [TestFixture]
    public class StringSafeExtensionsTests
    {
        [TestFixture]
        public class SafeLength : StringExtensionsTests
        {
            [Test]
            public void WhenIsNull_ThenReturnZero()
            {
                var result = StringSafeExtensions.SafeLength(null);

                Assert.That(result, Is.EqualTo(0));
            }

            [Test]
            public void WhenIsNotNull_ThenReturnLength()
            {
                var sut = "123";

                var result = sut.SafeLength();

                Assert.That(result, Is.EqualTo(3));
            }
        }

        [TestFixture]
        public class SafeSubstring
        {
            [Test]
            public void WhenIsNull_ThenReturnEmpty()
            {
                var result = StringSafeExtensions.SafeSubstring(null, 0, 5);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenIsEmpty_ThenReturnEmpty()
            {
                var sut = string.Empty;

                var result = sut.SafeSubstring(0, 5);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenLengthIsLessThanOne_ThenReturnEmpty()
            {
                const string sut = "John Smith";

                var result = sut.SafeSubstring(0, 0);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenSourceLengthIsEqualToStart_ThenReturnEmpty()
            {
                const string sut = "John Smith";

                var result = sut.SafeSubstring(sut.Length, 5);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenDesiredLengthIsGreaterThanSourceLength_ThenReturnSource()
            {
                const string sut = "John Smith";

                var result = sut.SafeSubstring(5, 6);

                Assert.That(result, Is.EqualTo("Smith"));
            }

            [Test]
            public void WhenRangeIsWithinSource_ThenReturnRequiredRangeOfChars()
            {
                const string sut = "John Smith";

                var result = sut.SafeSubstring(5, 5);

                Assert.That(result, Is.EqualTo("Smith"));
            }
        }
    }
}