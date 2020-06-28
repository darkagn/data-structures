using System;
using DataStructures.Matrix;
using NUnit.Framework;

namespace DataStructuresTest.Matrix
{
    /// <summary>
    /// Test fixture for the <see cref="Matrix{T}" class./>
    /// </summary>
    [TestFixture]
    public class MatrixTest
    {
        /// <summary>
        /// Tests that the <see cref="Matrix{T}.Search(int, int)"/> returns
        /// the correct node.
        /// </summary>
        [Test]
        public void SearchByRowColumnReturnsCorrectNode()
        {
            int rows = 4;
            int columns = 4;

            Matrix<int> matrix = GetTestMatrix(rows, columns);

            MatrixNode<int> foundNode = matrix.Search(2, 2);

            Assert.IsNotNull(foundNode);
            Assert.AreEqual(2, foundNode.Row);
            Assert.AreEqual(2, foundNode.Column);
            Assert.AreEqual(10, foundNode.Value);
        }

        /// <summary>
        /// Tests that the <see cref="Matrix{T}.Search(T)"/> returns the correct
        /// node when found.
        /// </summary>
        [Test]
        public void SearchByValueReturnsCorrectNode()
        {
            int rows = 4;
            int columns = 4;

            Matrix<int> matrix = GetTestMatrix(rows, columns);

            MatrixNode<int> foundNode = matrix.Search(2);

            Assert.IsNotNull(foundNode);
            Assert.AreEqual(0, foundNode.Row);
            Assert.AreEqual(2, foundNode.Column);
            Assert.AreEqual(2, foundNode.Value);
        }

        /// <summary>
        /// Tests that the <see cref="Matrix{T}.Search(T)"/> returns <c>null</c>
        /// when the value does not exist in the matrix at all.
        /// </summary>
        [Test]
        public void SearchByValueReturnsNullWhenNotFound()
        {
            int rows = 4;
            int columns = 4;

            Matrix<int> matrix = GetTestMatrix(rows, columns);

            MatrixNode<int> foundNode = matrix.Search(-1);

            Assert.IsNull(foundNode);
        }

