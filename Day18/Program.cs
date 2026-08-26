class Program
{
    static void Main(string[] args)
    {
        History history = new();

        history.AddValidationRule(word => !string.IsNullOrWhiteSpace(word));
        history.AddValidationRule(word => word.Length <= 10);

        System.Console.WriteLine(history.Type("hello"));
        System.Console.WriteLine(history.Type(""));
    }
}


class History
{
    private readonly List<Func<string, bool>> _rules = new();

    public void AddValidationRule(Func<string, bool> rule)
    {
        _rules.Add(rule);
    }

    public string Type(string word)
    {
        foreach (Func<string, bool> rule in _rules)
        {
            var result = rule.Invoke(word);
            if(result == false)
            {
                return "Rejected";
            }
        }
        return $"Typed {word}";
    }
}