﻿namespace Ovning16.Models;

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
    public bool IsOnline { get; set; }
    public List<DateTime> UpdateEvents { get; set; } = [];

    public Device ToDevice() => new()
    {
        Name = Name,
        Description = Description,
        IsOnline = IsOnline,
        ConnectionEvents = UpdateEvents
    };
}
