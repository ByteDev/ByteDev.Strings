using System;
using NUnit.Framework;

namespace ByteDev.Strings.UnitTests
{
    [TestFixture]
    public class StringExtensionsTests
    {
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
        public class Mask
        {
            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                string sut = null;

                Assert.Throws<ArgumentNullException>(() => sut.Mask(1, 1));
            }

            [Test]
            public void WhenSourceIsEmpty_ThenReturnEmpty()
            {
                var sut = string.Empty;

                var result = sut.Mask(1, 1);

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

                var result = sut.Mask(numBeginCharsToShow, 0);

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

                var result = sut.Mask(0, numEndCharsToShow);

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

                var result = sut.Mask(numBeginCharsToShow, numEndCharsToShow);

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
        public class AddSuffix
        {
            [Test]
            public void WhenIsNull_ThenReturnSuffix()
            {
                var result = StringExtensions.AddSuffix(null, "thing");

                Assert.That(result, Is.EqualTo("thing"));
            }

            [Test]
            public void WhenIsEmpty_ThenReturnSuffix()
            {
                var result = string.Empty.AddSuffix("thing");

                Assert.That(result, Is.EqualTo("thing"));
            }

            [Test]
            public void WhenSuffixExists_ThenReturnUnchanged()
            {
                const string sut = "Something";

                var result = sut.AddSuffix("thing");

                Assert.That(result, Is.EqualTo(sut));
            }

            [Test]
            public void WhenSuffixDoesNotExists_ThenReturnWithSuffix()
            {
                const string sut = "Some";

                var result = sut.AddSuffix("thing");

                Assert.That(result, Is.EqualTo(sut + "thing"));
            }
        }

        [TestFixture]
        public class AddPrefix
        {
            [Test]
            public void WhenIsNull_ThenReturnPrefix()
            {
                var result = StringExtensions.AddPrefix(null, "thing");

                Assert.That(result, Is.EqualTo("thing"));
            }

            [Test]
            public void WhenIsEmpty_ThenReturnPrefix()
            {
                var result = string.Empty.AddPrefix("thing");

                Assert.That(result, Is.EqualTo("thing"));
            }

            [Test]
            public void WhenPrefixExists_ThenReturnUnchanged()
            {
                const string sut = "Something";

                var result = sut.AddPrefix("Some");

                Assert.That(result, Is.EqualTo(sut));
            }

            [Test]
            public void WhenPrefixDoesNotExists_ThenReturnWithSuffix()
            {
                const string sut = "thing";

                var result = sut.AddPrefix("Some");

                Assert.That(result, Is.EqualTo("Some" + sut));
            }
        }

        [TestFixture]
        public class ContainsIgnoreCase
        {
            [Test]
            public void WhenSourceIsNull_ThenReturnsFalse()
            {
                var result = StringExtensions.ContainsIgnoreCase(null, "A");

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
    }
}
