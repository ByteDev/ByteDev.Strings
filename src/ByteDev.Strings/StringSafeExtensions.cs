namespace ByteDev.Strings
{
    /// <summary>
    /// Extension methods for <see cref="T:System.String" />.
    /// </summary>
    public static class StringSafeExtensions
    {
        /// <summary>
        /// Returns the length of a string or zero if it is null.
        /// </summary>
        /// <param name="source">The string to return the length on.</param>
        /// <returns>Length of the string. Zero if the string is null.</returns>
        public static int SafeLength(this string source)
        {
            return source?.Length ?? 0;
        }

        /// <summary>
        /// Safely retrieves a substring from this instance. No exceptions will be thrown.
        /// </summary>
        /// <param name="source">The string to perform the operation on.</param>
        /// <param name="startIndex">The zero-based starting character position of a substring in this instance.</param>
        /// <param name="length">The number of characters in the substring.</param>
        /// <returns>A string that is equivalent to the substring of length <paramref name="length" /> that begins at <paramref name="startIndex" />.</returns>
        public static string SafeSubstring(this string source, int startIndex, int length)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;

            if (length < 1)
                return string.Empty;

            if (source.Length <= startIndex) 
                return string.Empty;

            if (source.Length - startIndex <= length) 
                return source.Substring(startIndex);

            return source.Substring(startIndex, length);
        }
    }
}