using System.Collections.Generic;
using NUnit.Framework;

namespace ByteDev.Strings.UnitTests
{
    [TestFixture]
    public class ToStringBuilderTests
    {
        private ToStringBuilder _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new ToStringBuilder();
        }

        [Test]
        public void WhenWithPairs_ThenReturnString()
        {
            var result = _sut
                .WithNullValue("null")
                .With("Name", "John")
                .With("Age", 50)
                .With("Dummy", new Dummy())
                .With("Surname", null)
                .Build();

            Assert.That(result, Is.EqualTo("Name: John, Age: 50, Dummy: A Dummy, Surname: null"));
        }

        [Test]
        public void WhenWithEmptyCollection_ThenReturnString()
        {
            var result = _sut
                .With("MyList", new List<string>())
                .Build();

            Assert.That(result, Is.EqualTo("MyList: { }"));
        }

        [Test]
        public void WhenWithObjectCollection_ThenReturnString()
        {
            var list = new object[] { "Something1", 50, new Dummy()  };

            var result = _sut
                .With("Name", "John")
                .With("MyList", list)
                .Build();

            Assert.That(result, Is.EqualTo("Name: John, MyList: { Something1, 50, A Dummy }"));
        }

        [Test]
        public void WhenWithDummyCollection_ThenReturnString()
        {
            var list = new List<Dummy> {new Dummy(), new Dummy()};

            var result = _sut
                .With("Dummies", list)
                .Build();

            Assert.That(result, Is.EqualTo("Dummies: { A Dummy, A Dummy }"));
        }

        [Test]
        public void WhenWithStringQuoteChar_ThenReturnString()
        {
            var list = new[] { "Something1", "Something2"  };

            var result = _sut
                .WithStringQuoteChar('\'')
                .With("Name", "John")
                .With("MyList", list)
                .Build();

            Assert.That(result, Is.EqualTo("Name: 'John', MyList: { 'Something1', 'Something2' }"));
        }
        
        internal class Dummy
        {
            public override string ToString()
            {
                return "A Dummy";
            }
        }
    }
}