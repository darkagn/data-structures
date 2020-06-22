using DataStructures.LinkedList;
using NUnit.Framework;

namespace DataStructuresTest.LinkedList
{
    /// <summary>
    /// Unit test fixture for the <see cref="DataStructures.LinkedList.SortedLinkedList{T}"/> class.
    /// </summary>
    [TestFixture]
    public class SortedLinkedListTest
    {
        /// <summary>
        /// Tests the <see cref="SortedLinkedList{T}.Add(T)"/> method to ensure
        /// that the <see cref="SortedLinkedList{T}.Count"/> property is updated
        /// accordingly.
        /// </summary>
        [Test]
        public void AddShouldIncrementCount()
        {
            var list = new SortedLinkedList<int>();
            Assert.AreEqual(0, list.Count, "New list should have count of 0");

            list.Add(1);
            Assert.AreEqual(1, list.Count, "Add should increment count");
        }

        /// <summary>
        /// Tests the <see cref="SortedLinkedList{T}.Add(T)"/> method to ensure
        /// that the <see cref="SortedLinkedList{T}.IsEmpty"/> property is
        /// updated accordingly.
        /// </summary>
        [Test]
        public void AddToEmptyListShouldNoLongerBeEmpty()
        {
            var list = new SortedLinkedList<int>();
            Assert.IsTrue(list.IsEmpty, "New list should be empty");

            list.Add(1);
            Assert.IsFalse(list.IsEmpty, "Added item should no longer be empty list");
        }

        /// <summary>
        /// Tests the <see cref="SortedLinkedList{T}.Add(T)"/> method to ensure
        /// that sort order is maintained.
        /// </summary>
        public void AddShouldMaintainSortOrder()
        {
            var list = new SortedLinkedList<int>();
            list.Add(1);
            list.Add(7);
            list.Add(34);
            list.Add(-1);
            list.Add(9);

            Assert.AreEqual("34, 9, 7, 1, -1", list.ToString(), "Sort order should be maintained by adding values");
        }

        /// <summary>
        /// Tests the <see cref="SortedLinkedList{T}.Remove(T)"/> method to
        /// ensure that the <see cref="SortedLinkedList{T}.Count"/> property is
        /// updated accordingly.
        /// </summary>
        [Test]
        public void RemoveShouldDecrementCountWhenFound()
        {
            var list = new SortedLinkedList<int>();
            list.Add(1);

            Assert.IsTrue(list.Remove(1), "Remove should return true on success");
            Assert.AreEqual(0, list.Count, "Remove should decrement count on success");
        }

        /// <summary>
        /// Tests the <see cref="SortedLinkedList{T}.Remove(T)"/> method to ensure
        /// that the <see cref="SortedLinkedList{T}.IsEmpty"/> property is
        /// updated accordingly.
        /// </summary>
        [Test]
        public void RemoveOfSingleItemInListShouldNowBeEmpty()
        {
            var list = new SortedLinkedList<int>();
            list.Add(1);

            list.Remove(1);
            Assert.IsTrue(list.IsEmpty, "Remove should update IsEmpty on success");
        }

        /// <summary>
        /// Tests the <see cref="SortedLinkedList{T}.Remove(T)"/> method to
        /// ensure that the <see cref="SortedLinkedList{T}.Count"/> property is
        /// not updated if the value being removed is not found.
        /// </summary>
        [Test]
        public void RemoveShouldNotUpdateCountWhenNotFound()
        {
            var list = new SortedLinkedList<int>();
            list.Add(1);

            Assert.IsFalse(list.Remove(2), "Remove should return false on failure");
            Assert.AreEqual(1, list.Count, "Remove shoud not decrement count on failure");
        }

        /// <summary>
        /// Tests the <see cref="SortedLinkedList{T}.Remove(T)"/> method to ensure
        /// that sort order is maintained.
        /// </summary>
        public void RemoveShouldMaintainSortOrder()
        {
            var list = new SortedLinkedList<int>();
            list.Add(1);
            list.Add(7);
            list.Add(34);
            list.Add(-1);
            list.Add(9);

            list.Remove(9);

            Assert.AreEqual("34, 7, 1, -1", list.ToString(), "Sort order should be maintained by adding values");
        }

        /// <summary>
        /// Tests the <see cref="SortedLinkedList{T}.Search(T)"/> method to
        /// ensure that a non-null result is returned when the value is found
        /// in the list.
        /// </summary>
        [Test]
        public void SearchShouldReturnNonNullWhenFound()
        {
            var list = new SortedLinkedList<int>();
            list.Add(1);

            var actual = list.Search(1);
            Assert.IsNotNull(actual, "Search should return non-null result when value exists in the list");
            Assert.AreEqual(1, actual.Value, "Search should return the correct value when it exists in the list");
        }

        /// <summary>
        /// Tests the <see cref="SortedLinkedList{T}.Search(T)"/> method to
        /// ensure that a null result is returned when the value is not found
        /// in the list.
        /// </summary>
        [Test]
        public void SearchShouldReturnNullWhenNotFound()
        {
            var list = new SortedLinkedList<int>();
            list.Add(1);

            var actual = list.Search(2);
            Assert.IsNull(actual, "Search should return null result when value does not exist in the list");
        }
    }
}
