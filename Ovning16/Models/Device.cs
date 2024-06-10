namespace Ovning16.Models;

public class Device
{
    // Primary properties
    public int DeviceId { get; set; }
    public Guid DeviceGuid { get; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsOnline { get; set; }

    // Navigation properties
    public List<DateTime> UpdateEvents { get; set; } = [];

    public DateTime MostRecentUpdate =>
        UpdateEvents.LastOrDefault();
}
