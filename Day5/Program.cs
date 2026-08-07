class Program
{
    static void Main(string[] args)
    {
        CircularQueue circularQueue = new(3);

        circularQueue.Log(1);
        circularQueue.Log(2);
        circularQueue.Log(3);
        circularQueue.Log(4);
        circularQueue.Read();
    }
}

class CircularQueue
{
    private readonly int[] _buffer;
    private int _front;
    private int _rear;
    private int _count;

    public CircularQueue(int capacity)
    {
        _buffer = new int[capacity];
    }

    public void Log(int value)
    {
        if (_count == _buffer.Length)
        {
            Console.WriteLine("Buffer is full");
            return;
        }

        _buffer[_rear] = value;
        _rear = (_rear + 1) % _buffer.Length;
        _count++;
        Console.WriteLine($"Logged {value}");
    }

    public void Read()
    {
        if (_count == 0)
        {
            Console.WriteLine("Buffer is empty");
            return;
        }

        int value = _buffer[_front];
        _front = (_front + 1) % _buffer.Length;
        _count--;
        Console.WriteLine($"Read {value}");
    }
}