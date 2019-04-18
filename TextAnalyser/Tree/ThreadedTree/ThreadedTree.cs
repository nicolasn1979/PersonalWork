using System.Collections.Generic;
using TextAnalyser.Tree.ThreadedTree;
using TextAnalyser.TreeStructure;

namespace TextAnalyser.ThreadedTree
{
    public class ThreadedTree<T> : BaseTree<T>
    {

        public ThreadedTree(IComparer<T> comp) : base(comp)
        {

        }

        /// <summary>
        /// Insert an Item in the Tree
        /// </summary>
        /// <param name="i">The Item to be inserted</param>
        public override void Insert(T i)
        {
            Insert(root as IThreadedNode<T>, i);
        }
        
        /// <summary>
        /// Traverse the Tree
        /// </summary>
        public override void Traverse()
        {
            // Clear the Report from previous traversal 
            report.Clear();

            // Let's traverse
            InOrderTraversal(root as IThreadedNode<T>);
        }

        /// <summary>
        /// Insert an item in the Tree
        /// </summary>
        /// <param name="node">The node </param>
        /// <param name="newItem">The Item to be inserted</param>
        /// <returns>The created node</returns>
        private void Insert(IThreadedNode<T> node, T newItem)
        {           
            if (root == null)
            {
                IThreadedNode<T> newNode = new ThreadedNode<T>(newItem);
                root = newNode;
                return;
            }

            IThreadedNode<T> current = node;
            IThreadedNode<T> parent = null;
            while (current != null)
            {
                // save parent
                parent = current;

                // Compare both items using our custom comparer
                int result = comparer.Compare(current.GetItem(), newItem);

                // the same item, increment count
                if (result == 0)
                {
                    current.IncrementCount();
                    return;
                }

                // item goes to left
                else if (result > 0)
                {
                    current = current.GetLeft() as IThreadedNode<T>;

                    // we found the place to insert the new Node
                    if (current == null)
                    {
                        IThreadedNode<T> newNode = new ThreadedNode<T>(newItem);
                        parent.SetLeft(newNode);
                        newNode.SetRight(parent);
                        newNode.SetRightThread(true);
                        return;
                    }
                }
                // item goes to right
                else
                {
                    if (!current.GetRightThread())
                    {
                        current = (IThreadedNode<T>)current.GetRight();
                        if (current == null)
                        {
                            IThreadedNode<T> newNode = new ThreadedNode<T>(newItem);
                            parent.SetRight(newNode);
                            return;
                        }
                    }
                    else
                    {
                        IThreadedNode<T> tmp = current.GetRight() as IThreadedNode<T>;
                        IThreadedNode<T> newNode = new ThreadedNode<T>(newItem);
                        current.SetRight(newNode);
                        current.SetRightThread(false);
                        newNode.SetRight(tmp);
                        newNode.SetRightThread(true);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Find the Left Most Node
        /// </summary>
        /// <param name="node">The current Node</param>
        /// <returns></returns>
        private IThreadedNode<T> LeftMostNode(IThreadedNode<T> node)
        {
            if (node == null)
                return null;

            while (node.GetLeft() != null)
                node = node.GetLeft() as IThreadedNode<T>;

            return node;
        }

        /// <summary>
        /// Traverse the Tree using the Threaded Node relations
        /// </summary>
        private void InOrderTraversal(IThreadedNode<T> node)
        {
            IThreadedNode<T> current = LeftMostNode(node);
            while (current != null)
            {
                report.Add(current);

                // right node points to a inorder successor
                if (current.GetRightThread())
                {
                    current = current.GetRight() as IThreadedNode<T>;
                }

                // find the leftiest Node of current right Node
                else
                {
                    current = LeftMostNode(current.GetRight() as IThreadedNode<T>);
                }
            }

        }
    }
}
