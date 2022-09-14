using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteDev.Collections;
using NUnit.Framework;

namespace ByteDev.Strings.UnitTests
{
    [TestFixture]
    public class StringBuilderExtensionsTests
    {
        [TestFixture]
        public class IsEmpty
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => StringBuilderExtensions.IsEmpty(null));
            }

            [Test]
            public void WhenIsEmpty_ThenReturnTrue()
            {
                var sut = new StringBuilder();

                var result = sut.IsEmpty();

                Assert.That(result, Is.True);
            }

            [Test]
            public void WhenHasText_ThenReturnFalse()
            {
                var sut = new StringBuilder();

                sut.Append("Test");

                var result = sut.IsEmpty();

                Assert.That(result, Is.False);
            }
        }

        [TestFixture]
        public class AppendValues_Params
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => StringBuilderExtensions.AppendValues(null));
            }

            [Test]
            public void WhenTwoValues_ThenAppend()
            {
                var sut = new StringBuilder();

                sut.AppendValues("This is ", "a test");

                var result = sut.ToString();

                Assert.That(result, Is.EqualTo("This is a test"));
            }

            [Test]
            public void WhenContainsNullValue_ThenAppend()
            {
                var sut = new StringBuilder();

                sut.AppendValues("This is ", null, "a test");

                var result = sut.ToString();

                Assert.That(result, Is.EqualTo("This is a test"));
            }
        }

        [TestFixture]
        public class AppendValues_Enumerable
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => StringBuilderExtensions.AppendValues(null, Enumerable.Empty<string>()));
            }

            [Test]
            public void WhenEnumerableIsNull_ThenDoNothing()
            {
                var sut = new StringBuilder();

                sut.AppendValues(null as IEnumerable<string>);

                Assert.That(sut.ToString(), Is.Empty);
            }

            [Test]
            public void WhenTwoValues_ThenAppend()
            {
                var sut = new StringBuilder();

                var list = new List<string> { "This is ", "a test" };

                sut.AppendValues(list);

                var result = sut.ToString();

                Assert.That(result, Is.EqualTo("This is a test"));
            }

            [Test]
            public void WhenContainsNullValue_ThenAppend()
            {
                var sut = new StringBuilder();

                var list = new List<string> { "This is ", null, "a test" };

                sut.AppendValues(list);

                var result = sut.ToString();

                Assert.That(result, Is.EqualTo("This is a test"));
            }
        }

        [TestFixture]
        public class AppendLines_Params
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => StringBuilderExtensions.AppendLines(null));
            }

            [Test]
            public void WhenTwoValues_ThenAppend()
            {
                var sut = new StringBuilder();

                sut.AppendLines("This is ", "a test");

                var result = sut.ToString().ToLines().ToList();
                
                Assert.That(result.First(), Is.EqualTo("This is "));
                Assert.That(result.Second(), Is.EqualTo("a test"));
            }

            [Test]
            public void WhenContainsNullValue_ThenAppend()
            {
                var sut = new StringBuilder();

                sut.AppendLines("This is ", null, "a test");

                var result = sut.ToString().ToLines().ToList();
                
                Assert.That(result.First(), Is.EqualTo("This is "));
                Assert.That(result.Second(), Is.Empty);
                Assert.That(result.Third(), Is.EqualTo("a test"));
            }
        }

        [TestFixture]
        public class AppendLines_Enumerable
        {
            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => StringBuilderExtensions.AppendLines(null, Enumerable.Empty<string>()));
            }

            [Test]
            public void WhenEnumerableIsNull_ThenDoNothing()
            {
                var sut = new StringBuilder();

                sut.AppendLines(null as IEnumerable<string>);

                Assert.That(sut.ToString(), Is.Empty);
            }

            [Test]
            public void WhenTwoValues_ThenAppend()
            {
                var sut = new StringBuilder();

                var list = new List<string> { "This is ", "a test" };

                sut.AppendLines(list);

                var result = sut.ToString().ToLines().ToList();
                
                Assert.That(result.First(), Is.EqualTo("This is "));
                Assert.That(result.Second(), Is.EqualTo("a test"));
            }

            [Test]
            public void WhenContainsNullValue_ThenAppend()
            {
                var sut = new StringBuilder();

                var list = new List<string> { "This is ", null, "a test" };

                sut.AppendLines(list);

                var result = sut.ToString().ToLines().ToList();
                
                Assert.That(result.First(), Is.EqualTo("This is "));
                Assert.That(result.Second(), Is.Empty);
                Assert.That(result.Third(), Is.EqualTo("a test"));
            }
        }

        [TestFixture]
        public class AppendIfEmpty
        {
            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => StringBuilderExtensions.AppendIfEmpty(null, "value"));
            }

            [Test]
            public void WhenValueIsNull_ThenDoNothing()
            {
                var sut = new StringBuilder();

                sut.AppendIfEmpty(null);

                Assert.That(sut.ToString(), Is.Empty);
            }

            [Test]
            public void WhenEmpty_ThenAppend()
            {
                var sut = new StringBuilder();

                sut.AppendIfEmpty("value");

                Assert.That(sut.ToString(), Is.EqualTo("value"));
            }

            [Test]
            public void WhenNotEmpty_ThenDoNothing()
            {
                var sut = new StringBuilder("something");

                sut.AppendIfEmpty("value");

                Assert.That(sut.ToString(), Is.EqualTo("something"));
            }
        }

        [TestFixture]
        public class AppendIfNotEmpty
        {
            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => StringBuilderExtensions.AppendIfNotEmpty(null, "value"));
            }

            [Test]
            public void WhenValueIsNull_ThenDoNothing()
            {
                var sut = new StringBuilder("something");

                sut.AppendIfNotEmpty(null);

                Assert.That(sut.ToString(), Is.EqualTo("something"));
            }

            [Test]
            public void WhenEmpty_ThenDoNothing()
            {
                var sut = new StringBuilder();

                sut.AppendIfNotEmpty("value");

                Assert.That(sut.ToString(), Is.Empty);
            }

            [Test]
            public void WhenNotEmpty_ThenAppend()
            {
                var sut = new StringBuilder("something");

                sut.AppendIfNotEmpty("value");

                Assert.That(sut.ToString(), Is.EqualTo("somethingvalue"));
            }
        }

        [TestFixture]
        public class AppendLineIfEmpty
        {
            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => StringBuilderExtensions.AppendLineIfEmpty(null, "value"));
            }

            [Test]
            public void WhenValueIsNull_ThenAppendNewLine()
            {
                var sut = new StringBuilder();

                sut.AppendLineIfEmpty(null);

                Assert.That(sut.ToString(), Is.EqualTo(Environment.NewLine));
            }

            [Test]
            public void WhenEmpty_ThenAppend()
            {
                var sut = new StringBuilder();

                sut.AppendLineIfEmpty("value");

                Assert.That(sut.ToString(), Is.EqualTo("value" + Environment.NewLine));
            }

            [Test]
            public void WhenNotEmpty_ThenDoNothing()
            {
                var sut = new StringBuilder("something");

                sut.AppendLineIfEmpty("value");

                Assert.That(sut.ToString(), Is.EqualTo("something"));
            }
        }

        [TestFixture]
        public class AppendLineIfNotEmpty
        {
            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => StringBuilderExtensions.AppendLineIfNotEmpty(null, "value"));
            }

            [Test]
            public void WhenValueIsNull_ThenAppendNewLine()
            {
                var sut = new StringBuilder("something");

                sut.AppendLineIfNotEmpty(null);

                Assert.That(sut.ToString(), Is.EqualTo("something" + Environment.NewLine));
            }

            [Test]
            public void WhenEmpty_ThenDoNothing()
            {
                var sut = new StringBuilder();

                sut.AppendLineIfNotEmpty("value");

                Assert.That(sut.ToString(), Is.Empty);
            }

            [Test]
            public void WhenNotEmpty_ThenAppend()
            {
                var sut = new StringBuilder("something");

                sut.AppendLineIfNotEmpty("value");

                Assert.That(sut.ToString(), Is.EqualTo("somethingvalue" + Environment.NewLine));
            }
        }
    }
}