using NUnit.Framework;

namespace ByteDev.Strings.UnitTests
{
    [TestFixture]
    public class StringContainsExtensionsTests
    {
        [TestFixture]
        public class ContainsIgnoreCase
        {
            [Test]
            public void WhenSourceIsNull_ThenReturnsFalse()
            {
                var result = StringContainsExtensions.ContainsIgnoreCase(null, "A");

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenSourceIsEmpty_ThenReturnsFalse()
            {
                var result = string.Empty.ContainsIgnoreCase("A");

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenDoesNotContain_ThenReturnFalse()
            {
                var result = "ABC".ContainsIgnoreCase("D");

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenDoesContainWithSameCase_ThenReturnTrue()
            {
                var result = "ABC".ContainsIgnoreCase("B");

                Assert.That(result, Is.True);
            }

            [Test]
            public void WhenDoesContainWithDifferentCase_ThenReturnTrue()
            {
                var result = "ABC".ContainsIgnoreCase("b");

                Assert.That(result, Is.True);
            }
        }

        [TestFixture]
        public class ContainsOnly
        {
            [Test]
            public void WhenSourceIsNull_ThenReturnFalse()
            {
                var result = StringContainsExtensions.ContainsOnly(null, "ABC");

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenAllowedCharsIsNull_ThenReturnFalse()
            {
                var result = "ABC".ContainsOnly(null as string);

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenAllowedCharsEmpty_ThenReturnFalse()
            {
                var result = "ABC".ContainsOnly(string.Empty);

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenStringHasNotAllowedChars_ThenReturnFalse()
            {
                var result = "AB1C".ContainsOnly("ABC");

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenStringHasOnlyAllowedChars_ThenReturnTrue()
            {
                var result = "ABCCBA".ContainsOnly("ABCD");

                Assert.That(result, Is.True);
            }
        }

        [TestFixture]
        public class ContainsAny
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenSourceIsNullOrEmpty_ThenReturnFalse(string sut)
            {
                var result = sut.ContainsAny("ABC");

                Assert.That(result, Is.False);
            }

            [TestCase(null)]
            [TestCase("")]
            public void WhenCharsIsNullOrEmpty_ThenReturnFalse(string chars)
            {
                var result = "ABC".ContainsAny(chars);

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenStringDoesNotHaveAnyChars_ThenReturnFalse()
            {
                var result = "ABC".ContainsAny("DEF");

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenStringContainsChars_ThenReturnTrue()
            {
                var result = "ABC".ContainsAny("DEA");

                Assert.That(result, Is.True);
            }
        }

        [TestFixture]
        public class ContainsAll
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenSourceIsNullOrEmpty_ThenReturnFalse(string sut)
            {
                var result = sut.ContainsAll("ABC");

                Assert.That(result, Is.False);
            }

            [TestCase(null)]
            [TestCase("")]
            public void WhenCharsIsNullOrEmpty_ThenReturnTrue(string chars)
            {
                var result = "ABC".ContainsAll(chars);

                Assert.That(result, Is.True);
            }

            [TestCase("D")]
            [TestCase("ABCD")]
            public void WhenStringContainsNotAllChars_ThenReturnFalse(string chars)
            {
                var result = "ABC".ContainsAll(chars);

                Assert.That(result, Is.False);
            }

            [TestCase("A")]
            [TestCase("AB")]
            [TestCase("ABC")]
            [TestCase("BCA")]
            public void WhenStringContainsAllChars_ThenReturnTrue(string chars)
            {
                var result = "ABC".ContainsAll(chars);

                Assert.That(result, Is.True);
            }
        }
    }
}