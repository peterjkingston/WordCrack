namespace WordCrack
{
    public class WordCracker : object
    {
        public event WordEventHandler? ValidWordFound;

        private char[]? _pool;
        private ICombinationFinder<char> _comboFinder;
        private IWordValidator _wordValidator;

        public WordCracker(ICombinationFinder<char>? comboFinder, IWordValidator? wordValidator)
        {
            _comboFinder = comboFinder ?? new ComboFinder<char>();
            _wordValidator = wordValidator ?? new WordChecker(null);
            _wordValidator.ValidWordFound += EchoWord;

            _comboFinder.SingleComboFound += (object sender, ComboEventArgs<char> ce) =>
            {
                _wordValidator.CheckWord(ce.CarriedResult);
            };
        }

        public WordCracker()
        {
            _comboFinder = new ComboFinder<char>();
            _wordValidator = new WordChecker(null);
            _wordValidator.ValidWordFound += EchoWord;

            _comboFinder.SingleComboFound += (object sender, ComboEventArgs<char> ce) =>
            {
                _wordValidator.CheckWord(ce.CarriedResult);
            };
        }

        public void FindWords(char[] letters, uint minWordLength, uint maxWordLength = 7)
        {
            _pool = letters;
            _comboFinder.FindCombos(letters, minWordLength, maxWordLength);
        }

        private void EchoWord(object sender, WordEventArgs we)
        {
            OnValidWordFound(we);
        }

        protected virtual void OnValidWordFound(WordEventArgs we)
        {
            ValidWordFound?.Invoke(this, we);
        }
    }
}
