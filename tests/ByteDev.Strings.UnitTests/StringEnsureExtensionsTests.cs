using NUnit.Framework;

namespace ByteDev.Strings.UnitTests
{
    [TestFixture]
    public class StringEnsureExtensionsTests
    {
        [TestFixture]
        public class EnsureStartsWith
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenPrefixIsNullOrEmpty_ThenReturnSource(string prefix)
            {
                const string sut = "Something";

                var result = sut.EnsureStartsWith(prefix);

                Assert.That(result, Is.EqualTo(sut));
            }

            [TestCase(null)]
            [TestCase("")]
            public void WhenIsNullOrEmpty_ThenReturnPrefix(string sut)
            {
                var result = sut.EnsureStartsWith("thing");

                Assert.That(result, Is.EqualTo("thing"));
            }

            [Test]
            public void WhenPrefixExists_ThenReturnUnchanged()
            {
                const string sut = "Something";

                var result = sut.EnsureStartsWith("Some");

                Assert.That(result, Is.EqualTo(sut));
            }

            [Test]
            public void WhenPrefixDoesNotExists_ThenReturnWithPrefix()
            {
                const string sut = "thing";

                var result = sut.EnsureStartsWith("Some");

                Assert.That(result, Is.EqualTo("Some" + sut));
            }
        }

        [TestFixture]
        public class EnsureEndsWith
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenSuffixIsNullOrEmpty_ThenReturnSource(string suffix)
            {
                const string sut = "Something";

                var result = sut.EnsureEndsWith(suffix);

                Assert.That(result, Is.EqualTo(sut));
            }

            [TestCase(null)]
            [TestCase("")]
            public void WhenIsNullOrEmpty_ThenReturnSuffix(string sut)
            {
                var result = sut.EnsureEndsWith("thing");

                Assert.That(result, Is.EqualTo("thing"));
            }

            [Test]
            public void WhenSuffixExists_ThenReturnUnchanged()
            {
                const string sut = "Something";

                var result = sut.EnsureEndsWith("thing");

                Assert.That(result, Is.EqualTo(sut));
            }

            [Test]
            public void WhenSuffixDoesNotExists_ThenReturnWithSuffix()
            {
                const string sut = "Some";

                var result = sut.EnsureEndsWith("thing");

                Assert.That(result, Is.EqualTo(sut + "thing"));
            }
        }
    }
}