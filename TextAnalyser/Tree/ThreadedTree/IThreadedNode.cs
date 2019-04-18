using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAnalyser.Tree.TreeStructure;

namespace TextAnalyser.Tree.ThreadedTree
{
    public interface IThreadedNode<T> : INode<T>
    {
        bool GetRightThread();
        void SetRightThread(bool value);
    }
}
