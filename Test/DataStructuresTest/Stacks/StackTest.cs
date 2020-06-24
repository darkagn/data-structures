using DataStructures.Stacks;
using NUnit.Framework;

namespace DataStructuresTest.Stacks
{
    /// <summary>
    /// Unit test fixture for the <see cref="Stack{T}"/> class.
    /// </summary>
    [TestFixture]
    public class StackTest
    {
        /// <summary>
        /// Tests that a newly constructed stack has a count of 0 and is considered empty.
        /// </summary>
        [Test]
        public void NewStackShouldHaveZeroCountAndBeEmpty()
        {
            Stack<int> stack = new Stack<int>();
            Assert.IsNotNull(stack, "Stack should not be null after construction");
            Assert.AreEqual(0, stack.Count, "Count should be zero for new stack");
            Assert.IsTrue(stack.IsEmpty, "Stack should be considered empty");
        }

        /// <summary>
        /// Tests that the <see cref="Stack{T}.Push(T)"/> function adds one to the value of count each time.
        /// </summary>
        [Test]
        public void PushShouldAddOneToCountEachTime()
        {
            Stack<int> stack = new Stack<int>();
            Assert.IsNotNull(stack, "Stack should not be null after construction");
            Assert.AreEqual(0, stack.Count, "Count should be zero for new stack");
            Assert.IsTrue(stack.IsEmpty, "Stack should be considered empty");

            stack.Push(17);
            Assert.AreEqual(1, stack.Count, "Count should be 1 after push");
            Assert.IsFalse(stack.IsEmpty, "Stack should not be empty after push");

            stack.Push(42);
            Assert.AreEqual(2, stack.Count, "Count should be 2 after push");
            Assert.IsFalse(stack.IsEmpty, "Stack should not be empty after push");
        }

        /// <summary>
        /// Tests that the <see cref="Stack{T}.Pop"/> function throws an exception when called on an empty queue.
        /// </summary>
        [Test]
        public void PopOnEmptyStackShouldThrowException()
        {
            Stack<int> stack = new Stack<int>();

            _ = Assert.Throws(typeof(StackUnderflowException), () => stack.Pop(), "Pop on empty stack should throw exception");
        }

        /// <summary>
        /// Tests that the <see cref="Stack{T}.Pop"/> function returns the last element in the stack and decreases the count by one.
        /// </summary>
        [Test]
        public void PopOnNonEmptyStackShouldReturnLastElementAndDecreaseCountByOne()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(17);
            stack.Push(42);
            Assert.AreEqual(2, stack.Count, "Count should be 2 after push");
            Assert.IsFalse(stack.IsEmpty, "Stack should not be empty after push");

            int value = stack.Pop();
            Assert.AreEqual(42, value);
            Assert.AreEqual(1, stack.Count, "Count should be 1 after pop");
            Assert.IsFalse(stack.IsEmpty, "Stack should not be empty as count > 0");

            value = stack.Pop();
            Assert.AreEqual(17, value);
            Assert.AreEqual(0, stack.Count, "Count should be 0 after pop");
            Assert.IsTrue(stack.IsEmpty, "Stack should be empty as count = 0");
        }

        /// <summary>
        /// Tests that the <see cref="Stack{T}.Peek"/> function throws an exception when called on an empty queue.
        /// </summary>
        [Test]
        public void PeekOnEmptyStackShouldThrowException()
        {
            Stack<int> stack = new Stack<int>();

            _ = Assert.Throws(typeof(StackUnderflowException), () => stack.Peek(), "Peek on empty queue should throw exception");
        }

        /// <summary>
        /// Tests that the <see cref="Stack{T}.Peek"/> function returns the last element in the queue but does not change the queue.
        /// </summary>
        [Test]
        public void PeekOnNonEmptyStackShouldReturnLastElementButNotChangeQueue()
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(17);
            int value = stack.Peek();
            Assert.AreEqual(17, value, "Last value = 17");
            Assert.AreEqual(1, stack.Count, "Count should be 1 after peek");
            Assert.IsFalse(stack.IsEmpty, "Stack should not be empty as count > 0");

            value = stack.Peek();
            Assert.AreEqual(17, value, "Last value = 17");
            Assert.AreEqual(1, stack.Count, "Count should be 1 after peek");
            Assert.IsFalse(stack.IsEmpty, "Stack should not be empty as count > 0");

            stack.Push(42);
            value = stack.Peek();
            Assert.AreEqual(42, value, "Last value = 17");
            Assert.AreEqual(2, stack.Count, "Count should be 2 after peek");
            Assert.IsFalse(stack.IsEmpty, "Stack should not be empty as count > 0");
        }
    }
}
