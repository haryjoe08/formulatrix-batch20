
class Program
{
    static void Main(string[] args)
    {
        MyList myList = new();

        myList.SetSorting((a, b) => a.CompareTo(b));

        myList.AddFilter(x => x > 3);
        myList.AddFilter(x => x % 2 == 0);

        myList.Append(10);
        myList.Append(3);
        myList.Append(8);
        myList.Append(2);
        myList.Append(6);
        myList.Append(1);

        myList.Print();
    }
}

class MyList
{
    private List<int> _values = new();

    private Func<int, int, int>? _comparer;

    private List<Func<int, bool>> _filterRules = new();

    public void SetSorting(Func<int, int, int> comparer)
    {
        _comparer = comparer;
    }

    public void AddFilter(Func<int, bool> filterRule)
    {
        _filterRules.Add(filterRule);
    }

    public void Append(int val)
    {
        _values.Add(val);
    }

    public void Print()
    {
        List<int> result = new(_values);

        foreach (Func<int, bool> filterRule in _filterRules)
        {
            result = result.Where(filterRule).ToList();
        }

        if (_comparer != null)
        {
            result.Sort((a, b) => _comparer(a, b));
        }

        foreach (int value in result)
        {
            Console.WriteLine(value);
        }
    }
}