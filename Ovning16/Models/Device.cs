namespace Ovning16.Models;

public class Device
{
    public const string DateFormat = "yyyy-MM-ddTHH:mmZ";

    // Primary properties
    // DeviceId should only be used if backed by actual database
    //public int DeviceId { get; set; }
    public Guid DeviceGuid { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string? NickName { get; set; } = null;
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
        /* Summarize the amount of time since last connection.
         * Rather than a complete "2 days, 4 hours, 13 minutes, 45 seconds",
         * round down to the number of days or hours or minutes as appropriate.
         * Break points are at 1 day (1 day, 1 hour, 2 minutes => 1 day);
         * and 3 hours (4 hours, 18 minutes => 4 hours);
         * anything less than 3 hours in minutes (1 hour 5 minutes => 65 minutes).
         */
        if (!HasBeenConnected)
            return string.Empty;
        else if (TimeSinceLastConnection >= new TimeSpan(days: 1, 0, 0, 0))
        {
            var amount = (int)TimeSinceLastConnection.TotalDays;
            var suffix = (amount == 1) ? "" : "s";
            return $"{amount} day{suffix}";
        }
        else if (TimeSinceLastConnection >= new TimeSpan(hours: 3, 0, 0))
            return $"{(int)TimeSinceLastConnection.TotalHours} hours";
        else
        {
            var amount = (int)TimeSinceLastConnection.TotalMinutes;
            var suffix = (amount == 1) ? "" : "s";
            return $"{amount} minute{suffix}";
        }
    }
}
