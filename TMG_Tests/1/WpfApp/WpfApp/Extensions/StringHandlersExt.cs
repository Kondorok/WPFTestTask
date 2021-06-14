using System.Linq;
using static WpfApp.Constants;

/*
    String Handlers extensions.
    GetWordCount return count of words in the string.
    GetVowelsCoun return count of vowels in the string depend of language.
    RemoveWhitespace removes spaces in the string.
 */
namespace WpfApp.Extensions
{
    public static class StringHandlersExt
    {
        public static int GetWordsCount(this string str)
        {
            return str.Split(' ').Length;
        }
        public static int GetVowelsCount(this string str, Lang lang)
        {
            string vowels;
            int vowelsCount = 0;
            switch (lang)
            {
                case Lang.English:
                    vowels = engVowels;
                    break;
                case Lang.Russian:
                    vowels = rusVowels;
                    break;
                default:
                    return -1; //If language is unknown or mixing
            }
            foreach (char c in str)
            {
                if (vowels.Contains(c)) vowelsCount++;
            }
            return vowelsCount;
        }
        public static string RemoveWhitespace(this string input)
        {
            if (input == null) return "";
            return new string(input.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}
