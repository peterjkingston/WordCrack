using System.IO;
using System.Collections.Generic;
using System.Text;

namespace WordCrack
{
    class DictionaryLookup : IDictionaryProvider
    {
        Dictionary<string, string> _Dict;

        public void ParseFromFile(string filePath)
        {
            //TODO: Implement Dictionary loading...
            _Dict = new Dictionary<string, string>();
            StreamReader sr = new StreamReader(filePath);
            string word;
            while (!sr.EndOfStream)
            {
                word = sr.ReadLine();
                _Dict.Add(word, word);
            }
        }

        public Dictionary<string, string> GetDictionary()
        {
            return _Dict;
        }
    }
}
