using static WpfApp.Constants;

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
