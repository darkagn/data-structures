using System;
using System.Linq.Expressions;
using DataStructures.Node;

namespace DataStructures.Matrix
{
    /// <summary>
    /// Represents a node, or cell, in a matrix.
    /// </summary>
    /// <typeparam name="T">Indicates the type of data being stored as the value of the node.</typeparam>
    public class MatrixNode<T> : BaseNode<T>, IComparable<MatrixNode<T>> where T : unmanaged
    {
        /// <summary>
        /// Delegate for the addition operator.
        /// </summary>
        private static readonly Func<T, T, T> addMethod;

        /// <summary>
        /// Delegate for the subtract operator.
        /// </summary>
        private static readonly Func<T, T, T> subtractMethod;

        /// <summary>
        /// Static constructor.
        /// </summary>
        static MatrixNode()
        {
            try
            {
                ParameterExpression left = Expression.Parameter(typeof(T), "left");
                ParameterExpression right = Expression.Parameter(typeof(T), "right");
                addMethod = Expression.Lambda<Func<T, T, T>>(Expression.Add(left, right), left, right).Compile();
                subtractMethod = Expression.Lambda<Func<T, T, T>>(Expression.Subtract(left, right), left, right).Compile();
            }
            catch (InvalidOperationException)
            {
                //Eat the exception, no + operator defined :(
            }
        }

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

        /// <summary>
        /// Adds a node to another, if permitted.
        /// </summary>
        /// <param name="leftOperand">The left operand of the operation.</param>
        /// <param name="rightOperand">The right operand of the operation.</param>
        /// <returns>A new instance indicating the new node value.</returns>
        /// <exception cref="MatrixOperationException">
        /// Thrown if the row and column of each operand are not equivalent, or
        /// if <typeparamref name="T"/> does not allow the + operator.
        /// </exception>
        public static MatrixNode<T> operator +(MatrixNode<T> leftOperand, MatrixNode<T> rightOperand)
        {
            VerifyRowColumnForOperators(leftOperand, rightOperand);

            if (addMethod == null)
            {
                throw new MatrixOperationException("operator", "+ does not exist for the type T: ");
            }

            return MatrixNode<T>.Instance(addMethod(leftOperand.Value, rightOperand.Value), leftOperand.Row, leftOperand.Column);
        }

        /// <summary>
        /// Subtracts a node from another, if permitted.
        /// </summary>
        /// <param name="leftOperand">The left operand of the operation.</param>
        /// <param name="rightOperand">The right operand of the operation.</param>
        /// <returns>A new instance indicating the new node value.</returns>
        /// <exception cref="MatrixOperationException">
        /// Thrown if the row and column of each operand are not equivalent, or
        /// if <typeparamref name="T"/> does not allow the + operator.
        /// </exception>
        public static MatrixNode<T> operator -(MatrixNode<T> leftOperand, MatrixNode<T> rightOperand)
        {
            VerifyRowColumnForOperators(leftOperand, rightOperand);

            if (subtractMethod == null)
            {
                throw new MatrixOperationException("operator", "+ does not exist for the type T: ");
            }

            return MatrixNode<T>.Instance(subtractMethod(leftOperand.Value, rightOperand.Value), leftOperand.Row, leftOperand.Column);
        }

        /// <summary>
        /// Verifies the operands are in the corresponding row, column index in their respective matrices.
        /// </summary>
        /// <param name="leftOperand">The left operand of the operation.</param>
        /// <param name="rightOperand">The right operand of the operation.</param>
        private static void VerifyRowColumnForOperators(MatrixNode<T> leftOperand, MatrixNode<T> rightOperand)
        {
            if (leftOperand.Row != rightOperand.Row)
            {
                throw new MatrixOperationException("Row", "Row of each operator must match");
            }

            if (leftOperand.Column != rightOperand.Column)
            {
                throw new MatrixOperationException("Column", "Column of each operator must match");
            }
        }
    }
}
