using System;
using System.Collections.Generic;

namespace TextAnalyser.Structure
{
    public abstract class BaseTree : ITree
    {
        #region Members
        /// <summary>
        /// The Tree root
        /// </summary>
        protected BaseNode root;

        /// <summary>
        /// The comparer used to order items
        /// </summary>
        protected  IComparer<Item> comparer;

        /// <summary>
        /// Array of Item constructed during the tree traversal
        /// </summary>
        protected List<BaseNode> report;
        #endregion

        #region Constructor
        public BaseTree()
        {
            comparer = new LengthThenAsciiComparer();
            report = new List<BaseNode>();
            root = null;
        }
        #endregion

        #region Properties
        public BaseNode Root
        {
            get
            {
                return root;
            }
        }
        public List<BaseNode> Report
        {
            get
            {
                return report;
            }
        }

        #endregion

        #region Interface Implements
        /// <summary>
        /// Insert an item into the Tree
        /// </summary>
        /// <param name="i">The item</param>
        public abstract void Insert(Item i);

        /// <summary>
        /// Traverse the Tree
        /// </summary>
        public abstract void Traverse();

        /// <summary>
        /// Display alls Items fetched during Tree traversal
        /// </summary>
        public void ShowReport()
        {
            foreach (var item in report)
                Console.WriteLine(item.ToString());
        }

        #endregion
    }

}
