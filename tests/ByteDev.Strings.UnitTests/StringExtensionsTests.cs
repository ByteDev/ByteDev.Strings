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
                Assert.Throws<ArgumentNullException>(() => sut.FormatWith(string.Empty));
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
        public class CountOccurrences
        {
            [Test]
            public void WhenSourceIsNull_ThenReturnZero()
            {
                var result = StringExtensions.CountOccurrences(null, "something");

                Assert.That(result, Is.EqualTo(0));
            }

            [Test]
            public void WhenSourceIsEmpty_ThenReturnZero()
            {
                var sut = string.Empty;

                var result = sut.CountOccurrences("something");

                Assert.That(result, Is.EqualTo(0));
            }

            [Test]
            public void WhenValueIsNull_ThenThrowException()
            {
                const string sut = "something";

                Assert.Throws<ArgumentException>(() => sut.CountOccurrences(null));
            }

            [Test]
            public void WhenValueIsEmpty_ThenThrowException()
            {
                const string sut = "something";

                Assert.Throws<ArgumentException>(() => sut.CountOccurrences(string.Empty));
            }

            [Test]
            public void WhenValueDoesNotAppear_ThenReturnZero()
            {
                const string sut = "something";

                var result = sut.CountOccurrences("else");

                Assert.That(result, Is.EqualTo(0));
            }

            [Test]
            public void WhenValueAppearsOnce_ThenReturnOne()
            {
                const string sut = " something ";

                var result = sut.CountOccurrences("something");

                Assert.That(result, Is.EqualTo(1));
            }

            [Test]
            public void WhenValueAppearsTwice_ThenReturnTwo()
            {
                const string sut = " something somewhere something else";

                var result = sut.CountOccurrences("something");

                Assert.That(result, Is.EqualTo(2));
            }

            [Test]
            public void WhenChar_AndNull_ThenReturnZero()
            {
                var result = StringExtensions.CountOccurrences(null, '-');

                Assert.That(result, Is.EqualTo(0));
            }

            [Test]
            public void WhenChar_AndEmpty_ThenReturnZero()
            {
                var result = string.Empty.CountOccurrences('-');

                Assert.That(result, Is.EqualTo(0));
            }

            [Test]
            public void WhenChar_AndPresentOnce_ThenReturnOne()
            {
                var result = "something-else".CountOccurrences('-');

                Assert.That(result, Is.EqualTo(1));
            }

            [Test]
            public void WhenChar_AndPresentTwice_ThenReturnTwo()
            {
                var result = "something-else-".CountOccurrences('-');

                Assert.That(result, Is.EqualTo(2));
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

            [Test]
            public void WhenUnicodeChars_ThenReverseChars()
            {
                var result = "火山".Reverse();

                Assert.That(result, Is.EqualTo("山火"));
            }
        }

        [TestFixture]
        public class Wrap
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenIsNullOrEmpty_ThenReturnString(string sut)
            {
                var result = sut.Wrap("'");

                Assert.That(result, Is.EqualTo("''"));
            }

            [TestCase(null)]
            [TestCase("")]
            public void WhenWrapperIsNullOrEmpty_ThenReturnString(string wrapper)
            {
                var result = "a".Wrap(wrapper);

                Assert.That(result, Is.EqualTo("a"));
            }

            [Test]
            public void WhenSourceAndWrapperHasChars_ThenReturnString()
            {
                var result = "a".Wrap("**");

                Assert.That(result, Is.EqualTo("**a**"));
            }

            [Test]
            public void WhenWrapperIsChar_ThenReturnString()
            {
                var result = "a".Wrap('*');

                Assert.That(result, Is.EqualTo("*a*"));
            }
        }

        [TestFixture]
        public class InsertBeforeUpperCase
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenDelimiterIsNullOrEmpty_ThenReturnSource(string delimiter)
            {
                const string sut = "NotFound";

                var result = sut.InsertBeforeUpperCase(delimiter);

                Assert.That(result, Is.EqualTo(sut));
            }

            [TestCase(null)]
            [TestCase("")]
            [TestCase("a")]
            [TestCase("a1")]
            [TestCase("a1 b2")]
            public void WhenHasNoUpperCase_ThenReturnSource(string sut)
            {
                var result = sut.InsertBeforeUpperCase(" ");

                Assert.That(result, Is.EqualTo(sut));
            }

            [TestCase("A", "A")]
            [TestCase("AB", "A B")]
            [TestCase("ABaC", "A Ba C")]
            [TestCase("Not", "Not")]
            [TestCase("NotFound", "Not Found")]
            [TestCase("NotFoundHere", "Not Found Here")]
            [TestCase(" NotFound ", " Not Found ")]
            [TestCase("aNotFound ", "aNot Found ")]
            public void WhenHasUpperCase_ThenReturnString(string sut, string expected)
            {
                var result = sut.InsertBeforeUpperCase(" ");

                Assert.That(result, Is.EqualTo(expected));
            }
        }
    }
}
