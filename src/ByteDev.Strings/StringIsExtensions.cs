using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Schema;

namespace ByteDev.Strings
{
    /// <summary>
    /// Extension methods for <see cref="T:System.String" />.
    /// </summary>
    public static class StringIsExtensions
    {
        /// <summary>
        /// Indicates whether this string is empty.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>True if empty; otherwise returns false.</returns>
        public static bool IsEmpty(this string source)
        {
            if (source == null)
                return false;

            return source == string.Empty;
        }

        /// <summary>
        /// Indicates whether this string is null or empty.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>True if null or empty; otherwise returns false.</returns>
        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        /// <summary>
        /// Indicates whether this string is null or contains only white space characters.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>True if null or only contains white space characters; otherwise returns false.</returns>
        public static bool IsNullOrWhitespace(this string source)
        {
            return string.IsNullOrEmpty(source) || string.IsNullOrEmpty(source.Trim());
        }

        /// <summary>
        /// Indicates whether this string is not null or empty.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>True if not null or empty; otherwise returns false.</returns>
        public static bool IsNotNullOrEmpty(this string source)
        {
            return !string.IsNullOrEmpty(source);
        }

        /// <summary>
        /// Indicates whether this string is (probably) an email address.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>True if is probably an email address; otherwise returns false.</returns>
        public static bool IsEmailAddress(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return false;

            return new Regex(@"^\S+@\S+$").IsMatch(source);
        }

        /// <summary>
        /// Indicates whether this string is a URL (HTTP URI).
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>True if is a URL; otherwise returns false.</returns>
        public static bool IsHttpUrl(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return false;
            
            return new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?").IsMatch(source);
        }

        /// <summary>
        /// Indicates whether this string is an IP address (v4).
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>True if is an IP address; otherwise returns false.</returns>
        public static bool IsIpAddress(this string source)
        {
            if (source == null)
                return false;
            
            const string pattern = @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";

            return Regex.IsMatch(source, pattern);
        }

        /// <summary>
        /// Indicates whether this string is a GUID.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>True if is a GUID; otherwise returns false.</returns>
        public static bool IsGuid(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return false;

            const string pattern = "^[A-Fa-f0-9]{32}$|" +
                                   "^({|\\()?[A-Fa-f0-9]{8}-([A-Fa-f0-9]{4}-){3}[A-Fa-f0-9]{12}(}|\\))?$|" +
                                   "^({)?[0xA-Fa-f0-9]{3,10}(, {0,1}[0xA-Fa-f0-9]{3,6}){2}, {0,1}({)([0xA-Fa-f0-9]{3,4}, {0,1}){7}[0xA-Fa-f0-9]{3,4}(}})$";

            return Regex.IsMatch(source, pattern);
        }

        /// <summary>
        /// Indicates whether this string is XML.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>True if is XML; otherwise returns false.</returns>
        public static bool IsXml(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return false;

            var settings = new XmlReaderSettings
            {
                CheckCharacters = true,
                ConformanceLevel = ConformanceLevel.Document,
                DtdProcessing = DtdProcessing.Ignore,
                IgnoreComments = true,
                IgnoreProcessingInstructions = true,
                IgnoreWhitespace = true,
                ValidationFlags = XmlSchemaValidationFlags.None,
                ValidationType = ValidationType.None,
            };

            using (var reader = XmlReader.Create(new StringReader(source), settings))
            {
                try
                {
                    while (reader.Read()) { }
                    return true;
                }
                catch (XmlException)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Indicates whether this string is hexadecimal.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>True if is hexadecimal; otherwise returns false.</returns>
        public static bool IsHex(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return false;

            foreach(char c in source)
            {
                var isHex = c >= '0' && c <= '9' ||
                            c >= 'a' && c <= 'f' ||
                            c >= 'A' && c <= 'F';

                if(!isHex)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Indicates whether this string is only digits.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>True if is digits only; otherwise returns false.</returns>
        public static bool IsDigits(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return false;

            foreach (char c in source)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Indicates whether this string is a single digit.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>True if is a single digit only; otherwise returns false.</returns>
        public static bool IsDigit(this string source)
        {
            if (source == null)
                return false;

            var array = source.ToCharArray();

            return array.Length == 1 && char.IsDigit(array[0]);
        }

        /// <summary>
        /// Indicates whether this string is numeric (contains only digits and
        /// an optional single period character). Starting with period character
        /// returns false.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>True if is numeric; otherwise return false.</returns>
        public static bool IsNumeric(this string source)
        {
            if (string.IsNullOrEmpty(source) || source.StartsWith("."))
                return false;

            var hasPeriod = false;

            foreach (char c in source)
            {
                if (c == '.')
                {
                    if (hasPeriod)
                        return false;

                    hasPeriod = true;
                }
                else
                {
                    if (!char.IsDigit(c))
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Indicates whether string is only letters (A-Z and a-z).
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>True if is letters only; otherwise returns false.</returns>
        public static bool IsLetters(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return false;

            return source.All(char.IsLetter);
        }
    }
}