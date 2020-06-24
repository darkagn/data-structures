using DataStructures.Queues;
using NUnit.Framework;

namespace DataStructuresTest.Queues
{
    /// <summary>
    /// Unit test fixture for the <see cref="Dequeue{T}"/> class.
    /// </summary>
    [TestFixture]
    public class DequeueTest
    {
        /// <summary>
        /// Tests that the <see cref="Dequeue{T}.EnqueueFirst(T)"/> method inserts the item as the first element in the queue.
        /// </summary>
        [Test]
        public void EnqueueFirstShouldInsertAtBeginningOfQueue()
        {
            Dequeue<int> queue = new Dequeue<int>();
            Assert.IsNotNull(queue, "Queue should not be null after construction");
            Assert.AreEqual(0, queue.Count, "Count should be zero for new queue");
            Assert.IsTrue(queue.IsEmpty, "Count should be considered empty");

            queue.EnqueueFirst(17);
            Assert.AreEqual(1, queue.Count, "Count should be 1 after enqueue");
            Assert.IsFalse(queue.IsEmpty, "Queue should not be empty after enqueue");
            Assert.AreEqual(17, queue.Peek(), "First item should be 17");

            queue.EnqueueFirst(42);
            Assert.AreEqual(2, queue.Count, "Count should be 2 after enqueue");
            Assert.IsFalse(queue.IsEmpty, "Queue should not be empty after enqueue");
            Assert.AreEqual(42, queue.Peek(), "First item should be 42");
        }

        /// <summary>
        /// Tests that the <see cref="Dequeue{T}.DequeueLast"/> method throws an exception when called on an empty queue.
        /// </summary>
        [Test]
        public void DequeueLastOnEmptyQueueShouldThrowException()
        {
            Dequeue<int> queue = new Dequeue<int>();

            _ = Assert.Throws(typeof(QueueUnderflowException), () => queue.Dequeue(), "Dequeue on empty queue should throw exception");
        }

        /// <summary>
        /// Tests that the <see cref="Dequeue{T}.DequeueLast"/> function returns the last element in the queue and decreases the count by one.
        /// </summary>
        [Test]
        public void DequeueLastOnNonEmptyQueueShouldReturnLastElementAndDecreaseCountByOne()
        {
            Dequeue<int> queue = new Dequeue<int>();
            queue.Enqueue(17);
            queue.Enqueue(42);
            Assert.AreEqual(2, queue.Count, "Count should be 2 after enqueue");
            Assert.IsFalse(queue.IsEmpty, "Queue should not be empty after enqueue");

            int value = queue.DequeueLast();
            Assert.AreEqual(42, value, "dequeued value should be 42");
            Assert.AreEqual(1, queue.Count, "Count should be 1 after dequeue");
            Assert.IsFalse(queue.IsEmpty, "Queue should not be empty as count > 0");

            value = queue.DequeueLast();
            Assert.AreEqual(17, value, "dequeued value should be 17");
            Assert.AreEqual(0, queue.Count, "Count should be 0 after dequeue");
            Assert.IsTrue(queue.IsEmpty, "Queue should be empty as count = 0");
        }

        /// <summary>
        /// Tests that the <see cref="Dequeue{T}.PeekLast"/> method throws an exception when called on an empty queue.
        /// </summary>
        [Test]
        public void PeekLastOnEmptyQueueShouldThrowException()
        {
            Dequeue<int> queue = new Dequeue<int>();

            _ = Assert.Throws(typeof(QueueUnderflowException), () => queue.PeekLast(), "Peek on empty queue should throw exception");
        }

        /// <summary>
        /// Tests that the <see cref="Dequeue{T}.PeekLast"/> function returns the last element in the queue but does not change the queue.
        /// </summary>
        [Test]
        public void PeekLastOnNonEmptyQueueShouldReturnLastElementButNotChangeQueue()
        {
            Dequeue<int> queue = new Dequeue<int>();

            queue.Enqueue(17);
            int value = queue.PeekLast();
            Assert.AreEqual(17, value, "Last value = 17");
            Assert.AreEqual(1, queue.Count, "Count should be 1 after peek");
            Assert.IsFalse(queue.IsEmpty, "Queue should not be empty as count > 0");

            value = queue.PeekLast();
            Assert.AreEqual(17, value, "Last value = 17");
            Assert.AreEqual(1, queue.Count, "Count should be 1 after peek");
            Assert.IsFalse(queue.IsEmpty, "Queue should not be empty as count > 0");

            queue.Enqueue(42);
            value = queue.PeekLast();
            Assert.AreEqual(42, value, "Last value = 42");
            Assert.AreEqual(2, queue.Count, "Count should be 2 after peek");
            Assert.IsFalse(queue.IsEmpty, "Queue should not be empty as count > 0");
        }
    }
}
