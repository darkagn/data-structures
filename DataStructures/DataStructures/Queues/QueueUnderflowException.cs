using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Queues
{
    /// <summary>
    /// Exception that handles an underflow error in a queue.
    /// This occurs when an operation is performed on an empty queue, such as an attempt to dequeue.
    /// </summary>
    public class QueueUnderflowException : Exception
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
