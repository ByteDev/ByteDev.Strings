using System;
using System.Text.RegularExpressions;

namespace ByteDev.Strings
{
    /// <summary>
    /// Extension methods for <see cref="T:System.String" />.
    /// </summary>
    public static class StringRemoveExtensions
    {
        /// <summary>
        /// Removes starting string <paramref name="value" /> if <paramref name="source" /> starts with it.
        /// </summary>
        /// <param name="source">The string to perform the operation on.</param>
        /// <param name="value">The starting string.</param>
        /// <returns>String with the starting string <paramref name="value" /> removed if it starts with it.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="value" /> is null.</exception>
        public static string RemoveStartsWith(this string source, string value)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));

            if(value == null)
                throw new ArgumentNullException(nameof(value));

            if (value == string.Empty)
                return source;

            if (source.StartsWith(value))
                return source.Substring(value.Length);

            return source;
        }

        /// <summary>
        /// Removes ending string <paramref name="value" /> if <paramref name="source" /> starts with it.
        /// </summary>
        /// <param name="source">The string to perform the operation on.</param>
        /// <param name="value">The ending string.</param>
        /// <returns>String with the ending string <paramref name="value" /> removed if it ends with it.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="value" /> is null.</exception>
        public static string RemoveEndsWith(this string source, string value)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (value == string.Empty)
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
        /// <param name="source">The string to perform the operation on.</param>
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
        /// <param name="source">The string to perform the operation on.</param>
        /// <returns>String without white space characters.</returns>
        public static string RemoveWhiteSpace(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return source;

            return Regex.Replace(source, @"\s+", "");
        }
    }
}