using Microsoft.AspNetCore.Components;
using Ovning16.Contracts.Services;
using Ovning16.Models;

namespace Ovning16.Components.Pages;

public partial class DeviceDetails
{
    [Inject]
    public IDeviceDataService DeviceDataService { get; set; } = null!;

    [Parameter]
    public Guid DeviceGuid { get; set; }

    public Device Device { get; set; } = new();
    protected bool FinishedSearch { get; set; } = false;
    private Device? _device;
    protected bool FoundDevice { get; set; } = false;

    protected override void OnInitialized()
    {
        _device = DeviceDataService.GetDeviceByGuid(DeviceGuid);
        FinishedSearch = true;
        if (_device is not null)
        {
            FoundDevice = true;
            Device = _device;
        }
    }
}
