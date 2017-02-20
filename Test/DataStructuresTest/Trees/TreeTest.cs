using DataStructures.Trees;
using NUnit.Framework;

namespace DataStructuresTest.Trees
{
    /// <summary>
    /// Unit test fixture for the <see cref="Tree{T}"/> class.
    /// </summary>
    [TestFixture]
    public class TreeTest
    {
        /// <summary>
        /// Tests that a new tree is considered empty and has a size of 0. Also checks
        /// that the new tree has a height of -1 and prints an empty string.
        /// </summary>
        [Test]
        public void NewTreeShouldHaveSpecificProperties()
        {
            var tree = new Tree<int>();

            Assert.IsNotNull(tree, "Tree has been constructed");
            Assert.IsTrue(tree.IsEmpty, "Tree is empty");
            Assert.AreEqual(0, tree.Size(), "Tree should have size of 0");
            Assert.AreEqual(-1, tree.Height(), "Tree should have height of -1");
            Assert.IsEmpty(tree.ToString(), "Tree should be an empty string");
        }
        
        /// <summary>
        /// Tests that a non-empty tree has a positive height and size, and that it
        /// prints a comma separated list of values.
        /// </summary>
        [Test]
        public void NonEmptyTreeShouldHaveSizeAndHeightGreaterThanZero()
        {
            var root = new TreeNode<int>(17);
            var left = new TreeNode<int>(root, -2);
            root.Left = left;
            var right = new TreeNode<int>(root, 0);
            root.Right = right;

            var tree = new Tree<int>(root);
            Assert.IsFalse(tree.IsEmpty, "Tree is not empty");
            Assert.AreEqual(3, tree.Size(), "Tree should have three nodes");
            Assert.AreEqual(1, tree.Height(), "Tree should have height of 1");
            Assert.AreEqual("-2, 17, 0", tree.ToString(), "Tree should have comma separated list of values");
        }

        /// <summary>
        /// Tests that a search on an empty tree returns null.
        /// </summary>
        [Test]
        public void SearchOnEmptyTreeShouldReturnNull()
        {
            var tree = new Tree<int>();

            Assert.IsNull(tree.Search(189), "DFSearch on empty tree");
            Assert.IsNull(tree.Search(189, false), "BFSearch on empty tree");
        }

        /// <summary>
        /// Tests that a search for a value not in the tree returns null.
        /// </summary>
        [Test]
        public void SearchForMissingValueShouldReturnNull()
        {
            var root = new TreeNode<int>(17);
            var left = new TreeNode<int>(root, -2);
            root.Left = left;
            var right = new TreeNode<int>(root, 0);
            root.Right = right;
            var tree = new Tree<int>(root);

            Assert.IsNull(tree.Search(189), "DFSearch for missing element");
            Assert.IsNull(tree.Search(189, false), "BFSearch for missing element");
        }

        /// <summary>
        /// Tests that a search for a value in the tree does not return null and instead returns 
        /// the tree node with the supplied value.
        /// </summary>
        [Test]
        public void SearchForCorrectValueShouldNotReturnNull()
        {
            var root = new TreeNode<int>(17);
            var left = new TreeNode<int>(root, -2);
            root.Left = left;
            var right = new TreeNode<int>(root, 0);
            root.Right = right;
            var tree = new Tree<int>(root);

            var found = tree.Search(right.Value);
            Assert.IsNotNull(found, "DFS should have found value");
            Assert.AreEqual(right.Value, found.Value, "DFS Value");

            found = tree.Search(right.Value, false);
            Assert.IsNotNull(found, "BFS hould have found value");
            Assert.AreEqual(right.Value, found.Value, "BFS Value");
        }
    }
}
