using System;
using NUnit.Framework;

namespace ByteDev.Strings.UnitTests
{
    [TestFixture]
    public class StringIsExtensionsTests
    {
        [TestFixture]
        public class IsEmpty
        {
            [Test]
            public void WhenEmpty_ThenReturnTrue()
            {
                var sut = string.Empty;

                Assert.That(sut.IsEmpty(), Is.True);
            }

            [Test]
            public void WhenNotEmpty_ThenReturnFalse()
            {
                const string sut = "something";

                Assert.That(sut.IsEmpty(), Is.False);
            }

            [Test]
            public void WhenIsNull_ThenReturnFalse()
            {
                Assert.That((null as string).IsEmpty(), Is.False);
            }
        }

        [TestFixture]
        public class IsNullOrEmpty
        {
            [Test]
            public void WhenNull_ThenReturnTrue()
            {
                Assert.That((null as string).IsNullOrEmpty(), Is.True);
            }

            [Test]
            public void WhenEmpty_ThenReturnTrue()
            {
                Assert.That(string.Empty.IsNullOrEmpty(), Is.True);
            }

            [Test]
            public void WhenIsNotNullOrEmpty_ThenReturnTrue()
            {
                const string sut = "a";

                Assert.That(sut.IsNullOrEmpty(), Is.False);
            }
        }

