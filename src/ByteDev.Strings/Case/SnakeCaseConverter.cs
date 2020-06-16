namespace ByteDev.Strings.Case
{
    internal static class SnakeCaseConverter
    {
        public static string ToPascalCase(string value)
        {
            var parts = value.Split('_');
            string s = string.Empty;

            foreach (var part in parts)
            {
                s += part.ToTitleCase();
            }

            return s;
        }

        public static string ToCamelCase(string value)
        {
            var parts = value.Split('_');
            string s = string.Empty;

            for (var i=0; i < parts.Length; i++)
            {
                if (i == 0)
                {
                    s += parts[i].ToLower();
                }
                else
                {
                    s += parts[i].ToTitleCase();
                }
            }

            return s;
        }
    }
}