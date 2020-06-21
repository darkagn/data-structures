using DataStructures.LinkedList;

namespace DataStructures.Queues
{
    /// <summary>
    /// Exception that handles an underflow error in a queue.
    /// This occurs when an operation is performed on an empty queue, such as an attempt to dequeue.
    /// </summary>
    public class QueueUnderflowException : UnderflowException
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">The error message associated with the exception instance.</param>
        public QueueUnderflowException(string message) : base(message)
        {
        }
    }
}