        [TestFixture]
        public class IsNullOrWhitespace
        {
            [TestCase(null, true)]
            [TestCase("", true)]
            [TestCase(" ", true)]
            [TestCase(" ", true)]
            [TestCase(" a", false)]
            public void WhenProvided_ThenReturnExpected(string sut, bool expected)
            {
                var result = sut.IsNullOrWhitespace();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class IsEmailAddress
        {
            [TestCase(null)]
            [TestCase("")]
            [TestCase("a")]
            [TestCase("aa")]
            [TestCase("a@a b")]
            [TestCase(" ab@aa")]
            [TestCase("john.com")]
            [TestCase("@somewhere.com")]
            public void WhenIsNotEmailAddress_ThenReturnFalse(string sut)
            {
                var result = sut.IsEmailAddress();

                Assert.That(result, Is.False);
            }

            [TestCase("a@a")]
            [TestCase("a1@a1")]
            [TestCase("a.b.c@a.com")]
            [TestCase("john@google.com")]
            public void WhenIsEmailAddress_ThenReturnTrue(string sut)
            {
                var result = sut.IsEmailAddress();

                Assert.That(result, Is.True);
            }
        }

        [TestFixture]
        public class IsIpAddress
        {
            [TestCase(null)]
            [TestCase("")]
            [TestCase("192")]
            [TestCase("192.168")]
            [TestCase("192.168.1")]
            [TestCase("192.168.1.XXX")]
            [TestCase("192.168.1.256")]
            public void WhenIsNotIpAddress_ThenReturnFalse(string sut)
            {
                var result = sut.IsIpAddress();

                Assert.That(result, Is.False);
            }

            [TestCase("0.0.0.0")]
            [TestCase("127.0.0.1")]
            [TestCase("192.168.1.254")]
            [TestCase("255.255.255.255")]
            public void WhenIsIpAddress_ThenReturnTrue(string sut)
            {
                var result = sut.IsIpAddress();

                Assert.That(result, Is.True);
            }
        }

        [TestFixture]
        public class IsGuid
        {
            [TestCase(null)]
            [TestCase("")]
            [TestCase("123456567-ABCDEFGH")]
            [TestCase("A5EF801D-13BC-4C6F-94AA-C7152C8BC15G")]
            public void WhenIsNotGuid_ThenReturnFalse(string sut)
            {
                var result = sut.IsGuid();

                Assert.That(result, Is.False);
            }

            [TestCase("A5EF801D-13BC-4C6F-94AA-C7152C8BC158")]
            [TestCase("a5ef801d-13bc-4c6f-94aa-c7152c8bc158")]
            [TestCase("{a5ef801d-13bc-4c6f-94aa-c7152c8bc158}")]
            [TestCase("a5ef801d13bc4c6f94aac7152c8bc158")]
            [TestCase("00000000-0000-0000-0000-000000000000")]
            public void WhenIsGuid_ThenReturnTrue(string sut)
            {
                var result = sut.IsGuid();

                Assert.That(result, Is.True);
            }
        }

        [TestFixture]
        public class IsXml
        {
            [Test]
            public void WhenIsNull_ThenReturnFalse()
            {
                var result = (null as string).IsXml();

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenIsEmpty_ThenReturnFalse()
            {
                var result = string.Empty.IsXml();

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenIsValidXml_AndNoDeclaration_ThenReturnTrue()
            {
                const string sut = "<item><name>wrench</name></item>";

                var result = sut.IsXml();

                Assert.That(result, Is.True);
            }

            [Test]
            public void WhenIsValidXml_AndDeclaration_ThenReturnTrue()
            {
                string sut = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>" + Environment.NewLine +
                                        "<items />";

                var result = sut.IsXml();

                Assert.That(result, Is.True);
            }

            [Test]
            public void WhenIsInvalidXml_AndNoRootElement_ThenReturnFalse()
            {
                const string sut = "<item><name>wrench</name></item><item></item>";

                var result = sut.IsXml();

                Assert.That(result, Is.False);
            }
        }

        [TestFixture]
        public class IsHttpUrl
        {
            [TestCase("http://localhost")]
            [TestCase("http://localhost/")]
            [TestCase("http://local-host")]
            [TestCase("http://localhost:80")]
            [TestCase("http://www.google.co.uk")]
            [TestCase("http://www.google.com")]
            [TestCase("http://www.google.com/")]
            [TestCase("http://www.google.com/?q=1")]
            [TestCase("http://www.google.com/path")]
            [TestCase("http://www.google.com/path/")]
            [TestCase("http://www.google.com/path/file")]
            [TestCase("http://www.google.com/path/#fragment")]
            [TestCase("https://www.google.com/path/search?q=value")]
            [TestCase("https://www.google.com/path/search?q=value&value2")]
            [TestCase("https://www.google.com/path/search?q=value#fragment")]
            [TestCase("https://www.google.co.uk")]
            public void WhenIsUrl_ThenReturnTrue(string sut)
            {
                var result = sut.IsHttpUrl();

                Assert.That(result, Is.True);
            }

            [TestCase(null)]
            [TestCase("")]
            [TestCase("google.co.uk")]
            [TestCase("www.google.co.uk")]
            [TestCase("Http://www.google.com")]
            [TestCase(" http://www.google.com")]
            [TestCase("http://www.google.com ")]
            [TestCase("http://www.google.com/app?q=John Smith")]
            public void WhenIsNotUrl_ThenReturnFalse(string sut)
            {
                var result = sut.IsHttpUrl();

                Assert.That(result, Is.False);                
            }
        }

        [TestFixture]
        public class IsDigits
        {
            [TestCase("0")]
            [TestCase("0123456789")]            
            public void WhenIsDigits_ThenReturnTrue(string sut)
            {
                var result = sut.IsDigits();

                Assert.That(result, Is.True);
            }

            [TestCase(null)]
            [TestCase("")]
            [TestCase("A0")]
            public void WhenIsNotDigits_ThenReturnFalse(string sut)
            {
                var result = sut.IsDigits();

                Assert.That(result, Is.False);
            }
        }

        [TestFixture]
        public class IsDigit
        {
            [TestCase("0")]
            [TestCase("1")]            
            [TestCase("2")]            
            [TestCase("3")]            
            [TestCase("4")]            
            [TestCase("5")]            
            [TestCase("6")]            
            [TestCase("7")]            
            [TestCase("8")]            
            [TestCase("9")]            
            public void WhenIsDigits_ThenReturnTrue(string sut)
            {
                var result = sut.IsDigit();

                Assert.That(result, Is.True);
            }

            [TestCase(null)]
            [TestCase("")]
            [TestCase(" ")]
            [TestCase("00")]
            [TestCase("A")]
            public void WhenIsNotDigits_ThenReturnFalse(string sut)
            {
                var result = sut.IsDigit();

                Assert.That(result, Is.False);
            }
        }

        [TestFixture]
        public class IsNumeric
        {
            [TestCase(null)]
            [TestCase("")]
            [TestCase(" ")]
            [TestCase(".")]
            [TestCase(".1")]
            [TestCase("A.1")]
            [TestCase("A1")]
            [TestCase("1A")]
            [TestCase("1.0.1")]
            [TestCase("1..")]
            [TestCase("1-0")]
            public void WhenIsNotNumeric_ThenReturnFalse(string sut)
            {
                var result = sut.IsNumeric();

                Assert.That(result, Is.False);
            }

            [TestCase("0")]
            [TestCase("10")]
            [TestCase("01")]
            [TestCase("1.")]
            [TestCase("1.0")]
            [TestCase("1.01")]
            [TestCase("10.01")]
            [TestCase("00.00")]
            [TestCase("-1")]
            [TestCase("-1.0")]
            [TestCase("-1.01")]
            public void WhenIsNumeric_ThenReturnTrue(string sut)
            {
                var result = sut.IsNumeric();

                Assert.That(result, Is.True);                
            }
        }

        [TestFixture]
        public class IsLetters
        {
            [TestCase("A")]
            [TestCase("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz")]            
            public void WhenIsLettersOnly_ThenReturnTrue(string sut)
            {
                var result = sut.IsLetters();

                Assert.That(result, Is.True);
            }

            [TestCase(null)]
            [TestCase("")]
            [TestCase("A0")]
            public void WhenIsNotAllLetters_ThenReturnFalse(string sut)
            {
                var result = sut.IsLetters();

                Assert.That(result, Is.False);
            }
        }

        [TestFixture]
        public class IsTrue
        {
            [TestCase(null)]
            [TestCase("")]
            [TestCase("t")]
            [TestCase("false")]
            [TestCase("0")]
            public void WhenIsNotTrue_ThenReturnFalse(string sut)
            {
                var result = sut.IsTrue();

                Assert.That(result, Is.False);
            }

            [TestCase("true")]
            [TestCase("True")]
            [TestCase("TRUE")]
            [TestCase("on")]
            [TestCase("On")]
            [TestCase("ON")]
            [TestCase("1")]
            public void WhenIsTrue_ThenReturnTrue(string sut)
            {
                var result = sut.IsTrue();

                Assert.That(result, Is.True);
            }
        }

        [TestFixture]
        public class IsFalse
        {
            [TestCase(null)]
            [TestCase("")]
            [TestCase("f")]
            [TestCase("true")]
            [TestCase("1")]
            public void WhenIsNotFalse_ThenReturnFalse(string sut)
            {
                var result = sut.IsFalse();

                Assert.That(result, Is.False);
            }

            [TestCase("false")]
            [TestCase("False")]
            [TestCase("FALSE")]
            [TestCase("off")]
            [TestCase("Off")]
            [TestCase("OFF")]
            [TestCase("0")]
            public void WhenIsFalse_ThenReturnTrue(string sut)
            {
                var result = sut.IsFalse();

                Assert.That(result, Is.True);
            }
        }

        [TestFixture]
        public class IsLengthBetween
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => StringIsExtensions.IsLengthBetween(null, 0, 1));
            }

            [Test]
            public void WhenMinGreaterThanMax_ThenThrowException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => "something".IsLengthBetween(1, 0));
            }

