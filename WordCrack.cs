using System;
using System.Collections.Generic;

namespace WordCrack
{ 
    public class WordCrack : object
    {
        public event WordEventHandler ValidWordFound;

        private char[] _pool;
        private ICombinationFinder<char> _comboFinder;
        private IWordValidator _wordValidator;

        public Dictionary<string, string> WordDictionary { get; private set; }

        public WordCrack(ICombinationFinder<char> comboFinder, IWordValidator wordValidator)
        {
            _comboFinder = comboFinder;
            _wordValidator = wordValidator;
            _wordValidator.ValidWordFound += EchoWord;

            _comboFinder.SingleComboFound += (object sender, ComboEventArgs<char> ce) =>
            {
                _wordValidator.CheckWord(new String(ce.CarriedResult));
            };
        }

        public void FindWords(char[] letters, Int32 minWordLength, Int32 maxWordLength)
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
