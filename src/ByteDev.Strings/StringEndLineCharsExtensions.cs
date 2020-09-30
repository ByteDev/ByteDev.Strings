namespace ByteDev.Strings
{
    /// <summary>
    /// Extension methods for <see cref="T:System.String" />.
    /// </summary>
    public static class StringEndLineCharsExtensions
    {
        private const string WindowsEndLine = "\r\n";
        private const string UnixEndLine = "\n";

        /// <summary>
        /// Retrieves any end line characters from the end of the string.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <returns>Any end of line characters from the end of the string; otherwise returns empty.</returns>
        public static string GetEndLineChars(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;

            if (source.EndsWith(WindowsEndLine))
                return WindowsEndLine;

            if (source.EndsWith(UnixEndLine))
                return UnixEndLine;

            return string.Empty;
        }

        /// <summary>
        /// Removes any end lines characters from the end of the string. Any end line
        /// characters inside the string will not be affected.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <returns></returns>
        public static string RemoveEndLineChars(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return source;

            if (source.EndsWith(WindowsEndLine))
                return source.Substring(0, source.Length - WindowsEndLine.Length);
            
            if (source.EndsWith(UnixEndLine))
                return source.Substring(0, source.Length - UnixEndLine.Length);

            return source;
        }
    }
}