            [TestCase("a", -1, -1)]
            [TestCase("a", 0, 0)]
            [TestCase("aa", 0, 1)]
            [TestCase("aa", 1, 1)]
            public void WhenLengthIsNotBetweenMinAndMax_ThenReturnFalse(string sut, int min, int max)
            {
                var result = sut.IsLengthBetween(min, max);

                Assert.That(result, Is.False);
            }

            [TestCase("", -1, -1)]
            [TestCase("", 0, 0)]
            [TestCase("a", 1, 1)]
            [TestCase("a", 0, 1)]
            [TestCase("aa", 0, 2)]
            [TestCase("aa", 2, 2)]
            public void WhenLengthIsBetweenMinAndMax_ThenReturnTrue(string sut, int min, int max)
            {
                var result = sut.IsLengthBetween(min, max);

                Assert.That(result, Is.True);
            }
        }

        [TestFixture]
        public class IsLowerCase
        {
            [TestCase(null)]
            [TestCase("")]
            [TestCase("A")]
            [TestCase("a1")]
            [TestCase("a b")]
            public void WhenIsNotLowerCase_ThenReturnFalse(string sut)
            {
                var result = sut.IsLowerCase();

                Assert.That(result, Is.False);
            }

            [TestCase("a")]
            [TestCase("ab")]
            public void WhenIsLowerCase_ThenReturnTrue(string sut)
            {
                var result = sut.IsLowerCase();

                Assert.That(result, Is.True);
            }
        }

