using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyser
{
    public class LengthThenAsciiComparer: IComparer<Item>
    {
        public int Compare(Item a, Item b)
        {
            if (a == null || a.Value == null)
            {
                return (b == null || b.Value == null) ? 0 : -1;
            }
            if (b == null || b.Value == null)
            {
                return 1;
            }

            if (a.Value.Length < a.Value.Length)
                return 0;
            else if (a.Value.Length > b.Value.Length)
                return 1;
            else
                return String.Compare(a.Value, b.Value);
        }
    }
}
