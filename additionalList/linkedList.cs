class LinkedList
{
    private class Node
    {
        public int Data;
        public Node Next;
        public Node Prev;

        public Node(int data)
        {
            Data = data;
        }
    }

    private Node head;
    private Node tail;
    private int count;

    public void AddLast(int data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
        }

        count++;
    }

    public void AddFirst(int data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head.Prev = newNode;
            head = newNode;
        }

        count++;
    }

    public void Insert(int index, int data)
    {
        if (index < 0 || index > count)
            throw new ArgumentOutOfRangeException();

        if (index == 0)
        {
            AddFirst(data);
        }
        else if (index == count)
        {
            AddLast(data);
        }
        else
        {
            Node newNode = new Node(data);
            Node current = head;

            for (int i = 0; i < index; i++)
                current = current.Next;

            Node previous = current.Prev;

            newNode.Next = current;
            newNode.Prev = previous;
            previous.Next = newNode;
            current.Prev = newNode;

            count++;
        }
    }

    public void Remove(int data)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data == data)
            {
                if (current.Prev != null)
                    current.Prev.Next = current.Next;
                else
                    head = current.Next;

                if (current.Next != null)
                    current.Next.Prev = current.Prev;
                else
                    tail = current.Prev;

                count--;
                return;
            }
            current = current.Next;
        }
    }

    public void Clear()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public void PrintForward()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    public void PrintBackward()
    {
        Node current = tail;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Prev;
        }
        Console.WriteLine();
    }
}
