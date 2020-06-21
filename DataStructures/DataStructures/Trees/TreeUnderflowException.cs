using DataStructures.LinkedList;

namespace DataStructures.Trees
{
    /// <summary>
    /// Exception that handles an underflow error in a tree.
    /// This occurs when an operation is performed on an empty tree, such as an attempt to remove an item from the tree.
    /// </summary>
    public class TreeUnderflowException : UnderflowException
    {
        /// <summary>
        /// Constructor with message.
        /// </summary>
        /// <param name="message">The error message to associate with the exception.</param>
        public TreeUnderflowException(string message)
            : base(message)
        {
        }
    }
}
