using Microsoft.AspNetCore.Components;
using Ovning16.Contracts.Services;
using Ovning16.Models;

namespace Ovning16.Components.Pages;

public partial class EditDevice
{
    [Inject]
    public IDeviceDataService DeviceDataService { get; set; } = null!;

    [Parameter]
    public Guid DeviceGuid { get; set; }

    public Device? Device { get; set; }
    public bool? DeviceFound { get; set; } = null;

    protected override void OnInitialized()
    {
        Device = DeviceDataService.GetDeviceByGuid(DeviceGuid);
        DeviceFound = (Device is not null);
    }

    protected override void OnAfterRender(bool firstRender)
        => DeviceFound = (Device is null);
}
