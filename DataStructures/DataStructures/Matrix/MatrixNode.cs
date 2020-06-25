using System;
using DataStructures.Node;

namespace DataStructures.Matrix
{
    /// <summary>
    /// Represents a node, or cell, in a matrix.
    /// </summary>
    /// <typeparam name="T">Indicates the type of data being stored as the value of the node.</typeparam>
    public class MatrixNode<T> : BaseNode<T>, IComparable<MatrixNode<T>>
    {
        /// <summary>
        /// Constructor which specifies the <paramref name="row"/>, <paramref name="column"/> index for the cell.
        /// The supplied <paramref name="value"/> is stored in the cell and is immutable.
        /// </summary>
        /// <param name="value">Value being stored in the cell.</param>
        /// <param name="row">Row index of the cell.</param>
        /// <param name="column">Column index of the cell.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if either <paramref name="row"/> or <paramref name="column"/> are negative.
        /// </exception>
        protected MatrixNode(T value, int row, int column)
            : base(value)
        {
            if (row < 0)
            {
                throw new ArgumentOutOfRangeException("row", "Row must not be negative");
            }

            if (column < 0)
            {
                throw new ArgumentOutOfRangeException("column", "Column must not be negative");
            }

            Row = row;
            Column = column;
        }

        /// <summary>
        /// Row index for the cell -- ReadOnly.
        /// Strictly non-negative.
        /// </summary>
        public int Row
        {
            get;
            private set;
        }

        /// <summary>
        /// Column index for the cell -- ReadOnly.
        /// Strictly non-negative.
        /// </summary>
        public int Column
        {
            get;
            private set;
        }

        /// <summary>
        /// The row, column index for this cell -- ReadOnly.
        /// int[2] = [ Row, Column ]
        /// </summary>
        /// <seealso cref="Row"/>
        /// <seealso cref="Column"/>
        public int[] Index
        {
            get => new int[2] { Row, Column };
        }

        /// <summary>
        /// Creates a new matrix node instance with the supplied <paramref name="value"/>
        /// at the supplied <paramref name="row"/>, <paramref name="column"/> index.
        /// </summary>
        /// <param name="value">Value being stored in the cell.</param>
        /// <param name="row">Row index of the cell.</param>
        /// <param name="column">Column index of the cell.</param>
        /// <returns>A new instance.</returns>
        public static MatrixNode<T> Instance(T value, int row, int column)
        {
            return new MatrixNode<T>(value, row, column);
        }

        /// <summary>
        /// Used for sorting by index, this function compares the instance to the
        /// <paramref name="other"/> instance.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>
        /// -1 if this instance is "less than" the <paramref name="other"/> instance;
        /// 1 if this instance is "greater than" the <paramref name="other"/> instance;
        /// 0 if the instances are "equal" to each other.
        /// </returns>
        public int CompareTo(MatrixNode<T> other)
        {
            int result = Row.CompareTo(other.Row);

            if (result == 0)
            {
                result =  Column.CompareTo(other.Column);
            }

            return result;
        }
    }
}
