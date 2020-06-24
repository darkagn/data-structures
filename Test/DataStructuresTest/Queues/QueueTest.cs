using DataStructures.Queues;
using NUnit.Framework;

namespace DataStructuresTest.Queues
{
    /// <summary>
    /// Unit test fixture for the <see cref="Queue{T}"/> class.
    /// </summary>
    [TestFixture]
    public class QueueTest
    {
        /// <summary>
        /// Tests that a newly constructed queue has a count of 0 and is considered empty.
        /// </summary>
        [Test]
        public void NewQueueShouldBeEmptyAndHaveZeroCount()
        {
            Queue<int> queue = new Queue<int>();
            Assert.IsNotNull(queue, "Queue should not be null after construction");
            Assert.AreEqual(0, queue.Count, "Count should be zero for new queue");
            Assert.IsTrue(queue.IsEmpty, "Queue should be considered empty");
        }

        /// <summary>
        /// Tests that the <see cref="Queue{T}.Enqueue(T)"/> function adds one to the value of count each time.
        /// </summary>
        [Test]
        public void EnqueueShouldAddOneToCountEachTime()
        {
            Queue<int> queue = new Queue<int>();
            Assert.IsNotNull(queue, "Queue should not be null after construction");
            Assert.AreEqual(0, queue.Count, "Count should be zero for new queue");
            Assert.IsTrue(queue.IsEmpty, "Stack should be considered empty");

            queue.Enqueue(17);
            Assert.AreEqual(1, queue.Count, "Count should be 1 after enqueue");
            Assert.IsFalse(queue.IsEmpty, "Queue should not be empty after enqueue");

            queue.Enqueue(42);
            Assert.AreEqual(2, queue.Count, "Count should be 2 after enqueue");
            Assert.IsFalse(queue.IsEmpty, "Queue should not be empty after enqueue");
        }

        /// <summary>
        /// Tests that the <see cref="Queue{T}.Dequeue"/> function throws an exception when called on an empty queue.
        /// </summary>
        [Test]
        public void DequeueOnEmptyQueueShouldThrowException()
        {
            Queue<int> queue = new Queue<int>();

            _ = Assert.Throws(typeof(QueueUnderflowException), () => queue.Dequeue(), "Dequeue on empty queue should throw exception");
        }

        /// <summary>
        /// Tests that the <see cref="Queue{T}.Dequeue"/> function returns the first element in the queue and decreases the count by one.
        /// </summary>
        [Test]
        public void DequeueOnNonEmptyQueueShouldReturnFirstElementAndDecreaseCountByOne()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(17);
            queue.Enqueue(42);
            Assert.AreEqual(2, queue.Count, "Count should be 2 after enqueue");
            Assert.IsFalse(queue.IsEmpty, "Queue should not be empty after enqueue");

            int value = queue.Dequeue();
            Assert.AreEqual(17, value);
            Assert.AreEqual(1, queue.Count, "Count should be 1 after dequeue");
            Assert.IsFalse(queue.IsEmpty, "Queue should not be empty as count > 0");

            value = queue.Dequeue();
            Assert.AreEqual(42, value);
            Assert.AreEqual(0, queue.Count, "Count should be 0 after dequeue");
            Assert.IsTrue(queue.IsEmpty, "Queue should be empty as count = 0");
        }

        /// <summary>
        /// Tests that the <see cref="Queue{T}.Peek"/> function throws an exception when called on an empty queue.
        /// </summary>
        [Test]
        public void PeekOnEmptyQueueShouldThrowException()
        {
            Queue<int> queue = new Queue<int>();

            _ = Assert.Throws(typeof(QueueUnderflowException), () => queue.Peek(), "Peek on empty queue should throw exception");
        }

        /// <summary>
        /// Tests that the <see cref="Queue{T}.Peek"/> function returns the first element in the queue but does not change the queue.
        /// </summary>
        [Test]
        public void PeekOnNonEmptyQueueShouldReturnFirstElementButNotChangeQueue()
        {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(17);
            int value = queue.Peek();
            Assert.AreEqual(17, value, "First value = 17");
            Assert.AreEqual(1, queue.Count, "Count should be 1 after peek");
            Assert.IsFalse(queue.IsEmpty, "Queue should not be empty as count > 0");

            value = queue.Peek();
            Assert.AreEqual(17, value, "First value = 17");
            Assert.AreEqual(1, queue.Count, "Count should be 1 after peek");
            Assert.IsFalse(queue.IsEmpty, "Queue should not be empty as count > 0");

            queue.Enqueue(42);
            value = queue.Peek();
            Assert.AreEqual(17, value, "First value = 17");
            Assert.AreEqual(2, queue.Count, "Count should be 2 after peek");
            Assert.IsFalse(queue.IsEmpty, "Queue should not be empty as count > 0");
        }
    }
}
