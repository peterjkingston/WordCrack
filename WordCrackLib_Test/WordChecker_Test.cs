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
    }
}