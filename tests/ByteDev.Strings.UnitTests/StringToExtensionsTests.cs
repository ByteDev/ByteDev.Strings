using System;
using System.Linq;
using System.Text;
using ByteDev.Collections;
using ByteDev.Io;
using NUnit.Framework;

namespace ByteDev.Strings.UnitTests
{
    [TestFixture]
    public class StringToExtensionsTests
    {
        [TestFixture]
        public class ToEnum
        {
            private enum TestEnum
            {
                Test1
            }

            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => StringToExtensions.ToEnum<TestEnum>(null));
            }

            [Test]
            public void WhenIsNotEnumValue_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => "Test2".ToEnum<TestEnum>());
            }

            [Test]
            public void WhenRegardCase_AndIsEnumValueButDiffCase_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => "test1".ToEnum<TestEnum>());
            }

            [Test]
            public void WhenIsEnumValue_ThenReturnEnum()
            {
                var result = "Test1".ToEnum<TestEnum>();

                Assert.That(result, Is.EqualTo(TestEnum.Test1));
            }

            [Test]
            public void WhenIgnoreCase_AndIsEnumValueButDiffCase_ThenReturnEnum()
            {
                var result = "test1".ToEnum<TestEnum>(true);

                Assert.That(result, Is.EqualTo(TestEnum.Test1));
            }
        }

        [TestFixture]
        public class ToTitleCase
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenIsNullOrEmpty_ThenReturnSame(string sut)
            {
                var result = sut.ToTitleCase();

                Assert.That(result, Is.EqualTo(sut));
            }

            [Test]
            public void WhenLowerCase_ThenChangeCase()
            {
                const string sut = "my name is john";

                var result = sut.ToTitleCase();

                Assert.That(result, Is.EqualTo("My Name Is John"));
            }

            [Test]
            public void WhenLowerCaseWithPeriod_ThenChangeCase()
            {
                const string sut = "my name is john.and i work";

                var result = sut.ToTitleCase();

                Assert.That(result, Is.EqualTo("My Name Is John.And I Work"));
            }

            [Test]
            public void WhenUpperCaseWithPeriod_ThenChangeCase()
            {
                const string sut = "MY NAME IS JOHN.AND I WORK";

                var result = sut.ToTitleCase();

                Assert.That(result, Is.EqualTo("My Name Is John.And I Work"));
            }
        }

        [TestFixture]
        public class ToLines
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenIsNullOrEmpty_ThenReturnEmpty(string sut)
            {
                var result = sut.ToLines();

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenHasOneLine_ThenReturnOneLine()
            {
                const string sut = "Hello World";

                var result = sut.ToLines();

                Assert.That(result.Single(), Is.EqualTo(sut));
            }

            [Test]
            public void WhenHasThreeLines_ThenReturnThreeLines()
            {
                const string sut = "Hello World" + NewLineStrings.Windows +
                                   "my name" + NewLineStrings.Windows +
                                   "is John";

                var result = sut.ToLines().ToList();

                Assert.That(result.Count, Is.EqualTo(3));
                Assert.That(result.First(), Is.EqualTo("Hello World"));
                Assert.That(result.Second(), Is.EqualTo("my name"));
                Assert.That(result.Third(), Is.EqualTo("is John"));
            }

            [Test]
            public void WhenIgnoreEmptyLines_ThenReturnNonEmptyLines()
            {
                const string sut = "Hello World\r\n" + 
                                   NewLineStrings.Windows +
                                   " " + NewLineStrings.Windows +
                                   "  " + NewLineStrings.Windows +
                                   "    " + NewLineStrings.Windows +
                                   "is John";

                var result = sut.ToLines(true).ToList();

                Assert.That(result.Count, Is.EqualTo(2));
                Assert.That(result.First(), Is.EqualTo("Hello World"));
                Assert.That(result.Second(), Is.EqualTo("is John"));
            }

            [Test]
            public void WhenNewLinesAreUnix_ThenReturnLines()
            {
                const string sut =
                    "Hello" + NewLineStrings.Unix +
                    "World" + NewLineStrings.Unix +
                    "Everyone";

                var result = sut.ToLines().ToList();

                Assert.That(result.Count, Is.EqualTo(3));
                Assert.That(result.First(), Is.EqualTo("Hello"));
                Assert.That(result.Second(), Is.EqualTo("World"));
                Assert.That(result.Third(), Is.EqualTo("Everyone"));
            }

            [Test]
            public void WhenNewLinesAreMix_ThenReturnLines()
            {
                const string sut =
                    "Hello" + NewLineStrings.Windows +
                    "World" + NewLineStrings.Unix +
                    "Everyone";

                var result = sut.ToLines().ToList();

                Assert.That(result.Count, Is.EqualTo(3));
                Assert.That(result.First(), Is.EqualTo("Hello"));
                Assert.That(result.Second(), Is.EqualTo("World"));
                Assert.That(result.Third(), Is.EqualTo("Everyone"));
            }
        }

        [TestFixture]
        public class ToLinesList
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenIsNullOrEmpty_ThenReturnEmpty(string sut)
            {
                var result = sut.ToLinesList();

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenHasOneLine_ThenReturnOneLine()
            {
                const string sut = "Hello World";

                var result = sut.ToLinesList();

                Assert.That(result.Single(), Is.EqualTo(sut));
            }

            [Test]
            public void WhenHasThreeLines_ThenReturnThreeLines()
            {
                const string sut = "Hello World" + NewLineStrings.Windows +
                                   "my name" + NewLineStrings.Windows +
                                   "is John";

                var result = sut.ToLinesList();

                Assert.That(result.Count, Is.EqualTo(3));
                Assert.That(result.First(), Is.EqualTo("Hello World"));
                Assert.That(result.Second(), Is.EqualTo("my name"));
                Assert.That(result.Third(), Is.EqualTo("is John"));
            }

            [Test]
            public void WhenIgnoreEmptyLines_ThenReturnNonEmptyLines()
            {
                const string sut = "Hello World\r\n" + 
                                   NewLineStrings.Windows +
                                   " " + NewLineStrings.Windows +
                                   "  " + NewLineStrings.Windows +
                                   "    " + NewLineStrings.Windows +
                                   "is John";

                var result = sut.ToLinesList(true).ToList();

                Assert.That(result.Count, Is.EqualTo(2));
                Assert.That(result.First(), Is.EqualTo("Hello World"));
                Assert.That(result.Second(), Is.EqualTo("is John"));
            }

            [Test]
            public void WhenNewLinesAreUnix_ThenReturnLines()
            {
                const string sut =
                    "Hello" + NewLineStrings.Unix +
                    "World" + NewLineStrings.Unix +
                    "Everyone";

                var result = sut.ToLinesList().ToList();

                Assert.That(result.Count, Is.EqualTo(3));
                Assert.That(result.First(), Is.EqualTo("Hello"));
                Assert.That(result.Second(), Is.EqualTo("World"));
                Assert.That(result.Third(), Is.EqualTo("Everyone"));
            }

            [Test]
            public void WhenNewLinesAreMix_ThenReturnLines()
            {
                const string sut =
                    "Hello" + NewLineStrings.Windows +
                    "World" + NewLineStrings.Unix +
                    "Everyone";

                var result = sut.ToLinesList().ToList();

                Assert.That(result.Count, Is.EqualTo(3));
                Assert.That(result.First(), Is.EqualTo("Hello"));
                Assert.That(result.Second(), Is.EqualTo("World"));
                Assert.That(result.Third(), Is.EqualTo("Everyone"));
            }
        }

        [TestFixture]
        public class ToByteArray
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenNull_ThenReturnEmptyArray(string sut)
            {
                var result = sut.ToByteArray();

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenFiveCharString_ThenReturnFiveElementArray()
            {
                const string sut = "hello";

                var result = sut.ToByteArray();

                Assert.That(result.Length, Is.EqualTo(5));
                Assert.That(result.First(), Is.EqualTo(ConvertToByte('h')));
                Assert.That(result.Second(), Is.EqualTo(ConvertToByte('e')));
                Assert.That(result.Third(), Is.EqualTo(ConvertToByte('l')));
                Assert.That(result.Fourth(), Is.EqualTo(ConvertToByte('l')));
                Assert.That(result.Fifth(), Is.EqualTo(ConvertToByte('o')));
            }

            private static byte ConvertToByte(char c)
            {
                return BitConverter.GetBytes(c).First();
            }
        }

        [TestFixture]
        public class ToBool
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenIsNullOrEmpty_ThenReturnFalse(string sut)
            {
                var result = sut.ToBool();

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenIsNotBool_ThenReturnFalse()
            {
                var result = "A".ToBool();

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenIsBool_ThenReturnValue()
            {
                var result = "true".ToBool();

                Assert.That(result, Is.True);
            }
        }

        [TestFixture]
        public class ToBoolOrDefault
        {
            [Test]
            public void WhenIsNull_ThenReturnDefault()
            {
                var result = StringToExtensions.ToBoolOrDefault(null, true);

                Assert.That(result, Is.True);
            }

            [Test]
            public void WhenInvalidString_ThenReturnDefault()
            {
                var result = "A".ToBoolOrDefault();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenValidString_ThenReturnAsLong()
            {
                var result = "true".ToBoolOrDefault();

                Assert.That(result, Is.True);
            }
        }

        [TestFixture]
        public class ToInt32
        {
            [TestCase(null)]
            [TestCase("")]
            [TestCase("A")]
            public void WhenIsNotInt_ThenReturnZero(string sut)
            {
                var result = sut.ToInt32();

                Assert.That(result, Is.EqualTo(0));
            }

            [TestCase("-1", -1)]
            [TestCase("0", 0)]
            [TestCase("1", 1)]
            public void WhenIsInt_ThenReturnInt(string sut, int expected)
            {
                var result = sut.ToInt32();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class ToInt32OrDefault
        {
            [Test]
            public void WhenIsNull_ThenReturnDefault()
            {
                var result = StringToExtensions.ToInt32OrDefault(null, 1);

                Assert.That(result, Is.EqualTo(1));
            }

            [Test]
            public void WhenIsInvalid_ThenReturnDefault()
            {
                var result = "A123".ToInt32OrDefault(1);

                Assert.That(result, Is.EqualTo(1));
            }

            [Test]
            public void WhenIsValid_ThenReturnAsInt()
            {
                var result = "123".ToInt32OrDefault();

                Assert.That(result, Is.EqualTo(123));
            }
        }

        [TestFixture]
        public class ToInt64
        {
            [TestCase(null)]
            [TestCase("")]
            [TestCase("A")]
            public void WhenIsNotLong_ThenReturnZero(string sut)
            {
                var result = sut.ToInt64();

                Assert.That(result, Is.EqualTo(0));
            }

            [TestCase("-1", -1)]
            [TestCase("0", 0)]
            [TestCase("1", 1)]
            public void WhenIsLong_ThenReturnLong(string sut, int expected)
            {
                var result = sut.ToInt64();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class ToInt64OrDefault
        {
            [Test]
            public void WhenIsNull_ThenReturnDefault()
            {
                var result = StringToExtensions.ToInt64OrDefault(null, 1);

                Assert.That(result, Is.EqualTo(1));
            }

            [Test]
            public void WhenIsInvalid_ThenReturnDefault()
            {
                var result = "A123".ToInt64OrDefault(1);

                Assert.That(result, Is.EqualTo(1));
            }

            [Test]
            public void WhenIsValid_ThenReturnAsLong()
            {
                var result = "123".ToInt64OrDefault();

                Assert.That(result, Is.EqualTo(123));
            }
        }

        [TestFixture]
        public class ToSequence_CharDelimiter
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenIsNullOrEmpty_ThenReturnEmpty(string sut)
            {
                var result = sut.ToSequence(',');

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenDelimiterIsNotPresent_ThenReturnSingle()
            {
                var result = "John Smith".ToSequence(',');

                Assert.That(result.Single(), Is.EqualTo("John Smith"));
            }

            [Test]
            public void WhenDelimiterPresent_ThenReturnMultiple()
            {
                var result = "John:Smith".ToSequence(':');

                Assert.That(result.Count(), Is.EqualTo(2));
                Assert.That(result.First(), Is.EqualTo("John"));
                Assert.That(result.Second(), Is.EqualTo("Smith"));
            }

            [Test]
            public void WhenTrimValues_ThenReturnTrimedValues()
            {
                var result = "John : Smith:Peter: ".ToSequence(':', true);

                Assert.That(result.Count(), Is.EqualTo(3));
                Assert.That(result.First(), Is.EqualTo("John"));
                Assert.That(result.Second(), Is.EqualTo("Smith"));
                Assert.That(result.Third(), Is.EqualTo("Peter"));
            }
        }

        [TestFixture]
        public class ToSequence_StringDelimiter
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenIsNullOrEmpty_ThenReturnEmpty(string sut)
            {
                var result = sut.ToSequence(",");

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenDelimiterIsNotPresent_ThenReturnSingle()
            {
                var result = "John Smith".ToSequence(",");

                Assert.That(result.Single(), Is.EqualTo("John Smith"));
            }

            [Test]
            public void WhenDelimiterPresent_ThenReturnMultiple()
            {
                var result = "John:Smith".ToSequence(":");

                Assert.That(result.Count(), Is.EqualTo(2));
                Assert.That(result.First(), Is.EqualTo("John"));
                Assert.That(result.Second(), Is.EqualTo("Smith"));
            }

            [Test]
            public void WhenTrimValues_ThenReturnTrimedValues()
            {
                var result = "John : Smith:Peter: ".ToSequence(":", true);

                Assert.That(result.Count(), Is.EqualTo(3));
                Assert.That(result.First(), Is.EqualTo("John"));
                Assert.That(result.Second(), Is.EqualTo("Smith"));
                Assert.That(result.Third(), Is.EqualTo("Peter"));
            }

            [Test]
            public void WhenMultipleDelimitersPresent_ThenReturnMultiple()
            {
                var result = "John :Smith,50 ".ToSequence(new[] { ":", "," }, true);

                Assert.That(result.Count(), Is.EqualTo(3));
                Assert.That(result.First(), Is.EqualTo("John"));
                Assert.That(result.Second(), Is.EqualTo("Smith"));
                Assert.That(result.Third(), Is.EqualTo("50"));
            }
        }

        [TestFixture]
        public class ToUri
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenIsNullOrEmpty_ThenReturnNull(string sut)
            {
                var result = sut.ToUri();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenIsNotValidUri_ThenReturnNull()
            {
                var result = "A".ToUri();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenIsUri_ThenReturnUri()
            {
                var result = "http://localhost/".ToUri();

                Assert.That(result, Is.EqualTo(new Uri("http://localhost/")));
            }
        }

        [TestFixture]
        public class ToGuid
        {
            [Test]
            public void WhenIsNull_ThenReturnDefault()
            {
                var result = StringToExtensions.ToGuid(null);

                Assert.That(result, Is.EqualTo(Guid.Empty));
            }

            [TestCase("")]
            [TestCase("123")]
            public void WhenIsNotGuid_ThenReturnDefault(string sut)
            {
                var result = sut.ToGuid();

                Assert.That(result, Is.EqualTo(Guid.Empty));
            }

            [Test]
            public void WhenIsGuid_ThenReturnGuid()
            {
                var result = "9f28c9c7-31f5-4575-b3fc-d5c4ffd1df30".ToGuid();

                Assert.That(result, Is.EqualTo(new Guid("9f28c9c7-31f5-4575-b3fc-d5c4ffd1df30")));
            }
        }

        [TestFixture]
        public class ToKeyValuePair : StringToExtensionsTests
        {
            [Test]
            public void WhenSourceIsNull_ThenReturnKeyValuePair()
            {
                var result = (null as string).ToKeyValuePair("=");

                Assert.That(result.Key, Is.Null);
                Assert.That(result.Value, Is.Null);
            }

            [Test]
            public void WhenSourceIsEmpty_ThenReturnEmptyKeyAndValue()
            {
                var result = string.Empty.ToKeyValuePair("=");

                Assert.That(result.Key, Is.Empty);
                Assert.That(result.Value, Is.Empty);
            }

            [TestCase(null)]
            [TestCase("")]
            public void WhenDelimiterIsNullOrEmpty_ThenReturnEmptyValue(string delimiter)
            {
                var result = "a".ToKeyValuePair(delimiter);

                Assert.That(result.Key, Is.EqualTo("a"));
                Assert.That(result.Value, Is.Empty);
            }

            [TestCase("a")]
            [TestCase("a1")]
            public void WhenDelimiterDoesNotExist_ThenValueIsEmpty(string sut)
            {
                var result = sut.ToKeyValuePair("=");

                Assert.That(result.Key, Is.EqualTo(sut));
                Assert.That(result.Value, Is.Empty);
            }

            [Test]
            public void WhenKeyIsEmpty_ThenKeyIsEmpty()
            {
                var result = "=1".ToKeyValuePair("=");

                Assert.That(result.Key, Is.Empty);
                Assert.That(result.Value, Is.EqualTo("1"));
            }

            [Test]
            public void WhenOnlyDelimiterExists_ThenReturnEmptyKeyAndValue()
            {
                var result = "=".ToKeyValuePair("=");

                Assert.That(result.Key, Is.Empty);
                Assert.That(result.Value, Is.Empty);
            }

            [TestCase("a=", "a", "")]
            [TestCase("a=1", "a", "1")]
            [TestCase("ab1=123", "ab1", "123")]
            public void WhenDelimiterExists_ThenReturnKeyValuePair(string sut, string key, string value)
            {
                var result = sut.ToKeyValuePair("=");

                Assert.That(result.Key, Is.EqualTo(key));
                Assert.That(result.Value, Is.EqualTo(value));
            }

            [TestCase("a==", "a", "=")]
            [TestCase("a==1", "a", "=1")]
            [TestCase("ab1==123", "ab1", "=123")]
            [TestCase("a=1=2=3", "a", "1=2=3")]
            public void WhenDelimiterExistsTwice_ThenReturnKeyValuePair(string sut, string key, string value)
            {
                var result = sut.ToKeyValuePair("=");

                Assert.That(result.Key, Is.EqualTo(key));
                Assert.That(result.Value, Is.EqualTo(value));
            }
        }

        [TestFixture]
        public class ToMemoryStream
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenIsNullOrEmpty_ThenReturnEmptyStream(string sut)
            {
                var result = sut.ToMemoryStream();

                Assert.That(result.Length, Is.EqualTo(0));
            }

            [Test]
            public void WhenNotEmpty_ThenReturnStream()
            {
                const string sut = "Some text";

                var result = sut.ToMemoryStream();

                Assert.That(result.ReadAsString(), Is.EqualTo(sut));
            }
        }
    }
}