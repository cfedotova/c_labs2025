public class Taxi : Vehicle
{
    public int PassengerCapacity { get; private set; }
    public bool HasMeter { get; private set; }

    public Taxi(string model, double fuelCapacity, double fuelConsumption, int passengerCapacity, bool hasMeter)
        : base(model, fuelCapacity, fuelConsumption)
    {
        PassengerCapacity = passengerCapacity;
        HasMeter = hasMeter;
    }

    public void StartMeter()
    {
        if (HasMeter)
        {
            Console.WriteLine("Meter started. Fare is now running.");
        }
        else
        {
            Console.WriteLine("This taxi does not have a meter.");
        }
    }

    public void StopMeter(double distance)
    {
        if (HasMeter)
        {
            double fare = distance * 0.5;
            Console.WriteLine($"Meter stopped. Total fare: ${fare:F2}");
        }
        else
        {
            Console.WriteLine("This taxi does not have a meter.");
        }
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Taxi: {Model}");
        Console.WriteLine($"Fuel Capacity: {FuelCapacity} liters");
        Console.WriteLine($"Current Fuel: {CurrentFuelLevel:F2} liters");
        Console.WriteLine($"Fuel Consumption: {FuelConsumption:F2} l/100km");
        Console.WriteLine($"Passenger Capacity: {PassengerCapacity}");
        Console.WriteLine($"Has Meter: {HasMeter}");
    }
}