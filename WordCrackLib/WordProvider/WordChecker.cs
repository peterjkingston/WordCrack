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

        public bool CheckWord(string word)
        {
            if (IsValidWord(word))
            {
                WordEventArgs we = new WordEventArgs();
                we.WordFound = word;
                OnValidWordFound(we);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckWord(char[] letters)
        {
            var sb = new StringBuilder();
            sb.Append(letters);
            return CheckWord(sb.ToString());
        }

        protected virtual void OnValidWordFound(WordEventArgs we)
        {
            ValidWordFound?.Invoke(this, we);
        }

        
    }
}
