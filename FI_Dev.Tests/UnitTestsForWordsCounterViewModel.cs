using System.Linq;
using FI_Dev.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FI_Dev.Tests
{
    [TestClass]
    public class UnitTestsForSentenceViewModel
    {
        private const string Sentence = "THIS this is a very short and very boring sentence working also with oth!!!!er signs";

        [TestMethod]
        public void WordThisOccurTwice()
        {
            var sut = new WordsCounterViewModel(Sentence);
            sut.SaveChanges();
            var result = sut.Sentence.WordsCollection.FirstOrDefault(i => i.Name == "this");
            if (result != null)
                Assert.AreEqual(2, result.WordCounter);
        }

        [TestMethod]
        public void SentenceContains13Words()
        {
            var sut = new WordsCounterViewModel(Sentence);
            sut.SaveChanges();
            Assert.AreEqual(13, sut.Sentence.WordsCollection.Count);
        }

        [TestMethod]
        public void IfSentenceIsEmptyButtonIsDisabled()
        {
            const string emptySentence = "";
            var sut = new WordsCounterViewModel(emptySentence);
            sut.SaveChanges();
            Assert.AreEqual(false, sut.CanUpdate);
        }

        [TestMethod]
        public void IfSentenceIsNotEmptyButtonIsEnabled()
        {
            var sut = new WordsCounterViewModel(Sentence);
            sut.SaveChanges();
            Assert.AreEqual(true, sut.CanUpdate);
        }
    }
}
