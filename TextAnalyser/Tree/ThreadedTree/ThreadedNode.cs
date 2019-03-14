using System;
using TextAnalyser.Structure;

namespace TextAnalyser.ThreadedTree
{
    public class ThreadedNode : BaseNode
    {
        #region Members
        private ThreadedNode left;
        private ThreadedNode right;
        Boolean rightThread;
        #endregion

        #region Properties
        public ThreadedNode Left
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
        public ThreadedNode Right
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
        public Boolean RightThread
        {
            get
            {
                return rightThread;
            }
            set
            {
                rightThread = value;
            }
        }

        #endregion

        #region Contructor
        public ThreadedNode(Item i) : base (i)
        {
            rightThread = false;
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
