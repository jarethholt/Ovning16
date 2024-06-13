using Microsoft.AspNetCore.Components;
using Ovning16.Contracts.Services;

namespace Ovning16.Components.Widgets;

public partial class StatusSummary
{
    [Inject]
    public IDeviceDataService DeviceDataService { get; set; } = null!;

    public int NumberOnline { get; set; }
    public int NumberOffline { get; set; }

    protected override void OnInitialized()
    {
        (NumberOnline, NumberOffline) = DeviceDataService.NumberOfDevicesOnlineAndOffline();
    }
}
