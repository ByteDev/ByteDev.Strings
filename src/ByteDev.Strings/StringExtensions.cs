using System;
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
        /// Returns the length of a string or zero if it is null.
        /// </summary>
        /// <param name="source">The string to return the length on.</param>
        /// <returns>Length of the string. Zero if the string is null.</returns>
        public static int SafeLength(this string source)
        {
            return source?.Length ?? 0;
        }

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
        /// Replace all the tokens in the <paramref name="source" /> with <paramref name="value" />.
        /// </summary>
        /// <param name="source">The string to perform the operation on.</param>
        /// <param name="tokenName">The token to search and replace on.</param>
        /// <param name="value">The value to replace with.</param>
        /// <returns>String with all the instances of the token replaced.</returns>
        public static string ReplaceToken(this string source, string tokenName, object value)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Replace($"{{{tokenName}}}", value.ToString());
        }

        /// <summary>
        /// Replaces the format item in a specified string with the string representation of a corresponding object in a specified array.
        /// </summary>
        /// <param name="source">String to format.</param>
        /// <param name="args">Arguments to format the string with.</param>
        /// <returns>A copy of <paramref name="source">format</paramref> in which the format items have been replaced by the string representation of the corresponding objects in <paramref name="args">args</paramref>.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static string FormatWith(this string source, params object[] args)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));
            
            return string.Format(source, args);
        }

        /// <summary>
        /// Safely retrieves a substring from this instance. No exceptions will be thrown.
        /// </summary>
        /// <param name="source">The string to perform the operation on.</param>
        /// <param name="startIndex">The zero-based starting character position of a substring in this instance.</param>
        /// <param name="length">The number of characters in the substring.</param>
        /// <returns>A string that is equivalent to the substring of length <paramref name="length" /> that begins at <paramref name="startIndex" />.</returns>
        public static string SafeSubstring(this string source, int startIndex, int length)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;

            if (length < 1)
                return string.Empty;

            if (source.Length <= startIndex) 
                return string.Empty;

            if (source.Length - startIndex <= length) 
                return source.Substring(startIndex);

            return source.Substring(startIndex, length);
        }

        /// <summary>
        /// Retrieves a substring from this instance taking <paramref name="length" /> characters from the left.
        /// </summary>
        /// <param name="source">The string to perform the operation on.</param>
        /// <param name="length">The number of characters to take starting on the left.</param>
        /// <returns>A string that is equivalent to the substring of length <paramref name="length" /> taking characters from the left.</returns>
        public static string Left(this string source, int length)
        {
            return source.SafeSubstring(0, length);
        }

        /// <summary>
        /// Retrieves a substring from this instance taking <paramref name="length" /> characters from the right.
        /// </summary>
        /// <param name="source">The string to perform the operation on.</param>
        /// <param name="length">The number of characters to take starting on the right.</param>
        /// <returns>A string that is equivalent to the substring of length <paramref name="length" /> taking characters from the right.</returns>
        public static string Right(this string source, int length)
        {
            if (length > source.Length)
                return source;

            return source.SafeSubstring(source.Length - length, length);
        }

        /// <summary>
        /// Takes the length of characters from the left. Uses an appended ellipsis if the max length minus 3 is reached.
        /// </summary>
        /// <param name="source">The string to perform the operation on.</param>
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

            if(maxLength <= ellipsis.Length)
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
        /// <param name="source">The string to perform the operation on.</param>
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

        /// <summary>
        /// Replaces the last occurence of <paramref name="oldString" /> with <paramref name="newString" />.
        /// </summary>
        /// <param name="source">The string to perform the operation on.</param>
        /// <param name="oldString">The string to search for and replace.</param>
        /// <param name="newString">The string to replace with.</param>
        /// <returns>String with <paramref name="oldString" /> replaced with <paramref name="newString" />.</returns>
        public static string ReplaceLastOccurrence(this string source, string oldString, string newString)
        {
            if (string.IsNullOrEmpty(source))
                return source;
            
            var pos = source.LastIndexOf(oldString, StringComparison.InvariantCulture);

            return pos <= 0 ? source : source.Remove(pos, oldString.Length).Insert(pos, newString);
        }

        /// <summary>
        /// Returns a string with additional plural suffix. 
        /// </summary>
        /// <param name="source">The string to perform the operation on.</param>
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
        /// Returns the occurence count of <paramref name="value" /> within the string.
        /// </summary>
        /// <param name="source">The string to perform the operation on.</param>
        /// <param name="value">The string to count the occurence of.</param>
        /// <returns>Count of occurence.</returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="value" /> is null or empty.</exception>
        public static int CountOccurences(this string source, string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Value was null or empty.", nameof(value));
            
            return Regex.Matches(source, Regex.Escape(value)).Count;
        }

        
        /// <summary>
        /// Returns an obscured string.
        /// </summary>
        /// <param name="source">The string to perform the operation on.</param>
        /// <param name="beginCharsToShow">Chars to show from the left.</param>
        /// <param name="endCharsToShow">Chars to show from the right.</param>
        /// <returns>String with obscured characters.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static string Obscure(this string source, int beginCharsToShow, int endCharsToShow)
        {
            return Obscure(source, beginCharsToShow, endCharsToShow, '*');
        }

        /// <summary>
        /// Returns an obscured string.
        /// </summary>
        /// <param name="source">The string to perform the operation on.</param>
        /// <param name="beginCharsToShow">Chars to show from the left.</param>
        /// <param name="endCharsToShow">Chars to show from the right.</param>
        /// <param name="obscureChar">Obscure character.</param>
        /// <returns>String with obscured characters.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static string Obscure(this string source, int beginCharsToShow, int endCharsToShow, char obscureChar)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var len = source.Length;
            var sb = new StringBuilder(len);

            for (var pos = 0; pos < len; pos++)
            {
                sb.Append(pos < beginCharsToShow || len - pos <= endCharsToShow ? source[pos] : obscureChar);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Returns <paramref name="source" /> repeated <paramref name="count" /> times.
        /// </summary>
        /// <param name="source">The string to perform the operation on.</param>
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
        /// Returns a string with a forward slash suffix appended if one does not currently exist.
        /// </summary>
        /// <param name="source">The string to perform the operation on.</param>
        /// <returns>String with an appended forward slash.</returns>
        public static string AddSlashSuffix(this string source)
        {
            if (source == null)
                return "/";

            if (!source.EndsWith("/"))
                source += "/";
            
            return source;
        }

        /// <summary>
        /// Returns a string with a forward slash prefix removed if one currently exists.
        /// </summary>
        /// <param name="source">The string to perform the operation on.</param>
        /// <returns>String with any forward slash prefix removed.</returns>
        public static string RemoveSlashPrefix(this string source)
        {
            if (source == null)
                return null;

            if (source.StartsWith("/"))
                source = source.Substring(1);
            
            return source;
        }

        /// <summary>
        /// Returns a string with characters reversed.
        /// </summary>
        /// <param name="source">The string to perform the operation on.</param>
        /// <returns>String with all characters reversed.</returns>
        public static string Reverse(this string source)
        {
            if (source == null)
                return null;

            var charArray = source.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        } 
    }
}

