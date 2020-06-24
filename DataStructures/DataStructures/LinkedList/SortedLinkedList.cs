using System;

namespace DataStructures.LinkedList
{
    /// <summary>
    /// The sorted linked list maintains sort order of elements (nodes).
    /// It uses the <see cref="DoubleLinkedNode{T}"/> but maintains the order of
    /// element values.
    /// </summary>
    /// <typeparam name="T">Indicates the type of data being stored as the value
    /// of each item in the list.</typeparam>
    public class SortedLinkedList<T> where T: IComparable
    {
        /// <summary>
        /// Internal linked list to implement the queue.
        /// </summary>
        protected DoubleLinkedNode<T> mInnerList = null;

        /// <summary>
        /// Internal count of items in the queue.
        /// </summary>
        protected int mCount = 0;

        /// <summary>
        /// Returns the current count of items in the list -- ReadOnly.
        /// </summary>
        /// <remarks>
        /// This is an O(1) operation as it is being stored as a member
        /// variable rather than being calculated via the
        /// <see cref="DoubleLinkedNode{T}.Length(DoubleLinkedNode{T})"/>
        /// function which is O(n).
        /// </remarks>
        public int Count => mCount;

        /// <summary>
        /// Returns true if the list is currently empty -- ReadOnly.
        /// </summary>
        /// <remarks>This is an O(1) operation since it is a simple check for
        /// the null internal list.</remarks>
        public bool IsEmpty => mInnerList == null;

        /// <summary>
        /// Adds the value to the list, maintaining order.
        /// </summary>
        /// <remarks>
        /// This is an O(n) operation in the worst-case scenario.
        /// </remarks>
        /// <param name="value">The value to be added to the list.</param>
        public void Add(T value)
        {
            DoubleLinkedNode<T> newNode = CreateNode(value);
            DoubleLinkedNode<T> node = mInnerList;

            while (node != null && value.CompareTo(node.Value) < 1)
            {
                node = (DoubleLinkedNode<T>)node.Next;
            }

            if (node == null)
            {
                mInnerList = newNode;
            }
            else
            {
                node.Previous.Next = newNode;
                node.Previous = newNode;
                newNode.Next = node;
            }

            mCount++;
        }

        /// <summary>
        /// Removes the value from the list, if found.
        /// </summary>
        /// <remarks>
        /// This is an O(n) operation in the worst-case scenario.
        /// </remarks>
        /// <param name="value">The value to be removed from the list.</param>
        /// <returns>True if the value is removed; false otherwise.</returns>
        public bool Remove(T value)
        {
            DoubleLinkedNode<T> node = Search(value);

            if (node == null)
            {
                return false;
            }

            if (node.Previous == null && node.Next == null)
            {
                mInnerList = null;
            }

            DoubleLinkedNode<T> tempNode = node.Previous;

            if (node.Previous != null)
            {
                node.Previous.Next = node.Next;
            }

            if (node.Next != null)
            {
                ((DoubleLinkedNode<T>)node.Next).Previous = tempNode;
            }
            
            mCount--;

            return true;
        }

        /// <summary>
        /// Searches the list for the value and returns the node if found.
        /// </summary>
        /// <param name="value">
        /// The value being searched for in the list.
        /// </param>
        /// <returns>The node with the supplied value if found; or <c>null</c>
        /// otherwise.</returns>
        public DoubleLinkedNode<T> Search(T value)
        {
            DoubleLinkedNode<T> node = mInnerList;

            while (node != null && value.CompareTo(node.Value) < 0)
            {
                node = (DoubleLinkedNode<T>)node.Next;
            }

            return node != null && value.CompareTo(node.Value) == 0 ? node : null;
        }

        /// <summary>
        /// Returns a string representation of the list.
        /// </summary>
        /// <returns>The string representation of the list.</returns>
        public override string ToString()
        {
            return mInnerList.ToString();
        }

        /// <summary>
        /// Hook method that creates the details of the node that represents the
        /// supplied <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value to be stored in the queue.</param>
        /// <returns>The node for the queue.</returns>
        protected virtual DoubleLinkedNode<T> CreateNode(T value)
        {
            return DoubleLinkedNode<T>.Instance(value, null, null);
        }
    }
}
