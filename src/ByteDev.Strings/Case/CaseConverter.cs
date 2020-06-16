using System;

namespace ByteDev.Strings.Case
{
    /// <summary>
    /// Represents a converter for popular programming cases.
    /// </summary>
    public static class CaseConverter
    {
        /// <summary>
        /// Converts a value to camelCase.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        /// <param name="caseType">Case type of the value.</param>
        /// <returns>Converted value.</returns>
        /// <exception cref="T:System.InvalidOperationException">Case type was unhandled.</exception>
        public static string ToCamelCase(string value, CaseType caseType)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            if (!value.IsCaseType(caseType))
                throw new ArgumentException($"Value '{value}' is not of case type: '{caseType}'.");

            if (caseType == CaseType.SnakeCase || caseType == CaseType.SnakeUpperCase)
                return SnakeCaseConverter.ToCamelCase(value);

            if (caseType == CaseType.CamelCase)
                return value;

            if (caseType == CaseType.KebabCase)
                return KebabCaseConverter.ToCamelCase(value);

            if (caseType == CaseType.PascalCase)
                return PascalCaseConverter.ToCamelCase(value);

            throw new InvalidOperationException($"Unhandled case type: {caseType}.");
        }

        /// <summary>
        /// Converts a value to snake_case.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        /// <param name="caseType">Case type of the value.</param>
        /// <returns>Converted value.</returns>
        /// <exception cref="T:System.InvalidOperationException">Case type was unhandled.</exception>
        public static string ToSnakeCase(string value, CaseType caseType)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            if (!value.IsCaseType(caseType))
                throw new ArgumentException($"Value '{value}' is not of case type: '{caseType}'.");

            if (caseType == CaseType.SnakeCase)
                return value;

            if (caseType == CaseType.SnakeUpperCase)
                return value.ToLower();

            if (caseType == CaseType.CamelCase)
                return CamelCaseConverter.ToSnakeCase(value);

            if (caseType == CaseType.KebabCase)
                return value.Replace("-", "_");

            if (caseType == CaseType.PascalCase)
                return PascalCaseConverter.ToSnakeCase(value);

            throw new InvalidOperationException($"Unhandled case type: {caseType}.");
        }

        /// <summary>
        /// Converts a value to SNAKE_UPPER_CASE.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        /// <param name="caseType">Case type of the value.</param>
        /// <returns>Converted value.</returns>
        /// <exception cref="T:System.InvalidOperationException">Case type was unhandled.</exception>
        public static string ToSnakeUpperCase(string value, CaseType caseType)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            if (!value.IsCaseType(caseType))
                throw new ArgumentException($"Value '{value}' is not of case type: '{caseType}'.");

            if (caseType == CaseType.SnakeUpperCase)
                return value;

            if (caseType == CaseType.SnakeCase)
                return value.ToUpper();

            if (caseType == CaseType.CamelCase)
                return CamelCaseConverter.ToSnakeUpperCase(value);

            if (caseType == CaseType.KebabCase)
                return value.Replace("-", "_").ToUpper();

            if (caseType == CaseType.PascalCase)
                return PascalCaseConverter.ToSnakeUpperCase(value);

            throw new InvalidOperationException($"Unhandled case type: {caseType}.");
        }

        /// <summary>
        /// Converts a value to kebab-case.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        /// <param name="caseType">Case type of the value.</param>
        /// <returns>Converted value.</returns>
        /// <exception cref="T:System.InvalidOperationException">Case type was unhandled.</exception>
        public static string ToKebabCase(string value, CaseType caseType)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            if (!value.IsCaseType(caseType))
                throw new ArgumentException($"Value '{value}' is not of case type: '{caseType}'.");

            if (caseType == CaseType.KebabCase)
                return value;

            if (caseType == CaseType.SnakeCase)
                return value.Replace("_", "-");

            if (caseType == CaseType.SnakeUpperCase)
                return value.Replace("_", "-").ToLower();

            if (caseType == CaseType.CamelCase)
                return CamelCaseConverter.ToKebabCase(value);

            if (caseType == CaseType.PascalCase)
                return PascalCaseConverter.ToKebabCase(value);

            throw new InvalidOperationException($"Unhandled case type: {caseType}.");
        }

        /// <summary>
        /// Converts a value to PascalCase.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        /// <param name="caseType">Case type of the value.</param>
        /// <returns>Converted value.</returns>
        /// <exception cref="T:System.InvalidOperationException">Case type was unhandled.</exception>
        public static string ToPascalCase(string value, CaseType caseType)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            if (!value.IsCaseType(caseType))
                throw new ArgumentException($"Value '{value}' is not of case type: '{caseType}'.");

            if (caseType == CaseType.PascalCase)
                return value;

            if (caseType == CaseType.KebabCase)
                return KebabCaseConverter.ToPascalCase(value);

            if (caseType == CaseType.SnakeCase || caseType == CaseType.SnakeUpperCase) 
                return SnakeCaseConverter.ToPascalCase(value);

            if (caseType == CaseType.CamelCase)
                return CamelCaseConverter.ToPascalCase(value);

            throw new InvalidOperationException($"Unhandled case type: {caseType}.");
        }
    }
}