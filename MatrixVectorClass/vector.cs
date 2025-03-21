class Vector
{
    public List<double> Coordinates { get; }

    public Vector(List<double> coordinates)
    {
        Coordinates = new List<double>(coordinates);
    }

    public static Vector operator +(Vector a, Vector b)
    {
        if (a.Coordinates.Count != b.Coordinates.Count)
            throw new ArgumentException("Vectors must be the same length");
        
        return new Vector(a.Coordinates.Zip(b.Coordinates, (x, y) => x + y).ToList());
    }

    public static Vector operator -(Vector a, Vector b)
    {
        if (a.Coordinates.Count != b.Coordinates.Count)
            throw new ArgumentException("Vectors must be the same length");
        
        return new Vector(a.Coordinates.Zip(b.Coordinates, (x, y) => x - y).ToList());
    }

    public static Vector operator *(Vector a, double scalar)
    {
        return new Vector(a.Coordinates.Select(x => x * scalar).ToList());
    }

    public static Vector operator /(Vector a, double scalar)
    {
        if (scalar == 0)
            throw new DivideByZeroException("Cannot be divided by 0");
        
        return new Vector(a.Coordinates.Select(x => x / scalar).ToList());
    }

    public override string ToString()
    {
        return "(" + string.Join(", ", Coordinates) + ")";
    }

    public static Vector Load(string filename)
    {
        try
        {
            string[] lines = File.ReadAllLines(filename);
            List<double> coordinates = lines[0].Split().Select(double.Parse).ToList();
            return new Vector(coordinates);
        }
        catch (FileNotFoundException)
        {
            throw new FileNotFoundException($"File '{filename}' not found");
        }
        catch (Exception)
        {
            throw new Exception($"Error in file '{filename}'");
        }
    }

    public void Save(string filename)
    {
        File.WriteAllText(filename, string.Join(" ", Coordinates) + "\n");
    }
}
