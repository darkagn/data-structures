using DataStructures.LinkedList;

namespace DataStructures.Stacks
{
    /// <summary>
    /// Implementation of first in last out (FILO) data structure.
    /// </summary>
    /// <typeparam name="T">Indicates the type of data being stored as the value of each item in the stack.</typeparam>
    public class Stack<T>
    {
        /// <summary>
        /// Internal linked list to implement the stack.
        /// </summary>
        private SingleLinkedNode<T> mInnerList = null;

        /// <summary>
        /// Current size of the stack.
        /// </summary>
        private int mCount = 0;

        /// <summary>
        /// Returns the current size of the stack -- ReadOnly.
        /// </summary>
        public int Count
        {
            get
            {
                return mCount;
            }
        }

        /// <summary>
        /// Returns true when the stack is empty -- ReadOnly.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return mCount == 0;
            }
        }

        /// <summary>
        /// Pushes the supplied <paramref name="value"/> onto the top of the stack.
        /// </summary>
        /// <remarks>This is an O(1) operation since the size of the stack does not affect how long this operation takes.</remarks>
        /// <param name="value">The value to be added to the stack.</param>
        public void Push(T value)
        {
            mInnerList = SingleLinkedNode<T>.Instance(value, mInnerList);
            mCount++;
        }

        /// <summary>
        /// Pops the last added item from the top of the stack.
        /// </summary>
        /// <remarks>This is an O(1) operation since the size of the stack does not affect how long this operation takes.</remarks>
        /// <returns>The last item added to the stack.</returns>
        /// <exception cref="StackUnderflowException">Thrown when a call is made to an empty stack.</exception>
        public T Pop()
        {
            if (IsEmpty)
            {
                throw new StackUnderflowException("Cannot pop from an empty stack");
            }

            var returnValue = mInnerList.Value;
            mInnerList = mInnerList.Next;
            mCount--;

            return returnValue;
        }

        /// <summary>
        /// Peeks at the last item added to the top of the stack.
        /// </summary>
        /// <remarks>This is an O(1) operation since the size of the stack does not affect how long this operation takes.</remarks>
        /// <returns>The last item added to the stack.</returns>
        /// <exception cref="StackUnderflowException">Thrown when a call is made to an empty stack.</exception>
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new StackUnderflowException("Cannot peek at an empty stack");
            }

            return mInnerList.Value;
        }
    }
}
