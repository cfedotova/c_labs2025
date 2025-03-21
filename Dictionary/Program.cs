class Program
{
    static Dictionary<string, Device> networkDevices = new Dictionary<string, Device>
    {
        { "Device1", new Device("192.168.1.1", "compromised", new List<string> { "malware", "phishing" }) },
        { "Device2", new Device("192.168.1.2", "safe", new List<string>()) },
        { "Device3", new Device("192.168.1.3", "compromised", new List<string> { "ransomware" }) }
    };

    static void Main()
    {
        Console.WriteLine("All devices in the network:");
        DisplayDevices();

        Console.WriteLine("\nUpdating security status of Device1 to 'safe':");
        UpdateSecurityStatus("Device1", "safe");

        Console.WriteLine("\nRemoving threat 'malware' from Device1:");
        RemoveThreat("Device1", "malware");

        Console.WriteLine("\nDisplaying compromised devices:");
        DisplayCompromisedDevices();
    }

    static void DisplayDevices()
    {
        foreach (var device in networkDevices)
        {
            Console.WriteLine($"{device.Key}: IP - {device.Value.IpAddress}, Status - {device.Value.SecurityStatus}, Threats - {string.Join(", ", device.Value.ThreatsDetected)}");
        }
    }

    static void UpdateSecurityStatus(string device, string newStatus)
    {
        if (networkDevices.ContainsKey(device))
        {
            networkDevices[device].SecurityStatus = newStatus;
            Console.WriteLine($"Security status of {device} updated to {newStatus}.");
        }
        else
        {
            Console.WriteLine($"Device {device} not found in the network.");
        }
    }

    static void RemoveThreat(string device, string threat)
    {
        if (networkDevices.ContainsKey(device))
        {
            if (networkDevices[device].ThreatsDetected.Contains(threat))
            {
                networkDevices[device].ThreatsDetected.Remove(threat);
                Console.WriteLine($"Threat '{threat}' removed from {device}.");
            }
            else
            {
                Console.WriteLine($"Threat '{threat}' not found on {device}.");
            }
        }
        else
        {
            Console.WriteLine($"Device {device} not found in the network.");
        }
    }

    static void DisplayCompromisedDevices()
    {
        Console.WriteLine("Compromised devices in the network:");
        foreach (var device in networkDevices)
        {
            if (device.Value.SecurityStatus == "compromised")
            {
                Console.WriteLine($"{device.Key}: IP - {device.Value.IpAddress}, Threats - {string.Join(", ", device.Value.ThreatsDetected)}");
            }
        }
    }
}

class Device
{
    public string IpAddress { get; set; }
    public string SecurityStatus { get; set; }
    public List<string> ThreatsDetected { get; set; }

    public Device(string ipAddress, string securityStatus, List<string> threatsDetected)
    {
        IpAddress = ipAddress;
        SecurityStatus = securityStatus;
        ThreatsDetected = threatsDetected;
    }
}
