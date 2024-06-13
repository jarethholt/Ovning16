using Microsoft.AspNetCore.Components;
using Ovning16.Contracts.Services;
using Ovning16.Models;

namespace Ovning16.Components.Pages;

public partial class DeleteDevice
{
    [Inject]
    public IDeviceDataService DeviceDataService { get; set; } = null!;

    [Parameter]
    public Guid DeviceGuid { get; set; }

    public Device Device { get; set; } = new();

    protected void SetDevice(Device device) =>
        Device = device;

    protected bool Saved = false;

    public void HandleDelete()
    {
        DeviceDataService.DeleteDevice(Device);
        Saved = true;
    }

    private (string, string)[] LinkHrefsAndTexts => [
        ($"/devicedetails/{Device.DeviceGuid}", "Device details"),
        ($"/editdevice/{Device.DeviceGuid}", "Edit device"),
        ("/", "Back to overview")
        ];
}
