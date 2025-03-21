public class Rectangle : Shape
{
    private double width;
    private double height;

    public Rectangle(double width, double height, Color color) : base(color)
    {
        this.width = width;
        this.height = height;
    }

    public override double Area()
    {
        return width * height;
    }

    public override double Perimeter()
    {
        return 2 * (width + height);
    }
}