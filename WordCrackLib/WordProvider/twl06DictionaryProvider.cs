using System.IO;
using System.Collections.Generic;
using System.Text;

namespace WordCrack
{
    class twl06DictionaryProvider : IDictionaryProvider
    {
        Dictionary<string, string> _dict;

        public twl06DictionaryProvider()
        {
            _dict = ParseFromFile("twl06.txt");      
        }

        public Dictionary<string,string> ParseFromFile(string filePath)
        {
            _dict = new Dictionary<string, string>();
            StreamReader sr = new StreamReader(filePath);
            string word;
            while (!sr.EndOfStream)
            {
                word = sr.ReadLine() ?? string.Empty;
                _dict.Add(word, word);
            }
            return _dict;
        }

        public Dictionary<string, string> GetDictionary()
        {
            return _dict;
        }
    }
}
