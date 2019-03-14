using System;
using TextAnalyser.Structure;

namespace TextAnalyser.BinarySearchTree
{
    public class BinarySearchNode : BaseNode
    {
        #region Members
        private BinarySearchNode left;
        private BinarySearchNode right;
        #endregion

        #region Properties
        public BinarySearchNode Left
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
            }
        }
        public BinarySearchNode Right
        {
            get
            {
                return right;
            }
            set
            {
                right = value;
            }
        }
        #endregion

        #region Contructor
        public BinarySearchNode(Item i) : base(i)
        {
            left = null;
            right = null;
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
