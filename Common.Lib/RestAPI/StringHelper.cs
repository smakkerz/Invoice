using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LoyaltyPointEngine.Common.Helper
{
    public class StringHelper
    {
        private static List<string> ListLetter = new List<string>(new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" });
        private static List<string> ListNumber = new List<string>(new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" });
        private static List<string> ListSymbol = new List<string>(new[] { "!", "@", "#", "$", "%", "&", "*", "/", "+", @"\" });

        public static string GeneratedPassword()
        {
            string result = "";
            string FirstLetter = GeneratedRandomFromList(ListLetter, 1);
            string NumberCharacter = GeneratedRandomFromList(ListNumber, 2);
            string LastLetter = GeneratedRandomFromList(ListLetter, 3, false);
            return string.Format("{0}{1}{2}",FirstLetter,NumberCharacter,LastLetter);
        }

        public static string GeneratedPassword(int length, int alphaLength, int numericLength, int symbolLength)
        {
            if ((alphaLength + numericLength + symbolLength) != length) throw new Exception("Specified length not equals.");
            StringBuilder sb = new StringBuilder();
            string alphaLetters = GeneratedRandomFromList(ListLetter, alphaLength);
            string numericLetters = GeneratedRandomFromList(ListNumber, numericLength);
            string symbolLetters = GeneratedRandomFromList(ListSymbol, symbolLength);
            string result = string.Format("{0}{1}{2}", alphaLetters, numericLetters, symbolLetters);
            Random rnd = new Random();
            result = string.Join("", result.OrderBy(x => rnd.Next()).ToList());
            return result;
        }

        private static string GeneratedRandomFromList(List<string> listString, int length, bool IsUpperCase = true)
        {
            int myRandomIndex = 0;
            var results = new List<string>();
            var r = new Random(DateTime.Now.Millisecond);
            for (int ii = 0; ii < length; ii++)
            {
                myRandomIndex = r.Next(0, (listString.Count() - 1));
                results.Add(listString[myRandomIndex]);
            }
            return IsUpperCase ? string.Join("", results).ToUpper() : string.Join("", results).ToLower();
        }

        public static bool IsBase64String(string s)
        {
            s = s.Trim();
            int mod4 = s.Length % 4;
            if (mod4 != 0)
            {
                return false;
            }
            int i = 0;
            bool checkPadding = false;
            int paddingCount = 1;//only applies when the first is encountered.
            for (i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (checkPadding)
                {
                    if (c != '=')
                    {
                        return false;
                    }
                    paddingCount++;
                    if (paddingCount > 3)
                    {
                        return false;
                    }
                    continue;
                }
                if (c >= 'A' && c <= 'z' || c >= '0' && c <= '9')
                {
                    continue;
                }
                switch (c)
                {
                    case '+':
                    case '/':
                        continue;
                    case '=':
                        checkPadding = true;
                        continue;
                }
                return false;
            }
            //if here
            //, length was correct
            //, there were no invalid characters
            //, padding was correct
            return true;
        }

        public static string SanitizePath(string path, char replaceChar)
        {
            int filenamePos = path.LastIndexOf(Path.DirectorySeparatorChar) + 1;
            var sb = new System.Text.StringBuilder();
            sb.Append(path.Substring(0, filenamePos));
            for (int i = filenamePos; i < path.Length; i++)
            {
                char filenameChar = path[i];
                foreach (char c in Path.GetInvalidFileNameChars())
                    if (filenameChar.Equals(c))
                    {
                        filenameChar = replaceChar;
                        break;
                    }

                sb.Append(filenameChar);
            }
            string result = sb.ToString();
            string cleanString = System.Text.RegularExpressions.Regex.Replace(result, @"[^a-zA-Z 0-9'.@]", "_").Trim();
            if (!string.IsNullOrEmpty(cleanString))
            {
                cleanString = cleanString.Replace(" ", "").Replace(" ", "").Replace(" ", "");
            }
            return cleanString;
            // return HttpUtility.UrlEncode(result);
        }

        public static string SanitizeFromWhiteSpace(string text)
        {
            return Regex.Replace(text, @"\t|\n|\r", "");
        }

        public static byte[] HexToByteArray(string text)
        {
            if (text == null) return null;
            if (text.Length % 2 == 1) text = '0' + text;
            byte[] data = new byte[text.Length / 2];
            for (int i = 0; i < data.Length; i++)
                data[i] = Convert.ToByte(text.Substring(i * 2, 2), 16);
            return data;
        }

        /// <summary>
        /// Returns the number of steps required to transform the source string
        /// into the target string.
        /// </summary>
        public static int ComputeLevenshteinDistance(string source, string target)
        {
            if ((source == null) || (target == null)) return 0;
            if ((source.Length == 0) || (target.Length == 0)) return 0;
            if (source == target) return source.Length;

            int sourceWordCount = source.Length;
            int targetWordCount = target.Length;

            // Step 1
            if (sourceWordCount == 0)
                return targetWordCount;

            if (targetWordCount == 0)
                return sourceWordCount;

            int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

            // Step 2
            for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
            for (int j = 0; j <= targetWordCount; distance[0, j] = j++) ;

            for (int i = 1; i <= sourceWordCount; i++)
            {
                for (int j = 1; j <= targetWordCount; j++)
                {
                    // Step 3
                    int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    // Step 4
                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                }
            }

            return distance[sourceWordCount, targetWordCount];
        }

        /// <summary>
        /// Calculate percentage similarity of two strings
        /// <param name="source">Source String to Compare with</param>
        /// <param name="target">Targeted String to Compare</param>
        /// <returns>Return Similarity between two strings from 0 to 1.0</returns>
        /// </summary>
        public static double CalculateSimilarity(string source, string target)
        {
            if ((source == null) || (target == null)) return 0.0;
            if ((source.Length == 0) || (target.Length == 0)) return 0.0;
            if (source == target) return 1.0;

            int stepsToSame = ComputeLevenshteinDistance(source, target);
            return (1.0 - ((double)stepsToSame / (double)Math.Max(source.Length, target.Length)));
        }

        public static string CreateRandomString(int length, string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
        {
            try
            {
                if (length < 0) throw new ArgumentOutOfRangeException("length", "length cannot be less than zero.");
                if (string.IsNullOrEmpty(allowedChars)) throw new ArgumentException("allowedChars may not be empty.");

                const int byteSize = 0x100;
                var allowedCharSet = new HashSet<char>(allowedChars).ToArray();
                if (byteSize < allowedCharSet.Length) throw new ArgumentException(String.Format("allowedChars may contain no more than {0} characters.", byteSize));

                // Guid.NewGuid and System.Random are not particularly random. By using a
                // cryptographically-secure random number generator, the caller is always
                // protected, regardless of use.
                using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
                {
                    var result = new StringBuilder();
                    var buf = new byte[128];
                    while (result.Length < length)
                    {
                        rng.GetBytes(buf);
                        for (var i = 0; i < buf.Length && result.Length < length; ++i)
                        {
                            // Divide the byte into allowedCharSet-sized groups. If the
                            // random value falls into the last group and the last group is
                            // too small to choose from the entire allowedCharSet, ignore
                            // the value in order to avoid biasing the result.
                            var outOfRangeStart = byteSize - (byteSize % allowedCharSet.Length);
                            if (outOfRangeStart <= buf[i]) continue;
                            result.Append(allowedCharSet[buf[i] % allowedCharSet.Length]);
                        }
                    }
                    return result.ToString();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
