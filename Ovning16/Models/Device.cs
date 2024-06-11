using System.Web;

namespace Ovning16.Models;

public class Device
{
    public const string DateFormat = "yyyy-MM-dd T HH:mm Z";

    // Primary properties
    public int DeviceId { get; set; }
    public Guid DeviceGuid { get; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    private bool _isOnline;
    public bool IsOnline {
        get => _isOnline;
        init => _isOnline = value;
    }

    // Navigation property
    private List<DateTime> _connectionEvents = [];
    public List<DateTime> ConnectionEvents {
        get => _connectionEvents;
        init => _connectionEvents = value;
    }

    // Method-like properties
    public bool HasBeenConnected =>
        _connectionEvents.Count != 0;

    public DateTime LastConnectionTime =>
        ConnectionEvents.LastOrDefault();

    public TimeSpan TimeSinceLastConnection =>
        DateTime.UtcNow - LastConnectionTime;

    public string ShortGuid =>
        $"{DeviceGuid.ToString()[..4]}...{DeviceGuid.ToString()[^4..]}";

    // Methods
    public void PingDevice() =>
        _connectionEvents.Add(DateTime.UtcNow);

    public void ToggleStatus()
    {
        _isOnline = !_isOnline;
        PingDevice();
    }

    public string FormatLastConnectionTime()
    {
        DateTime updateTime = LastConnectionTime;
        return !HasBeenConnected ? string.Empty : updateTime.ToString(DateFormat);
    }

    public string FormatTimeSinceLastConnection()
    {
        if (!HasBeenConnected)
            return string.Empty;
        else if (TimeSinceLastConnection >= new TimeSpan(days: 1, 0, 0, 0))
            return $"{(int)TimeSinceLastConnection.TotalDays} days";
        else if (TimeSinceLastConnection >= new TimeSpan(hours: 3, 0, 0))
            return $"{(int)TimeSinceLastConnection.TotalHours} hours";
        else
            return $"{(int)TimeSinceLastConnection.TotalMinutes} minutes";
    }
}
