using System;
using ByteDev.Strings.Case;
using NUnit.Framework;

namespace ByteDev.Strings.UnitTests.Case
{
    [TestFixture]
    public class CaseConverterTests
    {
        [TestFixture]
        public class ToCamelCase : CaseConverterTests
        {
            [TestCase("snake_case")]
            [TestCase("kebab-case")]
            [TestCase("PascalCase")]
            [TestCase("SNAKE_UPPER_CASE")]
            public void WhenIsNotCaseSpecified_ThenThrowException(string value)
            {
                Assert.Throws<ArgumentException>(() => CaseConverter.ToCamelCase(value, CaseType.CamelCase));
            }

            [Test]
            public void WhenIsCamelCase_ThenReturnSameString()
            {
                var sut = "camelCase";

                var result = CaseConverter.ToCamelCase(sut, CaseType.CamelCase);

                Assert.That(result, Is.EqualTo(sut));
            }

            [TestCase(null, null)]
            [TestCase("", "")]
            [TestCase("snake", "snake")]
            [TestCase("snake_case", "snakeCase")]
            [TestCase("snake_case_again", "snakeCaseAgain")]
            public void WhenIsSnakeCase_ThenReturnString(string sut, string expected)
            {
                var result = CaseConverter.ToCamelCase(sut, CaseType.SnakeCase);

                Assert.That(result, Is.EqualTo(expected));
            }

            [TestCase(null, null)]
            [TestCase("", "")]
            [TestCase("kebab", "kebab")]
            [TestCase("kebab-case", "kebabCase")]
            [TestCase("kebab-case-again", "kebabCaseAgain")]
            public void WhenIsKebabCase_ThenReturnString(string sut, string expected)
            {
                var result = CaseConverter.ToCamelCase(sut, CaseType.KebabCase);

                Assert.That(result, Is.EqualTo(expected));
            }

            [TestCase(null, null)]
            [TestCase("", "")]
            [TestCase("Pascal", "pascal")]
            [TestCase("PascalCase", "pascalCase")]
            [TestCase("PascalCaseAgain", "pascalCaseAgain")]
            public void WhenIsPascalCase_ThenReturnString(string sut, string expected)
            {
                var result = CaseConverter.ToCamelCase(sut, CaseType.PascalCase);

                Assert.That(result, Is.EqualTo(expected));
            }

