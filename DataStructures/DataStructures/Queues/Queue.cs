using DataStructures.LinkedList;

namespace DataStructures.Queues
{
    /// <summary>
    /// Implementation of a first in first out (FIFO) queue data structure.
    /// </summary>
    /// <typeparam name="T">Indicates the type of data being stored as the value of each item in the queue.</typeparam>
    public class Queue<T>
    {
        /// <summary>
        /// Internal linked list to implement the queue.
        /// </summary>
        protected SingleLinkedNode<T> mInnerList = null;

        /// <summary>
        /// Internal reference to the last node added to the queue.
        /// </summary>
        protected SingleLinkedNode<T> mLast = null;

        /// <summary>
        /// Internal count of items in the queue.
        /// </summary>
        protected int mCount = 0;

        /// <summary>
        /// Returns the current count of items in the queue -- ReadOnly.
        /// </summary>
        /// <remarks>This is an O(1) operation as it is being stored as a member variable rather than being calculated via
        /// the <see cref="SingleLinkedNode{T}.Length(SingleLinkedNode{T})"/> function which is O(n).</remarks>
        public int Count => mCount;

        /// <summary>
        /// Returns true if the queue is currently empty -- ReadOnly.
        /// </summary>
        /// <remarks>This is an O(1) operation since it is a simple check for the null internal list.</remarks>
        public bool IsEmpty => mInnerList == null;

        /// <summary>
        /// Adds the supplied <paramref name="value"/> to the end of the queue.
        /// </summary>
        /// <remarks>This is an O(1) operation as it does not depend on the size of the queue to add a new item.</remarks>
        /// <param name="value">The value to be added.</param>
        public void Enqueue(T value)
        {
            SingleLinkedNode<T> node = CreateNode(value);

            if (IsEmpty)
            {
                mInnerList = node;
            }
            else
            {
                mLast.Next = node;
                SetPrevious(node, mLast);
            }

            mLast = node;

            mCount++;
        }

        /// <summary>
        /// Removes the first item from the queue and returns it.
        /// </summary>
        /// <remarks>This is an O(1) operation as it does not depend on the size of the queue to remove an item.</remarks>
        /// <returns>The first item in the queue.</returns>
        /// <exception cref="QueueUnderflowException">Thrown when this function is called on an empty queue.</exception>
        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new QueueUnderflowException("Cannot dequeue an empty queue");
            }

            T returnValue = Peek();
            mInnerList = mInnerList.Next;

            if (IsEmpty)
            {
                mLast = null;
            }
            else
            {
                SetPrevious(mInnerList, null);
            }

            mCount--;

            return returnValue;
        }

        /// <summary>
        /// Returns the first item in the queue without removing it.
        /// </summary>
        /// <remarks>This is an O(1) operation because it is not dependent upon the size of the queue.</remarks>
        /// <returns>The first item in the queue.</returns>
        /// <exception cref="QueueUnderflowException">Thrown when this function is called on an empty queue.</exception>
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new QueueUnderflowException("Cannot peek in an empty queue");
            }

            return mInnerList.Value;
        }

        /// <summary>
        /// Returns a string representation of the queue.
        /// </summary>
        /// <returns>The string representation of the queue.</returns>
        public override string ToString()
        {
            return mInnerList.ToString();
        }

        /// <summary>
        /// Hook method that creates the details of the node that represents the supplied <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value to be stored in the queue.</param>
        /// <returns>The node for the queue.</returns>
        protected virtual SingleLinkedNode<T> CreateNode(T value)
        {
            return SingleLinkedNode<T>.Instance(value, null);
        }

        /// <summary>
        /// Hook method to set the previous node for an any implementation that uses a double linked list.
        /// </summary>
        /// <param name="newNode">The new node.</param>
        /// <param name="previousNode">The node being set as the new node's previous node.</param>
        protected virtual void SetPrevious(SingleLinkedNode<T> newNode, SingleLinkedNode<T> previousNode)
        {
            // this implementation uses single linked list, so this method does nothing here
        }
    }
}
