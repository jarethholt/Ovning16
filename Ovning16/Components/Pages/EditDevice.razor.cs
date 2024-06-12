using Microsoft.AspNetCore.Components;
using Ovning16.Contracts.Services;
using Ovning16.Models;

namespace Ovning16.Components.Pages;

public partial class EditDevice
{
    [Inject]
    public IDeviceDataService DeviceDataService { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Parameter]
    public Guid DeviceGuid { get; set; }

    [SupplyParameterFromForm]
    public DeviceUpdateDTO DeviceUpdateDTO { get; set; } = null!;

    public Device Device { get; set; } = null!;

    protected bool Saved = false;

    protected override void OnInitialized()
    {
        var device = DeviceDataService.GetDeviceByGuid(DeviceGuid);
        if (device is null)
            NavigationManager.NavigateTo("/devicenotfound");

        Device = device!;
        DeviceUpdateDTO = new(Device);
    }

    public void HandleSubmit()
    {
        DeviceDataService.UpdateDevice(Device, DeviceUpdateDTO);
        Saved = true;
    }
}
