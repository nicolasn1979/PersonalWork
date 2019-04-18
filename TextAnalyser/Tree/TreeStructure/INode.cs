using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyser.Tree.TreeStructure
{
    public interface INode<T>
    {
        void IncrementCount();
        int GetCount();
        T GetItem();
        INode<T> GetLeft();
        void SetLeft(INode<T> node);
        INode<T> GetRight();
        void SetRight(INode<T> node);

    }

}