using Microsoft.AspNetCore.Components;
using Ovning16.Contracts.Services;
using Ovning16.Models;

namespace Ovning16.Components.Pages;

public partial class DeleteDevice
{
    [Inject]
    public IDeviceDataService DeviceDataService { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Parameter]
    public Guid DeviceGuid { get; set; }

    public Device Device { get; set; } = null!;

    protected bool Saved = false;

    protected override void OnInitialized()
    {
        var device = DeviceDataService.GetDeviceByGuid(DeviceGuid);
        if (device is null)
            NavigationManager.NavigateTo("/devicenotfound");

        Device = device!;
    }

    public void HandleSubmit()
    {
        DeviceDataService.DeleteDevice(Device);
        Saved = true;
    }

    public void BackToOverview() =>
        NavigationManager.NavigateTo("/");

    public void ToEditDevice() =>
        NavigationManager.NavigateTo($"/editdevice/{Device.DeviceGuid}");
}
