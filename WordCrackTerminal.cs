namespace WordCrack{
  
  static class Program{
    string _letters {get;set;}
    WordCrack _wordCrack {get;set;}
    
    static void Main(){
      console.Title = "WordCrack.exe";
      console.log("Welcome to WordCrack!\nPlease type any letter combination for a list of possible words!");
      _letters = String.Trim(console.Readline());
      Dispatcher.Current.Invoke(Intake());
    }
    
    static void Intake(){
      //Need a dictionary, instead of a blank one
      Int32 minWordLength = 3;
      
      _wordCrack = new WordCrack(_letters, new Dictionary<string,string>());
      _wordCrack.ValidWordFound = PrintWord;
      _wordCrack.FindWords(minWordLength);
    }
    
    static void PrintWord(object sender, WordEventHandler we){
      console.log(we.WordFound);
    }
  }
}
