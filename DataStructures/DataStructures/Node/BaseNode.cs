using System;

namespace DataStructures.Node
{
    /// <summary>
    /// A base class representing a node in a data structure. A node is defined
    /// as a point in the data structure that contains a value.
    /// </summary>
    /// <typeparam name="T">Indicates the type of data being stored as the value of the node.</typeparam>
    public class BaseNode<T> : IDisposable
    {
        /// <summary>
        /// Base constructor.
        /// </summary>
        /// <param name="value">Value being represented by this node.</param>
        protected BaseNode(T value)
        {
            Value = value;
        }

        /// <summary>
        /// The value of this node -- ReadOnly.
        /// </summary>
        public T Value
        {
            get;
            private set;
        }

        /// <summary>
        /// Hook method to dispose of the instance.
        /// </summary>
        public virtual void Dispose()
        {
        }

        /// <summary>
        /// Returns a string representation of the instance.
        /// </summary>
        /// <returns>A string representation of the instance.</returns>
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
