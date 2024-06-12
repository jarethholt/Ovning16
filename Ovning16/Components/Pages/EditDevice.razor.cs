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

    public Device Device { get; set; } = null!;
    protected bool FinishedSearch { get; set; } = false;
    protected bool FoundDevice { get; set; } = false;
    private Device? _device;
    protected bool Saved = false;

    protected override void OnInitialized()
    {
        _device = DeviceDataService.GetDeviceByGuid(DeviceGuid);
        FinishedSearch = true;
        if (_device is not null)
        {
            FoundDevice = true;
            Device = _device;
            DeviceUpdateDTO = new(Device);
        }
    }

    public void HandleSubmit()
    {
        DeviceDataService.UpdateDevice(Device, DeviceUpdateDTO);
        Saved = true;
    }
}
