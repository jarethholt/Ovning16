namespace Ovning16.Models;

public abstract class DeviceDTO
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class DeviceUpdateDTO : DeviceDTO
{
    public DeviceUpdateDTO() { }

    public DeviceUpdateDTO(Device device)
    {
        Name = device.Name;
        Description = device.Description;
    }

    public void UpdateDeviceInfo(Device device)
    {
        device.Name = Name;
        device.Description = Description;
    }
}

public class DeviceAddDTO : DeviceDTO
{
    public bool StartsOnline { get; set; }

    public Device ToDevice()
    {
        List<DateTime> connectionEvents = StartsOnline ? [DateTime.UtcNow] : new();
        return new()
        {
            Name = Name,
            Description = Description,
            IsOnline = StartsOnline,
            ConnectionEvents = connectionEvents
        };
    }
}
