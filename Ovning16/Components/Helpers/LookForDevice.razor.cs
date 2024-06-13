using Microsoft.AspNetCore.Components;
using Ovning16.Contracts.Services;
using Ovning16.Models;

namespace Ovning16.Components.Helpers;

public partial class LookForDevice
{
    [Parameter]
    public IDeviceDataService DeviceDataService { get; set; } = null!;
    [Parameter]
    public Guid DeviceGuid { get; set; }
    [Parameter]
    public EventCallback<Device> SetDevice { get; set; }
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    public Device Device { get; set; } = new();
    protected bool FinishedSearch = false;
    private Device? _device;
    protected bool FoundDevice = false;
    protected bool Saved = false;

    protected async override Task OnInitializedAsync()
    {
        _device = DeviceDataService.GetDeviceByGuid(DeviceGuid);
        FinishedSearch = true;
        if (_device is not null)
        {
            FoundDevice = true;
            await SetDevice.InvokeAsync(_device);
        }
    }
}
