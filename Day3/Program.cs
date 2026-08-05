class Program
{
    static void Main(string[] args)
    {
        StackProcessor stackProcessor = new();
        stackProcessor.Type("foo");
        stackProcessor.Type("bar");
        stackProcessor.Undo();
        stackProcessor.Undo();
    }
}

class StackProcessor
{
    readonly Stack<string> _stack = new();

    public void Type(string value)
    {
        _stack.Push(value);
        System.Console.WriteLine($"Typed {value}");
    }

    public void Undo()
    {
        if (_stack.Count == 0)
        {
            System.Console.WriteLine("Stack is empty");
            return;
        }
        string value = _stack.Pop();
        System.Console.WriteLine($"Undid {value}");
    }

}