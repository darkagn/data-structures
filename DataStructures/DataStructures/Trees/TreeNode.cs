using DataStructures.Node;

namespace DataStructures.Trees
{
    /// <summary>
    /// A node represents a data point in the tree.
    /// </summary>
    /// <typeparam name="T">The type of data being held in the node.</typeparam>
    public class TreeNode<T> : BaseNode<T>
    {
        /// <summary>
        /// Constructor for the root node of a tree.
        /// </summary>
        /// <param name="value">The value being stored in the node.</param>
        public TreeNode(T value)
            : this(null, value)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="parent">The parent of the new node.</param>
        /// <param name="value">The value being stored.</param>
        public TreeNode(TreeNode<T> parent, T value)
            : base(value)
        {
            Parent = parent;
            Left = null;
            Right = null;
        }

        /// <summary>
        /// Gets/Sets the parent node for this instance.
        /// </summary>
        public TreeNode<T> Parent
        {
            get;
            set;
        }

        /// <summary>
        /// Gets/Sets the left child branch of this instance.
        /// </summary>
        public TreeNode<T> Left
        {
            get;
            set;
        }

        /// <summary>
        /// Gets/Sets the right child branch of this instance.
        /// </summary>
        public TreeNode<T> Right
        {
            get;
            set;
        }

        /// <summary>
        /// Returns true if the node is a leaf of the tree -- ReadOnly.
        /// </summary>
        public bool IsLeaf => Left == null && Right == null;

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        public override void Dispose()
        {
            Left = null;
            Right = null;
            Parent = null;
        }
    }
}
