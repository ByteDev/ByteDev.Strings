using System.Collections.Generic;
using System.Text;

namespace ByteDev.Strings
{
    internal static class ToStringBuilderStringBuilderExtensions
    {
        internal static StringBuilder AppendName(this StringBuilder source, string name)
        {
            if (source.Length > 0)
                source.Append(", ");

            source.Append(name);
            source.Append(": ");

            return source;
        }

        internal static StringBuilder AppendCollection(this StringBuilder source, IEnumerable<object> collection, char stringQuoteChar)
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

        internal static StringBuilder AppendValue(this StringBuilder source, object value, char stringQuoteChar)
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