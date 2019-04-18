using System;
using System.Collections.Generic;
using TextAnalyser.Structure;
using TextAnalyser.Tree.TreeStructure;

namespace TextAnalyser.TreeStructure
{
    public abstract class BaseTree<T> : IDataStructure<T>
    {
        #region Members
        /// <summary>
        /// The Tree root
        /// </summary>
        protected INode<T> root;

        /// <summary>
        /// The comparer used to order items
        /// </summary>
        protected  IComparer<T> comparer;

        /// <summary>
        /// Array of Item constructed during the tree traversal
        /// </summary>
        protected List<INode<T>> report;
        #endregion

        #region Constructor
        public BaseTree(IComparer<T> comp)
        {
            comparer = comp;
            report = new List<INode<T>>();
            root = null;
        }
        #endregion

        #region Properties
        public List<INode<T>> Report
        {
            get
            {
                return report;
            }
        }


        public INode<T> GetRoot()
        {
            return root;
        }
        #endregion

        #region Interface Implements
        /// <summary>
        /// Insert an item into the Tree
        /// </summary>
        /// <param name="i">The item</param>
        public abstract void Insert(T i);

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
