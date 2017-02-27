using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (Tree<T>.Size(parent.Left) > Tree<T>.Size(parent.Right))
                {
                    AddChild(parent.Right, value);
                }
                else
                {
                    AddChild(parent.Left, value);
                }
            }
        }
    }
}
