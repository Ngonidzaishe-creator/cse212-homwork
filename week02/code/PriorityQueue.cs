using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
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
    public void TestDequeueEmptyQueue()
    {
        var queue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
    }

    [TestMethod]
    public void TestEnqueueSamePriority()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("Task 1", 2);
        queue.Enqueue("Task 2", 2);
        queue.Enqueue("Task 3", 2);

        Assert.AreEqual("Task 1", queue.Dequeue()); // FIFO
        Assert.AreEqual("Task 2", queue.Dequeue());
        Assert.AreEqual("Task 3", queue.Dequeue());
    }
}
