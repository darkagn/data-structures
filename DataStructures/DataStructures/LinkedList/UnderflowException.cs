using System;

namespace DataStructures.LinkedList
{
    /// <summary>
    /// Exception that handles an underflow error in a data structure.
    /// </summary>
    public abstract class UnderflowException : Exception
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">The error message associated with the exception instance.</param>
        public UnderflowException(string message): base(message)
        {
        }
    }
}
