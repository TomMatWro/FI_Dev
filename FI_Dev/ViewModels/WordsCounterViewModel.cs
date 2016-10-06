using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;
using FI_Dev.Commands;
using FI_Dev.Models;

namespace FI_Dev.ViewModels
{
    public class WordsCounterViewModel
    {
        public WordsCounterViewModel()
        {
            _sentence = new WordsCounterModel("This sentence is a very sample example of sentence.");
            UpdateContentCommand = new SentenceUpdateCommand(this);
        }

        public WordsCounterViewModel(string sentence)
        {
            _sentence = new WordsCounterModel(sentence);
            UpdateContentCommand = new SentenceUpdateCommand(this);
        }

        private WordsCounterModel _sentence;
        public WordsCounterModel Sentence
        {
            get { return _sentence; }
        }

        public ICommand UpdateContentCommand
        {
            get;
            private set;
        }

        public bool CanUpdate => !string.IsNullOrWhiteSpace(Sentence?.Content);

        public void SaveChanges()
        {
            Sentence.WordsCollection.Clear();

            var str = Sentence.Content.ToLower();

            var rgx = new Regex("[^a-zA-Z ]");
            str = rgx.Replace(str, "");

            var wordsList = str.Split(' ');


            foreach (var word in wordsList)
            {
                if (string.IsNullOrWhiteSpace(word))
                {
                    continue;
                }
                var wordFromCollection = Sentence.WordsCollection.FirstOrDefault(i => i.Name == word);
                if (wordFromCollection != null)
                {
                    wordFromCollection.WordCounter++;
                }
                else
                {
                    Sentence.WordsCollection.Add(new SentenceContent { Name = word, WordCounter = 1 });
                }
            }
        }
    }
}