        /// <summary>
        /// Tests that the <see cref="Matrix{T}.GetValue(int, int)"/> method
        /// returns the correct values.
        /// </summary>
        [Test]
        public void GetValueReturnsCorrectValue()
        {
            int rows = 4;
            int columns = 4;

            Matrix<int> matrix = GetTestMatrix(rows, columns);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int expectedValue = i * columns + j;
                    int actualValue = matrix.GetValue(i, j);

                    Assert.AreEqual(expectedValue, actualValue);
                }
            }
        }

        /// <summary>
        /// Tests that an <see cref="ArgumentOutOfRangeException"/> is thrown
        /// when calling <see cref="Matrix{T}.GetValue(int, int)"/> when the
        /// first argument is negative.
        /// </summary>
        [Test]
        public void GetValueThrowsExceptionWhenRowNegative()
        {
            int rows = 4;
            int columns = 4;

            Matrix<int> matrix = GetTestMatrix(rows, columns);

            _ = Assert.Throws(typeof(ArgumentOutOfRangeException), () => matrix.GetValue(-1, 2));
        }

        /// <summary>
        /// Tests that an <see cref="ArgumentOutOfRangeException"/> is thrown
        /// when calling <see cref="Matrix{T}.GetValue(int, int)"/> when the
        /// second argument is negative.
        /// </summary>
        [Test]
        public void GetValueThrowsExceptionWhenColumnNegative()
        {
            int rows = 4;
            int columns = 4;

            Matrix<int> matrix = GetTestMatrix(rows, columns);

            _ = Assert.Throws(typeof(ArgumentOutOfRangeException), () => matrix.GetValue(2, -1));
        }

        /// <summary>
        /// Tests that an <see cref="ArgumentOutOfRangeException"/> is thrown
        /// when calling <see cref="Matrix{T}.GetValue(int, int)"/> when the
        /// first argument is greater than <see cref="Matrix{T}.Rows"/>.
        /// </summary>
        [Test]
        public void GetValueThrowsExceptionWhenRowGreaterThanRows()
        {
            int rows = 4;
            int columns = 4;

            Matrix<int> matrix = GetTestMatrix(rows, columns);

            _ = Assert.Throws(typeof(ArgumentOutOfRangeException), () => matrix.GetValue(10, 2));
        }

        /// <summary>
        /// Tests that an <see cref="ArgumentOutOfRangeException"/> is thrown
        /// when calling <see cref="Matrix{T}.GetValue(int, int)"/> when the
        /// second argument is greater than <see cref="Matrix{T}.Columns"/>.
        /// </summary>
        [Test]
        public void GetValueThrowsExceptionWhenColumnGreaterThanColumns()
        {
            int rows = 4;
            int columns = 4;

            Matrix<int> matrix = GetTestMatrix(rows, columns);

            _ = Assert.Throws(typeof(ArgumentOutOfRangeException), () => matrix.GetValue(2, 10));
        }

        /// <summary>
        /// Tests that an <see cref="ArgumentOutOfRangeException"/> is thrown
        /// when calling <see cref="Matrix{T}.SetValue(T, int, int)"/> and the
        /// index is not available to be added yet.
        /// </summary>
        /// <remarks>Items must be added in row, column order to the matrix.</remarks>
        [Test]
        public void SetValueThrowsExceptionWhenOutOfRange()
        {
            int rows = 4;
            int columns = 4;

            Matrix<int> matrix = GetTestMatrix(rows, columns);

            _ = Assert.Throws(typeof(ArgumentOutOfRangeException), () => matrix.SetValue(5, 5, 5));
        }

        /// <summary>
        /// Tests that the <see cref="Matrix{T}.SetValue(T, int, int)"/> method
        /// overrides the value of an existing cell.
        /// </summary>
        [Test]
        public void SetValueOverridesValueOfCorrectCell()
        {
            int rows = 4;
            int columns = 4;

            Matrix<int> matrix = GetTestMatrix(rows, columns);

            MatrixNode<int> oldNode = matrix.Search(0, 0);

            Assert.IsNotNull(oldNode);
            Assert.AreEqual(0, oldNode.Row);
            Assert.AreEqual(0, oldNode.Column);
            Assert.AreEqual(0, oldNode.Value);

            matrix.SetValue(-1, 0, 0);

            MatrixNode<int> foundNode = matrix.Search(0, 0);

            Assert.IsNotNull(foundNode);
            Assert.AreEqual(0, foundNode.Row);
            Assert.AreEqual(0, foundNode.Column);
            Assert.AreEqual(-1, foundNode.Value);
        }

        /// <summary>
        /// Tests the output of <see cref="Matrix{T}.ToString"/> method.
        /// </summary>
        [Test]
        public void ToStringContainsTabsAndNewLines()
        {
            int rows = 4;
            int columns = 4;

            Matrix<int> matrix = GetTestMatrix(rows, columns);

            string expectedOutput =
                "0\t1\t2\t3\r\n4\t5\t6\t7\r\n8\t9\t10\t11\r\n12\t13\t14\t15";

            Assert.AreEqual(expectedOutput, matrix.ToString());
        }

        /// <summary>
        /// Verifies that the <see cref="Matrix{T}.Add(Matrix{T})"/> method works
        /// as expected when the matrices are compatible.
        /// </summary>
        [Test]
        public void AddSetsValuesAccordingly()
        {
            int rows = 4;
            int columns = 4;

            Matrix<int> matrixLeft = GetTestMatrix(rows, columns);
            Matrix<int> matrixRight = GetTestMatrix(rows, columns);

            Matrix<int> matrix = matrixLeft.Add(matrixRight);

            Assert.AreEqual(matrix.Rows, matrixLeft.Rows);
            Assert.AreEqual(matrix.Columns, matrixLeft.Columns);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Assert.AreEqual(matrix[i, j], matrixLeft[i, j] + matrixRight[i, j]);
                }
            }
        }

        /// <summary>
        /// Verifies that the <see cref="Matrix{T}.Subtract(Matrix{T})"/> method works
        /// as expected when the matrices are compatible.
        /// </summary>
        [Test]
        public void SubtractSetsValuesAccordingly()
        {
            int rows = 4;
            int columns = 4;

            Matrix<int> matrixLeft = GetTestMatrix(rows, columns);
            Matrix<int> matrixRight = GetTestMatrix(rows, columns);

            Matrix<int> matrix = matrixLeft.Subtract(matrixRight);

            Assert.AreEqual(matrix.Rows, matrixLeft.Rows);
            Assert.AreEqual(matrix.Columns, matrixLeft.Columns);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Assert.AreEqual(matrix[i, j], matrixLeft[i, j] - matrixRight[i, j]);
                }
            }
        }

        /// <summary>
        /// Builds a matrix with the supplied dimensions for testing.
        /// </summary>
        /// <param name="rows">Number of rows for the matrix.</param>
        /// <param name="columns">Number of columns for the matrix.</param>
        /// <returns>A matrix of <paramref name="rows"/> x <paramref name="columns"/>
        /// cells.</returns>
        private Matrix<int> GetTestMatrix(int rows, int columns)
        {
            Matrix<int> matrix = new Matrix<int>(rows, columns);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = i * columns + j;
                }
            }

            return matrix;
        }
    }
}
