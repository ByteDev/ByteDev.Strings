using ByteDev.Strings.Masking;
using NUnit.Framework;

namespace ByteDev.Strings.UnitTests.Masking
{
    [TestFixture]
    public class MaskerTests
    {
        private Masker _sut;

        public MaskerOptions Options { get; set; }

        [SetUp]
        public void SetUp()
        {
            Options = new MaskerOptions
            {
                MaskChar = '#',
                MaskSpace = true
            };

            _sut = new Masker(Options);
        }
        
        [TestFixture]
        public class PaymentCard : MaskerTests
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenValueNullOrEmpty_ThenReturnSame(string value)
            {
                var result = _sut.PaymentCard(value);

                Assert.That(result, Is.EqualTo(value));
            }

            [TestCase("4111111111111111", "############1111")]
            [TestCase("4111111111111111\n", "############1111")]
            [TestCase("4111 1111 1111 1111", "###############1111")]
            public void WhenMaskSpace_ThenReturnMasked(string value, string expected)
            {
                var result = _sut.PaymentCard(value);

                Assert.That(result, Is.EqualTo(expected));
            }

            [TestCase("4111111111111111", "############1111")]
            [TestCase("4111111111111111\n", "############1111")]
            [TestCase("\t4111111111111111", "############1111")]
            [TestCase("4111 1111 1111 1111", "#### #### #### 1111")]
            public void WhenNotMaskSpace_ThenReturnMasked(string value, string expected)
            {
                Options.MaskSpace = false;

                var result = _sut.PaymentCard(value);

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class EmailAddress : MaskerTests
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenValueNullOrEmpty_ThenReturnSame(string value)
            {
                var result = _sut.EmailAddress(value);

                Assert.That(result, Is.EqualTo(value));
            }

            [TestCase("j@localhost", "j@#########")]
            [TestCase("john@gmail.com", "j###@#####.com")]
            [TestCase("john.smith@gmail.co.uk", "j#########@#####.co.uk")]
            public void WhenCalled_ThenReturnMasked(string value, string expected)
            {
                var result = _sut.EmailAddress(value);

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class Custom : MaskerTests
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenValueNullOrEmpty_ThenReturnSame(string value)
            {
                var result = _sut.Custom(value, 0, 0);

                Assert.That(result, Is.EqualTo(value));
            }
            
            [TestCase(-1, "#####")]
            [TestCase(0, "#####")]
            [TestCase(1, "1####")]
            [TestCase(2, "12###")]
            [TestCase(3, "123##")]
            [TestCase(4, "1234#")]
            [TestCase(5, "12345")]
            [TestCase(6, "12345")]
            public void WhenShowBeginCharsOnly_ThenShowBeginChars(int numBeginCharsToShow, string expected)
            {
                var result = _sut.Custom("12345", numBeginCharsToShow, 0);

                Assert.That(result, Is.EqualTo(expected));
            }

            [TestCase(-1, "#####")]
            [TestCase(0, "#####")]
            [TestCase(1, "####5")]
            [TestCase(2, "###45")]
            [TestCase(3, "##345")]
            [TestCase(4, "#2345")]
            [TestCase(5, "12345")]
            [TestCase(6, "12345")]
            public void WhenShowEndCharsOnly_ThenShowEndChars(int numEndCharsToShow, string expected)
            {
                var result = _sut.Custom("12345", 0, numEndCharsToShow);

                Assert.That(result, Is.EqualTo(expected));
            }

            [TestCase(-1, -1, "#####")]
            [TestCase(0, 0, "#####")]
            [TestCase(1, 1, "1###5")]
            [TestCase(2, 2, "12#45")]
            [TestCase(3, 2, "12345")]
            [TestCase(3, 3, "12345")]
            [TestCase(4, 4, "12345")]
            [TestCase(5, 5, "12345")]
            [TestCase(6, 6, "12345")]
            public void WhenShowBeginAndEndChars_ThenShowBeginAndEndChars(int numBeginCharsToShow, int numEndCharsToShow, string expected)
            {
                var result = _sut.Custom("12345", numBeginCharsToShow, numEndCharsToShow);

                Assert.That(result, Is.EqualTo(expected));
            }

            [TestCase(1, 1, "1# #5")]
            public void WhenNotMaskSpace_ThenReturnMasked(int numBeginCharsToShow, int numEndCharsToShow, string expected)
            {
                Options.MaskSpace = false;

                var result = _sut.Custom("12 45", numBeginCharsToShow, numBeginCharsToShow);

                Assert.That(result, Is.EqualTo(expected));
            }
        }
    }
}