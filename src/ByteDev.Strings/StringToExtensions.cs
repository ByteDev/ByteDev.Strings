using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace ByteDev.Strings
{
    /// <summary>
    /// Extension methods for <see cref="T:System.String" />.
    /// </summary>
    public static class StringToExtensions
    {
        /// <summary>
        /// Returns a copy of this string converted to title case.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>A string in title case.</returns>
        public static string ToTitleCase(this string source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            
            return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(source.ToLower());
        }

        /// <summary>
        /// Returns this string as a collection of lines.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>The current string as a collection of lines.</returns>
        public static IEnumerable<string> ToLines(this string source)
        {
            if (string.IsNullOrEmpty(source))
                source = string.Empty;
            
            using (var reader = new StringReader(source))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        /// <summary>
        /// Returns this string as a byte array.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>The current string as an array of bytes.</returns>
        public static byte[] ToByteArray(this string source)
        {
            return ToByteArray(source, new UTF8Encoding());
        }

        /// <summary>
        /// Returns this string as a byte array using the given <paramref name="encoding" />.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <param name="encoding">Byte array encoding.</param>
        /// <returns>The current string as an array of bytes.</returns>
        public static byte[] ToByteArray(this string source, Encoding encoding)
        {
            if (string.IsNullOrEmpty(source))
                return new byte[0];
            
            return encoding.GetBytes(source);
        }

        /// <summary>
        /// Returns this string as a nullable int.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <param name="defaultValue">Default value to return if unable to convert to nullable int.</param>
        /// <returns>The current string as a nullable int.</returns>
        public static int? ToIntOrDefault(this string source, int? defaultValue)
        {
            return int.TryParse(source, out var result) ? result : defaultValue;
        }

        /// <summary>
        /// Returns this string as a nullable long.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <param name="defaultValue">Default value to return if unable to convert to nullable long.</param>
        /// <returns>The current string as a nullable long.</returns>
        public static long? ToLongOrDefault(this string source, long? defaultValue)
        {
            return long.TryParse(source, out var result) ? result : defaultValue;
        }

        /// <summary>
        /// Returns this string as a nullable DateTime.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <param name="defaultValue">Default value to return if unable to convert to nullable DateTime.</param>
        /// <returns>The current string as a nullable DateTime.</returns>
        public static DateTime? ToDateTimeOrDefault(this string source, DateTime? defaultValue)
        {
            return DateTime.TryParse(source, out var result) ? result : defaultValue;
        }

        /// <summary>
        /// Returns the string as a <typeparamref name="TEnum" />.
        /// </summary>
        /// <typeparam name="TEnum">Enum type to return.</typeparam>
        /// <param name="source">The string to perform this operation on.</param>
        /// <param name="ignoreCase">True to ignore the string's case; false to regard case.</param>
        /// <returns>The current string as a <typeparamref name="TEnum" />.</returns>
        public static TEnum ToEnum<TEnum>(this string source, bool ignoreCase = false) where TEnum : struct
        {
            return (TEnum)Enum.Parse(typeof(TEnum), source, ignoreCase);
        }
    }
}