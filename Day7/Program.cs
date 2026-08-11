class Program
{
    static void Main(string[] args)
    {
        QueueProcessor queue = new();

        queue.Enqueue("A");
        queue.Enqueue("B");
        queue.EnqueueVip("C");
        queue.Process();
        queue.Process();
        queue.Process();
    }
}

class QueueProcessor
{
    readonly LinkedList<string> _queue = new();
    public void Enqueue(string val)
    {
        _queue.AddLast(val);
        System.Console.WriteLine($"Queued {val}");
    }

    public void EnqueueVip(string val)
    {
        _queue.AddFirst(val);
        System.Console.WriteLine($"VIP Queued {val}");
    }

    public void Process()
    {
        if (_queue.Count == 0)
        {
            System.Console.WriteLine("Queue is empty");
            return;
        }

        // null possibility already checked above
        string value = _queue.First!.Value;
        _queue.RemoveFirst();
        System.Console.WriteLine($"Processed {value}");
    }

}