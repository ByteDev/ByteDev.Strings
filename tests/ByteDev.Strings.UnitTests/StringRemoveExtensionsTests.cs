using System;
using NUnit.Framework;

namespace ByteDev.Strings.UnitTests
{
    [TestFixture]
    public class StringRemoveExtensionsTests
    {
        [TestFixture]
        public class RemoveStartsWith : StringExtensionsTests
        {
            private const string Sut = "My name is John";

            [TestCase(null)]
            [TestCase("")]
            public void WhenSourceIsNullOrEmpty_ThenReturnSame(string sut)
            {
                var result = sut.RemoveStartsWith("M");

                Assert.That(result, Is.EqualTo(sut));
            }

            [Test]
            public void WhenValueIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => Sut.RemoveStartsWith(null));
            }

            [Test]
            public void WhenValueIsEmpty_ThenReturnSource()
            {
                var result = Sut.RemoveStartsWith(string.Empty);

                Assert.That(result, Is.EqualTo(Sut));
            }

            [Test]
            public void WhenDoesNotStartWithValue_ThenReturnSource()
            {
                var result = Sut.RemoveStartsWith("name");

                Assert.That(result, Is.EqualTo(Sut));
            }

            [Test]
            public void WhenValueIsLongerThanSource_ThenReturnSource()
            {
                var result = Sut.RemoveStartsWith(Sut + " Smith");

                Assert.That(result, Is.EqualTo(Sut));
            }

            [Test]
            public void WhenStartsWithValue_ThenRemoveStartingValue()
            {
                var result = Sut.RemoveStartsWith("My");

                Assert.That(result, Is.EqualTo(" name is John"));
            }
        }

        [TestFixture]
        public class RemoveEndsWith : StringExtensionsTests
        {
            private const string Sut = "My name is John";

            [TestCase(null)]
            [TestCase("")]
            public void WhenSourceIsNullOrEmpty_ThenReturnSame(string sut)
            {
                var result = sut.RemoveEndsWith("M");

                Assert.That(result, Is.EqualTo(sut));
            }

            [Test]
            public void WhenValueIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => Sut.RemoveEndsWith(null));
            }

            [Test]
            public void WhenValueIsEmpty_ThenReturnSource()
            {
                var result = Sut.RemoveEndsWith(string.Empty);

                Assert.That(result, Is.EqualTo(Sut));
            }

            [Test]
            public void WhenDoesNotEndWithValue_ThenReturnSource()
            {
                var result = Sut.RemoveEndsWith("name");

                Assert.That(result, Is.EqualTo(Sut));
            }

            [Test]
            public void WhenValueIsLongerThanSource_ThenReturnSource()
            {
                var result = Sut.RemoveEndsWith(Sut + " Smith");

                Assert.That(result, Is.EqualTo(Sut));
            }

            [Test]
            public void WhenEndsWithValue_ThenRemoveEndingValue()
            {
                var result = Sut.RemoveEndsWith("John");

                Assert.That(result, Is.EqualTo("My name is "));
            }
        }

        [TestFixture]
        public class RemoveBracketedText
        {
            [Test]
            public void WhenOneSetOfBrackets_ThenRemoveBracketText()
            {
                var result = "Something in (brackets)".RemoveBracketedText();

                Assert.That(result, Is.EqualTo("Something in "));
            }

            [Test]
            public void WhenMultipleSetsOfBrackets_ThenRemoveBracketText()
            {
                var result = "Something in (brackets) and (more)".RemoveBracketedText();

                Assert.That(result, Is.EqualTo("Something in  and "));
            }

            [Test]
            public void WhenNoClosingBracket_ThenRemoveBracketText()
            {
                var result = "Something in (brackets".RemoveBracketedText();

                Assert.That(result, Is.EqualTo("Something in "));
            }

            [Test]
            public void WhenBracketDoesntExist_ThenNotRemoveAnything()
            {
                var result = "Something in brackets".RemoveBracketedText();

                Assert.That(result, Is.EqualTo("Something in brackets"));
            }

            [Test]
            public void WhenBracketsAreFirstChar_ThenRemoveBracketText()
            {
                var result = "(Something) in (brackets) again".RemoveBracketedText();

                Assert.That(result, Is.EqualTo(" in  again"));
            }

            [Test]
            public void WhenTextIsAllInBrackets_ThenRemoveBracketText()
            {
                var result = "(Something in brackets)".RemoveBracketedText();

                Assert.That(result, Is.EqualTo(string.Empty));
            }

            [Test]
            public void WhenIsEmpty_ThenReturnEmpty()
            {
                var result = string.Empty.RemoveBracketedText();

                Assert.That(result, Is.EqualTo(string.Empty));
            }

            [Test]
            public void WhenIsNull_ThenReturnNull()
            {
                var result = StringRemoveExtensions.RemoveBracketedText(null);

                Assert.That(result, Is.Null);
            }
        }

        [TestFixture]
        public class RemoveWhiteSpace
        {
            [TestCase(null)]
            [TestCase("")]
            [TestCase("Something")]
            public void WhenIsHasNoWhiteSpace_ThenReturnSame(string sut)
            {
                var result = sut.RemoveWhiteSpace();

                Assert.That(result, Is.EqualTo(sut));
            }

            [TestCase(" something    and  something else   \n\r")]
            [TestCase("  something       and something   else    ")]
            public void WhenHasWhiteSpace_ThenRemove(string sut)
            {
                var result = sut.RemoveWhiteSpace();

                Assert.That(result, Is.EqualTo("somethingandsomethingelse"));
            }
        }

        [TestFixture]
        public class RemoveNonDigits : StringRemoveExtensionsTests
        {
            [TestCase(null)]
            [TestCase("")]
            [TestCase("0")]
            [TestCase("01")]
            public void WhenIsNullOrEmptyOrHasDigits_ThenReturnEqualString(string sut)
            {
                var result = sut.RemoveNonDigits();
                
                Assert.That(result, Is.EqualTo(sut));
            }

            [TestCase("A", "")]
            [TestCase("B0", "0")]
            [TestCase("a0b1", "01")]
            [TestCase(" 0 1 2 3 4 5 6 7 8 9 ", "0123456789")]
            public void WhenHasNonDigits_ThenReturnOnlyDigits(string sut, string expected)
            {
                var result = sut.RemoveNonDigits();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class Remove
        {
            [Test]
            public void WhenSourceIsNull_ThenReturnSource()
            {
                var result = StringRemoveExtensions.Remove(null, "ABC");

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenSourceIsEmpty_ThenReturnSource()
            {
                var result = string.Empty.Remove("ABC");

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenValueExists_ThenReturnRemoved()
            {
                var result = "some ABC thing".Remove("ABC");

                Assert.That(result, Is.EqualTo("some  thing"));
            }

            [Test]
            public void WhenValueExists_AndCaseInsensitive_ThenReturnRemoved()
            {
                var result = "some abc thing".Remove("ABC", true);

                Assert.That(result, Is.EqualTo("some  thing"));
            }

            [Test]
            public void WhenValuesExists_ThenReturnRemoved()
            {
                var result = "some ABC thing 123".Remove(new []{ "ABC", "123" });

                Assert.That(result, Is.EqualTo("some  thing "));
            }

            [Test]
            public void WhenValuesExists_AndCaseInsensitive_ThenReturnRemoved()
            {
                var result = "some abc thing 123".Remove(new []{ "ABC", "123" }, true);

                Assert.That(result, Is.EqualTo("some  thing "));
            }
        }
    }
}