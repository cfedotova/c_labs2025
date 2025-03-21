class Program
{
    static void Main()
    {
        Console.WriteLine(new string('=', 60));

        Console.WriteLine("Creating a new ArrayList of ints");
        ArrayList<int> num = new ArrayList<int>();

        Console.WriteLine("\nAdding elements 10, 20, 30, 4, 50");
        num.Add(10);
        num.Add(20);
        num.Add(30);
        num.Add(4);
        num.Add(50);

        Console.Write("Current list: ");
        num.Print();
        Console.WriteLine($"Count: {num.Count}");

        Console.WriteLine("\nInserting 25 at index 2");
        num.Insert(2, 25);
        Console.Write("After insertion: ");
        num.Print();

        Console.WriteLine("\nRemoving element at index 1");
        num.Remove(1);
        Console.Write("After removal: ");
        num.Print();

        int value = num.Get(2);
        Console.WriteLine($"\nElement at index 2: {value}\n");

        Console.WriteLine(new string('=', 60));
        Console.WriteLine("\nCreating a CustomArrayList of strings");
        ArrayList<string> str = new ArrayList<string>();
        str.Add("cat");
        str.Add("dog");
        str.Add("car");
        Console.Write("\nString list: ");
        str.Print();

        Console.WriteLine("\nResizing by adding more elements");
        for (int i = 0; i < 10; i++)
        {
            num.Add(i * 100);
        }

        Console.Write("After adding 10 more elements: ");
        num.Print();

        Console.WriteLine("\nClearing list");
        num.Clear();
        Console.Write("After clearing: ");
        num.Print();
        Console.WriteLine($"Count after clearing: {num.Count}");
    }
}