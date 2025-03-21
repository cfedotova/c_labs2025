class Matrix
{
    public List<List<double>> Data { get; }

    public Matrix(List<List<double>> data)
    {
        Data = data;
    }

    public static Matrix operator +(Matrix a, Matrix b)
    {
        if (a.Data.Count != b.Data.Count || a.Data[0].Count != b.Data[0].Count)
            throw new ArgumentException("Matrix must be the same length");
        
        return new Matrix(a.Data.Select((row, i) => row.Select((val, j) => val + b.Data[i][j]).ToList()).ToList());
    }

    public static Matrix operator -(Matrix a, Matrix b)
    {
        if (a.Data.Count != b.Data.Count || a.Data[0].Count != b.Data[0].Count)
            throw new ArgumentException("Matrix must be the same length");
        
        return new Matrix(a.Data.Select((row, i) => row.Select((val, j) => val - b.Data[i][j]).ToList()).ToList());
    }

    public static Matrix operator *(Matrix a, Matrix b)
    {
        if (a.Data[0].Count != b.Data.Count)
            throw new ArgumentException("The number of columns of the first matrix must be equal to the number of rows of the second matrix");
        
        var result = new List<List<double>>();
        for (int i = 0; i < a.Data.Count; i++)
        {
            var row = new List<double>();
            for (int j = 0; j < b.Data[0].Count; j++)
            {
                double sum = 0;
                for (int k = 0; k < b.Data.Count; k++)
                {
                    sum += a.Data[i][k] * b.Data[k][j];
                }
                row.Add(sum);
            }
            result.Add(row);
        }
        return new Matrix(result);
    }

    public static Matrix operator /(Matrix a, Matrix b)
    {
        Matrix inverse = b.Inverse();
        return a * inverse;
    }

    public Matrix Inverse()
    {
        if (Data.Count != 2 || Data[0].Count != 2)
            throw new ArgumentException("Calculating the inverse matrix is supported only for 2x2 matrices");
        
        double a = Data[0][0], b = Data[0][1], c = Data[1][0], d = Data[1][1];
        double det = a * d - b * c;
        
        if (det == 0)
            throw new ArgumentException("Matrix cannot be inversed");
        
        return new Matrix(new List<List<double>>
        {
            new List<double> { d / det, -b / det },
            new List<double> { -c / det, a / det }
        });
    }

    public override string ToString()
    {
        return string.Join("\n", Data.Select(row => string.Join(" ", row)));
    }

    public static Matrix Load(string filename)
    {
        try
        {
            var data = File.ReadAllLines(filename)
                .Select(line => line.Split().Select(double.Parse).ToList())
                .ToList();
            return new Matrix(data);
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
        File.WriteAllLines(filename, Data.Select(row => string.Join(" ", row)));
    }
}
