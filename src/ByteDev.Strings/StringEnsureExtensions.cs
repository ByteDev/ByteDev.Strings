namespace ByteDev.Strings
{
    /// <summary>
    /// Extension methods for <see cref="T:System.String" />.
    /// </summary>
    public static class StringEnsureExtensions
    {
        /// <summary>
        /// Returns a string with a prefix appended if the prefix does not already exist.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="prefix">Prefix to check for and add if not present.</param>
        /// <returns>String with the prefix.</returns>
        public static string EnsureStartsWith(this string source, string prefix)
        {
            if (string.IsNullOrEmpty(prefix))
                return source;

            if (source == null)
                return prefix;

            if (source.StartsWith(prefix))
                return source;
            
            return prefix + source;
        }

        /// <summary>
        /// Returns a string with a suffix appended if the suffix does not already exist.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="suffix">Suffix to check for and add if not present.</param>
        /// <returns>String with the suffix.</returns>
        public static string EnsureEndsWith(this string source, string suffix)
        {
            if (string.IsNullOrEmpty(suffix))
                return source;

            if (source == null)
                return suffix;

            if (source.EndsWith(suffix))
                return source;
            
            return source + suffix;
        }
    }
}