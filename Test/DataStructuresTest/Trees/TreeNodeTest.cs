using DataStructures.Trees;
using NUnit.Framework;

namespace DataStructuresTest.Trees
{
    /// <summary>
    /// Unit test fixture for the <see cref="TreeNode{T}"/> class.
    /// </summary>
    [TestFixture]
    public class TreeNodeTest
    {
        /// <summary>
        /// Tests that the <see cref="TreeNode{T}.IsLeaf"/> property is true when the node has no child nodes.
        /// </summary>
        [Test]
        public void IsLeafShouldReturnTrueWhenNodeHasNoChildren()
        {
            var node = new TreeNode<int>(187);
            Assert.IsTrue(node.IsLeaf, "Node has no child nodes");
        }

        /// <summary>
        /// Tests that the <see cref="TreeNode{T}.IsLeaf"/> property is false when the node has child nodes.
        /// </summary>
        [Test]
        public void IsLeafShouldReturnFalseWhenNodeHasChildren()
        {
            var parent = new TreeNode<int>(187);
            var child = new TreeNode<int>(parent, -2);
            parent.Left = child;

            Assert.IsFalse(parent.IsLeaf, "Node has child node");
        }
    }
}
