using System;
using System.Text.RegularExpressions;

namespace ByteDev.Strings.Case
{
    /// <summary>
    /// Extension methods for <see cref="T:System.String" />.
    /// </summary>
    public static class StringCaseExtensions
    {
        /// <summary>
        /// Indicates if a string value is in camelCase.
        /// </summary>
        /// <param name="source">Value to evaluate.</param>
        /// <returns>True if value is in camelCase; otherwise false.</returns>
        public static bool IsCamelCase(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return false;

            return Regex.IsMatch(source, "^[a-z]{1}[a-zA-Z0-9]*$");
        }

        /// <summary>
        /// Indicates if a string value is in kebab-case.
        /// </summary>
        /// <param name="source">Value to evaluate.</param>
        /// <returns>True if value is in kebab-case; otherwise false.</returns>
        public static bool IsKebabCase(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return false;

            return Regex.IsMatch(source, "^[a-z]{1}[a-z0-9-]*$");
        }

        /// <summary>
        /// Indicates if a string value is in PascalCase.
        /// </summary>
        /// <param name="source">Value to evaluate.</param>
        /// <returns>True if value is in PascalCase; otherwise false.</returns>
        public static bool IsPascalCase(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return false;

            return Regex.IsMatch(source, "^[A-Z]{1}[a-zA-Z0-9]*$");
        }

        /// <summary>
        /// Indicates if a string value is in snake_case.
        /// </summary>
        /// <param name="source">Value to evaluate.</param>
        /// <returns>True if value is in snake_case; otherwise false.</returns>
        public static bool IsSnakeCase(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return false;

            return Regex.IsMatch(source, "^[a-z]{1}[a-z0-9_]*$");
        }

        /// <summary>
        /// Indicates if a string value is in SNAKE_UPPER_CASE.
        /// </summary>
        /// <param name="source">Value to evaluate.</param>
        /// <returns>True if value is in SNAKE_UPPER_CASE; otherwise false.</returns>
        public static bool IsSnakeUpperCase(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return false;

            return Regex.IsMatch(source, "^[A-Z]{1}[A-Z_]*$");
        }

        /// <summary>
        /// Indicates if a string value is a particular <see cref="T:ByteDev.Strings.Case.CaseType" />.
        /// </summary>
        /// <param name="source">Value to evaluate.</param>
        /// <param name="caseType">Case type to evaluate.</param>
        /// <returns>True if value is of the case type; otherwise false.</returns>
        public static bool IsCaseType(this string source, CaseType caseType)
        {
            if (caseType == CaseType.CamelCase)
                return IsCamelCase(source);

            if (caseType == CaseType.KebabCase)
                return IsKebabCase(source);
            
            if (caseType == CaseType.PascalCase)
                return IsPascalCase(source);

            if (caseType == CaseType.SnakeCase)
                return IsSnakeCase(source);

            if (caseType == CaseType.SnakeUpperCase)
                return IsSnakeUpperCase(source);

            throw new InvalidOperationException($"Unhandled case type: {caseType}.");
        }
    }
}