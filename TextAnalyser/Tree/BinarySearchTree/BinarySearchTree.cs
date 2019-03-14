using TextAnalyser.Structure;

namespace TextAnalyser.BinarySearchTree
{

    /// <summary>
    /// A binary Search Tree Data representation
    /// </summary>
    public class BinarySearchTree : BaseTree
    {
        #region Constructor
        public BinarySearchTree()
        {

        }
        #endregion

        #region Interface Implements
        /// <summary>
        /// Insert an Item in the Tree
        /// </summary>
        /// <param name="i">The Item to be inserted</param>
        public override void Insert(Item i)
        {
            root = Insert((BinarySearchNode)root, i);
        }
        
        /// <summary>
        /// Traverse the Tree
        /// </summary>
        public override void Traverse()
        {
            // Clear the Report from previous traversal 
            report.Clear();

            // Let's traverse
            InOrderTraversal((BinarySearchNode)root);
        }

        #endregion 

        /// <summary>
        /// Insert an item in the Tree
        /// </summary>
        /// <param name="node">The node </param>
        /// <param name="i">The Item to be inserted</param>
        /// <returns>The created node</returns>
        private BinarySearchNode Insert(BinarySearchNode node, Item i)
        {
            // empty tree, create the new node
            if (node == null)
            {
                BinarySearchNode newNode = new BinarySearchNode(i);
                return newNode;
            }

            // Compare both items using our custom comparer
            int result = comparer.Compare(node.Item, i);

            // the same item, increment count
            if (result == 0)
            {
                node.Count++;
                return node;
            }
            // item goes to left
            else if (result > 0)
            {
                node.Left = Insert(node.Left, i);
            }
            // item goes to right
            else
            {
                node.Right = Insert(node.Right, i);
            }

            return node;
        }

        /// <summary>
        /// Traverse the Tree in order "In-Order" in a recursive way
        /// </summary>
        private void InOrderTraversal(BinarySearchNode node)
        {
            if (node != null)
            {
                // Visit Left
                InOrderTraversal(node.Left);

                // Then Current
                report.Add(node);

                // Then Right
                InOrderTraversal(node.Right);
            }
        }
    }
}
