class Program
{
    static void Main()
    {
        LinkedList list = new LinkedList();

        Console.WriteLine("Adding to the end");
        list.AddLast(10);
        list.AddLast(20);
        list.AddLast(30);
        list.PrintForward();  

        Console.WriteLine("\nAdding to the beginning");
        list.AddFirst(5);
        list.AddFirst(1);
        list.PrintForward();  

        Console.WriteLine("\nInsert element at index 2 (value 99)");
        list.Insert(2, 99);
        list.PrintForward();  

        Console.WriteLine("\nOutput in reverse order");
        list.PrintBackward();

        Console.WriteLine("\nClearing the list");
        list.Clear();
        list.PrintForward(); 
    }
}