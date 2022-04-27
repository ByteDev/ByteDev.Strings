using System;
using System.Collections.Generic;
using System.Text;

namespace ByteDev.Strings
{
    /// <summary>
    /// Extension methods for <see cref="T:System.Text.StringBuilder" />.
    /// </summary>
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// Determines if instance evaluates to an empty string.
        /// </summary>
        /// <param name="source">StringBuilder to perform the operation on.</param>
        /// <returns>True if empty; otherwise false.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static bool IsEmpty(this StringBuilder source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Length == 0;
        }

        /// <summary>
        /// Appends a copy of each given string.
        /// </summary>
        /// <param name="source">StringBuilder to perform the operation on.</param>
        /// <param name="values">String values to append.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static void AppendValues(this StringBuilder source, params string[] values)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            foreach (var value in values)
            {
                source.Append(value);
            }
        }

        /// <summary>
        /// Appends a copy of each given string.
        /// </summary>
        /// <param name="source">StringBuilder to perform the operation on.</param>
        /// <param name="values">String values to append.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static void AppendValues(this StringBuilder source, IEnumerable<string> values)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (values == null)
                return;

            foreach (var value in values)
            {
                source.Append(value);
            }
        }

        /// <summary>
        /// Appends a copy of each given string followed by the default line terminator.
        /// </summary>
        /// <param name="source">StringBuilder to perform the operation on.</param>
        /// <param name="values">String values to append as lines.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static void AppendLines(this StringBuilder source, params string[] values)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            foreach (var value in values)
            {
                source.AppendLine(value);
            }
        }

        /// <summary>
        /// Appends a copy of each given string followed by the default line terminator.
        /// </summary>
        /// <param name="source">StringBuilder to perform the operation on.</param>
        /// <param name="values">String values to append as lines.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static void AppendLines(this StringBuilder source, IEnumerable<string> values)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (values == null)
                return;

            foreach (var value in values)
            {
                source.AppendLine(value);
            }
        }

        /// <summary>
        /// Appends a copy of the string to this instance if the instance
        /// is currently empty.
        /// </summary>
        /// <param name="source">StringBuilder to perform the operation on.</param>
        /// <param name="value">Value to append.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static void AppendIfEmpty(this StringBuilder source, string value)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (source.Length == 0)
                source.Append(value);
        }

        /// <summary>
        /// Appends a copy of the string to this instance if the instance is
        /// currently not empty.
        /// </summary>
        /// <param name="source">StringBuilder to perform the operation on.</param>
        /// <param name="value">Value to append.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static void AppendIfNotEmpty(this StringBuilder source, string value)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (source.Length > 0)
                source.Append(value);
        }
    }
}