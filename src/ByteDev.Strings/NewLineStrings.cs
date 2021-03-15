namespace ByteDev.Strings
{
    /// <summary>
    /// Represents the different new line strings.
    /// </summary>
    public static class NewLineStrings
    {
        /// <summary>
        /// Windows.
        /// </summary>
        public const string Windows = "\r\n";

        /// <summary>
        /// Unix platforms.
        /// </summary>
        public const string Unix = "\n";

        /// <summary>
        /// Mac OS (pre-OS X). For Mac OS X and later use Unix.
        /// </summary>
        public const string MacOld = "\r";
    }
}