namespace ByteDev.Strings
{
    internal static class CharExtensions
    {
        public static bool IsUpperCase(this char source)
        {
            return char.IsUpper(source);
        }

        public static bool IsSpace(this char source)
        {
            return source == ' ';
        }
    }
}