public class TransportCompany
{
    public string Name { get; private set; }
    private List<Vehicle> Fleet;

    public TransportCompany(string name)
    {
        Name = name;
        Fleet = new List<Vehicle>();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        Fleet.Add(vehicle);
        Console.WriteLine($"Added {vehicle.GetType().Name} {vehicle.Model} to the {Name} fleet.");
    }

    public void DisplayFleet()
    {
        Console.WriteLine($"\n{Name} Fleet Information:");
        Console.WriteLine("-------------------------");
        
        if (Fleet.Count == 0)
        {
            Console.WriteLine("The fleet is empty.");
            return;
        }

        foreach (var vehicle in Fleet)
        {
            vehicle.DisplayInfo();
            Console.WriteLine("-------------------------");
        }
    }

    public bool SendVehicleOnTrip(int vehicleIndex, double distance)
    {
        if (vehicleIndex < 0 || vehicleIndex >= Fleet.Count)
        {
            Console.WriteLine("Invalid vehicle index.");
            return false;
        }

        var vehicle = Fleet[vehicleIndex];
        Console.WriteLine($"Sending {vehicle.GetType().Name} {vehicle.Model} on a {distance} km trip.");
        return vehicle.Drive(distance);
    }

    public void RefuelVehicle(int vehicleIndex, double amount, IRefuelingStation station)
    {
        if (vehicleIndex < 0 || vehicleIndex >= Fleet.Count)
        {
            Console.WriteLine("Invalid vehicle index.");
            return;
        }

        var vehicle = Fleet[vehicleIndex];
        Console.WriteLine($"Refueling {vehicle.GetType().Name} {vehicle.Model}.");
        station.RefuelVehicle(vehicle, amount);
    }
}