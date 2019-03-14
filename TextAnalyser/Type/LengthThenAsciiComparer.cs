using System;
using System.Collections.Generic;

namespace TextAnalyser
{
    public class LengthThenAsciiComparer: IComparer<Item>
    {
        public int Compare(Item a, Item b)
        {
            // sanity check
            if (a == null || a.Value == null)
            {
                return (b == null || b.Value == null) ? 0 : -1;
            }
            if (b == null || b.Value == null)
            {
                return 1;
            }

            // return result for non equal string lengths, Ascii comparison else
            int result = a.Value.Length.CompareTo(b.Value.Length);
            return (result != 0) ? result :  String.CompareOrdinal(a.Value, b.Value);
        
        }
    }
}
