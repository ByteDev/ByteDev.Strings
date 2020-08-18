using NUnit.Framework;

namespace ByteDev.Strings.UnitTests
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
    }
}