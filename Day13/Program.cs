
class Program
{
    static void Main(string[] args)
    {
        StackProcessor stackProcessor = new();

        stackProcessor.Type("A");
        stackProcessor.Type("B");
        stackProcessor.Undo();
        stackProcessor.Redo();
    }
}

class StackProcessor
{
    public readonly Stack<string> _stack = new();
    public readonly Stack<string> _undone = new();
    private const int _max = 3;

    public void Type(string value)
    {
        _undone.Clear();
        if (_stack.Count == _max)
        {
            // Temporary stack for storing the stack except the oldest one
            Stack<string> temp = new();

            //  storing the stack except the oldest one to temporary stack
            while (_stack.Count > 1)
            {
                temp.Push(_stack.Pop());
            }

            // pop the bottom value on the stack, which is the oldest one
            _stack.Pop();

            // restoring the remaining stack back to the original _stack
            while (temp.Count > 0)
            {
                _stack.Push(temp.Pop());
            }

            // push the value to the stack
            _stack.Push(value);

            Console.WriteLine($"Dropped bottom, Typed {value}");
            return;
        }

        // if stack < 3, push as usual
        _stack.Push(value);
        Console.WriteLine($"Typed {value}");
    }

    public void Undo()
    {
        if (_stack.Count == 0)
        {
            Console.WriteLine("Stack is empty");
            return;
        }

        string value = _stack.Pop();
        _undone.Push(value);
        Console.WriteLine($"Undid {value}");
    }

    public void Redo()
    {
        if (_undone.Count == 0)
        {
            Console.WriteLine("Nothing to redo");
            return;
        }

        string value = _undone.Pop();
        _stack.Push(value);
        System.Console.WriteLine($"Redid {value}");
    }


}
