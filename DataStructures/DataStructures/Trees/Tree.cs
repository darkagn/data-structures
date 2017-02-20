using System;
using DataStructures.Queues;
using DataStructures.Stacks;

namespace DataStructures.Trees
{
    /// <summary>
    /// Implementation of a tree data structure.
    /// </summary>
    /// <typeparam name="T">The type of data being represented by the tree.</typeparam>
    public class Tree<T> : IDisposable
    {
        /// <summary>
        /// The root of the tree.
        /// </summary>
        protected TreeNode<T> mRootNode;

        /// <summary>
        /// Constructor that generates an empty tree.
        /// </summary>
        public Tree()
            : this(null)
        {

        }

        /// <summary>
        /// Constructor that specifies a root node for the tree.
        /// </summary>
        /// <param name="rootNode">The root of the tree.</param>
        public Tree(TreeNode<T> rootNode)
        {
            mRootNode = rootNode;
        }

        /// <summary>
        /// Returns true if the tree is empty -- ReadOnly.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return mRootNode == null;
            }
        }

        /// <summary>
        /// Returns the size of the subtree where the supplied <paramref name="node"/> is the root.
        /// </summary>
        /// <param name="node">The root of the subtree being queried.</param>
        /// <returns>The size of the subtree.</returns>
        private static int Size(TreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return Size(node.Left) + Size(node.Right) + 1;
            }
        }

        /// <summary>
        /// Returns the size of the entire tree.
        /// </summary>
        /// <returns>The size of the entire tree.</returns>
        public int Size()
        {
            return Tree<T>.Size(this.mRootNode);
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        public void Dispose()
        {
            mRootNode = null;
        }

        /// <summary>
        /// Returns a string representation of the entire tree.
        /// </summary>
        /// <returns>A string representation of the instance.</returns>
        public override string ToString()
        {
            return Tree<T>.Print(mRootNode);
        }

        /// <summary>
        /// Returns a string representation of the subtree where the supplied <paramref name="node"/> is the root of the subtree.
        /// </summary>
        /// <param name="node">The root of the subtree to be parsed.</param>
        /// <returns>The string representation of the subtree.</returns>
        private static string Print(TreeNode<T> node)
        {
            var output = new System.Collections.Generic.List<string>();

            if (node != null)
            {
                if (node.Left != null)
                {
                    output.Add(Tree<T>.Print(node.Left));
                }

                output.Add(node.Value.ToString());

                if (node.Right != null)
                {
                    output.Add(Tree<T>.Print(node.Right));
                }
            }

            return string.Join(", ", output);
        }

        /// <summary>
        /// Returns the height of the subtree where the supplied <paramref name="node"/> is the root of the subtree.
        /// </summary>
        /// <param name="node">The root of the subtree to be determined.</param>
        /// <returns>The height of the subtree.</returns>
        private static int Height(TreeNode<T> node)
        {
            if (node == null)
            {
                return -1;
            }
            else
            {
                return Math.Max(Tree<T>.Height(node.Left), Tree<T>.Height(node.Right)) + 1;
            }
        }

        /// <summary>
        /// Determines the height of the entire tree.
        /// </summary>
        /// <returns>The height of the instance.</returns>
        public int Height()
        {
            return Tree<T>.Height(mRootNode);
        }

        /// <summary>
        /// Searches the tree for the supplied <paramref name="value"/> and returns the node that stores it, if found.
        /// </summary>
        /// <param name="value">The value being searched for.</param>
        /// <param name="depthFirstSearch">True (default) indicates that the search uses a depth first traversal.
        /// False indicates that the search uses a breadth first traversal instead.</param>
        /// <returns>The node with the supplied <paramref name="value"/>, if found; <c>null</c> otherwise.</returns>
        public TreeNode<T> Search(T value, bool depthFirstSearch = true)
        {
            if (depthFirstSearch)
            {
                return this.DepthFirstSearch(value);
            }
            else
            {
                return this.BreadthFirstSearch(value);
            }
        }

        /// <summary>
        /// Performs a depth first search of the tree.
        /// </summary>
        /// <param name="value">The value being searched for.</param>
        /// <returns>The node with the supplied <paramref name="value"/> if found; <c>null</c> otherwise.</returns>
        public TreeNode<T> DepthFirstSearch(T value)
        {
            if (!IsEmpty)
            {
                Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
                stack.Push(mRootNode);

                while (stack.Count > 0)
                {
                    var node = stack.Pop();
                    if (node.Value.Equals(value))
                    {
                        return node;
                    }

                   if (node.Left != null)
                    {
                        stack.Push(node.Left);
                    }

                    if (node.Right != null)
                    {
                        stack.Push(node.Right);
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Performs a breadth first search on the tree.
        /// </summary>
        /// <param name="value">The value being searched for.</param>
        /// <returns>The node with the supplied <paramref name="value"/> if found; <c>null</c> otherwise.</returns>
        public TreeNode<T> BreadthFirstSearch(T value)
        {
            if (!IsEmpty)
            {
                Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
                queue.Enqueue(mRootNode);

                while (queue.Count > 0)
                {
                    var node = queue.Dequeue();
                    if (node.Value.Equals(value))
                    {
                        return node;
                    }
                    
                    if (node.Left != null)
                    {
                        queue.Enqueue(node.Left);
                    }

                    if (node.Right != null)
                    {
                        queue.Enqueue(node.Right);
                    }
                }
            }
            
            return null;
        }
    }
}
