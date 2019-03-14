using TextAnalyser.Structure;

namespace TextAnalyser.ThreadedTree
{
    public class ThreadedTree : BaseTree
    {
        #region Constructor
        public ThreadedTree()
        {            
        }
        #endregion

        /// <summary>
        /// Insert an Item in the Tree
        /// </summary>
        /// <param name="i">The Item to be inserted</param>
        public override void Insert(Item i)
        {
            Insert((ThreadedNode)root, i);
        }
        
        /// <summary>
        /// Traverse the Tree
        /// </summary>
        public override void Traverse()
        {
            // Clear the Report from previous traversal 
            report.Clear();

            // Let's traverse
            InOrderTraversal((ThreadedNode)root);
        }

        /// <summary>
        /// Insert an item in the Tree
        /// </summary>
        /// <param name="node">The node </param>
        /// <param name="newItem">The Item to be inserted</param>
        /// <returns>The created node</returns>
        private void Insert(ThreadedNode node, Item newItem)
        {
            ThreadedNode current = node;
            ThreadedNode parent = null;

            if (root == null)
            {
                ThreadedNode newNode = new ThreadedNode(newItem);
                root = newNode;
                return;
            }

            while(current != null)
            {
                // save parent
                parent = current;

                // Compare both items using our custom comparer
                int result = comparer.Compare(current.Item, newItem);

                // the same item, increment count
                if (result == 0)
                {
                    current.Count++;
                    return;
                }

                // item goes to left
                else if (result > 0)
                {
                    current = current.Left;

                    // we found the place to insert the new Node
                    if (current == null)
                    {
                        ThreadedNode newNode = new ThreadedNode(newItem);
                        parent.Left = newNode;
                        newNode.Right = parent;
                        newNode.RightThread = true;
                        return;
                    }
                }
                // item goes to right
                else
                {
                    if (!current.RightThread)
                    {
                        current = current.Right;
                        if (current == null)
                        {
                            ThreadedNode newNode = new ThreadedNode(newItem);
                            parent.Right = newNode;
                            return;
                        }
                    }
                    else
                    {
                        ThreadedNode tmp = current.Right;
                        ThreadedNode newNode = new ThreadedNode(newItem);
                        current.Right = newNode;
                        current.RightThread = false;
                        newNode.Right = tmp;
                        newNode.RightThread = true;
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
        private ThreadedNode LeftMostNode(ThreadedNode node)
        {
            if (node == null)
                return null;

            while (node.Left != null)
                node = node.Left;

            return node;
        }

        /// <summary>
        /// Traverse the Tree using the Threaded Node relations
        /// </summary>
        private void InOrderTraversal(ThreadedNode node)
        {
            ThreadedNode current = LeftMostNode(node);
            while (current != null)
            {
                report.Add(current);

                // right node points to a inorder successor
                if (current.RightThread)
                {
                    current = current.Right;
                }

                // find the leftiest Node of current right Node
                else
                {
                    current = LeftMostNode(current.Right);
                }
            }

        }
    }
}
