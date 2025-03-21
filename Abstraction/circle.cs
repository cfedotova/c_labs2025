public class Circle : Shape
{
    private double radius;

    public Circle(double radius, Color color) : base(color)
    {
        this.radius = radius;
    }

    public override double Area()
    {
        return Math.PI * Math.Pow(radius, 2);
    }

    public override double Perimeter()
    {
        return 2 * Math.PI * radius;
    }
}