using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ByteDev.Strings
{
    /// <summary>
    /// Extension methods for <see cref="T:System.String" />.
    /// </summary>
    public static class StringToExtensions
    {
        /// <summary>
        /// Returns the string as a <typeparamref name="TEnum" />.
        /// </summary>
        /// <typeparam name="TEnum">Enum type to return.</typeparam>
        /// <param name="source">The string to perform this operation on.</param>
        /// <param name="ignoreCase">True to ignore the string's case; false to regard case.</param>
        /// <returns>The string as a <typeparamref name="TEnum" />.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="source" /> is not a valid enum value.</exception>
        public static TEnum ToEnum<TEnum>(this string source, bool ignoreCase = false) where TEnum : Enum
        {
            return (TEnum)Enum.Parse(typeof(TEnum), source, ignoreCase);
        }

        /// <summary>
        /// Returns a copy of the string converted to title case.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>The string in title case.</returns>
        public static string ToTitleCase(this string source)
        {
            if (source == null)
                return null;
            
            return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(source.ToLower());
        }

        /// <summary>
        /// Returns this string as a collection of lines.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>The string as a collection of lines.</returns>
        public static IEnumerable<string> ToLines(this string source)
        {
            if (source == null)
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
        /// <returns>The string as an array of bytes.</returns>
        public static byte[] ToByteArray(this string source)
        {
            return ToByteArray(source, new UTF8Encoding());
        }

        /// <summary>
        /// Returns this string as a byte array using the given <paramref name="encoding" />.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <param name="encoding">Byte array encoding.</param>
        /// <returns>The string as an array of bytes.</returns>
        public static byte[] ToByteArray(this string source, Encoding encoding)
        {
            if (string.IsNullOrEmpty(source))
                return new byte[0];
            
            return encoding.GetBytes(source);
        }

        /// <summary>
        /// Returns the string as a bool.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>The string as a bool if valid; otherwise false.</returns>
        public static bool ToBool(this string source)
        {
            if (bool.TryParse(source, out bool result))
                return result;

            return false;
        }

        /// <summary>
        /// Returns this string as a nullable bool.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <param name="defaultValue">Default value to return if unable to convert to nullable bool.</param>
        /// <returns>The string as a nullable bool if valid; otherwise default value.</returns>
        public static bool? ToBoolOrDefault(this string source, bool? defaultValue = null)
        {
            return bool.TryParse(source, out bool result) ? result : defaultValue;
        }

        /// <summary>
        /// Returns string as an int.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>The string as a int if valid; otherwise zero.</returns>
        public static int ToInt(this string source)
        {
            return int.TryParse(source, out var result) ? result : 0;
        }

        /// <summary>
        /// Returns this string as a nullable int.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <param name="defaultValue">Default value to return if unable to convert to nullable int.</param>
        /// <returns>The string as a nullable int if valid; otherwise default value.</returns>
        public static int? ToIntOrDefault(this string source, int? defaultValue = null)
        {
            return int.TryParse(source, out var result) ? result : defaultValue;
        }

        /// <summary>
        /// Returns string as a long.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>The string as a long if valid; otherwise zero.</returns>
        public static long ToLong(this string source)
        {
            return long.TryParse(source, out var result) ? result : 0;
        }

        /// <summary>
        /// Returns string as a nullable long.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <param name="defaultValue">Default value to return if unable to convert to nullable long.</param>
        /// <returns>The string as a nullable long if valid; otherwise default value.</returns>
        public static long? ToLongOrDefault(this string source, long? defaultValue = null)
        {
            return long.TryParse(source, out var result) ? result : defaultValue;
        }

        /// <summary>
        /// Returns string as a nullable DateTime.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <param name="defaultValue">Default value to return if unable to convert to nullable DateTime.</param>
        /// <returns>New nullable DateTime instance if the string is valid; otherwise default value.</returns>
        public static DateTime? ToDateTimeOrDefault(this string source, DateTime? defaultValue = null)
        {
            return DateTime.TryParse(source, out var result) ? result : defaultValue;
        }

        /// <summary>
        /// Returns string as a DateTime.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>New DateTime instance if the string is valid; otherwise DateTime.MinValue.</returns>
        public static DateTime ToDateTime(this string source)
        {
            return DateTime.TryParse(source, out var result) ? result : DateTime.MinValue;
        }

        /// <summary>
        /// Returns the string as a collection with each value determined by a comma delimiter.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <param name="trimValues">True trim each value; false do nothing.</param>
        /// <returns>Collection of values; otherwise empty.</returns>
        public static IEnumerable<string> ToCsv(this string source, bool trimValues = false)
        {
            return ToCsv(source, ',', trimValues);
        }

        /// <summary>
        /// Returns the string as a collection with each value determined by the specified delimiter.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <param name="delimiter">Value delimiter.</param>
        /// <param name="trimValues">True trim each value; false do nothing.</param>
        /// <returns>Collection of values; otherwise empty.</returns>
        public static IEnumerable<string> ToCsv(this string source, char delimiter, bool trimValues = false)
        {
            if (string.IsNullOrEmpty(source))
                return Enumerable.Empty<string>();

            string[] parts = source.Split(delimiter);

            if (!trimValues) 
                return parts;

            return parts.Select(a => a.Trim()).Where(s => s != string.Empty);
        }

        /// <summary>
        /// Returns the string as a Uri.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>New Uri instance if the string is a Uri; otherwise null.</returns>
        public static Uri ToUri(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return null;

            try
            {
                return new Uri(source);
            }
            catch (UriFormatException)
            {
                return null;
            }
        }

        /// <summary>
        /// Returns the string as a Guid.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>New Guid instance if the string is a Guid; otherwise default.</returns>
        public static Guid ToGuid(this string source)
        {
            if (source == null)
                return default;

            try
            {
                return new Guid(source);
            }
            catch (FormatException)
            {
                return default;
            }
        }
    }
}