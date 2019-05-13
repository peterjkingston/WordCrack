using System;
using System.Collections.Generic;
using System.Text;

namespace WordCrack
{
    class WordPrinter:IWordDisplayer
    {
        public void Display(string word)
        {
            Console.WriteLine(word);
        }

        public void DisplayTrigger(object sender, WordEventArgs we)
        {
            Display(we.WordFound);
        }
    }
}
