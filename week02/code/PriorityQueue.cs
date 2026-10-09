public class PriorityQueue
{
    private readonly List<(object Value, int Priority)> _queue = new();

    public void Enqueue(object value, int priority)
    {
        _queue.Add((value, priority));
    }

    public object Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        var highestPriorityIndex = 0;
        for (int i = 1; i < _queue.Count; i++)
        {
            if (_queue[i].Priority > _queue[highestPriorityIndex].Priority)
            {
                highestPriorityIndex = i;
            }
        }

        var value = _queue[highestPriorityIndex].Value;
        _queue.RemoveAt(highestPriorityIndex);
        return value;
    }

    public bool IsEmpty() => _queue.Count == 0;
}
