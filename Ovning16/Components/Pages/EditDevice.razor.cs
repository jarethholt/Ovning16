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
    public DeviceUpdateDTO DeviceUpdateDTO { get; set; } = new();

    public Device Device { get; set; } = new();

    protected void SetDevice(Device device)
    {
        Device = device;
        DeviceUpdateDTO = new(Device);
    }

    protected bool Saved = false;

    public void HandleSubmit()
    {
        DeviceDataService.UpdateDevice(Device, DeviceUpdateDTO);
        Saved = true;
    }
}
