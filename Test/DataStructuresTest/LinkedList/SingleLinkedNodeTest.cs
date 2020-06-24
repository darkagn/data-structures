using System;
using DataStructures.LinkedList;
using NUnit.Framework;

namespace DataStructuresTest.LinkedList
{
    /// <summary>
    /// Unit test fixture for the <see cref="SingleLinkedNode{T}"/> class.
    /// </summary>
    [TestFixture]
    public class SingleLinkedNodeTest
    {
        /// <summary>
        /// Tests the <see cref="SingleLinkedNode{T}.CreateFromArray(T[])"/> method to ensure that if 
        /// an array is passed to this function that is not yet instantiated it will throw an exception.
        /// </summary>
        [Test]
        public void CreateFromNullArrayShouldThrowException()
        {
            int[] array = null;
            _ = Assert.Throws(typeof(ArgumentNullException), () => SingleLinkedNode<int>.CreateFromArray(array),
                "Expected to throw System.ArgumentNullException");
        }

        /// <summary>
        /// Tests the <see cref="SingleLinkedNode{T}.CreateFromArray(T[])"/> method to ensure that if 
        /// an array with length 0 is passed to this function it will return a <c>null</c> result.
        /// </summary>
        [Test]
        public void CreateFromZeroLengthArrayShouldReturnNull()
        {
            int[] array = new int[0];
            SingleLinkedNode<int> actual = SingleLinkedNode<int>.CreateFromArray(array);
            Assert.IsNull(actual, "actual should be null since length of array is 0");
        }

        /// <summary>
        /// Tests the <see cref="SingleLinkedNode{T}.CreateFromArray(T[])"/> method to ensure that if 
        /// an array is passed to this function it will return a list with the same length as the array.
        /// </summary>
        [Test]
        public void CreateFromArrayShouldResultInHeaderLengthEqualToArrayLength()
        {
            int[] array = new int[] { 5, 12, 15, -61, 0 };
            SingleLinkedNode<int> actual = SingleLinkedNode<int>.CreateFromArray(array);
            Assert.AreEqual(array.Length, SingleLinkedNode<int>.Length(actual), "Length");
        }

        /// <summary>
        /// Tests that the <see cref="SingleLinkedNode{T}.IsLast" /> property is true when the
        /// <see cref="SingleLinkedNode{T}.Next"/> property is <c>null</c>.
        /// </summary>
        [Test]
        public void IsLastShouldBeTrueIfNextIsNull()
        {
            SingleLinkedNode<int> node = SingleLinkedNode<int>.Instance(0, null);
            Assert.IsNull(node.Next, "Next should be null");
            Assert.IsTrue(node.IsLast, "IsLast should be true when next is null");
        }

        /// <summary>
        /// Tests that the <see cref="SingleLinkedNode{T}.IsLast" /> property is false when the
        /// <see cref="SingleLinkedNode{T}.Next"/> property is not <c>null</c>.
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
        /// Tests that the <see cref="SingleLinkedNode{T}.ToString"/> method prints the values of
        /// each node in the same order as the original array as a comma separated list.
        /// </summary>
        [Test]
        public void ToStringShouldPrintValuesInOrder()
        {
            int[] array = new int[] { 5, 12, 15, -61, 0 };
            SingleLinkedNode<int> actual = SingleLinkedNode<int>.CreateFromArray(array);
            string toString = actual.ToString();
            Assert.IsNotNull(toString, "Should not be null string");
            Assert.IsNotEmpty(toString, "Should not be empty string");
            Assert.AreEqual("5, 12, 15, -61, 0", toString, "String is incorrect");
        }

        /// <summary>
        /// Tests that the <see cref="SingleLinkedNode{T}.Last"/> method finds the last node in the list.
        /// </summary>
        [Test]
        public void LastShouldReturnFinalNode()
        {
            int[] array = new int[] { 12, 15, -61, 0, 5 };
            SingleLinkedNode<int> actual = SingleLinkedNode<int>.CreateFromArray(array);
            SingleLinkedNode<int> last = actual.Last();
            Assert.IsNotNull(last, "Last should not be null");
            Assert.IsTrue(last.IsLast, "IsLast should be true for last node");
            Assert.AreEqual(5, last.Value, "Value should be equal to final array value");
        }

        /// <summary>
        /// Tests that the <see cref="SingleLinkedNode{T}.Search(T)"/> function returns null when the supplied value is not found.
        /// </summary>
        [Test]
        public void SearchShouldReturnNullWhenNotFound()
        {
            int[] array = new int[] { 12, 15, -61, 0, 5 };
            SingleLinkedNode<int> actual = SingleLinkedNode<int>.CreateFromArray(array);
            Assert.IsNull(actual.Search(38129), "Should return null");
        }

        /// <summary>
        /// Tests that the <see cref="SingleLinkedNode{T}.Search(T)"/> function returns node when the supplied value is found.
        /// </summary>
        [Test]
        public void SearchShouldReturnNodeWhenValueFound()
        {
            int[] array = new int[] { 12, 15, -61, 0, 5 };
            SingleLinkedNode<int> actual = SingleLinkedNode<int>.CreateFromArray(array);
            SingleLinkedNode<int> result = actual.Search(15);
            Assert.IsNotNull(result, "Should not return null");
            Assert.AreEqual(15, result.Value, "Value");
            Assert.AreEqual(-61, result.Next.Value, "Next value");
        }
    }
}
