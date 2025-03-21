public abstract class Shape
{
    protected Color color;

    public Shape(Color color)
    {
        this.color = color;
    }

    public abstract double Area();
    public abstract double Perimeter();

    public string Draw()
    {
        return $"Drawing {color.Fill()} {GetType().Name} with area {Area()} and perimeter {Perimeter()}";
    }
}