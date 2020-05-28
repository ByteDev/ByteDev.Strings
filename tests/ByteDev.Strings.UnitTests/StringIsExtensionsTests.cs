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
        public class IsNotNullOrEmpty
        {
            [Test]
            public void WhenNull_ThenReturnFalse()
            {
                Assert.That((null as string).IsNotNullOrEmpty(), Is.False);
            }

            [Test]
            public void WhenEmpty_ThenReturnFalse()
            {
                Assert.That(string.Empty.IsNotNullOrEmpty(), Is.False);
            }

            [Test]
            public void WhenNotNullOrEmpty_ThenReturnTrue()
            {
                const string sut = "test";

                Assert.That(sut.IsNotNullOrEmpty(), Is.True);
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
            [TestCase("http://www.google.co.uk")]
            [TestCase("http://www.google.com")]
            [TestCase("http://www.google.com/")]
            [TestCase("http://www.google.com/path")]
            [TestCase("http://www.google.com/path/")]
            [TestCase("http://www.google.com/path/file")]
            [TestCase("http://www.google.com/path/#fragment")]
            [TestCase("https://www.google.com//path/search?q=value")]
            [TestCase("https://www.google.com//path/search?q=value#fragment")]
            public void WhenIsUrl_ThenReturnTrue(string sut)
            {
                var result = sut.IsHttpUrl();

                Assert.That(result, Is.True);
            }

            [TestCase(null)]
            [TestCase("")]
            [TestCase("google.co.uk")]
            [TestCase("www.google.co.uk")]
            public void WhenIsNotUrl_ThenReturnFalse(string sut)
            {
                var result = sut.IsHttpUrl();

                Assert.That(result, Is.False);                
            }
        }

        [TestFixture]
        public class IsHex
        {
            [TestCase("A")]
            [TestCase("1")]
            [TestCase("F0")]
            [TestCase("F9")]
            [TestCase("F9A1")]
            [TestCase("f9a1")]
            [TestCase("f9A1")]
            public void WhenIsHex_ThenReturnTrue(string sut)
            {
                var result = sut.IsHex();

                Assert.That(result, Is.True);
            }

            [TestCase(null)]
            [TestCase("")]
            [TestCase("A1G")]
            public void WhenIsNotHex_ThenReturnFalse(string sut)
            {
                var result = sut.IsHex();

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
            [TestCase("1.0.1")]
            public void WhenIsNotNumeric_ThenReturnFalse(string sut)
            {
                var result = sut.IsNumeric();

                Assert.That(result, Is.False);
            }

            [TestCase("0")]
            [TestCase("10")]
            [TestCase("01")]
            [TestCase("1.0")]
            [TestCase("1.01")]
            [TestCase("10.01")]
            [TestCase("00.00")]
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
    }
}