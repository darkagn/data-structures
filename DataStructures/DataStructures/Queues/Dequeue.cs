using DataStructures.LinkedList;

namespace DataStructures.Queues
{
    /// <summary>
    /// A double ended queue implementation where items can be enqueued and dequeued at either end
    /// rather than following the FIFO rule of the standard <see cref="Queue{T}"/>.
    /// Internal structure of this implementation uses a double linked list rather than the parent's single linked list.
    /// </summary>
    /// <typeparam name="T">Indicates the type of data being stored as the value of each item in the queue.</typeparam>
    public class Dequeue<T> : Queue<T>
    {
        /// <summary>
        /// Enqueues an item at the front of the queue.
        /// </summary>
        /// <remarks>This is an O(1) operation since the size of the queue does not matter.</remarks>
        /// <param name="value">The item to be added.</param>
        public void EnqueueFirst(T value)
        {
            SingleLinkedNode<T> node = CreateNode(value);
            node.Next = mInnerList;

            if (IsEmpty)
            {
                mLast = node;
            }
            else
            {
                SetPrevious(mInnerList, node);
            }

            mInnerList = node;
            mCount++;
        }

        /// <summary>
        /// Dequeues the last item in the queue.
        /// </summary>
        /// <remarks>This is an O(1) operation since it is not dependent on the size of the queue.</remarks>
        /// <returns>The last item in the queue.</returns>
        /// <exception cref="QueueUnderflowException">Thrown when an attempt to dequeue an empty queue is made.</exception>
        public T DequeueLast()
        {
            if (IsEmpty)
            {
                throw new QueueUnderflowException("Cannot dequeue an empty queue");
            }

            T returnValue = PeekLast();

            if (mLast.GetType() == typeof(DoubleLinkedNode<T>))
            {
                DoubleLinkedNode<T> last = (DoubleLinkedNode<T>)mLast;
                if (last.Previous != null)
                {
                    last.Previous.Next = null;
                }

                mLast = last.Previous;
                if (mLast == null)
                {
                    mInnerList = null;
                }
            }

            mCount--;

            return returnValue;
        }

        /// <summary>
        /// Returns the last item in the queue without modifying the queue itself.
        /// </summary>
        /// <returns>The last item in the queue.</returns>
        /// <exception cref="QueueUnderflowException">Thrown when an attempt to peek at an empty queue is made.</exception>
        public T PeekLast()
        {
            if (IsEmpty)
            {
                throw new QueueUnderflowException("Cannot peek an empty queue");
            }

            return mLast.Value;
        }

        /// <summary>
        /// Overrides the hook method that creates the details of the node that represents the supplied <paramref name="value"/>.
        /// This override ensures that the internal implementation utilises a double linked list.
        /// </summary>
        /// <param name="value">The value to be stored in the queue.</param>
        /// <returns>The node for the queue.</returns>
        protected override SingleLinkedNode<T> CreateNode(T value)
        {
            return DoubleLinkedNode<T>.Instance(value, null, null);
        }

        /// <summary>
        /// Overrides the hook method to set the previous node for an any implementation that uses a double linked list.
        /// This override ensures that the double linked list Previous node reference is maintained.
        /// </summary>
        /// <param name="newNode">The new node.</param>
        /// <param name="previousNode">The node being set as the new node's previous node.</param>
        protected override void SetPrevious(SingleLinkedNode<T> newNode, SingleLinkedNode<T> previousNode)
        {
            if (newNode != null && newNode.GetType() == typeof(DoubleLinkedNode<T>))
            {
                if (previousNode == null)
                {
                    ((DoubleLinkedNode<T>)newNode).Previous = null;
                }
                else if (previousNode.GetType() == typeof(DoubleLinkedNode<T>))
                {
                    ((DoubleLinkedNode<T>)newNode).Previous = (DoubleLinkedNode<T>)previousNode;
                }
            }
        }
    }
}
