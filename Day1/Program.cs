class Program
{
    static void Main(string[] args)
    {
        LogicExcercise1 logic1 = new();

        logic1.Generate(15);

    }
}

class LogicExcercise1
{
    public void Generate(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            System.Console.Write($"{GetText(i)}, ");
        }
    }

    private static string GetText(int value)
    {
        if (value % 3 == 0 && value % 5 == 0) return "foobar";
        if (value % 3 == 0) return "foo";
        if (value % 5 == 0) return "bar";
        return value.ToString();
    }
}