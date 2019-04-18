using System.Collections.Generic;
using TextAnalyser.Structure;
using TextAnalyser.Tree.TreeStructure;
using TextAnalyser.TreeStructure;

namespace TextAnalyser.BinarySearchTree
{

    /// <summary>
    /// A binary Search Tree Data representation
    /// </summary>
    public class BinarySearchTree<T> : BaseTree<T>
    {
        #region Constructor
        public BinarySearchTree(IComparer<T> comp) : base(comp)
        {
            
        }
        #endregion

        #region Interface Implements
        /// <summary>
        /// Insert an Item in the Tree
        /// </summary>
        /// <param name="i">The Item to be inserted</param>
        public override void Insert(T i)
        {
            root = Insert(root, i);
        }
        
        /// <summary>
        /// Traverse the Tree
        /// </summary>
        public override void Traverse()
        {
            // Clear the Report from previous traversal 
            report.Clear();

            // Let's traverse
            InOrderTraversal(root);
        }

        #endregion 

        /// <summary>
        /// Insert an item in the Tree
        /// </summary>
        /// <param name="node">The node </param>
        /// <param name="i">The Item to be inserted</param>
        /// <returns>The created node</returns>
        private INode<T> Insert(INode<T> node, T i)
        {
            // empty tree, create the new node
            if (node == null)
            {
                BaseNode<T> newNode = new BaseNode<T>(i);
                return newNode;
            }

            // Compare both items using our custom comparer
            int result = comparer.Compare(node.GetItem(), i);

            // the same item, increment count
            if (result == 0)
            {
                node.IncrementCount();
                return node;
            }
            // item goes to left
            else if (result > 0)
            {
                node.SetLeft(Insert(node.GetLeft(), i));
            }
            // item goes to right
            else
            {
                node.SetRight(Insert(node.GetRight(), i));
            }

            return node;
        }

        /// <summary>
        /// Traverse the Tree in order "In-Order" in a recursive way
        /// </summary>
        private void InOrderTraversal(INode<T> node)
        {
            if (node != null)
            {
                // Visit Left
                InOrderTraversal(node.GetLeft());

                // Then Current
                report.Add(node);

                // Then Right
                InOrderTraversal(node.GetRight());
            }
        }
    }
}
