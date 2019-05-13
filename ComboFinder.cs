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

        public void FindCombos(T[] entries, Int32 minComboLength, 
                                Int32 maxComboLength)
        {
            /*
            _entries = GetList(entries);

            Task t = new Task((tArray) =>
            {
                for (int i = minComboLength; i < ((T[])tArray).Length; i++)
                {
                    GetCombo(new T[i], ((T[])tArray), 0, i);
                }
            },
            _entries.ToArray());
            t.Start();*/
            for (int i = minComboLength; i <= maxComboLength; i++)
            {
                GetCombo(new T[i], entries, 0, maxComboLength);
            }
        }

        private static List<T> GetList(T[] entries)
        {
            List<T> listEntry = new List<T>();
            for (int i = 0; i < entries.Length; i++) { listEntry.Add(entries[i]); }
            return listEntry;
        }

        protected void GetCombo(T[] currentArray, T[] poolArray, Int32 beginRecursion, Int32 maxRecursion)
        {
            if(beginRecursion == maxRecursion)
            {
                ComboEventArgs<T> ce = new ComboEventArgs<T>();
                ce.CarriedResult = currentArray;
                OnSingleComboFound(ce);
            }
            else
            {
                for(int i = 0; i < poolArray.Length-1; i++)
                {
                    if (!default(T).Equals(poolArray[i]))
                    {
                        T[] newpool = poolArray;
                        T[] newArray = currentArray;
                        Int32 itemIndex = GetFirstAvailable(newpool);
                        newArray[beginRecursion] = newpool[itemIndex];
                        newpool[itemIndex] = default;

                        GetCombo(newArray, newpool, beginRecursion + 1, maxRecursion);
                    }
                }
            }
        }

        protected static Int32 GetFirstAvailable(T[] tArray)
        {
            for(Int32 i = 0; i < tArray.Length; i++)
            {
                if(!default(T).Equals(tArray[i]))
                {
                    return i;
                }
            }
            return 0;
        }

        protected virtual void OnSingleComboFound(ComboEventArgs<T> ce)
        {
            SingleComboFound?.Invoke(this, ce);
        }
    }
}
