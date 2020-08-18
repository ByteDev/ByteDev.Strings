namespace ByteDev.Strings
{
    internal static class CharExtensions
    {
        public static bool IsUpperCase(this char source)
        {
            return source >= 'A' && source <= 'Z';
        }

        public static bool IsSpace(this char source)
        {
            return source == ' ';
        }
    }
}