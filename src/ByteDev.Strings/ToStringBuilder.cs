using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ByteDev.Strings
{
    /// <summary>
    /// Represents a builder to help return strings when overriding the ToString method.
    /// </summary>
    public class ToStringBuilder
    {
        private string _nullValue = "";
        private char _stringQuoteChar = '\0';

        private readonly IDictionary<string, object> _nameValuePairs;
        
        public ToStringBuilder()
        {
            _nameValuePairs = new Dictionary<string, object>();
        }

        public ToStringBuilder WithNullValue(string nullValue)
        {
            _nullValue = nullValue;
            return this;
        }

        public ToStringBuilder WithStringQuoteChar(char stringQuoteChar)
        {
            _stringQuoteChar = stringQuoteChar;
            return this;
        }

        public ToStringBuilder With(string name, object value)
        {
            _nameValuePairs.Add(name, value);
            return this;
        }

        public string Build()
        {
            var sb = new StringBuilder();

            foreach (var pair in _nameValuePairs)
            {
                sb.AppendName(pair.Key);

                if (pair.Value == null)
                {
                    sb.Append(_nullValue);
                }
                else if (pair.Value is IEnumerable<object> collection)
                {
                    sb.AppendCollection(collection, _stringQuoteChar);
                }
                else if (pair.Value is string str)
                {
                    sb.AppendValue(str, _stringQuoteChar);
                }
                else
                {
                    sb.Append(pair.Value);
                }
            }

            return sb.ToString();
        }
    }

    internal static class StringBuilderExtensions
    {
        public static StringBuilder AppendName(this StringBuilder source, string name)
        {
            if (source.Length > 0)
                source.Append(", ");

            source.Append(name);
            source.Append(": ");

            return source;
        }

        public static StringBuilder AppendCollection(this StringBuilder source, IEnumerable<object> collection, char stringQuoteChar)
        {
            source.Append("{");

            var isFirst = true;

            foreach (var element in collection)
            {
                if (isFirst)
                {
                    isFirst = false;
                    source.Append(" ");
                }
                else
                {
                    source.Append(", ");
                }

                source.AppendValue(element, stringQuoteChar);
            }
                       
            source.Append(" }");

            return source;
        }

        public static StringBuilder AppendValue(this StringBuilder source, object value, char stringQuoteChar)
        {
            if (stringQuoteChar == '\0' || !(value is string))
            {
                source.Append(value);
            }
            else
            {
                source.Append(stringQuoteChar);
                source.Append(value);
                source.Append(stringQuoteChar);
            }

            return source;
        }
    }
}