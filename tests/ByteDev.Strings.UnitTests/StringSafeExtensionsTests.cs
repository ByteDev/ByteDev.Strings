using NUnit.Framework;

namespace ByteDev.Strings.UnitTests
{
    [TestFixture]
    public class StringSafeExtensionsTests
    {
        [TestFixture]
        public class SafeLength : StringExtensionsTests
        {
            [TestCase(null, 0)]
            [TestCase("", 0)]
            [TestCase("A", 1)]
            [TestCase("A1", 2)]
            public void WhenCalled_ThenReturnLength(string sut, int expected)
            {
                var result = sut.SafeLength();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class SafeSubstring
        {
            private const string Sut = "John Smith";

            [TestCase(null)]
            [TestCase("")]
            public void WhenIsNullOrEmpty_ThenReturnEmpty(string sut)
            {
                var result = sut.SafeSubstring(0, 1);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenStartIndexIsLessThanZero_ThenUseStartIndexZero()
            {
                var result = Sut.SafeSubstring(-1, 4);

                Assert.That(result, Is.EqualTo("John"));
            }

            [TestCase(10)]
            [TestCase(11)]
            public void WhenStartIndexIsEqualOrGreaterThanLength_ThenReturnEmpty(int startIndex)
            {
                var result = Sut.SafeSubstring(startIndex, 1);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenLengthIsLessThanOne_ThenReturnEmpty()
            {
                var result = Sut.SafeSubstring(0, 0);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenLengthIsGreaterThanSourceLength_ThenReturnString()
            {
                var result = Sut.SafeSubstring(5, 6);

                Assert.That(result, Is.EqualTo("Smith"));
            }

            [Test]
            public void WhenRangeIsInbounds_ThenReturnString()
            {
                var result = Sut.SafeSubstring(5, 5);

                Assert.That(result, Is.EqualTo("Smith"));
            }
        }

        [TestFixture]
        public class SafeSubstring_NoLength
        {
            private const string Sut = "John Smith";

            [TestCase(null)]
            [TestCase("")]
            public void WhenIsNullOrEmpty_ThenReturnEmpty(string sut)
            {
                var result = sut.SafeSubstring(0);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenStartIndexIsLessThanZero_ThenReturnSameString()
            {
                var result = Sut.SafeSubstring(-1);

                Assert.That(result, Is.EqualTo(Sut));
            }

            [TestCase(10)]
            [TestCase(11)]
            public void WhenStartIndexIsEqualOrGreaterThanLength_ThenReturnEmpty(int startIndex)
            {
                var result = Sut.SafeSubstring(startIndex);

                Assert.That(result, Is.Empty);
            }

            [TestCase(0, "John Smith")]
            [TestCase(1, "ohn Smith")]
            [TestCase(9, "h")]
            public void WhenStartIndexIsInbounds_ThenReturnString(int startIndex, string expected)
            {
                var result = Sut.SafeSubstring(startIndex);

                Assert.That(result, Is.EqualTo(expected));
            }
        }
    }
}