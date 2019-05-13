using System;

namespace WordCrack
{
    public interface ICombinationFinder<T>
    {
        event ComboEventHandler<T> SingleComboFound;

        void FindCombos(T[] entries, Int32 minLength, Int32 maxLength);
    }
}
