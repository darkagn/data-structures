﻿using System;
using DataStructures.LinkedList;
using NUnit.Framework;

namespace DataStructuresTest.LinkedList
{
    /// <summary>
    /// Unit test fixture for the <see cref="DoubleLinkedNode{T}"/> class.
    /// </summary>
    [TestFixture]
    public class DoubleLinkedNodeTest
    {
        /// <summary>
        /// Tests the <see cref="DoubleLinkedNode{T}.CreateFromArray(T[])"/> method to ensure that if 
        /// an array is passed to this function that is not yet instantiated it will throw an exception.
        /// </summary>
        [Test]
        public void CreateFromNullArrayShouldThrowException()
        {
            int[] array = null;
            _ = Assert.Throws(typeof(ArgumentNullException), () => DoubleLinkedNode<int>.CreateFromArray(array), "Expected to throw System.ArgumentNullException");
        }

        /// <summary>
        /// Tests the <see cref="DoubleLinkedNode{T}.CreateFromArray(T[])"/> method to ensure that if 
        /// an array with length 0 is passed to this function it will return a <c>null</c> result.
        /// </summary>
        [Test]
        public void CreateFromZeroLengthArrayShouldReturnNull()
        {
            int[] array = new int[0];
            DoubleLinkedNode<int> actual = DoubleLinkedNode<int>.CreateFromArray(array);
            Assert.IsNull(actual, "actual should be null since length of array is 0");
        }

        /// <summary>
        /// Tests the <see cref="DoubleLinkedNode{T}.CreateFromArray(T[])"/> method to ensure that if 
        /// an array is passed to this function it will return a list with the same length as the array.
        /// </summary>
        [Test]
        public void CreateFromArrayShouldResultInHeaderLengthEqualToArrayLength()
        {
            int[] array = new int[] { 5, 12, 15, -61, 0 };
            SingleLinkedNode<int> actual = SingleLinkedNode<int>.CreateFromArray(array);
            Assert.AreEqual(array.Length, DoubleLinkedNode<int>.Length(actual), "Length");
        }

        /// <summary>
        /// Tests that the <see cref="DoubleLinkedNode{T}.IsHeader" /> property is true when the
        /// <see cref="DoubleLinkedNode{T}.Previous"/> property is <c>null</c>.
        /// </summary>
        [Test]
        public void IsHeaderShouldBeTrueIfPreviousIsNull()
        {
            DoubleLinkedNode<int> node = DoubleLinkedNode<int>.Instance(0, null, null);
            Assert.IsNull(node.Previous, "Previous should be null");
            Assert.IsTrue(node.IsHeader, "IsHeader should be true when next is null");
        }

        /// <summary>
        /// Tests that the <see cref="DoubleLinkedNode{T}.IsHeader" /> property is false when the
        /// <see cref="DoubleLinkedNode{T}.Previous"/> property is not <c>null</c>.
        /// </summary>
        [Test]
        public void IsHeaderShouldBeFalseIfPreviousIsNotNull()
        {
            DoubleLinkedNode<int> node = DoubleLinkedNode<int>.Instance(0, null, null);
            node = DoubleLinkedNode<int>.Instance(1, null, node);
            Assert.IsNotNull(node.Previous, "Previous should not be null");
            Assert.IsFalse(node.IsHeader, "IsHeader should be true when next is not null");
        }

        /// <summary>
        /// Tests that the <see cref="DoubleLinkedNode{T}.SetNext(SingleLinkedNode{T})"/> function throws an exception if the 
        /// type passed to the function is not <c>DoubleLinkedNode</c>.
        /// </summary>
        [Test]
        public void InstanceShouldThrowExceptionIfNextIsNotDoubleLinkedNodeType()
        {
            Assert.DoesNotThrow(() => DoubleLinkedNode<int>.Instance(0, null, null),
                "Passing null as next or previous should be fine - indicates first item being added to the list");

            DoubleLinkedNode<int> node = DoubleLinkedNode<int>.Instance(0, null, null);
            DoubleLinkedNode<int> nextNode = DoubleLinkedNode<int>.Instance(1, null, node);
            node.Next = nextNode;
            DoubleLinkedNode<int> lastNode = DoubleLinkedNode<int>.Instance(2, null, nextNode);
            nextNode.Next = lastNode;

            SingleLinkedNode<int> invalidNode = SingleLinkedNode<int>.Instance(-1, node);
            _ = Assert.Throws(typeof(ArgumentException), () => { node.Next = invalidNode; }, "Should throw an exception due to invalid type of node");
        }

