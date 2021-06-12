using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    public class TableString
    {
        public string Text { get; set; }
        public int Words_Count { get; set; }
        public int Vowels_Count { get; set; }
        public TableString(string Text, int Words_Count, int Vowels_Count)
        {
            this.Text = Text;
            this.Words_Count = Words_Count;
            this.Vowels_Count = Vowels_Count;
        }
    }
}
