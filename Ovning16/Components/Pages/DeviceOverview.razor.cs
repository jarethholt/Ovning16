using Microsoft.AspNetCore.Components;
using Ovning16.Contracts.Services;
using Ovning16.Models;

namespace Ovning16.Components.Pages;

public partial class DeviceOverview
{
    [Inject]
    public IDeviceDataService DeviceDataService { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    public List<Device> Devices { get; set; } = [];

    protected override void OnInitialized() =>
        Devices.AddRange(DeviceDataService.GetDevices());
}
