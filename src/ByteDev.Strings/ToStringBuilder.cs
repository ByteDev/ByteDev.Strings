using System.Collections.Generic;
using System.Text;

namespace ByteDev.Strings
{
    /// <summary>
    /// Represents a builder to help return strings when overriding the ToString method.
    /// </summary>
    public class ToStringBuilder
    {
        private readonly IDictionary<string, object> _nameValuePairs;

        private string _nullValue = string.Empty;
        private char _stringQuoteChar = '\0';
        
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
}