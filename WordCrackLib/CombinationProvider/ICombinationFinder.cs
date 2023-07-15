using System;

namespace WordCrack
{
    public interface ICombinationFinder<T>
    {
        event ComboEventHandler<T> SingleComboFound;

        void FindCombos(T[] entries, uint minLength, uint maxLength);
    }
}
