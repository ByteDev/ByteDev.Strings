namespace ByteDev.Strings
{
    /// <summary>
    /// Represents the possible new line situations a string can have.
    /// </summary>
    public enum NewLineType
    {
        /// <summary>
        /// No new lines.
        /// </summary>
        None = 0,

        /// <summary>
        /// Mix of different types of new lines.
        /// </summary>
        Mix = 1,

        /// <summary>
        /// Only Windows new lines.
        /// </summary>
        Windows = 2,

        /// <summary>
        /// Only Unix new lines.
        /// </summary>
        Unix = 3
    }
}