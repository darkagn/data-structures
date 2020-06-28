using NUnit.Framework;
using DataStructures.Matrix;

namespace DataStructuresTest.Matrix
{
    /// <summary>
    /// Unit test fixture for the <see cref="MatrixNode{T}"/> class.
    /// </summary>
    [TestFixture]
    public class MatrixNodeTest
    {
        /// <summary>
        /// Verifies that the <see cref="MatrixNode{T}.CompareTo(MatrixNode{T})"/>
        /// method returns "less than" if the row of the caller is less than the
        /// row of the other instance.
        /// </summary>
        [Test]
        public void CompareToShouldReturnLessThanWhenRowIsLessThan()
        {
            MatrixNode<int> node = MatrixNode<int>.Instance(1, 0, 0);
            MatrixNode<int> other = MatrixNode<int>.Instance(1, 1, 0);

            Assert.Less(node.CompareTo(other), 0);
        }

        /// <summary>
        /// Verifies that the <see cref="MatrixNode{T}.CompareTo(MatrixNode{T})"/>
        /// method returns "greater than" if the row of the caller is greater than the
        /// row of the other instance.
        /// </summary>
        [Test]
        public void CompareToShouldReturnGreaterThanWhenRowIsGreaterThan()
        {
            MatrixNode<int> node = MatrixNode<int>.Instance(1, 1, 0);
            MatrixNode<int> other = MatrixNode<int>.Instance(1, 0, 0);

            Assert.Greater(node.CompareTo(other), 0);
        }

        /// <summary>
        /// Verifies that the <see cref="MatrixNode{T}.CompareTo(MatrixNode{T})"/>
        /// method returns "less than" if the column of the caller is less than the
        /// column of the other instance.
        /// </summary>
        [Test]
        public void CompareToShouldReturnLessThanWhenColumnIsLessThan()
        {
            MatrixNode<int> node = MatrixNode<int>.Instance(1, 0, 0);
            MatrixNode<int> other = MatrixNode<int>.Instance(1, 0, 1);

            Assert.Less(node.CompareTo(other), 0);
        }

        /// <summary>
        /// Verifies that the <see cref="MatrixNode{T}.CompareTo(MatrixNode{T})"/>
        /// method returns "greater than" if the column of the caller is greater than the
        /// column of the other instance.
        /// </summary>
        [Test]
        public void CompareToShouldReturnGreaterThanWhenColumnIsGreaterThan()
        {
            MatrixNode<int> node = MatrixNode<int>.Instance(1, 0, 1);
            MatrixNode<int> other = MatrixNode<int>.Instance(1, 0, 0);

            Assert.Greater(node.CompareTo(other), 0);
        }

        /// <summary>
        /// Verifies that the <see cref="MatrixNode{T}.CompareTo(MatrixNode{T})"/>
        /// method returns "equals" if the row and column of each instance are equal.
        /// </summary>
        [Test]
        public void CompareToShouldReturnZeroWhenRowAndColumnAreEqual()
        {
            MatrixNode<int> node = MatrixNode<int>.Instance(1, 0, 0);
            MatrixNode<int> other = MatrixNode<int>.Instance(1, 0, 0);

            Assert.AreEqual(0, node.CompareTo(other));
        }

        /// <summary>
        /// Verifies that the value returned by addition is modified accordingly,
        /// while Row and Column remain equivalent.
        /// </summary>
        [Test]
        public void AddShouldReturnAdditionOfValues()
        {
            MatrixNode<int> leftOperand = MatrixNode<int>.Instance(3, 0, 0);
            MatrixNode<int> rightOperand = MatrixNode<int>.Instance(1, 0, 0);

            MatrixNode<int> result = leftOperand + rightOperand;

            Assert.AreEqual(4, result.Value);
            Assert.AreEqual(0, result.Row);
            Assert.AreEqual(0, result.Column);
        }

        /// <summary>
        /// Verifies that if row, column are incompatible, a <see cref="MatrixOperationException"/>
        /// is thrown when the + operator is used.
        /// </summary>
        [Test]
        public void AddShouldThrowExceptionIfRowColumnIncompatible()
        {
            MatrixNode<int> leftOperand = MatrixNode<int>.Instance(3, 0, 0);
            MatrixNode<int> rightOperand = MatrixNode<int>.Instance(1, 1, 1);

            MatrixNode<int> result;

            _ = Assert.Throws(
                typeof(MatrixOperationException),
                () => result = leftOperand + rightOperand
            );
        }


        /// <summary>
        /// Verifies that the + operator throws a <see cref="MatrixOperationException"/>
        /// if the operator does not exist for the type represented by T.
        /// </summary>
        [Test]
        public void AddShouldThrowExceptionIfOperatorNotAvailableForT()
        {
            MatrixNode<bool> leftOperand = MatrixNode<bool>.Instance(true, 0, 0);
            MatrixNode<bool> rightOperand = MatrixNode<bool>.Instance(false, 1, 1);

            MatrixNode<bool> result;

            _ = Assert.Throws(
                typeof(MatrixOperationException),
                () => result = leftOperand + rightOperand
            );
        }

        /// <summary>
        /// Verifies that the value returned by subtraction is modified accordingly,
        /// while Row and Column remain equivalent.
        /// </summary>
        [Test]
        public void SubtractShouldReturnSubtractionOfValues()
        {
            MatrixNode<int> leftOperand = MatrixNode<int>.Instance(3, 0, 0);
            MatrixNode<int> rightOperand = MatrixNode<int>.Instance(1, 0, 0);

            MatrixNode<int> result = leftOperand - rightOperand;

            Assert.AreEqual(2, result.Value);
            Assert.AreEqual(0, result.Row);
            Assert.AreEqual(0, result.Column);
        }

        /// <summary>
        /// Verifies that if row, column are incompatible, a <see cref="MatrixOperationException"/>
        /// is thrown when the - operator is used.
        /// </summary>
        [Test]
        public void SubtractShouldThrowExceptionIfRowColumnIncompatible()
        {
            MatrixNode<int> leftOperand = MatrixNode<int>.Instance(3, 0, 0);
            MatrixNode<int> rightOperand = MatrixNode<int>.Instance(1, 1, 1);

            MatrixNode<int> result;

            _ = Assert.Throws(
                typeof(MatrixOperationException),
                () => result = leftOperand - rightOperand
            );
        }

        /// <summary>
        /// Verifies that the - operator throws a <see cref="MatrixOperationException"/>
        /// if the operator does not exist for the type represented by T.
        /// </summary>
        [Test]
        public void SubtractShouldThrowExceptionIfOperatorNotAvailableForT()
        {
            MatrixNode<bool> leftOperand = MatrixNode<bool>.Instance(true, 0, 0);
            MatrixNode<bool> rightOperand = MatrixNode<bool>.Instance(false, 1, 1);

            MatrixNode<bool> result;

            _ = Assert.Throws(
                typeof(MatrixOperationException),
                () => result = leftOperand - rightOperand
            );
        }
    }
}
