namespace ByteDev.Strings.Masking
{
    /// <summary>
    /// Represents options for the type <see cref="T:ByteDev.Strings.Masking.Masker" />.
    /// </summary>
    public class MaskerOptions
    {
        /// <summary>
        /// Mask character.
        /// </summary>
        public char MaskChar { get; set; } = '*';

        /// <summary>
        /// Indicates if any spaces should be masked.
        /// </summary>
        public bool MaskSpace { get; set; } = true;
    }
}