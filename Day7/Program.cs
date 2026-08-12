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
    readonly Queue<string> _queue = new();

    public void Enqueue(string val)
    {
        _queue.Enqueue(val);
        Console.WriteLine($"Queued {val}");
    }


    public void EnqueueVip(string val)
    {
        Queue<string> temp = new();

        temp.Enqueue(val);

        while (_queue.Count > 0)
        {
            temp.Enqueue(_queue.Dequeue());
        }

        while (temp.Count > 0)
        {
            _queue.Enqueue(temp.Dequeue());
        }

        Console.WriteLine($"VIP Queued {val}");
    }


    public void Process()
    {
        if (_queue.Count == 0)
        {
            Console.WriteLine("Queue is empty");
            return;
        }

        string value = _queue.Dequeue();

        Console.WriteLine($"Processed {value}");
    }
}
