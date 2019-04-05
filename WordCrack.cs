//Psuedo-code for WordCrack C# implementation.
//WIP

//Includes here

namespace WordCrack
{
  public class WordCrack : Object{
    public delegate WordEventHandler(object sender, WordEventArgs we);
    public event WordEventHandler ValidWordFound;
  
    private char[] _pool {get; set;}
    public Dict<string,string> WordDictionary {get; private set;}
    
    public WordCrack (string letters, Dict<string,string> wordDict){
      if(minWordLength <= 0) throw ArgumentOutOfRangeException;
      
      _pool = letters.ToArray();
      WordDictionary = wordDict;
    }
    
    public void FindWords(Int32 minWordLength){
      ComboFinder<char> cf = new ComboFinder<char>(_pool);
      cf.SingleComboFound += Dispatcher.Current.Invoke((object sender, ComboEventArgs<char> ce) =>{
        if(IsValidWord(ce.CarriedResult)){
          WordEventHandler we.FoundWord = ce.CarriedResult.ToString();
        }
      })
    }
    
    private bool IsValidWord(char[] letters){
      return WordDictionary.Exists(letters.ToString())? true : false;
    }
    
    protected virtual void OnValidWordFound(WordEventHandler we){
      if(ValidWordFound != null){
        ValidWordFound(this,we);
      }
    }
  }
