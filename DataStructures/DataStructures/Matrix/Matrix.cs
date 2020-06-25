using System;
using System.Collections.Generic;

namespace DataStructures.Matrix
{
    /// <summary>
    /// The Matrix class represents a mathematical matrix.
    /// </summary>
    /// <typeparam name="T">Indicates the type of data being stored as the value
    /// of each item in the matrix.</typeparam>
    public class Matrix<T> : IDisposable
    {
        /// <summary>
        /// Internal data structure to hold each cell.
        /// </summary>
        private List<MatrixNode<T>> mCells;

        /// <summary>
        /// Base constructor.
        /// </summary>
        /// <param name="rows">Specifies the number of rows in the matrix.</param>
        /// <param name="columns">Specifies the number of columns in the matrix.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="rows"/> or <paramref name="columns"/> is
        /// less than or equal to 0.
        /// </exception>
        public Matrix(int rows, int columns)
        {
            if (rows <= 0)
            {
                throw new ArgumentOutOfRangeException("rows", "Must be greater than 0");
            }

            if (columns <= 0)
            {
                throw new ArgumentOutOfRangeException("columns", "Must be greater than 0");
            }

            Rows = rows;
            Columns = columns;

            mCells = new List<MatrixNode<T>>(rows * columns);
        }

        /// <summary>
        /// The number of rows in the matrix -- ReadOnly.
        /// </summary>
        public int Rows
        {
            get;
            private set;
        }

        /// <summary>
        /// The number of columns in the matrix -- ReadOnly.
        /// </summary>
        public int Columns
        {
            get;
            private set;
        }

        /// <summary>
        /// Index operator via <paramref name="row"/>, <paramref name="column"/>
        /// index of the matrix. Each index is 0-based, and can range up to
        /// <see cref="Rows"/> - 1 and <see cref="Columns"/> - 1.
        /// </summary>
        /// <param name="row">The row index of the value.</param>
        /// <param name="column">The column index of the value.</param>
        /// <returns>The value.</returns>
        public T this[int row, int column]
        {
            get => GetValue(row, column);
            set => SetValue(value, row, column);
        }

        /// <summary>
        /// Retrieves the value at the specified <paramref name="row"/>,
        /// <paramref name="column"/> index.
        /// </summary>
        /// <param name="row">Row index being retrieved.</param>
        /// <param name="column">Column index being retrieved.</param>
        /// <returns>The value of the cell at row, column index.</returns>
        public T GetValue(int row, int column)
        {
            MatrixNode<T> node = Search(row, column);

            return node.Value;
        }

        /// <summary>
        /// Sets the <paramref name="value"/> in the cell with the supplied
        /// <paramref name="row"/>, <paramref name="column"/> index.
        /// </summary>
        /// <param name="value">Value to be set.</param>
        /// <param name="row">Row of the index.</param>
        /// <param name="column">Column of the index.</param>
        public void SetValue(T value, int row, int column)
        {
            int index = GetScalarIndex(row, column);

            VerifyScalarIndex(index);

            MatrixNode<T> node = MatrixNode<T>.Instance(value, row, column);

            if (mCells.Count > index)
            {
                mCells[index] = node;
            }
            else
            {
                mCells.Add(node);
            }
        }

        /// <summary>
        /// Searches the matrix for the <paramref name="row"/>, <paramref name="column"/>
        /// index and returns the node at that index.
        /// </summary>
        /// <remarks>This is an O(1) function due to internal handling of a
        /// scalar index property.</remarks>
        /// <param name="row">The row of the index.</param>
        /// <param name="column">The column of the index.</param>
        /// <returns>The node at the supplied <paramref name="row"/>,
        /// <paramref name="column"/> index.</returns>
        public MatrixNode<T> Search(int row, int column)
        {
            int index = GetScalarIndex(row, column);

            return mCells[index];
        }

        /// <summary>
        /// Serches the matrix for the first instance of the supplied
        /// <paramref name="value"/>.
        /// If found, returns the node instance; otherwise this method
        /// returns <c>null</c>.
        /// </summary>
        /// <remarks>This is an O(n) operation in the worst case scenario.</remarks>
        /// <param name="value">The value being searched for.</param>
        /// <returns>
        /// The first node in the list with the supplied
        /// <paramref name="value"/> if found; <c>null</c> otherwise.
        /// </returns>
        public MatrixNode<T> Search(T value)
        {
            foreach (MatrixNode<T> node in mCells)
            {
                if (node.Value.Equals(value))
                {
                    return node;
                }
            }

            return null;
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
            List<string> output = new List<string>();
            List<string> line = null;

            foreach (MatrixNode<T> node in mCells)
            {
                if (line == null || node.Column == 0)
                {
                    line = new List<string>();
                }

                line.Add(node.ToString());

                if (node.Column == Columns - 1)
                {
                    output.Add(String.Join("\t", line));
                }
            }

            return String.Join("\r\n", output);
        }

        /// <summary>
        /// Verifies that the <paramref name="row"/>, <paramref name="column"/>
        /// index is valid for the matrix. Rows and columns are 0-indexed in a
        /// matrix, so the top-left cell is defined as having row, column index
        /// of [0, 0]. The bottom-right cell is defined as having row, column
        /// index [Rows - 1, Columns - 1]. Therefore, the appropriate ranges
        /// for the <paramref name="row"/>, <paramref name="column"/> index are
        /// [0, Rows - 1] and [0, Columns - 1].
        /// </summary>
        /// <param name="row">Row index being retrieved.</param>
        /// <param name="column">Column index being retrieved.</param>
        /// <returns>
        /// The value of the cell at <paramref name="row"/>,
        /// <paramref name="column"/> index.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the <paramref name="row"/> or <paramref name="column"/>
        /// argument are not in the range [0, Rows - 1] or [0, Columns - 1]
        /// respectively.
        /// </exception>
        /// <seealso cref="Rows"/>
        /// <seealso cref="Columns"/>
        private void VerifyIndex(int row, int column)
        {
            if (row < 0 || row > Rows - 1)
            {
                throw new ArgumentOutOfRangeException(
                    "row",
                    "Must be between 0 and " + (Rows - 1).ToString()
                );
            }

            if (column < 0 || column > Columns - 1)
            {
                throw new ArgumentOutOfRangeException(
                    "column",
                    "Must be between 0 and " + (Columns - 1).ToString()
                );
            }
        }

        /// <summary>
        /// Retrieves the scalar representation of the <paramref name="row"/>,
        /// <paramref name="column"/> index.
        /// </summary>
        /// <remarks>
        /// This can subsequently be used as the index to <seealso cref="mCells"/>
        /// to lookup a node in O(1) operation.
        /// </remarks>
        /// <param name="row">The row to be referenced.</param>
        /// <param name="column">The column to be referenced.</param>
        /// <returns>The scalar index of the internal data structure.</returns>
        private int GetScalarIndex(int row, int column)
        {
            VerifyIndex(row, column);

            return row * Columns + column;
        }

        /// <summary>
        /// Verifies that the supplied <paramref name="index"/> is available to
        /// be added to the matrix, or already exists.
        /// </summary>
        /// <param name="index">The scalar index being checked.</param>
        private void VerifyScalarIndex(int index)
        {
            if (mCells.Count < index)
            {
                throw new ArgumentOutOfRangeException(
                    "index",
                    "ScalarIndex must be no more than one greater than the current count of items added. Please ensure you generate the matrix by adding items in order."
                );
            }
        }
    }
}
