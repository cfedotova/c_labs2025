class Program
{
    static void Main()
    {
        VectorCalculator();

        MatrixCalculator();
    }

    static void VectorCalculator()
    {
        try
        {
            Vector v1 = Vector.Load("/Users/katia/RiderProjects/MatrixVectorClass/122111/vectorA.txt");
            Vector v2 = Vector.Load("/Users/katia/RiderProjects/MatrixVectorClass/122111/vectorB.txt");

            Vector additionResult = v1 + v2;
            Vector subtractionResult = v1 - v2;
            Vector multiplicationResult = v1 * 2;
            Vector divisionResult = v1 / 2;

            using (StreamWriter writer = new StreamWriter("/Users/katia/RiderProjects/MatrixVectorClass/122111/vector_results.txt"))
            {
                writer.WriteLine("Addition");
                writer.WriteLine($"{v1} + {v2} = {additionResult}");
                writer.WriteLine("Subtraction");
                writer.WriteLine($"{v1} - {v2} = {subtractionResult}");
                writer.WriteLine("Multiplication");
                writer.WriteLine($"{v1} * 2 = {multiplicationResult}");
                writer.WriteLine("Division");
                writer.WriteLine($"{v1} / 2 = {divisionResult}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void MatrixCalculator()
    {
        try
        {
            Matrix m1 = Matrix.Load("/Users/katia/RiderProjects/MatrixVectorClass/122111/matrixA.txt");
            Matrix m2 = Matrix.Load("/Users/katia/RiderProjects/MatrixVectorClass/122111/matrixB.txt");

            Matrix additionResult = m1 + m2;
            Matrix subtractionResult = m1 - m2;
            Matrix multiplicationResult = m1 * m2;
            Matrix divisionResult = m1 / m2;

            using (StreamWriter writer = new StreamWriter("/Users/katia/RiderProjects/MatrixVectorClass/122111/matrix_results.txt"))
            {
                writer.WriteLine("Addition");
                writer.WriteLine(additionResult);
                writer.WriteLine("Subtraction");
                writer.WriteLine(subtractionResult);
                writer.WriteLine("Multiplication");
                writer.WriteLine(multiplicationResult);
                writer.WriteLine("Division");
                writer.WriteLine(divisionResult);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
