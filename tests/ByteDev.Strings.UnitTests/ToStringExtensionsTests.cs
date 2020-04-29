using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ByteDev.Strings.UnitTests
{
    [TestFixture]
    public class ToStringHelperTests
    {
        [TestFixture]
        public class ToStringObject : ToStringHelperTests
        {
            [Test]
            public void WhenNameIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => new ToStringHelper().ToString(null, 1));
            }

            [Test]
            public void WhenNameIsEmpty_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => new ToStringHelper().ToString(string.Empty, 1));
            }

            [Test]
            public void WhenValueIsNull_ThenReturnString()
            {
                var result = new ToStringHelper().ToString("Id", null);

                Assert.That(result, Is.EqualTo("Id: "));
            }

            [Test]
            public void WhenValueIsNull_AndNullValueGiven_ThenReturnString()
            {
                var result = new ToStringHelper("<null>").ToString("Id", null);

                Assert.That(result, Is.EqualTo("Id: <null>"));
            }

            [Test]
            public void WhenValueIsNotNull_ThenReturnString()
            {
                var result = new ToStringHelper().ToString("Id", 10);

                Assert.That(result, Is.EqualTo("Id: 10"));
            }
        }

        [TestFixture]
        public class ToStringEnumerable : ToStringHelperTests
        {
            [Test]
            public void WhenEnumerableIsNull_ThenReturnString()
            {
                var result = Act(null);

                Assert.That(result, Is.EqualTo("Ids: "));
            }

            [Test]
            public void WhenEnumerableIsEmpty_ThenReturnString()
            {
                var result = Act(Enumerable.Empty<int>());

                Assert.That(result, Is.EqualTo("Ids: { }"));
            }

            [Test]
            public void WhenEnumerableHasOneItem_ThenReturnString()
            {
                var result = Act(new[] { 3 });

                Assert.That(result, Is.EqualTo("Ids: { 3 }"));
            }

            [Test]
            public void WhenEnumerableHasTwoItems_ThenReturnString()
            {
                var result = Act(new[] { 3, 15 });

                Assert.That(result, Is.EqualTo("Ids: { 3, 15 }"));
            }

            private static string Act(IEnumerable<int> values)
            {
                return new ToStringHelper().ToString("Ids", values);
            }
        }
    }
}