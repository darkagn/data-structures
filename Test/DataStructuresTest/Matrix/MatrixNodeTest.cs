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
    }
}
