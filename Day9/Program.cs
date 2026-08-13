class Program
{
    static void Main(string[] args)
    {
        Sequence sequence = new();

        sequence.Append(5);
        sequence.Append(10);
        sequence.Append(15);

        sequence.Print();
        sequence.PrintReverse();
    }
}

class Node
{
    public int Value { get; set; }
    public Node? Next { get; set; }
    public Node? Previous { get; set; }

    public Node(int value)
    {
        Value = value;
    }
}

class Sequence
{
    private Node? head;
    private Node? tail;

    public void Append(int value)
    {
        Node newNode = new(value);

        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail!.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
        }

        Console.WriteLine($"Appended {value}");
    }

    public void Print()
    {
        Node? current = head;

        Console.Write("Sequence: ");

        while (current != null)
        {
            Console.Write(current.Value);

            if (current.Next != null)
            {
                Console.Write(" -> ");
            }

            current = current.Next;
        }

        Console.WriteLine();
    }

    public void PrintReverse()
    {
        Node? current = tail;

        Console.Write("Reversed: ");

        while (current != null)
        {
            Console.Write(current.Value);

            if (current.Previous != null)
            {
                Console.Write(" -> ");
            }

            current = current.Previous;
        }

        Console.WriteLine();
    }
}