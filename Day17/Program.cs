class Program
{
    static void Main(string[] args)
    {
        QueueProcessor queue = new();
        queue.AddRule("urgent", 10);
        queue.AddRule("normal", 5);
        System.Console.WriteLine(queue.Enqueue("normal"));
        System.Console.WriteLine(queue.Enqueue("urgent"));



    }
}


class QueueProcessor
{
    readonly List<(string Value, int Priority)> _queue = new();
    readonly Dictionary<string, int> _rules = new();

    public void AddRule(string keyword, int priority)
    {
        _rules.Add(keyword, priority);
    }

    public string Enqueue(string value)
    {
        int priority = 0;

        foreach (var (keyword, priorityValue) in _rules)
        {
            if (keyword == value)
            {
                priority = priorityValue;

                break;
            }
        }
        _queue.Add((value, priority));
        return $"Queued with {value} {priority}";

    }
}