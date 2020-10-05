using System.Text;

namespace ByteDev.Strings.Masking
{
    /// <summary>
    /// Represents a type to mask strings in different ways.
    /// </summary>
    public class Masker
    {
        private MaskerOptions Options { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Strings.Masking.Masker" /> class.
        /// </summary>
        public Masker() : this(new MaskerOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Strings.Masking.Masker" /> class.
        /// </summary>
        /// <param name="options">Options to use when performing masking operations.</param>
        public Masker(MaskerOptions options)
        {
            Options = options ?? new MaskerOptions();
        }

        /// <summary>
        /// Masks a payment card number. Exposes only the last 4 numbers.
        /// </summary>
        /// <param name="value">Payment card number.</param>
        /// <returns>Masked payment card number.</returns>
        public string PaymentCard(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            value = value.Trim();

            return Custom(value, 0, 4);
        }

        /// <summary>
        /// Masks an email address.
        /// </summary>
        /// <param name="value">Email address to mask.</param>
        /// <param name="exposeNameChars">Number of characters to expose in the name segment.</param>
        /// <param name="maskDomainName">True: mask the domain name segment (the TLD will never be masked).</param>
        /// <returns>Masked email address.</returns>
        public string EmailAddress(string value, int exposeNameChars = 1, bool maskDomainName = true)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            if (exposeNameChars < 1)
                exposeNameChars = 1;

            var sb = new StringBuilder(value.Length);
            var inHost = false;
            var posLastDot = value.LastIndexOf('.');    // TLD

            for (var pos = 0; pos < value.Length; pos++)
            {
                if (value[pos] == '@')
                {
                    sb.Append(value[pos]);
                    inHost = true;
                }
                else if (inHost)
                {
                    if (pos >= posLastDot && posLastDot != -1)
                    {
                        sb.Append(value[pos]);
                    }
                    else
                    {
                        sb.Append(maskDomainName ? Options.MaskChar : value[pos]);
                    }
                }
                else
                {
                    // Name
                    sb.Append(pos < exposeNameChars ? value[pos] : Options.MaskChar);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Masks a string value. Exposes a certain number of beginning and
        /// end characters.
        /// </summary>
        /// <param name="value">String to mask.</param>
        /// <param name="beginCharsToExpose">Number of chars to expose at the beginning.</param>
        /// <param name="endCharsToExpose">Number of chars to expose at the end.</param>
        /// <returns>Masked string value.</returns>
        public string Custom(string value, int beginCharsToExpose, int endCharsToExpose)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            var sb = new StringBuilder(value.Length);

            for (var pos = 0; pos < value.Length; pos++)
            {
                if (IsCharSkippable(value[pos]))
                    sb.Append(value[pos]);
                else
                    sb.Append(pos < beginCharsToExpose || value.Length - pos <= endCharsToExpose ? value[pos] : Options.MaskChar);
            }

            return sb.ToString();
        }
        
        private bool IsCharSkippable(char ch)
        {
            return !Options.MaskSpace && ch.IsSpace();
        }
    }
}