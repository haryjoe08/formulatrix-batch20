class Program
{
    static void Main(string[] args)
    {
        Sequence sequence = new();

        sequence.Insert(5);
        sequence.Insert(2);
        sequence.Insert(8);

        sequence.Print();
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

    public void Insert(int value)
    {
        Node newNode = new(value);

        // if the list is empty, the new node becomes both head and tail
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        // if value less than head value
        else if (value <= head.Value)
        {
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
        }
        // if value greater than tail value
        else if (value >= tail!.Value)
        {
            tail.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
        }
        // neither
        else
        {
            Node current = head;

            // find the node before the new node
            while (current.Next != null && current.Next.Value < value)
            {
                current = current.Next;
            }

            // connect the new node to the next node
            newNode.Next = current.Next;
            newNode.Previous = current;

            // update the previous and next node references
            current.Next!.Previous = newNode;
            current.Next = newNode;
        }

        Console.WriteLine($"Inserted {value}");
    }

    public void Print()
    {
        Node? current = head;

        Console.Write("Sequence: ");

        // traverse the list from head to tail
        while (current != null)
        {
            Console.Write(current.Value);

            // print arrow if there is a next node
            if (current.Next != null)
            {
                Console.Write(" -> ");
            }

            current = current.Next;
        }

        Console.WriteLine();
    }
}