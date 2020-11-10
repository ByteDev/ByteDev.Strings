using System;
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
        /// <param name="source">String to perform the operation on.</param>
        /// <returns>True if empty; otherwise returns false.</returns>
        public static bool IsEmpty(this string source)
        {
            return source == string.Empty;
        }

        /// <summary>
        /// Indicates whether this string is null or empty.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <returns>True if null or empty; otherwise returns false.</returns>
        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        /// <summary>
        /// Indicates whether this string is null or contains only white space characters.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <returns>True if null or only contains white space characters; otherwise returns false.</returns>
        public static bool IsNullOrWhitespace(this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }

        /// <summary>
        /// Indicates whether this string is (probably) an email address.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
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
        /// <param name="source">String to perform the operation on.</param>
        /// <returns>True if is a URL; otherwise returns false.</returns>
        public static bool IsHttpUrl(this string source)
        {
            if (source == null)
                return false;

            return new Regex(@"^http(s)?://([\w-\.]+)+([:0-9]*)(/[\w-\./?%&=#]*)?$").IsMatch(source);
        }

        /// <summary>
        /// Indicates whether this string is an IP address (v4).
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
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
        /// <param name="source">String to perform the operation on.</param>
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
        /// <param name="source">String to perform the operation on.</param>
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
        /// Indicates whether this string is only digits.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
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
        /// <param name="source">String to perform the operation on.</param>
        /// <returns>True if is a single digit only; otherwise returns false.</returns>
        public static bool IsDigit(this string source)
        {
            if (source == null)
                return false;

            var array = source.ToCharArray();

            return array.Length == 1 && char.IsDigit(array[0]);
        }

        /// <summary>
        /// Indicates whether this string is numeric (contains only digits,
        /// an optional single period character, and optional hyphen prefix).
        /// Starting with period character returns false.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <returns>True if is numeric; otherwise return false.</returns>
        public static bool IsNumeric(this string source)
        {
            if (string.IsNullOrEmpty(source) || source.StartsWith("."))
                return false;

            var hasPeriod = false;
            var isFirstChar = true;

            foreach (char c in source)
            {
                if (isFirstChar)
                {
                    isFirstChar = false;

                    if (c == '-')
                        continue;
                }
                
                if (c == '.')
                {
                    if (hasPeriod)
                        return false;

                    hasPeriod = true;
                }
                else if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Indicates whether string is only letters (A-Z and a-z).
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <returns>True if is letters only; otherwise returns false.</returns>
        public static bool IsLetters(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return false;

            return source.All(char.IsLetter);
        }

        /// <summary>
        /// Indicates whether string looks like it is a true value
        /// (case insensitive "true" or "on" or "1").
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <returns>True if it appears the string is true; otherwise returns false.</returns>
        public static bool IsTrue(this string source)
        {
            if (source == null)
                return false;

            if (source.Equals("true", StringComparison.OrdinalIgnoreCase))
                return true;

            if (source.Equals("on", StringComparison.OrdinalIgnoreCase))
                return true;

            return source == "1";
        }

        /// <summary>
        /// Indicates whether string looks like it is a false value
        /// (case insensitive "false" or "off" or "0").
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <returns>True if it appears the string is false; otherwise returns false.</returns>
        public static bool IsFalse(this string source)
        {
            if (source == null)
                return false;

            if (source.Equals("false", StringComparison.OrdinalIgnoreCase))
                return true;

            if (source.Equals("off", StringComparison.OrdinalIgnoreCase))
                return true;

            return source == "0";
        }

        /// <summary>
        /// Indicates whether string's length is between a range (min and max values
        /// are both inclusive).
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <param name="min">Minimum allowable length.</param>
        /// <param name="max">Maximum allowable length.</param>
        /// <returns>True if the string length is between the range; otherwise returns false.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="min" /> should be equal to or less than <paramref name="max" />.</exception>
        public static bool IsLengthBetween(this string source, int min, int max)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (max < 0)
                max = 0;

            if (min > max)
                throw new ArgumentOutOfRangeException(nameof(min), "Min should be equal to or less than max.");

            return source.Length >= min && source.Length <= max;
        }

        /// <summary>
        /// Indicates whether string contains only one or more lower
        /// case characters (a-z). Null and empty strings will return false.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <returns>True if string is only lower case characters; otherwise returns false.</returns>
        public static bool IsLowerCase(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return false;

            return source.All(char.IsLower);
        }

        /// <summary>
        /// Indicates whether string contains only one or more upper
        /// case characters (A-Z).Null and empty strings will return false.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>True if string is only upper case characters; otherwise returns false.</returns>
        public static bool IsUpperCase(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return false;

            return source.All(char.IsUpper);
        }

        /// <summary>
        /// Indicates whether string appears to be a time in any of the formats:
        /// hh:mm:ss, hh-mm-ss, hhmmss, hh:mm, hh-mm or hhmm.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <returns>True if the string is a time; otherwise returns false.</returns>
        public static bool IsTime(this string source)
        {
            if (source == null)
                return false;

            if (source.Length == 8)
            {
                if (Regex.IsMatch(source, "^[0-2][0-3]:[0-5][0-9]:[0-5][0-9]$"))
                    return true;

                if (Regex.IsMatch(source, "^[0-2][0-3]-[0-5][0-9]-[0-5][0-9]$"))
                    return true;
            }
            else if (source.Length == 6)
            {
                return Regex.IsMatch(source, "^[0-2][0-3][0-5][0-9][0-5][0-9]$");
            }
            else if (source.Length == 5)
            {
                if (Regex.IsMatch(source, "^[0-2][0-3]:[0-5][0-9]$"))
                    return true;

                if (Regex.IsMatch(source, "^[0-2][0-3]-[0-5][0-9]$"))
                    return true;
            }
            else if (source.Length == 4)
            {
                return Regex.IsMatch(source, "^[0-2][0-3][0-5][0-9]$");
            }

            return false;
        }

        /// <summary>
        /// Indicates whether string appears to be a phone number or not.
        /// Allows characters 0-9, space, hyphen, and a plus character prefix.
        /// </summary>
        /// <param name="source">String to perform the operation on.</param>
        /// <returns>True if the string appears to be a phone number; otherwise false.</returns>
        public static bool IsPhoneNumber(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return false;

            return new Regex(@"^\+*[0-9][0-9- ]+$").IsMatch(source);
        }
    }
}