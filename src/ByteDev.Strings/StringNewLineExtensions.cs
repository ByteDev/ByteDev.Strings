namespace ByteDev.Strings
{
    /// <summary>
    /// Extension methods for <see cref="T:System.String" />.
    /// </summary>
    public static class StringNewLineExtensions
    {
        /// <summary>
        /// Retrieves any end line characters from the end of the string.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <returns>Any end of line characters from the end of the string; otherwise returns empty.</returns>
        public static string GetEndNewLine(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;

            if (source.EndsWith(NewLineStrings.Windows))
                return NewLineStrings.Windows;

            if (source.EndsWith(NewLineStrings.Unix))
                return NewLineStrings.Unix;

            return string.Empty;
        }

        /// <summary>
        /// Removes any end line characters from the end of the string. Any end line
        /// characters inside the string will not be affected.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <returns>String with any end return characters removed.</returns>
        public static string RemoveEndNewLine(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return source;

            if (source.EndsWith(NewLineStrings.Windows))
                return source.Substring(0, source.Length - NewLineStrings.Windows.Length);
            
            if (source.EndsWith(NewLineStrings.Unix))
                return source.Substring(0, source.Length - NewLineStrings.Unix.Length);

            return source;
        }

        /// <summary>
        /// Determine what if any new line types are used within the string.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <returns>End line type used in the string.</returns>
        public static NewLineType DetectNewLineType(this string source)
        {
            bool containsWindows = source.ContainsWindowsEndLine();

            if (source.ContainsUnixEndLine())
                return containsWindows ? NewLineType.Mix : NewLineType.Unix;

            if (containsWindows)
                return NewLineType.Windows;

            return NewLineType.None;
        }

        /// <summary>
        /// Normalize all new line strings to Unix platform style.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <returns>String with new lines normalized to Unix style.</returns>
        public static string NormalizeNewLinesToUnix(this string source)
        {
            return source?
                .Replace("\r\n", "\r")
                .Replace("\n\r", "\r")
                .Replace("\r", NewLineStrings.Unix);
        }

        /// <summary>
        /// Normalize all new line strings to Windows (non-Unix) platform style.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <returns>String with new lines normalized to Windows style.</returns>
        public static string NormalizeNewLinesToWindows(this string source)
        {
            return source?
                .Replace("\r\n", "\n")
                .Replace("\n\r", "\n")
                .Replace("\r", "\n")
                .Replace("\n", NewLineStrings.Windows);
        }

        internal static bool ContainsUnixEndLine(this string source)
        {
            if (source == null)
                return false;

            for (var i = 0; i < source.Length; i++)
            {
                var ch = source[i];

                if (ch == '\n')
                {
                    if (i == 0 || source[i - 1] != '\r') // Not Windows (\r\n)
                        return true;
                }
            }

            return false;
        }
        
        internal static bool ContainsWindowsEndLine(this string source)
        {
            if (source == null)
                return false;

            return source.Contains(NewLineStrings.Windows);
        }
    }
}