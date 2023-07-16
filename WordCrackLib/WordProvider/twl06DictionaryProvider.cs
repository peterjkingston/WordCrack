using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using WordCrackLib.Properties;

namespace WordCrack
{
    class twl06DictionaryProvider : IDictionaryProvider
    {
        Dictionary<string, string> _dict;

        public twl06DictionaryProvider()
        {
            _dict = ParseFromString(Resources.twl06,'\n');      
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

        public Dictionary<string,string>ParseFromString(string body, char delimiter)
        {
            _dict = new Dictionary<string, string>();
            var words = body.Split(delimiter);
            foreach (var word in words)
            {
                var trimmedWord = word.Trim();
                _dict.Add(trimmedWord, trimmedWord);
            }
            return _dict;
        }

        public Dictionary<string, string> GetDictionary()
        {
            return _dict;
        }
    }
}
