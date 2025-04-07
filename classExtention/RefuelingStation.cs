public class RefuelingStation : IRefuelingStation
{
    public double MaxFuelCapacity { get; private set; }

    public RefuelingStation(double maxFuelCapacity)
    {
        MaxFuelCapacity = maxFuelCapacity;
    }

    public void RefuelVehicle(Vehicle vehicle, double amount)
    {
        if (amount > MaxFuelCapacity)
        {
            Console.WriteLine($"Station can only provide up to {MaxFuelCapacity} liters per refuel.");
            amount = MaxFuelCapacity;
        }
        
        vehicle.Refuel(amount);
    }
}