using Microsoft.AspNetCore.Components;
using Ovning16.Contracts.Services;
using Ovning16.Models;

namespace Ovning16.Components.Pages;

public partial class AddDevice
{
    [Inject]
    public IDeviceDataService DeviceDataService { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [SupplyParameterFromForm]
    public DeviceAddDTO DeviceAddDTO { get; set; } = new();

    public Device? Device { get; set; } = null;

    public void HandleSubmit() =>
        Device = DeviceDataService.AddDevice(DeviceAddDTO);

    public void BackToOverview() =>
        NavigationManager.NavigateTo("/");

    public void ToDetails() =>
        NavigationManager.NavigateTo($"/devicedetails/{Device!.DeviceGuid}");
}
