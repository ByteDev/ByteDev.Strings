using System;
using System.Collections.Generic;

namespace ByteDev.Strings
{
    /// <summary>
    /// Extension methods for <see cref="T:System.String" />.
    /// </summary>
    public static class StringContainsExtensions
    {
        /// <summary>
        /// Returns a value indicating whether a specified substring occurs within this string
        /// ignoring the case of the string.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="value">The string to seek.</param>
        /// <returns>True if <paramref name="value" /> occurs; otherwise false.</returns>
        public static bool ContainsIgnoreCase(this string source, string value)
        {
            if (source == null)
                return false;

            return source.IndexOf(value, StringComparison.InvariantCultureIgnoreCase) != -1;
        }

        /// <summary>
        /// Determine if the string contains only the supplied allowed characters.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="chars">String of allowed characters.</param>
        /// <returns>True if the string contains only the allowed characters; otherwise false.</returns>
        public static bool ContainsOnly(this string source, string chars)
        {
            return chars == null ? 
                ContainsOnly(source, new List<char>()) : 
                ContainsOnly(source, chars.ToCharArray());
        }

        /// <summary>
        /// Determine if the string contains only the given allowed characters.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="chars">Collection of allowed characters.</param>
        /// <returns>True if the string contains only the allowed characters; otherwise false.</returns>
        public static bool ContainsOnly(this string source, ICollection<char> chars)
        {
            if (source == null || chars == null || chars.Count == 0)
                return false;

            foreach (char ch in source)
            {
                if (!chars.Contains(ch))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Determine if the string contains any of the supplied characters.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="chars">String of characters.</param>
        /// <returns>True if the string contains any of the supplied characters; otherwise false.</returns>
        public static bool ContainsAny(this string source, string chars)
        {
            return chars == null ? 
                ContainsAny(source, new List<char>()) : 
                ContainsAny(source, chars.ToCharArray());
        }

        /// <summary>
        /// Determine if the string contains any of the supplied characters.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="chars">Collection of characters.</param>
        /// <returns>True if the string contains any of the supplied characters; otherwise false.</returns>
        public static bool ContainsAny(this string source, ICollection<char> chars)
        {
            if (source == null || chars == null || chars.Count == 0)
                return false;

            foreach (char ch in source)
            {
                if (chars.Contains(ch))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Determine if the string contains all of the supplied characters.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="chars">String of characters.</param>
        /// <returns>True if the string contains all of the supplied characters; otherwise false.</returns>
        public static bool ContainsAll(this string source, string chars)
        {
            return chars == null ? 
                ContainsAll(source, new List<char>()) : 
                ContainsAll(source, chars.ToCharArray());
        }

        /// <summary>
        /// Determine if the string contains all of the supplied characters.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="chars">String of characters.</param>
        /// <returns>True if the string contains all of the supplied characters; otherwise false.</returns>
        public static bool ContainsAll(this string source, ICollection<char> chars)
        {
            if (source == null)
                return false;

            if (chars == null || chars.Count == 0)
                return true;

            foreach (var ch in chars)
            {
                if (!source.Contains(ch.ToString()))
                    return false;
            }

            return true;
        }
    }
}