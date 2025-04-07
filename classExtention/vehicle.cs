public abstract class Vehicle
{
    public string Model { get; set; }
    public double FuelCapacity { get; protected set; }
    public double CurrentFuelLevel { get; protected set; }
    public double FuelConsumption { get; protected set; }

    protected Vehicle(string model, double fuelCapacity, double fuelConsumption)
    {
        Model = model;
        FuelCapacity = fuelCapacity;
        FuelConsumption = fuelConsumption;
        CurrentFuelLevel = fuelCapacity / 2;
    }

    public virtual bool Drive(double distance)
    {
        double fuelNeeded = distance * FuelConsumption / 100;
        
        if (fuelNeeded > CurrentFuelLevel)
        {
            Console.WriteLine($"Not enough fuel to drive {distance} km.");
            return false;
        }
        
        CurrentFuelLevel -= fuelNeeded;
        Console.WriteLine($"{this.GetType().Name} {Model} drove {distance} km. Remaining fuel: {CurrentFuelLevel:F2} liters.");
        return true;
    }

    public virtual void Refuel(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid refuel amount.");
            return;
        }

        if (CurrentFuelLevel + amount > FuelCapacity)
        {
            CurrentFuelLevel = FuelCapacity;
            Console.WriteLine($"Tank is now full. ({FuelCapacity} liters)");
        }
        else
        {
            CurrentFuelLevel += amount;
            Console.WriteLine($"Added {amount} liters of fuel. Current level: {CurrentFuelLevel:F2} liters.");
        }
    }

    public abstract void DisplayInfo();
}