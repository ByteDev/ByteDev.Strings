using System.Text;

namespace ByteDev.Strings.Case
{
    internal static class CamelCaseConverter
    {
        public static string ToKebabCase(string value)
        {
            var sb = new StringBuilder();

            foreach (char ch in value)
            {
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

            foreach (char ch in value)
            {
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

            foreach (char ch in value)
            {
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

        public static string ToPascalCase(string value)
        {
            var ch = value.Substring(0, 1).ToUpper();
            return ch + value.Substring(1);
        }
    }
}