        /// <summary>
        /// Tests the <see cref="DoubleLinkedNode{T}.CreateFromArray(T[])"/> method maintains the expected next and previous properties.
        /// </summary>
        [Test]
        public void CreateFromArrayShouldMaintainPreviousAndNextLinks()
        {
            int[] array = new int[] { 5, 12, 15, -61, 0 };
            DoubleLinkedNode<int> actual = DoubleLinkedNode<int>.CreateFromArray(array);

            Assert.AreEqual(5, actual.Value, "Value");
            Assert.AreEqual(12, actual.Next.Value, "Next Value");
            Assert.IsNull(actual.Previous, "Previous");
            Assert.IsTrue(actual.IsHeader, "IsHeader");
            Assert.IsFalse(actual.IsLast, "IsLast");
            Assert.AreEqual(5, DoubleLinkedNode<int>.Length(actual), "Length");

            actual = (DoubleLinkedNode<int>)actual.Next;
            Assert.AreEqual(12, actual.Value, "Value");
            Assert.AreEqual(15, actual.Next.Value, "Next Value");
            Assert.AreEqual(5, actual.Previous.Value, "Previous Value");
            Assert.IsFalse(actual.IsHeader, "IsHeader");
            Assert.IsFalse(actual.IsLast, "IsLast");
            Assert.AreEqual(4, DoubleLinkedNode<int>.Length(actual), "Length");

            actual = (DoubleLinkedNode<int>)actual.Next;
            Assert.AreEqual(15, actual.Value, "Value");
            Assert.AreEqual(-61, actual.Next.Value, "Next Value");
            Assert.AreEqual(12, actual.Previous.Value, "Previous Value");
            Assert.IsFalse(actual.IsHeader, "IsHeader");
            Assert.IsFalse(actual.IsLast, "IsLast");
            Assert.AreEqual(3, DoubleLinkedNode<int>.Length(actual), "Length");

            actual = (DoubleLinkedNode<int>)actual.Next;
            Assert.AreEqual(-61, actual.Value, "Value");
            Assert.AreEqual(0, actual.Next.Value, "Next Value");
            Assert.AreEqual(15, actual.Previous.Value, "Previous Value");
            Assert.IsFalse(actual.IsHeader, "IsHeader");
            Assert.IsFalse(actual.IsLast, "IsLast");
            Assert.AreEqual(2, DoubleLinkedNode<int>.Length(actual), "Length");

            actual = (DoubleLinkedNode<int>)actual.Next;
            Assert.AreEqual(0, actual.Value, "Value");
            Assert.IsNull(actual.Next, "Next");
            Assert.AreEqual(-61, actual.Previous.Value, "Previous Value");
            Assert.IsFalse(actual.IsHeader, "IsHeader");
            Assert.IsTrue(actual.IsLast, "IsLast");
            Assert.AreEqual(1, DoubleLinkedNode<int>.Length(actual), "Length");
        }

        /// <summary>
        /// Tests that the <see cref="DoubleLinkedNode{T}.Head"/> method finds the first node in the list.
        /// </summary>
        [Test]
        public void HeadShouldReturnFirstNode()
        {
            int[] array = new int[] { 12, 15, -61, 0, 5 };
            DoubleLinkedNode<int> actual = DoubleLinkedNode<int>.CreateFromArray(array);
            DoubleLinkedNode<int> first = actual.Head();
            Assert.IsNotNull(first, "Head should not be null");
            Assert.IsTrue(first.IsHeader, "IsHeader should be true for last node");
            Assert.AreEqual(12, first.Value, "Value should be equal to first array value");
        }
    }
}
