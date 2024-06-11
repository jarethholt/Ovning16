using Microsoft.AspNetCore.Components;
using Ovning16.Contracts.Services;
using Ovning16.Models;
using Ovning16.Services;

namespace Ovning16.Components.Pages;

public partial class DeviceDetails
{
    [Parameter]
    public Guid DeviceGuid { get; set; }

    [Inject]
    public IDeviceDataService DeviceDataService { get; set; } = null!;

    public Device? Device { get; set; }

    protected override void OnInitialized() =>
        Device = DeviceDataService.GetDeviceByGuid(DeviceGuid);
}
