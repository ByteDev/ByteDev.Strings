using System.Text;

namespace ByteDev.Strings
{
    public class MaskerOptions
    {
        public char MaskChar { get; set; } = '*';

        public bool MaskSpace { get; set; } = true;
    }

    public class Masker
    {
        private MaskerOptions Options { get; }

        public Masker() : this(new MaskerOptions())
        {
        }

        public Masker(MaskerOptions options)
        {
            Options = options ?? new MaskerOptions();
        }

        public string PaymentCard(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            const int endCharsToShow = 4;

            value = value.Trim();
            var sb = new StringBuilder(value.Length);

            for (var pos = 0; pos < value.Length; pos++)
            {
                if (IsCharSkippable(value[pos]))
                    sb.Append(value[pos]);
                else
                    sb.Append(pos >= value.Length - endCharsToShow ? value[pos] : Options.MaskChar);
            }

            return sb.ToString();
        }
        
        private bool IsCharSkippable(char ch)
        {
            return !Options.MaskSpace && ch.IsSpace();
        }
    }
}