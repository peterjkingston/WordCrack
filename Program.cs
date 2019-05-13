using System;

namespace WordCrack
{
    class Program
    {
        static void Main(string[] args)
        {
            string letters;

            Console.Title = "WordCrack.exe";
            Console.WriteLine("Welcome to WordCrack!\nPlease type any letter combination for a list of possible words!");
            letters = Console.ReadLine().Trim();

            Int32 minWordLength = 3;
            Int32 maxWordLength = letters.Length;

            //Need a dictionary, instead of a blank one
            DictionaryLookup dictionaryProvider = new DictionaryLookup();
            dictionaryProvider.ParseFromFile(@"C:\Users\peter\source\repos\WordCrack Terminal\WordCrack Terminal\twl06.txt");
            
            ICombinationFinder<char> comboFinder = new ComboFinder<char>();
            IWordValidator wordValidator = new WordChecker(dictionaryProvider.GetDictionary());
            IWordDisplayer wordDisplayer = new WordPrinter();

            WordCrack crack = new WordCrack(comboFinder,
                                            wordValidator);

            wordValidator.ValidWordFound += wordDisplayer.DisplayTrigger;

            crack.FindWords(letters.ToCharArray(),
                            minWordLength,
                            maxWordLength);

            Console.WriteLine("\n Press any key to exit");
            Console.ReadKey(true);
        }
    }
}
