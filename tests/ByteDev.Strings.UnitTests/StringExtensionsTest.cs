using System;
using NUnit.Framework;

namespace ByteDev.Strings.UnitTests
{
    [TestFixture]
    public class StringExtensionsTest
    {
        [TestFixture]
        public class SafeLength : StringExtensionsTest
        {
            [Test]
            public void WhenIsNull_ThenReturnZero()
            {
                var result = StringExtensions.SafeLength(null);

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
        public class RemoveStartsWith : StringExtensionsTest
        {
            private const string Sut = "My name is John";

            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => StringExtensions.RemoveStartsWith(null, "M"));
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
        public class RemoveEndsWith : StringExtensionsTest
        {
            private const string Sut = "My name is John";

            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => StringExtensions.RemoveEndsWith(null, "M"));
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
        public class ReplaceToken : StringExtensionsTest
        {
            [Test]
            public void WhenStringIsNull_ThenThrowException()
            {
                const string sut = null;

                Assert.Throws<ArgumentNullException>(() => sut.ReplaceToken("customerId", 123));
            }

            [Test]
            public void WhenStringIsEmpty_ThenReturnEmpty()
            {
                string sut = string.Empty;

                var result = sut.ReplaceToken("customerId", 123);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenOneTokenPresent_ThenReplaceToken()
            {
                const string sut = "/customer/{customerId}/activate";

                var result = sut.ReplaceToken("customerId", 123);

                Assert.That(result, Is.EqualTo("/customer/123/activate"));
            }

            [Test]
            public void WhenTwoTokensPresent_ThenReplaceBothTokens()
            {
                const string sut = "/customer/{customerId}/activate/{customerId}";

                var result = sut.ReplaceToken("customerId", 123);

                Assert.That(result, Is.EqualTo("/customer/123/activate/123"));
            }

            [Test]
            public void WhenTokenIsNull_ThenReturnEqualString()
            {
                const string sut = "/customer/{customerId}/activate";

                var result = sut.ReplaceToken(null, 123);

                Assert.That(result, Is.EqualTo("/customer/{customerId}/activate"));
            }

            [Test]
            public void WhenTokenIsEmpty_ThenReturnEqualString()
            {
                const string sut = "/customer/{customerId}/activate";

                var result = sut.ReplaceToken(string.Empty, 123);

                Assert.That(result, Is.EqualTo("/customer/{customerId}/activate"));
            }

            [Test]
            public void WhenStringHasNoTokens_ThenReturnEqualString()
            {
                const string sut = "/customer/activate";

                var result = sut.ReplaceToken("customerId", 123);

                Assert.That(result, Is.EqualTo("/customer/activate"));
            }

            [Test]
            public void WhenStringDoesNotHaveMatchingToken_ThenReturnEqualString()
            {
                const string sut = "/customer/{customerId}/activate";

                var result = sut.ReplaceToken("customerID", 123);

                Assert.That(result, Is.EqualTo("/customer/{customerId}/activate"));
            }
        }

        [TestFixture]
        public class FormatWith
        {
            [Test]
            public void WhenStringIsNull_ThenThrowException()
            {
                const string sut = null;
                Assert.Throws<ArgumentNullException>(() => sut.FormatWith(""));
            }

            [Test]
            public void WithZeroArgs_ThenThrowException()
            {
                const string sut = "John is {0}, Mike is {1}";

                Assert.Throws<FormatException>(() => sut.FormatWith());
            }

            [Test]
            public void WithTwoArgs_ThenFormatStringWithValues()
            {
                const string expected = "John is 25, Mike is 30";
                const string sut = "John is {0}, Mike is {1}";

                var result = sut.FormatWith(25, 30);
                
                Assert.That(result, Is.EqualTo(expected));
            }   
        }

        [TestFixture]
        public class LeftWithEllipsis
        {
            [Test]
            public void WhenMaxLengthIsLessThanStringLength_ThenTruncate()
            {
                const string sut = "1234567890";

                var result = sut.LeftWithEllipsis(5);

                Assert.That(result, Is.EqualTo("12..."));
            }

            [Test]
            public void WhenMaxLengthSameLength_ThenNotTruncate()
            {
                const string sut = "1234567890";

                var result = sut.LeftWithEllipsis(10);

                Assert.That(result, Is.EqualTo(sut));
            }

            [Test]
            public void WhenMaxLengthLongerThanLength_ThenNotTruncate()
            {
                const string sut = "1234567890";

                var result = sut.LeftWithEllipsis(11);

                Assert.That(result, Is.EqualTo(sut));
            }

            [Test]
            public void WhenMaxLengthZero_ThenReturnEmpty()
            {
                const string sut = "1234567890";

                var result = sut.LeftWithEllipsis(0);

                Assert.That(result, Is.EqualTo(string.Empty));
            }

            [Test]
            public void WhenMaxLengthMinusOne_ThenReturnEmpty()
            {
                const string sut = "1234567890";

                var result = sut.LeftWithEllipsis(-1);

                Assert.That(result, Is.EqualTo(string.Empty));
            }

            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                const string sut = null;

                Assert.Throws<ArgumentNullException>(() => sut.LeftWithEllipsis(10));
            }

            [Test]
            public void WhenMaxLengthOne_ThenThrowException()
            {
                const string sut = "1234567890";

                Assert.Throws<ArgumentOutOfRangeException>(() => sut.LeftWithEllipsis(1));
            }

            [Test]
            public void WhenMaxLengthIsEllipsisLength_ThenThrowException()
            {
                const string sut = "1234567890";

                Assert.Throws<ArgumentOutOfRangeException>(() => sut.LeftWithEllipsis(3));
            }
        }

        [TestFixture]
        public class RemoveWhiteSpace
        {
            [Test]
            public void WhenIsNull_ThenReturnNull()
            {
                var result = StringExtensions.RemoveWhiteSpace(null);

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenIsEmpty_ThenReturnEmpty()
            {
                string sut = string.Empty;

                var result = sut.RemoveWhiteSpace();

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenHasSpaces_ThenRemoveSpaces()
            {
                var result = " something    and  something else   ".RemoveWhiteSpace();

                Assert.That(result, Is.EqualTo("somethingandsomethingelse"));
            }

            [Test]
            public void WhenHasTabs_ThenRemoveTabs()
            {
                var result = "  something       and something   else    ".RemoveWhiteSpace();

                Assert.That(result, Is.EqualTo("somethingandsomethingelse"));
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
                var result = StringExtensions.RemoveBracketedText(null);

                Assert.That(result, Is.Null);
            }
        }

        [TestFixture]
        public class Pluralize
        {
            private const string Sut = "Item";

            [Test]
            public void WhenSourceIsEmpty_ThenReturnEmpty()
            {
                var result = string.Empty.Pluralize(2);

                Assert.That(result, Is.EqualTo(string.Empty));
            }

            [Test]
            public void WhenNumberIsMinusTwo_ThenAddPlural()
            {
                var result = Sut.Pluralize(-2);

                Assert.That(result, Is.EqualTo(Sut + "s"));
            }

            [Test]
            public void WhenNumberIsMinusOne_ThenNotAddPlural()
            {
                var result = Sut.Pluralize(-1);

                Assert.That(result, Is.EqualTo(Sut));
            }

            [Test]
            public void WhenNumberIsZero_ThenAddPlural()
            {
                var result = Sut.Pluralize(0);

                Assert.That(result, Is.EqualTo(Sut + "s"));
            }

            [Test]
            public void WhenNumberIsOne_ThenNotAddPlural()
            {
                var result = Sut.Pluralize(1);

                Assert.That(result, Is.EqualTo(Sut));
            }

            [Test]
            public void WhenNumberIsTwo_ThenAddPlural()
            {
                var result = Sut.Pluralize(2);

                Assert.That(result, Is.EqualTo(Sut + "s"));
            }
        }

        [TestFixture]
        public class CountOccurences
        {
            [Test]
            public void WhenSourceIsEmpty_ThenReturnZero()
            {
                var sut = string.Empty;

                var result = sut.CountOccurences("something");

                Assert.That(result, Is.EqualTo(0));
            }

            [Test]
            public void WhenValueIsNull_ThenThrowException()
            {
                const string sut = "something";

                Assert.Throws<ArgumentException>(() => sut.CountOccurences(null));
            }

            [Test]
            public void WhenValueIsEmpty_ThenThrowException()
            {
                const string sut = "something";

                Assert.Throws<ArgumentException>(() => sut.CountOccurences(string.Empty));
            }

            [Test]
            public void WhenValueDoesNotAppear_ThenReturnZero()
            {
                const string sut = "something";

                var result = sut.CountOccurences("else");

                Assert.That(result, Is.EqualTo(0));
            }

            [Test]
            public void WhenValueAppearsOnce_ThenReturnOne()
            {
                const string sut = " something ";

                var result = sut.CountOccurences("something");

                Assert.That(result, Is.EqualTo(1));
            }
        }

        [TestFixture]
        public class Obscure
        {
            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                string sut = null;

                Assert.Throws<ArgumentNullException>(() => sut.Obscure(1, 1));
            }

            [Test]
            public void WhenSourceIsEmpty_ThenReturnEmpty()
            {
                var sut = string.Empty;

                var result = sut.Obscure(1, 1);

                Assert.That(result, Is.EqualTo(string.Empty));
            }
            
            [TestCase(0, "*****")]
            [TestCase(1, "1****")]
            [TestCase(2, "12***")]
            [TestCase(3, "123**")]
            [TestCase(4, "1234*")]
            [TestCase(5, "12345")]
            [TestCase(6, "12345")]
            public void WhenShowBeginCharsOnly_ThenShowBeginChars(int numBeginCharsToShow, string expected)
            {
                const string sut = "12345";

                var result = sut.Obscure(numBeginCharsToShow, 0);

                Assert.That(result, Is.EqualTo(expected));
            }

            [TestCase(0, "*****")]
            [TestCase(1, "****5")]
            [TestCase(2, "***45")]
            [TestCase(3, "**345")]
            [TestCase(4, "*2345")]
            [TestCase(5, "12345")]
            [TestCase(6, "12345")]
            public void WhenShowEndCharsOnly_ThenShowEndChars(int numEndCharsToShow, string expected)
            {
                const string sut = "12345";

                var result = sut.Obscure(0, numEndCharsToShow);

                Assert.That(result, Is.EqualTo(expected));
            }

            [TestCase(0, 0, "*****")]
            [TestCase(1, 1, "1***5")]
            [TestCase(2, 2, "12*45")]
            [TestCase(3, 2, "12345")]
            [TestCase(3, 3, "12345")]
            [TestCase(4, 4, "12345")]
            [TestCase(5, 5, "12345")]
            [TestCase(6, 6, "12345")]
            public void WhenShowBeginAndEndChars_ThenShowBeginAndEndChars(int numBeginCharsToShow, int numEndCharsToShow, string expected)
            {
                const string sut = "12345";

                var result = sut.Obscure(numBeginCharsToShow, numEndCharsToShow);

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class Repeat
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                const string sut = null;

                Assert.Throws<ArgumentNullException>(() => sut.Repeat(2));
            }

            [Test]
            public void WhenIsEmpty_ThenReturnEmpty()
            {
                var sut = string.Empty;

                var result = sut.Repeat(2);

                Assert.That(result, Is.EqualTo(string.Empty));
            }

            [Test]
            public void WhenRepeatOnce_ThenReturnEqualString()
            {
                const string sut = "something";

                var result = sut.Repeat(1);

                Assert.That(result, Is.EqualTo(sut));
            }

            [Test]
            public void WhenRepeatTwice_ThenReturnRepeatedString()
            {
                const string sut = "something";

                var result = sut.Repeat(2);

                Assert.That(result, Is.EqualTo(sut + sut));
            }
        }

        [TestFixture]
        public class LeftWithInnerEllipsis
        {
            private string _sut;

            [SetUp]
            public void SetUp()
            {
                _sut = "This string has too many characters for its own good";
            }

            [Test]
            public void WhenIsNull_ThenReturnNull()
            {
                var result = StringExtensions.LeftWithInnerEllipsis(null, 10);

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenLengthIsLessThanMaxLength_ThenReturnString()
            {
                var result = _sut.LeftWithInnerEllipsis(_sut.Length + 1);

                Assert.That(result, Is.EqualTo(_sut));
            }

            [Test]
            public void WhenLengthIsEqualToMaxLength_ThenReturnString()
            {
                var result = _sut.LeftWithInnerEllipsis(_sut.Length);

                Assert.That(result, Is.EqualTo(_sut));
            }

            [Test]
            public void WhenLengthIsMoreThanMaxLength_ThenTruncateString()
            {
                var result = _sut.LeftWithInnerEllipsis(_sut.Length - 1);

                Assert.That(result, Is.EqualTo("This string has too many...racters for its own good"));
            }
        }

        [TestFixture]
        public class ReplaceLastOccurrence
        {
            [Test]
            public void WhenIsNull_ThenReturnNull()
            {
                var result = StringExtensions.ReplaceLastOccurrence(null, "John", "Peter");

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenIsEmpty_ThenReturnEmpty()
            {
                var sut = string.Empty;

                var result = sut.ReplaceLastOccurrence("John", "Peter");

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenFindStringDoesNotExist_ThenReturnOriginalString()
            {
                const string sut = "John Smith";

                var result = sut.ReplaceLastOccurrence("Luke", "Peter");

                Assert.That(result, Is.EqualTo(sut));
            }

            [Test]
            public void WhenFindStringExists_ThenReplaceLastOccurance()
            {
                const string sut = "John Smith and John Jones";

                var result = sut.ReplaceLastOccurrence("John", "Peter");

                Assert.That(result, Is.EqualTo("John Smith and Peter Jones"));
            }
        }

        [TestFixture]
        public class SafeSubstring
        {
            [Test]
            public void WhenIsNull_ThenReturnEmpty()
            {
                var result = StringExtensions.SafeSubstring(null, 0, 5);

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

        [TestFixture]
        public class Left
        {
            private const string ClassUnderTest = "John Smith";

            [Test]
            public void WhenLengthIsZero_ThenReturnEmpty()
            {
                var result = ClassUnderTest.Left(0);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenLengthIsWithinSource_ThenReturnRequiredChars()
            {
                var result = ClassUnderTest.Left(4);

                Assert.That(result, Is.EqualTo("John"));
            }

            [Test]
            public void WhenLengthIsSameAsSourceLength_ThenReturnSource()
            {
                var result = ClassUnderTest.Left(ClassUnderTest.Length);

                Assert.That(result, Is.EqualTo(result));
            }

            [Test]
            public void WhenLengthIsLongerThanSourceLength_ThenReturnSource()
            {
                var result = ClassUnderTest.Left(ClassUnderTest.Length + 1);

                Assert.That(result, Is.EqualTo(result));
            } 
        }

        [TestFixture]
        public class Right
        {
            private const string ClassUnderTest = "John Smith";

            [Test]
            public void WhenLengthIsZero_ThenReturnEmpty()
            {
                var result = ClassUnderTest.Right(0);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenLengthIsWithinSource_ThenReturnRequiredChars()
            {
                var result = ClassUnderTest.Right(5);

                Assert.That(result, Is.EqualTo("Smith"));
            }

            [Test]
            public void WhenLengthIsSameAsSourceLength_ThenReturnSource()
            {
                var result = ClassUnderTest.Right(ClassUnderTest.Length);

                Assert.That(result, Is.EqualTo(result));
            }

            [Test]
            public void WhenLengthIsLongerThanSourceLength_ThenReturnSource()
            {
                var result = ClassUnderTest.Right(ClassUnderTest.Length + 1);

                Assert.That(result, Is.EqualTo(result));
            }
        }

        [TestFixture]
        public class Reverse
        {
            [Test]
            public void WhenIsNull_ThenReturnNull()
            {
                var result = (null as string).Reverse();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenIsEmpty_ThenReturnEmpty()
            {
                var result = string.Empty.Reverse();

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenSingleChar_ThenReturnSingleChar()
            {
                var result = "a".Reverse();

                Assert.That(result, Is.EqualTo("a"));
            }

            [Test]
            public void WhenTwoChars_ThenReverseChars()
            {
                var result = "ab".Reverse();

                Assert.That(result, Is.EqualTo("ba"));
            }

            [Test]
            public void WhenThreeChars_ThenReverseChars()
            {
                var result = "abc".Reverse();

                Assert.That(result, Is.EqualTo("cba"));
            }
        }

        [TestFixture]
        public class AddSlashSuffix
        {
            [TestCase(null, "/")]
            [TestCase("", "/")]
            [TestCase("path", "path/")]
            [TestCase("path/", "path/")]
            [TestCase("/path/", "/path/")]
            public void WhenProvided_ThenReturnExpected(string sut, string expected)
            {
                var result = sut.AddSlashSuffix();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class RemoveSlashPrefix
        {
            [TestCase(null, null)]
            [TestCase("", "")]
            [TestCase("path", "path")]
            [TestCase("/path", "path")]
            [TestCase("/path/", "path/")]
            public void WhenProvided_ThenReturnExpected(string sut, string expected)
            {
                var result = sut.RemoveSlashPrefix();

                Assert.That(result, Is.EqualTo(expected));
            }
        }
    }
}
