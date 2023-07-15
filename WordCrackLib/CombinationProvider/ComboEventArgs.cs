using System;

namespace WordCrack
{
  public class ComboEventArgs<T> : EventArgs
  {
    public T[] CarriedResult {get; set;} 
  }
}
