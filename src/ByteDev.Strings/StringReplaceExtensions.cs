using System;
using System.Text.RegularExpressions;

namespace ByteDev.Strings
{
    /// <summary>
    /// Extension methods for <see cref="T:System.String" />.
    /// </summary>
    public static class StringReplaceExtensions
    {
        /// <summary>
        /// Replace all the tokens in the <paramref name="source" /> with <paramref name="value" />.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="tokenName">The token to search and replace on.</param>
        /// <param name="value">The value to replace with.</param>
        /// <returns>String with all the instances of the token replaced.</returns>
        public static string ReplaceToken(this string source, string tokenName, object value)
        {
            if (string.IsNullOrEmpty(source))
                return source;

            return source.Replace($"{{{tokenName}}}", value.ToString());
        }

        /// <summary>
        /// Replaces the first occurence of <paramref name="oldValue" /> with <paramref name="newValue" />.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="oldValue">The string to replace.</param>
        /// <param name="newValue">The string to replace all occurrences with.</param>
        /// <returns>String with any first occurrence replaced.</returns>
        public static string ReplaceFirst(this string source, string oldValue, string newValue)
        {
            if (string.IsNullOrEmpty(source))
                return source;
            
            var regex = new Regex(oldValue, RegexOptions.IgnoreCase);

            return regex.Replace(source, newValue, 1);
        }

        /// <summary>
        /// Replaces the last occurence of <paramref name="oldValue" /> with <paramref name="newValue" />.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="oldValue">The string to replace.</param>
        /// <param name="newValue">The string to replace all occurrences with.</param>
        /// <returns>String with any last occurrence replaced.</returns>
        public static string ReplaceLast(this string source, string oldValue, string newValue)
        {
            if (string.IsNullOrEmpty(source))
                return source;
            
            var pos = source.LastIndexOf(oldValue, StringComparison.InvariantCulture);

            return pos <= 0 ? source : source.Remove(pos, oldValue.Length).Insert(pos, newValue);
        }

        /// <summary>
        /// Replaces multiple occurrences of char <paramref name="value" /> with a single occurrence.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="value">Char to check for multiple occurrences.</param>
        /// <returns>String with an multiple occurrence of <paramref name="value" /> replaced with a single occurrence.</returns>
        public static string ReplaceMultiOccurrences(this string source, char value)
        {
            if (string.IsNullOrEmpty(source))
                return source;

            var chString = value.ToString();
            var twoChString = chString + chString;

            while (source.Contains(twoChString))
            {
                source = source.Replace(twoChString, chString);
            }
            
            return source;
        }
    }
}