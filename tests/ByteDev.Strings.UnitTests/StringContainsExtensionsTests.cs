using System;
using System.Linq;
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
        public class ContainsOnly : StringContainsExtensionsTests
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
        public class ContainsAny : StringContainsExtensionsTests
        {
            [Test]
            public void WhenSourceIsNull_ThenReturnFalse()
            {
                var result = StringContainsExtensions.ContainsAny(null, "ABC");

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenAllowedCharsIsNull_ThenReturnFalse()
            {
                var result = "ABC".ContainsAny(null as string);

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenAllowedCharsEmpty_ThenReturnFalse()
            {
                var result = "ABC".ContainsOnly(string.Empty);

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
    }
}