using Microsoft.AspNetCore.Components;
using Ovning16.Contracts.Services;
using Ovning16.Models;

namespace Ovning16.Components.Pages;

public partial class AddDevice
{
    [Inject]
    public IDeviceDataService DeviceDataService { get; set; } = null!;

    [SupplyParameterFromForm]
    public DeviceAddDTO DeviceAddDTO { get; set; } = new();

    public Device Device { get; set; } = new();

    protected bool Saved { get; set; } = false;

    public void HandleSubmit()
    {
        Device = DeviceDataService.AddDevice(DeviceAddDTO);
        Saved = true;
    }

    protected (string, string)[] LinkHrefsAndTexts => [
        ($"/devicedetails/{Device.DeviceGuid}", "Device details"),
        ("/", "Back to overview")
        ];
}
