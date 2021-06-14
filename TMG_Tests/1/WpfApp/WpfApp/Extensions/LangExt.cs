using static WpfApp.Constants;

/*
    Extensions for language working
    GetLangOfChar return a language the char from is.
    GetLangOfString return a language of the string. A language must be certain(Rus,Eng) or Unknown(include Mix).
    RemoveWhitespace removes spaces in the string.
 */

namespace WpfApp.Extensions
{
    public static class LangExt
    {
        public static Lang GetLangOfChar(this char c)
        {
            if ((c > 'а' && c < 'я') || (c > 'А' && c < 'Я')) return Lang.Russian;
            else if ((c > 'a' && c < 'z') || (c > 'A' && c < 'Z')) return Lang.English;
            return Lang.Unknown;
        }
        public static Lang GetLangOfString(this string str)
        {
            //If the first char from one language, other char must be from this language too, if the language is certain.
            bool isFirstLetterEng = str[0].GetLangOfChar() == Lang.English;
            if (isFirstLetterEng)
            {
                foreach (char c in str)
                {
                    if (GetLangOfChar(c) == Lang.Russian) return Lang.Unknown;
                }
                return Lang.English;
            }
            else
            {
                foreach (char c in str)
                {
                    if (GetLangOfChar(c) == Lang.English) return Lang.Unknown;
                }
                return Lang.Russian;
            }
        }
    }
}
