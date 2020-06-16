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
        public class ToTitleCase
        {
            [Test]
            public void WhenStringIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => StringToExtensions.ToTitleCase(null));
            }

            [Test]
            public void WhenIsEmpty_ThenReturnEmpty()
            {
                var result = string.Empty.ToTitleCase();

                Assert.That(result, Is.Empty);
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
            [Test]
            public void WhenStringHasOneLine_ThenReturnOneElement()
            {
                const string sut = "Hello World";

                var result = sut.ToLines();

                Assert.That(result.Single(), Is.EqualTo(sut));
            }

            [Test]
            public void WhenStringHasThreeLines_ThenReturnThreeElements()
            {
                const string sut = "Hello World\r\nmy name\r\nis John";

                var result = sut.ToLines().ToList();

                Assert.That(result.Count, Is.EqualTo(3));
                Assert.That(result.First(), Is.EqualTo("Hello World"));
                Assert.That(result.Second(), Is.EqualTo("my name"));
                Assert.That(result.Third(), Is.EqualTo("is John"));
            }

            [Test]
            public void WhenIsEmpty_ThenReturnEmptyCollection()
            {
                var sut = string.Empty;

                var result = sut.ToLines();

                Assert.That(result.Count(), Is.EqualTo(0));
            }

            [Test]
            public void WhenIsNull_ThenReturnEmptyCollection()
            {
                var result = StringToExtensions.ToLines(null);

                Assert.That(result.Count(), Is.EqualTo(0));
            }
        }

        [TestFixture]
        public class ToByteArray
        {
            private static byte ConvertToByte(char c)
            {
                return BitConverter.GetBytes(c).First();
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

            [Test]
            public void WhenNull_ThenReturnEmptyArray()
            {
                var result = StringToExtensions.ToByteArray(null);

                Assert.That(result.Length, Is.EqualTo(0));
            }

            [Test]
            public void WhenEmpty_ThenReturnEmptyArray()
            {
                var sut = string.Empty;

                var result = sut.ToByteArray();

                Assert.That(result.Length, Is.EqualTo(0));
            }
        }

        [TestFixture]
        public class ToIntOrDefault
        {
            [Test]
            public void WhenValidString_ThenReturnAsInt()
            {
                const string sut = "123";

                var result = sut.ToIntOrDefault(1);

                Assert.That(result, Is.EqualTo(123));
            }

            [Test]
            public void WhenInvalidString_ThenReturnDefault()
            {
                const string sut = "A123";

                var result = sut.ToIntOrDefault(1);

                Assert.That(result, Is.EqualTo(1));
            }

            [Test]
            public void WhenNull_ThenReturnDefault()
            {
                var result = StringToExtensions.ToIntOrDefault(null, 1);

                Assert.That(result, Is.EqualTo(1));
            }
        }

        [TestFixture]
        public class ToLongOrDefault
        {
            [Test]
            public void WhenNull_ThenReturnDefault()
            {
                var result = StringToExtensions.ToLongOrDefault(null, 1);

                Assert.That(result, Is.EqualTo(1));
            }

            [Test]
            public void WhenValidString_ThenReturnAsLong()
            {
                const string sut = "123";

                var result = sut.ToLongOrDefault(1);

                Assert.That(result, Is.EqualTo(123));
            }

            [Test]
            public void WhenInvalidString_ThenReturnDefault()
            {
                const string sut = "A123";

                var result = sut.ToLongOrDefault(1);

                Assert.That(result, Is.EqualTo(1));
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
        public class ToEnum
        {
            private enum TestEnum
            {
                Test1
            }

            public struct NotEnum
            {
            }

            [Test]
            public void WhenTypeIsNotEnum_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => "Test1".ToEnum<NotEnum>());
            }

            [Test]
            public void WhenIsNotEnumValue_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => "Test2".ToEnum<TestEnum>());
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

            [Test]
            public void WhenRegardCase_AndIsEnumValueButDiffCase_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => "test1".ToEnum<TestEnum>());
            }
        }
    }
}