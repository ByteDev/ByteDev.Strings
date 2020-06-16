using ByteDev.Strings.Case;
using NUnit.Framework;

namespace ByteDev.Strings.UnitTests
{
    [TestFixture]
    public class StringCaseExtensionsTests
    {
        [TestCase("c")]
        [TestCase("camel")]
        [TestCase("camelCase")]
        [TestCase("camelCaseAgain")]
        public void WhenIsCamelCase_ThenReturnTrue(string sut)
        {
            var result = sut.IsCaseType(CaseType.CamelCase);

            Assert.That(result, Is.True);
        }        

        [TestCase(null)]
        [TestCase("")]
        [TestCase("P")]
        [TestCase("PascalCase")]
        [TestCase("snake_case")]
        [TestCase("kebab-case")]
        public void WhenIsNotCamelCase_ThenReturnFalse(string sut)
        {
            var result = sut.IsCaseType(CaseType.CamelCase);

            Assert.That(result, Is.False);
        }   
        

        [TestCase("s")]
        [TestCase("snake")]
        [TestCase("snake_case")]
        [TestCase("snake_case_again")]
        public void WhenIsSnakeCase_ThenReturnTrue(string sut)
        {
            var result = sut.IsCaseType(CaseType.SnakeCase);

            Assert.That(result, Is.True);
        }        

        [TestCase(null)]
        [TestCase("")]
        [TestCase("_")]
        [TestCase("S")]
        [TestCase("camelCase")]
        [TestCase("kebab-case")]
        [TestCase("SNAKE_UPPER_CASE")]
        public void WhenIsNotSnakeCase_ThenReturnFalse(string sut)
        {
            var result = sut.IsCaseType(CaseType.SnakeCase);

            Assert.That(result, Is.False);
        }   


        [TestCase("k")]
        [TestCase("kebab")]
        [TestCase("kebab-case")]
        [TestCase("kebab-case-again")]
        public void WhenIsKebabCase_ThenReturnTrue(string sut)
        {
            var result = sut.IsCaseType(CaseType.KebabCase);

            Assert.That(result, Is.True);
        }        

        [TestCase(null)]
        [TestCase("")]
        [TestCase("-")]
        [TestCase("K")]
        [TestCase("camelCase")]
        [TestCase("PascalCase")]
        [TestCase("snake_case")]
        public void WhenIsNotKebabCase_ThenReturnFalse(string sut)
        {
            var result = sut.IsCaseType(CaseType.KebabCase);

            Assert.That(result, Is.False);
        } 


        [TestCase("P")]
        [TestCase("Pascal")]
        [TestCase("PascalCase")]
        [TestCase("PascalCaseAgain")]
        public void WhenIsPascalCase_ThenReturnTrue(string sut)
        {
            var result = sut.IsCaseType(CaseType.PascalCase);

            Assert.That(result, Is.True);
        }        

        [TestCase(null)]
        [TestCase("")]
        [TestCase("p")]
        [TestCase("camelCase")]
        [TestCase("kebab-case")]
        [TestCase("snake_case")]
        public void WhenIsNotPascalCase_ThenReturnFalse(string sut)
        {
            var result = sut.IsCaseType(CaseType.PascalCase);

            Assert.That(result, Is.False);
        }


        [TestCase("S")]
        [TestCase("SNAKE")]
        [TestCase("SNAKE_UPPER")]
        [TestCase("SNAKE_UPPER_CASE")]
        public void WhenIsSnakeUpperCase_ThenReturnTrue(string sut)
        {
            var result = sut.IsCaseType(CaseType.SnakeUpperCase);

            Assert.That(result, Is.True);
        }        

        [TestCase(null)]
        [TestCase("")]
        [TestCase("s")]
        [TestCase("camelCase")]
        [TestCase("kebab-case")]
        [TestCase("snake_case")]
        public void WhenIsNotSnakeUpperCase_ThenReturnFalse(string sut)
        {
            var result = sut.IsCaseType(CaseType.PascalCase);

            Assert.That(result, Is.False);
        }
    }
}