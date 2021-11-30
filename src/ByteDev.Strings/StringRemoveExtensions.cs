using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ByteDev.Strings
{
    /// <summary>
    /// Extension methods for <see cref="T:System.String" />.
    /// </summary>
    public static class StringRemoveExtensions
    {
        /// <summary>
        /// Removes any leading zeros from the string.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <returns>String with any leading zeros removed.</returns>
        public static string RemoveLeadingZeros(this string source)
        {
            return source?.TrimStart('0');
        }

        /// <summary>
        /// Removes starting string <paramref name="value" /> if this string starts with it.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="value">The starting string.</param>
        /// <returns>String with the starting string <paramref name="value" /> removed if it starts with it.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="value" /> is null.</exception>
        public static string RemoveStartsWith(this string source, string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            
            if (string.IsNullOrEmpty(source))
                return source;

            if (value == string.Empty)
                return source;

            if (source.StartsWith(value))
                return source.Substring(value.Length);

            return source;
        }

        /// <summary>
        /// Removes ending string <paramref name="value" /> if this string ends with it.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="value">The ending string.</param>
        /// <returns>String with the ending string <paramref name="value" /> removed if it ends with it.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="value" /> is null.</exception>
        public static string RemoveEndsWith(this string source, string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (value == string.Empty)
                return source;

            if (string.IsNullOrEmpty(source))
                return source;

            if (source.EndsWith(value))
                return source.Substring(0, source.Length - value.Length);

            return source;
        }

        /// <summary>
        /// Removes all text between any brackets (and the brackets themselves).
        /// </summary>
        /// <example>
        /// "(Something) in (brackets) again" becomes " in  again".
        /// </example>
        /// <param name="source">String to perform the operation on.</param>
        /// <returns>String without bracketed text.</returns>
        public static string RemoveBracketedText(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return source;

            int posOpenBracket;

            while ((posOpenBracket = source.IndexOf("(", StringComparison.Ordinal)) >= 0)
            {
                var posCloseBracket = source.IndexOf(")", posOpenBracket, StringComparison.Ordinal);

                if (posCloseBracket > 0)
                {
                    source = source.Substring(0, posOpenBracket) + source.Substring(posCloseBracket + 1);
                }
                else
                {
                    source = source.Substring(0, posOpenBracket);
                    break;
                }
            }
            
            return source;
        }

        /// <summary>
        /// Removes all white space characters from the string.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <returns>String without white space characters.</returns>
        public static string RemoveWhiteSpace(this string source)
        {
            if (source == null)
                return null;

            return new string(source
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
        }

        /// <summary>
        /// Removes all non-digit (0-9) characters from the string.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <returns>String without non-digit characters.</returns>
        public static string RemoveNonDigits(this string source)
        {
            if (source == null)
                return null;

            return new string(source
                .Where(char.IsDigit)
                .ToArray());
        }

        /// <summary>
        /// Removes all <paramref name="removeValue" /> from this string.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="removeValue">Value to remove.</param>
        /// <param name="ignoreCase">True will ignore case; otherwise not ignore case.</param>
        /// <returns>String with <paramref name="removeValue" /> removed.</returns>
        public static string Remove(this string source, string removeValue, bool ignoreCase = false)
        {
            if (string.IsNullOrEmpty(source))
                return source;

            return ignoreCase ? 
                Regex.Replace(source, Regex.Escape(removeValue), string.Empty, RegexOptions.IgnoreCase) : 
                source.Replace(removeValue, string.Empty);
        }

        /// <summary>
        /// Removes all <paramref name="removeValues" /> from this string.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="removeValues">Values to remove.</param>
        /// <param name="ignoreCase">True will ignore case; otherwise not ignore case.</param>
        /// <returns>String with <paramref name="removeValues" /> removed.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="removeValues" /> is null.</exception>
        public static string Remove(this string source, IEnumerable<string> removeValues, bool ignoreCase = false)
        {
            if (removeValues == null)
                throw new ArgumentNullException(nameof(removeValues));

            foreach (var removeString in removeValues)
            {
                source = Remove(source, removeString, ignoreCase);
            }

            return source;
        }
    }
}