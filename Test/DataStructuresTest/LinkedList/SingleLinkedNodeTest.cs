using System;
using DataStructures.LinkedList;
using NUnit.Framework;

namespace DataStructuresTest.LinkedList
{
    /// <summary>
    /// Unit test fixture for the <see cref="DataStructures.LinkedList.SingleLinkedNode{T}"/> class.
    /// </summary>
    [TestFixture]
    public class SingleLinkedNodeTest
    {
        /// <summary>
        /// Tests the <see cref="DataStructures.LinkedList.SingleLinkedNode{T}.CreateFromArray(T[])"/> method to ensure that if 
        /// an array is passed to this function that is not yet instantiated it will throw an exception.
        /// </summary>
        [Test]
        public void CreateFromNullArrayShouldThrowException()
        {
            int[] array = null;
            Assert.Throws(typeof(ArgumentNullException), () => SingleLinkedNode<int>.CreateFromArray(array), "Expected to throw System.ArgumentNullException");
        }

        /// <summary>
        /// Tests the <see cref="DataStructures.LinkedList.SingleLinkedNode{T}.CreateFromArray(T[])"/> method to ensure that if 
        /// an array with length 0 is passed to this function it will return a <c>null</c> result.
        /// </summary>
        [Test]
        public void CreateFromZeroLengthArrayShouldReturnNull()
        {
            var array = new int[0];
            var actual = SingleLinkedNode<int>.CreateFromArray(array);
            Assert.IsNull(actual, "actual should be null since length of array is 0");
        }

        /// <summary>
        /// Tests the <see cref="DataStructures.LinkedList.SingleLinkedNode{T}.CreateFromArray(T[])"/> method to ensure that if 
        /// an array is passed to this function it will return a list with the same length as the array.
        /// </summary>
        [Test]
        public void CreateFromArrayShouldResultInHeaderLengthEqualToArrayLength()
        {
            int[] array = new int[] { 5, 12, 15, -61, 0 };
            var actual = SingleLinkedNode<int>.CreateFromArray(array);
            Assert.AreEqual(array.Length, SingleLinkedNode<int>.Length(actual), "Length");
        }

        /// <summary>
        /// Tests that the <see cref="DataStructures.LinkedList.SingleLinkedNode{T}.IsLast" /> property is true when the
        /// <see cref="DataStructures.LinkedList.SingleLinkedNode{T}.Next"/> property is <c>null</c>.
        /// </summary>
        [Test]
        public void IsLastShouldBeTrueIfNextIsNull()
        {
            SingleLinkedNode<int> node = SingleLinkedNode<int>.Instance(0, null);
            Assert.IsNull(node.Next, "Next should be null");
            Assert.IsTrue(node.IsLast, "IsLast should be true when next is null");
        }

        /// <summary>
        /// Tests that the <see cref="DataStructures.LinkedList.SingleLinkedNode{T}.IsLast" /> property is false when the
        /// <see cref="DataStructures.LinkedList.SingleLinkedNode{T}.Next"/> property is not <c>null</c>.
        /// </summary>
        [Test]
        public void IsLastShouldBeFalseIfNextIsNotNull()
        {
            SingleLinkedNode<int> node = SingleLinkedNode<int>.Instance(0, null);
            node = SingleLinkedNode<int>.Instance(1, node);
            Assert.IsNotNull(node.Next, "Next should not be null");
            Assert.IsFalse(node.IsLast, "IsLast should be true when next is not null");
        }

        /// <summary>
        /// Tests that the <see cref="DataStructures.LinkedList.SingleLinkedNode{T}.ToString"/> method prints the values of
        /// each node in the same order as the original array as a comma separated list.
        /// </summary>
        [Test]
        public void ToStringShouldPrintValuesInOrder()
        {
            int[] array = new int[] { 5, 12, 15, -61, 0 };
            var actual = SingleLinkedNode<int>.CreateFromArray(array);
            string toString = actual.ToString();
            Assert.IsNotNull(toString, "Should not be null string");
            Assert.IsNotEmpty(toString, "Should not be empty string");
            Assert.AreEqual("5, 12, 15, -61, 0", toString, "String is incorrect");
        }
    }
}
