using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with different priorities to the queue.
    // Expected Result: Dequeue returns the item with the highest priority first.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add an item with the highest priority as the last item.
    // Expected Result: Dequeue should find and return the last item.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("Highest", 10);

        Assert.AreEqual("Highest", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Items with equal priority should respect insertion order (FIFO).
    // Expected Result: First inserted item comes out first.
    public void TestPriorityQueue_SamePriorityOrder()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 2);
        priorityQueue.Enqueue("Second", 2);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Peek should return the highest priority item without removing it.
    // Expected Result: Peek and Dequeue return the same item.
    public void TestPriorityQueue_PeekConsistency()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);

        Assert.AreEqual("High", priorityQueue.Peek());
        Assert.AreEqual("High", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue on empty queue should throw.
    // Expected Result: InvalidOperationException is thrown.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Stress test with many items.
    // Expected Result: Items come out in descending priority order.
    public void TestPriorityQueue_StressTest()
    {
        var priorityQueue = new PriorityQueue();

        for (int i = 0; i < 50; i++)
            priorityQueue.Enqueue($"Item{i}", i);

        for (int i = 49; i >= 0; i--)
            Assert.AreEqual($"Item{i}", priorityQueue.Dequeue());
    }
}
