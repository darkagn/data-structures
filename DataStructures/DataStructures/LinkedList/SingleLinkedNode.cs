using System;
using System.Collections.Generic;
using DataStructures.Node;

namespace DataStructures.LinkedList
{
    /// <summary>
    /// A single linked list where each node has a value and a next node property.
    /// </summary>
    /// <typeparam name="T">Indicates the type of data being stored as the value of the node.</typeparam>
    public class SingleLinkedNode<T> : BaseNode<T>
    {
        /// <summary>
        /// A pointer to the next node in the list.
        /// </summary>
        protected SingleLinkedNode<T> mNext;

        /// <summary>
        /// Base constructor.
        /// </summary>
        /// <param name="value">Value being represented by this node.</param>
        protected SingleLinkedNode(T value)
            : this(value, null)
        {
        }

        /// <summary>
        /// Constructor specifying link to next node in the list.
        /// </summary>
        /// <param name="value">Value being represented by this node.</param>
        /// <param name="next">The next node.</param>
        protected SingleLinkedNode(T value, SingleLinkedNode<T> next)
            : base(value)
        {
            SetNext(next);
        }

        /// <summary>
        /// A pointer to the next node in the list.
        /// If this value is <c>null</c>, this indicates that the node is the last one in the list.
        /// </summary>
        public SingleLinkedNode<T> Next
        {
            get => mNext;

            set => SetNext(value);
        }

        /// <summary>
        /// Returns true if the node is the last one in the list -- ReadOnly.
        /// A return value of false indicates that the node has child nodes.
        /// </summary>
        public bool IsLast => Next == null;

        /// <summary>
        /// Returns the last descendant node in the list.
        /// </summary>
        /// <returns>The tail node in the list.</returns>
        public SingleLinkedNode<T> Last()
        {
            return IsLast ? this : Next.Last();
        }

        /// <summary>
        /// Hook method to provide a way to set the <paramref name="next"/> node in the list.
        /// </summary>
        /// <param name="next">A pointer to the next node in the list.</param>
        protected virtual void SetNext(SingleLinkedNode<T> next)
        {
            mNext = next;
        }

        /// <summary>
        /// Outputs a string representation of the linked list.
        /// </summary>
        /// <returns>A string representation of the node and its child nodes.</returns>
        public override string ToString()
        {
            List<string> output = new List<string>
            {
                base.ToString()
            };

            if (!IsLast)
            {
                // recursive call to next value in the list
                output.Add(Next.ToString());
            }

            return string.Join(", ", output);
        }

        /// <summary>
        /// Returns the current length of the supplied <paramref name="node"/>.
        /// </summary>
        /// <param name="node">A pointer to the header of the list.</param>
        /// <returns>The length of the current node.</returns>
        public static int Length(SingleLinkedNode<T> node)
        {
            int length = 0;
            if (node != null)
            {
                length += 1 + Length(node.Next);
            }

            return length;
        }

        /// <summary>
        /// Returns an instance of the node with the supplied <paramref name="value"/> and a pointer to the <paramref name="next"/> node in the list.
        /// </summary>
        /// <param name="value">The value of the node.</param>
        /// <param name="next">A pointer to the next node in the list.</param>
        /// <returns>An instance of the node.</returns>
        public static SingleLinkedNode<T> Instance(T value, SingleLinkedNode<T> next)
        {
            return new SingleLinkedNode<T>(value, next);
        }

        /// <summary>
        /// Creates a list of nodes from the supplied <paramref name="array"/>.
        /// </summary>
        /// <param name="array">The array of values to be converted to a linked list.</param>
        /// <returns>A linked list of nodes representing the supplied <paramref name="array"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the supplied <paramref name="array"/> is <c>null</c>.</exception>
        public static SingleLinkedNode<T> CreateFromArray(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            SingleLinkedNode<T> next = null;

            for(int i = array.Length - 1; i >= 0; i--)
            {
                next = Instance(array[i], next);
            }

            return next;
        }

        /// <summary>
        /// Searches the list for the supplied <paramref name="value"/>.
        /// </summary>
        /// <remarks>This is an O(n) operation since the size of the list determines how long it will take.</remarks>
        /// <param name="value">The value to be found.</param>
        /// <returns>The node containing the supplied <paramref name="value"/> if found; <c>null</c> otherwise.</returns>
        public SingleLinkedNode<T> Search(T value)
        {
            if (Value.Equals(value))
            {
                return this;
            }
            else if (Next != null)
            {
                return Next.Search(value);
            }

            return null;
        }

        /// <summary>
        /// Removes all references to other <c>SingleLinkedNode</c> instances to aid garbage collection.
        /// </summary>
        public override void Dispose()
        {
            Next = null;
        }
    }
}
