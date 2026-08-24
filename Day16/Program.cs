class Program
{
    static void Main(string[] args)
    {
        FooBarJazz fooBarJazz = new();

        fooBarJazz.AddRule(3, "foo");
        fooBarJazz.AddRule(5, "bar");

        Console.WriteLine(fooBarJazz.GenerateSequence(1, 15));
        Console.WriteLine(fooBarJazz.Evaluate(18));
    }
}

class FooBarJazz
{
    private readonly Dictionary<int, string> _rules = new();

    public void AddRule(int divisor, string output)
    {
        _rules.Add(divisor, output);
    }

    public string Evaluate(int number)
    {
        List<string> outputs = new();

        foreach (var (divisor, output) in _rules.OrderBy(rule => rule.Key))
        {
            if (number % divisor == 0)
            {
                outputs.Add(output);
            }
        }

        if (outputs.Count == 0)
        {
            return number.ToString();
        }

        return string.Join(" ", outputs);
    }

    public string GenerateSequence(int start, int end)
    {
        List<string> sequence = new();

        for (int number = start; number <= end; number++)
        {
            sequence.Add(Evaluate(number));
        }

        return string.Join(", ", sequence);
    }
}