using Microsoft.AspNetCore.Components;
using Ovning16.Contracts.Services;
using Ovning16.Models;

namespace Ovning16.Components.Pages;

public partial class DeviceDetails
{
    [Inject]
    public IDeviceDataService DeviceDataService { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Parameter]
    public Guid DeviceGuid { get; set; }

    public Device? Device { get; set; }

    protected override void OnInitialized()
    {
        Device = DeviceDataService.GetDeviceByGuid(DeviceGuid);
        if (Device is null)
            NavigationManager.NavigateTo("/devicenotfound");
    }
}
