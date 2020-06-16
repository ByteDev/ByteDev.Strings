using System;
using System.Text.RegularExpressions;

namespace ByteDev.Strings
{
    public static class StringCaseExtensions
    {
        public static bool IsCaseType(this string value, CaseType caseType)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            if (caseType == CaseType.CamelCase)
            {
                return Regex.IsMatch(value, "^[a-z]{1}[a-zA-Z0-9]*$");
            }

            if (caseType == CaseType.SnakeCase)
            {
                return Regex.IsMatch(value, "^[a-z]{1}[a-z0-9_]*$");
            }

            if (caseType == CaseType.KebabCase)
            {
                return Regex.IsMatch(value, "^[a-z]{1}[a-z0-9-]*$");
            }

            if (caseType == CaseType.PascalCase)
            {
                return Regex.IsMatch(value, "^[A-Z]{1}[a-zA-Z0-9]*$");
            }

            if (caseType == CaseType.SnakeUpperCase)
            {
                return Regex.IsMatch(value, "^[A-Z]{1}[A-Z_]*$");
            }

            throw new InvalidOperationException($"Unhandled case type: {caseType}.");
        }
    }
}