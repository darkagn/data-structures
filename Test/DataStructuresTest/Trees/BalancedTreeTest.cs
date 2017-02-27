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
            //           213401 -1 9

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
    }
}
