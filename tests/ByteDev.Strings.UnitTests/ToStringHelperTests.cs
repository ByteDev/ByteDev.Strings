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
            public void WhenValueIsInt_ThenReturnString()
            {
                var result = new ToStringHelper().ToString("Id", 10);

                Assert.That(result, Is.EqualTo("Id: 10"));
            }

            [Test]
            public void WhenValueIsString_ThenReturnString()
            {
                var result = new ToStringHelper().ToString("Id", "John Smith");

                Assert.That(result, Is.EqualTo("Id: John Smith"));
            }
        }

        [TestFixture]
        public class ToStringEnumerable : ToStringHelperTests
        {
            [Test]
            public void WhenEnumerableIsNull_ThenReturnString()
            {
                var result = new ToStringHelper().ToString("Ids", null);

                Assert.That(result, Is.EqualTo("Ids: "));
            }

            [Test]
            public void WhenEnumerableIsNull_AndNullValueGiven_ThenReturnString()
            {
                var result = new ToStringHelper("<null>").ToString("Ids", null);

                Assert.That(result, Is.EqualTo("Ids: <null>"));
            }

            [Test]
            public void WhenEnumerableIsEmpty_ThenReturnString()
            {
                var result = new ToStringHelper().ToString("Ids", Enumerable.Empty<int>());

                Assert.That(result, Is.EqualTo("Ids: { }"));
            }

            [Test]
            public void WhenEnumerableHasOneItem_ThenReturnString()
            {
                var result = new ToStringHelper().ToString("Ids", new[] { 3 });

                Assert.That(result, Is.EqualTo("Ids: { 3 }"));
            }

            [Test]
            public void WhenEnumerableHasTwoItems_ThenReturnString()
            {
                var result = new ToStringHelper().ToString("Ids", new[] { 3, 15 });

                Assert.That(result, Is.EqualTo("Ids: { 3, 15 }"));
            }
        }

        [Test]
        public void WhenUsedFromType_ThenReturnString()
        {
            var result = new MyClass().ToString();

            Assert.That(result, Is.EqualTo("Name: John, Age: <null>, Address: { 123 Highstreet, London, UK }"));
        }
    }

    public class MyClass
    {
        public string Name => "John";

        public string Age => null;

        public IEnumerable<string> Address => new List<string>
        {
            "123 Highstreet",
            "London",
            "UK"
        };

        public override string ToString()
        {
            var helper = new ToStringHelper("<null>");

            return helper.ToString(nameof(Name), Name) + ", " +
                   helper.ToString(nameof(Age), Age) + ", " +
                   helper.ToString(nameof(Address), Address);
        }
    }
}