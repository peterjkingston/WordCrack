using System;
using System.Collections.Generic;
using WordCrack;

namespace WordCrackTerminal{
  
  static class Program{
    static string _letters {get;set;}
    static WordCracker _wordCrack = new WordCracker(null, null);
    
    static void Main(){
      Console.Title = "WordCrack.exe";
      Console.WriteLine("Welcome to WordCrack!\nPlease type any letter combination for a list of possible words!");
      _letters = (Console.ReadLine() ?? string.Empty).Trim();
      Intake();
    }
    
    static void Intake(){
      //Need a dictionary, instead of a blank one
      uint minWordLength = 3;
      
      _wordCrack.ValidWordFound += PrintWord;
      _wordCrack.FindWords(_letters.ToCharArray(),minWordLength);
    }

    private static void PrintWord(object sender, WordEventArgs we)
    {
        Console.WriteLine(we.WordFound);
    }
  }
}
