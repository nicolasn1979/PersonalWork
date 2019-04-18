
using System.Collections;

namespace TextAnalyser.Structure
{
    interface IDataStructure<T>
    {
        void Insert(T i);
        void Traverse();
        void ShowReport();
    }
}
