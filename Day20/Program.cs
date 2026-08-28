class Program
{
    static void Main(string[] args)
    {
        QueueProcessor<int> queue = new();

        queue.SetCapacity(3);
        queue.SetOverWritePolicy(false);

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Print();
    }
}

public class QueueProcessor<T>
{
    private T[]? _buffer;
    private int _front;
    private int _rear;
    private int _count;
    private bool _isOverWriteEnabled;
    public void SetCapacity(int n)
    {
        if (n <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "value must be greater than zero");
        }
        _buffer = new T[n];
        _front = 0;
        _rear = 0;
        _count = 0;

    }

    public void SetOverWritePolicy(bool isOverWriteEnabled)
    {
        _isOverWriteEnabled = isOverWriteEnabled;
    }

    public void Enqueue(T value)
    {
        if (_buffer == null)
        {
            throw new InvalidOperationException("must set buffer size first");
        }
        if (_count == _buffer.Length)
        {
            if (_isOverWriteEnabled)
            {
                _front = (_front + 1) % _buffer.Length;
                _count--;

            }
            else
            {
                 return;
            }
        }

        _buffer[_rear] = value;
        _rear = (_rear + 1) % _buffer.Length;
        _count++;

    }

    public void Print()
    {
        if (_buffer == null)
        {
            throw new InvalidOperationException("must set buffer size first");
        }

        for (int i = 0; i < _count; i++)
        {
            int index = (_front + i) % _buffer.Length;
            System.Console.WriteLine(_buffer[index]);
        }
    }
}