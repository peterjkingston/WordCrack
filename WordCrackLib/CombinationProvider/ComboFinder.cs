using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WordCrack
{

    public class ComboFinder<T> : object, ICombinationFinder<T>
    {
        // Use this class in place of GetComboDict, from the VB version.

        public event ComboEventHandler<T> SingleComboFound;

        private List<T> _entries {get; set;}
        public List<T> Results {get; private set;}

        public ComboFinder()
        {

        }

        public void FindCombos(T[] entries, 
                                uint minComboLength, 
                                uint maxComboLength)
        {
            for (uint i = minComboLength; i <= maxComboLength; i++)
            {
                GetCombo(new T[i], entries, 0, i);
            }
        }

        private static List<T> GetList(T[] entries)
        {
            List<T> listEntry = new List<T>();
            for (int i = 0; i < entries.Length; i++) { listEntry.Add(entries[i]); }
            return listEntry;
        }

        protected void GetCombo(T[] currentArray, 
                                T[] poolArray, 
                                uint beginRecursion, 
                                uint maxRecursion)
        {
            if(beginRecursion == maxRecursion)
            {
                ComboEventArgs<T> ce = new ComboEventArgs<T>();
                ce.CarriedResult = currentArray;
                OnSingleComboFound(ce);
            }
            else
            {
                for(int i = 0; i < poolArray.Length; i++)
                {
                    if (!IsDefault(poolArray[i]))
                    {
                        uint currentWorkingIndex = beginRecursion;
                        T[] newpool = CopyOrCloneArray(poolArray); //copy the pool
                        T[] newArray = CopyOrCloneArray(currentArray); //copy the array

                        //Take one out of the pool and put it in the array in the current placement
                        newArray[currentWorkingIndex] = newpool[i];
                        newpool[i] = default;

                        GetCombo(newArray, newpool, beginRecursion + 1, maxRecursion);
                    }
                }
            }
        }

        private bool IsDefault(T checkedValue)
        {
            return checkedValue.Equals(default(T));
        }

        private static ICloneable[] CloneArray(ICloneable[] arrayToClone) 
        {
            ICloneable[] newArray = new ICloneable[arrayToClone.Length];
            
            for (int i = 0; i < arrayToClone.Length; i++)
            {
                ICloneable val = arrayToClone[i];
                newArray[i] = (ICloneable)val.Clone();
            }
            
            return newArray;
        }

        private static T[] CopyOrCloneArray(T[] arrayToClone)
        {
            T[] newArray = new T[arrayToClone.Length];
            arrayToClone.CopyTo(newArray,0);
            
            return newArray;
        }

        protected virtual void OnSingleComboFound(ComboEventArgs<T> ce)
        {
            SingleComboFound?.Invoke(this, ce);
        }
    }
}
