using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Media;
using WpfApp.Extensions;

namespace WpfApp.Models
{
    public class IndexesString : INotifyPropertyChanged, IDataErrorInfo
    {
        const string pattern = @"^(0*(1?\d|20)(,|;))*$";
        private string _beforeFormat;

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case "BeforeFormat":
                        if (_beforeFormat !=null && _beforeFormat != "")
                        if (!Regex.IsMatch((_beforeFormat + ',').RemoveWhitespace(), pattern, RegexOptions.IgnoreCase))
                            error = "Формат строки неверен. Перечисляйте индексы 1-20 через , или ;";
                        break;
                }
                return error;
            }
        }

        public string BeforeFormat
        {
            get => _beforeFormat;
            set
            {
                _beforeFormat = value;
                var charAr = new string(value.Where(x => ((x >= '0') && (x <= '9')) || x == ',' || x == ';' || x == ' ').ToArray());
                //indexesStringAfterFormat = Regex.Replace(value, pattern, String.Empty);
                AfterFormat = charAr;
                OnPropertyChanged(_beforeFormat);
            }
        }
        public string AfterFormat { get; private set; }

        public string Error => throw new System.NotImplementedException();





        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }



}
