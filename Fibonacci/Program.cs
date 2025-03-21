class Program
{
    static void Main()
    {
        try
        {
            string numbersFilePath = "/Users/katia/RiderProjects/fibonacci/numbers.txt";
            int step = int.Parse(File.ReadAllText("/Users/katia/RiderProjects/fibonacci/steps.txt"));
            string numbersFromFile = File.ReadAllText(numbersFilePath).Trim();
            int[] numbers = numbersFromFile.Split(',').Select(int.Parse).ToArray();
            int limit = int.Parse(File.ReadAllText("/Users/katia/RiderProjects/fibonacci/limit.txt"));

            if (numbers.Length < 2)
            {
                throw new Exception("The numbers.txt file must contain at least two numbers");
            }

            var fibonacci = numbers.ToList();
            while (fibonacci.Count < step)
            {
                int next = fibonacci[^1] + fibonacci[^2];
                fibonacci.Add(next);
            }

            string stepsOutput = "Steps:\n" + string.Join(" ", fibonacci);
            string limitOutput = "\n\nLimit:\n" + string.Join(" ", fibonacci.Where(n => n < limit));

            File.WriteAllText("/Users/katia/RiderProjects/fibonacci/output.txt", stepsOutput + limitOutput);
            Console.WriteLine("The result has been written to output.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}