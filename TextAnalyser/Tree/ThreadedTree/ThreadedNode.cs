using System;
using TextAnalyser.Structure;
using TextAnalyser.Tree.ThreadedTree;

namespace TextAnalyser.ThreadedTree
{
    public class ThreadedNode<T> : BaseNode<T>, IThreadedNode<T>
    {
        #region Members
        bool rightThread;
        #endregion


        #region Contructor
        public ThreadedNode(T i) : base (i)
        {
            rightThread = false;
            left = null;
            right = null;
        }

        public bool GetRightThread()
        {
            return rightThread;
        }

        public void SetRightThread(bool value)
        {
            rightThread = value;
        }
        #endregion
    }
}
