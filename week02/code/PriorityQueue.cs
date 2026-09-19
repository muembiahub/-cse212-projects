public class PriorityQueue
{
    private List<(int priority, int order, string value)> _items = new();
    private int _counter = 0;

    public void Enqueue(string item, int priority)
    {
        _items.Add((priority, _counter++, item));
    }

    public string Dequeue()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("Queue is empty.");

        // Find max priority, break ties by order
        var best = _items.OrderByDescending(x => x.priority)
                         .ThenBy(x => x.order)
                         .First();

        _items.Remove(best);
        return best.value;
    }

    public string Peek()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("Queue is empty.");

        return _items.OrderByDescending(x => x.priority)
                     .ThenBy(x => x.order)
                     .First().value;
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    // DO NOT MODIFY THE CODE IN THIS METHOD
    // The graders rely on this method to check if you fixed all the bugs, so changes to it will cause you to lose points.
    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}