using System;

namespace DataStructures.LinkedList
{
    /// <summary>
    /// Extension of the <see cref="SingleLinkedNode{T}"/> class that allows for two-way traversal of the resulting linked list.
    /// </summary>
    /// <typeparam name="T">Indicates the type of data being stored as the value of the node.</typeparam>
    public class DoubleLinkedNode<T> : SingleLinkedNode<T>, IDisposable
    {
        /// <summary>
        /// A pointer to the previous node in the list.
        /// If this value is <c>null</c>, this indicates that the node is the first one in the list.
        /// </summary>
        public DoubleLinkedNode<T> Previous
        {
            get;
            set;
        }

        /// <summary>
        /// Returns true if the node is the first one in the list -- ReadOnly.
        /// A return value of false indicates that the node has ancestor nodes.
        /// </summary>
        public bool IsHeader => Previous == null;

        /// <summary>
        /// Returns the first ancestor node in the list.
        /// </summary>
        /// <returns>The header node in the list.</returns>
        public DoubleLinkedNode<T> Head()
        {
            return IsHeader ? this : Previous.Head();
        }

        /// <summary>
        /// Overrides the parent hook method to ensure that the <paramref name="next"/> node in the list is of type <c>DoubleLinkedNode&lt;T&gt;</c>
        /// </summary>
        /// <param name="next">A pointer to the next node in the list.</param>
        /// <exception cref="ArgumentException">Thrown when the supplied <paramref name="next"/> node is not of type <c>DoubleLinkedNode&lt;T&gt;</c>.</exception>
        protected override void SetNext(SingleLinkedNode<T> next)
        {
            if (next == null || next.GetType() == typeof(DoubleLinkedNode<T>))
            {
                base.SetNext(next);
            }
            else
            {
                throw new ArgumentException("Must by of type DoubleLinkedNode", "next");
            }
        }

        /// <summary>
        /// Returns an instance of the node with the supplied <paramref name="value"/> and a pointer to the <paramref name="previous"/> 
        /// and <paramref name="next"/> nodes in the list.
        /// </summary>
        /// <param name="value">The value of the node.</param>
        /// <param name="previous">A pointer to the previous node in the list.</param>
        /// <param name="next">A pointer to the next node in the list.</param>
        /// <returns>An instance of the node.</returns>
        public static DoubleLinkedNode<T> Instance(T value, DoubleLinkedNode<T> previous, DoubleLinkedNode<T> next)
        {
            DoubleLinkedNode<T> node = new DoubleLinkedNode<T>
            {
                Value = value,
                Previous = previous,
                Next = next
            };

            return node;
        }

        /// <summary>
        /// Creates a list of nodes from the supplied <paramref name="array"/>.
        /// </summary>
        /// <param name="array">The array of values to be converted to a linked list.</param>
        /// <returns>A linked list of nodes representing the supplied <paramref name="array"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the supplied <paramref name="array"/> is <c>null</c>.</exception>
        public static new DoubleLinkedNode<T> CreateFromArray(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            DoubleLinkedNode<T> returnVal = null;
            DoubleLinkedNode<T> previous = null;

            for (int i = 0; i < array.Length; i++)
            {
                DoubleLinkedNode<T> node = Instance(array[i], previous, null);
                if (previous == null)
                {
                    returnVal = node;
                }
                else
                {
                    previous.Next = node;
                }

                previous = node;
            }

            return returnVal;
        }

        /// <summary>
        /// Removes all references to other <c>DoubleLinkedNode</c> instances to aid garbage collection.
        /// </summary>
        public override void Dispose()
        {
            Previous = null;
            base.Dispose();
        }
    }
}
