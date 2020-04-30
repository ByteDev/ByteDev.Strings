using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ByteDev.Strings
{
    /// <summary>
    /// Functionality to help return strings when overriding the ToString method.
    /// </summary>
    public class ToStringHelper
    {
        private readonly string _nullValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Strings.ToStringHelper" /> class.
        /// </summary>
        public ToStringHelper() : this(string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Strings.ToStringHelper" /> class.
        /// </summary>
        /// <param name="nullValue">Value to use when any param value is null.</param>
        public ToStringHelper(string nullValue)
        {
            _nullValue = nullValue;
        }
        
        /// <summary>
        /// Returns a string representation of <paramref name="value" />.
        /// </summary>
        /// <param name="name">Name of <paramref name="value" />.</param>
        /// <param name="value">The object value.</param>
        /// <returns>A string representation.</returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="name" /> is null or empty.</exception>
        public string ToString(string name, object value)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name is null or empty.", nameof(name));
            }

            return value == null ? FormatNull(name) : Format(name, value.ToString());
        }

        /// <summary>
        /// Returns a string representation of <paramref name="value" />.
        /// </summary>
        /// <param name="name">Name of <paramref name="value" />.</param>
        /// <param name="value">The object value.</param>
        /// <returns>A string representation.</returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="name" /> is null or empty.</exception>
        public string ToString(string name, string value)
        {
            return ToString(name, value as object);
        }

        /// <summary>
        /// Returns a string representation of a collection of values.
        /// </summary>
        /// <typeparam name="T">Collection type.</typeparam>
        /// <param name="name">Name of <paramref name="values" />.</param>
        /// <param name="values">The object values.</param>
        /// <returns>A string representation.</returns>
        public string ToString<T>(string name, IEnumerable<T> values)
        {
            if (values == null)
                return ToString(name, null);

            var s = new StringBuilder("{ ");

            if (values.Any())
            {
                s.Append(values.First());

                foreach (var id in values.Skip(1))
                {
                    s.Append($", {id}");
                }

                s.Append(" }");
            }
            else
            {
                s.Append("}");
            }

            return Format(name, s.ToString());
        }

        private static string Format(string name, string value)
        {
            return $"{name}: {value}";
        }

        private string FormatNull(string name)
        {
            return Format(name, _nullValue);
        }
    }
}