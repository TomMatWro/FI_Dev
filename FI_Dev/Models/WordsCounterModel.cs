using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace FI_Dev.Models
{
    public class WordsCounterModel : INotifyPropertyChanged
    {


        public WordsCounterModel(string sentenceContent)
        {
            Content = sentenceContent;
            WordsCollection = new ObservableCollection<SentenceContent>();
            WordsCollection.CollectionChanged += ContentCollectionChanged;
        }

        private void ContentCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("WordsCollection");
        }

        private string _content;


        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged("Content");
            }
        }

        public ObservableCollection<SentenceContent> WordsCollection { get; }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}