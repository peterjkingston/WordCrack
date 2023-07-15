using System;
using System.Collections.Generic;
using System.Text;

namespace WordCrack
{
    public interface IDictionaryProvider
    {
        Dictionary<string, string> GetDictionary();
    }
}
