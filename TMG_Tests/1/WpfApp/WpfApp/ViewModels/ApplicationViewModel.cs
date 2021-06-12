using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using WpfApp.API;
using WpfApp.Extensions;
using WpfApp.Models;

namespace WpfApp.ViewModels
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        Api api = new Api();
        public ObservableCollection<TableString> TableStrings { get; set; }
        private string indexesStringBeforeFormat;
        private string indexesStringAfterFormat;
        public string IndexesString {
            get { return indexesStringBeforeFormat; }
            set
            {
                indexesStringBeforeFormat = value;
                var charAr = new string(value.Where(x => ((x >= '0') && (x <= '9')) || x == ',' || x == ';' || x == ' ').ToArray());
                indexesStringAfterFormat = charAr;
                OnPropertyChanged(IndexesString);
            }
        }

        public ApplicationViewModel()
        {
            TableStrings = new ObservableCollection<TableString>();
        }

        private IEnumerable<int> GetIndexes()
        {
            var strIndexes = IndexesString.RemoveWhitespace().Split(',', ';').Distinct();
            foreach (var c in strIndexes)
            {
                int number = int.Parse(c);
                if (number > 0 && number <= 20) yield return number;
            }
        }

        private RelayCommand fetchCommand;
        public RelayCommand FetchCommand
        {
            get
            {
                return fetchCommand ??
                  (fetchCommand = new RelayCommand(obj =>
                  {
                      FetchTableStrings();
                  }));
            }
        }

        public async void FetchTableStrings()
        {
            var nums = GetIndexes();
            TableStrings.Clear();
            foreach (int index in nums)
            {
                var responseMessage = (await api.GetResponse(index)).Text;
                var wordsCount = responseMessage.GetWordsCount();
                var vowelsCount = responseMessage.GetVowelsCount(responseMessage.GetLangOfString());
                if (responseMessage != "")
                {
                    var tableString = new TableString(responseMessage, wordsCount, vowelsCount);
                    TableStrings.Add(tableString);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