            [TestCase(null, null)]
            [TestCase("", "")]
            [TestCase("SNAKE", "snake")]
            [TestCase("SNAKE_CASE", "snakeCase")]
            [TestCase("SNAKE_CASE_AGAIN", "snakeCaseAgain")]
            public void WhenIsSnakeUpperCase_ThenReturnString(string sut, string expected)
            {
                var result = CaseConverter.ToCamelCase(sut, CaseType.SnakeUpperCase);

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class ToSnakeCase : CaseConverterTests
        {
            [TestCase("camelCase")]
            [TestCase("kebab-case")]
            [TestCase("PascalCase")]
            [TestCase("SNAKE_UPPER_CASE")]
            public void WhenIsNotCaseSpecified_ThenThrowException(string value)
            {
                Assert.Throws<ArgumentException>(() => CaseConverter.ToSnakeCase(value, CaseType.SnakeCase));
            }

            [Test]
            public void WhenIsSnakeCase_ThenReturnSameString()
            {
                var sut = "snake_case";

                var result = CaseConverter.ToSnakeCase(sut, CaseType.SnakeCase);

                Assert.That(result, Is.EqualTo(sut));
            }

            [TestCase(null, null)]
            [TestCase("", "")]
            [TestCase("camel", "camel")]
            [TestCase("camelCase", "camel_case")]
            [TestCase("camelCaseAgain", "camel_case_again")]
            public void WhenIsCamelCase_ThenReturnString(string sut, string expected)
            {
                var result = CaseConverter.ToSnakeCase(sut, CaseType.CamelCase);

                Assert.That(result, Is.EqualTo(expected));
            }

            [TestCase(null, null)]
            [TestCase("", "")]
            [TestCase("kebab", "kebab")]
            [TestCase("kebab-case", "kebab_case")]
            [TestCase("kebab-case-again", "kebab_case_again")]
            public void WhenIsKebabCase_ThenReturnString(string sut, string expected)
            {
                var result = CaseConverter.ToSnakeCase(sut, CaseType.KebabCase);

                Assert.That(result, Is.EqualTo(expected));
            }

            [TestCase(null, null)]
            [TestCase("", "")]
            [TestCase("Pascal", "pascal")]
            [TestCase("PascalCase", "pascal_case")]
            [TestCase("PascalCaseAgain", "pascal_case_again")]
            public void WhenIsPascalCase_ThenReturnString(string sut, string expected)
            {
                var result = CaseConverter.ToSnakeCase(sut, CaseType.PascalCase);

                Assert.That(result, Is.EqualTo(expected));
            }

            [TestCase(null, null)]
            [TestCase("", "")]
            [TestCase("SNAKE", "snake")]
            [TestCase("SNAKE_CASE", "snake_case")]
            [TestCase("SNAKE_CASE_AGAIN", "snake_case_again")]
            public void WhenIsSnakeUpperCase_ThenReturnString(string sut, string expected)
            {
                var result = CaseConverter.ToSnakeCase(sut, CaseType.SnakeUpperCase);

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class ToKebabCase : CaseConverterTests
        {
            [TestCase("camelCase")]
            [TestCase("snake_case")]
            [TestCase("PascalCase")]
            [TestCase("SNAKE_UPPER_CASE")]
            public void WhenIsNotCaseSpecified_ThenThrowException(string value)
            {
                Assert.Throws<ArgumentException>(() => CaseConverter.ToKebabCase(value, CaseType.KebabCase));
            }

            [Test]
            public void WhenIsKebabCase_ThenReturnSameString()
            {
                const string value = "kebab-case";

                var result = CaseConverter.ToKebabCase(value, CaseType.KebabCase);

                Assert.That(result, Is.EqualTo(value));
            }

            [TestCase(null, null)]
            [TestCase("", "")]
            [TestCase("camel", "camel")]
            [TestCase("camelCase", "camel-case")]
            [TestCase("camelCaseAgain", "camel-case-again")]
            public void WhenIsCamelCase_ThenReturnString(string value, string expected)
            {
                var result = CaseConverter.ToKebabCase(value, CaseType.CamelCase);

                Assert.That(result, Is.EqualTo(expected));
            }

            [TestCase(null, null)]
            [TestCase("", "")]
            [TestCase("snake", "snake")]
            [TestCase("snake_case", "snake-case")]
            [TestCase("snake_case_again", "snake-case-again")]
            public void WhenIsSnakeCase_ThenReturnString(string value, string expected)
            {
                var result = CaseConverter.ToKebabCase(value, CaseType.SnakeCase);

                Assert.That(result, Is.EqualTo(expected));
            }

            [TestCase(null, null)]
            [TestCase("", "")]
            [TestCase("Pascal", "pascal")]
            [TestCase("PascalCase", "pascal-case")]
            [TestCase("PascalCaseAgain", "pascal-case-again")]
            public void WhenIsPascalCase_ThenReturnString(string value, string expected)
            {
                var result = CaseConverter.ToKebabCase(value, CaseType.PascalCase);

                Assert.That(result, Is.EqualTo(expected));
            }

            [TestCase(null, null)]
            [TestCase("", "")]
            [TestCase("SNAKE", "snake")]
            [TestCase("SNAKE_CASE", "snake-case")]
            [TestCase("SNAKE_CASE_AGAIN", "snake-case-again")]
            public void WhenIsSnakeUpperCase_ThenReturnString(string value, string expected)
            {
                var result = CaseConverter.ToKebabCase(value, CaseType.SnakeUpperCase);

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class ToPascalCase : CaseConverterTests
        {
            [TestCase("camelCase")]
            [TestCase("snake_case")]
            [TestCase("kebab-case")]
            [TestCase("SNAKE_UPPER_CASE")]
            public void WhenIsNotCaseSpecified_ThenThrowException(string value)
            {
                Assert.Throws<ArgumentException>(() => CaseConverter.ToPascalCase(value, CaseType.PascalCase));
            }

            [Test]
            public void WhenIsPascalCase_ThenReturnSameString()
            {
                const string value = "PascalCase";

                var result = CaseConverter.ToPascalCase(value, CaseType.PascalCase);

                Assert.That(result, Is.EqualTo(value));
            }

            [TestCase(null, null)]
            [TestCase("", "")]
            [TestCase("camel", "Camel")]
            [TestCase("camelCase", "CamelCase")]
            [TestCase("camelCaseAgain", "CamelCaseAgain")]
            public void WhenIsCamelCase_ThenReturnString(string value, string expected)
            {
                var result = CaseConverter.ToPascalCase(value, CaseType.CamelCase);

                Assert.That(result, Is.EqualTo(expected));
            }

            [TestCase(null, null)]
            [TestCase("", "")]
            [TestCase("snake", "Snake")]
            [TestCase("snake_case", "SnakeCase")]
            [TestCase("snake_case_again", "SnakeCaseAgain")]
            public void WhenIsSnakeCase_ThenReturnString(string value, string expected)
            {
                var result = CaseConverter.ToPascalCase(value, CaseType.SnakeCase);

                Assert.That(result, Is.EqualTo(expected));
            }

            [TestCase(null, null)]
            [TestCase("", "")]
            [TestCase("kebab", "Kebab")]
            [TestCase("kebab-case", "KebabCase")]
            [TestCase("kebab-case-again", "KebabCaseAgain")]
            public void WhenIsKebabCase_ThenReturnString(string value, string expected)
            {
                var result = CaseConverter.ToPascalCase(value, CaseType.KebabCase);

                Assert.That(result, Is.EqualTo(expected));
            }

            [TestCase(null, null)]
            [TestCase("", "")]
            [TestCase("SNAKE", "Snake")]
            [TestCase("SNAKE_CASE", "SnakeCase")]
            [TestCase("SNAKE_CASE_AGAIN", "SnakeCaseAgain")]
            public void WhenIsSnakeUpperCase_ThenReturnString(string value, string expected)
            {
                var result = CaseConverter.ToPascalCase(value, CaseType.SnakeUpperCase);

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class ToSnakeUpperCase : CaseConverterTests
        {
            [TestCase("camelCase")]
            [TestCase("kebab-case")]
            [TestCase("PascalCase")]
            [TestCase("snake_upper_case")]
            public void WhenIsNotCaseSpecified_ThenThrowException(string value)
            {
                Assert.Throws<ArgumentException>(() => CaseConverter.ToSnakeUpperCase(value, CaseType.SnakeUpperCase));
            }

            [Test]
            public void WhenIsSnakeUpperCase_ThenReturnSameString()
            {
                var sut = "SNAKE_UPPER_CASE";

                var result = CaseConverter.ToSnakeUpperCase(sut, CaseType.SnakeUpperCase);

                Assert.That(result, Is.EqualTo(sut));
            }

            [TestCase(null, null)]
            [TestCase("", "")]
            [TestCase("camel", "CAMEL")]
            [TestCase("camelCase", "CAMEL_CASE")]
            [TestCase("camelCaseAgain", "CAMEL_CASE_AGAIN")]
            public void WhenIsCamelCase_ThenReturnString(string sut, string expected)
            {
                var result = CaseConverter.ToSnakeUpperCase(sut, CaseType.CamelCase);

                Assert.That(result, Is.EqualTo(expected));
            }

            [TestCase(null, null)]
            [TestCase("", "")]
            [TestCase("kebab", "KEBAB")]
            [TestCase("kebab-case", "KEBAB_CASE")]
            [TestCase("kebab-case-again", "KEBAB_CASE_AGAIN")]
            public void WhenIsKebabCase_ThenReturnString(string sut, string expected)
            {
                var result = CaseConverter.ToSnakeUpperCase(sut, CaseType.KebabCase);

                Assert.That(result, Is.EqualTo(expected));
            }

            [TestCase(null, null)]
            [TestCase("", "")]
            [TestCase("Pascal", "PASCAL")]
            [TestCase("PascalCase", "PASCAL_CASE")]
            [TestCase("PascalCaseAgain", "PASCAL_CASE_AGAIN")]
            public void WhenIsPascalCase_ThenReturnString(string sut, string expected)
            {
                var result = CaseConverter.ToSnakeUpperCase(sut, CaseType.PascalCase);

                Assert.That(result, Is.EqualTo(expected));
            }

            [TestCase(null, null)]
            [TestCase("", "")]
            [TestCase("snake", "SNAKE")]
            [TestCase("snake_case", "SNAKE_CASE")]
            [TestCase("snake_case_again", "SNAKE_CASE_AGAIN")]
            public void WhenIsSnakeCase_ThenReturnString(string sut, string expected)
            {
                var result = CaseConverter.ToSnakeUpperCase(sut, CaseType.SnakeCase);

                Assert.That(result, Is.EqualTo(expected));
            }
        }
    }
}