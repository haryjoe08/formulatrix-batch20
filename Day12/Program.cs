class Program
{
    static void Main(string[] args)
    {
        QueueProcessor queue = new();

        queue.Enqueue("A", 1);
        queue.Enqueue("B", 5);
        queue.Enqueue("C", 5);

        queue.Process();
        queue.Process();
    }
}


class QueueProcessor
{
    readonly List<(string Value, int Priority)> _queue = new();

    public void Enqueue(string val, int p)
    {
        _queue.Add((val, p));
        Console.WriteLine($"Queued {val} with priority {p}");
    }

    public void Process()
    {
        if (_queue.Count == 0)
        {
            Console.WriteLine("Queue is empty");
            return;
        }

        int highestIndex = 0;

        for (int i = 1; i < _queue.Count; i++)
        {
            if (_queue[i].Priority > _queue[highestIndex].Priority)
            {
                highestIndex = i;
            }
        }

        string value = _queue[highestIndex].Value;

        _queue.RemoveAt(highestIndex);

        Console.WriteLine($"Processed {value}");
    }
}