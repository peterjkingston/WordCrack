using System;
using System.Collections.Generic;
using System.Text;

namespace WordCrack
{
    class WordChecker : IWordValidator
    {
        public event WordEventHandler ValidWordFound;
        private Dictionary<string, string> _dict;

        public WordChecker(Dictionary<string, string> dictionary)
        {
            _dict = dictionary;
        }

        public bool IsValidWord(string word)
        {

            return _dict.ContainsKey(word);
        }

        public void CheckWord(string word)
        {
            if (IsValidWord(word))
            {
                WordEventArgs we = new WordEventArgs();
                we.WordFound = word;
                OnValidWordFound(we);
            }
        }

        protected virtual void OnValidWordFound(WordEventArgs we)
        {
            ValidWordFound?.Invoke(this, we);
        }
    }
}
