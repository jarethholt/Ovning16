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

    [SupplyParameterFromForm]
    public DeviceUpdateDTO DeviceUpdateDTO { get; set; } = null!;

    public Device? Device { get; set; }

    protected override void OnInitialized()
    {
        Device = DeviceDataService.GetDeviceByGuid(DeviceGuid);
        DeviceUpdateDTO = Device is null ? new() : new(Device);
    }

    public void HandleSubmit()
    {
        if (Device is not null)
            DeviceDataService.UpdateDevice(Device, DeviceUpdateDTO);
    }
}
