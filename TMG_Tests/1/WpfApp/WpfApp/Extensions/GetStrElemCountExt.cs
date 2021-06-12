using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WpfApp.Constants;

namespace WpfApp.Extensions
{
    public static class GetStrElemCountExt
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
                    return -1;
            }
            foreach (char c in str)
            {
                if (vowels.Contains(c)) vowelsCount++;
            }
            return vowelsCount;
        }
        public static string RemoveWhitespace(this string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}
