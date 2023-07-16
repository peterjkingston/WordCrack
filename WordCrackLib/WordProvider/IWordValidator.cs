namespace WordCrack
{
    public interface IWordValidator
    {
        bool CheckWord(string word);
        bool CheckWord(char[] letters);
        bool IsValidWord(string word);
        event WordEventHandler ValidWordFound;
    }
}
