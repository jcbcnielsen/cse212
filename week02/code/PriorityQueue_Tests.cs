using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add two priority 1 items, then one priority 2 item, then dequeue two items
    // Expected Result: The priority 2 item gets dequeued first, then the first priority 1 item
    // Defect(s) Found: Dequeueing did not check the last item in the queue, did not remove items from the queue, and selected the last item of a given priority rather than the first
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 1);
        priorityQueue.Enqueue("second", 1);
        priorityQueue.Enqueue("priority", 2);

        Assert.AreEqual("priority", priorityQueue.Dequeue());
        Assert.AreEqual("first", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add items of: priority 1, priority 2, priority 1, priority 3, priority 2, priority 1, then dequeue seven items
    // Expected Result: The fourth, second, fifth, first, third, and sixth items get dequeued in that order, then an error is thrown for attempting to dequeue an empty list
    // Defect(s) Found: None, likely fixed when testing TestPriorityQueue_1
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 1);
        priorityQueue.Enqueue("second", 2);
        priorityQueue.Enqueue("third", 1);
        priorityQueue.Enqueue("fourth", 3);
        priorityQueue.Enqueue("fifth", 2);
        priorityQueue.Enqueue("sixth", 1);

        Assert.AreEqual("fourth", priorityQueue.Dequeue());
        Assert.AreEqual("second", priorityQueue.Dequeue());
        Assert.AreEqual("fifth", priorityQueue.Dequeue());
        Assert.AreEqual("first", priorityQueue.Dequeue());
        Assert.AreEqual("third", priorityQueue.Dequeue());
        Assert.AreEqual("sixth", priorityQueue.Dequeue());
        Assert.ThrowsException<InvalidOperationException>(priorityQueue.Dequeue);
    }

    // Add more test cases as needed below.
}