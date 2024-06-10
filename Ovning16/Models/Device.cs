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

    public TimeSpan TimeSinceUpdate =>
        DateTime.UtcNow - MostRecentUpdate;

    public string FormattedUpdate()
    {
        DateTime updateTime = MostRecentUpdate;
        return updateTime == default ? "Never connected" : updateTime.ToString("yyyy-MM-dd T HH:mm Z");
    }

    public string FormattedTimeSinceUpdate()
    {
        if (MostRecentUpdate == default)
            return "Never connected";
        else if (TimeSinceUpdate >= new TimeSpan(days: 1, 0, 0, 0))
            return $"{(int)TimeSinceUpdate.TotalDays} days";
        else if (TimeSinceUpdate >= new TimeSpan(hours: 3, 0, 0))
            return $"{(int)TimeSinceUpdate.TotalHours} hours";
        else
            return $"{(int)TimeSinceUpdate.TotalMinutes} minutes";
    }
}
