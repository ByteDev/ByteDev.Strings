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
        /// Masks an email address. Exposes the first letter of the email address and the
        /// constant suffix (e.g. ".com").
        /// </summary>
        /// <param name="value">Email address.</param>
        /// <returns>Masked email address.</returns>
        public string EmailAddress(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            var sb = new StringBuilder(value.Length);
            var inHost = false;
            var maskOff = false;

            for (var pos = 0; pos < value.Length; pos++)
            {
                if (pos == 0 || maskOff)
                {
                    sb.Append(value[pos]);
                }
                else if (value[pos] == '@')
                {
                    sb.Append(value[pos]);
                    inHost = true;
                }
                else
                {
                    if (inHost)
                    {
                        if (value[pos] == '.')
                        {
                            sb.Append(value[pos]);
                            maskOff = true;
                        }
                        else
                        {
                            sb.Append(Options.MaskChar);
                        }
                    }
                    else
                    {
                        sb.Append(Options.MaskChar);
                    }
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