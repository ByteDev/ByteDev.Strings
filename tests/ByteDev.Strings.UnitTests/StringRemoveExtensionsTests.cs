﻿using System;
using NUnit.Framework;

namespace ByteDev.Strings.UnitTests
{
    [TestFixture]
    public class StringRemoveExtensionsTests
    {
        [TestFixture]
        public class RemoveStartsWith : StringExtensionsTests
        {
            private const string Sut = "My name is John";

            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => StringRemoveExtensions.RemoveStartsWith(null, "M"));
            }

            [Test]
            public void WhenValueIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => Sut.RemoveStartsWith(null));
            }

            [Test]
            public void WhenValueIsEmpty_ThenReturnSource()
            {
                var result = Sut.RemoveStartsWith(string.Empty);

                Assert.That(result, Is.EqualTo(Sut));
            }

            [Test]
            public void WhenDoesNotStartWithValue_ThenReturnSource()
            {
                var result = Sut.RemoveStartsWith("name");

                Assert.That(result, Is.EqualTo(Sut));
            }

            [Test]
            public void WhenValueIsLongerThanSource_ThenReturnSource()
            {
                var result = Sut.RemoveStartsWith(Sut + " Smith");

                Assert.That(result, Is.EqualTo(Sut));
            }

            [Test]
            public void WhenStartsWithValue_ThenRemoveStartingValue()
            {
                var result = Sut.RemoveStartsWith("My");

                Assert.That(result, Is.EqualTo(" name is John"));
            }
        }

        [TestFixture]
        public class RemoveEndsWith : StringExtensionsTests
        {
            private const string Sut = "My name is John";

            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => StringRemoveExtensions.RemoveEndsWith(null, "M"));
            }

            [Test]
            public void WhenValueIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => Sut.RemoveEndsWith(null));
            }

            [Test]
            public void WhenValueIsEmpty_ThenReturnSource()
            {
                var result = Sut.RemoveEndsWith(string.Empty);

                Assert.That(result, Is.EqualTo(Sut));
            }

            [Test]
            public void WhenDoesNotEndWithValue_ThenReturnSource()
            {
                var result = Sut.RemoveEndsWith("name");

                Assert.That(result, Is.EqualTo(Sut));
            }

            [Test]
            public void WhenValueIsLongerThanSource_ThenReturnSource()
            {
                var result = Sut.RemoveEndsWith(Sut + " Smith");

                Assert.That(result, Is.EqualTo(Sut));
            }

            [Test]
            public void WhenEndsWithValue_ThenRemoveEndingValue()
            {
                var result = Sut.RemoveEndsWith("John");

                Assert.That(result, Is.EqualTo("My name is "));
            }
        }

        [TestFixture]
        public class RemoveWhiteSpace
        {
            [Test]
            public void WhenIsNull_ThenReturnNull()
            {
                var result = StringRemoveExtensions.RemoveWhiteSpace(null);

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenIsEmpty_ThenReturnEmpty()
            {
                string sut = string.Empty;

                var result = sut.RemoveWhiteSpace();

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenHasSpaces_ThenRemoveSpaces()
            {
                var result = " something    and  something else   ".RemoveWhiteSpace();

                Assert.That(result, Is.EqualTo("somethingandsomethingelse"));
            }

            [Test]
            public void WhenHasTabs_ThenRemoveTabs()
            {
                var result = "  something       and something   else    ".RemoveWhiteSpace();

                Assert.That(result, Is.EqualTo("somethingandsomethingelse"));
            }
        }

        [TestFixture]
        public class RemoveBracketedText
        {
            [Test]
            public void WhenOneSetOfBrackets_ThenRemoveBracketText()
            {
                var result = "Something in (brackets)".RemoveBracketedText();

                Assert.That(result, Is.EqualTo("Something in "));
            }

            [Test]
            public void WhenMultipleSetsOfBrackets_ThenRemoveBracketText()
            {
                var result = "Something in (brackets) and (more)".RemoveBracketedText();

                Assert.That(result, Is.EqualTo("Something in  and "));
            }

            [Test]
            public void WhenNoClosingBracket_ThenRemoveBracketText()
            {
                var result = "Something in (brackets".RemoveBracketedText();

                Assert.That(result, Is.EqualTo("Something in "));
            }

            [Test]
            public void WhenBracketDoesntExist_ThenNotRemoveAnything()
            {
                var result = "Something in brackets".RemoveBracketedText();

                Assert.That(result, Is.EqualTo("Something in brackets"));
            }

            [Test]
            public void WhenBracketsAreFirstChar_ThenRemoveBracketText()
            {
                var result = "(Something) in (brackets) again".RemoveBracketedText();

                Assert.That(result, Is.EqualTo(" in  again"));
            }

            [Test]
            public void WhenTextIsAllInBrackets_ThenRemoveBracketText()
            {
                var result = "(Something in brackets)".RemoveBracketedText();

                Assert.That(result, Is.EqualTo(string.Empty));
            }

            [Test]
            public void WhenIsEmpty_ThenReturnEmpty()
            {
                var result = string.Empty.RemoveBracketedText();

                Assert.That(result, Is.EqualTo(string.Empty));
            }

            [Test]
            public void WhenIsNull_ThenReturnNull()
            {
                var result = StringRemoveExtensions.RemoveBracketedText(null);

                Assert.That(result, Is.Null);
            }
        }
    }
}