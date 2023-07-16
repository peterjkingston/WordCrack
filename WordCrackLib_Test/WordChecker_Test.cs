using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCrack;

namespace WordCrackLib
{
    [TestClass]
    public class TestWordChecker
    {
        [TestMethod]
        public void EmptyConstructor()
        {
            var checker = new WordChecker();

            Assert.IsNotNull(checker);
        }

        [TestMethod]
        public void NullConstructor()
        {
            var checker = new WordChecker(null);
            Assert.IsNotNull(checker);
        }

        [TestMethod]
        public void CheckWord_AllowsCommonWords()
        {
            var checker = new WordChecker();
            string[] commonWords = { "goat", "fire", "sleep", "sit", "sand", "beach" };

            var result = true;
            foreach (string word in commonWords)
            {
                result = checker.CheckWord(word);
                if (!result) break;
            }

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckWord_DisallowsMadeUpWords()
        {
            var checker = new WordChecker();
            string[] madeUpWords = { "pinzit", "whurrsh", "kadump", "blingbling" };

            var result = false;
            foreach (string word in madeUpWords)
            {
                result = checker.CheckWord(word);
                if (result) break;
            }

            Assert.IsFalse(result);
        }
    }
}