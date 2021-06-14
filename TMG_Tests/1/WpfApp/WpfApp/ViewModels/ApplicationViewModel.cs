using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using WpfApp.API;
using WpfApp.Extensions;
using WpfApp.Models;

namespace WpfApp.ViewModels
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        Api api = new Api();
        public IndexesString indexesString { get; set; }

        //ObservableCollection for binding to the table view
        public ObservableCollection<TableString> TableStrings { get; set; }

        public int ColumnWidth { get; set; }
        public int FontSize { get; set; }
        public int RowHeight { get; set; }
        public ApplicationViewModel()
        {
            TableStrings = new ObservableCollection<TableString>();
            indexesString = new IndexesString();
        }
        //Parsing the textBox string to the list of distinct indexes
        private IEnumerable<int> GetIndexes(string strIndexes)
        {
            var _strIndexes = strIndexes.RemoveWhitespace().Split(',', ';');
            List<int> nums = new List<int>();
            foreach (var c in _strIndexes)
            {
                int number;
                if (int.TryParse(c, out number))
                {
                    if (number > 0 && number <= 20) nums.Add(number);
                }
            }
            return nums.Distinct();
        }

        //Command for view elements for fetching strings
        private RelayCommand fetchCommand;
        public RelayCommand FetchCommand
        {
            get
            {
                return fetchCommand ??
                  (fetchCommand = new RelayCommand(obj =>
                  {
                      FetchTableStrings(obj);
                  }));
            }
        }

        public async void FetchTableStrings(object button)
        {
            //Lock button while response is handling
            Button _button = button as Button;
            _button.IsEnabled = false;
            var nums = GetIndexes(indexesString.AfterFormat);

            //Clear the table
            TableStrings.Clear();

            foreach (int index in nums)
            {
                var responseMessage = await api.GetResponse(index);
                if (responseMessage != null)
                {
                    var responseText = responseMessage.Text;
                    var wordsCount = responseText.GetWordsCount();
                    var vowelsCount = responseText.GetVowelsCount(responseText.GetLangOfString());
                    if (responseText != "")
                    {
                        int linesCount;
                        var text = responseText.GetStringWithBreak(12, 300, out linesCount);
                        RowHeight = 17 * linesCount; // Line's height is about 17
                        var tableString = new TableString(text, wordsCount, vowelsCount);
                        TableStrings.Add(tableString);
                    }
                }
            }
            _button.IsEnabled = true;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
