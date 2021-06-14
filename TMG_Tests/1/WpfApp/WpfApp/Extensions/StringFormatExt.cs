using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
    Format the string with breaks
 */


namespace WpfApp.Extensions
{
    public static class StringFormatExt
    {
        public static string GetStringWithBreak(this string str, int fontSize, int columnWidth, out int linesCount)
        {
            var _linesCount = 0;
            var masWords = str.Split(' ');
            StringBuilder tempStr = new StringBuilder();
            StringBuilder entireString = new StringBuilder();
            int len = columnWidth / fontSize * 2 - 2;
            for (int i = 0; i < masWords.Length; i++)
            {
                if ((tempStr.Length + masWords[i].Length) < len) tempStr.Append(masWords[i] + ' ');
                else
                {
                    tempStr.Append('\n');
                    entireString.Append(tempStr);
                    _linesCount++;
                    tempStr.Clear();
                }
            }
            tempStr.Append('\n');
            entireString.Append(tempStr);
            _linesCount++;
            linesCount = _linesCount;
            return entireString.ToString();
        }
    }
}
