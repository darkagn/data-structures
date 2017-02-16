using DataStructures.LinkedList;

namespace DataStructures.Queues
{
    /// <summary>
    /// Implementation of a first in first out (FIFO) queue data structure.
    /// </summary>
    public class Queue<T>
    {
        /// <summary>
        /// Internal linked list to implement the queue.
        /// </summary>
        private SingleLinkedNode<T> mInnerList = null;

        /// <summary>
        /// Returns the current count of items in the queue -- ReadOnly.
        /// </summary>
        public int Count
        {
            get
            {
                return SingleLinkedNode<T>.Length(mInnerList);
            }
        }

        /// <summary>
        /// Returns true if the queue is currently empty -- ReadOnly.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return mInnerList == null;
            }
        }

        /// <summary>
        /// Adds the supplied <paramref name="value"/> to the end of the queue.
        /// </summary>
        /// <param name="value">The value to be added.</param>
        public void Enqueue(T value)
        {
            SingleLinkedNode<T> node = SingleLinkedNode<T>.Instance(value, null);
            if (IsEmpty)
            {
                mInnerList = node;
            }
            else
            {
                mInnerList.Last().Next = node;
            }
        }

        /// <summary>
        /// Removes the first item from the queue and returns it.
        /// </summary>
        /// <returns>The first item in the queue.</returns>
        /// <exception cref="QueueUnderflowException">Thrown when this function is called on an empty queue.</exception>
        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new QueueUnderflowException("Cannot dequeue an empty queue");
            }

            T returnValue = mInnerList.Value;
            mInnerList = mInnerList.Next;

            return returnValue;
        }

        /// <summary>
        /// Returns the first item in the queue without removing it.
        /// </summary>
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
    }
}
