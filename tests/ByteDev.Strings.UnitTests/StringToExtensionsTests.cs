using System;
using System.Linq;
using ByteDev.Collections;
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
            public void WhenHasOneLine_ThenReturnOneElement()
            {
                const string sut = "Hello World";

                var result = sut.ToLines();

                Assert.That(result.Single(), Is.EqualTo(sut));
            }

            [Test]
            public void WhenHasThreeLines_ThenReturnThreeElements()
            {
                const string sut = "Hello World\r\n" + 
                                   "my name\r\n" +
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
                                   "\r\n" +
                                   " \r\n" +
                                   "  \r\n" +
                                   "    \r\n" +
                                   "is John";

                var result = sut.ToLines(true).ToList();

                Assert.That(result.Count, Is.EqualTo(2));
                Assert.That(result.First(), Is.EqualTo("Hello World"));
                Assert.That(result.Second(), Is.EqualTo("is John"));
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
        public class ToInt
        {
            [TestCase(null)]
            [TestCase("")]
            [TestCase("A")]
            public void WhenIsNotInt_ThenReturnZero(string sut)
            {
                var result = sut.ToInt();

                Assert.That(result, Is.EqualTo(0));
            }

            [TestCase("-1", -1)]
            [TestCase("0", 0)]
            [TestCase("1", 1)]
            public void WhenIsInt_ThenReturnInt(string sut, int expected)
            {
                var result = sut.ToInt();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class ToIntOrDefault
        {
            [Test]
            public void WhenIsNull_ThenReturnDefault()
            {
                var result = StringToExtensions.ToIntOrDefault(null, 1);

                Assert.That(result, Is.EqualTo(1));
            }

            [Test]
            public void WhenIsInvalid_ThenReturnDefault()
            {
                var result = "A123".ToIntOrDefault(1);

                Assert.That(result, Is.EqualTo(1));
            }

            [Test]
            public void WhenIsValid_ThenReturnAsInt()
            {
                var result = "123".ToIntOrDefault();

                Assert.That(result, Is.EqualTo(123));
            }
        }

        [TestFixture]
        public class ToLong
        {
            [TestCase(null)]
            [TestCase("")]
            [TestCase("A")]
            public void WhenIsNotLong_ThenReturnZero(string sut)
            {
                var result = sut.ToLong();

                Assert.That(result, Is.EqualTo(0));
            }

            [TestCase("-1", -1)]
            [TestCase("0", 0)]
            [TestCase("1", 1)]
            public void WhenIsLong_ThenReturnLong(string sut, int expected)
            {
                var result = sut.ToLong();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class ToLongOrDefault
        {
            [Test]
            public void WhenIsNull_ThenReturnDefault()
            {
                var result = StringToExtensions.ToLongOrDefault(null, 1);

                Assert.That(result, Is.EqualTo(1));
            }

            [Test]
            public void WhenIsInvalid_ThenReturnDefault()
            {
                var result = "A123".ToLongOrDefault(1);

                Assert.That(result, Is.EqualTo(1));
            }

            [Test]
            public void WhenIsValid_ThenReturnAsLong()
            {
                var result = "123".ToLongOrDefault();

                Assert.That(result, Is.EqualTo(123));
            }
        }

        [TestFixture]
        public class ToDateTime
        {
            [TestCase(null)]
            [TestCase("")]
            [TestCase("A")]
            public void WhenIsNotDateTime_ThenReturnMin(string sut)
            {
                var result = sut.ToDateTime();

                Assert.That(result, Is.EqualTo(DateTime.MinValue));
            }

            [Test]
            public void WhenIsDateTimeFormat_ThenReturnDateTime()
            {
                var expected = new DateTime(2000, 12, 12, 12, 0, 0);

                var result = "12/12/2000 12:00".ToDateTime();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class ToDateTimeOrDefault
        {
            [Test]
            public void WhenHasValidFormat_ThenReturnValueAsDateTime()
            {
                const string sut = "09/12/2000 12:00";

                var defaultDateTime = DateTime.Now;
                var expected = new DateTime(2000, 12, 9, 12, 0, 0);

                var result = sut.ToDateTimeOrDefault(defaultDateTime);

                Assert.That(result.Value.Year, Is.EqualTo(expected.Year));
            }

            [Test]
            public void WhenHasInvalidFormat_ThenReturnDefaultValue()
            {
                const string sut = "13/13/2000 12:00";

                var defaultDateTime = DateTime.Now;

                var result = sut.ToDateTimeOrDefault(defaultDateTime);

                Assert.That(result, Is.EqualTo(defaultDateTime));
            }
        }

        [TestFixture]
        public class ToCsv
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenIsNullOrEmpty_ThenReturnEmpty(string sut)
            {
                var result = sut.ToCsv();

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenDelimiterIsNotPresent_ThenReturnSingle()
            {
                var result = "John Smith".ToCsv();

                Assert.That(result.Single(), Is.EqualTo("John Smith"));
            }

            [Test]
            public void WhenDelimiterPresent_ThenReturnMultiple()
            {
                var result = "John:Smith".ToCsv(':');

                Assert.That(result.Count(), Is.EqualTo(2));
                Assert.That(result.First(), Is.EqualTo("John"));
                Assert.That(result.Second(), Is.EqualTo("Smith"));
            }

            [Test]
            public void WhenTrimValues_ThenReturnTrimedValues()
            {
                var result = "John : Smith:Peter: ".ToCsv(':', true);

                Assert.That(result.Count(), Is.EqualTo(3));
                Assert.That(result.First(), Is.EqualTo("John"));
                Assert.That(result.Second(), Is.EqualTo("Smith"));
                Assert.That(result.Third(), Is.EqualTo("Peter"));
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
    }
}