        [TestFixture]
        public class IsUpperCase
        {
            [TestCase(null)]
            [TestCase("")]
            [TestCase("a")]
            [TestCase("A1")]
            [TestCase("A B")]
            public void WhenIsNotUpperCase_ThenReturnFalse(string sut)
            {
                var result = sut.IsUpperCase();

                Assert.That(result, Is.False);
            }

            [TestCase("A")]
            [TestCase("AB")]
            public void WhenIsUpperCase_ThenReturnTrue(string sut)
            {
                var result = sut.IsUpperCase();

                Assert.That(result, Is.True);
            }
        }

        [TestFixture]
        public class IsTime
        {
            [TestCase(null)]
            [TestCase("")]
            [TestCase("0")]
            [TestCase("00")]
            [TestCase("23,59,59")]
            [TestCase("24:59:59")]
            [TestCase("23:60:59")]
            [TestCase("23:59:60")]
            public void WhenIsNotTime_ThenReturnFalse(string sut)
            {
                var result = sut.IsTime();

                Assert.That(result, Is.False);
            }

            [TestCase("00:00:00")]
            [TestCase("00-00-00")]
            [TestCase("000000")]
            [TestCase("23:59:59")]
            [TestCase("23-59-59")]
            [TestCase("235959")]
            [TestCase("00:00")]
            [TestCase("00-00")]
            [TestCase("0000")]
            [TestCase("23:59")]
            [TestCase("23-59")]
            [TestCase("2359")]
            public void WhenIsTime_ThenReturnTrue(string sut)
            {
                var result = sut.IsTime();

                Assert.That(result, Is.True);
            }
        }

        [TestFixture]
        public class IsPhoneNumber
        {
            [TestCase("12")]
            [TestCase("12345")]
            [TestCase("12 345")]
            [TestCase("+12345")]
            [TestCase("+12 345")]
            [TestCase("+12-345")]
            [TestCase("+1 2-345")]
            [TestCase("+12")]
            [TestCase("0012")]
            public void WhenIsPhoneNumber_ThenReturnTrue(string sut)
            {
                var result = sut.IsPhoneNumber();

                Assert.That(result, Is.True);
            }

            [TestCase(null)]
            [TestCase("")]
            [TestCase(" ")]
            [TestCase("1")]
            [TestCase(" 1")]
            [TestCase("+1")]
            [TestCase("++1")]
            [TestCase(" +1")]
            public void WhenIsNotPhoneNumber_ThenReturnFalse(string sut)
            {
                var result = sut.IsPhoneNumber();

                Assert.That(result, Is.False);
            }
        }
    }
}