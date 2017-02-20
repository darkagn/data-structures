using System;

namespace DataStructures.Stacks
{
    /// <summary>
    /// Exception that handles an underflow error in a stack.
    /// This occurs when an operation is performed on an empty stack, such as an attempt to pop an item from the stack.
    /// </summary>
    public class StackUnderflowException : Exception
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">The error message associated with the exception instance.</param>
        public StackUnderflowException(string message) : base(message)
        {

        }
    }
}
