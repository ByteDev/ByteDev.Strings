using NUnit.Framework;

namespace ByteDev.Strings.UnitTests
{
    [TestFixture]
    public class StringReplaceExtensionsTests
    {
        [TestFixture]
        public class ReplaceToken : StringExtensionsTests
        {
            [Test]
            public void WhenSourceIsNull_ThenReturnNull()
            {
                var result = StringReplaceExtensions.ReplaceToken(null, "customerId", 123);

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenSourceIsEmpty_ThenReturnEmpty()
            {
                var result = string.Empty.ReplaceToken("customerId", 123);

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
        public class ReplaceFirst
        {
            [Test]
            public void WhenIsNull_ThenReturnNull()
            {
                var result = StringReplaceExtensions.ReplaceFirst(null, "John", "Peter");

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenIsEmpty_ThenReturnEmpty()
            {
                var result = string.Empty.ReplaceFirst("John", "Peter");

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenOldValueDoesNotExist_ThenReturnSameString()
            {
                const string sut = "John Smith";

                var result = sut.ReplaceFirst("Luke", "Peter");

                Assert.That(result, Is.EqualTo(sut));
            }

            [Test]
            public void WhenOldValueDoesExists_ThenReplaceLastOccurance()
            {
                const string sut = "John Smith and John Jones";

                var result = sut.ReplaceFirst("John", "Peter");

                Assert.That(result, Is.EqualTo("Peter Smith and John Jones"));
            }
        }

        [TestFixture]
        public class ReplaceLast
        {
            [Test]
            public void WhenIsNull_ThenReturnNull()
            {
                var result = StringReplaceExtensions.ReplaceLast(null, "John", "Peter");

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenIsEmpty_ThenReturnEmpty()
            {
                var result = string.Empty.ReplaceLast("John", "Peter");

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenOldValueDoesNotExist_ThenReturnSameString()
            {
                const string sut = "John Smith";

                var result = sut.ReplaceLast("Luke", "Peter");

                Assert.That(result, Is.EqualTo(sut));
            }

            [Test]
            public void WhenOldValueDoesExists_ThenReplaceLastOccurance()
            {
                const string sut = "John Smith and John Jones";

                var result = sut.ReplaceLast("John", "Peter");

                Assert.That(result, Is.EqualTo("John Smith and Peter Jones"));
            }
        }
    }
}