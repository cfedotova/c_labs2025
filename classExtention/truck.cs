public class Truck : Vehicle
{
    public double CargoCapacity { get; private set; }

    public Truck(string model, double fuelCapacity, double fuelConsumption, double cargoCapacity)
        : base(model, fuelCapacity, fuelConsumption)
    {
        CargoCapacity = cargoCapacity;
    }

    public override bool Drive(double distance)
    {
        double originalConsumption = FuelConsumption;
        FuelConsumption *= 1.2;
        
        bool result = base.Drive(distance);
        
        FuelConsumption = originalConsumption;
        return result;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Truck: {Model}");
        Console.WriteLine($"Fuel Capacity: {FuelCapacity} liters");
        Console.WriteLine($"Current Fuel: {CurrentFuelLevel:F2} liters");
        Console.WriteLine($"Fuel Consumption: {FuelConsumption:F2} l/100km");
        Console.WriteLine($"Cargo Capacity: {CargoCapacity} tons");
    }
}