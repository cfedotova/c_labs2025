class Program
{
    static void Main()
    {
        try
        {
            List<Shape> shapes = ReadShapesFromFile("/Users/katia/RiderProjects/abstraction/abstraction/info.txt");
            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.Draw());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
        }
    }

    static List<Shape> ReadShapesFromFile(string filename)
    {
        List<Shape> figures = new List<Shape>();
        Dictionary<string, Color> colorMap = new Dictionary<string, Color>
        {
            { "Red", new Red() },
            { "Yellow", new Yellow() },
            { "Blue", new Blue() }
        };

        if (!File.Exists(filename))
            throw new FileNotFoundException($"The file '{filename}' does not exist.");

        foreach (string line in File.ReadAllLines(filename))
        {
            string[] parts = line.Trim().Split(',');
            if (parts.Length < 2)
            {
                Console.WriteLine($"Skipping invalid line: {line.Trim()}");
                continue;
            }

            string shapeType = parts[0];
            string colorName = parts[^1]; 

            if (!colorMap.ContainsKey(colorName))
            {
                Console.WriteLine($"Unknown color '{colorName}' in line: {line.Trim()}");
                continue;
            }

            Color color = colorMap[colorName];

            try
            {
                switch (shapeType)
                {
                    case "Circle":
                        double radius = double.Parse(parts[1]);
                        figures.Add(new Circle(radius, color));
                        break;
                    case "Rectangle":
                        double width = double.Parse(parts[1]);
                        double height = double.Parse(parts[2]);
                        figures.Add(new Rectangle(width, height, color));
                        break;
                    case "Square":
                        double side = double.Parse(parts[1]);
                        figures.Add(new Square(side, color));
                        break;
                    default:
                        Console.WriteLine($"Unknown shape type '{shapeType}' in line: {line.Trim()}");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing line: {line.Trim()}. Error: {ex.Message}");
            }
        }

        return figures;
    }
}
