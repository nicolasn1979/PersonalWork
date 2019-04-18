
using System;
using TextAnalyser.Tree.TreeStructure;

namespace TextAnalyser.Structure
{
    public class BaseNode<T> : INode<T>
    {
        #region Members
        protected T item;
        protected int count;
        protected INode<T> left;
        protected INode<T> right;
        #endregion

        #region Constructor
        public BaseNode(T i)
        {
            item = i;
            count = 1;
        }

        public void IncrementCount()
        {
            count++;
        }

        public int GetCount()
        {
            return count;
        }

        public T GetItem()
        {
            return item;
        }

        public INode<T> GetLeft()
        {
            return left;
        }
        public void SetLeft(INode<T> node)
        {
            left = node;
        }

        public INode<T> GetRight()
        {
            return right;
        }

        public void SetRight(INode<T> node)
        {
            right = node;
        }

        #endregion

        #region Properties

        #endregion

        #region Methods
        public override String ToString()
        {
            return $"{count} {item.ToString()}";
        }
        #endregion
    }
}
