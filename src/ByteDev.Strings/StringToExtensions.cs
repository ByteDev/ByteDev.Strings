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
        /// Returns this string as a sequence of lines.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <param name="ignoreEmptyLines">If true empty and whitespace only lines will not be returned.</param>
        /// <returns>The string as a sequence of lines.</returns>
        public static IEnumerable<string> ToLines(this string source, bool ignoreEmptyLines = false)
        {
            if (source == null)
                source = string.Empty;
            
            using (var reader = new StringReader(source))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (ignoreEmptyLines && string.IsNullOrWhiteSpace(line))
                        continue;

                    yield return line;
                }
            }
        }

        /// <summary>
        /// Returns this string as a list of lines.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <param name="ignoreEmptyLines">If true empty and whitespace only lines will not be returned.</param>
        /// <returns>The string as a list of lines.</returns>
        public static IList<string> ToLinesList(this string source, bool ignoreEmptyLines = false)
        {
            if (string.IsNullOrEmpty(source))
                return new List<string>();

            var lines = new List<string>();

            using (var reader = new StringReader(source))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (ignoreEmptyLines && string.IsNullOrWhiteSpace(line))
                        continue;

                    lines.Add(line);
                }
            }

            return lines;
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
        /// Returns string as an Int32.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>The string as a Int32 if valid; otherwise zero.</returns>
        public static int ToInt32(this string source)
        {
            return int.TryParse(source, out var result) ? result : 0;
        }

        /// <summary>
        /// Returns this string as a nullable Int32.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <param name="defaultValue">Default value to return if unable to convert to nullable int.</param>
        /// <returns>The string as a nullable Int32 if valid; otherwise default value.</returns>
        public static int? ToInt32OrDefault(this string source, int? defaultValue = null)
        {
            return int.TryParse(source, out var result) ? result : defaultValue;
        }

        /// <summary>
        /// Returns string as a Int64.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>The string as a Int64 if valid; otherwise zero.</returns>
        public static long ToInt64(this string source)
        {
            return long.TryParse(source, out var result) ? result : 0;
        }

        /// <summary>
        /// Returns string as a nullable Int64.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <param name="defaultValue">Default value to return if unable to convert to nullable long.</param>
        /// <returns>The string as a nullable long if valid; otherwise default value.</returns>
        public static long? ToInt64OrDefault(this string source, long? defaultValue = null)
        {
            return long.TryParse(source, out var result) ? result : defaultValue;
        }

        /// <summary>
        /// Returns the string as a sequence with each value determined by the specified char delimiter.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <param name="delimiter">Value delimiter.</param>
        /// <param name="trimValues">True trim each value; false do nothing.</param>
        /// <returns>Collection of values; otherwise empty.</returns>
        public static IEnumerable<string> ToSequence(this string source, char delimiter, bool trimValues = false)
        {
            if (string.IsNullOrEmpty(source))
                return Enumerable.Empty<string>();

            string[] parts = source.Split(delimiter);

            if (!trimValues) 
                return parts;

            return parts.Select(a => a.Trim()).Where(s => s != string.Empty);
        }

        /// <summary>
        /// Returns the string as a sequence with each value determined by the specified string delimiter.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <param name="delimiter">Value delimiter.</param>
        /// <param name="trimValues">True trim each value; false do nothing.</param>
        /// <returns>Collection of values; otherwise empty.</returns>
        public static IEnumerable<string> ToSequence(this string source, string delimiter, bool trimValues = false)
        {
            return ToSequence(source, new[] {delimiter}, trimValues);
        }

        /// <summary>
        /// Returns the string as a sequence with each value determined by the specified array of string delimiters.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <param name="delimiters">Value delimiter.</param>
        /// <param name="trimValues">True trim each value; false do nothing.</param>
        /// <returns>Collection of values; otherwise empty.</returns>
        public static IEnumerable<string> ToSequence(this string source, string[] delimiters, bool trimValues = false)
        {
            if (string.IsNullOrEmpty(source))
                return Enumerable.Empty<string>();

            string[] parts = source.Split(delimiters, StringSplitOptions.None);

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

        /// <summary>
        /// Returns the string as a KeyValuePair.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <param name="delimiter">String delimiter for the key value pair.</param>
        /// <returns>New KeyValuePair instance.</returns>
        public static KeyValuePair<string, string> ToKeyValuePair(this string source, string delimiter)
        {
            if (source == null)
                return default;

            if (string.IsNullOrEmpty(delimiter))
                return new KeyValuePair<string, string>(source, string.Empty);

            int index = source.IndexOf(delimiter, StringComparison.Ordinal);

            if (index < 0)
                return new KeyValuePair<string, string>(source, string.Empty);

            var key = source.Substring(0, index);
            var value = source.Substring(index + delimiter.Length);

            return new KeyValuePair<string, string>(key, value);
        }
        
        /// <summary>
        /// Returns the string as a MemoryStream using UTF-8 encoding.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>New MemoryStream instance.</returns>
        public static MemoryStream ToMemoryStream(this string source)
        {
            return ToMemoryStream(source, Encoding.UTF8);
        }

        /// <summary>
        /// Returns the string as a MemoryStream.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <param name="encoding">Encoding to use.</param>
        /// <returns>New MemoryStream instance.</returns>
        public static MemoryStream ToMemoryStream(this string source, Encoding encoding)
        {
            byte[] bytes = encoding.GetBytes(source ?? string.Empty);

            return new MemoryStream(bytes);
        }
    }
}