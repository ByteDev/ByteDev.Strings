using System.Text;

namespace ByteDev.Strings.Case
{
    internal static class PascalCaseConverter
    {
        public static string ToKebabCase(string value)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < value.Length; i++)
            {
                var ch = value[i];

                if (i == 0)
                {
                    sb.Append(char.ToLower(ch));
                    continue;
                }

                if (ch.IsUpperCase())
                {
                    sb.Append("-");
                    sb.Append(char.ToLower(ch));
                }
                else
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString();
        }

        public static string ToSnakeCase(string value)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < value.Length; i++)
            {
                var ch = value[i];

                if (i == 0)
                {
                    sb.Append(char.ToLower(ch));
                    continue;
                }

                if (ch.IsUpperCase())
                {
                    sb.Append("_");
                    sb.Append(char.ToLower(ch));
                }
                else
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString();
        }

        public static string ToSnakeUpperCase(string value)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < value.Length; i++)
            {
                var ch = value[i];

                if (i == 0)
                {
                    sb.Append(ch);
                    continue;
                }

                if (ch.IsUpperCase())
                {
                    sb.Append("_");
                    sb.Append(ch);
                }
                else
                {
                    sb.Append(char.ToUpper(ch));
                }
            }

            return sb.ToString();
        }

        public static string ToCamelCase(string value)
        {
            var ch = value.Substring(0, 1).ToLower();
            return ch + value.Substring(1);
        }
    }
}