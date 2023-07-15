using WordCrack;

namespace WordCrackTermnial
{
    public interface IWordDisplayer
    {
        void Display(string word);
        void DisplayTrigger(object sender, WordEventArgs we);
    }
}
