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

    public void HandleSubmit() =>
        _ = DeviceDataService.AddDevice(DeviceAddDTO);
}
