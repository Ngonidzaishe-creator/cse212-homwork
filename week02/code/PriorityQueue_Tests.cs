using Microsoft.VisualStudio.TestTools.UnitTesting;

// Tests cover enqueueing, highest-priority removal, FIFO order for ties, and the exact empty-queue exception.
[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Result: verifies items are returned from highest to lowest priority.
    // Defect(s) Found: initial implementation may fail if it does not select the highest priority.
    public void TestEnqueueAndDequeue()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("Task 1", 1);
        queue.Enqueue("Task 2", 2);
        queue.Enqueue("Task 3", 3);

        Assert.AreEqual("Task 3", queue.Dequeue());
        Assert.AreEqual("Task 2", queue.Dequeue());
        Assert.AreEqual("Task 1", queue.Dequeue());
    }

    [TestMethod]
    // Result: empty dequeue must throw InvalidOperationException with the exact required message.
    // Defect(s) Found: catches an incorrect exception type or message.
    public void TestDequeueEmptyQueue()
    {
        var queue = new PriorityQueue();
        var exception = Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
        Assert.AreEqual("The queue is empty.", exception.Message);
    }

    [TestMethod]
    // Result: items with equal priority must be returned in insertion order (FIFO).
    // Defect(s) Found: catches tie-breaking that does not preserve queue order.
    public void TestEnqueueSamePriority()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("Task 1", 2);
        queue.Enqueue("Task 2", 2);
        queue.Enqueue("Task 3", 2);

        Assert.AreEqual("Task 1", queue.Dequeue());
        Assert.AreEqual("Task 2", queue.Dequeue());
        Assert.AreEqual("Task 3", queue.Dequeue());
    }

    [TestMethod]
    // Result: among mixed priorities, the highest priority wins; equal high priorities still use FIFO.
    // Defect(s) Found: catches implementations that only work when priorities are strictly increasing.
    public void TestMixedPrioritiesAndTie()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("First high", 5);
        queue.Enqueue("Low", 1);
        queue.Enqueue("Second high", 5);
        queue.Enqueue("Medium", 3);

        Assert.AreEqual("First high", queue.Dequeue());
        Assert.AreEqual("Second high", queue.Dequeue());
        Assert.AreEqual("Medium", queue.Dequeue());
        Assert.AreEqual("Low", queue.Dequeue());
    }
}
