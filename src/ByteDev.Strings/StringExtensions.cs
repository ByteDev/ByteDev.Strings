using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ByteDev.Strings
{
    /// <summary>
    /// Extension methods for <see cref="T:System.String" />.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Replaces the format item in a specified string with the string representation of a corresponding object in a specified array.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="args">Arguments to format the string with.</param>
        /// <returns>A copy of <paramref name="source">format</paramref> in which the format items have been replaced by the string representation of the corresponding objects in <paramref name="args">args</paramref>.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static string FormatWith(this string source, params object[] args)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            
            return string.Format(source, args);
        }
        
        /// <summary>
        /// Retrieves a substring from this instance taking <paramref name="length" /> characters from the left.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="length">The number of characters to take starting on the left.</param>
        /// <returns>A string that is equivalent to the substring of length <paramref name="length" /> taking characters from the left.</returns>
        public static string Left(this string source, int length)
        {
            return source.SafeSubstring(0, length);
        }

        /// <summary>
        /// Takes the length of characters from the left. Uses an appended ellipsis if the max length minus 3 is reached.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="maxLength">The number of characters to take starting on the left.</param>
        /// <returns>Shortened string with ellipsis if greater than max length minus 3; otherwise returns the original string.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="maxLength" /> cannot be between 1 and 3.</exception>
        public static string LeftWithEllipsis(this string source, int maxLength)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (maxLength < 1)
                return string.Empty;
            
            const string ellipsis = "...";

            if (maxLength <= ellipsis.Length)
                throw new ArgumentOutOfRangeException(nameof(maxLength), $"Max length cannot be between 1 and {ellipsis.Length} (ellipsis length).");

            if (maxLength < source.Length)
                return source.Substring(0, maxLength - ellipsis.Length) + ellipsis;

            return source;
        }

        /// <summary>
        /// Truncates the given string by stripping out the center and replacing it with an 
        /// ellipsis so that the beginning and end of the string are retained.
        /// </summary>
        /// <example>
        /// "This string has too many characters for its own good."LeftWithInnerEllipsis(32) yields 
        /// "This string has...its own good."
        /// </example>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="maxLength">The number of characters to take starting on the left.</param>
        /// <returns>Shortened string with inner ellipsis if greater than max length minus 3; otherwise returns the original string.</returns>
        public static string LeftWithInnerEllipsis(this string source, int maxLength)
        {
            if (string.IsNullOrEmpty(source) || source.Length <= maxLength)
                return source;

            var charsInEachHalf = (maxLength - 3) / 2;

            var right = source.Substring(source.Length - charsInEachHalf, charsInEachHalf).TrimStart();

            var left = source.Substring(0, (maxLength - 3) - right.Length).TrimEnd();

            return $"{left}...{right}";
        }

        /// <summary>
        /// Retrieves a substring from this instance taking <paramref name="length" /> characters from the right.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="length">The number of characters to take starting on the right.</param>
        /// <returns>A string that is equivalent to the substring of length <paramref name="length" /> taking characters from the right.</returns>
        public static string Right(this string source, int length)
        {
            if (length > source.Length)
                return source;

            return source.SafeSubstring(source.Length - length, length);
        }

        /// <summary>
        /// Returns <paramref name="source" /> repeated <paramref name="count" /> times.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="count">The count of instances to return.</param>
        /// <returns>String repeated.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static string Repeat(this string source, int count)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return new StringBuilder().Insert(0, source, count).ToString();
        }

        /// <summary>
        /// Returns a string with additional plural suffix. 
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="number">The number to base the plural on.</param>
        /// <returns>String with an required plural suffix.</returns>
        public static string Pluralize(this string source, int number)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;

            number = Math.Abs(number); // -1 should be singular, too
            return source + (number == 1 ? string.Empty : "s");
        }

        /// <summary>
        /// Returns the occurrence count of <paramref name="value" /> within the string.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="value">The string to count the occurrence of.</param>
        /// <returns>Count of occurrences.</returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="value" /> is null or empty.</exception>
        public static int CountOccurrences(this string source, string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Value is null or empty", nameof(value));

            return string.IsNullOrEmpty(source) ? 0 : Regex.Matches(source, Regex.Escape(value)).Count;
        }

        /// <summary>
        /// Returns the occurrence count of <paramref name="value" /> within the string.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="value">The string to count the occurrence of.</param>
        /// <returns>Count of occurrences.</returns>
        public static int CountOccurrences(this string source, char value)
        {
            return string.IsNullOrEmpty(source) ? 0 : source.Count(mt => mt == value);
        }

        /// <summary>
        /// Returns a string with characters reversed.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <returns>String with all characters reversed.</returns>
        public static string Reverse(this string source)
        {
            if (source == null)
                return null;

            var charArray = source.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// Returns a string with a wrapper string to the left and right of it.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="wrapper">Wrapper to use.</param>
        /// <returns>String wrapped with the wrapper.</returns>
        public static string Wrap(this string source, string wrapper)
        {
            return wrapper + source + wrapper;
        }

        /// <summary>
        /// Returns a string with a wrapper string to the left and right of it.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="wrapper">Wrapper to use.</param>
        /// <returns>String wrapped with the wrapper.</returns>
        public static string Wrap(this string source, char wrapper)
        {
            return wrapper + source + wrapper;
        }

        /// <summary>
        /// Returns a new string with a delimiter inserted before every upper case character (except the first).
        /// For example: "NotFoundHere" will be returned as "Not Found Here".
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="delimiter">Delimiter value to insert.</param>
        /// <returns>String with delimiter inserted before upper case characters.</returns>
        public static string InsertBeforeUpperCase(this string source, string delimiter)
        {
            if (string.IsNullOrEmpty(source))
                return source;

            var sb = new StringBuilder();
            var isUpperCaseAppended = false;
            
            foreach (char ch in source)
            {
                if (ch.IsUpperCase() && isUpperCaseAppended)
                    sb.Append(delimiter);

                sb.Append(ch);

                if (ch.IsUpperCase())
                    isUpperCaseAppended = true;
            }

            return sb.ToString();
        }
    }
}