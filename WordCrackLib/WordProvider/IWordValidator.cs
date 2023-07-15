namespace WordCrack
{
    public interface IWordValidator
    {
        void CheckWord(string word);
        void CheckWord(char[] letters);
        bool IsValidWord(string word);
        event WordEventHandler ValidWordFound;
    }
}
