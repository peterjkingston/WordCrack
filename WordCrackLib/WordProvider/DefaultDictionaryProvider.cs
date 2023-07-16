using System.IO;
using System.Collections.Generic;
using System.Text;

namespace WordCrack
{
    class DefaultDictionaryProvider : IDictionaryProvider
    {
        Dictionary<string, string> _dict;

        public void ParseFromFile(string filePath)
        {
            //TODO: Implement Dictionary loading...
            _dict = new Dictionary<string, string>();
            StreamReader sr = new StreamReader(filePath);
            string word;
            while (!sr.EndOfStream)
            {
                word = sr.ReadLine() ?? string.Empty;
                _dict.Add(word, word);
            }
        }

        public Dictionary<string, string> GetDictionary()
        {
            return _dict;
        }
    }
}
