
using System;

namespace TextAnalyser.Structure
{
    public class BaseNode
    {
        #region Members
        protected Item item;
        protected int count;
        #endregion

        #region Constructor
        public BaseNode(Item i)
        {
            item = i;
            count++;
        }
        #endregion

        #region Properties
        public Item Item
        {
            get
            {
                return item;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }
        #endregion

        #region Methods
        public override String ToString()
        {
            return $"{count} {item.ToString()}";
        }
        #endregion
    }
}
