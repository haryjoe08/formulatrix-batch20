class Program
{
    static void Main(string[] args)
    {
        QueueProcessor queue = new();

        queue.Enqueue("A");
        queue.Enqueue("B");
        queue.Process();
        queue.Process();
    }
}

class QueueProcessor
{
    readonly Queue<string> _queue = new();
    public void Enqueue(string val)
    {
        _queue.Enqueue(val);
        System.Console.WriteLine($"Queued {val}");
    }

    public void Process()
    {
        if (_queue.Count == 0)
        {
            System.Console.WriteLine("Queue is empty");
            return;
        }

        string value = _queue.Dequeue();
        System.Console.WriteLine($"Processed {value}");
    }

}