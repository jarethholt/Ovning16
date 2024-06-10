using Ovning16.Contracts.Services;
using Ovning16.Models;

namespace Ovning16.Services;

public class DeviceDataService : IDeviceDataService
{
    private static List<Device>? _devices;

    public static List<Device> Devices
    {
        get
        {
            _devices ??= InitializeDevices();
            return _devices;
        }
    }

    public static void Reset() =>
        _devices = InitializeDevices();

    private static List<Device> InitializeDevices()
    {
        Device d1 = new()
        {
            DeviceId = 1,
            Name = "Weather mast",
            Description = "Standard weather mast with temperature, humidity, and wind sensors",
            IsOnline = true,
            UpdateEvents = [new DateTime(2024, 3, 1), new DateTime(2024, 4, 1), new DateTime(2024, 5, 1), new DateTime(2024, 6, 1)]
        };
        Device d2 = new()
        {
            DeviceId = 2,
            Name = "Surface radiometer",
            Description = "Pyranometers measuring upward and downward radiation",
            IsOnline = true,
            UpdateEvents = [new DateTime(2024, 6, 8), new DateTime(2024, 6, 9), new DateTime(2024, 6, 10)]
        };
        Device d3 = new()
        {
            DeviceId = 3,
            Name = "Ceilometer",
            Description = "Laser used to detect cloud base height",
            IsOnline = false,
            UpdateEvents = [new DateTime(2024, 6, 4), new DateTime(2024, 6, 7), new DateTime(2024, 6, 10)]
        };
        Device d4 = new()
        {
            DeviceId = 4,
            Name = "Radiosonde",
            Description = "Weather balloon with attached Vaisala instrument",
            IsOnline = true,
            UpdateEvents = [new DateTime(2024, 6, 10, 0, 0, 0), new DateTime(2024, 6, 10, 6, 0, 0), new DateTime(2024, 6, 10, 12, 0, 0), new DateTime(2024, 6, 10, 18, 0, 0)]
        };
        Device d5 = new()
        {
            DeviceId = 5,
            Name = "Doppler Lidar (WindCube)",
            Description = "Lidar using particles to determine wind profiles",
            IsOnline = false,
            UpdateEvents = [new DateTime(2024, 6, 1), new DateTime(2024, 6, 8)]
        };
        Device d6 = new()
        {
            DeviceId = 6,
            Name = "Microwave radiometer (HATPRO)",
            Description = "Passive microwave radiometer for measuring liquid and ice water",
            IsOnline = true,
            UpdateEvents = [new DateTime(2024, 6, 1), new DateTime(2024, 6, 8)]
        };
        Device d7 = new()
        {
            DeviceId = 7,
            Name = "Laser disdrometer (Parsivel)",
            Description = "Laser determining size and speed of falling precipitation",
            IsOnline = false,
            UpdateEvents = []
        };

        return [d1, d2, d3, d4, d5, d6, d7];
    }

    public Device AddDevice(Device device)
    {
        // Update the device's ID
        int nextId = Devices.Select(d => d.DeviceId).Max() + 1;
        device.DeviceId = nextId;
        Devices.Add(device);
        return Devices[^1];
    }

    public void DeleteDevice(Device device) =>
        Devices.Remove(device);

    public Device? GetDeviceByGuid(Guid guid) =>
        Devices.FirstOrDefault(d => d.DeviceGuid == guid);

    public Device? GetDeviceByGuid(string guidString) =>
        Devices.FirstOrDefault(d => d.DeviceGuid == Guid.Parse(guidString));

    public Device? GetDeviceById(int id) =>
        Devices.FirstOrDefault(d => d.DeviceId == id);

    public IEnumerable<Device> GetDevices() =>
        Devices;

    public Device? UpdateDevice(Device device)
    {
        Device? found = Devices.FirstOrDefault(d => d.DeviceGuid == device.DeviceGuid);
        if (found is null)
            return null;

        found.DeviceId = device.DeviceId;
        found.Name = device.Name;
        found.Description = device.Description;
        found.IsOnline = device.IsOnline;
        found.UpdateEvents = device.UpdateEvents;
        return found;
    }
}
