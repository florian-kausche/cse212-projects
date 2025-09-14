using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add multiple items with different priorities and verify they are dequeued in priority order (highest first)
    // Expected Result: "urgent" (5), "important" (3), "normal" (1)
    // Defect(s) Found: The Dequeue method does not remove items from the queue and has an off-by-one error in the loop
    public void TestPriorityQueue_DifferentPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("normal", 1);
        priorityQueue.Enqueue("important", 3);
        priorityQueue.Enqueue("urgent", 5);

        Assert.AreEqual("urgent", priorityQueue.Dequeue());
        Assert.AreEqual("important", priorityQueue.Dequeue());
        Assert.AreEqual("normal", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add multiple items with the same priority and verify FIFO order is maintained
    // Expected Result: Items with equal priority should be dequeued in the order they were added
    // Defect(s) Found: The Dequeue method always takes the last item with equal priority instead of preserving FIFO order
    public void TestPriorityQueue_EqualPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 2);
        priorityQueue.Enqueue("second", 2);
        priorityQueue.Enqueue("third", 2);

        Assert.AreEqual("first", priorityQueue.Dequeue());
        Assert.AreEqual("second", priorityQueue.Dequeue());
        Assert.AreEqual("third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue
    // Expected Result: Should throw InvalidOperationException
    // Defect(s) Found: None - empty queue handling works correctly
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Mix of different priorities with repeated priorities
    // Expected Result: Higher priorities first, then equal priorities in FIFO order
    // Defect(s) Found: Items are not properly removed from the queue and equal priorities aren't handled in FIFO order
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low1", 1);
        priorityQueue.Enqueue("high", 3);
        priorityQueue.Enqueue("low2", 1);
        priorityQueue.Enqueue("medium", 2);

        Assert.AreEqual("high", priorityQueue.Dequeue());
        Assert.AreEqual("medium", priorityQueue.Dequeue());
        Assert.AreEqual("low1", priorityQueue.Dequeue());
        Assert.AreEqual("low2", priorityQueue.Dequeue());
    }
}