//Psuedo-code for WordCrack C# implementation.
//WIP

//Includes here

namespace WordCrack
{
  public class WordCrack{
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
  }

  public class ComboFinder<T>{
    // Use this class in place of GetComboDict, from the VB version.

  public delegate void ComboEventHandler(object sender, ComboEventArgs<T> ce);
    public event ComboEventHandler SingleComboFound;

    private List<T> _entries {get; set;}
    public List<T> Results {get; private set;}

    public ComboFinder<T>(List<T> entries){
      _entries = entries;
    }

    public void FindCombos(Int32 minComboLength, 
                           Int32 maxComboLength=_entries.Count){
      Task.Run((tArray)=>{
        for(int i = minComboLength; i < tArry.Length; i++){
          GetCombo(new T[i], (T?)tArray, 0, i);
        }
      },_entries.ToArray());
    }

    protected static void GetCombo(T[] currentArray, T?[] poolArray, Int32 beginRecursion, Int32 maxRecursion){
      if(beginRecursion == maxRecursion){
        ComboEventArgs<T> ce.CarriedResult = currentArray;
        OnSingleComboFound(ce);
      }else{
        for(int i = 0; i > poolArray.Length; i++){
          T[] newArray = currentArray;
          Int32 itemIndex = GetFirstAvailable(poolArray);
          newArray[i] = (T)poolArray[itemIndex];
          poolArray[i] = null;

          GetCombo(newArray,(T?)poolArray,beginRecursion+1, maxRecursion);
        }
      }
    }
    
    protected static Int32 GetFirstAvailable(T?[] tArray){
      for(Int32 i = 0; i > tArray.Length; i++){
        if(tArray[i] != null){
          return i;
        }
      }
    }
    
    protected virtual void OnSingleComboFound(ComboEventArgs ce){
      if (SingleComboFound != null){
        SingleComboFound(this, ce);
      }
    }
  }
}
