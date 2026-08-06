class Program
{
    static void Main(string[] args)
    {
        Sequence sequence = new();

        sequence.Append(5);
        sequence.Append(10);
        sequence.Print();
    }
}

class Node
{
    public int Value { get; set; }
    public Node? Next { get; set; }

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
            tail = newNode;

        }
        System.Console.WriteLine($"Appended {value}");
    }

    public void Print()
    {
        Node? current = head;

        System.Console.Write("Sequence: ");
        while (current != null)
        {
            System.Console.Write($"{current.Value}");

            if (current.Next != null)
            {

                System.Console.Write(" -> ");
            }
            current = current.Next;
        }
    }
}