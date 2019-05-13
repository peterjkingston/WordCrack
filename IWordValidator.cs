namespace WordCrack
{
    public interface IWordValidator
    {
        void CheckWord(string word);
        bool IsValidWord(string word);
        event WordEventHandler ValidWordFound;
    }
}
