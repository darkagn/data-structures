using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Trees;
using NUnit.Framework;

namespace DataStructuresTest.Trees
{
    /// <summary>
    /// Unit test fixture for the <see cref="BalancedTree{T}"/> class.
    /// </summary>
    [TestFixture]
    public class BalancedTreeTest
    {
        /// <summary>
        /// Tests the <see cref="BalancedTree{T}.Add(T)"/> function to
        /// ensure when a previously empty tree is added to the size and height are adjusted
        /// correctly.
        /// </summary>
        [Test]
        public void AddToEmptyBalancedTreeShouldHaveSpecificProperties()
        {
            var tree = new BalancedTree<int>();
            tree.Add(42);

            Assert.IsFalse(tree.IsEmpty, "Tree is not empty");
            Assert.AreEqual(1, tree.Size(), "Tree should have one node");
            Assert.AreEqual(0, tree.Height(), "Tree should have height of 1");
            Assert.AreEqual("42", tree.ToString(), "Tree should have comma separated list of values");
        }

        /// <summary>
        /// Tests the <see cref="BalancedTree{T}.Add(T)"/> function to
        /// ensure balance is maintained when called several times.
        /// </summary>
        [Test]
        public void AddingSeveralValuesToBalancedTreeShouldMaintainBalance()
        {
            var tree = new BalancedTree<int>();
            tree.Add(42);

            // tree should now look like this:
            //                  42

            tree.Add(17);

            // tree should now look like this:
            //                  42
            //                 /  
            //                17  

            tree.Add(0);

            // tree should now look like this:
            //                  42
            //                 /  \
            //                17   0

            tree.Add(213401);

            // tree should now look like this:
            //                  42
            //                 /  \
            //                17   0
            //               /  
            //           213401

            tree.Add(-1);

            // tree should now look like this:
            //                  42
            //                 /  \
            //                17   0
            //               /    /
            //           213401 -1

            tree.Add(9);

            // tree should now look like this:
            //                  42
            //                 /  \
            //                17   0
            //               /  \  /
            //           213401 9 -1

            Assert.IsFalse(tree.IsEmpty, "Tree is not empty");
            Assert.AreEqual(6, tree.Size(), "Tree should have six nodes");
            Assert.AreEqual(2, tree.Height(), "Tree should have height of 2");
            Assert.AreEqual("42, 17, 213401, 9, 0, -1", tree.ToString(), "Tree should have comma separated list of values");

            // adding one more should add the node to the "0" on the right
            tree.Add(-69);
            Assert.IsFalse(tree.IsEmpty, "Tree is not empty");
            Assert.AreEqual(7, tree.Size(), "Tree should have seven nodes");
            Assert.AreEqual(2, tree.Height(), "Tree should have height of 2");
            Assert.AreEqual("42, 17, 213401, 9, 0, -1, -69", tree.ToString(), "Tree should have comma separated list of values");
        }

        /// <summary>
        /// Tests the <see cref="BalancedTree{T}.Remove(T)"/> function throws an exception if the tree is empty.
        /// </summary>
        [Test]
        public void RemovingFromAnEmptyBalancedTreeShouldThrowException()
        {
            var tree = new BalancedTree<int>();
            Assert.IsTrue(tree.IsEmpty, "Tree is empty");
            Assert.Throws(typeof(TreeUnderflowException), () => tree.Remove(42), "Removing from an empty tree should throw exception");
        }

        /// <summary>
        /// Tests the <see cref="BalancedTree{T}.Remove(T)"/> function returns false if the tree does not contain the value being removed.
        /// </summary>
        [Test]
        public void RemovingAValueThatDoesNotExistShouldReturnFalse()
        {
            var tree = new BalancedTree<int>();
            tree.Add(42);

            Assert.IsFalse(tree.IsEmpty, "Tree is not empty");
            Assert.IsFalse(tree.Remove(0), "Should not have been able to remove value not in the tree");
        }

        /// <summary>
        /// Tests the <see cref="BalancedTree{T}.Remove(T)"/> function returns true if the tree contains the value being removed,
        /// and that the balanced property is maintained when removing values. This function tests the simple case of removing a leaf.
        /// </summary>
        [Test]
        public void RemovingAValueThatExistsShouldMaintainBalanceAndReturnTrue()
        {
            var tree = new BalancedTree<int>();
            tree.Add(42);

            // remove the root node - should return true and make the tree empty
            Assert.IsTrue(tree.Remove(42), "Should be able to remove 42");
            Assert.IsTrue(tree.IsEmpty, "Tree should be empty again");

            tree.Add(42);
            tree.Add(17);
            tree.Add(0);
            tree.Add(213401);
            tree.Add(-1);
            tree.Add(9);

            // tree should now look like this:
            //                  42
            //                 /  \
            //                17   0
            //               /  \  /
            //           213401 9 -1

            Assert.IsFalse(tree.IsEmpty, "Tree is not empty");
            Assert.AreEqual(6, tree.Size(), "Tree should have six nodes");
            Assert.AreEqual(2, tree.Height(), "Tree should have height of 2");
            Assert.AreEqual("42, 17, 213401, 9, 0, -1", tree.ToString(), "Tree should have comma separated list of values");

            // simple case - remove a leaf
            Assert.IsTrue(tree.Remove(-1), "Should have been able to remove 9");
            Assert.IsFalse(tree.IsEmpty, "Tree is not empty");
            Assert.AreEqual(5, tree.Size(), "Tree should have five nodes");
            Assert.AreEqual(2, tree.Height(), "Tree should have height of 2");
            Assert.AreEqual("42, 17, 213401, 9, 0", tree.ToString(), "Tree should have comma separated list of values");

            // tree should now look like this:
            //                  42
            //                 /  \
            //                17   0
            //               /  \    
            //           213401  9

            // remove 213401 - should move 9 to the left child of 17
            Assert.IsTrue(tree.Remove(213401), "Should have been able to remove 213401");

            // tree should now look like this:
            //                  42
            //                 /  \
            //                17   0
            //               /   
            //              9

            Assert.IsFalse(tree.IsEmpty, "Tree is not empty");
            Assert.AreEqual(4, tree.Size(), "Tree should have four nodes");
            Assert.AreEqual(2, tree.Height(), "Tree should have height of 2");
            Assert.AreEqual("42, 17, 9, 0", tree.ToString(), "Tree should have comma separated list of values");

            // add a few more nodes back into the tree and remove a node with two subtrees
            tree.Add(-1);
            tree.Add(69);
            tree.Add(213401);

            // tree should now look like this:
            //                  42
            //                 /  \
            //                17   0
            //               / \  / \
            //              9 69 -1 213401

            Assert.IsTrue(tree.Remove(17), "Should have been able to remove 17");

            // tree should now look like this:
            //                  42
            //                 /  \
            //                69   0
            //               /    / \
            //              9   -1  213401

            Assert.IsFalse(tree.IsEmpty, "Tree is not empty");
            Assert.AreEqual(6, tree.Size(), "Tree should have six nodes");
            Assert.AreEqual(2, tree.Height(), "Tree should have height of 2");
            Assert.AreEqual("42, 69, 9, 0, -1, 213401", tree.ToString(), "Tree should have comma separated list of values");
        }
    }
}
