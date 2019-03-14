using System;

namespace TextAnalyser
{
    public class Item
    {
        #region Members
        private String value;
        #endregion

        #region Constructor
        public Item(String value)
        {
            this.value = value;
        }
        #endregion

        #region Properties
        public String Value
        {
            get { return value; }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return value;
        }
        #endregion
    }
}
