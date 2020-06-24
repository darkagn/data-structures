namespace DataStructures.Trees
{
    /// <summary>
    /// Specific type of tree that maintains balance such that the height of any subtree is 
    /// no greater then one more than the smallest subtree from the same node, and vice versa.
    /// This is a simple implementation that merely maintains height restriction of a balanced
    /// tree rather than ensuring that the left child is less than the node and the right child
    /// is greater than the node (ie a binary search tree).
    /// </summary>
    /// <typeparam name="T">The type of value being stored in the node of the tree.</typeparam>
    public class BalancedTree<T> : Tree<T>
    {
        /// <summary>
        /// Adds a new node to the tree with the supplied <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value to be added to the tree.</param>
        public void Add(T value)
        {
            if (IsEmpty)
            {
                mRootNode = new TreeNode<T>(value);
            }
            else
            {
                AddChild(mRootNode, value);
            }
        }

        /// <summary>
        /// Adds a child node to the supplied <paramref name="parent"/> with the given value.
        /// This implementation adds the child node to maintain the property that the left
        /// and right subtrees of the <paramref name="parent"/> have a height that differs
        /// by at most one. Extending classes such as the binary search tree will override
        /// this behaviour to maintain ordering of the comparable data.
        /// </summary>
        /// <param name="parent">The node to add the value to as a child node.</param>
        /// <param name="value">The value being added.</param>
        protected virtual void AddChild(TreeNode<T> parent, T value)
        {
            if (parent.Left == null)
            {
                parent.Left = new TreeNode<T>(parent, value);
            }
            else if (parent.Right == null)
            {
                parent.Right = new TreeNode<T>(parent, value);
            }
            else
            {
                if (Size(parent.Left) > Size(parent.Right))
                {
                    AddChild(parent.Right, value);
                }
                else
                {
                    AddChild(parent.Left, value);
                }
            }
        }

        /// <summary>
        /// Removes the supplied <paramref name="value"/> from the tree and maintains the 
        /// balanced property.
        /// </summary>
        /// <param name="value">The value to be removed from the tree.</param>
        /// <returns>True if the <paramref name="value"/> is found in the tree and removed; 
        /// false otherwise.</returns>
        /// <exception cref="TreeUnderflowException">Thrown when an attempt is made to remove 
        /// a value from an empty tree.</exception>
        public bool Remove(T value)
        {
            if (IsEmpty)
            {
                throw new TreeUnderflowException("Cannot remove from an empty tree");
            }

            TreeNode<T> node = Search(value);

            if (node == null)
            {
                return false;
            }

            RemoveNode(node);
            return true;
        }

        /// <summary>
        /// Removes the supplied <paramref name="node"/> from the tree and rebalances the resulting tree.
        /// </summary>
        /// <param name="node">The node to be removed from the tree.</param>
        protected void RemoveNode(TreeNode<T> node)
        {
            TreeNode<T> parent = node.Parent;

            if (parent == null)
            {
                // here there is only one node in the entire tree and it is the supplied node
                // so we can set the mRootNode to null since removing it will cause the tree to be empty
                mRootNode = null;
            }
            else
            {
                bool isLeft = parent.Left.Equals(node); // false => node is the right subtree of the parent

                if (node.IsLeaf)
                {
                    // simple case - remove the node and set the parent's child to null
                    if (isLeft)
                    {
                        // here the left child is the node to be removed, so set the right child to the left of the parent
                        // this will also empty the parent node's children if there was no right child
                        parent.Left = parent.Right;
                    }

                    // either way remove the right child
                    parent.Right = null;
                }
                else if (node.Right == null)
                {
                    // the node has one child - left only
                    if (isLeft)
                    {
                        // simply set the parent's left subtree to the node's left subtree
                        parent.Left = node.Left;
                    }
                    else
                    {
                        // here it is the parent's right subtree that must have the node's left subtree assigned to it
                        parent.Right = node.Left;
                    }
                }
                else
                {
                    // the node has two subtrees - left and right
                    // find the node to swap with the current node and replace it with the current node
                    TreeNode<T> swap = FindLeafNodeToSwap(node);
                    if (isLeft)
                    {
                        parent.Left = swap;
                    }
                    else
                    {
                        parent.Right = swap;
                    }

                    swap.Parent = parent;
                    swap.Left = node.Left;
                    swap.Right = node.Right;
                    if (swap.Left != null)
                    {
                        swap.Left.Parent = swap;
                    }

                    if (swap.Right != null)
                    {
                        swap.Right.Parent = swap;
                    }
                }
            }
        }

        /// <summary>
        /// This hook method finds a leaf in the <paramref name="node"/> subtrees to swap with the node being 
        /// removed from the tree.
        /// This is a simple implementation that can be overridden in extending classes to enforce further
        /// behaviour (such as a binary search tree property of left child always being less than the parent
        /// node and right child being greater than the parent).
        /// </summary>
        /// <param name="node">The node to be removed.</param>
        protected virtual TreeNode<T> FindLeafNodeToSwap(TreeNode<T> node)
        {
            if (node.IsLeaf)
            {
                // first remove the node's parent's reference to the node in order to remove a circular reference after we swap
                if (node.Parent != null)
                {
                    if (node.Parent.Left.Equals(node))
                    {
                        node.Parent.Left = node.Parent.Right;
                    }

                    node.Parent.Right = null;
                }
                return node;
            }

            bool isLeft = Height(node.Left) > Height(node.Right);

            if (isLeft)
            {
                // the left subtree of the parent needs to become both the left and right subtrees of the node
                return FindLeafNodeToSwap(node.Left);
            }
            else
            {
                // the right subtree of the parent needs to become both the left and right subtrees of the node
                return FindLeafNodeToSwap(node.Right);
            }
        }
    }
}
