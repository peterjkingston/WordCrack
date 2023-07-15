using System;
using System.Collections.Generic;
using System.Text;

namespace WordCrack
{
    public class WordChecker : IWordValidator
    {
        public event WordEventHandler? ValidWordFound;
        private Dictionary<string, string> _dict;

        public WordChecker(IDictionaryProvider? dictionaryProvider)
        {
            var provider = dictionaryProvider ?? new twl06DictionaryProvider();
            _dict = provider.GetDictionary();
        }

        public WordChecker()
        {
            var provider = new twl06DictionaryProvider();
            _dict = provider.GetDictionary();
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

        public void CheckWord(char[] letters)
        {
            var sb = new StringBuilder();
            sb.Append(letters);
            CheckWord(sb.ToString());
        }
    }
}
