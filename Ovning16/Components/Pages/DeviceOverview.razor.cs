using Ovning16.Models;
using Ovning16.Services;

namespace Ovning16.Components.Pages;

public partial class DeviceOverview
{
    public List<Device> Devices { get; set; } = [];

    protected override void OnInitialized() =>
        Devices = DeviceDataService.Devices;
}
